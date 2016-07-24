using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_Appended<T> : IFlinqOperation<T>
{
	private T element;

	public void OnInit(T element)
	{
		this.element = element;
	}

	public void Transform(List<T> list)
	{
		list.Add(element);
	}
}

}