using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

// it's basically the same as Intersect but allows duplicates

public sealed class FlinqOperation_ExistIn<T> : IFlinqOperation<T>
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

		// RemoveAll is faster for large lists, see FlinqOperation_Where for more information

		if(count > 500)
			list.RemoveAll(x => !hashSet.Contains(x));
		else
		{
			for(int i = 0; i < count; ++i)
			{
				var elem = list[i];

				if(hashSet.Contains(elem))
					list.Add(elem);
			}

			list.RemoveRange(0, count);
		}

		FlinqHashSetPool<T>.Return(hashSet);
	}
}

}