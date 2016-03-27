using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_ToArray
{
	public static T[] ToArray<T>(this FlinqQuery<T> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		var ret = finalList.ToArray();

		query.CleanupAfterResolve(finalList, returnToPool);

		return ret;
	}

	public static void ToArray<T>(this FlinqQuery<T> query, T[] toFill, out int size)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(toFill == null)
			throw new ArgumentNullException("toFill");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		if(toFill.Length < count)
		{
			query.CleanupAfterResolve(finalList, returnToPool);
			throw new ArgumentException("Array is too small to hold all elements.");
		}

		finalList.CopyTo(toFill);
		size = count;

		query.CleanupAfterResolve(finalList, returnToPool);
	}
}

}