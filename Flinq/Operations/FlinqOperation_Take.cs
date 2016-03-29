using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_Take<T> : IFlinqOperation<T>
{
	private int count;

	public void OnInit(int count)
	{
		this.count = count;
	}

	public void Transform(List<T> list)
	{
		if(count <= 0)
		{
			list.Clear();
			return;
		}

		int listCount = list.Count;

		if(count >= listCount)
			return;

		list.RemoveRange(count, listCount - count);
	}
}

}