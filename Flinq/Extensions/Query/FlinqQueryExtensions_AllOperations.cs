using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_AllOperations
{
	public static FlinqQuery<T> Where<T>(this FlinqQuery<T> query, Predicate<T> predicate)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(predicate == null)
			throw new ArgumentNullException("predicate");

		var op = FlinqOperationPool<FlinqOperation_Where<T>>.Get();

		op.OnInit(predicate);

		var newQuery = FlinqQueryPool<T>.Get();

		newQuery.OnInit(query, op);

		return newQuery;
	}

	public static FlinqQuery<T> Where<T>(this FlinqQuery<T> query, Func<T, int, bool> predicate)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(predicate == null)
			throw new ArgumentNullException("predicate");

		var op = FlinqOperationPool<FlinqOperation_Where_WithIndex<T>>.Get();

		op.OnInit(predicate);

		var newQuery = FlinqQueryPool<T>.Get();

		newQuery.OnInit(query, op);

		return newQuery;
	}

	public static FlinqQuery<T> Take<T>(this FlinqQuery<T> query, int count)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var op = FlinqOperationPool<FlinqOperation_Take<T>>.Get();

		op.OnInit(count);

		var newQuery = FlinqQueryPool<T>.Get();

		newQuery.OnInit(query, op);

		return newQuery;
	}

	public static FlinqQuery<T> TakeWhile<T>(this FlinqQuery<T> query, Predicate<T> predicate)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(predicate == null)
			throw new ArgumentNullException("predicate");

		var op = FlinqOperationPool<FlinqOperation_TakeWhile<T>>.Get();

		op.OnInit(predicate);

		var newQuery = FlinqQueryPool<T>.Get();

		newQuery.OnInit(query, op);

		return newQuery;
	}

	public static FlinqQuery<T> TakeWhile<T>(this FlinqQuery<T> query, Func<T, int, bool> predicate)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(predicate == null)
			throw new ArgumentNullException("predicate");

		var op = FlinqOperationPool<FlinqOperation_TakeWhile_WithIndex<T>>.Get();

		op.OnInit(predicate);

		var newQuery = FlinqQueryPool<T>.Get();

		newQuery.OnInit(query, op);

		return newQuery;
	}

	public static FlinqQuery<T> Reverse<T>(this FlinqQuery<T> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var op = FlinqOperationPool<FlinqOperation_Reverse<T>>.Get();

		op.OnInit();

		var newQuery = FlinqQueryPool<T>.Get();

		newQuery.OnInit(query, op);

		return newQuery;
	}

	public static FlinqQuery<T> Distinct<T>(this FlinqQuery<T> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var op = FlinqOperationPool<FlinqOperation_Distinct<T>>.Get();

		op.OnInit();

		var newQuery = FlinqQueryPool<T>.Get();

		newQuery.OnInit(query, op);

		return newQuery;
	}

	public static FlinqQuery<T> Union<T>(this FlinqQuery<T> query, FlinqQuery<T> otherQuery)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(otherQuery == null)
			throw new ArgumentNullException("otherQuery");

		var op = FlinqOperationPool<FlinqOperation_Union<T>>.Get();

		op.OnInit(otherQuery);

		var newQuery = FlinqQueryPool<T>.Get();

		newQuery.OnInit(query, op);

		return newQuery;
	}
	
	public static FlinqQuery<T> UnionLeaveDuplicates<T>(this FlinqQuery<T> query, FlinqQuery<T> otherQuery)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(otherQuery == null)
			throw new ArgumentNullException("otherQuery");

		var op = FlinqOperationPool<FlinqOperation_UnionLeaveDuplicates<T>>.Get();

		op.OnInit(otherQuery);

		var newQuery = FlinqQueryPool<T>.Get();

		newQuery.OnInit(query, op);

		return newQuery;
	}

	public static FlinqQuery<T> Concat<T>(this FlinqQuery<T> query, FlinqQuery<T> otherQuery)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(otherQuery == null)
			throw new ArgumentNullException("otherQuery");

		var op = FlinqOperationPool<FlinqOperation_Concat<T>>.Get();

		op.OnInit(otherQuery);

		var newQuery = FlinqQueryPool<T>.Get();

		newQuery.OnInit(query, op);

		return newQuery;
	}

	public static FlinqQuery<T> Append<T>(this FlinqQuery<T> query, T element)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var op = FlinqOperationPool<FlinqOperation_Append<T>>.Get();

		op.OnInit(element);

		var newQuery = FlinqQueryPool<T>.Get();

		newQuery.OnInit(query, op);

		return newQuery;
	}

	public static FlinqQuery<T> LazyAppend<T>(this FlinqQuery<T> query, Func<T> elementGetter)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(elementGetter == null)
			throw new ArgumentNullException("elementGetter");

		var op = FlinqOperationPool<FlinqOperation_LazyAppend<T>>.Get();

		op.OnInit(elementGetter);

		var newQuery = FlinqQueryPool<T>.Get();

		newQuery.OnInit(query, op);

		return newQuery;
	}

	public static FlinqQuery<T> Prepend<T>(this FlinqQuery<T> query, T element)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var op = FlinqOperationPool<FlinqOperation_Prepend<T>>.Get();

		op.OnInit(element);

		var newQuery = FlinqQueryPool<T>.Get();

		newQuery.OnInit(query, op);

		return newQuery;
	}

	public static FlinqQuery<T> LazyPrepend<T>(this FlinqQuery<T> query, Func<T> elementGetter)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(elementGetter == null)
			throw new ArgumentNullException("elementGetter");

		var op = FlinqOperationPool<FlinqOperation_LazyPrepend<T>>.Get();

		op.OnInit(elementGetter);

		var newQuery = FlinqQueryPool<T>.Get();

		newQuery.OnInit(query, op);

		return newQuery;
	}

	public static FlinqQuery<T> DefaultIfEmpty<T>(this FlinqQuery<T> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var op = FlinqOperationPool<FlinqOperation_DefaultIfEmpty<T>>.Get();

		op.OnInit();

		var newQuery = FlinqQueryPool<T>.Get();

		newQuery.OnInit(query, op);

		return newQuery;
	}

	public static FlinqQuery<T> DefaultIfEmpty<T>(this FlinqQuery<T> query, T defaultValue)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var op = FlinqOperationPool<FlinqOperation_DefaultIfEmpty_WithDefaultValue<T>>.Get();

		op.OnInit(defaultValue);

		var newQuery = FlinqQueryPool<T>.Get();

		newQuery.OnInit(query, op);

		return newQuery;
	}

	public static FlinqQuery<T> Except<T>(this FlinqQuery<T> query, FlinqQuery<T> otherQuery)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(otherQuery == null)
			throw new ArgumentNullException("otherQuery");

		var op = FlinqOperationPool<FlinqOperation_Except<T>>.Get();

		op.OnInit(otherQuery);

		var newQuery = FlinqQueryPool<T>.Get();

		newQuery.OnInit(query, op);

		return newQuery;
	}

	public static FlinqQuery<T> Intersect<T>(this FlinqQuery<T> query, FlinqQuery<T> otherQuery)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(otherQuery == null)
			throw new ArgumentNullException("otherQuery");

		var op = FlinqOperationPool<FlinqOperation_Intersect<T>>.Get();

		op.OnInit(otherQuery);

		var newQuery = FlinqQueryPool<T>.Get();

		newQuery.OnInit(query, op);

		return newQuery;
	}

	public static FlinqQuery<T> ExistIn<T>(this FlinqQuery<T> query, FlinqQuery<T> otherQuery)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(otherQuery == null)
			throw new ArgumentNullException("otherQuery");

		var op = FlinqOperationPool<FlinqOperation_ExistIn<T>>.Get();

		op.OnInit(otherQuery);

		var newQuery = FlinqQueryPool<T>.Get();

		newQuery.OnInit(query, op);

		return newQuery;
	}

	public static FlinqQuery<T> Skip<T>(this FlinqQuery<T> query, int count)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var op = FlinqOperationPool<FlinqOperation_Skip<T>>.Get();

		op.OnInit(count);

		var newQuery = FlinqQueryPool<T>.Get();

		newQuery.OnInit(query, op);

		return newQuery;
	}

	public static FlinqQuery<T> SkipWhile<T>(this FlinqQuery<T> query, Predicate<T> predicate)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(predicate == null)
			throw new ArgumentNullException("predicate");

		var op = FlinqOperationPool<FlinqOperation_SkipWhile<T>>.Get();

		op.OnInit(predicate);

		var newQuery = FlinqQueryPool<T>.Get();

		newQuery.OnInit(query, op);

		return newQuery;
	}

	public static FlinqQuery<T> SkipWhile<T>(this FlinqQuery<T> query, Func<T, int, bool> predicate)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(predicate == null)
			throw new ArgumentNullException("predicate");

		var op = FlinqOperationPool<FlinqOperation_SkipWhile_WithIndex<T>>.Get();

		op.OnInit(predicate);

		var newQuery = FlinqQueryPool<T>.Get();

		newQuery.OnInit(query, op);

		return newQuery;
	}

	public static FlinqQuery<T> InRandomOrder<T>(this FlinqQuery<T> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var op = FlinqOperationPool<FlinqOperation_InRandomOrder<T>>.Get();

		op.OnInit();

		var newQuery = FlinqQueryPool<T>.Get();

		newQuery.OnInit(query, op);

		return newQuery;
	}

	public static FlinqQuery<T> InRandomOrder<T>(this FlinqQuery<T> query, Func<int, int, int> intRangeInclusive)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(intRangeInclusive == null)
			throw new ArgumentNullException("intRangeInclusive");

		var op = FlinqOperationPool<FlinqOperation_InRandomOrder_WithRandomNumberGenerator<T>>.Get();

		op.OnInit(intRangeInclusive);

		var newQuery = FlinqQueryPool<T>.Get();

		newQuery.OnInit(query, op);

		return newQuery;
	}

	public static FlinqQuery<T> GetDuplicates<T>(this FlinqQuery<T> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var op = FlinqOperationPool<FlinqOperation_GetDuplicates<T>>.Get();

		op.OnInit();

		var newQuery = FlinqQueryPool<T>.Get();

		newQuery.OnInit(query, op);

		return newQuery;
	}
}

}