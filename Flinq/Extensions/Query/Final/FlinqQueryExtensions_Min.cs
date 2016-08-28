using System;
using System.Collections;

namespace Flinq
{

public static class FlinqQueryExtensions_Min
{
	public static decimal Min(this FlinqQuery<decimal> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		decimal minElem = array[0];

		for(int i = 1; i < count; ++i)
		{
			var elem = array[i];

			if(elem < minElem)
				minElem = elem;
		}

		FlinqListPool<decimal>.Return(finalList);

		return minElem;
	}

	public static Nullable<decimal> Min(this FlinqQuery<Nullable<decimal>> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		decimal minElem = 0;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = array[i];

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

		FlinqListPool<Nullable<decimal>>.Return(finalList);

		if(found)
			return minElem;

		return null;
	}

	public static double Min(this FlinqQuery<double> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		double minElem = array[0];

		for(int i = 1; i < count; ++i)
		{
			var elem = array[i];

			if(elem < minElem)
				minElem = elem;
		}

		FlinqListPool<double>.Return(finalList);

		return minElem;
	}

	public static Nullable<double> Min(this FlinqQuery<Nullable<double>> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		double minElem = 0.0;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = array[i];

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

		FlinqListPool<Nullable<double>>.Return(finalList);

		if(found)
			return minElem;

		return null;
	}

	public static int Min(this FlinqQuery<int> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		int minElem = array[0];

		for(int i = 1; i < count; ++i)
		{
			var elem = array[i];

			if(elem < minElem)
				minElem = elem;
		}

		FlinqListPool<int>.Return(finalList);

		return minElem;
	}

	public static Nullable<int> Min(this FlinqQuery<Nullable<int>> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		int minElem = 0;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = array[i];

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

		FlinqListPool<Nullable<int>>.Return(finalList);

		if(found)
			return minElem;

		return null;
	}

	public static long Min(this FlinqQuery<long> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		long minElem = array[0];

		for(int i = 1; i < count; ++i)
		{
			var elem = array[i];

			if(elem < minElem)
				minElem = elem;
		}

		FlinqListPool<long>.Return(finalList);

		return minElem;
	}

	public static Nullable<long> Min(this FlinqQuery<Nullable<long>> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		long minElem = 0;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = array[i];

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

		FlinqListPool<Nullable<long>>.Return(finalList);

		if(found)
			return minElem;

		return null;
	}

	public static float Min(this FlinqQuery<float> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		float minElem = array[0];

		for(int i = 1; i < count; ++i)
		{
			var elem = array[i];

			if(elem < minElem)
				minElem = elem;
		}

		FlinqListPool<float>.Return(finalList);

		return minElem;
	}

	public static Nullable<float> Min(this FlinqQuery<Nullable<float>> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		float minElem = 0f;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = array[i];

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

		FlinqListPool<Nullable<float>>.Return(finalList);

		if(found)
			return minElem;

		return null;
	}

	public static T Min<T>(this FlinqQuery<T> query)
	{
		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		T minElem = default(T);
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

		FlinqListPool<T>.Return(finalList);

		if(found)
			return minElem;

		return default(T);
	}
	
	public static TResult Min<T, TResult>(this FlinqQuery<T> query, Func<T, TResult> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		TResult minElem = default(TResult);
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

		FlinqListPool<T>.Return(finalList);

		if(found)
			return minElem;

		return default(TResult);
	}

	public static decimal Min<T>(this FlinqQuery<T> query, Func<T, decimal> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		decimal minElem = selector(array[0]);

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem < minElem)
				minElem = elem;
		}

		FlinqListPool<T>.Return(finalList);

		return minElem;
	}

	public static Nullable<decimal> Min<T>(this FlinqQuery<T> query, Func<T, Nullable<decimal>> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		decimal minElem = 0;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = selector(array[i]);

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

		FlinqListPool<T>.Return(finalList);

		if(found)
			return minElem;

		return null;
	}

	public static double Min<T>(this FlinqQuery<T> query, Func<T, double> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		double minElem = selector(array[0]);

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem < minElem)
				minElem = elem;
		}

		FlinqListPool<T>.Return(finalList);

		return minElem;
	}

	public static Nullable<double> Min<T>(this FlinqQuery<T> query, Func<T, Nullable<double>> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		double minElem = 0.0;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = selector(array[i]);

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

		FlinqListPool<T>.Return(finalList);

		if(found)
			return minElem;

		return null;
	}

	public static int Min<T>(this FlinqQuery<T> query, Func<T, int> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		int minElem = selector(array[0]);

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem < minElem)
				minElem = elem;
		}

		FlinqListPool<T>.Return(finalList);

		return minElem;
	}

	public static Nullable<int> Min<T>(this FlinqQuery<T> query, Func<T, Nullable<int>> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		int minElem = 0;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = selector(array[i]);

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

		FlinqListPool<T>.Return(finalList);

		if(found)
			return minElem;

		return null;
	}

	public static long Min<T>(this FlinqQuery<T> query, Func<T, long> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		long minElem = selector(array[0]);

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem < minElem)
				minElem = elem;
		}

		FlinqListPool<T>.Return(finalList);

		return minElem;
	}

	public static Nullable<long> Min<T>(this FlinqQuery<T> query, Func<T, Nullable<long>> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		long minElem = 0;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = selector(array[i]);

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

		FlinqListPool<T>.Return(finalList);

		if(found)
			return minElem;

		return null;
	}

	public static float Min<T>(this FlinqQuery<T> query, Func<T, float> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
			throw new InvalidOperationException("No elements.");

		var array = finalList.array;

		float minElem = selector(array[0]);

		for(int i = 1; i < count; ++i)
		{
			var elem = selector(array[i]);

			if(elem < minElem)
				minElem = elem;
		}

		FlinqListPool<T>.Return(finalList);

		return minElem;
	}

	public static Nullable<float> Min<T>(this FlinqQuery<T> query, Func<T, Nullable<float>> selector)
	{
		if(selector == null)
			throw new ArgumentNullException("selector");

		var finalList = query.Resolve();

		int count = finalList.count;
		var array = finalList.array;

		float minElem = 0f;
		bool found = false;

		for(int i = 0; i < count; ++i)
		{
			var elem = selector(array[i]);

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

		FlinqListPool<T>.Return(finalList);

		if(found)
			return minElem;

		return null;
	}
}

}