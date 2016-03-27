using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_FirstOrDefault
{
	public static T FirstOrDefault<T>(this FlinqQuery<T> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(1, out returnToPool);

		var first = finalList.Count == 0 ? default(T) : finalList[0];

		query.CleanupAfterResolve(finalList, returnToPool);

		return first;
	}

	public static T FirstOrDefault<T>(this FlinqQuery<T> query, Predicate<T> predicate)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(predicate == null)
			throw new ArgumentNullException("predicate");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		var elem = finalList.Find(predicate);

		query.CleanupAfterResolve(finalList, returnToPool);

		return elem;
	}
}

}