using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public struct FlinqQueryResult<T> : IDisposable
{
	private FlinqList<T> result;

	public FlinqQueryResult(FlinqList<T> result)
	{
		this.result = FlinqListPool<T>.Get();
		this.result.CopyFrom(result);
	}

	public void Dispose()
	{
		FlinqListPool<T>.Return(result);
	}
}

}