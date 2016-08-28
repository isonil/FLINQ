using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_Reversed<T> : IFlinqOperation<T>
{
	public void OnInit()
	{
		parent = null;
	}

	public override void Transform(FlinqList<T> list)
	{
		list.Reverse();
	}
}

}