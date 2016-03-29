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

		private static List<TResult> Impl(object queryParam)
		{
			var query = (FlinqQuery<T>)queryParam;

			var finalList = query.Resolve();

			var newList = FlinqListPool<TResult>.Get();

			int count = finalList.Count;

			for(int i = 0; i < count; ++i)
			{
				newList.Add((TResult)(object)finalList[i]);
			}

			FlinqListPool<T>.Return(finalList);

			return newList;
		}
	}

	public static FlinqQuery<TResult> Cast<T, TResult>(this FlinqQuery<T> query)
	{
		var sameType = query as FlinqQuery<TResult>;

		if(sameType != null)
			return sameType;

		if(query == null)
			throw new ArgumentNullException("query");

		var newQuery = FlinqQueryPool<TResult>.Get();

		newQuery.OnInit(ImplWrapper<T, TResult>.impl, query);

		return newQuery;
	}
}
	
}