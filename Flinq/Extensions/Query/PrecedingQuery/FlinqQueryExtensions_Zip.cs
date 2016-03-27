using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_Zip
{
	private static class ImplWrapper<TFirst, TSecond, TResult>
	{
		public static readonly FlinqQuery<TResult>.PrecedingQuery impl = Impl;

		private static List<TResult> Impl(int wantedElementsCount, object paramsPack)
		{
			var paramsArray = (object[])paramsPack;
			var first = (FlinqQuery<TFirst>)paramsArray[0];
			var second = (FlinqQuery<TSecond>)paramsArray[1];
			var resultSelector = (Func<TFirst, TSecond, TResult>)paramsArray[2];

			bool firstReturnToPool;
			var firstFinalList = first.Resolve(wantedElementsCount, out firstReturnToPool);

			bool secondReturnToPool;
			var secondFinalList = second.Resolve(wantedElementsCount, out secondReturnToPool);

			var newList = FlinqListPool<TResult>.Get();

			int count = Math.Min(Math.Min(wantedElementsCount, firstFinalList.Count), secondFinalList.Count);

			for(int i = 0; i < count; ++i)
			{
				newList.Add(resultSelector(firstFinalList[i], secondFinalList[i]));
			}

			second.CleanupAfterResolve(secondFinalList, secondReturnToPool);
			first.CleanupAfterResolve(firstFinalList, firstReturnToPool);

			return newList;
		}
	}

	public static FlinqQuery<TResult> Zip<TFirst, TSecond, TResult>(this FlinqQuery<TFirst> first, FlinqQuery<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
	{
		if(first == null)
			throw new ArgumentNullException("first");

		if(second == null)
			throw new ArgumentNullException("second");

		if(resultSelector == null)
			throw new ArgumentNullException("resultSelector");

		var paramsPack = FlinqObjectsArrayPool.Get3();

		paramsPack[0] = first;
		paramsPack[1] = second;
		paramsPack[2] = resultSelector;

		var newQuery = FlinqQueryPool<TResult>.Get();

		newQuery.OnInit(ImplWrapper<TFirst, TSecond, TResult>.impl, paramsPack);

		return newQuery;
	}
}

}