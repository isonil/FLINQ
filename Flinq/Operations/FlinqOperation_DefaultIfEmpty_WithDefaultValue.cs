using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public sealed class FlinqOperation_DefaultIfEmpty_WithDefaultValue<T> : FlinqOperation<T>
{
	private T defaultValue;

	public void OnInit(T defaultValue)
	{
		parent = null;
		this.defaultValue = defaultValue;
	}

	public override void Transform(FlinqList<T> list)
	{
		if(list.count == 0)
			list.Add(defaultValue);
	}
}

}