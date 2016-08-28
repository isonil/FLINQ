using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_HasDuplicates
{
	public static bool HasDuplicates<T>(this FlinqQuery<T> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;
		var hashSet = FlinqHashSetPool<T>.Get();

		bool foundDuplicate = false;

		for(int i = 0; i < count; ++i)
		{
			if(!hashSet.Add(array[i]))
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