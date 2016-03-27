using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_Aggregate
{
	public static T Aggregate<T>(this FlinqQuery<T> query, Func<T, T, T> func)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(func == null)
			throw new ArgumentNullException("func");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		if(finalList.Count == 0)
			throw new InvalidOperationException("No elements.");

		T final = finalList[0];
		int count = finalList.Count;

		for(int i = 1; i < count; ++i)
		{
			final = func(final, finalList[i]);
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return final;
	}

	public static TAccumulate Aggregate<T, TAccumulate>(this FlinqQuery<T> query, TAccumulate seed, Func<TAccumulate, T, TAccumulate> func)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(func == null)
			throw new ArgumentNullException("func");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		TAccumulate final = seed;
		int count = finalList.Count;

		for(int i = 0; i < count; ++i)
		{
			final = func(final, finalList[i]);
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return final;
	}

	public static TResult Aggregate<T, TAccumulate, TResult>(this FlinqQuery<T> query, TAccumulate seed, Func<TAccumulate, T, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(func == null)
			throw new ArgumentNullException("func");

		if(resultSelector == null)
			throw new ArgumentNullException("resultSelector");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		TAccumulate final = seed;
		int count = finalList.Count;

		for(int i = 0; i < count; ++i)
		{
			final = func(final, finalList[i]);
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return resultSelector(final);
	}
}

}