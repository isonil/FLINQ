using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_Sum
{
	public static decimal Sum(this FlinqQuery<decimal> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		decimal sum = 0;

		for(int i = 0; i < count; ++i)
		{
			sum += array[i];
		}

		FlinqListPool<decimal>.Return(finalList);

		return sum;
	}

	public static Nullable<decimal> Sum(this FlinqQuery<Nullable<decimal>> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		decimal sum = 0;

		for(int i = 0; i < count; ++i)
		{
			var elem = array[i];

			if(elem.HasValue)
				sum += elem.Value;
		}

		FlinqListPool<Nullable<decimal>>.Return(finalList);

		return sum;
	}

	public static double Sum(this FlinqQuery<double> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		double sum = 0.0;

		for(int i = 0; i < count; ++i)
		{
			sum += array[i];
		}

		FlinqListPool<double>.Return(finalList);

		return sum;
	}

	public static Nullable<double> Sum(this FlinqQuery<Nullable<double>> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		double sum = 0.0;

		for(int i = 0; i < count; ++i)
		{
			var elem = array[i];

			if(elem.HasValue)
				sum += elem.Value;
		}

		FlinqListPool<Nullable<double>>.Return(finalList);

		return sum;
	}

	public static int Sum(this FlinqQuery<int> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		int sum = 0;

		for(int i = 0; i < count; ++i)
		{
			sum += array[i];
		}

		FlinqListPool<int>.Return(finalList);

		return sum;
	}

	public static Nullable<int> Sum(this FlinqQuery<Nullable<int>> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		int sum = 0;

		for(int i = 0; i < count; ++i)
		{
			var elem = array[i];

			if(elem.HasValue)
				sum += elem.Value;
		}

		FlinqListPool<Nullable<int>>.Return(finalList);

		return sum;
	}

	public static long Sum(this FlinqQuery<long> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		long sum = 0;

		for(int i = 0; i < count; ++i)
		{
			sum += array[i];
		}

		FlinqListPool<long>.Return(finalList);

		return sum;
	}

	public static Nullable<long> Sum(this FlinqQuery<Nullable<long>> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		long sum = 0;

		for(int i = 0; i < count; ++i)
		{
			var elem = array[i];

			if(elem.HasValue)
				sum += elem.Value;
		}

		FlinqListPool<Nullable<long>>.Return(finalList);

		return sum;
	}

	public static float Sum(this FlinqQuery<float> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		float sum = 0f;

		for(int i = 0; i < count; ++i)
		{
			sum += array[i];
		}

		FlinqListPool<float>.Return(finalList);

		return sum;
	}

	public static Nullable<float> Sum(this FlinqQuery<Nullable<float>> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		float sum = 0f;

		for(int i = 0; i < count; ++i)
		{
			var elem = array[i];

			if(elem.HasValue)
				sum += elem.Value;
		}

		FlinqListPool<Nullable<float>>.Return(finalList);

		return sum;
	}

	public static decimal Sum<T>(this FlinqQuery<T> query, Func<T, decimal> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		decimal sum = 0;

		for(int i = 0; i < count; ++i)
		{
			sum += selector(array[i]);
		}

		FlinqListPool<T>.Return(finalList);

		return sum;
	}

	public static Nullable<decimal> Sum<T>(this FlinqQuery<T> query, Func<T, Nullable<decimal>> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		decimal sum = 0;

		for(int i = 0; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem.HasValue)
				sum += elem.Value;
		}

		FlinqListPool<T>.Return(finalList);

		return sum;
	}

	public static double Sum<T>(this FlinqQuery<T> query, Func<T, double> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		double sum = 0.0;

		for(int i = 0; i < count; ++i)
		{
			sum += selector(array[i]);
		}

		FlinqListPool<T>.Return(finalList);

		return sum;
	}

	public static Nullable<double> Sum<T>(this FlinqQuery<T> query, Func<T, Nullable<double>> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		double sum = 0.0;

		for(int i = 0; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem.HasValue)
				sum += elem.Value;
		}

		FlinqListPool<T>.Return(finalList);

		return sum;
	}

	public static int Sum<T>(this FlinqQuery<T> query, Func<T, int> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		int sum = 0;

		for(int i = 0; i < count; ++i)
		{
			sum += selector(array[i]);
		}

		FlinqListPool<T>.Return(finalList);

		return sum;
	}

	public static Nullable<int> Sum<T>(this FlinqQuery<T> query, Func<T, Nullable<int>> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		int sum = 0;

		for(int i = 0; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem.HasValue)
				sum += elem.Value;
		}

		FlinqListPool<T>.Return(finalList);

		return sum;
	}

	public static long Sum<T>(this FlinqQuery<T> query, Func<T, long> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		long sum = 0;

		for(int i = 0; i < count; ++i)
		{
			sum += selector(array[i]);
		}

		FlinqListPool<T>.Return(finalList);

		return sum;
	}

	public static Nullable<long> Sum<T>(this FlinqQuery<T> query, Func<T, Nullable<long>> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		long sum = 0;

		for(int i = 0; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem.HasValue)
				sum += elem.Value;
		}

		FlinqListPool<T>.Return(finalList);

		return sum;
	}

	public static float Sum<T>(this FlinqQuery<T> query, Func<T, float> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		float sum = 0f;

		for(int i = 0; i < count; ++i)
		{
			sum += selector(array[i]);
		}

		FlinqListPool<T>.Return(finalList);

		return sum;
	}

	public static Nullable<float> Sum<T>(this FlinqQuery<T> query, Func<T, Nullable<float>> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		float sum = 0f;

		for(int i = 0; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem.HasValue)
				sum += elem.Value;
		}

		FlinqListPool<T>.Return(finalList);

		return sum;
	}
}

}