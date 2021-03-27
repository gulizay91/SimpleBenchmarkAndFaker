namespace SimpleTest.FakeData
{
  using Newtonsoft.Json;
  using System;

  /// <summary>
  /// Defines the <see cref="FakeDataSamples" />.
  /// </summary>
  public class FakeDataSamples : BaseSample
  {
    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="FakeDataSamples"/> class.
    /// </summary>
    /// <param name="count">The count<see cref="int?"/>.</param>
    public FakeDataSamples(int? count) : base(count)
    {
    }

    #endregion

    #region Methods

    /// <summary>
    /// The CustomerFakeDataList.
    /// </summary>
    public void CustomerFakeDataList()
    {
      string valueAsJson = JsonConvert.SerializeObject(_customer, new JsonSerializerSettings
      {
        Formatting = Formatting.Indented
      });

      Console.WriteLine(valueAsJson);
      Console.WriteLine(_customer.Count);
    }

    #endregion
  }
}
