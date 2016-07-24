using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqListPool<T>
{
	private static List<List<T>> pool = new List<List<T>>();
	private static int freeIndex;
	private static int maxFreeIndexThisFrame;

	private const int MaxListCapacity = 1024;

	static FlinqListPool()
	{
#if !NO_FLINQ_POOLS
		FlinqPools.AddReturnAllObjectsAction(() =>
			{
				//Console.WriteLine("Pool of type: List<" + typeof(T).Name + ">, Total: " + pool.Count + ", Releasing " + freeIndex);
				ReturnAllObjects();
			});

		FlinqPools.AddResetAction(Reset);
#endif
	}

	public static List<T> Get()
	{
#if !NO_FLINQ_POOLS
		if(freeIndex >= pool.Count)
			pool.Add(new List<T>());

		int index = freeIndex++;

		if(freeIndex > maxFreeIndexThisFrame)
			maxFreeIndexThisFrame = freeIndex;

		var ret = pool[index];

		if(ret.Count != 0)
		{
			ret.Clear();
			throw new InvalidOperationException("List from pool has been used after being returned.");
		}

		return ret;
#else
		return new List<T>();
#endif
	}

	public static void Return(List<T> list)
	{
#if !NO_FLINQ_POOLS
		for(int i = freeIndex - 1; i >= 0; --i)
		{
			var elem = pool[i];

			if(elem == list)
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

		throw new InvalidOperationException("Could not return element of type List<" + typeof(T).Name + ">, because it's not here.");
#endif
	}

	public static void ReturnAllObjects()
	{
#if !NO_FLINQ_POOLS
		int count = pool.Count;

		for(int i = 0; i < maxFreeIndexThisFrame; )
		{
			var elem = pool[i];

			if(elem.Capacity > MaxListCapacity)
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