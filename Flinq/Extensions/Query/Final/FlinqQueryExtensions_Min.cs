using System;
using System.Collections;

namespace Flinq
{

public static class FlinqQueryExtensions_Min
{
	public static decimal Min(this FlinqQuery<decimal> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		decimal minElem = finalList[0];

		for(int i = 1; i < count; ++i)
		{
			var elem = finalList[i];

			if(elem < minElem)
				minElem = elem;
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return minElem;
	}

	public static Nullable<decimal> Min(this FlinqQuery<Nullable<decimal>> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		decimal minElem = 0;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = finalList[i];

			if(elem.HasValue)
			{
				var val = elem.Value;

				if(!found || val < minElem)
				{
					minElem = val;
					found = true;
				}
			}
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		if(found)
			return minElem;

		return null;
	}

	public static double Min(this FlinqQuery<double> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		double minElem = finalList[0];

		for(int i = 1; i < count; ++i)
		{
			var elem = finalList[i];

			if(elem < minElem)
				minElem = elem;
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return minElem;
	}

	public static Nullable<double> Min(this FlinqQuery<Nullable<double>> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		double minElem = 0.0;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = finalList[i];

			if(elem.HasValue)
			{
				var val = elem.Value;

				if(!found || val < minElem)
				{
					minElem = val;
					found = true;
				}
			}
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		if(found)
			return minElem;

		return null;
	}

	public static int Min(this FlinqQuery<int> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		int minElem = finalList[0];

		for(int i = 1; i < count; ++i)
		{
			var elem = finalList[i];

			if(elem < minElem)
				minElem = elem;
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return minElem;
	}

	public static Nullable<int> Min(this FlinqQuery<Nullable<int>> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		int minElem = 0;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = finalList[i];

			if(elem.HasValue)
			{
				var val = elem.Value;

				if(!found || val < minElem)
				{
					minElem = val;
					found = true;
				}
			}
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		if(found)
			return minElem;

		return null;
	}

	public static long Min(this FlinqQuery<long> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		long minElem = finalList[0];

		for(int i = 1; i < count; ++i)
		{
			var elem = finalList[i];

			if(elem < minElem)
				minElem = elem;
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return minElem;
	}

	public static Nullable<long> Min(this FlinqQuery<Nullable<long>> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		long minElem = 0;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = finalList[i];

			if(elem.HasValue)
			{
				var val = elem.Value;

				if(!found || val < minElem)
				{
					minElem = val;
					found = true;
				}
			}
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		if(found)
			return minElem;

		return null;
	}

	public static float Min(this FlinqQuery<float> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		float minElem = finalList[0];

		for(int i = 1; i < count; ++i)
		{
			var elem = finalList[i];

			if(elem < minElem)
				minElem = elem;
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return minElem;
	}

	public static Nullable<float> Min(this FlinqQuery<Nullable<float>> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		float minElem = 0f;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = finalList[i];

			if(elem.HasValue)
			{
				var val = elem.Value;

				if(!found || val < minElem)
				{
					minElem = val;
					found = true;
				}
			}
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		if(found)
			return minElem;

		return null;
	}

	public static T Min<T>(this FlinqQuery<T> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		T minElem = default(T);
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = finalList[i];

			if(elem != null)
			{
				if(found)
				{
					var c1 = elem as IComparable<T>;

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
				else
				{
					minElem = elem;
					found = true;
				}
			}
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		if(found)
			return minElem;

		return default(T);
	}
	
	public static TResult Min<T, TResult>(this FlinqQuery<T> query, Func<T, TResult> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		TResult minElem = default(TResult);
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem != null)
			{
				if(found)
				{
					var c1 = elem as IComparable<TResult>;

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
				else
				{
					minElem = elem;
					found = true;
				}
			}
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		if(found)
			return minElem;

		return default(TResult);
	}

	public static decimal Min<T>(this FlinqQuery<T> query, Func<T, decimal> selector)
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

		decimal minElem = selector(finalList[0]);

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem < minElem)
				minElem = elem;
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return minElem;
	}

	public static Nullable<decimal> Min<T>(this FlinqQuery<T> query, Func<T, Nullable<decimal>> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		decimal minElem = 0;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem.HasValue)
			{
				var val = elem.Value;

				if(!found || val < minElem)
				{
					minElem = val;
					found = true;
				}
			}
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		if(found)
			return minElem;

		return null;
	}

	public static double Min<T>(this FlinqQuery<T> query, Func<T, double> selector)
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

		double minElem = selector(finalList[0]);

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem < minElem)
				minElem = elem;
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return minElem;
	}

	public static Nullable<double> Min<T>(this FlinqQuery<T> query, Func<T, Nullable<double>> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		double minElem = 0.0;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem.HasValue)
			{
				var val = elem.Value;

				if(!found || val < minElem)
				{
					minElem = val;
					found = true;
				}
			}
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		if(found)
			return minElem;

		return null;
	}

	public static int Min<T>(this FlinqQuery<T> query, Func<T, int> selector)
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

		int minElem = selector(finalList[0]);

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem < minElem)
				minElem = elem;
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return minElem;
	}

	public static Nullable<int> Min<T>(this FlinqQuery<T> query, Func<T, Nullable<int>> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		int minElem = 0;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem.HasValue)
			{
				var val = elem.Value;

				if(!found || val < minElem)
				{
					minElem = val;
					found = true;
				}
			}
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		if(found)
			return minElem;

		return null;
	}

	public static long Min<T>(this FlinqQuery<T> query, Func<T, long> selector)
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

		long minElem = selector(finalList[0]);

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem < minElem)
				minElem = elem;
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return minElem;
	}

	public static Nullable<long> Min<T>(this FlinqQuery<T> query, Func<T, Nullable<long>> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		long minElem = 0;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem.HasValue)
			{
				var val = elem.Value;

				if(!found || val < minElem)
				{
					minElem = val;
					found = true;
				}
			}
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		if(found)
			return minElem;

		return null;
	}

	public static float Min<T>(this FlinqQuery<T> query, Func<T, float> selector)
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

		float minElem = selector(finalList[0]);

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem < minElem)
				minElem = elem;
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return minElem;
	}

	public static Nullable<float> Min<T>(this FlinqQuery<T> query, Func<T, Nullable<float>> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		float minElem = 0f;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem.HasValue)
			{
				var val = elem.Value;

				if(!found || val < minElem)
				{
					minElem = val;
					found = true;
				}
			}
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		if(found)
			return minElem;

		return null;
	}
}

}