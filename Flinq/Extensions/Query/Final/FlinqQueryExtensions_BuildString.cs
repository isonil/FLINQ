using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_BuildString
{
	public static string BuildString<T>(this FlinqQuery<string> query, string delim)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		var builder = FlinqStringBuilderPool.Get();
		int count = finalList.Count;

		for(int i = 0; i < count; ++i)
		{
			builder.Append(finalList[i]);

			if(i != count - 1)
				builder.Append(delim);
		}

		var str = builder.ToString();

		FlinqStringBuilderPool.Return(builder);

		query.CleanupAfterResolve(finalList, returnToPool);

		return str;
	}

	public static string BuildString<T>(this FlinqQuery<T> query, Func<T, string> selector, string delim)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		var builder = FlinqStringBuilderPool.Get();
		int count = finalList.Count;

		for(int i = 0; i < count; ++i)
		{
			builder.Append(selector(finalList[i]));

			if(i != count - 1)
				builder.Append(delim);
		}

		var str = builder.ToString();

		FlinqStringBuilderPool.Return(builder);

		query.CleanupAfterResolve(finalList, returnToPool);

		return str;
	}
}

}