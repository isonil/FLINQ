using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_UnionLeaveDuplicates<T> : FlinqOperation<T>
{
	private FlinqQuery<T> query;

	public void OnInit(FlinqQuery<T> query)
	{
		parent = null;
		this.query = query;
	}

	public override void Transform(FlinqList<T> list)
	{
		var hashSet = FlinqHashSetPool<T>.Get();

		int count = list.count;
		var array = list.array;

		for(int i = 0; i < count; ++i)
		{
			hashSet.Add(array[i]);
		}

		var queryFinalList = query.Resolve();

		int queryFinalCount = queryFinalList.count;
		var queryFinalArray = queryFinalList.array;

		for(int i = 0; i < queryFinalCount; ++i)
		{
			var elem = queryFinalArray[i];

			if(hashSet.Add(elem))
				list.Add(elem);
		}

		FlinqListPool<T>.Return(queryFinalList);
		FlinqHashSetPool<T>.Return(hashSet);
	}
}

}