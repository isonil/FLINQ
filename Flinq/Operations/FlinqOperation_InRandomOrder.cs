using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_InRandomOrder<T> : IFlinqOperation<T>
{
	public void OnInit()
	{
		parent = null;
	}

	public override void Transform(FlinqList<T> list)
	{
		var randomNumberGenerator = FlinqRandomNumberGenerator.IntRangeInclusive;

		int count = list.count;
		var array = list.array;

		for(int i = 0; i < count - 1; ++i)
		{
			int rand = randomNumberGenerator(i, count - 1);

			var tmp = array[i];
			array[i] = array[rand];
			array[rand] = tmp;
		}
	}
}

}