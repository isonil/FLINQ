using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_IntersectsBy
{
	public static bool IntersectsBy<T, TCompareBy>(this FlinqQuery<T> query, FlinqQuery<T> other, Func<T, TCompareBy> compareBy)
	{
		if(compareBy == null)
			throw new ArgumentNullException("compareBy");

		var finalList = query.Resolve();

		var otherFinalList = other.Resolve();

		int count = finalList.count;
		var array = finalList.array;
		var hashSet = FlinqHashSetPool<TCompareBy>.Get();

		for(int i = 0; i < count; ++i)
		{
			hashSet.Add(compareBy(array[i]));
		}

		FlinqListPool<T>.Return(finalList);

		count = otherFinalList.count;
		var otherArray = otherFinalList.array;

		bool intersects = false;

		for(int i = 0; i < count; ++i)
		{
			if(hashSet.Contains(compareBy(otherArray[i])))
			{
				intersects = true;
				break;
			}
		}

		FlinqHashSetPool<TCompareBy>.Return(hashSet);
		FlinqListPool<T>.Return(otherFinalList);

		return intersects;
	}

	public static bool IntersectsBy<TFirst, TSecond, TCompareBy>(this FlinqQuery<TFirst> first, FlinqQuery<TSecond> second, Func<TFirst, TCompareBy> firstCompareBy, Func<TSecond, TCompareBy> secondCompareBy)
	{
		if(firstCompareBy == null)
			throw new ArgumentNullException("firstCompareBy");

		if(secondCompareBy == null)
			throw new ArgumentNullException("secondCompareBy");

		var firstFinalList = first.Resolve();
		var secondFinalList = second.Resolve();

		int count = firstFinalList.count;
		var firstArray = firstFinalList.array;
		var hashSet = FlinqHashSetPool<TCompareBy>.Get();

		for(int i = 0; i < count; ++i)
		{
			hashSet.Add(firstCompareBy(firstArray[i]));
		}

		FlinqListPool<TFirst>.Return(firstFinalList);

		count = secondFinalList.count;
		var secondArray = secondFinalList.array;

		bool intersects = false;

		for(int i = 0; i < count; ++i)
		{
			if(hashSet.Contains(secondCompareBy(secondArray[i])))
			{
				intersects = true;
				break;
			}
		}

		FlinqHashSetPool<TCompareBy>.Return(hashSet);
		FlinqListPool<TSecond>.Return(secondFinalList);

		return intersects;
	}
}

}