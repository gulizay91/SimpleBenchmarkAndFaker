using System.Collections.Generic;
using System.Linq;
using static SimpleTest.DataModels;

namespace SimpleTest
{
  public class Samples
  {
    private readonly List<Customer> _customer;

    public Samples()
    {
      _customer = FakeDataMother.SimpleCustomerList(60000);
    }

    public int ActiveCustomerLinqWhere()
    {
      return _customer.Where(r => r.IsActive).Count();
    }

    public int ActiveCustomerLinqCount()
    {
      return _customer.Count(r => r.IsActive);
    }

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

    public List<string> PassiveCustomerNameLinq()
    {
      return _customer.Where(r => !r.IsActive).Select(r => (r.FinancialId.Length == 10 ? r.Title : (r.Name + " " + r.Surname))).ToList();
    }

  }
}