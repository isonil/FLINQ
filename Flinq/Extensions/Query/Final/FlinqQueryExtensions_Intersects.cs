using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_Intersects
{
	public static bool Intersects<T>(this FlinqQuery<T> query, FlinqQuery<T> other)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(other == null)
			throw new ArgumentNullException("other");

		var finalList = query.Resolve();

		var otherFinalList = other.Resolve();

		int count = finalList.Count;
		var hashSet = FlinqHashSetPool<T>.Get();

		for(int i = 0; i < count; ++i)
		{
			hashSet.Add(finalList[i]);
		}

		FlinqListPool<T>.Return(finalList);

		count = otherFinalList.Count;

		bool intersects = false;

		for(int i = 0; i < count; ++i)
		{
			if(hashSet.Contains(otherFinalList[i]))
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