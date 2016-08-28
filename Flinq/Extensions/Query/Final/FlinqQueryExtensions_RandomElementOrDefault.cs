using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_RandomElementOrDefault
{
	public static T RandomElementOrDefault<T>(this FlinqQuery<T> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
		{
			FlinqListPool<T>.Return(finalList);
			return default(T);
		}

		int index = FlinqRandomNumberGenerator.IntRangeInclusive(0, count - 1);
		var element = finalList.array[index];

		FlinqListPool<T>.Return(finalList);

		return element;
	}

	public static T RandomElementOrDefault<T>(this FlinqQuery<T> query, Func<int, int, int> intRangeInclusive)
	{
		if(intRangeInclusive == null)
			throw new ArgumentNullException("intRangeInclusive");

		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
		{
			FlinqListPool<T>.Return(finalList);
			return default(T);
		}

		int index = intRangeInclusive(0, count - 1);
		var element = finalList.array[index];

		FlinqListPool<T>.Return(finalList);

		return element;
	}
}

}