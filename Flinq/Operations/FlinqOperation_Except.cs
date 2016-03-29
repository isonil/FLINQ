using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_Except<T> : IFlinqOperation<T>
{
	private FlinqQuery<T> except;

	public void OnInit(FlinqQuery<T> except)
	{
		this.except = except;
	}

	public void Transform(List<T> list)
	{
		var hashSet = FlinqHashSetPool<T>.Get();
		var exceptFinalList = except.Resolve();

		int exceptCount = exceptFinalList.Count;

		for(int i = 0; i < exceptCount; ++i)
		{
			hashSet.Add(exceptFinalList[i]);
		}

		FlinqListPool<T>.Return(exceptFinalList);

		int count = list.Count;

		// RemoveAll is faster for large lists, see FlinqOperation_Where for more information

		if(count > 500)
			list.RemoveAll(x => hashSet.Contains(x));
		else
		{
			for(int i = 0; i < count; ++i)
			{
				var elem = list[i];

				if(!hashSet.Contains(elem))
					list.Add(elem);
			}

			list.RemoveRange(0, count);
		}

		FlinqHashSetPool<T>.Return(hashSet);
	}
}

}