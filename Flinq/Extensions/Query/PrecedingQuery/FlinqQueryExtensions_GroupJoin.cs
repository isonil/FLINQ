using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_GroupJoin
{
	private static class ImplWrapper<TOuter, TInner, TKey, TResult>
	{
		public static readonly FlinqQuery<TResult>.PrecedingQuery impl = Impl;

		private static FlinqList<TResult> Impl(object paramsPack)
		{
			return null;

			/*
			var paramsArray = (object[])paramsPack;
			var query = (FlinqQuery<TOuter>)paramsArray[0];
			var inner = (FlinqQuery<TInner>)paramsArray[1];
			var outerKeySelector = (Func<TOuter, TKey>)paramsArray[2];
			var innerKeySelector = (Func<TInner, TKey>)paramsArray[3];
			var resultSelector = (Func<TOuter, FlinqQuery<TInner>, TResult>)paramsArray[4];

			var finalList = query.Resolve();

			var dict = FlinqDictionaryPool<TKey, List<int>>.Get();

			int count = finalList.Count;

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

			var innerFinalList = inner.Resolve();

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
				newList.Add(resultSelector(finalList[i], matching[i].AsFlinqQuery()));
			}

			// unfortunately we can't return all Lists<TInner>, because result selector could potentially
			// store our new Flinq queries somewhere, so lists must be still alive

			FlinqListPool<List<TInner>>.Return(matching);

			foreach(var elem in dict)
			{
				FlinqListPool<int>.Return(elem.Value);
			}

			FlinqDictionaryPool<TKey, List<int>>.Return(dict);

			FlinqListPool<TOuter>.Return(finalList);
			FlinqListPool<TInner>.Return(innerFinalList);

			return newList;*/
		}
	}

	public static FlinqQuery<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this FlinqQuery<TOuter> query, FlinqQuery<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, FlinqQuery<TInner>, TResult> resultSelector)
	{
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

		return new FlinqQuery<TResult>(ImplWrapper<TOuter, TInner, TKey, TResult>.impl, paramsPack);
	}
}

}