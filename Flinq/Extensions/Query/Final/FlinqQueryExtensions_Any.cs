using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_Any
{
	public static bool Any<T>(this FlinqQuery<T> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(1, out returnToPool);

		bool any = finalList.Count != 0;

		query.CleanupAfterResolve(finalList, returnToPool);

		return any;
	}

	public static bool Any<T>(this FlinqQuery<T> query, Predicate<T> predicate)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(predicate == null)
			throw new ArgumentNullException("predicate");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		bool any = finalList.Exists(predicate);

		query.CleanupAfterResolve(finalList, returnToPool);

		return any;
	}
}

}