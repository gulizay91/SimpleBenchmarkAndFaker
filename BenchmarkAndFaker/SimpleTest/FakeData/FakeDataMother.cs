namespace SimpleTest.FakeData
{
  using Bogus;
  using System;
  using System.Collections.Generic;
  using static SimpleTest.FakeData.DataModels;

  /// <summary>
  /// Defines the <see cref="FakeDataMother" />.
  /// </summary>
  public static class FakeDataMother
  {
    #region Properties

    /// <summary>
    /// Gets the CustomerFaker.
    /// </summary>
    private static Faker<Customer> CustomerFaker => GenerateFaker();

    #endregion Properties

    #region Methods

    /// <summary>
    /// The GenerateFaker.
    /// </summary>
    /// <returns>The <see cref="Faker{Customer}"/>.</returns>
    public static Faker<Customer> GenerateFaker()
    {
      Faker<Address> addressFaker = new Faker<Address>("tr")
                .RuleFor(i => i.City, i => i.Address.City())
                .RuleFor(i => i.StreetName, i => i.Address.StreetName())
                .RuleFor(i => i.ZipCode, i => i.Address.ZipCode());

      Random rnd = new Random();
      var financialId = rnd.Next(0, 1) == 0 ? rnd.Next(10, 99).ToString() + rnd.Next(10000000, 99999999).ToString() : rnd.Next(100, 999).ToString() + rnd.Next(10000000, 99999999).ToString();
      Faker<Customer> _customerFaker = new Faker<Customer>("tr")
        .RuleFor(r => r.Id, Guid.NewGuid())
        .RuleFor(r => r.FinancialId, financialId)
        .RuleFor(r => r.Email, r => r.Person.Email)
        .RuleFor(r => r.Phone, r => r.Person.Phone)
        .RuleFor(i => i.CompanyType, i => i.PickRandom<CompanyTypeEnum>())
        .RuleFor(i => i.Address, addressFaker)
        .RuleFor(r => r.IsActive, r => r.Random.Bool());
      if (financialId.Length == 11)
      {
        _customerFaker
        .RuleFor(r => r.Name, r => r.Person.FirstName)
        .RuleFor(r => r.Surname, r => r.Person.LastName);
      }
      else
      {
        _customerFaker
        .RuleFor(r => r.Title, r => r.Company.CompanyName());
      }
      return _customerFaker;
    }

    /// <summary>
    /// The SimpleCustomer.
    /// </summary>
    /// <returns>The <see cref="Customer"/>.</returns>
    public static Customer SimpleCustomer()
    {
      return CustomerFaker.Generate();
    }

    /// <summary>
    /// The SimpleCustomerList.
    /// </summary>
    /// <param name="count">The count<see cref="int"/>.</param>
    /// <returns>The <see cref="List{Customer}"/>.</returns>
    public static List<Customer> SimpleCustomerList(int count)
    {
      return CustomerFaker.Generate(count);
    }

    #endregion Methods
  }
}