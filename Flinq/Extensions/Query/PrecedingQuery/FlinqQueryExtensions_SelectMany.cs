using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_SelectMany
{
	private static class ImplWrapper1<T, TResult>
	{
		public static readonly FlinqQuery<TResult>.PrecedingQuery impl = Impl;

		private static List<TResult> Impl(object paramsPack)
		{
			var paramsArray = (object[])paramsPack;
			var query = (FlinqQuery<T>)paramsArray[0];
			var selector = (Func<T, FlinqQuery<TResult>>)paramsArray[1];

			var finalList = query.Resolve();

			var newList = FlinqListPool<TResult>.Get();

			int count = finalList.Count;

			for(int i = 0; i < count; ++i)
			{
				var elemQuery = selector(finalList[i]);
				
				var elemFinalList = elemQuery.Resolve();

				newList.AddRange(elemFinalList);

				FlinqListPool<TResult>.Return(elemFinalList);
			}

			FlinqListPool<T>.Return(finalList);

			return newList;
		}
	}

	public static FlinqQuery<TResult> SelectMany<T, TResult>(this FlinqQuery<T> query, Func<T, FlinqQuery<TResult>> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		var paramsPack = FlinqObjectsArrayPool.Get2();

		paramsPack[0] = query;
		paramsPack[1] = selector;

		var newQuery = FlinqQueryPool<TResult>.Get();

		newQuery.OnInit(ImplWrapper1<T, TResult>.impl, paramsPack);

		return newQuery;
	}

	private static class ImplWrapper2<T, TResult>
	{
		public static readonly FlinqQuery<TResult>.PrecedingQuery impl = Impl;

		private static List<TResult> Impl(object paramsPack)
		{
			var paramsArray = (object[])paramsPack;
			var query = (FlinqQuery<T>)paramsArray[0];
			var selector = (Func<T, int, FlinqQuery<TResult>>)paramsArray[1];

			var finalList = query.Resolve();

			var newList = FlinqListPool<TResult>.Get();

			int count = finalList.Count;

			for(int i = 0; i < count; ++i)
			{
				var elemQuery = selector(finalList[i], i);
				
				var elemFinalList = elemQuery.Resolve();

				newList.AddRange(elemFinalList);

				FlinqListPool<TResult>.Return(elemFinalList);
			}

			FlinqListPool<T>.Return(finalList);

			return newList;
		}
	}

	public static FlinqQuery<TResult> SelectMany<T, TResult>(this FlinqQuery<T> query, Func<T, int, FlinqQuery<TResult>> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		var paramsPack = FlinqObjectsArrayPool.Get2();

		paramsPack[0] = query;
		paramsPack[1] = selector;

		var newQuery = FlinqQueryPool<TResult>.Get();

		newQuery.OnInit(ImplWrapper2<T, TResult>.impl, paramsPack);

		return newQuery;
	}

	private static class ImplWrapper3<T, TCollection, TResult>
	{
		public static readonly FlinqQuery<TResult>.PrecedingQuery impl = Impl;

		private static List<TResult> Impl(object paramsPack)
		{
			var paramsArray = (object[])paramsPack;
			var query = (FlinqQuery<T>)paramsArray[0];
			var collectionSelector = (Func<T, FlinqQuery<TCollection>>)paramsArray[1];
			var resultSelector = (Func<T, TCollection, TResult>)paramsArray[2];

			var finalList = query.Resolve();

			var newList = FlinqListPool<TResult>.Get();

			int count = finalList.Count;

			for(int i = 0; i < count; ++i)
			{
				var elem = finalList[i];
				var elemQuery = collectionSelector(elem);
				
				var elemFinalList = elemQuery.Resolve();

				int elemFinalListCount = elemFinalList.Count;

				for(int j = 0; j < elemFinalListCount; ++j)
				{
					newList.Add(resultSelector(elem, elemFinalList[j]));
				}

				FlinqListPool<TCollection>.Return(elemFinalList);
			}

			FlinqListPool<T>.Return(finalList);

			return newList;
		}
	}

	public static FlinqQuery<TResult> SelectMany<T, TCollection, TResult>(this FlinqQuery<T> query, Func<T, FlinqQuery<TCollection>> collectionSelector, Func<T, TCollection, TResult> resultSelector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(collectionSelector == null)
			throw new ArgumentNullException("collectionSelector");

		if(resultSelector == null)
			throw new ArgumentNullException("resultSelector");

		var paramsPack = FlinqObjectsArrayPool.Get3();

		paramsPack[0] = query;
		paramsPack[1] = collectionSelector;
		paramsPack[2] = resultSelector;

		var newQuery = FlinqQueryPool<TResult>.Get();

		newQuery.OnInit(ImplWrapper3<T, TCollection, TResult>.impl, paramsPack);

		return newQuery;
	}

	private static class ImplWrapper4<T, TCollection, TResult>
	{
		public static readonly FlinqQuery<TResult>.PrecedingQuery impl = Impl;

		private static List<TResult> Impl(object paramsPack)
		{
			var paramsArray = (object[])paramsPack;
			var query = (FlinqQuery<T>)paramsArray[0];
			var collectionSelector = (Func<T, int, FlinqQuery<TCollection>>)paramsArray[1];
			var resultSelector = (Func<T, TCollection, TResult>)paramsArray[2];

			var finalList = query.Resolve();

			var newList = FlinqListPool<TResult>.Get();

			int count = finalList.Count;

			for(int i = 0; i < count; ++i)
			{
				var elem = finalList[i];
				var elemQuery = collectionSelector(elem, i);
				
				var elemFinalList = elemQuery.Resolve();

				int elemFinalListCount = elemFinalList.Count;

				for(int j = 0; j < elemFinalListCount; ++j)
				{
					newList.Add(resultSelector(elem, elemFinalList[j]));
				}

				FlinqListPool<TCollection>.Return(elemFinalList);
			}

			FlinqListPool<T>.Return(finalList);

			return newList;
		}
	}
	
	public static FlinqQuery<TResult> SelectMany<T, TCollection, TResult>(this FlinqQuery<T> query, Func<T, int, FlinqQuery<TCollection>> collectionSelector, Func<T, TCollection, TResult> resultSelector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(collectionSelector == null)
			throw new ArgumentNullException("collectionSelector");

		if(resultSelector == null)
			throw new ArgumentNullException("resultSelector");

		var paramsPack = FlinqObjectsArrayPool.Get3();

		paramsPack[0] = query;
		paramsPack[1] = collectionSelector;
		paramsPack[2] = resultSelector;

		var newQuery = FlinqQueryPool<TResult>.Get();

		newQuery.OnInit(ImplWrapper4<T, TCollection, TResult>.impl, paramsPack);

		return newQuery;
	}
}

}