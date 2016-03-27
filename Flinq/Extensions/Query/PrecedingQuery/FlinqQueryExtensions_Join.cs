using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_Join
{
	private static class ImplWrapper<TOuter, TInner, TKey, TResult>
	{
		public static readonly FlinqQuery<TResult>.PrecedingQuery impl = Impl;

		private static List<TResult> Impl(int wantedElementsCount, object paramsPack)
		{
			var paramsArray = (object[])paramsPack;
			var query = (FlinqQuery<TOuter>)paramsArray[0];
			var inner = (FlinqQuery<TInner>)paramsArray[1];
			var outerKeySelector = (Func<TOuter, TKey>)paramsArray[2];
			var innerKeySelector = (Func<TInner, TKey>)paramsArray[3];
			var resultSelector = (Func<TOuter, TInner, TResult>)paramsArray[4];

			bool returnToPool;
			var finalList = query.Resolve(int.MaxValue, out returnToPool);

			var dict = FlinqDictionaryPool<TKey, List<int>>.Get();

			int count = Math.Min(finalList.Count, wantedElementsCount);

			List<int> list;

			for(int i = 0; i < count; ++i)
			{
				var key = outerKeySelector(finalList[i]);

				if(dict.TryGetValue(key, out list))
					list.Add(i);
				else
				{
					list = FlinqListPool<int>.Get();
					list.Add(i);
					dict.Add(key, list);
				}
			}

			var matching = FlinqListPool<List<TInner>>.Get();

			for(int i = 0; i < count; ++i)
			{
				var emptyList = FlinqListPool<TInner>.Get();
				matching.Add(emptyList);
			}

			bool innerReturnToPool;
			var innerFinalList = inner.Resolve(int.MaxValue, out innerReturnToPool);

			count = innerFinalList.Count;

			for(int i = 0; i < count; ++i)
			{
				var innerElem = innerFinalList[i];
				var key = innerKeySelector(innerElem);

				if(dict.TryGetValue(key, out list))
				{
					int count2 = list.Count;

					for(int j = 0; j < count2; ++j)
					{
						matching[list[j]].Add(innerElem);
					}
				}
			}

			var newList = FlinqListPool<TResult>.Get();

			count = matching.Count;

			for(int i = 0; i < count; ++i)
			{
				var outerElem = finalList[i];
				var singleMatching = matching[i];

				int matchingCount = singleMatching.Count;

				for(int j = 0; j < matchingCount; ++j)
				{
					newList.Add(resultSelector(outerElem, singleMatching[j]));
				}

				FlinqListPool<TInner>.Return(singleMatching);
			}

			FlinqListPool<List<TInner>>.Return(matching);

			foreach(var elem in dict)
			{
				FlinqListPool<int>.Return(elem.Value);
			}

			FlinqDictionaryPool<TKey, List<int>>.Return(dict);

			query.CleanupAfterResolve(finalList, returnToPool);
			inner.CleanupAfterResolve(innerFinalList, innerReturnToPool);

			return newList;
		}
	}

	public static FlinqQuery<TResult> Join<TOuter, TInner, TKey, TResult>(this FlinqQuery<TOuter> query, FlinqQuery<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(inner == null)
			throw new ArgumentNullException("inner");

		if(outerKeySelector == null)
			throw new ArgumentNullException("outerKeySelector");

		if(innerKeySelector == null)
			throw new ArgumentNullException("innerKeySelector");

		if(resultSelector == null)
			throw new ArgumentNullException("resultSelector");

		var paramsPack = FlinqObjectsArrayPool.Get5();

		paramsPack[0] = query;
		paramsPack[1] = inner;
		paramsPack[2] = outerKeySelector;
		paramsPack[3] = innerKeySelector;
		paramsPack[4] = resultSelector;

		var newQuery = FlinqQueryPool<TResult>.Get();

		newQuery.OnInit(ImplWrapper<TOuter, TInner, TKey, TResult>.impl, paramsPack);

		return newQuery;
	}
}

}