using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public class FlinqOperation_InRandomOrder<T> : FlinqOperation<T>
{
	public void OnInit() { }

	public override void Transform(List<T> list, int wantedElementsCount)
	{
		var randomNumberGenerator = FlinqRandomNumberGenerator.IntRangeInclusive;

		int count = list.Count;

		for(int i = 0; i < count - 1; ++i)
		{
			int rand = randomNumberGenerator(i, count - 1);

			var tmp = list[i];
			list[i] = list[rand];
			list[rand] = tmp;
		}
	}

	public override bool RequiresFullListToWorkOn { get { return true; } }
}

}