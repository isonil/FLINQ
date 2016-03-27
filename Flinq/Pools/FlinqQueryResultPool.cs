using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryResultPool<T>
{
	private static List<FlinqQueryResult<T>> pool = new List<FlinqQueryResult<T>>();
	private static int freeIndex;
	private static int maxFreeIndexThisFrame;

	private const int MaxQueryResultCapacity = 1024;

	static FlinqQueryResultPool()
	{
#if !NO_FLINQ_POOLS
		FlinqPools.AddReturnAllObjectsAction(() =>
			{
				//Console.WriteLine("Pool of type: FlinqQueryResult<" + typeof(T).Name + ">, Total: " + pool.Count + ", Releasing " + freeIndex);
				ReturnAllObjects();
			});

		FlinqPools.AddResetAction(Reset);
#endif
	}

	public static FlinqQueryResult<T> Get()
	{
#if !NO_FLINQ_POOLS
		if(freeIndex >= pool.Count)
			pool.Add(new FlinqQueryResult<T>());

		int index = freeIndex++;

		if(freeIndex > maxFreeIndexThisFrame)
			maxFreeIndexThisFrame = freeIndex;

		var ret = pool[index];

		if(ret.Count != 0)
		{
			ret.Clear();
			throw new InvalidOperationException("Query result from pool has been used after being returned.");
		}

		return ret;
#else
		return new FlinqQueryResult<T>();
#endif
	}

	public static void Return(FlinqQueryResult<T> queryResult)
	{
#if !NO_FLINQ_POOLS
		for(int i = freeIndex - 1; i >= 0; --i)
		{
			var elem = pool[i];

			if(elem == queryResult)
			{
				elem.Clear();

				pool[i] = pool[freeIndex - 1];
				pool[freeIndex - 1] = elem;

				--freeIndex;

				return;
			}
		}

		throw new InvalidOperationException("Could not return element of type FlinqQueryResult<" + typeof(T).Name + ">, because it's not here.");
#endif
	}

	public static void ReturnAllObjects()
	{
#if !NO_FLINQ_POOLS
		int count = pool.Count;

		for(int i = 0; i < maxFreeIndexThisFrame; )
		{
			var elem = pool[i];

			if(elem.Capacity > MaxQueryResultCapacity)
			{
				pool[i] = pool[count - 1];
				pool[count - 1] = elem;

				pool.RemoveAt(count - 1);

				--count;

				if(maxFreeIndexThisFrame > count)
					maxFreeIndexThisFrame = count;
			}
			else
			{
				elem.Clear();
				++i;
			}
		}

		freeIndex = 0;
		maxFreeIndexThisFrame = 0;
#endif
	}

	public static void Reset()
	{
#if !NO_FLINQ_POOLS
		pool.Clear();
		freeIndex = 0;
		maxFreeIndexThisFrame = 0;
#endif
	}
}

}