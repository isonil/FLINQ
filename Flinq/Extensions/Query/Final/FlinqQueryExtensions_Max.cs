using System;
using System.Collections;

namespace Flinq
{

public static class FlinqQueryExtensions_Max
{
	public static decimal Max(this FlinqQuery<decimal> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		decimal maxElem = finalList[0];

		for(int i = 1; i < count; ++i)
		{
			var elem = finalList[i];

			if(elem > maxElem)
				maxElem = elem;
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return maxElem;
	}

	public static Nullable<decimal> Max(this FlinqQuery<Nullable<decimal>> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		decimal maxElem = 0;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = finalList[i];

			if(elem.HasValue)
			{
				var val = elem.Value;

				if(!found || val > maxElem)
				{
					maxElem = val;
					found = true;
				}
			}
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		if(found)
			return maxElem;

		return null;
	}

	public static double Max(this FlinqQuery<double> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		double maxElem = finalList[0];

		for(int i = 1; i < count; ++i)
		{
			var elem = finalList[i];

			if(elem > maxElem)
				maxElem = elem;
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return maxElem;
	}

	public static Nullable<double> Max(this FlinqQuery<Nullable<double>> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		double maxElem = 0.0;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = finalList[i];

			if(elem.HasValue)
			{
				var val = elem.Value;

				if(!found || val > maxElem)
				{
					maxElem = val;
					found = true;
				}
			}
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		if(found)
			return maxElem;

		return null;
	}

	public static int Max(this FlinqQuery<int> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		int maxElem = finalList[0];

		for(int i = 1; i < count; ++i)
		{
			var elem = finalList[i];

			if(elem > maxElem)
				maxElem = elem;
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return maxElem;
	}

	public static Nullable<int> Max(this FlinqQuery<Nullable<int>> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		int maxElem = 0;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = finalList[i];

			if(elem.HasValue)
			{
				var val = elem.Value;

				if(!found || val > maxElem)
				{
					maxElem = val;
					found = true;
				}
			}
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		if(found)
			return maxElem;

		return null;
	}

	public static long Max(this FlinqQuery<long> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		long maxElem = finalList[0];

		for(int i = 1; i < count; ++i)
		{
			var elem = finalList[i];

			if(elem > maxElem)
				maxElem = elem;
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return maxElem;
	}

	public static Nullable<long> Max(this FlinqQuery<Nullable<long>> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		long maxElem = 0;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = finalList[i];

			if(elem.HasValue)
			{
				var val = elem.Value;

				if(!found || val > maxElem)
				{
					maxElem = val;
					found = true;
				}
			}
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		if(found)
			return maxElem;

		return null;
	}

	public static float Max(this FlinqQuery<float> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		float maxElem = finalList[0];

		for(int i = 1; i < count; ++i)
		{
			var elem = finalList[i];

			if(elem > maxElem)
				maxElem = elem;
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return maxElem;
	}

	public static Nullable<float> Max(this FlinqQuery<Nullable<float>> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		float maxElem = 0f;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = finalList[i];

			if(elem.HasValue)
			{
				var val = elem.Value;

				if(!found || val > maxElem)
				{
					maxElem = val;
					found = true;
				}
			}
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		if(found)
			return maxElem;

		return null;
	}

	public static T Max<T>(this FlinqQuery<T> query)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		T maxElem = default(T);
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
				else
				{
					maxElem = elem;
					found = true;
				}
			}
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		if(found)
			return maxElem;

		return default(T);
	}

	public static TResult Max<T, TResult>(this FlinqQuery<T> query, Func<T, TResult> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		TResult maxElem = default(TResult);
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
				else
				{
					maxElem = elem;
					found = true;
				}
			}
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		if(found)
			return maxElem;

		return default(TResult);
	}

	public static decimal Max<T>(this FlinqQuery<T> query, Func<T, decimal> selector)
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

		decimal maxElem = selector(finalList[0]);

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem > maxElem)
				maxElem = elem;
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return maxElem;
	}

	public static Nullable<decimal> Max<T>(this FlinqQuery<T> query, Func<T, Nullable<decimal>> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		decimal maxElem = 0;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem.HasValue)
			{
				var val = elem.Value;

				if(!found || val > maxElem)
				{
					maxElem = val;
					found = true;
				}
			}
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		if(found)
			return maxElem;

		return null;
	}

	public static double Max<T>(this FlinqQuery<T> query, Func<T, double> selector)
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

		double maxElem = selector(finalList[0]);

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem > maxElem)
				maxElem = elem;
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return maxElem;
	}

	public static Nullable<double> Max<T>(this FlinqQuery<T> query, Func<T, Nullable<double>> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		double maxElem = 0.0;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem.HasValue)
			{
				var val = elem.Value;

				if(!found || val > maxElem)
				{
					maxElem = val;
					found = true;
				}
			}
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		if(found)
			return maxElem;

		return null;
	}

	public static int Max<T>(this FlinqQuery<T> query, Func<T, int> selector)
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

		int maxElem = selector(finalList[0]);

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem > maxElem)
				maxElem = elem;
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return maxElem;
	}

	public static Nullable<int> Max<T>(this FlinqQuery<T> query, Func<T, Nullable<int>> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		int maxElem = 0;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem.HasValue)
			{
				var val = elem.Value;

				if(!found || val > maxElem)
				{
					maxElem = val;
					found = true;
				}
			}
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		if(found)
			return maxElem;

		return null;
	}

	public static long Max<T>(this FlinqQuery<T> query, Func<T, long> selector)
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

		long maxElem = selector(finalList[0]);

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem > maxElem)
				maxElem = elem;
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return maxElem;
	}

	public static Nullable<long> Max<T>(this FlinqQuery<T> query, Func<T, Nullable<long>> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		long maxElem = 0;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem.HasValue)
			{
				var val = elem.Value;

				if(!found || val > maxElem)
				{
					maxElem = val;
					found = true;
				}
			}
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		if(found)
			return maxElem;

		return null;
	}

	public static float Max<T>(this FlinqQuery<T> query, Func<T, float> selector)
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

		float maxElem = selector(finalList[0]);

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem > maxElem)
				maxElem = elem;
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		return maxElem;
	}

	public static Nullable<float> Max<T>(this FlinqQuery<T> query, Func<T, Nullable<float>> selector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(selector == null)
			throw new ArgumentNullException("selector");

		bool returnToPool;

		var finalList = query.Resolve(int.MaxValue, out returnToPool);

		int count = finalList.Count;

		float maxElem = 0f;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = selector(finalList[i]);

			if(elem.HasValue)
			{
				var val = elem.Value;

				if(!found || val > maxElem)
				{
					maxElem = val;
					found = true;
				}
			}
		}

		query.CleanupAfterResolve(finalList, returnToPool);

		if(found)
			return maxElem;

		return null;
	}
}

}