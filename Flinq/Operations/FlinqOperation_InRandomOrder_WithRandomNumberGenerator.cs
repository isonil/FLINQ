using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public class FlinqOperation_InRandomOrder_WithRandomNumberGenerator<T> : FlinqOperation<T>
{
	public Func<int, int, int> intRangeInclusive;

	public void OnInit(Func<int, int, int> intRangeInclusive)
	{
		this.intRangeInclusive = intRangeInclusive;
	}

	public override void Transform(List<T> list, int wantedElementsCount)
	{
		int count = list.Count;

		for(int i = 0; i < count - 1; ++i)
		{
			int rand = intRangeInclusive(i, count - 1);

			var tmp = list[i];
			list[i] = list[rand];
			list[rand] = tmp;
		}
	}

	public override bool RequiresFullListToWorkOn { get { return true; } }
}

}