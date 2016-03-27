using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_GroupBy
{
	private static class ImplWrapper1<T, TKey>
	{
		public static readonly FlinqQuery<FlinqGrouping<TKey, T>>.PrecedingQuery impl = Impl;

		private static List<FlinqGrouping<TKey, T>> Impl(int wantedElementsCount, object paramsPack)
		{
			var paramsArray = (object[])paramsPack;
			var query = (FlinqQuery<T>)paramsArray[0];
			var keySelector = (Func<T, TKey>)paramsArray[1];

			bool returnToPool;
			var finalList = query.Resolve(int.MaxValue, out returnToPool);

			int count = finalList.Count;

			var dict = FlinqDictionaryPool<TKey, List<T>>.Get();

			List<T> fromDict;

			for(int i = 0; i < count; ++i)
			{
				var elem = finalList[i];

				var key = keySelector(elem);

				if(dict.TryGetValue(key, out fromDict))
					fromDict.Add(elem);
				else
				{
					var toAdd = FlinqListPool<T>.Get();

					toAdd.Add(elem);

					dict.Add(key, toAdd);
				}
			}

			var newList = FlinqListPool<FlinqGrouping<TKey, T>>.Get();

			int alreadyAdded = 0;

			foreach(var elem in dict)
			{
				var grouping = FlinqGroupingPool<TKey, T>.Get();

				grouping.Key = elem.Key;
				grouping.OnInit(elem.Value);

				newList.Add(grouping);

				++alreadyAdded;

				if(alreadyAdded == wantedElementsCount)
					break;
			}

			FlinqDictionaryPool<TKey, List<T>>.Return(dict);

			query.CleanupAfterResolve(finalList, returnToPool);

			return newList;
		}
	}

	public static FlinqQuery<FlinqGrouping<TKey, T>> GroupBy<T, TKey>(this FlinqQuery<T> query, Func<T, TKey> keySelector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(keySelector == null)
			throw new ArgumentNullException("keySelector");

		var paramsPack = FlinqObjectsArrayPool.Get2();

		paramsPack[0] = query;
		paramsPack[1] = keySelector;
		
		var newQuery = FlinqQueryPool<FlinqGrouping<TKey, T>>.Get();

		newQuery.OnInit(ImplWrapper1<T, TKey>.impl, paramsPack);

		return newQuery;
	}

	private static class ImplWrapper2<T, TKey, TElement>
	{
		public static readonly FlinqQuery<FlinqGrouping<TKey, TElement>>.PrecedingQuery impl = Impl;

		private static List<FlinqGrouping<TKey, TElement>> Impl(int wantedElementsCount, object paramsPack)
		{
			var paramsArray = (object[])paramsPack;
			var query = (FlinqQuery<T>)paramsArray[0];
			var keySelector = (Func<T, TKey>)paramsArray[1];
			var elementSelector = (Func<T, TElement>)paramsArray[2];

			bool returnToPool;
			var finalList = query.Resolve(int.MaxValue, out returnToPool);

			int count = finalList.Count;

			var dict = FlinqDictionaryPool<TKey, List<TElement>>.Get();

			List<TElement> fromDict;

			for(int i = 0; i < count; ++i)
			{
				var elem = finalList[i];

				var key = keySelector(elem);

				if(dict.TryGetValue(key, out fromDict))
					fromDict.Add(elementSelector(elem));
				else
				{
					var toAdd = FlinqListPool<TElement>.Get();

					toAdd.Add(elementSelector(elem));

					dict.Add(key, toAdd);
				}
			}

			var newList = FlinqListPool<FlinqGrouping<TKey, TElement>>.Get();

			int alreadyAdded = 0;

			foreach(var elem in dict)
			{
				var grouping = FlinqGroupingPool<TKey, TElement>.Get();

				grouping.Key = elem.Key;
				grouping.OnInit(elem.Value);

				newList.Add(grouping);

				++alreadyAdded;

				if(alreadyAdded == wantedElementsCount)
					break;
			}

			FlinqDictionaryPool<TKey, List<TElement>>.Return(dict);

			query.CleanupAfterResolve(finalList, returnToPool);

			return newList;
		}
	}
	
	public static FlinqQuery<FlinqGrouping<TKey, TElement>> GroupBy<T, TKey, TElement>(this FlinqQuery<T> query, Func<T, TKey> keySelector, Func<T, TElement> elementSelector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(keySelector == null)
			throw new ArgumentNullException("keySelector");

		if(elementSelector == null)
			throw new ArgumentNullException("elementSelector");

		var paramsPack = FlinqObjectsArrayPool.Get3();

		paramsPack[0] = query;
		paramsPack[1] = keySelector;
		paramsPack[2] = elementSelector;

		var newQuery = FlinqQueryPool<FlinqGrouping<TKey, TElement>>.Get();

		newQuery.OnInit(ImplWrapper2<T, TKey, TElement>.impl, paramsPack);

		return newQuery;
	}

	private static class ImplWrapper3<T, TKey, TResult>
	{
		public static readonly FlinqQuery<TResult>.PrecedingQuery impl = Impl;

		private static List<TResult> Impl(int wantedElementsCount, object paramsPack)
		{
			var paramsArray = (object[])paramsPack;
			var query = (FlinqQuery<T>)paramsArray[0];
			var keySelector = (Func<T, TKey>)paramsArray[1];
			var resultSelector = (Func<TKey, FlinqQuery<T>, TResult>)paramsArray[2];

			bool returnToPool;
			var finalList = query.Resolve(int.MaxValue, out returnToPool);

			int count = finalList.Count;

			var dict = FlinqDictionaryPool<TKey, List<T>>.Get();

			List<T> fromDict;

			for(int i = 0; i < count; ++i)
			{
				var elem = finalList[i];

				var key = keySelector(elem);

				if(dict.TryGetValue(key, out fromDict))
					fromDict.Add(elem);
				else
				{
					var toAdd = FlinqListPool<T>.Get();

					toAdd.Add(elem);

					dict.Add(key, toAdd);
				}
			}

			var newList = FlinqListPool<TResult>.Get();

			int alreadyAdded = 0;

			foreach(var elem in dict)
			{
				var singleQuery = FlinqQueryPool<T>.Get();

				singleQuery.OnInit(elem.Value);

				newList.Add(resultSelector(elem.Key, singleQuery));

				++alreadyAdded;

				if(alreadyAdded == wantedElementsCount)
					break;
			}

			FlinqDictionaryPool<TKey, List<T>>.Return(dict);

			query.CleanupAfterResolve(finalList, returnToPool);

			return newList;
		}
	}

	public static FlinqQuery<TResult> GroupBy<T, TKey, TResult>(this FlinqQuery<T> query, Func<T, TKey> keySelector, Func<TKey, FlinqQuery<T>, TResult> resultSelector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(keySelector == null)
			throw new ArgumentNullException("keySelector");

		if(resultSelector == null)
			throw new ArgumentNullException("resultSelector");

		var paramsPack = FlinqObjectsArrayPool.Get3();

		paramsPack[0] = query;
		paramsPack[1] = keySelector;
		paramsPack[2] = resultSelector;

		var newQuery = FlinqQueryPool<TResult>.Get();

		newQuery.OnInit(ImplWrapper3<T, TKey, TResult>.impl, paramsPack);

		return newQuery;
	}

	private static class ImplWrapper4<T, TKey, TElement, TResult>
	{
		public static readonly FlinqQuery<TResult>.PrecedingQuery impl = Impl;

		private static List<TResult> Impl(int wantedElementsCount, object paramsPack)
		{
			var paramsArray = (object[])paramsPack;
			var query = (FlinqQuery<T>)paramsArray[0];
			var keySelector = (Func<T, TKey>)paramsArray[1];
			var elementSelector = (Func<T, TElement>)paramsArray[2];
			var resultSelector = (Func<TKey, FlinqQuery<TElement>, TResult>)paramsArray[3];

			bool returnToPool;
			var finalList = query.Resolve(int.MaxValue, out returnToPool);

			int count = finalList.Count;

			var dict = FlinqDictionaryPool<TKey, List<TElement>>.Get();

			List<TElement> fromDict;

			for(int i = 0; i < count; ++i)
			{
				var elem = finalList[i];

				var key = keySelector(elem);

				if(dict.TryGetValue(key, out fromDict))
					fromDict.Add(elementSelector(elem));
				else
				{
					var toAdd = FlinqListPool<TElement>.Get();

					toAdd.Add(elementSelector(elem));

					dict.Add(key, toAdd);
				}
			}

			var newList = FlinqListPool<TResult>.Get();

			int alreadyAdded = 0;

			foreach(var elem in dict)
			{
				var singleQuery = FlinqQueryPool<TElement>.Get();

				singleQuery.OnInit(elem.Value);

				newList.Add(resultSelector(elem.Key, singleQuery));

				++alreadyAdded;

				if(alreadyAdded == wantedElementsCount)
					break;
			}

			FlinqDictionaryPool<TKey, List<TElement>>.Return(dict);

			query.CleanupAfterResolve(finalList, returnToPool);

			return newList;
		}
	}
	
	public static FlinqQuery<TResult> GroupBy<T, TKey, TElement, TResult>(this FlinqQuery<T> query, Func<T, TKey> keySelector, Func<T, TElement> elementSelector, Func<TKey, FlinqQuery<TElement>, TResult> resultSelector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(keySelector == null)
			throw new ArgumentNullException("keySelector");

		if(elementSelector == null)
			throw new ArgumentNullException("elementSelector");

		if(resultSelector == null)
			throw new ArgumentNullException("resultSelector");

		var paramsPack = FlinqObjectsArrayPool.Get4();

		paramsPack[0] = query;
		paramsPack[1] = keySelector;
		paramsPack[2] = elementSelector;
		paramsPack[3] = resultSelector;

		var newQuery = FlinqQueryPool<TResult>.Get();

		newQuery.OnInit(ImplWrapper4<T, TKey, TElement, TResult>.impl, paramsPack);

		return newQuery;
	}
}

}