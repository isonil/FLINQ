using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_ToDictionary
{
	public static Dictionary<TKey, T> ToDictionary<T, TKey>(this FlinqQuery<T> query, Func<T, TKey> keySelector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(keySelector == null)
			throw new ArgumentNullException("keySelector");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		// note that we don't use pool here,
		// because we return dictionary to the "world outside"
		var ret = new Dictionary<TKey, T>();

		int count = finalList.Count;

		for(int i = 0; i < count; ++i)
		{
			var elem = finalList[i];

			ret.Add(keySelector(elem), elem);
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return ret;
	}

	public static Dictionary<TKey, TElement> ToDictionary<T, TKey, TElement>(this FlinqQuery<T> query, Func<T, TKey> keySelector, Func<T, TElement> elementSelector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(keySelector == null)
			throw new ArgumentNullException("keySelector");

		if(elementSelector == null)
			throw new ArgumentNullException("elementSelector");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		// note that we don't use pool here,
		// because we return dictionary to the "world outside"
		var ret = new Dictionary<TKey, TElement>();

		int count = finalList.Count;

		for(int i = 0; i < count; ++i)
		{
			var elem = finalList[i];

			ret.Add(keySelector(elem), elementSelector(elem));
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return ret;
	}

	public static void ToDictionary<T, TKey>(this FlinqQuery<T> query, Dictionary<TKey, T> toFill, Func<T, TKey> keySelector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(toFill == null)
			throw new ArgumentNullException("toFill");

		if(keySelector == null)
			throw new ArgumentNullException("keySelector");

		toFill.Clear();

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		for(int i = 0; i < count; ++i)
		{
			var elem = finalList[i];

			toFill.Add(keySelector(elem), elem);
		}

		query.CleanupAfterResolve(finalList, returnToPool);
	}

	public static void ToDictionary<T, TKey, TElement>(this FlinqQuery<T> query, Dictionary<TKey, TElement> toFill, Func<T, TKey> keySelector, Func<T, TElement> elementSelector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(toFill == null)
			throw new ArgumentNullException("toFill");

		if(keySelector == null)
			throw new ArgumentNullException("keySelector");

		if(elementSelector == null)
			throw new ArgumentNullException("elementSelector");

		toFill.Clear();

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		for(int i = 0; i < count; ++i)
		{
			var elem = finalList[i];

			toFill.Add(keySelector(elem), elementSelector(elem));
		}

		query.CleanupAfterResolve(finalList, returnToPool);
	}
}

}