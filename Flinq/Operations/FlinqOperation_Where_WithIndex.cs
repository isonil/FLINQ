using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_Where_WithIndex<T> : IFlinqOperation<T>
{
	private Func<T, int, bool> predicate;

	public void OnInit(Func<T, int, bool> predicate)
	{
		parent = null;
		this.predicate = predicate;
	}

	public override void Transform(FlinqList<T> list)
	{
		list.KeepWhere(predicate);
	}
}

}