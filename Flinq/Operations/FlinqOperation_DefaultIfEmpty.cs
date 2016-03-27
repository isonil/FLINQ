using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public class FlinqOperation_DefaultIfEmpty<T> : FlinqOperation<T>
{
	public void OnInit() { }

	public override void Transform(List<T> list, int wantedElementsCount)
	{
		if(list.Count == 0)
			list.Add(default(T));
	}

	public override bool RequiresFullListToWorkOn { get { return false; } }
}

}