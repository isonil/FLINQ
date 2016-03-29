using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_Sum
{
	public static decimal Sum(this FlinqQuery<decimal> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var finalList = query.Resolve();

		int count = finalList.Count;

		decimal sum = 0;

		for(int i = 0; i < count; ++i)
		{
			sum += finalList[i];
		}

		FlinqListPool<decimal>.Return(finalList);

		return sum;
	}

	public static Nullable<decimal> Sum(this FlinqQuery<Nullable<decimal>> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var finalList = query.Resolve();

		int count = finalList.Count;

		decimal sum = 0;

		for(int i = 0; i < count; ++i)
		{
			var elem = finalList[i];

			if(elem.HasValue)
				sum += elem.Value;
		}

		FlinqListPool<Nullable<decimal>>.Return(finalList);

		return sum;
	}

	public static double Sum(this FlinqQuery<double> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var finalList = query.Resolve();

		int count = finalList.Count;

		double sum = 0.0;

		for(int i = 0; i < count; ++i)
		{
			sum += finalList[i];
		}

		FlinqListPool<double>.Return(finalList);

		return sum;
	}

	public static Nullable<double> Sum(this FlinqQuery<Nullable<double>> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var finalList = query.Resolve();

		int count = finalList.Count;

		double sum = 0.0;

		for(int i = 0; i < count; ++i)
		{
			var elem = finalList[i];

			if(elem.HasValue)
				sum += elem.Value;
		}

		FlinqListPool<Nullable<double>>.Return(finalList);

		return sum;
	}

	public static int Sum(this FlinqQuery<int> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var finalList = query.Resolve();

		int count = finalList.Count;

		int sum = 0;

		for(int i = 0; i < count; ++i)
		{
			sum += finalList[i];
		}

		FlinqListPool<int>.Return(finalList);

		return sum;
	}

	public static Nullable<int> Sum(this FlinqQuery<Nullable<int>> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var finalList = query.Resolve();

		int count = finalList.Count;

		int sum = 0;

		for(int i = 0; i < count; ++i)
		{
			var elem = finalList[i];

			if(elem.HasValue)
				sum += elem.Value;
		}

		FlinqListPool<Nullable<int>>.Return(finalList);

		return sum;
	}

	public static long Sum(this FlinqQuery<long> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var finalList = query.Resolve();

		int count = finalList.Count;

		long sum = 0;

		for(int i = 0; i < count; ++i)
		{
			sum += finalList[i];
		}

		FlinqListPool<long>.Return(finalList);

		return sum;
	}

	public static Nullable<long> Sum(this FlinqQuery<Nullable<long>> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var finalList = query.Resolve();

		int count = finalList.Count;

		long sum = 0;

		for(int i = 0; i < count; ++i)
		{
			var elem = finalList[i];

			if(elem.HasValue)
				sum += elem.Value;
		}

		FlinqListPool<Nullable<long>>.Return(finalList);

		return sum;
	}

	public static float Sum(this FlinqQuery<float> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var finalList = query.Resolve();

		int count = finalList.Count;

		float sum = 0f;

		for(int i = 0; i < count; ++i)
		{
			sum += finalList[i];
		}

		FlinqListPool<float>.Return(finalList);

		return sum;
	}

	public static Nullable<float> Sum(this FlinqQuery<Nullable<float>> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var finalList = query.Resolve();

		int count = finalList.Count;

		float sum = 0f;

		for(int i = 0; i < count; ++i)
		{
			var elem = finalList[i];

			if(elem.HasValue)
				sum += elem.Value;
		}

		FlinqListPool<Nullable<float>>.Return(finalList);

		return sum;
	}

	public static decimal Sum<T>(this FlinqQuery<T> query, Func<T, decimal> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.Count;

		decimal sum = 0;

		for(int i = 0; i < count; ++i)
		{
			sum += selector(finalList[i]);
		}

		FlinqListPool<T>.Return(finalList);

		return sum;
	}

	public static Nullable<decimal> Sum<T>(this FlinqQuery<T> query, Func<T, Nullable<decimal>> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.Count;

		decimal sum = 0;

		for(int i = 0; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem.HasValue)
				sum += elem.Value;
		}

		FlinqListPool<T>.Return(finalList);

		return sum;
	}

	public static double Sum<T>(this FlinqQuery<T> query, Func<T, double> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.Count;

		double sum = 0.0;

		for(int i = 0; i < count; ++i)
		{
			sum += selector(finalList[i]);
		}

		FlinqListPool<T>.Return(finalList);

		return sum;
	}

	public static Nullable<double> Sum<T>(this FlinqQuery<T> query, Func<T, Nullable<double>> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.Count;

		double sum = 0.0;

		for(int i = 0; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem.HasValue)
				sum += elem.Value;
		}

		FlinqListPool<T>.Return(finalList);

		return sum;
	}

	public static int Sum<T>(this FlinqQuery<T> query, Func<T, int> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.Count;

		int sum = 0;

		for(int i = 0; i < count; ++i)
		{
			sum += selector(finalList[i]);
		}

		FlinqListPool<T>.Return(finalList);

		return sum;
	}

	public static Nullable<int> Sum<T>(this FlinqQuery<T> query, Func<T, Nullable<int>> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.Count;

		int sum = 0;

		for(int i = 0; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem.HasValue)
				sum += elem.Value;
		}

		FlinqListPool<T>.Return(finalList);

		return sum;
	}

	public static long Sum<T>(this FlinqQuery<T> query, Func<T, long> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.Count;

		long sum = 0;

		for(int i = 0; i < count; ++i)
		{
			sum += selector(finalList[i]);
		}

		FlinqListPool<T>.Return(finalList);

		return sum;
	}

	public static Nullable<long> Sum<T>(this FlinqQuery<T> query, Func<T, Nullable<long>> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.Count;

		long sum = 0;

		for(int i = 0; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem.HasValue)
				sum += elem.Value;
		}

		FlinqListPool<T>.Return(finalList);

		return sum;
	}

	public static float Sum<T>(this FlinqQuery<T> query, Func<T, float> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.Count;

		float sum = 0f;

		for(int i = 0; i < count; ++i)
		{
			sum += selector(finalList[i]);
		}

		FlinqListPool<T>.Return(finalList);

		return sum;
	}

	public static Nullable<float> Sum<T>(this FlinqQuery<T> query, Func<T, Nullable<float>> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.Count;

		float sum = 0f;

		for(int i = 0; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem.HasValue)
				sum += elem.Value;
		}

		FlinqListPool<T>.Return(finalList);

		return sum;
	}
}

}