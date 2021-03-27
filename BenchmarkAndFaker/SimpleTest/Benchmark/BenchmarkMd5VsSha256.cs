namespace SimpleTest.Benchmark
{
  using BenchmarkDotNet.Attributes;
  using System;
  using System.Security.Cryptography;

  /// <summary>
  /// Defines the <see cref="BenchmarkMd5VsSha256" />.
  /// </summary>
  public class BenchmarkMd5VsSha256
  {
    #region Constants

    /// <summary>
    /// Defines the N.
    /// </summary>
    private const int N = 10000;

    #endregion

    #region Fields

    /// <summary>
    /// Defines the data.
    /// </summary>
    private readonly byte[] data;

    /// <summary>
    /// Defines the md5.
    /// </summary>
    private readonly MD5 md5 = MD5.Create();

    /// <summary>
    /// Defines the sha256.
    /// </summary>
    private readonly SHA256 sha256 = SHA256.Create();

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="BenchmarkMd5VsSha256"/> class.
    /// </summary>
    public BenchmarkMd5VsSha256()
    {
      data = new byte[N];
      new Random(42).NextBytes(data);
    }

    #endregion

    #region Methods

    /// <summary>
    /// The Md5.
    /// </summary>
    /// <returns>The <see cref="byte[]"/>.</returns>
    [Benchmark(Baseline = true)]
    public byte[] Md5() => md5.ComputeHash(data);

    /// <summary>
    /// The Sha256.
    /// </summary>
    /// <returns>The <see cref="byte[]"/>.</returns>
    [Benchmark]
    public byte[] Sha256() => sha256.ComputeHash(data);

    #endregion
  }
}
