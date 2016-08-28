using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqListExtensions
{
	public static FlinqQuery<T> AsFlinqQuery<T>(this List<T> list)
	{
		if(list == null)
			return FlinqQuery<T>.Empty;

		return new FlinqQuery<T>(list);
	}

	// Operations:

	public static FlinqQuery<T> Appended<T>(this List<T> list, T element)
	{
		if(list == null)
			throw new ArgumentNullException("list");

		var op = FlinqOperationPool<FlinqOperation_Appended<T>>.Get();

		op.OnInit(element);

		return new FlinqQuery<T>(list, op);
	}

	public static FlinqQuery<T> Concat<T>(this List<T> list, FlinqQuery<T> otherQuery)
	{
		if(list == null)
			throw new ArgumentNullException("list");
		
		var op = FlinqOperationPool<FlinqOperation_Concat<T>>.Get();

		op.OnInit(otherQuery);

		return new FlinqQuery<T>(list, op);
	}
	
	public static FlinqQuery<T> DefaultIfEmpty<T>(this List<T> list)
	{
		if(list == null)
			throw new ArgumentNullException("list");
		
		var op = FlinqOperationPool<FlinqOperation_DefaultIfEmpty<T>>.Get();

		op.OnInit();

		return new FlinqQuery<T>(list, op);
	}

	public static FlinqQuery<T> DefaultIfEmpty<T>(this List<T> list, T defaultValue)
	{
		if(list == null)
			throw new ArgumentNullException("list");
		
		var op = FlinqOperationPool<FlinqOperation_DefaultIfEmpty_WithDefaultValue<T>>.Get();

		op.OnInit(defaultValue);

		return new FlinqQuery<T>(list, op);
	}
	
	public static FlinqQuery<T> Distinct<T>(this List<T> list)
	{
		if(list == null)
			throw new ArgumentNullException("list");

		var op = FlinqOperationPool<FlinqOperation_Distinct<T>>.Get();

		op.OnInit();

		return new FlinqQuery<T>(list, op);
	}
	
	public static FlinqQuery<T> Except<T>(this List<T> list, FlinqQuery<T> except)
	{
		if(list == null)
			throw new ArgumentNullException("list");

		var op = FlinqOperationPool<FlinqOperation_Except<T>>.Get();

		op.OnInit(except);

		return new FlinqQuery<T>(list, op);
	}
	
	public static FlinqQuery<T> ExistIn<T>(this List<T> list, FlinqQuery<T> intersect)
	{
		if(list == null)
			throw new ArgumentNullException("list");

		var op = FlinqOperationPool<FlinqOperation_ExistIn<T>>.Get();

		op.OnInit(intersect);

		return new FlinqQuery<T>(list, op);
	}
	
	public static FlinqQuery<T> GetDuplicates<T>(this List<T> list)
	{
		if(list == null)
			throw new ArgumentNullException("list");

		var op = FlinqOperationPool<FlinqOperation_GetDuplicates<T>>.Get();

		op.OnInit();

		return new FlinqQuery<T>(list, op);
	}
	
	public static FlinqQuery<T> GetDuplicatesBy<T, TCompareBy>(this List<T> list, Func<T, TCompareBy> selector)
	{
		if(list == null)
			throw new ArgumentNullException("list");

		if(selector == null)
			throw new ArgumentNullException("selector");

		var op = FlinqOperationPool<FlinqOperation_GetDuplicatesBy<T, TCompareBy>>.Get();

		op.OnInit(selector);

		return new FlinqQuery<T>(list, op);
	}
	
	public static FlinqQuery<T> InRandomOrder<T>(this List<T> list)
	{
		if(list == null)
			throw new ArgumentNullException("list");

		var op = FlinqOperationPool<FlinqOperation_InRandomOrder<T>>.Get();

		op.OnInit();

		return new FlinqQuery<T>(list, op);
	}
	
	public static FlinqQuery<T> InRandomOrder<T>(this List<T> list, Func<int, int, int> intRangeInclusive)
	{
		if(list == null)
			throw new ArgumentNullException("list");

		if(intRangeInclusive == null)
			throw new ArgumentNullException("intRangeInclusive");

		var op = FlinqOperationPool<FlinqOperation_InRandomOrder_WithRandomNumberGenerator<T>>.Get();

		op.OnInit(intRangeInclusive);

		return new FlinqQuery<T>(list, op);
	}

	///////

	public static FlinqQuery<T> Where<T>(this List<T> list, Predicate<T> predicate)
	{
		if(list == null)
			throw new ArgumentNullException("list");

		if(predicate == null)
			throw new ArgumentNullException("predicate");

		var op = FlinqOperationPool<FlinqOperation_Where<T>>.Get();

		op.OnInit(predicate);

		return new FlinqQuery<T>(list, op);
	}

	public static FlinqQuery<T> Take<T>(this List<T> list, int count)
	{
		if(list == null)
			throw new ArgumentNullException("list");

		var op = FlinqOperationPool<FlinqOperation_Take<T>>.Get();

		op.OnInit(count);

		return new FlinqQuery<T>(list, op);
	}

	public static FlinqQuery<T> TakeWhile<T>(this List<T> list, Predicate<T> predicate)
	{
		if(list == null)
			throw new ArgumentNullException("list");

		if(predicate == null)
			throw new ArgumentNullException("predicate");

		var op = FlinqOperationPool<FlinqOperation_TakeWhile<T>>.Get();

		op.OnInit(predicate);

		return new FlinqQuery<T>(list, op);
	}

	public static FlinqQuery<T> Reversed<T>(this List<T> list)
	{
		if(list == null)
			throw new ArgumentNullException("list");

		var op = FlinqOperationPool<FlinqOperation_Reversed<T>>.Get();

		op.OnInit();

		return new FlinqQuery<T>(list, op);
	}

	// TODO: rest

	// Preceding queries:

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

		return list.AsFlinqQuery().Select(select);
	}

	public static FlinqQuery<T> OrderBy<T, TKey>(this List<T> list, Func<T, TKey> keySelector) where TKey : IComparable<TKey>
	{
		if(list == null)
			throw new ArgumentNullException("list");

		return list.AsFlinqQuery().OrderBy(keySelector);
	}

	public static FlinqQuery<T> OrderByDescending<T, TKey>(this List<T> list, Func<T, TKey> keySelector) where TKey : IComparable<TKey>
	{
		if(list == null)
			throw new ArgumentNullException("list");

		return list.AsFlinqQuery().OrderByDescending(keySelector);
	}

	// TODO: rest

	// Final operations:

	public static bool Any<T>(this List<T> list, Predicate<T> predicate)
	{
		if(list == null)
			throw new ArgumentNullException("list");

		if(predicate == null)
			throw new ArgumentNullException("predicate");

		return list.FindIndex(predicate) != -1;
	}

	// TODO: rest

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