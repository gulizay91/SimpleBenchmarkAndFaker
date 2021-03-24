using BenchmarkDotNet.Running;
using Bogus;
using System;

namespace SimpleTest
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      Randomizer.Seed = new Random(420);
      BenchmarkRunner.Run<Benchmarks>();
    }
  }
}