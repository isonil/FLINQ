using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_First
{
	public static T First<T>(this FlinqQuery<T> query)
	{
		var finalList = query.Resolve();

		if(finalList.count == 0)
		{
			FlinqListPool<T>.Return(finalList);
			throw new InvalidOperationException("No elements.");
		}

		var first = finalList.array[0];

		FlinqListPool<T>.Return(finalList);

		return first;
	}

	public static T First<T>(this FlinqQuery<T> query, Predicate<T> predicate)
	{
		if(predicate == null)
			throw new ArgumentNullException("predicate");

		var finalList = query.Resolve();

		int index = finalList.FindIndex(predicate);

		if(index < 0)
		{
			FlinqListPool<T>.Return(finalList);
			throw new InvalidOperationException("No element matches predicate.");
		}

		var elem = finalList.array[index];

		FlinqListPool<T>.Return(finalList);

		return elem;
	}
}

}