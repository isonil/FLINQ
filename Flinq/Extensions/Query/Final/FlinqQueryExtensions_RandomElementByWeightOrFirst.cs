using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqQueryExtensions_RandomElementByWeightOrFirst
{
	public static T RandomElementByWeightOrFirst<T>(this FlinqQuery<T> query, Func<T, float> weightSelector)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(weightSelector == null)
			throw new ArgumentNullException("weightSelector");
		var finalList = query.Resolve();

		int count = finalList.Count;

		if(count == 0)
		{
			FlinqListPool<T>.Return(finalList);
			throw new InvalidOperationException("No elements.");
		}

		float sum = 0f;

		for(int i = 0; i < count; ++i)
		{
			float weight = weightSelector(finalList[i]);

			if(weight < 0f)
			{
				FlinqListPool<T>.Return(finalList);
				throw new InvalidOperationException("Element with negative weight.");
			}

			sum += weight;
		}

		if(sum == 0f)
		{
			var first = finalList[0];
			FlinqListPool<T>.Return(finalList);

			return first;
		}

		float randomValue = FlinqRandomNumberGenerator.Float01() * sum;

		sum = 0f;
		bool found = false;
		T ret = default(T);

		for(int i = 0; i < count; ++i)
		{
			var element = finalList[i];

			float weight = weightSelector(finalList[i]);

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

	public static T RandomElementByWeightOrFirst<T>(this FlinqQuery<T> query, Func<T, float> weightSelector, Func<float> float01)
	{
		if(query == null)
			throw new ArgumentNullException("query");

		if(weightSelector == null)
			throw new ArgumentNullException("weightSelector");

		if(float01 == null)
			throw new ArgumentNullException("float01");
		var finalList = query.Resolve();

		int count = finalList.Count;

		if(count == 0)
		{
			FlinqListPool<T>.Return(finalList);
			throw new InvalidOperationException("No elements.");
		}

		float sum = 0f;

		for(int i = 0; i < count; ++i)
		{
			float weight = weightSelector(finalList[i]);

			if(weight < 0f)
			{
				FlinqListPool<T>.Return(finalList);
				throw new InvalidOperationException("Element with negative weight.");
			}

			sum += weight;
		}

		if(sum == 0f)
		{
			var first = finalList[0];
			FlinqListPool<T>.Return(finalList);

			return first;
		}

		float randomValue = float01() * sum;

		sum = 0f;
		bool found = false;
		T ret = default(T);

		for(int i = 0; i < count; ++i)
		{
			var element = finalList[i];

			float weight = weightSelector(finalList[i]);

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