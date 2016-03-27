using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_LastOrDefault
{
	public static T LastOrDefault<T>(this FlinqQuery<T> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);
		int count = finalList.Count;

		var last = count == 0 ? default(T) : finalList[count - 1];

		query.CleanupAfterResolve(finalList, returnToPool);

		return last;
	}

	public static T LastOrDefault<T>(this FlinqQuery<T> query, Predicate<T> predicate)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(predicate == null)
			throw new ArgumentNullException("predicate");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		var elem = finalList.FindLast(predicate);

		query.CleanupAfterResolve(finalList, returnToPool);

		return elem;
	}
}

}