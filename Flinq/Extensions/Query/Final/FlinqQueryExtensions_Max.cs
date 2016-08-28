using System;
using System.Collections;

namespace Flinq
{

public static class FlinqQueryExtensions_Max
{
	public static decimal Max(this FlinqQuery<decimal> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		decimal maxElem = array[0];

		for(int i = 1; i < count; ++i)
		{
			var elem = array[i];

			if(elem > maxElem)
				maxElem = elem;
		}

		FlinqListPool<decimal>.Return(finalList);

		return maxElem;
	}

	public static Nullable<decimal> Max(this FlinqQuery<Nullable<decimal>> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		decimal maxElem = 0;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = array[i];

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

		FlinqListPool<Nullable<decimal>>.Return(finalList);

		if(found)
			return maxElem;

		return null;
	}

	public static double Max(this FlinqQuery<double> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		double maxElem = array[0];

		for(int i = 1; i < count; ++i)
		{
			var elem = array[i];

			if(elem > maxElem)
				maxElem = elem;
		}

		FlinqListPool<double>.Return(finalList);

		return maxElem;
	}

	public static Nullable<double> Max(this FlinqQuery<Nullable<double>> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		double maxElem = 0.0;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = array[i];

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

		FlinqListPool<Nullable<double>>.Return(finalList);

		if(found)
			return maxElem;

		return null;
	}

	public static int Max(this FlinqQuery<int> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		int maxElem = array[0];

		for(int i = 1; i < count; ++i)
		{
			var elem = array[i];

			if(elem > maxElem)
				maxElem = elem;
		}

		FlinqListPool<int>.Return(finalList);

		return maxElem;
	}

	public static Nullable<int> Max(this FlinqQuery<Nullable<int>> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		int maxElem = 0;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = array[i];

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

		FlinqListPool<Nullable<int>>.Return(finalList);

		if(found)
			return maxElem;

		return null;
	}

	public static long Max(this FlinqQuery<long> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		long maxElem = array[0];

		for(int i = 1; i < count; ++i)
		{
			var elem = array[i];

			if(elem > maxElem)
				maxElem = elem;
		}

		FlinqListPool<long>.Return(finalList);

		return maxElem;
	}

	public static Nullable<long> Max(this FlinqQuery<Nullable<long>> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		long maxElem = 0;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = array[i];

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

		FlinqListPool<Nullable<long>>.Return(finalList);

		if(found)
			return maxElem;

		return null;
	}

	public static float Max(this FlinqQuery<float> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		float maxElem = array[0];

		for(int i = 1; i < count; ++i)
		{
			var elem = array[i];

			if(elem > maxElem)
				maxElem = elem;
		}

		FlinqListPool<float>.Return(finalList);

		return maxElem;
	}

	public static Nullable<float> Max(this FlinqQuery<Nullable<float>> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		float maxElem = 0f;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = array[i];

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

		FlinqListPool<Nullable<float>>.Return(finalList);

		if(found)
			return maxElem;

		return null;
	}

	public static T Max<T>(this FlinqQuery<T> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		T maxElem = default(T);
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = array[i];

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

		FlinqListPool<T>.Return(finalList);

		if(found)
			return maxElem;

		return default(T);
	}

	public static TResult Max<T, TResult>(this FlinqQuery<T> query, Func<T, TResult> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		TResult maxElem = default(TResult);
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = selector(array[i]);

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

		FlinqListPool<T>.Return(finalList);

		if(found)
			return maxElem;

		return default(TResult);
	}

	public static decimal Max<T>(this FlinqQuery<T> query, Func<T, decimal> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		decimal maxElem = selector(array[0]);

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem > maxElem)
				maxElem = elem;
		}

		FlinqListPool<T>.Return(finalList);

		return maxElem;
	}

	public static Nullable<decimal> Max<T>(this FlinqQuery<T> query, Func<T, Nullable<decimal>> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		decimal maxElem = 0;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = selector(array[i]);

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

		FlinqListPool<T>.Return(finalList);

		if(found)
			return maxElem;

		return null;
	}

	public static double Max<T>(this FlinqQuery<T> query, Func<T, double> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		double maxElem = selector(array[0]);

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem > maxElem)
				maxElem = elem;
		}

		FlinqListPool<T>.Return(finalList);

		return maxElem;
	}

	public static Nullable<double> Max<T>(this FlinqQuery<T> query, Func<T, Nullable<double>> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		double maxElem = 0.0;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = selector(array[i]);

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

		FlinqListPool<T>.Return(finalList);

		if(found)
			return maxElem;

		return null;
	}

	public static int Max<T>(this FlinqQuery<T> query, Func<T, int> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		int maxElem = selector(array[0]);

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem > maxElem)
				maxElem = elem;
		}

		FlinqListPool<T>.Return(finalList);

		return maxElem;
	}

	public static Nullable<int> Max<T>(this FlinqQuery<T> query, Func<T, Nullable<int>> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		int maxElem = 0;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = selector(array[i]);

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

		FlinqListPool<T>.Return(finalList);

		if(found)
			return maxElem;

		return null;
	}

	public static long Max<T>(this FlinqQuery<T> query, Func<T, long> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		long maxElem = selector(array[0]);

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem > maxElem)
				maxElem = elem;
		}

		FlinqListPool<T>.Return(finalList);

		return maxElem;
	}

	public static Nullable<long> Max<T>(this FlinqQuery<T> query, Func<T, Nullable<long>> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		long maxElem = 0;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = selector(array[i]);

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

		FlinqListPool<T>.Return(finalList);

		if(found)
			return maxElem;

		return null;
	}

	public static float Max<T>(this FlinqQuery<T> query, Func<T, float> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		float maxElem = selector(array[0]);

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem > maxElem)
				maxElem = elem;
		}

		FlinqListPool<T>.Return(finalList);

		return maxElem;
	}

	public static Nullable<float> Max<T>(this FlinqQuery<T> query, Func<T, Nullable<float>> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		float maxElem = 0f;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = selector(array[i]);

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

		FlinqListPool<T>.Return(finalList);

		if(found)
			return maxElem;

		return null;
	}
}

}