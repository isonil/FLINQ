using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_Aggregate
{
	public static T Aggregate<T>(this FlinqQuery<T> query, Func<T, T, T> func)
	{
		if(func == null)
			throw new ArgumentNullException("func");

		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
		{
			FlinqListPool<T>.Return(finalList);
			throw new InvalidOperationException("No elements.");
		}

		var array = finalList.array;
		T final = array[0];

		for(int i = 1; i < count; ++i)
		{
			final = func(final, array[i]);
		}

		FlinqListPool<T>.Return(finalList);

		return final;
	}

	public static TAccumulate Aggregate<T, TAccumulate>(this FlinqQuery<T> query, TAccumulate seed, Func<TAccumulate, T, TAccumulate> func)
	{
		if(func == null)
			throw new ArgumentNullException("func");

		var finalList = query.Resolve();

		TAccumulate final = seed;
		int count = finalList.count;
		var array = finalList.array;

		for(int i = 0; i < count; ++i)
		{
			final = func(final, array[i]);
		}

		FlinqListPool<T>.Return(finalList);

		return final;
	}

	public static TResult Aggregate<T, TAccumulate, TResult>(this FlinqQuery<T> query, TAccumulate seed, Func<TAccumulate, T, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
	{
		if(func == null)
			throw new ArgumentNullException("func");

		if(resultSelector == null)
			throw new ArgumentNullException("resultSelector");

		var finalList = query.Resolve();

		TAccumulate final = seed;
		int count = finalList.count;
		var array = finalList.array;

		for(int i = 0; i < count; ++i)
		{
			final = func(final, array[i]);
		}

		FlinqListPool<T>.Return(finalList);

		return resultSelector(final);
	}
}

}