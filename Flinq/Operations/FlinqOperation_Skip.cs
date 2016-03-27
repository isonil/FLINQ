using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public class FlinqOperation_Skip<T> : FlinqOperation<T>
{
	private int count;

	public void OnInit(int count)
	{
		this.count = count;
	}

	public override void Transform(List<T> list, int wantedElementsCount)
	{
		if(count <= 0)
			return;

		int listCount = list.Count;

		if(count >= listCount)
		{
			list.Clear();
			return;
		}

		list.RemoveRange(0, count);
	}

	public override bool RequiresFullListToWorkOn { get { return true; } }
}

}