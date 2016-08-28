using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_SingleOrDefault
{
	public static T SingleOrDefault<T>(this FlinqQuery<T> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
		{
			FlinqListPool<T>.Return(finalList);
			return default(T);
		}

		if(count != 1)
		{
			FlinqListPool<T>.Return(finalList);
			throw new InvalidOperationException("The collection contains more than one element.");
		}

		var first = finalList.array[0];

		FlinqListPool<T>.Return(finalList);

		return first;
	}

	public static T SingleOrDefault<T>(this FlinqQuery<T> query, Predicate<T> predicate)
	{
		if(predicate == null)
			throw new ArgumentNullException("predicate");

		var finalList = query.Resolve();
		
		int index = finalList.FindIndex(predicate);
		int secondIndex = -1;
		
		if(index >= 0 && index + 1 < finalList.count)
			secondIndex = finalList.FindIndex(index + 1, predicate);

		if(secondIndex >= 0)
		{
			FlinqListPool<T>.Return(finalList);
			throw new InvalidOperationException("The collection contains more than one element.");
		}

		var elem = index < 0 ? default(T) : finalList.array[index];

		FlinqListPool<T>.Return(finalList);

		return elem;
	}
}

}