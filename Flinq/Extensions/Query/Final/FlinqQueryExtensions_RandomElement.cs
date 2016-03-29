using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_RandomElement
{
	public static T RandomElement<T>(this FlinqQuery<T> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");
		var finalList = query.Resolve();

		int count = finalList.Count;

		if(count == 0)
		{
			FlinqListPool<T>.Return(finalList);
			throw new InvalidOperationException("No elements.");
		}

		int index = FlinqRandomNumberGenerator.IntRangeInclusive(0, count - 1);
		var element = finalList[index];

		FlinqListPool<T>.Return(finalList);

		return element;
	}

	public static T RandomElement<T>(this FlinqQuery<T> query, Func<int, int, int> intRangeInclusive)
	{
		if(query == null)
			throw new ArgumentNullException("query");
		var finalList = query.Resolve();

		int count = finalList.Count;

		if(count == 0)
		{
			FlinqListPool<T>.Return(finalList);
			throw new InvalidOperationException("No elements.");
		}

		int index = intRangeInclusive(0, count - 1);
		var element = finalList[index];

		FlinqListPool<T>.Return(finalList);

		return element;
	}
}

}