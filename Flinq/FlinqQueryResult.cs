using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqQueryResult<T> : List<T>, IDisposable
{
	public void Dispose()
	{
		FlinqQueryResultPool<T>.Return(this);
	}
}

}