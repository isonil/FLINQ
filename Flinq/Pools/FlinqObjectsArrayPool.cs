using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqObjectsArrayPool
{
	private static FlinqList<object[]> pool2 = new FlinqList<object[]>();
	private static FlinqList<object[]> pool3 = new FlinqList<object[]>();
	private static FlinqList<object[]> pool4 = new FlinqList<object[]>();
	private static FlinqList<object[]> pool5 = new FlinqList<object[]>();
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
		if(freeIndex2 >= pool2.count)
			pool2.Add(new object[2]);

		return pool2.array[freeIndex2++];
#else
		return new object[2];
#endif
	}
	
	public static object[] Get3()
	{
#if !NO_FLINQ_POOLS
		if(freeIndex3 >= pool3.count)
			pool3.Add(new object[3]);

		return pool3.array[freeIndex3++];
#else
		return new object[3];
#endif
	}
	
	public static object[] Get4()
	{
#if !NO_FLINQ_POOLS
		if(freeIndex4 >= pool4.count)
			pool4.Add(new object[4]);

		return pool4.array[freeIndex4++];
#else
		return new object[4];
#endif
	}
	
	public static object[] Get5()
	{
#if !NO_FLINQ_POOLS
		if(freeIndex5 >= pool5.count)
			pool5.Add(new object[5]);

		return pool5.array[freeIndex5++];
#else
		return new object[5];
#endif
	}

	public static void ReturnAllObjects()
	{
#if !NO_FLINQ_POOLS
		var pool2Array = pool2.array;

		for(int i = 0; i < freeIndex2; ++i)
		{
			Array.Clear(pool2Array[i], 0, 2);
		}

		var pool3Array = pool3.array;
		
		for(int i = 0; i < freeIndex3; ++i)
		{
			Array.Clear(pool3Array[i], 0, 3);
		}

		var pool4Array = pool4.array;
		
		for(int i = 0; i < freeIndex4; ++i)
		{
			Array.Clear(pool4Array[i], 0, 4);
		}

		var pool5Array = pool5.array;
		
		for(int i = 0; i < freeIndex5; ++i)
		{
			Array.Clear(pool5Array[i], 0, 5);
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