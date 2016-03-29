using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_HasDuplicatesBy
{
	public static bool HasDuplicatesBy<T, TCompareBy>(this FlinqQuery<T> query, Func<T, TCompareBy> compareBy)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(compareBy == null)
			throw new ArgumentNullException("compareBy");

		var finalList = query.Resolve();

		int count = finalList.Count;
		var hashSet = FlinqHashSetPool<TCompareBy>.Get();

		bool foundDuplicate = false;

		for(int i = 0; i < count; ++i)
		{
			if(!hashSet.Add(compareBy(finalList[i])))
			{
				foundDuplicate = true;
				break;
			}
		}

		FlinqHashSetPool<TCompareBy>.Return(hashSet);
		FlinqListPool<T>.Return(finalList);

		return foundDuplicate;
	}
}

}