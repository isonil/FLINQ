using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_Average
{
	public static decimal Average(this FlinqQuery<decimal> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		if(finalList.Count == 0)
		{
			query.CleanupAfterResolve(finalList, returnToPool);
			throw new InvalidOperationException("No elements.");
		}

		decimal final = 0;
		int count = finalList.Count;
		
		for(int i = 0; i < count; ++i)
		{
			final += finalList[i];
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return final / count;
	}

	public static Nullable<decimal> Average(this FlinqQuery<Nullable<decimal>> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		decimal final = 0;
		int count = finalList.Count;
		int realCount = 0;

		for(int i = 0; i < count; ++i)
		{
			var element = finalList[i];

			if(element.HasValue)
			{
				final += element.Value;
				++realCount;
			}
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		if(realCount == 0)
			return null;

		return final / realCount;
	}

	public static double Average(this FlinqQuery<double> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		if(finalList.Count == 0)
		{
			query.CleanupAfterResolve(finalList, returnToPool);
			throw new InvalidOperationException("No elements.");
		}

		double final = 0.0;
		int count = finalList.Count;

		for(int i = 0; i < count; ++i)
		{
			final += finalList[i];
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return final / count;
	}

	public static Nullable<double> Average(this FlinqQuery<Nullable<double>> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		double final = 0.0;
		int count = finalList.Count;
		int realCount = 0;

		for(int i = 0; i < count; ++i)
		{
			var element = finalList[i];

			if(element.HasValue)
			{
				final += element.Value;
				++realCount;
			}
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		if(realCount == 0)
			return null;

		return final / realCount;
	}

	public static double Average(this FlinqQuery<int> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		if(finalList.Count == 0)
		{
			query.CleanupAfterResolve(finalList, returnToPool);
			throw new InvalidOperationException("No elements.");
		}

		int final = 0;
		int count = finalList.Count;

		for(int i = 0; i < count; ++i)
		{
			final += finalList[i];
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return final / (double)count;
	}

	public static Nullable<double> Average(this FlinqQuery<Nullable<int>> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int final = 0;
		int count = finalList.Count;
		int realCount = 0;

		for(int i = 0; i < count; ++i)
		{
			var element = finalList[i];

			if(element.HasValue)
			{
				final += element.Value;
				++realCount;
			}
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		if(realCount == 0)
			return null;

		return final / (double)realCount;
	}

	public static double Average(this FlinqQuery<long> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		if(finalList.Count == 0)
		{
			query.CleanupAfterResolve(finalList, returnToPool);
			throw new InvalidOperationException("No elements.");
		}

		long final = 0;
		int count = finalList.Count;

		for(int i = 0; i < count; ++i)
		{
			final += finalList[i];
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return final / (double)count;
	}

	public static Nullable<double> Average(this FlinqQuery<Nullable<long>> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		long final = 0;
		int count = finalList.Count;
		int realCount = 0;

		for(int i = 0; i < count; ++i)
		{
			var element = finalList[i];

			if(element.HasValue)
			{
				final += element.Value;
				++realCount;
			}
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		if(realCount == 0)
			return null;

		return final / (double)realCount;
	}

	public static float Average(this FlinqQuery<float> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		if(finalList.Count == 0)
		{
			query.CleanupAfterResolve(finalList, returnToPool);
			throw new InvalidOperationException("No elements.");
		}

		float final = 0f;
		int count = finalList.Count;

		for(int i = 0; i < count; ++i)
		{
			final += finalList[i];
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return final / count;
	}

	public static Nullable<float> Average(this FlinqQuery<Nullable<float>> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		float final = 0f;
		int count = finalList.Count;
		int realCount = 0;

		for(int i = 0; i < count; ++i)
		{
			var element = finalList[i];

			if(element.HasValue)
			{
				final += element.Value;
				++realCount;
			}
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		if(realCount == 0)
			return null;

		return final / realCount;
	}

	// with selectors

	public static decimal Average<T>(this FlinqQuery<T> query, Func<T, decimal> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		if(finalList.Count == 0)
		{
			query.CleanupAfterResolve(finalList, returnToPool);
			throw new InvalidOperationException("No elements.");
		}

		decimal final = 0;
		int count = finalList.Count;

		for(int i = 0; i < count; ++i)
		{
			final += selector(finalList[i]);
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return final / count;
	}

	public static Nullable<decimal> Average<T>(this FlinqQuery<T> query, Func<T, Nullable<decimal>> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		decimal final = 0;
		int count = finalList.Count;
		int realCount = 0;

		for(int i = 0; i < count; ++i)
		{
			var element = selector(finalList[i]);

			if(element.HasValue)
			{
				final += element.Value;
				++realCount;
			}
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		if(realCount == 0)
			return null;

		return final / realCount;
	}

	public static double Average<T>(this FlinqQuery<T> query, Func<T, double> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		if(finalList.Count == 0)
		{
			query.CleanupAfterResolve(finalList, returnToPool);
			throw new InvalidOperationException("No elements.");
		}

		double final = 0.0;
		int count = finalList.Count;

		for(int i = 0; i < count; ++i)
		{
			final += selector(finalList[i]);
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return final / count;
	}

	public static Nullable<double> Average<T>(this FlinqQuery<T> query, Func<T, Nullable<double>> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		double final = 0.0;
		int count = finalList.Count;
		int realCount = 0;

		for(int i = 0; i < count; ++i)
		{
			var element = selector(finalList[i]);

			if(element.HasValue)
			{
				final += element.Value;
				++realCount;
			}
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		if(realCount == 0)
			return null;

		return final / realCount;
	}

	public static double Average<T>(this FlinqQuery<T> query, Func<T, int> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		if(finalList.Count == 0)
		{
			query.CleanupAfterResolve(finalList, returnToPool);
			throw new InvalidOperationException("No elements.");
		}

		int final = 0;
		int count = finalList.Count;

		for(int i = 0; i < count; ++i)
		{
			final += selector(finalList[i]);
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return final / (double)count;
	}

	public static Nullable<double> Average<T>(this FlinqQuery<T> query, Func<T, Nullable<int>> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int final = 0;
		int count = finalList.Count;
		int realCount = 0;

		for(int i = 0; i < count; ++i)
		{
			var element = selector(finalList[i]);

			if(element.HasValue)
			{
				final += element.Value;
				++realCount;
			}
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		if(realCount == 0)
			return null;

		return final / (double)realCount;
	}

	public static double Average<T>(this FlinqQuery<T> query, Func<T, long> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		if(finalList.Count == 0)
		{
			query.CleanupAfterResolve(finalList, returnToPool);
			throw new InvalidOperationException("No elements.");
		}

		long final = 0;
		int count = finalList.Count;

		for(int i = 0; i < count; ++i)
		{
			final += selector(finalList[i]);
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return final / (double)count;
	}

	public static Nullable<double> Average<T>(this FlinqQuery<T> query, Func<T, Nullable<long>> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		long final = 0;
		int count = finalList.Count;
		int realCount = 0;

		for(int i = 0; i < count; ++i)
		{
			var element = selector(finalList[i]);

			if(element.HasValue)
			{
				final += element.Value;
				++realCount;
			}
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		if(realCount == 0)
			return null;

		return final / (double)realCount;
	}

	public static float Average<T>(this FlinqQuery<T> query, Func<T, float> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		if(finalList.Count == 0)
		{
			query.CleanupAfterResolve(finalList, returnToPool);
			throw new InvalidOperationException("No elements.");
		}

		float final = 0f;
		int count = finalList.Count;

		for(int i = 0; i < count; ++i)
		{
			final += selector(finalList[i]);
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return final / count;
	}

	public static Nullable<float> Average<T>(this FlinqQuery<T> query, Func<T, Nullable<float>> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		float final = 0f;
		int count = finalList.Count;
		int realCount = 0;

		for(int i = 0; i < count; ++i)
		{
			var element = selector(finalList[i]);

			if(element.HasValue)
			{
				final += element.Value;
				++realCount;
			}
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		if(realCount == 0)
			return null;

		return final / realCount;
	}
}

}