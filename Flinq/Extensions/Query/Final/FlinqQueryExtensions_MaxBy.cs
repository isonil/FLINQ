using System;
using System.Collections;

namespace Flinq
{

public static class FlinqQueryExtensions_MaxBy
{
	public static T MaxBy<T>(this FlinqQuery<T> query, Func<T, decimal> selector)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		decimal maxElem = selector(array[0]);
		int maxIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem > maxElem)
			{
				maxElem = elem;
				maxIndex = i;
			}
		}

		var ret = array[maxIndex];

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static T MaxBy<T>(this FlinqQuery<T> query, Func<T, Nullable<decimal>> selector)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		decimal maxElem = 0;
		int maxIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem.HasValue && elem > maxElem)
			{
				maxElem = elem.Value;
				maxIndex = i;
			}
		}

		var ret = array[maxIndex];

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static T MaxBy<T>(this FlinqQuery<T> query, Func<T, double> selector)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		double maxElem = selector(array[0]);
		int maxIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem > maxElem)
			{
				maxElem = elem;
				maxIndex = i;
			}
		}

		var ret = array[maxIndex];

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static T MaxBy<T>(this FlinqQuery<T> query, Func<T, Nullable<double>> selector)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		double maxElem = 0.0;
		int maxIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem.HasValue && elem > maxElem)
			{
				maxElem = elem.Value;
				maxIndex = i;
			}
		}

		var ret = array[maxIndex];

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static T MaxBy<T>(this FlinqQuery<T> query, Func<T, int> selector)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		int maxElem = selector(array[0]);
		int maxIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem > maxElem)
			{
				maxElem = elem;
				maxIndex = i;
			}
		}

		var ret = array[maxIndex];

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static T MaxBy<T>(this FlinqQuery<T> query, Func<T, Nullable<int>> selector)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		int maxElem = 0;
		int maxIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem.HasValue && elem > maxElem)
			{
				maxElem = elem.Value;
				maxIndex = i;
			}
		}

		var ret = array[maxIndex];

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static T MaxBy<T>(this FlinqQuery<T> query, Func<T, long> selector)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		long maxElem = selector(array[0]);
		int maxIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem > maxElem)
			{
				maxElem = elem;
				maxIndex = i;
			}
		}

		var ret = array[maxIndex];

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static T MaxBy<T>(this FlinqQuery<T> query, Func<T, Nullable<long>> selector)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		long maxElem = 0;
		int maxIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem.HasValue && elem > maxElem)
			{
				maxElem = elem.Value;
				maxIndex = i;
			}
		}

		var ret = array[maxIndex];

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static T MaxBy<T>(this FlinqQuery<T> query, Func<T, float> selector)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		float maxElem = selector(array[0]);
		int maxIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem > maxElem)
			{
				maxElem = elem;
				maxIndex = i;
			}
		}

		var ret = array[maxIndex];

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static T MaxBy<T>(this FlinqQuery<T> query, Func<T, Nullable<float>> selector)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		float maxElem = 0f;
		int maxIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem.HasValue && elem > maxElem)
			{
				maxElem = elem.Value;
				maxIndex = i;
			}
		}

		var ret = array[maxIndex];

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static T MaxBy<T, TMaxBy>(this FlinqQuery<T> query, Func<T, TMaxBy> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		TMaxBy maxElem = selector(array[0]);
		int maxIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem != null)
			{
				var c1 = elem as IComparable<TMaxBy>;

				if(c1 != null)
				{
					if(c1.CompareTo(maxElem) > 0)
						maxElem = elem;
				}
				else
				{
					var c2 = elem as IComparable;

					if(c2 != null)
					{
						if(c2.CompareTo(maxElem) > 0)
							maxElem = elem;
					}
				}
			}
		}

		var ret = array[maxIndex];

		FlinqListPool<T>.Return(finalList);

		return ret;
	}
}

}