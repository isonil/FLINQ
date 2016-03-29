﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_Where<T> : IFlinqOperation<T>
{
	private Predicate<T> predicate;

	public void OnInit(Predicate<T> predicate)
	{
		this.predicate = predicate;
	}

	public void Transform(List<T> list)
	{
		int count = list.Count;

		// RemoveAll seems to be the fastest for large lists
		// (probably because it has access to the internal array and it allows for better caching or maybe it's because it's one layer of indirection closer to the internal array?)

		if(count > 500)
			list.RemoveAll(x => !predicate(x));
		else
		{
			// for small lists this solution is 2 to 5 times faster than RemoveAll

			for(int i = 0; i < count; ++i)
			{
				var elem = list[i];

				if(predicate(elem))
					list.Add(elem);
			}

			list.RemoveRange(0, count);
		}

		// old solution (a little bit slower):
		/*
		int firstNotMatchingFromLeft = 0;

		int count = list.Count;

		for(int i = 0; i < count; ++i)
		{
			var elem = list[i];

			if(predicate(elem))
			{
				list[i] = list[firstNotMatchingFromLeft];
				list[firstNotMatchingFromLeft] = elem;

				++firstNotMatchingFromLeft;
			}
		}

		list.RemoveRange(firstNotMatchingFromLeft, list.Count - firstNotMatchingFromLeft);
		*/
	}
}

}