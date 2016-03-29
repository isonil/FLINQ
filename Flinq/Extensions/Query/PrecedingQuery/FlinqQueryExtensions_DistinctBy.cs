using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_DistinctBy
{
	private static class ImplWrapper<T, TCompareBy>
	{
		public static readonly FlinqQuery<T>.PrecedingQuery impl = Impl;

		private static List<T> Impl(object paramsPack)
		{
			var paramsArray = (object[])paramsPack;
			var query = (FlinqQuery<T>)paramsArray[0];
			var compareBySelector = (Func<T, TCompareBy>)paramsArray[1];

			var finalList = query.Resolve();

			var newList = FlinqListPool<T>.Get();
			var hashSet = FlinqHashSetPool<TCompareBy>.Get();

			int count = finalList.Count;

			for(int i = 0; i < count; ++i)
			{
				var elem = finalList[i];

				if(hashSet.Add(compareBySelector(elem)))
					newList.Add(elem);
			}

			FlinqHashSetPool<TCompareBy>.Return(hashSet);

			FlinqListPool<T>.Return(finalList);

			return newList;
		}
	}

	public static FlinqQuery<T> DistinctBy<T, TCompareBy>(this FlinqQuery<T> query, Func<T, TCompareBy> compareBySelector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(compareBySelector == null)
			throw new ArgumentNullException("compareBySelector");

		var paramsPack = FlinqObjectsArrayPool.Get2();

		paramsPack[0] = query;
		paramsPack[1] = compareBySelector;

		var newQuery = FlinqQueryPool<T>.Get();

		newQuery.OnInit(ImplWrapper<T, TCompareBy>.impl, paramsPack);

		return newQuery;
	}
}

}