using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_DefaultIfEmpty_WithDefaultValue<T> : IFlinqOperation<T>
{
	private T defaultValue;

	public void OnInit(T defaultValue)
	{
		this.defaultValue = defaultValue;
	}

	public void Transform(List<T> list)
	{
		if(list.Count == 0)
			list.Add(defaultValue);
	}
}

}