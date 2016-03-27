using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public class FlinqOperation_Take<T> : FlinqOperation<T>
{
	private int count;

	public void OnInit(int count)
	{
		this.count = count;
	}

	public override void Transform(List<T> list, int wantedElementsCount)
	{
		if(count <= 0)
		{
			list.Clear();
			return;
		}

		int listCount = list.Count;

		if(count >= listCount)
			return;

		int finalCount = Math.Min(wantedElementsCount, count);

		list.RemoveRange(finalCount, listCount - finalCount);
	}

	public override bool RequiresFullListToWorkOn { get { return false; } }
}

}