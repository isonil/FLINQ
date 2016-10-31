using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_Concat<T> : FlinqOperation<T>
{
	private FlinqQuery<T> query;

	public void OnInit(FlinqQuery<T> query)
	{
		parent = null;
		this.query = query;
	}

	public override void Transform(FlinqList<T> list)
	{
		var finalList = query.Resolve();

		list.AddRange(finalList);

		FlinqListPool<T>.Return(finalList);
	}
}

}