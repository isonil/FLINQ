using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqListExtensions
{
	// conversions to FlinqQuery

	public static FlinqQuery<T> AsFlinqQuery<T>(this List<T> list)
	{
		if(list == null)
			return FlinqQuery<T>.Empty;

		var query = FlinqQueryPool<T>.Get();

		query.OnInit(list);

		return query;
	}

	/*
	public static FlinqQuery<T> AsFlinqQuery<TKey, T>(this Dictionary<TKey, T> dictionary)
	{
		if(dictionary == null)
			return FlinqQuery<T>.Empty;

		var query = FlinqQueryPool<T>.Get();

		// since FlinqQuery uses list internally, we need to create preceding query which converts dictionary to list

		query.OnInit(wantedElementsCount =>
			{
				var list = FlinqListPool<T>.Get();

				int alreadyAdded = 0;

				foreach(var elem in dictionary)
				{
					list.Add(elem.Value);

					++alreadyAdded;

					if(alreadyAdded == wantedElementsCount)
						break;
				}

				return list;
			});

		return query;
	}

	public static FlinqQuery<T> AsFlinqQuery<T>(this HashSet<T> hashSet)
	{
		if(hashSet == null)
			return FlinqQuery<T>.Empty;

		var query = FlinqQueryPool<T>.Get();

		// since FlinqQuery uses list internally, we need to create preceding query which converts hash set to list

		query.OnInit(wantedElementsCount =>
			{
				var list = FlinqListPool<T>.Get();

				int alreadyAdded = 0;

				foreach(var elem in hashSet)
				{
					list.Add(elem);

					++alreadyAdded;

					if(alreadyAdded == wantedElementsCount)
						break;
				}

				return list;
			});

		return query;
	}

	public static FlinqQuery<T> AsFlinqQuery<T>(this T[] array)
	{
		if(array == null)
			return FlinqQuery<T>.Empty;

		var query = FlinqQueryPool<T>.Get();

		// since FlinqQuery uses list internally, we need to create preceding query which converts array to list

		query.OnInit(wantedElementsCount =>
			{
				var list = FlinqListPool<T>.Get();

				int arrayLength = array.Length;

				// do a check, because AddRange is super fast
				if(wantedElementsCount >= arrayLength)
					list.AddRange(array);
				else
				{
					int count = Math.Min(wantedElementsCount, arrayLength);

					for(int i = 0; i < count; ++i)
					{
						list.Add(array[i]);
					}
				}

				return list;
			});

		return query;
	}
	*/
	// these will create preceding operations
	// (they can't be normal operations because they depend on other types than T)

	public static FlinqQuery<TResult> Cast<T, TResult>(this List<T> list)
	{
		if(list == null)
			throw new ArgumentNullException("list");

		return list.AsFlinqQuery().Cast<T, TResult>();
	}

	public static FlinqQuery<TResult> Select<T, TResult>(this List<T> list, Func<T, TResult> select)
	{
		if(list == null)
			throw new ArgumentNullException("list");

		if(select == null)
			throw new ArgumentNullException("select");

		return list.AsFlinqQuery().Select(select);
	}

	public static FlinqQuery<T> OrderBy<T, TKey>(this List<T> list, Func<T, TKey> keySelector) where TKey : IComparable<TKey>
	{
		if(list == null)
			throw new ArgumentNullException("list");

		if(keySelector == null)
			throw new ArgumentNullException("keySelector");

		return list.AsFlinqQuery().OrderBy(keySelector);
	}

	public static FlinqQuery<T> OrderByDescending<T, TKey>(this List<T> list, Func<T, TKey> keySelector) where TKey : IComparable<TKey>
	{
		if(list == null)
			throw new ArgumentNullException("list");

		if(keySelector == null)
			throw new ArgumentNullException("keySelector");

		return list.AsFlinqQuery().OrderByDescending(keySelector);
	}

	// chainable operations,
	// note that we don't use, for example, list.AsLinqQuery().Where(...), because we can directly
	// create FlinqQuery with the desired operation, which is slightly faster

	public static FlinqQuery<T> Where<T>(this List<T> list, Predicate<T> predicate)
	{
		if(list == null)
			throw new ArgumentNullException("list");

		if(predicate == null)
			throw new ArgumentNullException("predicate");

		var op = FlinqOperationPool<FlinqOperation_Where<T>>.Get();

		op.OnInit(predicate);

		var query = FlinqQueryPool<T>.Get();

		query.OnInit(list, op);

		return query;
	}

	public static FlinqQuery<T> Take<T>(this List<T> list, int count)
	{
		if(list == null)
			throw new ArgumentNullException("list");

		var op = FlinqOperationPool<FlinqOperation_Take<T>>.Get();

		op.OnInit(count);

		var query = FlinqQueryPool<T>.Get();

		query.OnInit(list, op);

		return query;
	}

	public static FlinqQuery<T> TakeWhile<T>(this List<T> list, Predicate<T> predicate)
	{
		if(list == null)
			throw new ArgumentNullException("list");

		if(predicate == null)
			throw new ArgumentNullException("predicate");

		var op = FlinqOperationPool<FlinqOperation_TakeWhile<T>>.Get();

		op.OnInit(predicate);

		var query = FlinqQueryPool<T>.Get();

		query.OnInit(list, op);

		return query;
	}

	public static FlinqQuery<T> Reverse<T>(this List<T> list)
	{
		if(list == null)
			throw new ArgumentNullException("list");

		var op = FlinqOperationPool<FlinqOperation_Reverse<T>>.Get();

		op.OnInit();

		var query = FlinqQueryPool<T>.Get();

		query.OnInit(list, op);

		return query;
	}

	public static FlinqQuery<T> Distinct<T>(this List<T> list)
	{
		if(list == null)
			throw new ArgumentNullException("list");

		var op = FlinqOperationPool<FlinqOperation_Distinct<T>>.Get();

		op.OnInit();

		var query = FlinqQueryPool<T>.Get();

		query.OnInit(list, op);

		return query;
	}

	// some extra extensions, they don't use FlinqQuery (will be probably removed)

	public static T FirstOrDefault<T>(this List<T> list)
	{
		if(list.NullOrEmpty())
			return default(T);

		return list[0];
	}

	public static bool NullOrEmpty<T>(this List<T> list)
	{
		return list == null || list.Count == 0;
	}
}

}