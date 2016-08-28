using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_Cast
{
	private static class ImplWrapper<T, TResult>
	{
		public static readonly FlinqQuery<TResult>.PrecedingQuery impl = Impl;

		private static FlinqList<TResult> Impl(object queryParam)
		{
			var query = (FlinqQuery<T>)queryParam;

			var finalList = query.Resolve();

			var newList = FlinqListPool<TResult>.Get();

			int count = finalList.count;
			var array = finalList.array;

			for(int i = 0; i < count; ++i)
			{
				newList.Add((TResult)(object)array[i]);
			}

			FlinqListPool<T>.Return(finalList);

			return newList;
		}
	}

	public static FlinqQuery<TResult> Cast<T, TResult>(this FlinqQuery<T> query)
	{
		if(query is FlinqQuery<TResult>)
			return (FlinqQuery<TResult>)(object)query;

		return new FlinqQuery<TResult>(ImplWrapper<T, TResult>.impl, query);
	}
}
	
}