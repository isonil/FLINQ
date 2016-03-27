using System;
using System.Collections;

namespace Flinq
{

public static class FlinqQueryExtensions_MaxBy
{
	public static T MaxBy<T>(this FlinqQuery<T> query, Func<T, decimal> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		decimal maxElem = selector(finalList[0]);
		int maxIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem > maxElem)
			{
				maxElem = elem;
				maxIndex = i;
			}
		}

		var ret = finalList[maxIndex];

		query.CleanupAfterResolve(finalList, returnToPool);

		return ret;
	}

	public static T MaxBy<T>(this FlinqQuery<T> query, Func<T, Nullable<decimal>> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		decimal maxElem = 0;
		int maxIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem.HasValue && elem > maxElem)
			{
				maxElem = elem.Value;
				maxIndex = i;
			}
		}

		var ret = finalList[maxIndex];

		query.CleanupAfterResolve(finalList, returnToPool);

		return ret;
	}

	public static T MaxBy<T>(this FlinqQuery<T> query, Func<T, double> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		double maxElem = selector(finalList[0]);
		int maxIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem > maxElem)
			{
				maxElem = elem;
				maxIndex = i;
			}
		}

		var ret = finalList[maxIndex];

		query.CleanupAfterResolve(finalList, returnToPool);

		return ret;
	}

	public static T MaxBy<T>(this FlinqQuery<T> query, Func<T, Nullable<double>> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		double maxElem = 0.0;
		int maxIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem.HasValue && elem > maxElem)
			{
				maxElem = elem.Value;
				maxIndex = i;
			}
		}

		var ret = finalList[maxIndex];

		query.CleanupAfterResolve(finalList, returnToPool);

		return ret;
	}

	public static T MaxBy<T>(this FlinqQuery<T> query, Func<T, int> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		int maxElem = selector(finalList[0]);
		int maxIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem > maxElem)
			{
				maxElem = elem;
				maxIndex = i;
			}
		}

		var ret = finalList[maxIndex];

		query.CleanupAfterResolve(finalList, returnToPool);

		return ret;
	}

	public static T MaxBy<T>(this FlinqQuery<T> query, Func<T, Nullable<int>> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		int maxElem = 0;
		int maxIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem.HasValue && elem > maxElem)
			{
				maxElem = elem.Value;
				maxIndex = i;
			}
		}

		var ret = finalList[maxIndex];

		query.CleanupAfterResolve(finalList, returnToPool);

		return ret;
	}

	public static T MaxBy<T>(this FlinqQuery<T> query, Func<T, long> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		long maxElem = selector(finalList[0]);
		int maxIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem > maxElem)
			{
				maxElem = elem;
				maxIndex = i;
			}
		}

		var ret = finalList[maxIndex];

		query.CleanupAfterResolve(finalList, returnToPool);

		return ret;
	}

	public static T MaxBy<T>(this FlinqQuery<T> query, Func<T, Nullable<long>> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		long maxElem = 0;
		int maxIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem.HasValue && elem > maxElem)
			{
				maxElem = elem.Value;
				maxIndex = i;
			}
		}

		var ret = finalList[maxIndex];

		query.CleanupAfterResolve(finalList, returnToPool);

		return ret;
	}

	public static T MaxBy<T>(this FlinqQuery<T> query, Func<T, float> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		float maxElem = selector(finalList[0]);
		int maxIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem > maxElem)
			{
				maxElem = elem;
				maxIndex = i;
			}
		}

		var ret = finalList[maxIndex];

		query.CleanupAfterResolve(finalList, returnToPool);

		return ret;
	}

	public static T MaxBy<T>(this FlinqQuery<T> query, Func<T, Nullable<float>> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		float maxElem = 0f;
		int maxIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem.HasValue && elem > maxElem)
			{
				maxElem = elem.Value;
				maxIndex = i;
			}
		}

		var ret = finalList[maxIndex];

		query.CleanupAfterResolve(finalList, returnToPool);

		return ret;
	}

	public static T MaxBy<T, TMaxBy>(this FlinqQuery<T> query, Func<T, TMaxBy> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		TMaxBy maxElem = selector(finalList[0]);
		int maxIndex = 0;

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(finalList[i]);

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

		var ret = finalList[maxIndex];

		query.CleanupAfterResolve(finalList, returnToPool);

		return ret;
	}
}

}