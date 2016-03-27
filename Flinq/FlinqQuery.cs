using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Flinq
{

public class FlinqQuery<T>
{
	internal delegate List<T> PrecedingQuery(int wantedElementsCount, object param);

	private static class ImplsWrapper
	{
		public static readonly PrecedingQuery implEmpty = ImplEmpty;
		public static readonly PrecedingQuery implFromSingleElement = ImplFromSingleElement;
		public static readonly FlinqQuery<int>.PrecedingQuery implRange = ImplRange;
		public static readonly PrecedingQuery implRepeat = ImplRepeat;
		public static readonly PrecedingQuery implCreate = ImplCreate;

		private static List<T> ImplEmpty(int wantedElementsCount, object unused)
		{
			return FlinqListPool<T>.Get();
		}

		private static List<T> ImplFromSingleElement(int wantedElementsCount, object param)
		{
			var list = FlinqListPool<T>.Get();

			list.Add((T)param);

			return list;
		}

		private static List<int> ImplRange(int wantedElementsCount, object paramsPack)
		{
			var paramsArray = (object[])paramsPack;
			var start = (int)paramsArray[0];
			var count = (int)paramsArray[1];

			var list = FlinqListPool<int>.Get();

			int end = start + Math.Min(count, wantedElementsCount);

			for(int i = start; i <= end; ++i)
			{
				list.Add(i);
			}

			return list;
		}

		private static List<T> ImplRepeat(int wantedElementsCount, object paramsPack)
		{
			var paramsArray = (object[])paramsPack;
			var element = (T)paramsArray[0];
			var count = (int)paramsArray[1];

			var list = FlinqListPool<T>.Get();

			int count2 = Math.Min(count, wantedElementsCount);

			for(int i = 0; i < count2; ++i)
			{
				list.Add(element);
			}

			return list;
		}
		
		private static List<T> ImplCreate(int wantedElementsCount, object param)
		{
			var list = FlinqListPool<T>.Get();

			((Action<Action<T>>)param)(list.Add);

			return list;
		}
	}

	// PrecedingQuery:
	// preceding query (query of potentially different type, which gives List of elements of our type; operations like Select),
	// preceding query must return List which is suitable for modification in-place, so this means that it must return a new list from the pool,
	// list returned from this function must be returned to the pool
	// OR
	// List<T>:
	// original list
	private object precedingQueryOrList;

	// param passed to the preceding query
	private object precedingQueryParam;

	// operation to be applied on the list (operations like Where)
	private FlinqOperation<T> operation;

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

	public static FlinqQuery<T> Create(Action<Action<T>> elementsGiver)
	{
		var query = FlinqQueryPool<T>.Get();

		query.OnInit(ImplsWrapper.implCreate, elementsGiver);

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

	internal void OnInit(List<T> list, FlinqOperation<T> operation)
	{
		precedingQueryOrList = list;
		precedingQueryParam = null;
		this.operation = operation;
		parent = null;
	}

	internal void OnInit(FlinqQuery<T> query, FlinqOperation<T> operation)
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

		bool returnToPool;

		var finalList = Resolve(int.MaxValue, out returnToPool);

		result.AddRange(finalList);

		CleanupAfterResolve(finalList, returnToPool);

		return result;
	}

	public FlinqQueryEnumerator<T> GetEnumerator()
	{
		return new FlinqQueryEnumerator<T>(GetResult());
	}

	// resolve function, calculates final list after all transformations,
	// returned list should be returned to pool if told to do so,
	// note that the list returned from Resolve shouldn't be passed to the user,
	// it's just a local result of all transformations applied to the list and shouldn't leave this object,
	// also, the list returned from Resolve must not be modified (because it can be the original list),
	// returned list size can be different than wantedElementsCount (it's just an optimization hint)

	internal List<T> Resolve(int wantedElementsCount, out bool returnToPool)
	{
		List<T> finalList;

		var node = this;
		bool anyOperation = false;

		do
		{
			if(node.operation != null)
			{
				anyOperation = true;
				break;
			}

			node = node.parent;
		} while(node != null);

		List<FlinqOperation<T>> operations;

		var list = precedingQueryOrList as List<T>;

		if(list != null)
		{
			if(!anyOperation)
			{
				// if we have no preceding query and no operations
				// (happens if someone converted a collection to FlinqQuery without any operation),
				// then just use the list itself

				finalList = list;
				returnToPool = false;

				// we can already return from this function, since there are no operations to be applied on the list
				// (and actually can't be, because we're using the original list)
				return finalList;
			}
			else
			{
				// first, create our operations list

				node = this;
				operations = FlinqListPool<FlinqOperation<T>>.Get();

				do
				{
					if(node.operation != null)
						operations.Add(node.operation);

					node = node.parent;
				} while(node != null);

				// create list copy on which we will be applying transformations

				finalList = FlinqListPool<T>.Get();

				if(operations.Count == 1 && wantedElementsCount < list.Count && !operations[0].RequiresFullListToWorkOn)
				{
					// if we have only 1 operation, then we don't have to work on full list
					
					for(int i = 0; i < wantedElementsCount; ++i)
					{
						finalList.Add(list[i]);
					}
				}
				else
					finalList.AddRange(list);

				returnToPool = true;
			}
		}
		else
		{
			var precedingQuery = (PrecedingQuery)precedingQueryOrList;

			int wantedElementsCount2 = wantedElementsCount;

			if(anyOperation)
				wantedElementsCount2 = int.MaxValue;

			finalList = precedingQuery(wantedElementsCount2, precedingQueryParam);
			returnToPool = true;

			if(!anyOperation)
				return finalList;

			// now, we need to create our operations list,
			// we do this here (and not at the beginning of this function) becase we want to do this before resolving preceding query,
			// this way we will use only 1 list at a time
			
			node = this;
			operations = FlinqListPool<FlinqOperation<T>>.Get();

			do
			{
				if(node.operation != null)
					operations.Add(node.operation);

				node = node.parent;
			} while(node != null);
		}

		for(int i = operations.Count - 1; i >= 0; --i)
		{
			int wantedElementsForThisOperation = (i == 0 ? wantedElementsCount : int.MaxValue);

			operations[i].Transform(finalList, wantedElementsForThisOperation);
		}

		FlinqListPool<FlinqOperation<T>>.Return(operations);

		return finalList;
	}

	// cleanup function which should be called after resolving final list,
	// no resources are leaked if this function is not called: list is just
	// not returned to the pool (it will be at the end of the frame),
	// after calling this function resolvedList must no longer be used

	internal void CleanupAfterResolve(List<T> resolvedList, bool returnToPool)
	{
		if(returnToPool)
			FlinqListPool<T>.Return(resolvedList);
	}
}

}