using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

// it's basically the same as Intersect but allows duplicates

public class FlinqOperation_ExistIn<T> : FlinqOperation<T>
{
	private FlinqQuery<T> intersect;

	public void OnInit(FlinqQuery<T> intersect)
	{
		this.intersect = intersect;
	}

	public override void Transform(List<T> list, int wantedElementsCount)
	{
		var hashSet = FlinqHashSetPool<T>.Get();

		bool returnToPool;
		var intersectFinalList = intersect.Resolve(int.MaxValue, out returnToPool);

		int intersectCount = intersectFinalList.Count;

		for(int i = 0; i < intersectCount; ++i)
		{
			hashSet.Add(intersectFinalList[i]);
		}

		intersect.CleanupAfterResolve(intersectFinalList, returnToPool);

		int count = list.Count;

		// RemoveAll is faster for large lists, see FlinqOperation_Where for more information

		if(count > 500 && wantedElementsCount >= count)
			list.RemoveAll(x => !hashSet.Contains(x));
		else
		{
			int alreadyFound = 0;

			for(int i = 0; i < count; ++i)
			{
				var elem = list[i];

				if(hashSet.Contains(elem))
				{
					list.Add(elem);

					++alreadyFound;

					if(alreadyFound >= wantedElementsCount)
						break;
				}
			}

			list.RemoveRange(0, count);
		}

		FlinqHashSetPool<T>.Return(hashSet);
	}

	public override bool RequiresFullListToWorkOn { get { return true; } }
}

}