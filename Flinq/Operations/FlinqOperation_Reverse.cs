using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_Reverse<T> : IFlinqOperation<T>
{
	public void OnInit() { }

	public void Transform(List<T> list)
	{
		list.Reverse();
	}
}

}