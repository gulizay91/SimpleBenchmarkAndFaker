namespace SimpleTest.Benchmark
{
  using System.Collections.Generic;
  using System.Linq;

  /// <summary>
  /// Defines the <see cref="BenchmarkSamples" />.
  /// </summary>
  public class BenchmarkSamples : BaseSample
  {
    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="BenchmarkSamples"/> class.
    /// </summary>
    /// <param name="count">The count<see cref="int?"/>.</param>
    public BenchmarkSamples(int? count = null) : base(count)
    {
    }

    #endregion

    #region Methods

    /// <summary>
    /// The ActiveCustomerCountForEachLoop.
    /// </summary>
    /// <returns>The <see cref="int"/>.</returns>
    public int ActiveCustomerCountForEachLoop()
    {
      var count = 0;
      foreach (var item in _customer)
      {
        if (item.IsActive)
          count++;
      }
      return count;
    }

    /// <summary>
    /// The ActiveCustomerCountForLoop.
    /// </summary>
    /// <returns>The <see cref="int"/>.</returns>
    public int ActiveCustomerCountForLoop()
    {
      var count = 0;
      for (int i = 0; i < _customer.Count; i++)
      {
        if (_customer[i].IsActive)
          count++;
      }
      return count;
    }

    /// <summary>
    /// The ActiveCustomerLinqCount.
    /// </summary>
    /// <returns>The <see cref="int"/>.</returns>
    public int ActiveCustomerLinqCount()
    {
      return _customer.Count(r => r.IsActive);
    }

    /// <summary>
    /// The ActiveCustomerLinqWhere.
    /// </summary>
    /// <returns>The <see cref="int"/>.</returns>
    public int ActiveCustomerLinqWhere()
    {
      return _customer.Where(r => r.IsActive).Count();
    }

    /// <summary>
    /// The PassiveCustomerNameForEachLoop.
    /// </summary>
    /// <returns>The <see cref="List{string}"/>.</returns>
    public List<string> PassiveCustomerNameForEachLoop()
    {
      var names = new List<string>();
      foreach (var item in _customer)
      {
        if (!item.IsActive)
          names.Add(item.FinancialId.Length == 10 ? item.Title : (item.Name + " " + item.Surname));
      }
      return names;
    }

    /// <summary>
    /// The PassiveCustomerNameForLoop.
    /// </summary>
    /// <returns>The <see cref="List{string}"/>.</returns>
    public List<string> PassiveCustomerNameForLoop()
    {
      var names = new List<string>();
      for (int i = 0; i < _customer.Count; i++)
      {
        if (!_customer[i].IsActive)
          names.Add(_customer[i].FinancialId.Length == 10 ? _customer[i].Title : (_customer[i].Name + " " + _customer[i].Surname));
      }
      return names;
    }

    /// <summary>
    /// The PassiveCustomerNameLinq.
    /// </summary>
    /// <returns>The <see cref="List{string}"/>.</returns>
    public List<string> PassiveCustomerNameLinq()
    {
      return _customer.Where(r => !r.IsActive).Select(r => (r.FinancialId.Length == 10 ? r.Title : (r.Name + " " + r.Surname))).ToList();
    }

    /// <summary>
    /// The PassiveCustomerNameLinqForeach.
    /// </summary>
    /// <returns>The <see cref="List{string}"/>.</returns>
    public List<string> PassiveCustomerNameLinqForeach()
    {
      var names = new List<string>();
      _customer.ForEach(r =>
      {
        if (!r.IsActive)
          names.Add(r.FinancialId.Length == 10 ? r.Title : (r.Name + " " + r.Surname));
      });
      return names;
    }

    /// <summary>
    /// The PassiveCustomerNameLinqForeachTwo.
    /// </summary>
    /// <returns>The <see cref="List{string}"/>.</returns>
    public List<string> PassiveCustomerNameLinqForeachTwo()
    {
      var names = new List<string>();
      _customer.Where(r => !r.IsActive).ToList().ForEach(r =>
      {
        names.Add(r.FinancialId.Length == 10 ? r.Title : (r.Name + " " + r.Surname));
      });
      return names;
    }

    #endregion
  }
}
