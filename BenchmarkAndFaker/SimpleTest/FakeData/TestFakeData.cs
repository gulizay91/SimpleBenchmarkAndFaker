﻿namespace SimpleTest.FakeData
{
  /// <summary>
  /// Defines the <see cref="TestFakeData" />.
  /// </summary>
  public static class TestFakeData
  {
    #region Fields

    /// <summary>
    /// Defines the Sample.
    /// </summary>
    private static readonly FakeDataSamples Sample = new(10000);

    #endregion

    #region Methods

    /// <summary>
    /// The GetCustomerFakeDataList.
    /// </summary>
    public static void GetCustomerFakeDataList() => Sample.CustomerFakeDataList();

    #endregion
  }
}