using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_GetDuplicatesBy<T, TCompareBy> : FlinqOperation<T>
{
	private Func<T, TCompareBy> selector;

	public void OnInit(Func<T, TCompareBy> selector)
	{
		parent = null;
		this.selector = selector;
	}

	public override void Transform(FlinqList<T> list)
	{
		var hashSet = FlinqHashSetPool<TCompareBy>.Get();

		int count = list.count;

		for(int i = 0; i < count; ++i)
		{
			var elem = list.array[i]; // list.array can change

			if(!hashSet.Add(selector(elem)))
				list.Add(elem);
		}

		FlinqHashSetPool<TCompareBy>.Return(hashSet);

		list.RemoveRange(0, count);
	}
}

}