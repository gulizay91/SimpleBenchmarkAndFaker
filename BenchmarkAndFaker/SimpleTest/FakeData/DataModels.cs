namespace SimpleTest.FakeData
{
  using System;

  /// <summary>
  /// Defines the <see cref="DataModels" />.
  /// </summary>
  public class DataModels
  {
    #region Enums

    /// <summary>
    /// Defines the CompanyTypeEnum.
    /// </summary>
    public enum CompanyTypeEnum
    {
      /// <summary>
      /// Defines the JointStock.
      /// </summary>
      JointStock,
      /// <summary>
      /// Defines the Limited.
      /// </summary>
      Limited,
      /// <summary>
      /// Defines the Collective.
      /// </summary>
      Collective,
      /// <summary>
      /// Defines the LimitedPartnership.
      /// </summary>
      LimitedPartnership,
      /// <summary>
      /// Defines the Cooperativve.
      /// </summary>
      Cooperativve
    }

    #endregion

    /// <summary>
    /// Defines the <see cref="Address" />.
    /// </summary>
    public class Address
    {
      #region Properties

      /// <summary>
      /// Gets or sets the City.
      /// </summary>
      public string City { get; set; }

      /// <summary>
      /// Gets or sets the StreetName.
      /// </summary>
      public string StreetName { get; set; }

      /// <summary>
      /// Gets or sets the ZipCode.
      /// </summary>
      public string ZipCode { get; set; }

      #endregion
    }

    /// <summary>
    /// Defines the <see cref="Customer" />.
    /// </summary>
    public class Customer
    {
      #region Properties

      /// <summary>
      /// Gets or sets the Address.
      /// </summary>
      public Address Address { get; set; }

      /// <summary>
      /// Gets or sets the CompanyType.
      /// </summary>
      public CompanyTypeEnum CompanyType { get; set; }

      /// <summary>
      /// Gets or sets the Email.
      /// </summary>
      public string Email { get; set; }

      /// <summary>
      /// Gets or sets the EmployeeCount.
      /// </summary>
      public int EmployeeCount { get; set; }

      /// <summary>
      /// Gets or sets the FinancialId.
      /// </summary>
      public string FinancialId { get; set; }

      /// <summary>
      /// Gets or sets the Id.
      /// </summary>
      public Guid Id { get; set; }

      /// <summary>
      /// Gets or sets a value indicating whether IsActive.
      /// </summary>
      public bool IsActive { get; set; }

      /// <summary>
      /// Gets or sets the Name.
      /// </summary>
      public string Name { get; set; }

      /// <summary>
      /// Gets or sets the Phone.
      /// </summary>
      public string Phone { get; set; }

      /// <summary>
      /// Gets or sets the Surname.
      /// </summary>
      public string Surname { get; set; }

      /// <summary>
      /// Gets or sets the Title.
      /// </summary>
      public string Title { get; set; }

      #endregion
    }
  }
}
