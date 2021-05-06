namespace SimpleTest
{
  using BenchmarkDotNet.Configs;
  using BenchmarkDotNet.Environments;
  using BenchmarkDotNet.Jobs;
  using BenchmarkDotNet.Running;
  using BenchmarkDotNet.Validators;
  using Bogus;
  using SimpleTest.Benchmark;
  using SimpleTest.FakeData;
  using System;
  using System.IO;

  /// <summary>
  /// Defines the <see cref="Program" />.
  /// </summary>
  internal class Program
  {
    #region Methods

    /// <summary>
    /// The CountBenchmarkRunner.
    /// </summary>
    private static void BenchmarkRunnerCount()
    {
      Randomizer.Seed = new Random(420);
      BenchmarkRunner.Run<BenchmarkCount>();
    }

    /// <summary>
    /// The CryptographyBenchmarkRunner.
    /// </summary>
    private static void BenchmarkRunnerCryptography()
    {
      Randomizer.Seed = new Random(420);
      BenchmarkRunner
                .Run<BenchmarkMd5VsSha256>(
                    DefaultConfig.Instance
                        .AddJob(Job.Default.WithRuntime(ClrRuntime.Net48))
                        .AddJob(Job.Default.WithRuntime(CoreRuntime.Core31))
                        .AddValidator(ExecutionValidator.FailOnError));
    }

    /// <summary>
    /// The BenchmarkRunnerDateTimeParser.
    /// </summary>
    private static void BenchmarkRunnerDateTimeParser()
    {
      BenchmarkRunner.Run<BenchmarkDateTimeParser>();
    }

    /// <summary>
    /// The ListBenchmarkRunner.
    /// </summary>
    private static void BenchmarkRunnerList()
    {
      Randomizer.Seed = new Random(420);
      BenchmarkRunner.Run<BenchmarkList>();
    }

    /// <summary>
    /// The BenchmarkRunnerStringFileName.
    /// </summary>
    private static void BenchmarkRunnerStringFileName()
    {
      BenchmarkRunner.Run<BenchmarkStringFileName>();
    }

    /// <summary>
    /// The BenchmarkRunnerStringProcess.
    /// </summary>
    private static void BenchmarkRunnerStringProcess()
    {
      Randomizer.Seed = new Random(420);
      BenchmarkRunner.Run<BenchmarkStringProcess>();
    }

    /// <summary>
    /// The DefineDirectoryByFileNameWithSpan.
    /// </summary>
    private static void DefineDirectoryByFileNameWithSpan()
    {
      var fileName = "1155228844-2021-01-0007-0013-0023.zip";
      ReadOnlySpan<char> spanFilePath = fileName.AsSpan();

      var financialId = spanFilePath.Slice(0, spanFilePath.IndexOf('-')).ToString();
      Console.WriteLine(financialId);
      string year = spanFilePath.Slice(spanFilePath.IndexOf('-') + 1, 4).ToString();
      Console.WriteLine(year);
      string month = spanFilePath.Slice((financialId + year).Length + 2, 2).ToString();
      Console.WriteLine(month);
      string currentPart = spanFilePath.Slice((financialId + year + month).Length + 3, 4).ToString();
      Console.WriteLine(currentPart);
      string totalPart = spanFilePath.Slice((financialId + year + month + currentPart).Length + 4, 4).ToString();
      Console.WriteLine(totalPart);
      string branch = spanFilePath.Slice((financialId + year + month + currentPart + totalPart).Length + 5, 4).ToString();
      Console.WriteLine(branch);

      string customerMonthlyDirectoryPath = Path.Combine("RootDocumentPath", financialId, year, month, "Original");
      DirectoryInfo targetDirectory = new DirectoryInfo(customerMonthlyDirectoryPath);
      if (!targetDirectory.Exists)
        Console.WriteLine(targetDirectory.FullName);
    }

    /// <summary>
    /// The GetCustomerFakeDataList.
    /// </summary>
    private static void GetCustomerFakeDataList()
    {
      TestFakeData.GetCustomerFakeDataList();
    }

    /// <summary>
    /// The GetHighestNumberofEmployeesFakeData.
    /// </summary>
    private static void GetHighestNumberofEmployeesFakeData()
    {
      TestFakeData.GetHighestNumberofEmployeesFakeData();
    }

    /// <summary>
    /// The Main.
    /// </summary>
    /// <param name="args">The args<see cref="string[]"/>.</param>
    private static void Main(string[] args)
    {
      Console.WriteLine("**************************************************************************************************");
      Console.WriteLine("******************************************BENCHMARKS**********************************************");
      Console.WriteLine("1 - BenchmarkRunnerStringProcess");
      Console.WriteLine("2 - BenchmarkRunnerCount");
      Console.WriteLine("3 - BenchmarkRunnerList");
      Console.WriteLine("4 - BenchmarkRunnerCryptography");
      Console.WriteLine("5 - BenchmarkRunnerDateTimeParser");
      Console.WriteLine("6 - BenchmarkRunnerStringFileName");
      Console.WriteLine("*******************************************FAKEDATA-BOGUS*****************************************");
      Console.WriteLine("default - DefineDirectoryByFileNameWithSpan");
      Console.WriteLine("11 - GetCustomerFakeDataList");
      Console.WriteLine("12 - GetHighestNumberofEmployeesFakeData");
      Console.WriteLine("**************************************************************************************************");

      var choice = Console.ReadLine();

      switch (choice)
      {
        case "1":
          BenchmarkRunnerStringProcess();
          break;

        case "2":
          BenchmarkRunnerCount();
          break;

        case "3":
          BenchmarkRunnerList();
          break;

        case "4":
          BenchmarkRunnerCryptography();
          break;

        case "5":
          BenchmarkRunnerDateTimeParser();
          break;

        case "6":
          BenchmarkRunnerStringFileName();
          break;

        case "11":
          GetCustomerFakeDataList();
          break;

        case "12":
          GetHighestNumberofEmployeesFakeData();
          break;

        default:
          DefineDirectoryByFileNameWithSpan();
          break;
      }
    }

    #endregion
  }
}
