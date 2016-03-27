using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public class FlinqOperation_Append<T> : FlinqOperation<T>
{
	private T element;

	public void OnInit(T element)
	{
		this.element = element;
	}

	public override void Transform(List<T> list, int wantedElementsCount)
	{
		list.Add(element);
	}

	public override bool RequiresFullListToWorkOn { get { return true; } }
}

}