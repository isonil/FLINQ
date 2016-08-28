using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_RandomElementByWeight
{
	public static T RandomElementByWeight<T>(this FlinqQuery<T> query, Func<T, float> weightSelector)
	{
		if(weightSelector == null)
			throw new ArgumentNullException("weightSelector");

		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
		{
			FlinqListPool<T>.Return(finalList);
			throw new InvalidOperationException("No elements.");
		}

		var array = finalList.array;

		float sum = 0f;

		for(int i = 0; i < count; ++i)
		{
			float weight = weightSelector(array[i]);

			if(weight < 0f)
			{
				FlinqListPool<T>.Return(finalList);
				throw new InvalidOperationException("Element with negative weight.");
			}

			sum += weight;
		}

		if(sum == 0f)
		{
			FlinqListPool<T>.Return(finalList);
			throw new InvalidOperationException("No elements with non-zero weight.");
		}

		float randomValue = FlinqRandomNumberGenerator.Float01() * sum;

		sum = 0f;
		bool found = false;
		T ret = default(T);

		for(int i = 0; i < count; ++i)
		{
			var element = array[i];

			float weight = weightSelector(array[i]);

			if(weight == 0f)
				continue;

			sum += weight;

			if(randomValue <= sum)
			{
				ret = element;
				found = true;
				break;
			}
		}

		FlinqListPool<T>.Return(finalList);

		if(!found)
			throw new InvalidOperationException("Random number generator problem.");

		return ret;
	}

	public static T RandomElementByWeight<T>(this FlinqQuery<T> query, Func<T, float> weightSelector, Func<float> float01)
	{
		if(weightSelector == null)
			throw new ArgumentNullException("weightSelector");

		if(float01 == null)
			throw new ArgumentNullException("float01");

		var finalList = query.Resolve();

		int count = finalList.count;

		if(count == 0)
		{
			FlinqListPool<T>.Return(finalList);
			throw new InvalidOperationException("No elements.");
		}

		var array = finalList.array;

		float sum = 0f;

		for(int i = 0; i < count; ++i)
		{
			float weight = weightSelector(array[i]);

			if(weight < 0f)
			{
				FlinqListPool<T>.Return(finalList);
				throw new InvalidOperationException("Element with negative weight.");
			}

			sum += weight;
		}

		if(sum == 0f)
		{
			FlinqListPool<T>.Return(finalList);
			throw new InvalidOperationException("No elements with non-zero weight.");
		}

		float randomValue = float01() * sum;

		sum = 0f;
		bool found = false;
		T ret = default(T);

		for(int i = 0; i < count; ++i)
		{
			var element = array[i];

			float weight = weightSelector(array[i]);

			if(weight == 0f)
				continue;

			sum += weight;

			if(randomValue <= sum)
			{
				ret = element;
				found = true;
				break;
			}
		}

		FlinqListPool<T>.Return(finalList);

		if(!found)
			throw new InvalidOperationException("Random number generator problem.");

		return ret;
	}
}

}