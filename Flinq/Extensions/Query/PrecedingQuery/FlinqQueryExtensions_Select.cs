using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_Select
{
	private static class ImplWrapper1<T, TResult>
	{
		public static readonly FlinqQuery<TResult>.PrecedingQuery impl = Impl;

		private static FlinqList<TResult> Impl(object paramsPack)
		{
			var paramsArray = (object[])paramsPack;
			var query = (FlinqQuery<T>)paramsArray[0];
			var selector = (Func<T, TResult>)paramsArray[1];

			var finalList = query.Resolve();
			int count = finalList.count;
			var array = finalList.array;

			var sameTypeSelector = selector as Func<T, T>;
			if(sameTypeSelector != null)
			{
				for(int i = 0; i < count; ++i)
				{
					array[i] = sameTypeSelector(array[i]);
				}

				return (FlinqList<TResult>)(object)finalList;
			}
			else
			{
				var newList = FlinqListPool<TResult>.Get();

				for(int i = 0; i < count; ++i)
				{
					newList.Add(selector(array[i]));
				}
			
				FlinqListPool<T>.Return(finalList);

				return newList;
			}
		}
	}

	public static FlinqQuery<TResult> Select<T, TResult>(this FlinqQuery<T> query, Func<T, TResult> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var paramsPack = FlinqObjectsArrayPool.Get2();

		paramsPack[0] = query;
		paramsPack[1] = selector;

		return new FlinqQuery<TResult>(ImplWrapper1<T, TResult>.impl, paramsPack);
	}

	private static class ImplWrapper2<T, TResult>
	{
		public static readonly FlinqQuery<TResult>.PrecedingQuery impl = Impl;

		private static FlinqList<TResult> Impl(object paramsPack)
		{
			var paramsArray = (object[])paramsPack;
			var query = (FlinqQuery<T>)paramsArray[0];
			var selector = (Func<T, int, TResult>)paramsArray[1];

			var finalList = query.Resolve();
			var newList = FlinqListPool<TResult>.Get();
			int count = finalList.count;
			var array = finalList.array;
			
			var sameTypeSelector = selector as Func<T, int, T>;
			if(sameTypeSelector != null)
			{
				for(int i = 0; i < count; ++i)
				{
					array[i] = sameTypeSelector(array[i], i);
				}

				return (FlinqList<TResult>)(object)finalList;
			}
			else
			{
				for(int i = 0; i < count; ++i)
				{
					newList.Add(selector(array[i], i));
				}

				FlinqListPool<T>.Return(finalList);

				return newList;
			}
		}
	}

	public static FlinqQuery<TResult> Select<T, TResult>(this FlinqQuery<T> query, Func<T, int, TResult> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var paramsPack = FlinqObjectsArrayPool.Get2();

		paramsPack[0] = query;
		paramsPack[1] = selector;

		return new FlinqQuery<TResult>(ImplWrapper2<T, TResult>.impl, paramsPack);
	}
}

}