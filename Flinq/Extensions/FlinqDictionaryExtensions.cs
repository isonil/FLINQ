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

		private static List<T> Impl(object param)
		{
			var dictionary = (Dictionary<TKey, T>)param;

			var newList = FlinqListPool<T>.Get();

			foreach(var elem in dictionary)
			{
				newList.Add(elem.Value);
			}

			return newList;
		}
	}

	public static FlinqQuery<T> AsFlinqQuery<TKey, T>(this Dictionary<TKey, T> dictionary)
	{
		if(dictionary == null)
			return FlinqQuery<T>.Empty;

		var query = FlinqQueryPool<T>.Get();

		query.OnInit(ImplWrapper<TKey, T>.impl, dictionary);

		return query;
	}
}

}