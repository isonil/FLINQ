﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_Union<T> : IFlinqOperation<T>
{
	private FlinqQuery<T> query;

	public void OnInit(FlinqQuery<T> query)
	{
		this.query = query;
	}

	public void Transform(List<T> list)
	{
		var hashSet = FlinqHashSetPool<T>.Get();

		int count = list.Count;

		for(int i = 0; i < count; ++i)
		{
			var elem = list[i];

			if(hashSet.Add(elem))
				list.Add(elem);
		}

		var queryFinalList = query.Resolve();

		int count2 = queryFinalList.Count;

		for(int i = 0; i < count2; ++i)
		{
			var elem = queryFinalList[i];

			if(hashSet.Add(elem))
				list.Add(elem);
		}

		FlinqListPool<T>.Return(queryFinalList);
		FlinqHashSetPool<T>.Return(hashSet);

		list.RemoveRange(0, count);
	}
}

}