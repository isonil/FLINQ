using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_LastOrDefault
{
	public static T LastOrDefault<T>(this FlinqQuery<T> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var finalList = query.Resolve();
		int count = finalList.Count;

		var last = count == 0 ? default(T) : finalList[count - 1];

		FlinqListPool<T>.Return(finalList);

		return last;
	}

	public static T LastOrDefault<T>(this FlinqQuery<T> query, Predicate<T> predicate)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(predicate == null)
			throw new ArgumentNullException("predicate");

		var finalList = query.Resolve();

		var elem = finalList.FindLast(predicate);

		FlinqListPool<T>.Return(finalList);

		return elem;
	}
}

}