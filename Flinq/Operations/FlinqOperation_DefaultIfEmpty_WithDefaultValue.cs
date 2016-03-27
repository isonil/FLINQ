using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public class FlinqOperation_DefaultIfEmpty_WithDefaultValue<T> : FlinqOperation<T>
{
	private T defaultValue;

	public void OnInit(T defaultValue)
	{
		this.defaultValue = defaultValue;
	}

	public override void Transform(List<T> list, int wantedElementsCount)
	{
		if(list.Count == 0)
			list.Add(defaultValue);
	}

	public override bool RequiresFullListToWorkOn { get { return false; } }
}

}