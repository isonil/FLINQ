using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryPool<T>
{
	private static List<FlinqQuery<T>> pool = new List<FlinqQuery<T>>();
	private static int freeIndex;

	static FlinqQueryPool()
	{
#if !NO_FLINQ_POOLS
		FlinqPools.AddReturnAllObjectsAction(() =>
			{
				//Console.WriteLine("Pool of type: FlinqQuery<" + typeof(T).Name + ">, Total: " + pool.Count + ", Releasing " + freeIndex);
				ReturnAllObjects();
			});

		FlinqPools.AddResetAction(Reset);
#endif
	}

	public static FlinqQuery<T> Get()
	{
#if !NO_FLINQ_POOLS
		if(freeIndex >= pool.Count)
			pool.Add(new FlinqQuery<T>());

		return pool[freeIndex++];
#else
		return new FlinqQuery<T>();
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