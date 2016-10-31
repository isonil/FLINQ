using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
FlinqGrouping!!!! commented out
GroupBy and GroupJoin!!!! commented out
private static FlinqList<T> ImplCreate(object param) could be optimized by caching list.Add method

either make almost everything internal,
OR add Internal namespace

To add:
GetDuplicatesBy
AnyDuplicates
AnyDuplicatesBy
AnyExistIn
AnyExistInBy
ExistInBy
UnionBy
IntersectBy
IntersectLeaveDuplicates (?)
IntersectByLeaveDuplicates (?)
UnionByLeaveDuplicates (?)
SetsEqual
TakeEvery
DiscardEvery

some of the preceding queries could be done with simple operations... no need for preceding queries
(like DistinctBy I think?)

make sure we nullify every object on each iteration in the pool,
e.g. all selectors referenced by operations
to let GC collect objects

consider pooling FlinqQuery enumerators (and make them a class),
due to mono's boxing bug

call Array.Clear on all FlinqLists at the end of the frame! remember about those used by pools themselves...

everywhere where I do list.array in a loop because list.array can change: see if I can just update var array = list.array; local variable only when needed (this will help a bit performance-wise if I add to list only occassionally)

preceding query mem allocs could be optimized: use classes like ParamPack2 { object param1; object param2; } instead of arrays, maybe it will alloc less,
OR even better, add some kind of FlinqQuery_WithPrecedingQuery2 and FlinqQuery_WithPrecedingQuery3, etc. which would inherit from FlinqQuery

search for all usages of list.array (FlinqList) and see if it can't change in this context (e.g. I'm also adding something to the list)

check usages of FlinqList methods: TrueForAll, FindIndex, Find, FindLast, FindLastIndex, Contains, Exists and see if they cna be optimized in the context

ToList could be optimized by making FlinqList implement ICollection and IEnumerable I think

Min, MinBy, Max, MaxBy -> they all throw without returning final list to pool..., fix!

FlinqList should have 0 initial size I think

*/

namespace Flinq
{

class Foo
{
	public int x = 0;
}

class Program
{
	private static void TestKeepWhere()
	{
		var stopwatch = new System.Diagnostics.Stopwatch();

		FlinqList<Foo> list = new FlinqList<Foo>();

		for( int i = 0; i < 15; i++ )
		{
			list.Add(new Foo());
			list.array[list.count - 1].x = i;
		}

		stopwatch.Restart();

		for( int i = 0; i < 1000000; i++ )
		{
			list.KeepWhere(x => x.x != 0);
		}

		Console.WriteLine("KeepWhere: " + stopwatch.ElapsedMilliseconds);

		stopwatch.Restart();

		for( int i = 0; i < 1000000; i++ )
		{
			//list.KeepWhereAlt(x => x.x != 0);
		}

		Console.WriteLine("KeepWhereAlt: " + stopwatch.ElapsedMilliseconds);
	}

	static void Main(string[] args)
	{
		//TestKeepWhere();

		var stopwatch = new System.Diagnostics.Stopwatch();
		var stopwatch2 = new System.Diagnostics.Stopwatch();
		List<Foo> list = new List<Foo>();

		for( int i = 0; i < 15; i++ )
		{
			list.Add(new Foo());
			list[list.Count - 1].x = i;
		}

		stopwatch.Restart();
		int sum2 = 0;
		for( int i = 0; i < 1000; i++ )
		{
			for( int n = 0; n < 100; n++ )
			{
				//sum2 += list.AsEnumerable().Min(x => x.x);
				sum2 += list.AsEnumerable().Where(x => x.x != 0).Where(x => x.x != 0).Min(x => x.x);
				//sum2 += list.AsEnumerable().Where(x => x.x != 0).Last().x;
				//sum2 += list.AsEnumerable().Union(list).Distinct().Last().x;

				/*
				foreach( var elem in list.AsEnumerable().Where(x => x.x % 2 == 0).Where(x => x.x % 2 == 0) )
				{
					sum2 += elem.x;
				}*/
			}
		}
		Console.WriteLine("LINQ: " + stopwatch.ElapsedMilliseconds + " (" + sum2 + ")");

		stopwatch.Restart();
		int sum3 = 0;
		for( int i = 0; i < 100000; i++ )
		{
			foreach( var elem in list )
			{
				if( elem.x % 2 == 0 && elem.x % 2 == 0 )
					sum3 += elem.x;
			}
		}
		Console.WriteLine("LOOP: " + stopwatch.ElapsedMilliseconds + " (" + sum3 + ")");

		FlinqPools.Reset();
		
		stopwatch.Restart();
		int sum4 = 0;
		long timePerReturn = 0;
		for( int i = 0; i < 1000; i++ )
		{
			for( int n = 0; n < 100; n++ )
			{
				//sum4 += list.AsFlinqQuery().Min(x => x.x);
				sum4 += list.AsFlinqQuery().Where(x => x.x != 0).Where(x => x.x != 0).Min(x => x.x);
				//sum4 += list.AsFlinqQuery().Where(x => x.x != 0).Last().x;
				//sum4 += list.AsFlinqQuery().Union(list).Distinct().Last().x;

				/*
				foreach( var elem in list.AsFlinqQuery().Where(x => x.x % 2 == 0).Where(x => x.x % 2 == 0) )
				{
					sum4 += elem.x;
				}*/
			}

			//stopwatch2.Restart();
			FlinqPools.ReturnAllObjects();
			//timePerReturn += stopwatch2.ElapsedTicks;
		}
		Console.WriteLine("FLINQ: " + stopwatch.ElapsedMilliseconds + " (" + sum4 + ") (ReturnAllObjects: " + (timePerReturn / TimeSpan.TicksPerMillisecond) + ")");



		FlinqPools.Reset();

		stopwatch.Restart();
		for( int i = 0; i < 1000; i++ )
		{
			for( int n = 0; n < 100; n++ )
			{
				foreach( var elem in list.AsFlinqQuery() )
				{
					if( i == int.MinValue )
						i = 0;
				}
			}

			//stopwatch2.Restart();
			FlinqPools.ReturnAllObjects();
			//timePerReturn += stopwatch2.ElapsedTicks;
		}
		Console.WriteLine("foreach on FLINQ: " + stopwatch.ElapsedMilliseconds + " (" + sum4 + ") (ReturnAllObjects: " + (timePerReturn / TimeSpan.TicksPerMillisecond) + ")");




		FlinqPools.Reset();

		stopwatch.Restart();
		for( int i = 0; i < 1000; i++ )
		{
			for( int n = 0; n < 100; n++ )
			{
				using( var result = list.AsFlinqQuery().GetResult() )
				{
					for( int j = 0, count = result.Count; j < count; j++ )
					{
						if( result[j].x == int.MinValue )
							i = 0;
					}
				}
			}

			//stopwatch2.Restart();
			FlinqPools.ReturnAllObjects();
			//timePerReturn += stopwatch2.ElapsedTicks;
		}
		Console.WriteLine("for on FLINQ: " + stopwatch.ElapsedMilliseconds + " (" + sum4 + ") (ReturnAllObjects: " + (timePerReturn / TimeSpan.TicksPerMillisecond) + ")");





		stopwatch.Restart();
		int sumx = 0;

		Foo[] tmpArray = new Foo[list.Count];

		for( int i = 0; i < 1000; i++ )
		{
			for( int n = 0; n < 100; n++ )
			{
				var h1 = FlinqListPool<Foo>.Get();
				var h2 = new FlinqQuery<Foo>();

				h1.CopyFrom(list);
				tmpArray = h1.array;

				int min = tmpArray[0].x;
				int c = h1.count;

				for( int yy = 1; yy < c; ++yy )
				{
					var elem = tmpArray[yy].x;

					if( elem < min )
						min = elem;
				}

				FlinqListPool<Foo>.Return(h1);

				sumx += min;
			}

			FlinqPools.ReturnAllObjects();
		}
		Console.WriteLine("FLINQ decomposed: " + stopwatch.ElapsedMilliseconds + " (" + sumx + ")");




		FlinqPools.Reset();

		stopwatch.Restart();
		int sum5 = 0;
		for( int i = 0; i < 1000; i++ )
		{
			for( int n = 0; n < 100; n++ )
			{
				using( var result = list.AsFlinqQuery().Where(x => x.x % 2 == 0).GetResult() )
				{
					/*
					foreach( var elem in result )
					{
						sum5 += elem.x;
					}*/
				}
			}

			FlinqPools.ReturnAllObjects();
		}
		Console.WriteLine("FLINQ (using): " + stopwatch.ElapsedMilliseconds + " (" + sum5 + ")");

		var a = new List<int>();
		for( int i = 0; i < 15; i++ )
		{
			a.Add(i);
		}
		var b = a.ToArray();

		var aCopy = new List<int>();
		var bCopy = new int[b.Length];

		stopwatch.Restart();
		for( int i = 0; i < 100000; i++ )
		{
			int min = 100000;

			aCopy.Clear();
			aCopy.AddRange(a);

			for( int j = 0, count = aCopy.Count; j < count; j++ )
			{
				var elem = aCopy[j];

				if( elem < min )
					min = elem;
			}
		}
		Console.WriteLine("LIST: " + stopwatch.ElapsedMilliseconds + " (" + sum3 + ")");

		stopwatch.Restart();
		for( int i = 0; i < 100000; i++ )
		{
			int min = 100000;

			b.CopyTo(bCopy, 0);

			for( int j = 0, count = bCopy.Length; j < count; j++ )
			{
				var elem = bCopy[j];

				if( elem < min )
					min = elem;
			}
		}
		Console.WriteLine("ARRAY: " + stopwatch.ElapsedMilliseconds + " (" + sum3 + ")");



		Console.ReadKey();
	}
}

}
