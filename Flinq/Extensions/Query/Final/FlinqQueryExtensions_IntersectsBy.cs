using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_IntersectsBy
{
	public static bool IntersectsBy<T, TCompareBy>(this FlinqQuery<T> query, FlinqQuery<T> other, Func<T, TCompareBy> compareBy)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(other == null)
			throw new ArgumentNullException("other");

		if(compareBy == null)
			throw new ArgumentNullException("compareBy");

		bool returnToPool;
		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		bool otherReturnToPool;
		var otherFinalList = other.Resolve(int.MaxValue, out otherReturnToPool);

		int count = finalList.Count;
		var hashSet = FlinqHashSetPool<TCompareBy>.Get();

		for(int i = 0; i < count; ++i)
		{
			hashSet.Add(compareBy(finalList[i]));
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		count = otherFinalList.Count;

		bool intersects = false;

		for(int i = 0; i < count; ++i)
		{
			if(hashSet.Contains(compareBy(otherFinalList[i])))
			{
				intersects = true;
				break;
			}
		}

		FlinqHashSetPool<TCompareBy>.Return(hashSet);

		other.CleanupAfterResolve(otherFinalList, otherReturnToPool);

		return intersects;
	}

	public static bool IntersectsBy<TFirst, TSecond, TCompareBy>(this FlinqQuery<TFirst> first, FlinqQuery<TSecond> second, Func<TFirst, TCompareBy> firstCompareBy, Func<TSecond, TCompareBy> secondCompareBy)
	{
		if(first == null)
			throw new ArgumentNullException("first");

		if(second == null)
			throw new ArgumentNullException("second");

		if(firstCompareBy == null)
			throw new ArgumentNullException("firstCompareBy");

		if(secondCompareBy == null)
			throw new ArgumentNullException("secondCompareBy");

		bool firstReturnToPool;
		var firstFinalList = first.Resolve(int.MaxValue, out firstReturnToPool);

		bool secondReturnToPool;
		var secondFinalList = second.Resolve(int.MaxValue, out secondReturnToPool);

		int count = firstFinalList.Count;
		var hashSet = FlinqHashSetPool<TCompareBy>.Get();

		for(int i = 0; i < count; ++i)
		{
			hashSet.Add(firstCompareBy(firstFinalList[i]));
		}

		first.CleanupAfterResolve(firstFinalList, firstReturnToPool);

		count = secondFinalList.Count;

		bool intersects = false;

		for(int i = 0; i < count; ++i)
		{
			if(hashSet.Contains(secondCompareBy(secondFinalList[i])))
			{
				intersects = true;
				break;
			}
		}

		FlinqHashSetPool<TCompareBy>.Return(hashSet);

		second.CleanupAfterResolve(secondFinalList, secondReturnToPool);

		return intersects;
	}
}

}