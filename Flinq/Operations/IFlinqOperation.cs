using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public abstract class IFlinqOperation<T>
{
	public IFlinqOperation<T> parent;

	public abstract void Transform(FlinqList<T> list);
}

}