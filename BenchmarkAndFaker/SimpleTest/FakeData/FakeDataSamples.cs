namespace SimpleTest.FakeData
{
  using System;
  using System.Text.Encodings.Web;
  using System.Text.Json;
  using System.Text.Unicode;

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
      var opt = new JsonSerializerOptions()
      {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
      };

      string valueAsJson = JsonSerializer.Serialize(_customer, opt);

      Console.WriteLine(valueAsJson);
      Console.WriteLine(_customer.Count);
    }

    #endregion
  }
}
