using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_ForEach
{
	public static void ForEach<T>(this FlinqQuery<T> query, Action<T> action)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var finalList = query.Resolve();

		int count = finalList.Count;

		for(int i = 0; i < count; ++i)
		{
			action(finalList[i]);
		}

		// we don't return anything to pool if there's an exception thrown,
		// not a big deal, since we'll do a clean up at the end of the frame anyway

		FlinqListPool<T>.Return(finalList);
	}
}

}