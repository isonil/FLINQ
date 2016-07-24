using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqHashSetPool<T>
{
	private static List<HashSet<T>> pool = new List<HashSet<T>>();
	private static int freeIndex;

	static FlinqHashSetPool()
	{
#if !NO_FLINQ_POOLS
		FlinqPools.AddReturnAllObjectsAction(() =>
			{
				//Console.WriteLine("Pool of type: HashSet<" + typeof(T).Name + ">, Total: " + pool.Count + ", Releasing " + freeIndex);
				ReturnAllObjects();
			});

		FlinqPools.AddResetAction(Reset);
#endif
	}

	public static HashSet<T> Get()
	{
#if !NO_FLINQ_POOLS
		if(freeIndex >= pool.Count)
			pool.Add(new HashSet<T>());

		int index = freeIndex++;
		var ret = pool[index];

		if(ret.Count != 0)
		{
			ret.Clear();
			throw new InvalidOperationException("Hash set from pool has been used after being returned.");
		}

		return ret;
#else
		return new HashSet<T>();
#endif
	}

	public static void Return(HashSet<T> hashSet)
	{
#if !NO_FLINQ_POOLS
		for(int i = freeIndex - 1; i >= 0; --i)
		{
			var elem = pool[i];

			if(elem == hashSet)
			{
				elem.Clear();

				if(i != freeIndex - 1)
				{
					pool[i] = pool[freeIndex - 1];
					pool[freeIndex - 1] = elem;
				}

				--freeIndex;

				return;
			}
		}

		throw new InvalidOperationException("Could not return element of type HashSet<" + typeof(T).Name + ">, because it's not here.");
#endif
	}

	public static void ReturnAllObjects()
	{
#if !NO_FLINQ_POOLS
		for(int i = 0; i < freeIndex; ++i)
		{
			pool[i].Clear();
		}

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