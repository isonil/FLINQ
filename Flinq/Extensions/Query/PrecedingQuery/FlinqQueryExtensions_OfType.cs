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

		private static List<TResult> Impl(object param)
		{
			var query = (FlinqQuery<T>)param;

			var finalList = query.Resolve();
			var sameType = finalList as List<TResult>;

			if(sameType != null)
				return sameType;
			else
			{
				var newList = FlinqListPool<TResult>.Get();

				int count = finalList.Count;

				for(int i = 0; i < count; ++i)
				{
					var newElem = finalList[i] as TResult;

					if(newElem != null)
						newList.Add(newElem);
				}

				FlinqListPool<T>.Return(finalList);

				return newList;
			}
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