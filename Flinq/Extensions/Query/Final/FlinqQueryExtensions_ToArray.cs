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

		var finalList = query.Resolve();

		var ret = finalList.ToArray();

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static void ToArray<T>(this FlinqQuery<T> query, T[] toFill, out int size)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(toFill == null)
			throw new ArgumentNullException("toFill");

		var finalList = query.Resolve();

		int count = finalList.Count;

		if(toFill.Length < count)
		{
			FlinqListPool<T>.Return(finalList);
			throw new ArgumentException("Array is too small to hold all elements.");
		}

		finalList.CopyTo(toFill);
		size = count;

		FlinqListPool<T>.Return(finalList);
	}
}

}