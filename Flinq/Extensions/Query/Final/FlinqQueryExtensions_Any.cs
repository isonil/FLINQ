using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_Any
{
	public static bool Any<T>(this FlinqQuery<T> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var finalList = query.Resolve();

		bool any = finalList.Count != 0;

		FlinqListPool<T>.Return(finalList);

		return any;
	}

	public static bool Any<T>(this FlinqQuery<T> query, Predicate<T> predicate)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(predicate == null)
			throw new ArgumentNullException("predicate");

		var finalList = query.Resolve();

		bool any = finalList.Exists(predicate);

		FlinqListPool<T>.Return(finalList);

		return any;
	}
}

}