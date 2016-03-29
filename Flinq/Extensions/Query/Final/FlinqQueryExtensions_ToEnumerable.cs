using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_ToEnumerable
{
	public static IEnumerable<T> ToEnumerable<T>(this FlinqQuery<T> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var finalList = query.Resolve();

		try
		{
			int count = finalList.Count;

			for(int i = 0; i < count; ++i)
			{
				yield return finalList[i];
			}
		}
		finally
		{
			FlinqListPool<T>.Return(finalList);
		}
	}
}

}