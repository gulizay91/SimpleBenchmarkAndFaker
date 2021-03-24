using BenchmarkDotNet.Attributes;
using System.Collections.Generic;

namespace SimpleTest
{
  [MemoryDiagnoser] // garbage collection and allocated
  [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
  [RankColumn]
  public class Benchmarks
  {
    private static readonly Samples Sample = new();

    [Benchmark]
    public int GetActiveCustomerLinqWhere() => Sample.ActiveCustomerLinqWhere();

    [Benchmark]
    public int GetActiveCustomerLinqCount() => Sample.ActiveCustomerLinqCount();

    [Benchmark]
    public int GetActiveCustomerCountForLoop() => Sample.ActiveCustomerCountForLoop();

    [Benchmark]
    public int GetActiveCustomerCountForEachLoop() => Sample.ActiveCustomerCountForEachLoop();

    [Benchmark]
    public List<string> GetPassiveCustomerNameForLoop() => Sample.PassiveCustomerNameForLoop();

    [Benchmark]
    public List<string> GetPassiveCustomerNameLinq() => Sample.PassiveCustomerNameLinq();
  }
}