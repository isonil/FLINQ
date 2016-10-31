using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public abstract class FlinqOperation<T>
{
	public FlinqOperation<T> parent;

	public abstract void Transform(FlinqList<T> list);
}

}