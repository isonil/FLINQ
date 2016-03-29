using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_HasDuplicates
{
	public static bool HasDuplicates<T>(this FlinqQuery<T> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var finalList = query.Resolve();

		int count = finalList.Count;
		var hashSet = FlinqHashSetPool<T>.Get();

		bool foundDuplicate = false;

		for(int i = 0; i < count; ++i)
		{
			if(!hashSet.Add(finalList[i]))
			{
				foundDuplicate = true;
				break;
			}
		}

		FlinqHashSetPool<T>.Return(hashSet);
		FlinqListPool<T>.Return(finalList);

		return foundDuplicate;
	}
}

}