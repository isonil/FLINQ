using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flinq
{

public static class FlinqArgList<T>
{
	private static FlinqList<T> args = new FlinqList<T>();
	public static FlinqList<int> nextArgIndices = new FlinqList<int>(); // caller must know of what type, so he knows where to look for the next arg

	static FlinqArgList()
	{
		// TODO: do not use FlinqPools

		FlinqPools.AddReturnAllObjectsAction(() =>
			{
				args.Clear();
				nextArgIndices.Clear();
			});

		FlinqPools.AddResetAction(() =>
			{
				args.Clear();
				nextArgIndices.Clear();
			});
	}

	// call this if you expect there to be more arguments
	public static T Get(ref int argIndex)
	{
		int prevArgIndex = argIndex;

		argIndex = nextArgIndices.array[argIndex];

		return args.array[prevArgIndex];
	}

	// call this if it's the last argument
	public static T Get(int argIndex)
	{
		return args.array[argIndex];
	}

	public static int Add(T argument, int nextArgumentIndex)
	{
		args.Add(argument);
		nextArgIndices.Add(nextArgumentIndex);

		return args.count - 1;
	}

	public static int Add(T argument)
	{
		args.Add(argument);
		nextArgIndices.Add(-1);

		return args.count - 1;
	}
}

}
