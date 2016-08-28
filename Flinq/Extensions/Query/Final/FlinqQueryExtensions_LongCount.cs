using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

// Flinq doesn't support that large lists anyway,
// so we just return regular Count

public static class FlinqQueryExtensions_LongCount
{
	public static long LongCount<T>(this FlinqQuery<T> query)
	{
		return (long)query.Count();
	}

	public static long LongCount<T>(this FlinqQuery<T> query, Predicate<T> predicate)
	{
		if(predicate == null)
			throw new ArgumentNullException("predicate");

		return (long)query.Count(predicate);
	}
}

}