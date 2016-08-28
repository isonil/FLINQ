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
		parent = null;
		this.except = except;
	}

	public override void Transform(FlinqList<T> list)
	{
		var hashSet = FlinqHashSetPool<T>.Get();
		var exceptFinalList = except.Resolve();

		int exceptCount = exceptFinalList.count;
		var exceptArray = exceptFinalList.array;

		for(int i = 0; i < exceptCount; ++i)
		{
			hashSet.Add(exceptArray[i]);
		}

		FlinqListPool<T>.Return(exceptFinalList);

		list.RemoveWhereHashSetContains(hashSet);

		FlinqHashSetPool<T>.Return(hashSet);
	}
}

}