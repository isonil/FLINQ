﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_Concat<T> : IFlinqOperation<T>
{
	private FlinqQuery<T> query;

	public void OnInit(FlinqQuery<T> query)
	{
		this.query = query;
	}

	public void Transform(List<T> list)
	{
		var finalList = query.Resolve();

		list.AddRange(finalList);

		FlinqListPool<T>.Return(finalList);
	}
}

}