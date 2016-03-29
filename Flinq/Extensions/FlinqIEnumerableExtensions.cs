using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqIEnumerableExtensions
{
	private static class ImplWrapper<T>
	{
		public static readonly FlinqQuery<T>.PrecedingQuery impl = Impl;

		private static List<T> Impl(object param)
		{
			var enumerable = (IEnumerable<T>)param;

			var newList = FlinqListPool<T>.Get();

			newList.AddRange(enumerable);

			return newList;
		}
	}

	public static FlinqQuery<T> AsFlinqQuery<T>(this IEnumerable<T> enumerable)
	{
		if(enumerable == null)
			return FlinqQuery<T>.Empty;

		var query = FlinqQueryPool<T>.Get();

		var asList = enumerable as List<T>;

		if(asList != null) // is it already a list? great!
			query.OnInit(asList);
		else // since FlinqQuery uses list internally, we need to create preceding query which converts enumerable to list
			query.OnInit(ImplWrapper<T>.impl, enumerable);

		return query;
	}

	// TODO: each FlinqQuery extension implemented like this: enumerable.AsFlinqQuery().Extention();
}

}