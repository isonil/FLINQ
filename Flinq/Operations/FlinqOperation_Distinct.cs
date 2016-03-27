using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public class FlinqOperation_Distinct<T> : FlinqOperation<T>
{
	public void OnInit() { }

	public override void Transform(List<T> list, int wantedElementsCount)
	{
		var hashSet = FlinqHashSetPool<T>.Get();

		int count = list.Count;
		int alreadyFound = 0;

		for(int i = 0; i < count; ++i)
		{
			var elem = list[i];

			if(hashSet.Add(elem))
			{
				list.Add(elem);

				++alreadyFound;

				if(alreadyFound == wantedElementsCount)
					break;
			}
		}

		FlinqHashSetPool<T>.Return(hashSet);

		list.RemoveRange(0, count);
	}

	public override bool RequiresFullListToWorkOn { get { return false; } }
}

}