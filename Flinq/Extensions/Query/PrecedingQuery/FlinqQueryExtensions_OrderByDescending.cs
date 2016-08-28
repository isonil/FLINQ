using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_OrderByDescending
{
	private static class ImplWrapper<T, TKey> where TKey : IComparable<TKey>
	{
		public static readonly FlinqQuery<T>.PrecedingQuery impl = Impl;

		private static FlinqList<T> Impl(object paramsPack)
		{
			var paramsArray = (object[])paramsPack;
			var query = (FlinqQuery<T>)paramsArray[0];
			var keySelector = (Func<T, TKey>)paramsArray[1];

			var finalList = query.Resolve();

			int count = finalList.count;
			var array = finalList.array;

			var indices = FlinqListPool<int>.Get();
			var keys = FlinqListPool<TKey>.Get();

			for(int i = 0; i < count; ++i)
			{
				indices.Add(i);
				keys.Add(keySelector(array[i]));
			}

			indices.SortDescending(keys);
			var indicesArray = indices.array;

			var newList = FlinqListPool<T>.Get();

			for(int i = 0; i < count; ++i)
			{
				newList.Add(array[indicesArray[i]]);
			}

			FlinqListPool<T>.Return(finalList);
			FlinqListPool<int>.Return(indices);
			FlinqListPool<TKey>.Return(keys);

			return newList;
		}
	}

	public static FlinqQuery<T> OrderByDescending<T, TKey>(this FlinqQuery<T> query, Func<T, TKey> keySelector) where TKey : IComparable<TKey>
	{
		if(keySelector == null)
			throw new ArgumentNullException("keySelector");

		var paramsPack = FlinqObjectsArrayPool.Get2();

		paramsPack[0] = query;
		paramsPack[1] = keySelector;

		return new FlinqQuery<T>(ImplWrapper<T, TKey>.impl, paramsPack);
	}
}

}