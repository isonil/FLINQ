using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_Where<T> : IFlinqOperation<T>
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