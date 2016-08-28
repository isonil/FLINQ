using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_Count
{
	public static int Count<T>(this FlinqQuery<T> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		FlinqListPool<T>.Return(finalList);

		return count;
	}

	public static int Count<T>(this FlinqQuery<T> query, Predicate<T> predicate)
	{
		if(predicate == null)
			throw new ArgumentNullException("predicate");

		var finalList = query.Resolve();

		int listCount = finalList.count;
		var listArray = finalList.array;
		int count = 0;

		for(int i = 0; i < listCount; ++i)
		{
			if(predicate(listArray[i]))
				++count;
		}

		FlinqListPool<T>.Return(finalList);

		return count;
	}
}

}