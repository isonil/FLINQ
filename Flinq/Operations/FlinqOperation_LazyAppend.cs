using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_LazyAppend<T> : IFlinqOperation<T>
{
	private Func<T> elementGetter;

	public void OnInit(Func<T> elementGetter)
	{
		this.elementGetter = elementGetter;
	}

	public void Transform(List<T> list)
	{
		list.Add(elementGetter());
	}
}

}