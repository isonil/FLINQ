using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_OfType
{
	private static class ImplWrapper<T, TResult> where TResult : class
	{
		public static readonly FlinqQuery<TResult>.PrecedingQuery impl = Impl;

		private static FlinqList<TResult> Impl(object param)
		{
			var query = (FlinqQuery<T>)param;

			var finalList = query.Resolve();
			var newList = FlinqListPool<TResult>.Get();
			int count = finalList.count;
			var array = finalList.array;

			for(int i = 0; i < count; ++i)
			{
				var newElem = array[i] as TResult;

				if(newElem != null)
					newList.Add(newElem);
			}

			FlinqListPool<T>.Return(finalList);

			return newList;
		}
	}

	public static FlinqQuery<TResult> OfType<T, TResult>(this FlinqQuery<T> query) where TResult : class
	{
		if(query is FlinqQuery<TResult>)
			return (FlinqQuery<TResult>)(object)query;

		return new FlinqQuery<TResult>(ImplWrapper<T, TResult>.impl, query);
	}
}

}