using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_Contains
{
	public static bool Contains<T>(this FlinqQuery<T> query, T element)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		bool found = finalList.Contains(element);

		query.CleanupAfterResolve(finalList, returnToPool);

		return found;
	}
}

}