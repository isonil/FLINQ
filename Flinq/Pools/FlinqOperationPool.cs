using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqOperationPool<T> where T : new()
{
	private static List<T> pool = new List<T>();
	private static int freeIndex;

	static FlinqOperationPool()
	{
#if !NO_FLINQ_POOLS
		FlinqPools.AddReturnAllObjectsAction(() =>
			{
				//Console.WriteLine("Pool of type: " + typeof(T).Name + ", Total: " + pool.Count + ", Releasing " + freeIndex);
				ReturnAllObjects();
			});

		FlinqPools.AddResetAction(Reset);
#endif
	}

	public static T Get()
	{
#if !NO_FLINQ_POOLS
		if(freeIndex >= pool.Count)
			pool.Add(new T());

		return pool[freeIndex++];
#else
		return new T();
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