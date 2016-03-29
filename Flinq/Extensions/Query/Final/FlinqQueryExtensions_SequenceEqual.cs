using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_SequenceEqual
{
	public static bool SequenceEqual<T>(this FlinqQuery<T> query, FlinqQuery<T> other)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(other == null)
			throw new ArgumentNullException("other");

		if(query == other)
			return true;

		var finalList = query.Resolve();
		var otherFinalList = other.Resolve();

		int count = finalList.Count;
		int otherCount = otherFinalList.Count;

		bool result = true;

		if(count != otherCount)
			result = false;
		else
		{
			var eq = EqualityComparer<T>.Default;

			for(int i = 0; i < count; ++i)
			{
				if(!eq.Equals(finalList[i], otherFinalList[i]))
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