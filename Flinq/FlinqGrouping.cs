using System.Collections;

namespace Flinq
{

public class FlinqGrouping<TKey, T> : FlinqQuery<T>
{
	public TKey Key { get; internal set; }
}

}