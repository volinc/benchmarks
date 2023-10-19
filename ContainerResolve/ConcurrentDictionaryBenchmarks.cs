using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace ContainerResolve
{
	public class ConcurrentDictionaryBenchmarks
	{
		private static readonly ConcurrentDictionary<long, SampleSettings> LocalCache;
		private static readonly Random Random = new Random();

		static ConcurrentDictionaryBenchmarks()
		{
			var keyValuePairs = new List<KeyValuePair<long, SampleSettings>>();

			//var random = new Random();
			for (var i = 1L; i < 10000L; i++)
			{
				var key = i; //random.Next(1000000, 500000);
				var value = new SampleSettings { Value = Guid.NewGuid() };
				keyValuePairs.Add(new KeyValuePair<long, SampleSettings>(key, value));
			}

			LocalCache = new ConcurrentDictionary<long, SampleSettings>(keyValuePairs);
		}

		[Benchmark]
		public SampleSettings TryGetValue()
		{
			var key = Random.Next(1, 10000);
			LocalCache.TryGetValue(key, out var value);
			return value;
		}
	}
}
