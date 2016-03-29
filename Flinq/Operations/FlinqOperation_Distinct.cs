using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_Distinct<T> : IFlinqOperation<T>
{
	public void OnInit() { }

	public void Transform(List<T> list)
	{
		var hashSet = FlinqHashSetPool<T>.Get();

		int count = list.Count;

		for(int i = 0; i < count; ++i)
		{
			var elem = list[i];

			if(hashSet.Add(elem))
				list.Add(elem);
		}

		FlinqHashSetPool<T>.Return(hashSet);

		list.RemoveRange(0, count);
	}
}

}