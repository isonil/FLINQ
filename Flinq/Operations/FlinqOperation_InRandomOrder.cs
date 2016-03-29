using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_InRandomOrder<T> : IFlinqOperation<T>
{
	public void OnInit() { }

	public void Transform(List<T> list)
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
}

}