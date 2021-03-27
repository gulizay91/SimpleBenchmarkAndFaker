namespace SimpleTest.Benchmark
{
  using BenchmarkDotNet.Attributes;
  using System.Collections.Generic;

  /// <summary>
  /// Defines the <see cref="BenchmarkList" />.
  /// </summary>
  [MemoryDiagnoser] // garbage collection and allocated
  [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
  [RankColumn]
  public class BenchmarkList
  {
    #region Fields

    /// <summary>
    /// Defines the Sample.
    /// </summary>
    private static readonly BenchmarkSamples Sample = new BenchmarkSamples(100000);

    #endregion Fields

    #region Methods

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