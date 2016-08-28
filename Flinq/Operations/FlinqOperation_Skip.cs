using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_Skip<T> : IFlinqOperation<T>
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
			return;

		if(count >= list.count)
			list.Clear();
		else
			list.RemoveRange(0, count);
	}
}

}