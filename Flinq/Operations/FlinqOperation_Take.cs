using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_Take<T> : FlinqOperation<T>
{
	private int count;

	public void OnInit(int count)
	{
		parent = null;
		this.count = count;
	}

	public override void Transform(FlinqList<T> list)
	{
		if(count <= 0)
		{
			list.Clear();
			return;
		}

		int listCount = list.count;

		if(count >= listCount)
			return;

		list.RemoveRange(count, listCount - count);
	}
}

}