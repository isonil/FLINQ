using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqStringBuilderPool
{
	private static List<StringBuilder> pool = new List<StringBuilder>();
	private static int freeIndex;
	private static int maxFreeIndexThisFrame;

	private const int MaxStringBuilderCapacity = 8192;

	static FlinqStringBuilderPool()
	{
#if !NO_FLINQ_POOLS
		FlinqPools.AddReturnAllObjectsAction(() =>
			{
				//Console.WriteLine("Pool of type: StringBuilder, Total: " + pool.Count + ", Releasing " + freeIndex);
				ReturnAllObjects();
			});

		FlinqPools.AddResetAction(Reset);
#endif
	}

	public static StringBuilder Get()
	{
#if !NO_FLINQ_POOLS
		if(freeIndex >= pool.Count)
			pool.Add(new StringBuilder());

		int index = freeIndex++;

		if(freeIndex > maxFreeIndexThisFrame)
			maxFreeIndexThisFrame = freeIndex;

		var ret = pool[index];

		if(ret.Length != 0)
		{
			ret.Length = 0;
			throw new InvalidOperationException("String builder from pool has been used after being returned.");
		}

		return ret;
#else
		return new StringBuilder();
#endif
	}

	public static void Return(StringBuilder builder)
	{
#if !NO_FLINQ_POOLS
		for(int i = freeIndex - 1; i >= 0; --i)
		{
			var elem = pool[i];

			if(elem == builder)
			{
				elem.Length = 0;

				if(i != freeIndex - 1)
				{
					pool[i] = pool[freeIndex - 1];
					pool[freeIndex - 1] = elem;
				}

				--freeIndex;

				return;
			}
		}

		throw new InvalidOperationException("Could not return element of type StringBuilder, because it's not here.");
#endif
	}

	public static void ReturnAllObjects()
	{
#if !NO_FLINQ_POOLS
		int count = pool.Count;

		for(int i = 0; i < maxFreeIndexThisFrame; )
		{
			var elem = pool[i];

			if(elem.Capacity > MaxStringBuilderCapacity)
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
				elem.Length = 0;
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