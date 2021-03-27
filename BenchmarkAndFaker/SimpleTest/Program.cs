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
      Console.WriteLine("1 - CountBenchmark");
      Console.WriteLine("2 - ListBenchmark");
      Console.WriteLine("3 - CryptographyBenchmark");
      Console.WriteLine("*******************************************FAKEDATA-BOGUS*****************************************");
      Console.WriteLine("4 - GetCustomerFakeDataList");
      Console.WriteLine("**************************************************************************************************");

      var choice = Console.ReadLine();

      Randomizer.Seed = new Random(420);
      switch (choice)
      {
        case "1":
          CountBenchmarkRunner();
          break;

        case "2":
          ListBenchmarkRunner();
          break;

        case "3":
          CryptographyBenchmarkRunner();
          break;

        case "4":
          GetCustomerFakeDataList();
          break;

        default:
          break;
      }
    }

    #endregion
  }
}
