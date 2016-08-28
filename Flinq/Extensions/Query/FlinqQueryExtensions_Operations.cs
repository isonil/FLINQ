using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_Operations
{
	public static FlinqQuery<T> Where<T>(this FlinqQuery<T> query, Predicate<T> predicate)
	{
		if(predicate == null)
			throw new ArgumentNullException("predicate");

		var op = FlinqOperationPool<FlinqOperation_Where<T>>.Get();

		op.OnInit(predicate);

		return new FlinqQuery<T>(query, op);
	}

	public static FlinqQuery<T> Where<T>(this FlinqQuery<T> query, Func<T, int, bool> predicate)
	{
		if(predicate == null)
			throw new ArgumentNullException("predicate");

		var op = FlinqOperationPool<FlinqOperation_Where_WithIndex<T>>.Get();

		op.OnInit(predicate);

		return new FlinqQuery<T>(query, op);
	}

	public static FlinqQuery<T> Take<T>(this FlinqQuery<T> query, int count)
	{
		var op = FlinqOperationPool<FlinqOperation_Take<T>>.Get();

		op.OnInit(count);

		return new FlinqQuery<T>(query, op);
	}

	public static FlinqQuery<T> TakeWhile<T>(this FlinqQuery<T> query, Predicate<T> predicate)
	{
		if(predicate == null)
			throw new ArgumentNullException("predicate");

		var op = FlinqOperationPool<FlinqOperation_TakeWhile<T>>.Get();

		op.OnInit(predicate);

		return new FlinqQuery<T>(query, op);
	}

	public static FlinqQuery<T> TakeWhile<T>(this FlinqQuery<T> query, Func<T, int, bool> predicate)
	{
		if(predicate == null)
			throw new ArgumentNullException("predicate");

		var op = FlinqOperationPool<FlinqOperation_TakeWhile_WithIndex<T>>.Get();

		op.OnInit(predicate);

		return new FlinqQuery<T>(query, op);
	}

	public static FlinqQuery<T> Reversed<T>(this FlinqQuery<T> query)
	{
		var op = FlinqOperationPool<FlinqOperation_Reversed<T>>.Get();

		op.OnInit();

		return new FlinqQuery<T>(query, op);
	}

	public static FlinqQuery<T> Distinct<T>(this FlinqQuery<T> query)
	{
		var op = FlinqOperationPool<FlinqOperation_Distinct<T>>.Get();

		op.OnInit();

		return new FlinqQuery<T>(query, op);
	}

	public static FlinqQuery<T> Union<T>(this FlinqQuery<T> query, FlinqQuery<T> otherQuery)
	{
		var op = FlinqOperationPool<FlinqOperation_Union<T>>.Get();

		op.OnInit(otherQuery);
		
		return new FlinqQuery<T>(query, op);
	}
	
	public static FlinqQuery<T> UnionLeaveDuplicates<T>(this FlinqQuery<T> query, FlinqQuery<T> otherQuery)
	{
		var op = FlinqOperationPool<FlinqOperation_UnionLeaveDuplicates<T>>.Get();

		op.OnInit(otherQuery);

		return new FlinqQuery<T>(query, op);
	}

	public static FlinqQuery<T> Concat<T>(this FlinqQuery<T> query, FlinqQuery<T> otherQuery)
	{
		var op = FlinqOperationPool<FlinqOperation_Concat<T>>.Get();

		op.OnInit(otherQuery);

		return new FlinqQuery<T>(query, op);
	}

	public static FlinqQuery<T> Appended<T>(this FlinqQuery<T> query, T element)
	{
		var op = FlinqOperationPool<FlinqOperation_Appended<T>>.Get();

		op.OnInit(element);
		
		return new FlinqQuery<T>(query, op);
	}

	public static FlinqQuery<T> LazyAppend<T>(this FlinqQuery<T> query, Func<T> elementGetter)
	{
		if(elementGetter == null)
			throw new ArgumentNullException("elementGetter");

		var op = FlinqOperationPool<FlinqOperation_LazyAppend<T>>.Get();

		op.OnInit(elementGetter);

		return new FlinqQuery<T>(query, op);
	}

	public static FlinqQuery<T> Prepended<T>(this FlinqQuery<T> query, T element)
	{
		var op = FlinqOperationPool<FlinqOperation_Prepended<T>>.Get();

		op.OnInit(element);

		return new FlinqQuery<T>(query, op);
	}

	public static FlinqQuery<T> LazyPrepend<T>(this FlinqQuery<T> query, Func<T> elementGetter)
	{
		if(elementGetter == null)
			throw new ArgumentNullException("elementGetter");

		var op = FlinqOperationPool<FlinqOperation_LazyPrepend<T>>.Get();

		op.OnInit(elementGetter);

		return new FlinqQuery<T>(query, op);
	}

	public static FlinqQuery<T> DefaultIfEmpty<T>(this FlinqQuery<T> query)
	{
		var op = FlinqOperationPool<FlinqOperation_DefaultIfEmpty<T>>.Get();

		op.OnInit();

		return new FlinqQuery<T>(query, op);
	}

	public static FlinqQuery<T> DefaultIfEmpty<T>(this FlinqQuery<T> query, T defaultValue)
	{
		var op = FlinqOperationPool<FlinqOperation_DefaultIfEmpty_WithDefaultValue<T>>.Get();

		op.OnInit(defaultValue);

		return new FlinqQuery<T>(query, op);
	}

	public static FlinqQuery<T> Except<T>(this FlinqQuery<T> query, FlinqQuery<T> otherQuery)
	{
		var op = FlinqOperationPool<FlinqOperation_Except<T>>.Get();

		op.OnInit(otherQuery);

		return new FlinqQuery<T>(query, op);
	}

	public static FlinqQuery<T> Intersect<T>(this FlinqQuery<T> query, FlinqQuery<T> otherQuery)
	{
		var op = FlinqOperationPool<FlinqOperation_Intersect<T>>.Get();

		op.OnInit(otherQuery);

		return new FlinqQuery<T>(query, op);
	}

	public static FlinqQuery<T> ExistIn<T>(this FlinqQuery<T> query, FlinqQuery<T> otherQuery)
	{
		var op = FlinqOperationPool<FlinqOperation_ExistIn<T>>.Get();

		op.OnInit(otherQuery);

		return new FlinqQuery<T>(query, op);
	}

	public static FlinqQuery<T> Skip<T>(this FlinqQuery<T> query, int count)
	{
		var op = FlinqOperationPool<FlinqOperation_Skip<T>>.Get();

		op.OnInit(count);

		return new FlinqQuery<T>(query, op);
	}

	public static FlinqQuery<T> SkipWhile<T>(this FlinqQuery<T> query, Predicate<T> predicate)
	{
		if(predicate == null)
			throw new ArgumentNullException("predicate");

		var op = FlinqOperationPool<FlinqOperation_SkipWhile<T>>.Get();

		op.OnInit(predicate);

		return new FlinqQuery<T>(query, op);
	}

	public static FlinqQuery<T> SkipWhile<T>(this FlinqQuery<T> query, Func<T, int, bool> predicate)
	{
		if(predicate == null)
			throw new ArgumentNullException("predicate");

		var op = FlinqOperationPool<FlinqOperation_SkipWhile_WithIndex<T>>.Get();

		op.OnInit(predicate);

		return new FlinqQuery<T>(query, op);
	}

	public static FlinqQuery<T> InRandomOrder<T>(this FlinqQuery<T> query)
	{
		var op = FlinqOperationPool<FlinqOperation_InRandomOrder<T>>.Get();

		op.OnInit();

		return new FlinqQuery<T>(query, op);
	}

	public static FlinqQuery<T> InRandomOrder<T>(this FlinqQuery<T> query, Func<int, int, int> intRangeInclusive)
	{
		if(intRangeInclusive == null)
			throw new ArgumentNullException("intRangeInclusive");

		var op = FlinqOperationPool<FlinqOperation_InRandomOrder_WithRandomNumberGenerator<T>>.Get();

		op.OnInit(intRangeInclusive);

		return new FlinqQuery<T>(query, op);
	}

	public static FlinqQuery<T> GetDuplicates<T>(this FlinqQuery<T> query)
	{
		var op = FlinqOperationPool<FlinqOperation_GetDuplicates<T>>.Get();

		op.OnInit();

		return new FlinqQuery<T>(query, op);
	}
	
	public static FlinqQuery<T> GetDuplicatesBy<T, TCompareBy>(this FlinqQuery<T> query, Func<T, TCompareBy> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var op = FlinqOperationPool<FlinqOperation_GetDuplicatesBy<T, TCompareBy>>.Get();

		op.OnInit(selector);

		return new FlinqQuery<T>(query, op);
	}
}

}