using System;
using System.Collections;

namespace Flinq
{

public static class FlinqQueryExtensions_MinBy
{
	public static T MinBy<T>(this FlinqQuery<T> query, Func<T, decimal> selector)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		decimal minElem = selector(array[0]);
		int minIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem < minElem)
			{
				minElem = elem;
				minIndex = i;
			}
		}

		var ret = array[minIndex];

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static T MinBy<T>(this FlinqQuery<T> query, Func<T, Nullable<decimal>> selector)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		decimal minElem = 0;
		int minIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem.HasValue && elem < minElem)
			{
				minElem = elem.Value;
				minIndex = i;
			}
		}

		var ret = array[minIndex];

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static T MinBy<T>(this FlinqQuery<T> query, Func<T, double> selector)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		double minElem = selector(array[0]);
		int minIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem < minElem)
			{
				minElem = elem;
				minIndex = i;
			}
		}

		var ret = array[minIndex];

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static T MinBy<T>(this FlinqQuery<T> query, Func<T, Nullable<double>> selector)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		double minElem = 0.0;
		int minIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem.HasValue && elem < minElem)
			{
				minElem = elem.Value;
				minIndex = i;
			}
		}

		var ret = array[minIndex];

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static T MinBy<T>(this FlinqQuery<T> query, Func<T, int> selector)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		int minElem = selector(array[0]);
		int minIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem < minElem)
			{
				minElem = elem;
				minIndex = i;
			}
		}

		var ret = array[minIndex];

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static T MinBy<T>(this FlinqQuery<T> query, Func<T, Nullable<int>> selector)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		int minElem = 0;
		int minIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem.HasValue && elem < minElem)
			{
				minElem = elem.Value;
				minIndex = i;
			}
		}

		var ret = array[minIndex];

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static T MinBy<T>(this FlinqQuery<T> query, Func<T, long> selector)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		long minElem = selector(array[0]);
		int minIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem < minElem)
			{
				minElem = elem;
				minIndex = i;
			}
		}

		var ret = array[minIndex];

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static T MinBy<T>(this FlinqQuery<T> query, Func<T, Nullable<long>> selector)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		long minElem = 0;
		int minIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem.HasValue && elem < minElem)
			{
				minElem = elem.Value;
				minIndex = i;
			}
		}

		var ret = array[minIndex];

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static T MinBy<T>(this FlinqQuery<T> query, Func<T, float> selector)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		float minElem = selector(array[0]);
		int minIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem < minElem)
			{
				minElem = elem;
				minIndex = i;
			}
		}

		var ret = array[minIndex];

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static T MinBy<T>(this FlinqQuery<T> query, Func<T, Nullable<float>> selector)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		float minElem = 0f;
		int minIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem.HasValue && elem < minElem)
			{
				minElem = elem.Value;
				minIndex = i;
			}
		}

		var ret = array[minIndex];

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static T MinBy<T, TMinBy>(this FlinqQuery<T> query, Func<T, TMinBy> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		TMinBy minElem = selector(array[0]);
		int minIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem != null)
			{
				var c1 = elem as IComparable<TMinBy>;

				if(c1 != null)
				{
					if(c1.CompareTo(minElem) < 0)
						minElem = elem;
				}
				else
				{
					var c2 = elem as IComparable;

					if(c2 != null)
					{
						if(c2.CompareTo(minElem) < 0)
							minElem = elem;
					}
				}
			}
		}

		var ret = array[minIndex];

		FlinqListPool<T>.Return(finalList);

		return ret;
	}
}

}