using System;
using System.Collections;
using System.Collections.Generic;

namespace Flinq
{

public class FlinqOperation_Except<T> : FlinqOperation<T>
{
	private FlinqQuery<T> except;

	public void OnInit(FlinqQuery<T> except)
	{
		this.except = except;
	}

	public override void Transform(List<T> list, int wantedElementsCount)
	{
		var hashSet = FlinqHashSetPool<T>.Get();

		bool returnToPool;
		var exceptFinalList = except.Resolve(int.MaxValue, out returnToPool);

		int exceptCount = exceptFinalList.Count;

		for(int i = 0; i < exceptCount; ++i)
		{
			hashSet.Add(exceptFinalList[i]);
		}

		except.CleanupAfterResolve(exceptFinalList, returnToPool);

		int count = list.Count;

		// RemoveAll is faster for large lists, see FlinqOperation_Where for more information

		if(count > 500 && wantedElementsCount >= count)
			list.RemoveAll(x => hashSet.Contains(x));
		else
		{
			int alreadyFound = 0;

			for(int i = 0; i < count; ++i)
			{
				var elem = list[i];

				if(!hashSet.Contains(elem))
				{
					list.Add(elem);

					++alreadyFound;

					if(alreadyFound >= wantedElementsCount)
						break;
				}
			}

			list.RemoveRange(0, count);
		}

		FlinqHashSetPool<T>.Return(hashSet);
	}

	public override bool RequiresFullListToWorkOn { get { return false; } }
}

}