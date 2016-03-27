using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public class FlinqOperation_Reverse<T> : FlinqOperation<T>
{
	public void OnInit() { }

	public override void Transform(List<T> list, int wantedElementsCount)
	{
		list.Reverse();
	}

	public override bool RequiresFullListToWorkOn { get { return true; } }
}

}