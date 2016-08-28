using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_Contains
{
	public static bool Contains<T>(this FlinqQuery<T> query, T element)
	{
		var finalList = query.Resolve();

		bool found = finalList.Contains(element);

		FlinqListPool<T>.Return(finalList);

		return found;
	}
}

}