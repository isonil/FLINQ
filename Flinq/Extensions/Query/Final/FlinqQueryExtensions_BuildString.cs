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

		var finalList = query.Resolve();

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

		FlinqListPool<string>.Return(finalList);

		return str;
	}

	public static string BuildString<T>(this FlinqQuery<T> query, Func<T, string> selector, string delim)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

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

		FlinqListPool<T>.Return(finalList);

		return str;
	}
}

}