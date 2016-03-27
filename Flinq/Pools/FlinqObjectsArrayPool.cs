using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqObjectsArrayPool
{
	private static List<object[]> pool2 = new List<object[]>();
	private static List<object[]> pool3 = new List<object[]>();
	private static List<object[]> pool4 = new List<object[]>();
	private static List<object[]> pool5 = new List<object[]>();
	private static int freeIndex2, freeIndex3, freeIndex4, freeIndex5;

	static FlinqObjectsArrayPool()
	{
#if !NO_FLINQ_POOLS
		FlinqPools.AddReturnAllObjectsAction(() =>
			{
				//Console.WriteLine("ObjectsArrayPool");
				ReturnAllObjects();
			});

		FlinqPools.AddResetAction(Reset);
#endif
	}

	public static object[] Get2()
	{
#if !NO_FLINQ_POOLS
		if(freeIndex2 >= pool2.Count)
			pool2.Add(new object[2]);

		return pool2[freeIndex2++];
#else
		return new object[2];
#endif
	}
	
	public static object[] Get3()
	{
#if !NO_FLINQ_POOLS
		if(freeIndex3 >= pool3.Count)
			pool3.Add(new object[3]);

		return pool3[freeIndex3++];
#else
		return new object[3];
#endif
	}
	
	public static object[] Get4()
	{
#if !NO_FLINQ_POOLS
		if(freeIndex4 >= pool4.Count)
			pool4.Add(new object[4]);

		return pool4[freeIndex4++];
#else
		return new object[4];
#endif
	}
	
	public static object[] Get5()
	{
#if !NO_FLINQ_POOLS
		if(freeIndex5 >= pool5.Count)
			pool5.Add(new object[5]);

		return pool5[freeIndex5++];
#else
		return new object[5];
#endif
	}

	public static void ReturnAllObjects()
	{
#if !NO_FLINQ_POOLS
		for(int i = 0; i < freeIndex2; ++i)
		{
			Array.Clear(pool2[i], 0, 2);
		}
		
		for(int i = 0; i < freeIndex3; ++i)
		{
			Array.Clear(pool3[i], 0, 3);
		}
		
		for(int i = 0; i < freeIndex4; ++i)
		{
			Array.Clear(pool4[i], 0, 4);
		}
		
		for(int i = 0; i < freeIndex5; ++i)
		{
			Array.Clear(pool5[i], 0, 5);
		}

		freeIndex2 = 0;
		freeIndex3 = 0;
		freeIndex4 = 0;
		freeIndex5 = 0;
#endif
	}

	public static void Reset()
	{
#if !NO_FLINQ_POOLS
		pool2.Clear();
		pool3.Clear();
		pool4.Clear();
		pool5.Clear();

		freeIndex2 = 0;
		freeIndex3 = 0;
		freeIndex4 = 0;
		freeIndex5 = 0;
#endif
	}
}

}