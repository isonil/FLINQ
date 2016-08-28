using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqDictionaryExtensions
{
	private static class ImplWrapper<TKey, T>
	{
		public static readonly FlinqQuery<T>.PrecedingQuery impl = Impl;

		private static FlinqList<T> Impl(object param)
		{
			var dictionary = (Dictionary<TKey, T>)param;

			var newList = FlinqListPool<T>.Get();

			newList.CopyFrom(dictionary);

			return newList;
		}
	}

	public static FlinqQuery<T> AsFlinqQuery<TKey, T>(this Dictionary<TKey, T> dictionary)
	{
		if(dictionary == null)
			return FlinqQuery<T>.Empty;

		return new FlinqQuery<T>(ImplWrapper<TKey, T>.impl, dictionary);
	}
}

}