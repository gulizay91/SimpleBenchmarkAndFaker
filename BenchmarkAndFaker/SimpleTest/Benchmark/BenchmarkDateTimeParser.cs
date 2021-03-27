namespace SimpleTest.Benchmark
{
  using BenchmarkDotNet.Attributes;
  using System;

  /// <summary>
  /// Defines the <see cref="BenchmarkDateTimeParser" />.
  /// </summary>
  [SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.NetCoreApp50, baseline: true)]
  //[SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.NetCoreApp31)]
  [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
  [MemoryDiagnoser]
  [RankColumn]
  public class BenchmarkDateTimeParser
  {
    #region Fields

    /// <summary>
    /// Defines the _dateTime.
    /// </summary>
    private string _dateTime;

    #endregion

    #region Methods

    /// <summary>
    /// The GetYearFromDateTime.
    /// </summary>
    /// <returns>The <see cref="int"/>.</returns>
    [Benchmark(Baseline = true)]
    public int GetYearFromDateTime()
    {
      var dateTime = DateTime.Parse(_dateTime);
      return dateTime.Year;
    }

    /// <summary>
    /// The GetYearFromSplit.
    /// </summary>
    /// <returns>The <see cref="int"/>.</returns>
    [Benchmark()]
    public int GetYearFromSplit()
    {
      var splitArr = _dateTime.Split('-');
      return int.Parse(splitArr[0]);
    }

    /// <summary>
    /// The GetYearFromSubStr.
    /// </summary>
    /// <returns>The <see cref="int"/>.</returns>
    [Benchmark]
    public int GetYearFromSubStr()
    {
      var index = _dateTime.IndexOf('-');
      return int.Parse(_dateTime.Substring(0, index));
    }

    /// <summary>
    /// The GetYearFromWithSpan.
    /// </summary>
    /// <returns>The <see cref="int"/>.</returns>
    [Benchmark]
    public int GetYearFromWithSpan()
    {
      ReadOnlySpan<char> span = _dateTime.AsSpan();
      var index = _dateTime.IndexOf('-');
      return int.Parse(span.Slice(0, index).ToString());
    }

    /// <summary>
    /// The GetYearFromWithSpanWithManuelConversion.
    /// </summary>
    /// <returns>The <see cref="int"/>.</returns>
    [Benchmark]
    public int GetYearFromWithSpanWithManuelConversion()
    {
      ReadOnlySpan<char> span = _dateTime.AsSpan();
      var index = _dateTime.IndexOf('-');
      var yearAsSpan = span.Slice(0, index);

      var temp = 0;

      for (int i = 0; i < yearAsSpan.Length; i++)
      {
        temp *= 10 + (yearAsSpan[i] - '0');
      }

      return temp;
    }

    /// <summary>
    /// The Setup.
    /// </summary>
    [GlobalSetup]
    public void Setup()
    {
      _dateTime = "2021-01-21T12:00:00";
    }

    #endregion
  }
}
