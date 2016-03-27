using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public class FlinqOperation_SkipWhile<T> : FlinqOperation<T>
{
	private Predicate<T> predicate;

	public void OnInit(Predicate<T> predicate)
	{
		this.predicate = predicate;
	}

	public override void Transform(List<T> list, int wantedElementsCount)
	{
		int firstNotMatchingFromLeft = list.FindIndex(x => !predicate(x));

		if(firstNotMatchingFromLeft < 0)
			firstNotMatchingFromLeft = list.Count;

		list.RemoveRange(0, firstNotMatchingFromLeft);
	}

	public override bool RequiresFullListToWorkOn { get { return true; } }
}

}