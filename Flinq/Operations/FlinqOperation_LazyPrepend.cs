using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_LazyPrepend<T> : IFlinqOperation<T>
{
	private Func<T> elementGetter;

	public void OnInit(Func<T> elementGetter)
	{
		this.elementGetter = elementGetter;
	}

	public void Transform(List<T> list)
	{
		list.Insert(0, elementGetter());
	}
}

}