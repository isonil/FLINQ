using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqIListExtensions
{
	public static T FirstOrDefault<T>(this IList<T> list)
	{
		if(list == null)
			throw new ArgumentNullException("list");

		if(list.Count == 0)
			return default(T);

		return list[0];
	}
}

}