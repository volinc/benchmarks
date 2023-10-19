using BenchmarkDotNet.Running;

namespace ContainerResolve
{
	internal class Program
	{
		private static void Main()
		{
			//BenchmarkRunner.Run<AutofacBenchmarks>();
			BenchmarkRunner.Run<ConcurrentDictionaryBenchmarks>();
		}
	}
}
