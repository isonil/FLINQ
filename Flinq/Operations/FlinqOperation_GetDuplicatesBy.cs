using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_GetDuplicatesBy<T, TCompareBy> : IFlinqOperation<T>
{
	private Func<T, TCompareBy> selector;

	public void OnInit(Func<T, TCompareBy> selector)
	{
		this.selector = selector;
	}

	public void Transform(List<T> list)
	{
		var hashSet = FlinqHashSetPool<TCompareBy>.Get();

		int count = list.Count;

		for(int i = 0; i < count; ++i)
		{
			var elem = list[i];

			if(!hashSet.Add(selector(elem)))
				list.Add(elem);
		}

		FlinqHashSetPool<TCompareBy>.Return(hashSet);

		list.RemoveRange(0, count);
	}
}

}