using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_Single
{
	public static T Single<T>(this FlinqQuery<T> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var finalList = query.Resolve();

		if(finalList.Count != 0)
		{
			FlinqListPool<T>.Return(finalList);
			throw new InvalidOperationException("The collection does not contain exactly one element.");
		}

		var first = finalList[0];

		FlinqListPool<T>.Return(finalList);

		return first;
	}

	public static T Single<T>(this FlinqQuery<T> query, Predicate<T> predicate)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(predicate == null)
			throw new ArgumentNullException("predicate");

		var finalList = query.Resolve();

		int index = finalList.FindIndex(predicate);
		int secondIndex = -1;
		
		if(index >= 0 && index + 1 < finalList.Count)
			secondIndex = finalList.FindIndex(index + 1, predicate);

		if(index < 0 || secondIndex >= 0)
		{
			FlinqListPool<T>.Return(finalList);
			throw new InvalidOperationException("The collection does not contain exactly one element.");
		}

		var elem = finalList[index];

		FlinqListPool<T>.Return(finalList);

		return elem;
	}
}

}