using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_Distinct<T> : IFlinqOperation<T>
{
	public void OnInit()
	{
		parent = null;
	}

	public override void Transform(FlinqList<T> list)
	{
		var hashSet = FlinqHashSetPool<T>.Get();

		int count = list.count;

		for(int i = 0; i < count; ++i)
		{
			var elem = list.array[i]; // list.array can change

			if(hashSet.Add(elem))
				list.Add(elem);
		}

		FlinqHashSetPool<T>.Return(hashSet);

		list.RemoveRange(0, count);
	}
}

}