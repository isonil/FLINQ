using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public class FlinqOperation_UnionLeaveDuplicates<T> : FlinqOperation<T>
{
	private FlinqQuery<T> query;

	public void OnInit(FlinqQuery<T> query)
	{
		this.query = query;
	}

	public override void Transform(List<T> list, int wantedElementsCount)
	{
		var hashSet = FlinqHashSetPool<T>.Get();

		int count = list.Count;

		for(int i = 0; i < count; ++i)
		{
			hashSet.Add(list[i]);
		}

		bool returnToPool;
		var queryFinalList = query.Resolve(int.MaxValue, out returnToPool);

		int count2 = queryFinalList.Count;

		for(int i = 0; i < count2; ++i)
		{
			var elem = queryFinalList[i];

			if(hashSet.Add(elem))
				list.Add(elem);
		}

		query.CleanupAfterResolve(queryFinalList, returnToPool);

		FlinqHashSetPool<T>.Return(hashSet);
	}

	public override bool RequiresFullListToWorkOn { get { return true; } }
}

}