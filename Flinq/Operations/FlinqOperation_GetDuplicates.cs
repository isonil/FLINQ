using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public class FlinqOperation_GetDuplicates<T> : FlinqOperation<T>
{
	public void OnInit() { }

	public override void Transform(List<T> list, int wantedElementsCount)
	{
		var hashSet = FlinqHashSetPool<T>.Get();

		int count = list.Count;

		for(int i = 0; i < count; ++i)
		{
			var elem = list[i];

			if(!hashSet.Add(elem))
				list.Add(elem);
		}

		FlinqHashSetPool<T>.Return(hashSet);

		list.RemoveRange(0, count);
	}

	public override bool RequiresFullListToWorkOn { get { return true; } }
}

}