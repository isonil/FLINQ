using System;
using System.Collections.Generic;

namespace Flinq
{

class Program
{
	static void Main(string[] args)
	{
		int val = FlinqQuery<int>.Range(1, 10).Where(x => x >= 5).Select(x => x * x).First();
		Console.WriteLine(val);

		var list = new List<int>();
		list.Add(1);
		list.Add(5);
		list.Add(10);

		int val2 = list.Where(x => x > 1).Sum();
		Console.WriteLine(val2);

		Console.ReadKey();
	}
}

}
