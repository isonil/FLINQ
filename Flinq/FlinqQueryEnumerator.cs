using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public struct FlinqQueryEnumerator<T> : IEnumerator<T>, IDisposable
{
	private List<T> result;
	private int index;
	private int count;

	public T Current { get { return result[index]; } }
	object IEnumerator.Current { get { return Current; } }

	public FlinqQueryEnumerator(List<T> result)
	{
		this.result = result;
		index = -1;
		count = result.Count;
	}

	public void Dispose()
	{
		FlinqListPool<T>.Return(result);
	}

	public bool MoveNext()
	{
		return ++index < count;
	}

	public void Reset()
	{
		index = -1;
	}
}

}