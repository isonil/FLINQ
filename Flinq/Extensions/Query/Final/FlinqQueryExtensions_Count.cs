using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_Count
{
	public static int Count<T>(this FlinqQuery<T> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var finalList = query.Resolve();

		int count = finalList.Count;

		FlinqListPool<T>.Return(finalList);

		return count;
	}

	public static int Count<T>(this FlinqQuery<T> query, Predicate<T> predicate)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(predicate == null)
			throw new ArgumentNullException("predicate");

		var finalList = query.Resolve();

		int listCount = finalList.Count;
		int count = 0;

		for(int i = 0; i < listCount; ++i)
		{
			if(predicate(finalList[i]))
				++count;
		}

		FlinqListPool<T>.Return(finalList);

		return count;
	}
}

}