using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public class FlinqQueryResult<T> : List<T>, IDisposable
{
	public bool ReturnToPool { get; internal set; }

	public void Dispose()
	{
		if(ReturnToPool)
			FlinqQueryResultPool<T>.Return(this);
	}
}

}