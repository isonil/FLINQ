using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_Intersect<T> : IFlinqOperation<T>
{
	private FlinqQuery<T> intersect;

	public void OnInit(FlinqQuery<T> intersect)
	{
		this.intersect = intersect;
	}

	public void Transform(List<T> list)
	{
		var hashSet = FlinqHashSetPool<T>.Get();
		var intersectFinalList = intersect.Resolve();

		int intersectCount = intersectFinalList.Count;

		for(int i = 0; i < intersectCount; ++i)
		{
			hashSet.Add(intersectFinalList[i]);
		}

		FlinqListPool<T>.Return(intersectFinalList);

		int count = list.Count;

		var hashSet2 = FlinqHashSetPool<T>.Get();

		for(int i = 0; i < count; ++i)
		{
			var elem = list[i];

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