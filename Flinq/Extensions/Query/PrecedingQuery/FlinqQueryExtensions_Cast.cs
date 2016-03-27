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

		private static List<TResult> Impl(int wantedElementsCount, object queryParam)
		{
			var query = (Flinq.FlinqQuery<T>)queryParam;

			bool returnToPool;
			var finalList = query.Resolve(int.MaxValue, out returnToPool);

			var newList = Flinq.FlinqListPool<TResult>.Get();

			int count = Math.Min(wantedElementsCount, finalList.Count);

			for(int i = 0; i < count; ++i)
			{
				newList.Add((TResult)(object)finalList[i]);
			}

			query.CleanupAfterResolve(finalList, returnToPool);

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