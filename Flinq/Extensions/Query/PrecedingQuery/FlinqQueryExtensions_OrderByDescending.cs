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

		private static List<T> Impl(object paramsPack)
		{
			var paramsArray = (object[])paramsPack;
			var query = (FlinqQuery<T>)paramsArray[0];
			var keySelector = (Func<T, TKey>)paramsArray[1];

			var finalList = query.Resolve();

			int count = finalList.Count;

			var indices = FlinqListPool<int>.Get();
			var keys = FlinqListPool<TKey>.Get();

			for(int i = 0; i < count; ++i)
			{
				indices.Add(i);
				keys.Add(keySelector(finalList[i]));
			}

			indices.Sort((a, b) => keys[b].CompareTo(keys[a]));

			var newList = FlinqListPool<T>.Get();

			for(int i = 0; i < count; ++i)
			{
				newList.Add(finalList[indices[i]]);
			}

			FlinqListPool<T>.Return(finalList);

			return newList;
		}
	}

	public static FlinqQuery<T> OrderByDescending<T, TKey>(this FlinqQuery<T> query, Func<T, TKey> keySelector) where TKey : IComparable<TKey>
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(keySelector == null)
			throw new ArgumentNullException("keySelector");

		var paramsPack = FlinqObjectsArrayPool.Get2();

		paramsPack[0] = query;
		paramsPack[1] = keySelector;

		var newQuery = FlinqQueryPool<T>.Get();

		newQuery.OnInit(ImplWrapper<T, TKey>.impl, paramsPack);

		return newQuery;
	}
}

}