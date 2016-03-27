using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_RandomElementOrDefault
{
	public static T RandomElementOrDefault<T>(this FlinqQuery<T> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;
		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		if(count == 0)
		{
			query.CleanupAfterResolve(finalList, returnToPool);
			return default(T);
		}

		int index = FlinqRandomNumberGenerator.IntRangeInclusive(0, count - 1);
		var element = finalList[index];

		query.CleanupAfterResolve(finalList, returnToPool);

		return element;
	}

	public static T RandomElementOrDefault<T>(this FlinqQuery<T> query, Func<int, int, int> intRangeInclusive)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;
		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		if(count == 0)
		{
			query.CleanupAfterResolve(finalList, returnToPool);
			return default(T);
		}

		int index = intRangeInclusive(0, count - 1);
		var element = finalList[index];

		query.CleanupAfterResolve(finalList, returnToPool);

		return element;
	}
}

}