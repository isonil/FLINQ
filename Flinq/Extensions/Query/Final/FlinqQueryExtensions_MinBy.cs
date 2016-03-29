using System;
using System.Collections;

namespace Flinq
{

public static class FlinqQueryExtensions_MinBy
{
	public static T MinBy<T>(this FlinqQuery<T> query, Func<T, decimal> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var finalList = query.Resolve();

		int count = finalList.Count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		decimal minElem = selector(finalList[0]);
		int minIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem < minElem)
			{
				minElem = elem;
				minIndex = i;
			}
		}

		var ret = finalList[minIndex];

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static T MinBy<T>(this FlinqQuery<T> query, Func<T, Nullable<decimal>> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var finalList = query.Resolve();

		int count = finalList.Count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		decimal minElem = 0;
		int minIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem.HasValue && elem < minElem)
			{
				minElem = elem.Value;
				minIndex = i;
			}
		}

		var ret = finalList[minIndex];

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static T MinBy<T>(this FlinqQuery<T> query, Func<T, double> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var finalList = query.Resolve();

		int count = finalList.Count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		double minElem = selector(finalList[0]);
		int minIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem < minElem)
			{
				minElem = elem;
				minIndex = i;
			}
		}

		var ret = finalList[minIndex];

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static T MinBy<T>(this FlinqQuery<T> query, Func<T, Nullable<double>> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var finalList = query.Resolve();

		int count = finalList.Count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		double minElem = 0.0;
		int minIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem.HasValue && elem < minElem)
			{
				minElem = elem.Value;
				minIndex = i;
			}
		}

		var ret = finalList[minIndex];

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static T MinBy<T>(this FlinqQuery<T> query, Func<T, int> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var finalList = query.Resolve();

		int count = finalList.Count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		int minElem = selector(finalList[0]);
		int minIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem < minElem)
			{
				minElem = elem;
				minIndex = i;
			}
		}

		var ret = finalList[minIndex];

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static T MinBy<T>(this FlinqQuery<T> query, Func<T, Nullable<int>> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var finalList = query.Resolve();

		int count = finalList.Count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		int minElem = 0;
		int minIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem.HasValue && elem < minElem)
			{
				minElem = elem.Value;
				minIndex = i;
			}
		}

		var ret = finalList[minIndex];

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static T MinBy<T>(this FlinqQuery<T> query, Func<T, long> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var finalList = query.Resolve();

		int count = finalList.Count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		long minElem = selector(finalList[0]);
		int minIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem < minElem)
			{
				minElem = elem;
				minIndex = i;
			}
		}

		var ret = finalList[minIndex];

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static T MinBy<T>(this FlinqQuery<T> query, Func<T, Nullable<long>> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var finalList = query.Resolve();

		int count = finalList.Count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		long minElem = 0;
		int minIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem.HasValue && elem < minElem)
			{
				minElem = elem.Value;
				minIndex = i;
			}
		}

		var ret = finalList[minIndex];

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static T MinBy<T>(this FlinqQuery<T> query, Func<T, float> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var finalList = query.Resolve();

		int count = finalList.Count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		float minElem = selector(finalList[0]);
		int minIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem < minElem)
			{
				minElem = elem;
				minIndex = i;
			}
		}

		var ret = finalList[minIndex];

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static T MinBy<T>(this FlinqQuery<T> query, Func<T, Nullable<float>> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		var finalList = query.Resolve();

		int count = finalList.Count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		float minElem = 0f;
		int minIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem.HasValue && elem < minElem)
			{
				minElem = elem.Value;
				minIndex = i;
			}
		}

		var ret = finalList[minIndex];

		FlinqListPool<T>.Return(finalList);

		return ret;
	}

	public static T MinBy<T, TMinBy>(this FlinqQuery<T> query, Func<T, TMinBy> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.Count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		TMinBy minElem = selector(finalList[0]);
		int minIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(finalList[i]);

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

		var ret = finalList[minIndex];

		FlinqListPool<T>.Return(finalList);

		return ret;
	}
}

}