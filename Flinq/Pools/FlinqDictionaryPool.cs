using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqDictionaryPool<TKey, TElement>
{
	private static List<Dictionary<TKey, TElement>> pool = new List<Dictionary<TKey, TElement>>();
	private static int freeIndex;

	static FlinqDictionaryPool()
	{
#if !NO_FLINQ_POOLS
		FlinqPools.AddReturnAllObjectsAction(() =>
			{
				//Console.WriteLine("Pool of type: Dictionary<" + typeof(T).Name + ">, Total: " + pool.Count + ", Releasing " + freeIndex);
				ReturnAllObjects();
			});

		FlinqPools.AddResetAction(Reset);
#endif
	}

	public static Dictionary<TKey, TElement> Get()
	{
#if !NO_FLINQ_POOLS
		if(freeIndex >= pool.Count)
			pool.Add(new Dictionary<TKey, TElement>());

		int index = freeIndex++;
		var ret = pool[index];

		if(ret.Count != 0)
		{
			ret.Clear();
			throw new InvalidOperationException("Dictionary from pool has been used after being returned.");
		}

		return ret;
#else
		return new Dictionary<TKey, TElement>();
#endif
	}

	public static void Return(Dictionary<TKey, TElement> dict)
	{
#if !NO_FLINQ_POOLS
		for(int i = freeIndex - 1; i >= 0; --i)
		{
			var elem = pool[i];

			if(elem == dict)
			{
				elem.Clear();

				pool[i] = pool[freeIndex - 1];
				pool[freeIndex - 1] = elem;

				--freeIndex;

				return;
			}
		}

		throw new InvalidOperationException("Could not return element of type Dictionary<" + typeof(TKey).Name + ", " + typeof(TElement).Name + ">, because it's not here.");
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