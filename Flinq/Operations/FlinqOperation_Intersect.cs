using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_Intersect<T> : FlinqOperation<T>
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

		int count = list.count;

		var hashSet2 = FlinqHashSetPool<T>.Get();

		for(int i = 0; i < count; ++i)
		{
			var elem = list.array[i]; // list.array can change

			if(!hashSet.Contains(elem))
				continue;

			if(hashSet2.Add(elem))
				list.Add(elem);
		}

		FlinqHashSetPool<T>.Return(hashSet2);
		FlinqHashSetPool<T>.Return(hashSet);

		list.RemoveRange(0, count);
	}
}

}