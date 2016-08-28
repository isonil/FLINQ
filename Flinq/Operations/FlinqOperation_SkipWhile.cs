using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_SkipWhile<T> : IFlinqOperation<T>
{
	private Predicate<T> predicate;

	public void OnInit(Predicate<T> predicate)
	{
		parent = null;
		this.predicate = predicate;
	}

	public override void Transform(FlinqList<T> list)
	{
		int count = list.count;
		var array = list.array;

		int firstNotMatchingFromLeft = count;

		for(int i = 0; i < count; ++i)
		{
			if(!predicate(array[i]))
			{
				firstNotMatchingFromLeft = i;
				break;
			}
		}

		list.RemoveRange(0, firstNotMatchingFromLeft);
	}
}

}