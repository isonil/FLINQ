using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqListPool<T>
{
	private static FlinqList<FlinqList<T>> pool = new FlinqList<FlinqList<T>>();
	private static int freeIndex;
	private static int maxFreeIndexThisFrame;

	private const int MaxListCapacity = 1024;

	static FlinqListPool()
	{
#if !NO_FLINQ_POOLS
		FlinqPools.AddReturnAllObjectsAction(() =>
			{
				//Console.WriteLine("Pool of type: FlinqList<" + typeof(T).Name + ">, Total: " + pool.Count + ", Releasing " + freeIndex);
				ReturnAllObjects();
			});

		FlinqPools.AddResetAction(Reset);
#endif
	}

	public static FlinqList<T> Get()
	{
#if !NO_FLINQ_POOLS
		if(freeIndex >= pool.count)
			pool.Add(new FlinqList<T>());

		int index = freeIndex++;

		if(freeIndex > maxFreeIndexThisFrame)
			maxFreeIndexThisFrame = freeIndex;

		var ret = pool.array[index];

		if(ret.count != 0)
		{
			ret.Clear();
			throw new InvalidOperationException("FlinqList from pool has been used after being returned.");
		}

		return ret;
#else
		return new List<T>();
#endif
	}

	public static void Return(FlinqList<T> list)
	{
#if !NO_FLINQ_POOLS
		var poolArray = pool.array;

		for(int i = freeIndex - 1; i >= 0; --i)
		{
			var elem = poolArray[i];

			if(elem == list)
			{
				elem.Clear();

				if(i != freeIndex - 1)
				{
					poolArray[i] = poolArray[freeIndex - 1];
					poolArray[freeIndex - 1] = elem;
				}

				--freeIndex;

				return;
			}
		}

		throw new InvalidOperationException("Could not return element of type FlinqList<" + typeof(T).Name + ">, because it's not here.");
#endif
	}

	public static void ReturnAllObjects()
	{
#if !NO_FLINQ_POOLS
		int count = pool.count;
		var poolArray = pool.array;

		for(int i = 0; i < maxFreeIndexThisFrame; )
		{
			var elem = poolArray[i];

			if(elem.Capacity > MaxListCapacity)
			{
				poolArray[i] = poolArray[count - 1];
				poolArray[count - 1] = elem;

				pool.RemoveAt(count - 1);
				poolArray = pool.array; // could change

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