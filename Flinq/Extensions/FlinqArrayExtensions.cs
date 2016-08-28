using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqArrayExtensions
{
	private static class ImplWrapper<T>
	{
		public static readonly FlinqQuery<T>.PrecedingQuery impl = Impl;

		private static FlinqList<T> Impl(object param)
		{
			var array = (T[])param;

			var newList = FlinqListPool<T>.Get();

			newList.CopyFrom(array);

			return newList;
		}
	}

	public static FlinqQuery<T> AsFlinqQuery<T>(this T[] array)
	{
		if(array == null)
			return FlinqQuery<T>.Empty;

		return new FlinqQuery<T>(ImplWrapper<T>.impl, array);
	}
}

}