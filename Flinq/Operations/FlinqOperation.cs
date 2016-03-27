using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public abstract class FlinqOperation<T>
{
	public abstract void Transform(List<T> list, int wantedElementsCount);

	// this answers the following question: if I were to give you a sublist (from first n elements) of the original list,
	// and let you apply transformation on it, then would any element of the resulting list (of size X) be different
	// from any of the first X elements of the resulting list if I gave you the full list?
	public abstract bool RequiresFullListToWorkOn { get; }
}

}