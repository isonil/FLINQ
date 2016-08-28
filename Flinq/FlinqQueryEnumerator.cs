using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public struct FlinqQueryEnumerator<T> : IEnumerator<T>, IDisposable
{
	private FlinqList<T> result;
	private int index;

	public T Current { get { return result.array[index]; } }
	object IEnumerator.Current { get { return Current; } }

	public FlinqQueryEnumerator(FlinqList<T> result)
	{
		this.result = result;
		index = -1;
	}

	public void Dispose()
	{
		FlinqListPool<T>.Return(result);
	}

	public bool MoveNext()
	{
		return ++index < result.count;
	}

	public void Reset()
	{
		index = -1;
	}
}

}