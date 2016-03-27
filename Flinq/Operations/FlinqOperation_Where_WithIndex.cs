using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public class FlinqOperation_Where_WithIndex<T> : FlinqOperation<T>
{
	private Func<T, int, bool> predicate;

	public void OnInit(Func<T, int, bool> predicate)
	{
		this.predicate = predicate;
	}

	public override void Transform(List<T> list, int wantedElementsCount)
	{
		// unfortunately we can't use list.RemoveAll method here,
		// because it doesn't accept a predicate with index

		int count = list.Count;
		int alreadyFound = 0;

		for(int i = 0; i < count; ++i)
		{
			var elem = list[i];

			if(predicate(elem, i))
			{
				list.Add(elem);

				++alreadyFound;

				if(alreadyFound == wantedElementsCount)
					break;
			}
		}

		list.RemoveRange(0, count);
	}

	public override bool RequiresFullListToWorkOn { get { return true; } }
}

}