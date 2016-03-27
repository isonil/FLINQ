using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_Last
{
	public static T Last<T>(this FlinqQuery<T> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		if(count == 0)
		{
			query.CleanupAfterResolve(finalList, returnToPool);
			throw new InvalidOperationException("No elements.");
		}

		var last = finalList[count - 1];

		query.CleanupAfterResolve(finalList, returnToPool);

		return last;
	}

	public static T Last<T>(this FlinqQuery<T> query, Predicate<T> predicate)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(predicate == null)
			throw new ArgumentNullException("predicate");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int index = finalList.FindLastIndex(predicate);

		if(index < 0)
		{
			query.CleanupAfterResolve(finalList, returnToPool);
			throw new InvalidOperationException("No element matches predicate.");
		}

		var elem = finalList[index];

		query.CleanupAfterResolve(finalList, returnToPool);

		return elem;
	}
}

}