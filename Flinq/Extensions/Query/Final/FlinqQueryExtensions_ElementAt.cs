using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_ElementAt
{
	public static T ElementAt<T>(this FlinqQuery<T> query, int index)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(index < 0)
			throw new ArgumentOutOfRangeException("index");

		bool returnToPool;

		var finalList = query.Resolve(index + 1, out returnToPool);

		if(index >= finalList.Count)
		{
			query.CleanupAfterResolve(finalList, returnToPool);
			throw new ArgumentOutOfRangeException("index");
		}

		var element = finalList[index];

		query.CleanupAfterResolve(finalList, returnToPool);

		return element;
	}
}

}