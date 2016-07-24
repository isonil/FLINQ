using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_Prepended<T> : IFlinqOperation<T>
{
	private T element;

	public void OnInit(T element)
	{
		this.element = element;
	}

	public void Transform(List<T> list)
	{
		list.Insert(0, element);
	}
}

}