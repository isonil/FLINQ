using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_Average
{
	public static decimal Average(this FlinqQuery<decimal> query)
	{
		var finalList = query.Resolve();
		int count = finalList.count;

		if(count == 0)
		{
			FlinqListPool<decimal>.Return(finalList);
			throw new InvalidOperationException("No elements.");
		}

		var array = finalList.array;

		decimal final = 0;
		
		for(int i = 0; i < count; ++i)
		{
			final += array[i];
		}

		FlinqListPool<decimal>.Return(finalList);

		return final / count;
	}

	public static Nullable<decimal> Average(this FlinqQuery<Nullable<decimal>> query)
	{
		var finalList = query.Resolve();

		decimal final = 0;
		int count = finalList.count;
		var array = finalList.array;
		int realCount = 0;

		for(int i = 0; i < count; ++i)
		{
			var element = array[i];

			if(element.HasValue)
			{
				final += element.Value;
				++realCount;
			}
		}

		FlinqListPool<Nullable<decimal>>.Return(finalList);

		if(realCount == 0)
			return null;

		return final / realCount;
	}

	public static double Average(this FlinqQuery<double> query)
	{
		var finalList = query.Resolve();
		int count = finalList.count;

		if(count == 0)
		{
			FlinqListPool<double>.Return(finalList);
			throw new InvalidOperationException("No elements.");
		}

		var array = finalList.array;

		double final = 0.0;

		for(int i = 0; i < count; ++i)
		{
			final += array[i];
		}

		FlinqListPool<double>.Return(finalList);

		return final / count;
	}

	public static Nullable<double> Average(this FlinqQuery<Nullable<double>> query)
	{
		var finalList = query.Resolve();

		double final = 0.0;
		int count = finalList.count;
		var array = finalList.array;
		int realCount = 0;

		for(int i = 0; i < count; ++i)
		{
			var element = array[i];

			if(element.HasValue)
			{
				final += element.Value;
				++realCount;
			}
		}

		FlinqListPool<Nullable<double>>.Return(finalList);

		if(realCount == 0)
			return null;

		return final / realCount;
	}

	public static double Average(this FlinqQuery<int> query)
	{
		var finalList = query.Resolve();
		int count = finalList.count;

		if(count == 0)
		{
			FlinqListPool<int>.Return(finalList);
			throw new InvalidOperationException("No elements.");
		}

		var array = finalList.array;

		int final = 0;

		for(int i = 0; i < count; ++i)
		{
			final += array[i];
		}

		FlinqListPool<int>.Return(finalList);

		return final / (double)count;
	}

	public static Nullable<double> Average(this FlinqQuery<Nullable<int>> query)
	{
		var finalList = query.Resolve();

		int final = 0;
		int count = finalList.count;
		var array = finalList.array;
		int realCount = 0;

		for(int i = 0; i < count; ++i)
		{
			var element = array[i];

			if(element.HasValue)
			{
				final += element.Value;
				++realCount;
			}
		}

		FlinqListPool<Nullable<int>>.Return(finalList);

		if(realCount == 0)
			return null;

		return final / (double)realCount;
	}

	public static double Average(this FlinqQuery<long> query)
	{
		var finalList = query.Resolve();
		int count = finalList.count;

		if(count == 0)
		{
			FlinqListPool<long>.Return(finalList);
			throw new InvalidOperationException("No elements.");
		}

		var array = finalList.array;

		long final = 0;

		for(int i = 0; i < count; ++i)
		{
			final += array[i];
		}

		FlinqListPool<long>.Return(finalList);

		return final / (double)count;
	}

	public static Nullable<double> Average(this FlinqQuery<Nullable<long>> query)
	{
		var finalList = query.Resolve();

		long final = 0;
		int count = finalList.count;
		var array = finalList.array;
		int realCount = 0;

		for(int i = 0; i < count; ++i)
		{
			var element = array[i];

			if(element.HasValue)
			{
				final += element.Value;
				++realCount;
			}
		}

		FlinqListPool<Nullable<long>>.Return(finalList);

		if(realCount == 0)
			return null;

		return final / (double)realCount;
	}

	public static float Average(this FlinqQuery<float> query)
	{
		var finalList = query.Resolve();
		int count = finalList.count;

		if(count == 0)
		{
			FlinqListPool<float>.Return(finalList);
			throw new InvalidOperationException("No elements.");
		}

		var array = finalList.array;

		float final = 0f;

		for(int i = 0; i < count; ++i)
		{
			final += array[i];
		}

		FlinqListPool<float>.Return(finalList);

		return final / count;
	}

	public static Nullable<float> Average(this FlinqQuery<Nullable<float>> query)
	{
		var finalList = query.Resolve();

		float final = 0f;
		int count = finalList.count;
		var array = finalList.array;
		int realCount = 0;

		for(int i = 0; i < count; ++i)
		{
			var element = array[i];

			if(element.HasValue)
			{
				final += element.Value;
				++realCount;
			}
		}

		FlinqListPool<Nullable<float>>.Return(finalList);

		if(realCount == 0)
			return null;

		return final / realCount;
	}

	// with selectors

	public static decimal Average<T>(this FlinqQuery<T> query, Func<T, decimal> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();
		int count = finalList.count;

		if(count == 0)
		{
			FlinqListPool<T>.Return(finalList);
			throw new InvalidOperationException("No elements.");
		}

		var array = finalList.array;

		decimal final = 0;

		for(int i = 0; i < count; ++i)
		{
			final += selector(array[i]);
		}

		FlinqListPool<T>.Return(finalList);

		return final / count;
	}

	public static Nullable<decimal> Average<T>(this FlinqQuery<T> query, Func<T, Nullable<decimal>> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		decimal final = 0;
		int count = finalList.count;
		var array = finalList.array;
		int realCount = 0;

		for(int i = 0; i < count; ++i)
		{
			var element = selector(array[i]);

			if(element.HasValue)
			{
				final += element.Value;
				++realCount;
			}
		}

		FlinqListPool<T>.Return(finalList);

		if(realCount == 0)
			return null;

		return final / realCount;
	}

	public static double Average<T>(this FlinqQuery<T> query, Func<T, double> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();
		int count = finalList.count;

		if(count == 0)
		{
			FlinqListPool<T>.Return(finalList);
			throw new InvalidOperationException("No elements.");
		}

		var array = finalList.array;

		double final = 0.0;

		for(int i = 0; i < count; ++i)
		{
			final += selector(array[i]);
		}

		FlinqListPool<T>.Return(finalList);

		return final / count;
	}

	public static Nullable<double> Average<T>(this FlinqQuery<T> query, Func<T, Nullable<double>> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		double final = 0.0;
		int count = finalList.count;
		var array = finalList.array;
		int realCount = 0;

		for(int i = 0; i < count; ++i)
		{
			var element = selector(array[i]);

			if(element.HasValue)
			{
				final += element.Value;
				++realCount;
			}
		}

		FlinqListPool<T>.Return(finalList);

		if(realCount == 0)
			return null;

		return final / realCount;
	}

	public static double Average<T>(this FlinqQuery<T> query, Func<T, int> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();
		int count = finalList.count;

		if(count == 0)
		{
			FlinqListPool<T>.Return(finalList);
			throw new InvalidOperationException("No elements.");
		}

		var array = finalList.array;

		int final = 0;

		for(int i = 0; i < count; ++i)
		{
			final += selector(array[i]);
		}

		FlinqListPool<T>.Return(finalList);

		return final / (double)count;
	}

	public static Nullable<double> Average<T>(this FlinqQuery<T> query, Func<T, Nullable<int>> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int final = 0;
		int count = finalList.count;
		var array = finalList.array;
		int realCount = 0;

		for(int i = 0; i < count; ++i)
		{
			var element = selector(array[i]);

			if(element.HasValue)
			{
				final += element.Value;
				++realCount;
			}
		}

		FlinqListPool<T>.Return(finalList);

		if(realCount == 0)
			return null;

		return final / (double)realCount;
	}

	public static double Average<T>(this FlinqQuery<T> query, Func<T, long> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();
		int count = finalList.count;

		if(count == 0)
		{
			FlinqListPool<T>.Return(finalList);
			throw new InvalidOperationException("No elements.");
		}

		var array = finalList.array;

		long final = 0;

		for(int i = 0; i < count; ++i)
		{
			final += selector(array[i]);
		}

		FlinqListPool<T>.Return(finalList);

		return final / (double)count;
	}

	public static Nullable<double> Average<T>(this FlinqQuery<T> query, Func<T, Nullable<long>> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		long final = 0;
		int count = finalList.count;
		var array = finalList.array;
		int realCount = 0;

		for(int i = 0; i < count; ++i)
		{
			var element = selector(array[i]);

			if(element.HasValue)
			{
				final += element.Value;
				++realCount;
			}
		}

		FlinqListPool<T>.Return(finalList);

		if(realCount == 0)
			return null;

		return final / (double)realCount;
	}

	public static float Average<T>(this FlinqQuery<T> query, Func<T, float> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();
		int count = finalList.count;

		if(count == 0)
		{
			FlinqListPool<T>.Return(finalList);
			throw new InvalidOperationException("No elements.");
		}

		var array = finalList.array;

		float final = 0f;

		for(int i = 0; i < count; ++i)
		{
			final += selector(array[i]);
		}

		FlinqListPool<T>.Return(finalList);

		return final / count;
	}

	public static Nullable<float> Average<T>(this FlinqQuery<T> query, Func<T, Nullable<float>> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		float final = 0f;
		int count = finalList.count;
		var array = finalList.array;
		int realCount = 0;

		for(int i = 0; i < count; ++i)
		{
			var element = selector(array[i]);

			if(element.HasValue)
			{
				final += element.Value;
				++realCount;
			}
		}

		FlinqListPool<T>.Return(finalList);

		if(realCount == 0)
			return null;

		return final / realCount;
	}
}

}