namespace SimpleTest.Benchmark
{
  using BenchmarkDotNet.Attributes;
  using System;
  using System.Text;

  /// <summary>
  /// Defines the <see cref="BenchmarkStringProcess" />.
  /// </summary>
  [SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.NetCoreApp50, id: "String Benchmark Job 5.0")]
  [SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.NetCoreApp31, id: "String Benchmark Job 3.1")]
  [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
  [MinColumn, MaxColumn, MeanColumn, MedianColumn]
  [MemoryDiagnoser]
  [RankColumn]
  public class BenchmarkStringProcess
  {
    #region Fields

    /// <summary>
    /// Defines the counter.
    /// </summary>
    private int counter = 10000;

    #endregion Fields

    #region Methods

    /// <summary>
    /// The Append.
    /// </summary>
    [Benchmark(Baseline = true)]
    public void Append()
    {
      String emptyStr = "";

      for (int i = 0; i < counter; i++)
      {
        emptyStr += i.ToString();
      }
    }

    /// <summary>
    /// The AppendWithStringBuilder.
    /// </summary>
    [Benchmark()]
    public void AppendWithStringBuilder()
    {
      StringBuilder sb = new StringBuilder(counter);

      for (int i = 0; i < counter; i++)
      {
        sb.Append(i.ToString());
      }
    }

    #endregion Methods
  }
}