using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_DefaultIfEmpty<T> : IFlinqOperation<T>
{
	public void OnInit() { }

	public void Transform(List<T> list)
	{
		if(list.Count == 0)
			list.Add(default(T));
	}
}

}