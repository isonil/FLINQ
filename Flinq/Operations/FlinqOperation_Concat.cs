using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public class FlinqOperation_Concat<T> : FlinqOperation<T>
{
	private FlinqQuery<T> query;

	public void OnInit(FlinqQuery<T> query)
	{
		this.query = query;
	}

	public override void Transform(List<T> list, int wantedElementsCount)
	{
		bool returnToPool;
		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		list.AddRange(finalList);

		query.CleanupAfterResolve(finalList, returnToPool);
	}

	public override bool RequiresFullListToWorkOn { get { return true; } }
}

}