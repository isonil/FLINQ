using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Flinq
{

public struct FlinqQuery<T> : IEquatable<FlinqQuery<T>>
{
	// always returns a flinq list from pool
	internal delegate FlinqList<T> PrecedingQuery(object param);

	private static class ImplsWrapper
	{
		public static readonly PrecedingQuery implEmpty = ImplEmpty;
		public static readonly PrecedingQuery implFromSingleElement = ImplFromSingleElement;
		public static readonly FlinqQuery<int>.PrecedingQuery implRange = ImplRange;
		public static readonly PrecedingQuery implRepeat = ImplRepeat;
		public static readonly PrecedingQuery implCreate = ImplCreate;

		private static FlinqList<T> ImplEmpty(object unused)
		{
			return FlinqListPool<T>.Get();
		}

		private static FlinqList<T> ImplFromSingleElement(object param)
		{
			var list = FlinqListPool<T>.Get();

			list.Add((T)param);

			return list;
		}

		private static FlinqList<int> ImplRange(object paramsPack)
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

		private static FlinqList<T> ImplRepeat(object paramsPack)
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

		private static FlinqList<T> ImplCreate(object param)
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

	//private int precedingQueryArgIndex;
	private object precedingQueryParam;

	private FlinqOperation<T> lastOperation;

	public static FlinqQuery<T> Empty
	{
		get
		{
			return new FlinqQuery<T>(ImplsWrapper.implEmpty, null);
		}
	}

	internal FlinqQuery(List<T> list)
	{
		precedingQueryOrList = list;
		//precedingQueryArgIndex = -1;
		precedingQueryParam = null;
		lastOperation = null;
	}

	internal FlinqQuery(List<T> list, FlinqOperation<T> operation)
	{
		precedingQueryOrList = list;
		//precedingQueryArgIndex = -1;
		precedingQueryParam = null;
		lastOperation = operation;
	}

	internal FlinqQuery(FlinqQuery<T> query, FlinqOperation<T> operation)
	{
		operation.parent = query.lastOperation;

		precedingQueryOrList = query.precedingQueryOrList;
		//precedingQueryArgIndex = query.precedingQueryArgIndex;
		precedingQueryParam = query.precedingQueryParam;
		lastOperation = operation;
	}

	internal FlinqQuery(PrecedingQuery precedingQuery, object precedingQueryParam)
	{
		precedingQueryOrList = precedingQuery;
		this.precedingQueryParam = precedingQueryParam;
		lastOperation = null;
	}

	public static bool operator ==(FlinqQuery<T> lhs, FlinqQuery<T> rhs)
	{
		return lhs.precedingQueryOrList == rhs.precedingQueryOrList
			&& lhs.precedingQueryParam == rhs.precedingQueryParam
			&& lhs.lastOperation == rhs.lastOperation;
	}

	public static bool operator !=(FlinqQuery<T> lhs, FlinqQuery<T> rhs)
	{
		return !(lhs == rhs);
	}

	public static implicit operator FlinqQuery<T>(List<T> list)
	{
		return list.AsFlinqQuery();
	}

	public static FlinqQuery<T> FromSingleElement(T element)
	{
		return new FlinqQuery<T>(ImplsWrapper.implFromSingleElement, element);
	}

	public static FlinqQuery<int> Range(int start, int count)
	{
		if(count < 0)
			throw new ArgumentOutOfRangeException("count");

		var paramsPack = FlinqObjectsArrayPool.Get2();

		paramsPack[0] = start;
		paramsPack[1] = count;

		return new FlinqQuery<int>(ImplsWrapper.implRange, paramsPack);
	}

	public static FlinqQuery<T> Repeat(T element, int count)
	{
		if(count < 0)
			throw new ArgumentOutOfRangeException("count");

		var paramsPack = FlinqObjectsArrayPool.Get2();

		paramsPack[0] = element;
		paramsPack[1] = count;

		return new FlinqQuery<T>(ImplsWrapper.implRepeat, paramsPack);
	}

	public static FlinqQuery<T> Create(Action<Action<T>> initializer)
	{
		if(initializer == null)
			throw new ArgumentNullException("initializer");

		return new FlinqQuery<T>(ImplsWrapper.implCreate, initializer);
	}

	public override int GetHashCode()
	{
		return precedingQueryOrList.GetHashCode()
			^ (precedingQueryParam == null ? 0 : precedingQueryParam.GetHashCode())
			^ (lastOperation == null ? 0 : lastOperation.GetHashCode());
	}

	public override bool Equals(object obj)
	{
		if( !(obj is FlinqQuery<T>) )
			return false;

		return this == (FlinqQuery<T>)obj;
	}

	public bool Equals(FlinqQuery<T> other)
	{
		return this == other;
	}

	public FlinqList<T> GetResult()
	{
		// the public GetResult() method now just returns the FlinqList from Resolve,
		// the user just has to remember about using "using"

		return Resolve();
	}

	public FlinqQueryEnumerator<T> GetEnumerator()
	{
		return new FlinqQueryEnumerator<T>(Resolve());
	}

	// resolve method, calculates final list after all transformations,
	// returned list should be returned to pool,
	// note that the list returned from Resolve shouldn't be passed to the user,
	// it's just a local result of all transformations applied to the list and shouldn't leave this object
	
	internal FlinqList<T> Resolve()
	{
		FlinqList<T> finalList;

		var list = precedingQueryOrList as List<T>;

		if(list != null)
		{
			// create a list copy on which we will be applying transformations

			finalList = FlinqListPool<T>.Get();
			finalList.CopyFrom(list);
		}
		else
		{
			// get resolved list from our preceding query

			finalList = ((PrecedingQuery)precedingQueryOrList)(precedingQueryParam);
		}

		ApplyTransformOperations(finalList, lastOperation);

		return finalList;
	}

	private static void ApplyTransformOperations(FlinqList<T> list, FlinqOperation<T> operation)
	{
		if(operation == null)
			return;

		ApplyTransformOperations(list, operation.parent);

		operation.Transform(list);
	}
}

}