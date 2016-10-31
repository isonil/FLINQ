using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_Prepended<T> : FlinqOperation<T>
{
	private T element;

	public void OnInit(T element)
	{
		parent = null;
		this.element = element;
	}

	public override void Transform(FlinqList<T> list)
	{
		list.Prepend(element);
	}
}

}