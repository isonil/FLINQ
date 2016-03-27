using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_All
{
	public static bool All<T>(this FlinqQuery<T> query, Predicate<T> predicate)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(predicate == null)
			throw new ArgumentNullException("predicate");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		bool all = finalList.TrueForAll(predicate);

		query.CleanupAfterResolve(finalList, returnToPool);

		return all;
	}
}

}
