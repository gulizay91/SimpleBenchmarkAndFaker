namespace SimpleTest.Benchmark
{
  using BenchmarkDotNet.Attributes;

  /// <summary>
  /// Defines the <see cref="BenchmarkCount" />.
  /// </summary>
  [MemoryDiagnoser] // garbage collection and allocated
  [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
  [RankColumn]
  //[RyuJitX64Job, RyuJitX86Job]
  [SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.NetCoreApp50)]
  [SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net48)]
  [SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.NetCoreApp31)]
  public class BenchmarkCount
  {
    #region Fields

    /// <summary>
    /// Defines the Sample.
    /// </summary>
    private static readonly BenchmarkSamples Sample = new BenchmarkSamples(60000);

    #endregion

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

    #endregion
  }
}
