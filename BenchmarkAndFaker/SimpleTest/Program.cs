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

  /// <summary>
  /// Defines the <see cref="Program" />.
  /// </summary>
  internal class Program
  {
    #region Methods

    /// <summary>
    /// The CountBenchmarkRunner.
    /// </summary>
    private static void CountBenchmarkRunner()
    {
      BenchmarkRunner.Run<BenchmarkCount>();
    }

    /// <summary>
    /// The CryptographyBenchmarkRunner.
    /// </summary>
    private static void CryptographyBenchmarkRunner()
    {
      BenchmarkRunner
                .Run<BenchmarkMd5VsSha256>(
                    DefaultConfig.Instance
                        .AddJob(Job.Default.WithRuntime(ClrRuntime.Net48))
                        .AddJob(Job.Default.WithRuntime(CoreRuntime.Core31))
                        .AddValidator(ExecutionValidator.FailOnError));
    }

    /// <summary>
    /// The GetCustomerFakeDataList.
    /// </summary>
    private static void GetCustomerFakeDataList()
    {
      TestFakeData.GetCustomerFakeDataList();
    }

    /// <summary>
    /// The ListBenchmarkRunner.
    /// </summary>
    private static void ListBenchmarkRunner()
    {
      BenchmarkRunner.Run<BenchmarkList>();
    }

    /// <summary>
    /// The Main.
    /// </summary>
    /// <param name="args">The args<see cref="string[]"/>.</param>
    private static void Main(string[] args)
    {
      Console.WriteLine("**************************************************************************************************");
      Console.WriteLine("******************************************BENCHMARKS**********************************************");
      Console.WriteLine("1 - StringProcessBenchmarkRunner");
      Console.WriteLine("2 - CountBenchmarkRunner");
      Console.WriteLine("3 - ListBenchmark");
      Console.WriteLine("4 - CryptographyBenchmark");
      Console.WriteLine("*******************************************FAKEDATA-BOGUS*****************************************");
      Console.WriteLine("11 - GetCustomerFakeDataList");
      Console.WriteLine("**************************************************************************************************");

      var choice = Console.ReadLine();

      Randomizer.Seed = new Random(420);
      switch (choice)
      {
        case "1":
          StringProcessBenchmarkRunner();
          break;

        case "2":
          CountBenchmarkRunner();
          break;

        case "3":
          ListBenchmarkRunner();
          break;

        case "4":
          CryptographyBenchmarkRunner();
          break;

        case "11":
          GetCustomerFakeDataList();
          break;

        default:
          break;
      }
    }

    /// <summary>
    /// The StringProcessBenchmarkRunner.
    /// </summary>
    private static void StringProcessBenchmarkRunner()
    {
      BenchmarkRunner.Run<BenchmarkStringProcess>();
    }

    #endregion Methods
  }
}