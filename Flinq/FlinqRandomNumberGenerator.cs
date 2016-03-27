using System;
using System.Collections;

namespace Flinq
{

public static class FlinqRandomNumberGenerator
{
	private static Func<int, int, int> intRangeInclusive;
	private static Func<float> float01;

	internal static Func<int, int, int> IntRangeInclusive
	{
		get
		{
			if(intRangeInclusive == null)
				throw new InvalidOperationException("No random number generator set for FLINQ.");

			return intRangeInclusive;
		}
	}

	internal static Func<float> Float01
	{
		get
		{
			if(float01 == null)
				throw new InvalidOperationException("No random number generator set for FLINQ.");

			return float01;
		}
	}

	public static void Set(Func<int, int, int> intRangeInclusive, Func<float> float01)
	{
		FlinqRandomNumberGenerator.intRangeInclusive = intRangeInclusive;
		FlinqRandomNumberGenerator.float01 = float01;
	}
}

}