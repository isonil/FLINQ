using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqGroupingPool<TKey, T>
{
	private static List<FlinqGrouping<TKey, T>> pool = new List<FlinqGrouping<TKey, T>>();
	private static int freeIndex;

	static FlinqGroupingPool()
	{
#if !NO_FLINQ_POOLS
		FlinqPools.AddReturnAllObjectsAction(() =>
			{
				//Console.WriteLine("Pool of type: FlinqGrouping<" + typeof(T).Name + ">, Total: " + pool.Count + ", Releasing " + freeIndex);
				ReturnAllObjects();
			});

		FlinqPools.AddResetAction(Reset);
#endif
	}

	public static FlinqGrouping<TKey, T> Get()
	{
#if !NO_FLINQ_POOLS
		if(freeIndex >= pool.Count)
			pool.Add(new FlinqGrouping<TKey, T>());
		
		return pool[freeIndex++];
#else
		return new FlinqGrouping<TKey, T>();
#endif
	}

	public static void ReturnAllObjects()
	{
#if !NO_FLINQ_POOLS
		freeIndex = 0;
#endif
	}

	public static void Reset()
	{
#if !NO_FLINQ_POOLS
		pool.Clear();
		freeIndex = 0;
#endif
	}
}

}