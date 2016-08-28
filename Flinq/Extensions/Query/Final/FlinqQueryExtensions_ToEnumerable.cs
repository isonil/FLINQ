using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_ToEnumerable
{
	public static IEnumerable<T> ToEnumerable<T>(this FlinqQuery<T> query)
	{
		var finalList = query.Resolve();

		try
		{
			int count = finalList.count;
			var array = finalList.array;

			for(int i = 0; i < count; ++i)
			{
				yield return array[i];
			}
		}
		finally
		{
			FlinqListPool<T>.Return(finalList);
		}
	}
}

}