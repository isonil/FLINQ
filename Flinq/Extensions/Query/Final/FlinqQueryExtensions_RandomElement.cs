using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_RandomElement
{
	public static T RandomElement<T>(this FlinqQuery<T> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
		{
			FlinqListPool<T>.Return(finalList);
			throw new InvalidOperationException("No elements.");
		}

		int index = FlinqRandomNumberGenerator.IntRangeInclusive(0, count - 1);
		var element = finalList.array[index];

		FlinqListPool<T>.Return(finalList);

		return element;
	}

	public static T RandomElement<T>(this FlinqQuery<T> query, Func<int, int, int> intRangeInclusive)
	{
		if(intRangeInclusive == null)
			throw new ArgumentNullException("intRangeInclusive");

		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
		{
			FlinqListPool<T>.Return(finalList);
			throw new InvalidOperationException("No elements.");
		}

		int index = intRangeInclusive(0, count - 1);
		var element = finalList.array[index];

		FlinqListPool<T>.Return(finalList);

		return element;
	}
}

}