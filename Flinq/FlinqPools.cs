using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public static class FlinqPools
{
	private static List<Action> returnAllObjectsActions = new List<Action>();
	private static List<Action> resetActions = new List<Action>();

	public static void ReturnAllObjects()
	{
#if !NO_FLINQ_POOLS
		int count = returnAllObjectsActions.Count;

		for(int i = 0; i < count; ++i)
		{
			returnAllObjectsActions[i]();
		}
#endif
	}

	public static void Reset()
	{
#if !NO_FLINQ_POOLS
		int count = resetActions.Count;

		for(int i = 0; i < count; ++i)
		{
			resetActions[i]();
		}
#endif
	}

	internal static void AddReturnAllObjectsAction(Action action)
	{
#if !NO_FLINQ_POOLS
		returnAllObjectsActions.Add(action);
#endif
	}

	internal static void AddResetAction(Action action)
	{
#if !NO_FLINQ_POOLS
		resetActions.Add(action);
#endif
	}
}

}