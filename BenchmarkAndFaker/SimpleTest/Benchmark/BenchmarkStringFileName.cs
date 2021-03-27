namespace SimpleTest.Benchmark
{
  using BenchmarkDotNet.Attributes;
  using System;
  using System.IO;

  /// <summary>
  /// Defines the <see cref="BenchmarkStringFileName" />.
  /// </summary>
  [SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.NetCoreApp50, baseline: true)]
  //[SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.NetCoreApp31)]
  [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
  [MemoryDiagnoser]
  [RankColumn]
  public class BenchmarkStringFileName
  {
    #region Constants

    /// <summary>
    /// Defines the fileNameBranchless.
    /// </summary>
    private const string fileNameBranchless = "1155228844-2021-01-0004-0237.zip";

    #endregion

    #region Fields

    /// <summary>
    /// Defines the fileNameBranch.
    /// </summary>
    private string fileNameBranch = "1155228844-2021-01-0007-0013-0023.zip";

    #endregion

    #region Methods

    /// <summary>
    /// The DefineDirectoryWithSpan.
    /// </summary>
    /// <returns>The <see cref="string"/>.</returns>
    public string DefineDirectoryWithSpan()
    {
      ReadOnlySpan<char> spanFilePath = fileNameBranch.AsSpan();

      var financialId = spanFilePath.Slice(0, spanFilePath.IndexOf('-')).ToString();
      //Console.WriteLine(financialId);
      string year = spanFilePath.Slice(spanFilePath.IndexOf('-') + 1, 4).ToString();
      //Console.WriteLine(year);
      string month = spanFilePath.Slice((financialId + year).Length + 2, 2).ToString();
      //Console.WriteLine(month);
      string currentPart = spanFilePath.Slice((financialId + year + month).Length + 3, 4).ToString();
      //Console.WriteLine(currentPart);
      string totalPart = spanFilePath.Slice((financialId + year + month + currentPart).Length + 4, 4).ToString();
      //Console.WriteLine(totalPart);
      string branch = spanFilePath.Slice((financialId + year + month + currentPart + totalPart).Length + 5, 4).ToString();
      //Console.WriteLine(branch);

      return Path.Combine("RootDocumentPath", financialId, year, month, "Original");
    }

    /// <summary>
    /// The DefineDirectoryWithSplit.
    /// </summary>
    /// <returns>The <see cref="string"/>.</returns>
    public string DefineDirectoryWithSplit()
    {
      var arrFilePath = fileNameBranch.Split('-');

      var financialId = arrFilePath[0];
      string year = arrFilePath[1];
      string month = arrFilePath[2];
      string currentPart = arrFilePath[3];
      string totalPart = arrFilePath[4];
      string branch = arrFilePath[5];

      return Path.Combine("RootDocumentPath", financialId, year, month, "Original");
    }

    /// <summary>
    /// The DefineDirectoryWithSpan.
    /// </summary>
    /// <returns>The <see cref="string"/>.</returns>
    [Benchmark]
    public string SimpleWithSpan()
    {
      ReadOnlySpan<char> spanFilePath = fileNameBranchless.AsSpan();

      return spanFilePath.Slice(0, spanFilePath.IndexOf('-')).ToString();
    }

    /// <summary>
    /// The DefineDirectoryWithSplit.
    /// </summary>
    /// <returns>The <see cref="string"/>.</returns>
    [Benchmark(Baseline = true)]
    public string SimpleWithSplit()
    {
      var arrFilePath = fileNameBranchless.Split('-');

      return arrFilePath[0];
    }

    /// <summary>
    /// The SimpleWithSubstring.
    /// </summary>
    /// <returns>The <see cref="string"/>.</returns>
    [Benchmark]
    public string SimpleWithSubstring()
    {
      var index = fileNameBranchless.IndexOf('-');

      return fileNameBranchless.Substring(0, index);
    }

    #endregion
  }
}
