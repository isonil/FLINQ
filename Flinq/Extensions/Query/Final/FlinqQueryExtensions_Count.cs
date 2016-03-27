using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_Count
{
	public static int Count<T>(this FlinqQuery<T> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		query.CleanupAfterResolve(finalList, returnToPool);

		return count;
	}

	public static int Count<T>(this FlinqQuery<T> query, Predicate<T> predicate)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(predicate == null)
			throw new ArgumentNullException("predicate");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int listCount = finalList.Count;
		int count = 0;

		for(int i = 0; i < listCount; ++i)
		{
			if(predicate(finalList[i]))
				++count;
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return count;
	}
}

}