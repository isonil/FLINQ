﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_ExceptBy
{
	private static class ImplWrapper<TFirst, TSecond, TCompareBy>
	{
		public static readonly FlinqQuery<TFirst>.PrecedingQuery impl = Impl;

		private static FlinqList<TFirst> Impl(object paramsPack)
		{
			var paramsArray = (object[])paramsPack;
			var first = (FlinqQuery<TFirst>)paramsArray[0];
			var second = (FlinqQuery<TSecond>)paramsArray[1];
			var firstCompareBySelector = (Func<TFirst, TCompareBy>)paramsArray[2];
			var secondCompareBySelector = (Func<TSecond, TCompareBy>)paramsArray[3];

			var secondFinalList = second.Resolve();

			var hashSet = FlinqHashSetPool<TCompareBy>.Get();

			int secondCount = secondFinalList.count;
			var secondArray = secondFinalList.array;

			for(int i = 0; i < secondCount; ++i)
			{
				hashSet.Add(secondCompareBySelector(secondArray[i]));
			}

			FlinqListPool<TSecond>.Return(secondFinalList);

			var firstFinalList = first.Resolve();

			int firstCount = firstFinalList.count;
			var firstArray = firstFinalList.array;

			var newList = FlinqListPool<TFirst>.Get();

			for(int i = 0; i < firstCount; ++i)
			{
				var elem = firstArray[i];

				if(!hashSet.Contains(firstCompareBySelector(elem)))
					newList.Add(elem);
			}

			FlinqListPool<TFirst>.Return(firstFinalList);
			FlinqHashSetPool<TCompareBy>.Return(hashSet);

			return newList;
		}
	}

	public static FlinqQuery<TFirst> ExceptBy<TFirst, TSecond, TCompareBy>(this FlinqQuery<TFirst> first, FlinqQuery<TSecond> second, Func<TFirst, TCompareBy> firstCompareBySelector, Func<TSecond, TCompareBy> secondCompareBySelector)
	{
		if(firstCompareBySelector == null)
			throw new ArgumentNullException("firstCompareBySelector");

		if(secondCompareBySelector == null)
			throw new ArgumentNullException("secondCompareBySelector");

		var paramsPack = FlinqObjectsArrayPool.Get4();

		paramsPack[0] = first;
		paramsPack[1] = second;
		paramsPack[2] = firstCompareBySelector;
		paramsPack[3] = secondCompareBySelector;

		return new FlinqQuery<TFirst>(ImplWrapper<TFirst, TSecond, TCompareBy>.impl, paramsPack);
	}
}

}