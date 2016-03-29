using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_InRandomOrder_WithRandomNumberGenerator<T> : IFlinqOperation<T>
{
	public Func<int, int, int> intRangeInclusive;

	public void OnInit(Func<int, int, int> intRangeInclusive)
	{
		this.intRangeInclusive = intRangeInclusive;
	}

	public void Transform(List<T> list)
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
}

}