using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public interface IFlinqOperation<T>
{
	void Transform(List<T> list);
}

}