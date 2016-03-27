using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_ElementAtOrDefault
{
	public static T ElementAtOrDefault<T>(this FlinqQuery<T> query, int index)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(index < 0)
			return default(T);

		bool returnToPool;

		var finalList = query.Resolve(index + 1, out returnToPool);

		T element = default(T);

		if(index < finalList.Count)
			element = finalList[index];

		query.CleanupAfterResolve(finalList, returnToPool);

		return element;
	}
}

}