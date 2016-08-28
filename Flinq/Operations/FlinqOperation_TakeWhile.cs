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
		parent = null;
		this.predicate = predicate;
	}

	public override void Transform(FlinqList<T> list)
	{
		int firstNotMatchingFromLeft = -1;

		int count = list.count;
		var array = list.array;

		for(int i = 0; i < count; ++i)
		{
			if(!predicate(array[i]))
			{
				firstNotMatchingFromLeft = i;
				break;
			}
		}
		
		if(firstNotMatchingFromLeft < 0)
			return;

		list.RemoveRange(firstNotMatchingFromLeft, count - firstNotMatchingFromLeft);
	}
}

}