using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_SequenceEqual
{
	public static bool SequenceEqual<T>(this FlinqQuery<T> query, FlinqQuery<T> other)
	{
		if(query == other)
			return true;

		var finalList = query.Resolve();
		var otherFinalList = other.Resolve();

		int count = finalList.count;
		int otherCount = otherFinalList.count;

		bool result = true;

		if(count != otherCount)
			result = false;
		else
		{
			var array = finalList.array;
			var otherArray = otherFinalList.array;

			var eq = EqualityComparer<T>.Default;

			for(int i = 0; i < count; ++i)
			{
				if(!eq.Equals(array[i], otherArray[i]))
				{
					result = false;
					break;
				}
			}
		}

		FlinqListPool<T>.Return(otherFinalList);
		FlinqListPool<T>.Return(finalList);

		return result;
	}
}
	
}