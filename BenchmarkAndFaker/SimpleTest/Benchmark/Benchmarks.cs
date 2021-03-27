namespace SimpleTest.Benchmark
{
  using BenchmarkDotNet.Attributes;
  using BenchmarkDotNet.Environments;
  using BenchmarkDotNet.Jobs;
  using System.Collections.Generic;

  /// <summary>
  /// Defines the <see cref="Benchmarks" />.
  /// </summary>
  [MemoryDiagnoser] // garbage collection and allocated
  [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
  [RankColumn]
  [SimpleJob(RuntimeMoniker.Net48, baseline: true)]
  [SimpleJob(RuntimeMoniker.NetCoreApp30)]
  [SimpleJob(RuntimeMoniker.CoreRt31)]
  [SimpleJob((BenchmarkDotNet.Engines.RunStrategy)Platform.X64)]
  [SimpleJob((BenchmarkDotNet.Engines.RunStrategy)Platform.X86)]
  public class Benchmarks
  {
    #region Fields

    /// <summary>
    /// Defines the Sample.
    /// </summary>
    private static readonly BenchmarkSamples Sample = new BenchmarkSamples();

    #endregion Fields

    #region Methods

    /// <summary>
    /// The GetActiveCustomerCountForEachLoop.
    /// </summary>
    /// <returns>The <see cref="int"/>.</returns>
    [Benchmark]
    public int GetActiveCustomerCountForEachLoop() => Sample.ActiveCustomerCountForEachLoop();

    /// <summary>
    /// The GetActiveCustomerCountForLoop.
    /// </summary>
    /// <returns>The <see cref="int"/>.</returns>
    [Benchmark]
    public int GetActiveCustomerCountForLoop() => Sample.ActiveCustomerCountForLoop();

    /// <summary>
    /// The GetActiveCustomerLinqCount.
    /// </summary>
    /// <returns>The <see cref="int"/>.</returns>
    [Benchmark]
    public int GetActiveCustomerLinqCount() => Sample.ActiveCustomerLinqCount();

    /// <summary>
    /// The GetActiveCustomerLinqWhere.
    /// </summary>
    /// <returns>The <see cref="int"/>.</returns>
    [Benchmark]
    public int GetActiveCustomerLinqWhere() => Sample.ActiveCustomerLinqWhere();

    /// <summary>
    /// The GetPassiveCustomerNameForEachLoop.
    /// </summary>
    /// <returns>The <see cref="List{string}"/>.</returns>
    [Benchmark]
    public List<string> GetPassiveCustomerNameForEachLoop() => Sample.PassiveCustomerNameForEachLoop();

    /// <summary>
    /// The GetPassiveCustomerNameForLoop.
    /// </summary>
    /// <returns>The <see cref="List{string}"/>.</returns>
    [Benchmark]
    public List<string> GetPassiveCustomerNameForLoop() => Sample.PassiveCustomerNameForLoop();

    /// <summary>
    /// The GetPassiveCustomerNameLinq.
    /// </summary>
    /// <returns>The <see cref="List{string}"/>.</returns>
    [Benchmark]
    public List<string> GetPassiveCustomerNameLinq() => Sample.PassiveCustomerNameLinq();

    /// <summary>
    /// The GetPassiveCustomerNameLinqForeach.
    /// </summary>
    /// <returns>The <see cref="List{string}"/>.</returns>
    [Benchmark]
    public List<string> GetPassiveCustomerNameLinqForeach() => Sample.PassiveCustomerNameLinqForeach();

    /// <summary>
    /// The GetPassiveCustomerNameLinqForeachTwo.
    /// </summary>
    /// <returns>The <see cref="List{string}"/>.</returns>
    [Benchmark]
    public List<string> GetPassiveCustomerNameLinqForeachTwo() => Sample.PassiveCustomerNameLinqForeachTwo();

    #endregion Methods
  }
}