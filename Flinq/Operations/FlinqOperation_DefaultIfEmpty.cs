using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_DefaultIfEmpty<T> : FlinqOperation<T>
{
	public void OnInit()
	{
		parent = null;
	}

	public override void Transform(FlinqList<T> list)
	{
		if(list.count == 0)
			list.Add(default(T));
	}
}

}