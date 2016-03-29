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

		private static List<TResult> Impl(object paramsPack)
		{
			var paramsArray = (object[])paramsPack;
			var first = (FlinqQuery<TFirst>)paramsArray[0];
			var second = (FlinqQuery<TSecond>)paramsArray[1];
			var resultSelector = (Func<TFirst, TSecond, TResult>)paramsArray[2];

			var firstFinalList = first.Resolve();
			var secondFinalList = second.Resolve();

			var newList = FlinqListPool<TResult>.Get();

			int count = Math.Min(firstFinalList.Count, secondFinalList.Count);

			for(int i = 0; i < count; ++i)
			{
				newList.Add(resultSelector(firstFinalList[i], secondFinalList[i]));
			}

			FlinqListPool<TSecond>.Return(secondFinalList);
			FlinqListPool<TFirst>.Return(firstFinalList);

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