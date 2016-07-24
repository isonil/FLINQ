using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqICollectionExtensions
{
	public static bool Any<T>(this ICollection<T> collection)
	{
		if(collection == null)
			throw new ArgumentNullException("collection");

		return collection.Count != 0;
	}
}

}