using System;
using Autofac;
using BenchmarkDotNet.Attributes;

namespace ContainerResolve
{
	public class AutofacBenchmarks
	{
		private static readonly IContainer Container;
		private static readonly Random Random = new Random();

		static AutofacBenchmarks()
		{
			var builder = new ContainerBuilder();

			for (var i = 1L; i < 10000L; i++)
			{
				var key = GetKey(i);
				builder.Register(context => new SampleSettings { Value = Guid.NewGuid() })
					.Keyed<SampleSettings>(key)
					.SingleInstance();
			}

			Container = builder.Build();
		}

		[Benchmark]
		public SampleSettings TryGetValue()
		{
			var key = GetKey(Random.Next(1, 10000));
			Container.TryResolveKeyed<SampleSettings>(key, out var instance);
			return instance;
		}

		private static string GetKey(long i) => $"ApplicationConfiguration.{i}Settings";

	}
}