using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_FirstOrDefault
{
	public static T FirstOrDefault<T>(this FlinqQuery<T> query)
	{
		var finalList = query.Resolve();

		var first = finalList.count == 0 ? default(T) : finalList.array[0];

		FlinqListPool<T>.Return(finalList);

		return first;
	}

	public static T FirstOrDefault<T>(this FlinqQuery<T> query, Predicate<T> predicate)
	{
		if(predicate == null)
			throw new ArgumentNullException("predicate");

		var finalList = query.Resolve();

		var elem = finalList.Find(predicate);

		FlinqListPool<T>.Return(finalList);

		return elem;
	}
}

}