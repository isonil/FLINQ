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
		this.count = count;
	}

	public void Transform(List<T> list)
	{
		if(count <= 0)
			return;

		if(count >= list.Count)
			list.Clear();
		else
			list.RemoveRange(0, count);
	}
}

}