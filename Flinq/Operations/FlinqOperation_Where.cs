using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_Where<T> : FlinqOperation<T>
{
	private Predicate<T> predicate;

	public void OnInit(Predicate<T> predicate)
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