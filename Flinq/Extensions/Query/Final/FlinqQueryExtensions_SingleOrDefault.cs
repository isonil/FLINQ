using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_SingleOrDefault
{
	public static T SingleOrDefault<T>(this FlinqQuery<T> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(1, out returnToPool);

		int count = finalList.Count;

		if(count == 0)
		{
			query.CleanupAfterResolve(finalList, returnToPool);
			return default(T);
		}

		if(count != 1)
		{
			query.CleanupAfterResolve(finalList, returnToPool);
			throw new InvalidOperationException("The collection contains more than one element.");
		}

		var first = finalList[0];

		query.CleanupAfterResolve(finalList, returnToPool);

		return first;
	}

	public static T SingleOrDefault<T>(this FlinqQuery<T> query, Predicate<T> predicate)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(predicate == null)
			throw new ArgumentNullException("predicate");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);
		
		int index = finalList.FindIndex(predicate);
		int secondIndex = -1;
		
		if(index >= 0 && index + 1 < finalList.Count)
			secondIndex = finalList.FindIndex(index + 1, predicate);

		if(secondIndex >= 0)
		{
			query.CleanupAfterResolve(finalList, returnToPool);
			throw new InvalidOperationException("The collection contains more than one element.");
		}

		var elem = index < 0 ? default(T) : finalList[index];

		query.CleanupAfterResolve(finalList, returnToPool);

		return elem;
	}
}

}