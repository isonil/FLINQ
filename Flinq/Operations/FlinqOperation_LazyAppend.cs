using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public class FlinqOperation_LazyAppend<T> : FlinqOperation<T>
{
	private Func<T> elementGetter;

	public void OnInit(Func<T> elementGetter)
	{
		this.elementGetter = elementGetter;
	}

	public override void Transform(List<T> list, int wantedElementsCount)
	{
		list.Add(elementGetter());
	}

	public override bool RequiresFullListToWorkOn { get { return true; } }
}

}