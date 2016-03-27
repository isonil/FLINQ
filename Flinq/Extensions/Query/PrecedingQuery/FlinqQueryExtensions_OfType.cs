using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_OfType
{
	private static class ImplWrapper<T, TResult> where TResult : class
	{
		public static readonly FlinqQuery<TResult>.PrecedingQuery impl = Impl;

		private static List<TResult> Impl(int wantedElementsCount, object param)
		{
			var query = (FlinqQuery<T>)param;

			bool returnToPool;
			var finalList = query.Resolve(int.MaxValue, out returnToPool);

			var newList = FlinqListPool<TResult>.Get();

			int count = finalList.Count;
			int added = 0;

			for(int i = 0; i < count; ++i)
			{
				var newElem = finalList[i] as TResult;

				if(newElem != null)
				{
					newList.Add(newElem);
					++added;

					if(added >= wantedElementsCount)
						break;
				}
			}

			query.CleanupAfterResolve(finalList, returnToPool);

			return newList;
		}
	}

	public static FlinqQuery<TResult> OfType<T, TResult>(this FlinqQuery<T> query) where TResult : class
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var newQuery = FlinqQueryPool<TResult>.Get();

		newQuery.OnInit(ImplWrapper<T, TResult>.impl, query);

		return newQuery;
	}
}

}