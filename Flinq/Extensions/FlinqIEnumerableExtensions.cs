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

		private static FlinqList<T> Impl(object param)
		{
			var enumerable = (IEnumerable<T>)param;

			var newList = FlinqListPool<T>.Get();

			newList.CopyFrom(enumerable);

			return newList;
		}
	}

	public static FlinqQuery<T> AsFlinqQuery<T>(this IEnumerable<T> enumerable)
	{
		if(enumerable == null)
			return FlinqQuery<T>.Empty;

		var asList = enumerable as List<T>;

		if(asList != null) // is it already a list? great!
			return new FlinqQuery<T>(asList);
		else // since FlinqQuery uses list internally, we need to create a preceding query which converts enumerable to list
			return new FlinqQuery<T>(ImplWrapper<T>.impl, enumerable);
	}

	// TODO: each FlinqQuery extension implemented like this: enumerable.AsFlinqQuery().Extention();
	
	public static FlinqQuery<TResult> Cast<T, TResult>(this IEnumerable<T> source)
	{
		if(source == null)
			throw new ArgumentNullException("source");

		return source.AsFlinqQuery().Cast<T, TResult>();
	}

	public static FlinqQuery<TResult> Select<T, TResult>(this IEnumerable<T> source, Func<T, TResult> select)
	{
		if(source == null)
			throw new ArgumentNullException("source");

		if(select == null)
			throw new ArgumentNullException("select");

		return source.AsFlinqQuery().Select(select);
	}

	public static FlinqQuery<T> OrderBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector) where TKey : IComparable<TKey>
	{
		if(source == null)
			throw new ArgumentNullException("source");

		if(keySelector == null)
			throw new ArgumentNullException("keySelector");

		return source.AsFlinqQuery().OrderBy(keySelector);
	}

	public static FlinqQuery<T> OrderByDescending<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector) where TKey : IComparable<TKey>
	{
		if(source == null)
			throw new ArgumentNullException("source");

		if(keySelector == null)
			throw new ArgumentNullException("keySelector");

		return source.AsFlinqQuery().OrderByDescending(keySelector);
	}
}

}