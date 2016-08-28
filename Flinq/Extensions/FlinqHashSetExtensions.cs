using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqHashSetExtensions
{
	private static class ImplWrapper<T>
	{
		public static readonly FlinqQuery<T>.PrecedingQuery impl = Impl;

		private static FlinqList<T> Impl(object param)
		{
			var hashSet = (HashSet<T>)param;

			var newList = FlinqListPool<T>.Get();

			newList.CopyFrom(hashSet);

			return newList;
		}
	}

	public static FlinqQuery<T> AsFlinqQuery<T>(this HashSet<T> hashSet)
	{
		if(hashSet == null)
			return FlinqQuery<T>.Empty;

		return new FlinqQuery<T>(ImplWrapper<T>.impl, hashSet);
	}
}

}