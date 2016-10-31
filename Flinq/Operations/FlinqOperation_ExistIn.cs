using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

// it's basically the same as Intersect but allows duplicates

public sealed class FlinqOperation_ExistIn<T> : FlinqOperation<T>
{
	private FlinqQuery<T> intersect;

	public void OnInit(FlinqQuery<T> intersect)
	{
		parent = null;
		this.intersect = intersect;
	}

	public override void Transform(FlinqList<T> list)
	{
		var hashSet = FlinqHashSetPool<T>.Get();
		var intersectFinalList = intersect.Resolve();

		int intersectCount = intersectFinalList.count;
		var intersectArray = intersectFinalList.array;

		for(int i = 0; i < intersectCount; ++i)
		{
			hashSet.Add(intersectArray[i]);
		}

		FlinqListPool<T>.Return(intersectFinalList);

		list.KeepWhereHashSetContains(hashSet);

		FlinqHashSetPool<T>.Return(hashSet);
	}
}

}