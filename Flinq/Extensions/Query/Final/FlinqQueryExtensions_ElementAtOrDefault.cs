using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_ElementAtOrDefault
{
	public static T ElementAtOrDefault<T>(this FlinqQuery<T> query, int index)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(index < 0)
			return default(T);

		var finalList = query.Resolve();

		T element = default(T);

		if(index < finalList.Count)
			element = finalList[index];

		FlinqListPool<T>.Return(finalList);

		return element;
	}
}

}