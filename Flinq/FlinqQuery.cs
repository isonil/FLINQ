using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Flinq
{

public class FlinqQuery<T>
{
	// always returns a list from pool
	internal delegate List<T> PrecedingQuery(object param);

	private static class ImplsWrapper
	{
		public static readonly PrecedingQuery implEmpty = ImplEmpty;
		public static readonly PrecedingQuery implFromSingleElement = ImplFromSingleElement;
		public static readonly FlinqQuery<int>.PrecedingQuery implRange = ImplRange;
		public static readonly PrecedingQuery implRepeat = ImplRepeat;
		public static readonly PrecedingQuery implCreate = ImplCreate;

		private static List<T> ImplEmpty(object unused)
		{
			return FlinqListPool<T>.Get();
		}

		private static List<T> ImplFromSingleElement(object param)
		{
			var list = FlinqListPool<T>.Get();

			list.Add((T)param);

			return list;
		}

		private static List<int> ImplRange(object paramsPack)
		{
			var paramsArray = (object[])paramsPack;
			var start = (int)paramsArray[0];
			var count = (int)paramsArray[1];

			var list = FlinqListPool<int>.Get();

			int end = start + count;

			for(int i = start; i <= end; ++i)
			{
				list.Add(i);
			}

			return list;
		}

		private static List<T> ImplRepeat(object paramsPack)
		{
			var paramsArray = (object[])paramsPack;
			var element = (T)paramsArray[0];
			var count = (int)paramsArray[1];

			var list = FlinqListPool<T>.Get();

			for(int i = 0; i < count; ++i)
			{
				list.Add(element);
			}

			return list;
		}
		
		private static List<T> ImplCreate(object param)
		{
			var list = FlinqListPool<T>.Get();

			((Action<Action<T>>)param)(list.Add);

			return list;
		}
	}

	// PrecedingQuery:
	// preceding query (query of potentially different type, which gives List of elements of our type; operations like Select),
	// preceding query must return a working List which is suitable for modification in-place, which means that it must return a new list from the pool,
	// list returned from this function must be returned to the pool
	// OR
	// List<T>:
	// original list
	private object precedingQueryOrList;

	// param passed to the preceding query
	private object precedingQueryParam;

	// operation to be applied on the list (operations like Where)
	private IFlinqOperation<T> operation;

	// parent query
	private FlinqQuery<T> parent;

	public static FlinqQuery<T> Empty
	{
		get
		{
			var query = FlinqQueryPool<T>.Get();

			query.OnInit(ImplsWrapper.implEmpty, null);

			return query;
		}
	}

	public static FlinqQuery<T> FromSingleElement(T element)
	{
		var query = FlinqQueryPool<T>.Get();

		query.OnInit(ImplsWrapper.implFromSingleElement, element);

		return query;
	}

	public static FlinqQuery<int> Range(int start, int count)
	{
		if(count < 0)
			throw new ArgumentOutOfRangeException("count");

		var paramsPack = FlinqObjectsArrayPool.Get2();

		paramsPack[0] = start;
		paramsPack[1] = count;

		var query = FlinqQueryPool<int>.Get();

		query.OnInit(ImplsWrapper.implRange, paramsPack);

		return query;
	}

	public static FlinqQuery<T> Repeat(T element, int count)
	{
		if(count < 0)
			throw new ArgumentOutOfRangeException("count");

		var paramsPack = FlinqObjectsArrayPool.Get2();

		paramsPack[0] = element;
		paramsPack[1] = count;

		var query = FlinqQueryPool<T>.Get();

		query.OnInit(ImplsWrapper.implRepeat, paramsPack);

		return query;
	}

	public static FlinqQuery<T> Create(Action<Action<T>> initializer)
	{
		if(initializer == null)
			throw new ArgumentNullException("initializer");

		var query = FlinqQueryPool<T>.Get();

		query.OnInit(ImplsWrapper.implCreate, initializer);

		return query;
	}

	public static implicit operator FlinqQuery<T>(List<T> list)
	{
		return list.AsFlinqQuery();
	}

	// OnInit functions
	// must be called after getting query from the pool
	// (called internally by Flinq, not by Flinq user)

	internal void OnInit(List<T> list)
	{
		precedingQueryOrList = list;
		precedingQueryParam = null;
		operation = null;
		parent = null;
	}

	internal void OnInit(List<T> list, IFlinqOperation<T> operation)
	{
		precedingQueryOrList = list;
		precedingQueryParam = null;
		this.operation = operation;
		parent = null;
	}

	internal void OnInit(FlinqQuery<T> query, IFlinqOperation<T> operation)
	{
		precedingQueryOrList = query.precedingQueryOrList;
		precedingQueryParam = query.precedingQueryParam;
		this.operation = operation;
		parent = query;
	}

	internal void OnInit(PrecedingQuery precedingQuery, object precedingQueryParam)
	{
		this.precedingQueryOrList = precedingQuery;
		this.precedingQueryParam = precedingQueryParam;
		operation = null;
		parent = null;
	}

	public FlinqQueryResult<T> GetResult()
	{
		var result = FlinqQueryResultPool<T>.Get();

		var finalList = Resolve();

		result.AddRange(finalList);

		FlinqListPool<T>.Return(finalList);

		return result;
	}

	public FlinqQueryEnumerator<T> GetEnumerator()
	{
		return new FlinqQueryEnumerator<T>(Resolve());
	}

	// resolve method, calculates final list after all transformations,
	// returned list should be returned to pool,
	// note that the list returned from Resolve shouldn't be passed to the user,
	// it's just a local result of all transformations applied to the list and shouldn't leave this object

	internal List<T> Resolve()
	{
		List<T> finalList;

		var list = precedingQueryOrList as List<T>;

		if(list != null)
		{
			// create a list copy on which we will be applying transformations

			finalList = FlinqListPool<T>.Get();
			finalList.AddRange(list);
		}
		else
		{
			// get resolved list from our preceding query

			finalList = ((PrecedingQuery)precedingQueryOrList)(precedingQueryParam);
		}

		ApplyTransformOperations(finalList, this);

		return finalList;
	}

	private static void ApplyTransformOperations(List<T> list, FlinqQuery<T> query)
	{
		if(query.parent != null)
			ApplyTransformOperations(list, query.parent);

		if(query.operation != null)
			query.operation.Transform(list);
	}
}

}