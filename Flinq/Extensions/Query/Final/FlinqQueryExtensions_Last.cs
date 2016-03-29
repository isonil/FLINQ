using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_Last
{
	public static T Last<T>(this FlinqQuery<T> query)
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

		var last = finalList[count - 1];

		FlinqListPool<T>.Return(finalList);

		return last;
	}

	public static T Last<T>(this FlinqQuery<T> query, Predicate<T> predicate)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(predicate == null)
			throw new ArgumentNullException("predicate");

		var finalList = query.Resolve();

		int index = finalList.FindLastIndex(predicate);

		if(index < 0)
		{
			FlinqListPool<T>.Return(finalList);
			throw new InvalidOperationException("No element matches predicate.");
		}

		var elem = finalList[index];

		FlinqListPool<T>.Return(finalList);

		return elem;
	}
}

}