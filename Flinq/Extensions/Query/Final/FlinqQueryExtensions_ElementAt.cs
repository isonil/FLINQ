using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_ElementAt
{
	public static T ElementAt<T>(this FlinqQuery<T> query, int index)
	{
		if(index < 0)
			throw new ArgumentOutOfRangeException("index");

		var finalList = query.Resolve();

		if(index >= finalList.count)
		{
			FlinqListPool<T>.Return(finalList);
			throw new ArgumentOutOfRangeException("index");
		}

		var element = finalList.array[index];

		FlinqListPool<T>.Return(finalList);

		return element;
	}
}

}