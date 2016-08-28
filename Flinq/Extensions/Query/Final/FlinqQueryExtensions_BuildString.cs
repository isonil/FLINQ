using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_BuildString
{
	public static string BuildString<T>(this FlinqQuery<string> query, string delim)
	{
		var finalList = query.Resolve();

		var builder = FlinqStringBuilderPool.Get();
		int count = finalList.count;
		var array = finalList.array;

		for(int i = 0; i < count; ++i)
		{
			builder.Append(array[i]);

			if(i != count - 1)
				builder.Append(delim);
		}

		var str = builder.ToString();

		FlinqStringBuilderPool.Return(builder);

		FlinqListPool<string>.Return(finalList);

		return str;
	}
	
	public static string BuildString<T>(this FlinqQuery<string> query)
	{
		var finalList = query.Resolve();

		var builder = FlinqStringBuilderPool.Get();
		int count = finalList.count;
		var array = finalList.array;

		for(int i = 0; i < count; ++i)
		{
			builder.Append(array[i]);
		}

		var str = builder.ToString();

		FlinqStringBuilderPool.Return(builder);

		FlinqListPool<string>.Return(finalList);

		return str;
	}

	public static string BuildString<T>(this FlinqQuery<T> query, Func<T, string> selector, string delim)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		var builder = FlinqStringBuilderPool.Get();
		int count = finalList.count;
		var array = finalList.array;

		for(int i = 0; i < count; ++i)
		{
			builder.Append(selector(array[i]));

			if(i != count - 1)
				builder.Append(delim);
		}

		var str = builder.ToString();

		FlinqStringBuilderPool.Return(builder);

		FlinqListPool<T>.Return(finalList);

		return str;
	}
	
	public static string BuildString<T>(this FlinqQuery<T> query, Func<T, string> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		var builder = FlinqStringBuilderPool.Get();
		int count = finalList.count;
		var array = finalList.array;

		for(int i = 0; i < count; ++i)
		{
			builder.Append(selector(array[i]));
		}

		var str = builder.ToString();

		FlinqStringBuilderPool.Return(builder);

		FlinqListPool<T>.Return(finalList);

		return str;
	}
}

}