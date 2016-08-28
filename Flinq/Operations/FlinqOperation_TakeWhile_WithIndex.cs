using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_TakeWhile_WithIndex<T> : IFlinqOperation<T>
{
	private Func<T, int, bool> predicate;

	public void OnInit(Func<T, int, bool> predicate)
	{
		parent = null;
		this.predicate = predicate;
	}

	public override void Transform(FlinqList<T> list)
	{
		int firstNotMatchingFromLeft = 0;

		int count = list.count;
		var array = list.array;

		for(int i = 0; i < count; ++i)
		{
			if(predicate(array[i], i))
				++firstNotMatchingFromLeft;
			else
				break;
		}

		if(firstNotMatchingFromLeft == count)
			return;

		list.RemoveRange(firstNotMatchingFromLeft, count - firstNotMatchingFromLeft);
	}
}

}