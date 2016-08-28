using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_ToList
{
	public static List<T> ToList<T>(this FlinqQuery<T> query)
	{
		var finalList = query.Resolve();
		
		int count = finalList.count;
		var array = finalList.array;

		// note that we don't use pool here,
		// because we return list to the "world outside"
		var ret = new List<T>(count);

		for(int i = 0; i < count; ++i)
		{
			ret.Add(array[i]);
		}

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static void ToList<T>(this FlinqQuery<T> query, List<T> toFill)
	{
		if(toFill == null)
			throw new ArgumentNullException("toFill");

		toFill.Clear();

		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		toFill.Capacity = Math.Max(toFill.Capacity, count);

		for(int i = 0; i < count; ++i)
		{
			toFill.Add(array[i]);
		}

		FlinqListPool<T>.Return(finalList);
	}
}

}