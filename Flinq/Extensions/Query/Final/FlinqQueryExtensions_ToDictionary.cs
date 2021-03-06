﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_ToDictionary
{
	public static Dictionary<TKey, T> ToDictionary<T, TKey>(this FlinqQuery<T> query, Func<T, TKey> keySelector)
	{
		if(keySelector == null)
			throw new ArgumentNullException("keySelector");

		var finalList = query.Resolve();

		// note that we don't use pool here,
		// because we return dictionary to the "world outside"
		var ret = new Dictionary<TKey, T>();

		int count = finalList.count;
		var array = finalList.array;

		for(int i = 0; i < count; ++i)
		{
			var elem = array[i];

			ret.Add(keySelector(elem), elem);
		}

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static Dictionary<TKey, TElement> ToDictionary<T, TKey, TElement>(this FlinqQuery<T> query, Func<T, TKey> keySelector, Func<T, TElement> elementSelector)
	{
		if(keySelector == null)
			throw new ArgumentNullException("keySelector");

		if(elementSelector == null)
			throw new ArgumentNullException("elementSelector");

		var finalList = query.Resolve();

		// note that we don't use pool here,
		// because we return dictionary to the "world outside"
		var ret = new Dictionary<TKey, TElement>();

		int count = finalList.count;
		var array = finalList.array;

		for(int i = 0; i < count; ++i)
		{
			var elem = array[i];

			ret.Add(keySelector(elem), elementSelector(elem));
		}

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static void ToDictionary<T, TKey>(this FlinqQuery<T> query, Dictionary<TKey, T> toFill, Func<T, TKey> keySelector)
	{
		if(toFill == null)
			throw new ArgumentNullException("toFill");

		if(keySelector == null)
			throw new ArgumentNullException("keySelector");

		toFill.Clear();

		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		for(int i = 0; i < count; ++i)
		{
			var elem = array[i];

			toFill.Add(keySelector(elem), elem);
		}

		FlinqListPool<T>.Return(finalList);
	}

	public static void ToDictionary<T, TKey, TElement>(this FlinqQuery<T> query, Dictionary<TKey, TElement> toFill, Func<T, TKey> keySelector, Func<T, TElement> elementSelector)
	{
		if(toFill == null)
			throw new ArgumentNullException("toFill");

		if(keySelector == null)
			throw new ArgumentNullException("keySelector");

		if(elementSelector == null)
			throw new ArgumentNullException("elementSelector");

		toFill.Clear();

		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		for(int i = 0; i < count; ++i)
		{
			var elem = array[i];

			toFill.Add(keySelector(elem), elementSelector(elem));
		}

		FlinqListPool<T>.Return(finalList);
	}
}

}