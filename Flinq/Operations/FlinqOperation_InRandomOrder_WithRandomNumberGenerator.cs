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
		parent = null;
		this.intRangeInclusive = intRangeInclusive;
	}

	public override void Transform(FlinqList<T> list)
	{
		int count = list.count;
		var array = list.array;

		for(int i = 0; i < count - 1; ++i)
		{
			int rand = intRangeInclusive(i, count - 1);
			
			var tmp = array[i];
			array[i] = array[rand];
			array[rand] = tmp;
		}
	}
}

}