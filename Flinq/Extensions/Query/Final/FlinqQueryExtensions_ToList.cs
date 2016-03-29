using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_ToList
{
	public static List<T> ToList<T>(this FlinqQuery<T> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var finalList = query.Resolve();

		// note that we don't use pool here,
		// because we return list to the "world outside"
		var ret = new List<T>();
		ret.AddRange(finalList);

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static void ToList<T>(this FlinqQuery<T> query, List<T> toFill)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(toFill == null)
			throw new ArgumentNullException("toFill");

		toFill.Clear();

		var finalList = query.Resolve();

		toFill.AddRange(finalList);

		FlinqListPool<T>.Return(finalList);
	}
}

}