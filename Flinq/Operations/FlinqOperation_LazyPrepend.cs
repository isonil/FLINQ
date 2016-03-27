using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public class FlinqOperation_LazyPrepend<T> : FlinqOperation<T>
{
	private Func<T> elementGetter;

	public void OnInit(Func<T> elementGetter)
	{
		this.elementGetter = elementGetter;
	}

	public override void Transform(List<T> list, int wantedElementsCount)
	{
		list.Insert(0, elementGetter());
	}

	public override bool RequiresFullListToWorkOn { get { return true; } }
}

}