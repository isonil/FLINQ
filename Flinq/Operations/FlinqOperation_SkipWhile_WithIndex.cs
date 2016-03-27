using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public class FlinqOperation_SkipWhile_WithIndex<T> : FlinqOperation<T>
{
	private Func<T, int, bool> predicate;

	public void OnInit(Func<T, int, bool> predicate)
	{
		this.predicate = predicate;
	}

	public override void Transform(List<T> list, int wantedElementsCount)
	{
		int firstNotMatchingFromLeft = 0;

		int count = list.Count;

		for(int i = 0; i < count; ++i)
		{
			if(predicate(list[i], i))
				++firstNotMatchingFromLeft;
			else
				break;
		}

		list.RemoveRange(0, firstNotMatchingFromLeft);
	}

	public override bool RequiresFullListToWorkOn { get { return true; } }
}

}