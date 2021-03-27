namespace SimpleTest
{
  using SimpleTest.FakeData;
  using System.Collections.Generic;
  using static SimpleTest.FakeData.DataModels;

  /// <summary>
  /// Defines the <see cref="BaseSample" />.
  /// </summary>
  public class BaseSample
  {
    #region Fields

    /// <summary>
    /// Defines the _customer.
    /// </summary>
    protected readonly List<Customer> _customer;

    #endregion Fields

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseSample"/> class.
    /// </summary>
    /// <param name="count">The count<see cref="int?"/>.</param>
    public BaseSample(int? count = 50000)
    {
      _customer = FakeDataMother.SimpleCustomerList(count.Value);
    }

    #endregion Constructors
  }
}