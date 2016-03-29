using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_Where_WithIndex<T> : IFlinqOperation<T>
{
	private Func<T, int, bool> predicate;

	public void OnInit(Func<T, int, bool> predicate)
	{
		this.predicate = predicate;
	}

	public void Transform(List<T> list)
	{
		// unfortunately we can't use list.RemoveAll method here,
		// because it doesn't accept a predicate with index

		int count = list.Count;

		for(int i = 0; i < count; ++i)
		{
			var elem = list[i];

			if(predicate(elem, i))
				list.Add(elem);
		}

		list.RemoveRange(0, count);
	}
}

}