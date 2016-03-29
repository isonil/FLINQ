using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_TakeWhile<T> : IFlinqOperation<T>
{
	private Predicate<T> predicate;

	public void OnInit(Predicate<T> predicate)
	{
		this.predicate = predicate;
	}

	public void Transform(List<T> list)
	{
		int firstNotMatchingFromLeft = list.FindIndex(x => !predicate(x));

		if(firstNotMatchingFromLeft < 0)
			return;

		list.RemoveRange(firstNotMatchingFromLeft, list.Count - firstNotMatchingFromLeft);
	}
}

}