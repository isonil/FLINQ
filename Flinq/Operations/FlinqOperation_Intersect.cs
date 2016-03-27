using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public class FlinqOperation_Intersect<T> : FlinqOperation<T>
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
		int alreadyFound = 0;

		var hashSet2 = FlinqHashSetPool<T>.Get();

		for(int i = 0; i < count; ++i)
		{
			var elem = list[i];

			if(!hashSet.Contains(elem))
				continue;

			if(hashSet2.Add(elem))
			{
				list.Add(elem);

				++alreadyFound;

				if(alreadyFound == wantedElementsCount)
					break;
			}
		}

		FlinqHashSetPool<T>.Return(hashSet2);
		FlinqHashSetPool<T>.Return(hashSet);

		list.RemoveRange(0, count);
	}

	public override bool RequiresFullListToWorkOn { get { return true; } }
}

}