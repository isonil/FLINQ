using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_LastOrDefault
{
	public static T LastOrDefault<T>(this FlinqQuery<T> query)
	{
		var finalList = query.Resolve();
		int count = finalList.count;

		var last = count == 0 ? default(T) : finalList.array[count - 1];

		FlinqListPool<T>.Return(finalList);

		return last;
	}

	public static T LastOrDefault<T>(this FlinqQuery<T> query, Predicate<T> predicate)
	{
		if(predicate == null)
			throw new ArgumentNullException("predicate");

		var finalList = query.Resolve();

		var elem = finalList.FindLast(predicate);

		FlinqListPool<T>.Return(finalList);

		return elem;
	}
}

}