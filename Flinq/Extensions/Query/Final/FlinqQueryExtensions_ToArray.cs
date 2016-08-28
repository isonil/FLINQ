using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_ToArray
{
	public static T[] ToArray<T>(this FlinqQuery<T> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		var ret = new T[count];
		Array.Copy(finalList.array, ret, count);

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static void ToArray<T>(this FlinqQuery<T> query, T[] toFill, out int size)
	{
		if(toFill == null)
			throw new ArgumentNullException("toFill");

		var finalList = query.Resolve();

		int count = finalList.count;

		if(toFill.Length < count)
		{
			FlinqListPool<T>.Return(finalList);
			throw new ArgumentException("Array is too small to hold all elements.");
		}

		Array.Copy(finalList.array, toFill, count);
		size = count;

		FlinqListPool<T>.Return(finalList);
	}
}

}