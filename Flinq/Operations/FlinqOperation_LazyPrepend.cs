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
		parent = null;
		this.elementGetter = elementGetter;
	}

	public override void Transform(FlinqList<T> list)
	{
		list.Prepend(elementGetter());
	}
}

}