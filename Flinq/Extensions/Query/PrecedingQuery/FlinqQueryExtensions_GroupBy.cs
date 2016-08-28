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

		private static FlinqList<FlinqGrouping<TKey, T>> Impl(object paramsPack)
		{
			return null;

			/*
			var paramsArray = (object[])paramsPack;
			var query = (FlinqQuery<T>)paramsArray[0];
			var keySelector = (Func<T, TKey>)paramsArray[1];

			var finalList = query.Resolve();

			int count = finalList.count;
			var array = finalList.array;

			var dict = FlinqDictionaryPool<TKey, List<T>>.Get();

			List<T> fromDict;

			for(int i = 0; i < count; ++i)
			{
				var elem = array[i];

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

			foreach(var elem in dict)
			{
				var grouping = FlinqGroupingPool<TKey, T>.Get();

				grouping.Key = elem.Key;
				grouping.OnInit(elem.Value);

				newList.Add(grouping);
			}

			FlinqDictionaryPool<TKey, List<T>>.Return(dict);
			FlinqListPool<T>.Return(finalList);

			return newList;*/
		}
	}

	public static FlinqQuery<FlinqGrouping<TKey, T>> GroupBy<T, TKey>(this FlinqQuery<T> query, Func<T, TKey> keySelector)
	{
		if(keySelector == null)
			throw new ArgumentNullException("keySelector");

		var paramsPack = FlinqObjectsArrayPool.Get2();

		paramsPack[0] = query;
		paramsPack[1] = keySelector;

		return new FlinqQuery<FlinqGrouping<TKey, T>>(ImplWrapper1<T, TKey>.impl, paramsPack);
	}

	private static class ImplWrapper2<T, TKey, TElement>
	{
		public static readonly FlinqQuery<FlinqGrouping<TKey, TElement>>.PrecedingQuery impl = Impl;

		private static FlinqList<FlinqGrouping<TKey, TElement>> Impl(object paramsPack)
		{
			return null;

			/*
			var paramsArray = (object[])paramsPack;
			var query = (FlinqQuery<T>)paramsArray[0];
			var keySelector = (Func<T, TKey>)paramsArray[1];
			var elementSelector = (Func<T, TElement>)paramsArray[2];

			var finalList = query.Resolve();

			int count = finalList.count;
			var array = finalList.array;

			var dict = FlinqDictionaryPool<TKey, FlinqList<TElement>>.Get();

			FlinqList<TElement> fromDict;

			for(int i = 0; i < count; ++i)
			{
				var elem = array[i];

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

			foreach(var elem in dict)
			{
				var grouping = FlinqGroupingPool<TKey, TElement>.Get();

				grouping.Key = elem.Key;
				grouping.OnInit(elem.Value);

				newList.Add(grouping);
			}

			FlinqDictionaryPool<TKey, FlinqList<TElement>>.Return(dict);
			FlinqListPool<T>.Return(finalList);

			return newList;*/
		}
	}
	
	public static FlinqQuery<FlinqGrouping<TKey, TElement>> GroupBy<T, TKey, TElement>(this FlinqQuery<T> query, Func<T, TKey> keySelector, Func<T, TElement> elementSelector)
	{
		if(keySelector == null)
			throw new ArgumentNullException("keySelector");

		if(elementSelector == null)
			throw new ArgumentNullException("elementSelector");

		var paramsPack = FlinqObjectsArrayPool.Get3();

		paramsPack[0] = query;
		paramsPack[1] = keySelector;
		paramsPack[2] = elementSelector;

		return new FlinqQuery<FlinqGrouping<TKey, TElement>>(ImplWrapper2<T, TKey, TElement>.impl, paramsPack);
	}

	private static class ImplWrapper3<T, TKey, TResult>
	{
		public static readonly FlinqQuery<TResult>.PrecedingQuery impl = Impl;

		private static FlinqList<TResult> Impl(object paramsPack)
		{
			return null;

			/*
			var paramsArray = (object[])paramsPack;
			var query = (FlinqQuery<T>)paramsArray[0];
			var keySelector = (Func<T, TKey>)paramsArray[1];
			var resultSelector = (Func<TKey, FlinqQuery<T>, TResult>)paramsArray[2];

			var finalList = query.Resolve();

			int count = finalList.count;
			var array = finalList.array;

			var dict = FlinqDictionaryPool<TKey, List<T>>.Get();

			List<T> fromDict;

			for(int i = 0; i < count; ++i)
			{
				var elem = array[i];

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

			foreach(var elem in dict)
			{
				var singleQuery = FlinqQueryPool<T>.Get();

				singleQuery.OnInit(elem.Value);

				newList.Add(resultSelector(elem.Key, singleQuery));
			}

			FlinqDictionaryPool<TKey, List<T>>.Return(dict);
			FlinqListPool<T>.Return(finalList);

			return newList;*/
		}
	}

	public static FlinqQuery<TResult> GroupBy<T, TKey, TResult>(this FlinqQuery<T> query, Func<T, TKey> keySelector, Func<TKey, FlinqQuery<T>, TResult> resultSelector)
	{
		if(keySelector == null)
			throw new ArgumentNullException("keySelector");

		if(resultSelector == null)
			throw new ArgumentNullException("resultSelector");

		var paramsPack = FlinqObjectsArrayPool.Get3();

		paramsPack[0] = query;
		paramsPack[1] = keySelector;
		paramsPack[2] = resultSelector;

		return new FlinqQuery<TResult>(ImplWrapper3<T, TKey, TResult>.impl, paramsPack);
	}

	private static class ImplWrapper4<T, TKey, TElement, TResult>
	{
		public static readonly FlinqQuery<TResult>.PrecedingQuery impl = Impl;

		private static FlinqList<TResult> Impl(object paramsPack)
		{
			return null;

			/*
			var paramsArray = (object[])paramsPack;
			var query = (FlinqQuery<T>)paramsArray[0];
			var keySelector = (Func<T, TKey>)paramsArray[1];
			var elementSelector = (Func<T, TElement>)paramsArray[2];
			var resultSelector = (Func<TKey, FlinqQuery<TElement>, TResult>)paramsArray[3];

			var finalList = query.Resolve();

			int count = finalList.count;
			var array = finalList.array;

			var dict = FlinqDictionaryPool<TKey, List<TElement>>.Get();

			List<TElement> fromDict;

			for(int i = 0; i < count; ++i)
			{
				var elem = array[i];

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

			foreach(var elem in dict)
			{
				var singleQuery = FlinqQueryPool<TElement>.Get();

				singleQuery.OnInit(elem.Value);

				newList.Add(resultSelector(elem.Key, singleQuery));
			}

			FlinqDictionaryPool<TKey, List<TElement>>.Return(dict);
			FlinqListPool<T>.Return(finalList);

			return newList;*/
		}
	}
	
	public static FlinqQuery<TResult> GroupBy<T, TKey, TElement, TResult>(this FlinqQuery<T> query, Func<T, TKey> keySelector, Func<T, TElement> elementSelector, Func<TKey, FlinqQuery<TElement>, TResult> resultSelector)
	{
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

		return new FlinqQuery<TResult>(ImplWrapper4<T, TKey, TElement, TResult>.impl, paramsPack);
	}
}

}