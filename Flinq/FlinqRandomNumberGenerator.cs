using System;
using System.Collections;

namespace Flinq
{

public static class FlinqRandomNumberGenerator
{
	private static Func<int, int, int> intRangeInclusive = DefaultIntRangeInclusive;
	private static Func<float> float01 = DefaultFloat01;
	private static Random random = new Random(DateTime.Now.GetHashCode());

	internal static Func<int, int, int> IntRangeInclusive { get { return intRangeInclusive; } }
	internal static Func<float> Float01 { get { return float01; } }

	public static void Set(Func<int, int, int> intRangeInclusive, Func<float> float01)
	{
		FlinqRandomNumberGenerator.intRangeInclusive = intRangeInclusive;
		FlinqRandomNumberGenerator.float01 = float01;
	}

	private static int DefaultIntRangeInclusive(int from, int to)
	{
		return random.Next(to - from + 1) + from;
	}

	private static float DefaultFloat01()
	{
		return (float)random.NextDouble();
	}
}

}