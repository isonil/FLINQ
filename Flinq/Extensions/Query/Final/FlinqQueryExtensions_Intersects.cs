using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_Intersects
{
	public static bool Intersects<T>(this FlinqQuery<T> query, FlinqQuery<T> other)
	{
		var finalList = query.Resolve();

		var otherFinalList = other.Resolve();

		int count = finalList.count;
		var array = finalList.array;
		var hashSet = FlinqHashSetPool<T>.Get();

		for(int i = 0; i < count; ++i)
		{
			hashSet.Add(array[i]);
		}

		FlinqListPool<T>.Return(finalList);

		count = otherFinalList.count;
		var otherArray = otherFinalList.array;

		bool intersects = false;

		for(int i = 0; i < count; ++i)
		{
			if(hashSet.Contains(otherArray[i]))
			{
				intersects = true;
				break;
			}
		}

		FlinqHashSetPool<T>.Return(hashSet);
		FlinqListPool<T>.Return(otherFinalList);

		return intersects;
	}
}

}