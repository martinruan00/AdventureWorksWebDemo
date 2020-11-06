using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdventureWorks.Data.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Person");

            migrationBuilder.EnsureSchema(
                name: "Production");

            migrationBuilder.EnsureSchema(
                name: "Sales");

            migrationBuilder.EnsureSchema(
                name: "HumanResources");

            migrationBuilder.EnsureSchema(
                name: "Purchasing");

            migrationBuilder.CreateTable(
                name: "AWBuildVersion",
                columns: table => new
                {
                    SystemInformationID = table.Column<byte>(nullable: false, comment: "Current version number of the AdventureWorks 2016 sample database. ")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatabaseVersion = table.Column<string>(name: "Database Version", maxLength: 25, nullable: false, comment: "Current version number of the AdventureWorks 2016 sample database. "),
                    VersionDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Current version number of the AdventureWorks 2016 sample database. "),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Current version number of the AdventureWorks 2016 sample database. ")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AWBuildVersion_SystemInformationID", x => x.SystemInformationID);
                },
                comment: "Current version number of the AdventureWorks 2016 sample database. ");

            migrationBuilder.CreateTable(
                name: "DatabaseLog",
                columns: table => new
                {
                    DatabaseLogID = table.Column<int>(nullable: false, comment: "Audit table tracking all DDL changes made to the AdventureWorks database. Data is captured by the database trigger ddlDatabaseTriggerLog.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Audit table tracking all DDL changes made to the AdventureWorks database. Data is captured by the database trigger ddlDatabaseTriggerLog."),
                    DatabaseUser = table.Column<string>(maxLength: 128, nullable: false, comment: "Audit table tracking all DDL changes made to the AdventureWorks database. Data is captured by the database trigger ddlDatabaseTriggerLog."),
                    Event = table.Column<string>(maxLength: 128, nullable: false, comment: "Audit table tracking all DDL changes made to the AdventureWorks database. Data is captured by the database trigger ddlDatabaseTriggerLog."),
                    Schema = table.Column<string>(maxLength: 128, nullable: true, comment: "Audit table tracking all DDL changes made to the AdventureWorks database. Data is captured by the database trigger ddlDatabaseTriggerLog."),
                    Object = table.Column<string>(maxLength: 128, nullable: true, comment: "Audit table tracking all DDL changes made to the AdventureWorks database. Data is captured by the database trigger ddlDatabaseTriggerLog."),
                    TSQL = table.Column<string>(nullable: false, comment: "Audit table tracking all DDL changes made to the AdventureWorks database. Data is captured by the database trigger ddlDatabaseTriggerLog."),
                    XmlEvent = table.Column<string>(type: "xml", nullable: false, comment: "Audit table tracking all DDL changes made to the AdventureWorks database. Data is captured by the database trigger ddlDatabaseTriggerLog.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatabaseLog_DatabaseLogID", x => x.DatabaseLogID)
                        .Annotation("SqlServer:Clustered", false);
                },
                comment: "Audit table tracking all DDL changes made to the AdventureWorks database. Data is captured by the database trigger ddlDatabaseTriggerLog.");

            migrationBuilder.CreateTable(
                name: "ErrorLog",
                columns: table => new
                {
                    ErrorLogID = table.Column<int>(nullable: false, comment: "Audit table tracking errors in the the AdventureWorks database that are caught by the CATCH block of a TRY...CATCH construct. Data is inserted by stored procedure dbo.uspLogError when it is executed from inside the CATCH block of a TRY...CATCH construct.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErrorTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Audit table tracking errors in the the AdventureWorks database that are caught by the CATCH block of a TRY...CATCH construct. Data is inserted by stored procedure dbo.uspLogError when it is executed from inside the CATCH block of a TRY...CATCH construct."),
                    UserName = table.Column<string>(maxLength: 128, nullable: false, comment: "Audit table tracking errors in the the AdventureWorks database that are caught by the CATCH block of a TRY...CATCH construct. Data is inserted by stored procedure dbo.uspLogError when it is executed from inside the CATCH block of a TRY...CATCH construct."),
                    ErrorNumber = table.Column<int>(nullable: false, comment: "Audit table tracking errors in the the AdventureWorks database that are caught by the CATCH block of a TRY...CATCH construct. Data is inserted by stored procedure dbo.uspLogError when it is executed from inside the CATCH block of a TRY...CATCH construct."),
                    ErrorSeverity = table.Column<int>(nullable: true, comment: "Audit table tracking errors in the the AdventureWorks database that are caught by the CATCH block of a TRY...CATCH construct. Data is inserted by stored procedure dbo.uspLogError when it is executed from inside the CATCH block of a TRY...CATCH construct."),
                    ErrorState = table.Column<int>(nullable: true, comment: "Audit table tracking errors in the the AdventureWorks database that are caught by the CATCH block of a TRY...CATCH construct. Data is inserted by stored procedure dbo.uspLogError when it is executed from inside the CATCH block of a TRY...CATCH construct."),
                    ErrorProcedure = table.Column<string>(maxLength: 126, nullable: true, comment: "Audit table tracking errors in the the AdventureWorks database that are caught by the CATCH block of a TRY...CATCH construct. Data is inserted by stored procedure dbo.uspLogError when it is executed from inside the CATCH block of a TRY...CATCH construct."),
                    ErrorLine = table.Column<int>(nullable: true, comment: "Audit table tracking errors in the the AdventureWorks database that are caught by the CATCH block of a TRY...CATCH construct. Data is inserted by stored procedure dbo.uspLogError when it is executed from inside the CATCH block of a TRY...CATCH construct."),
                    ErrorMessage = table.Column<string>(maxLength: 4000, nullable: false, comment: "Audit table tracking errors in the the AdventureWorks database that are caught by the CATCH block of a TRY...CATCH construct. Data is inserted by stored procedure dbo.uspLogError when it is executed from inside the CATCH block of a TRY...CATCH construct.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLog", x => x.ErrorLogID);
                },
                comment: "Audit table tracking errors in the the AdventureWorks database that are caught by the CATCH block of a TRY...CATCH construct. Data is inserted by stored procedure dbo.uspLogError when it is executed from inside the CATCH block of a TRY...CATCH construct.");

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "HumanResources",
                columns: table => new
                {
                    DepartmentID = table.Column<short>(nullable: false, comment: "Lookup table containing the departments within the Adventure Works Cycles company.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false, comment: "Lookup table containing the departments within the Adventure Works Cycles company."),
                    GroupName = table.Column<string>(maxLength: 50, nullable: false, comment: "Lookup table containing the departments within the Adventure Works Cycles company."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Lookup table containing the departments within the Adventure Works Cycles company.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentID);
                },
                comment: "Lookup table containing the departments within the Adventure Works Cycles company.");

            migrationBuilder.CreateTable(
                name: "Shift",
                schema: "HumanResources",
                columns: table => new
                {
                    ShiftID = table.Column<byte>(nullable: false, comment: "Work shift lookup table.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false, comment: "Work shift lookup table."),
                    StartTime = table.Column<TimeSpan>(nullable: false, comment: "Work shift lookup table."),
                    EndTime = table.Column<TimeSpan>(nullable: false, comment: "Work shift lookup table."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Work shift lookup table.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.ShiftID);
                },
                comment: "Work shift lookup table.");

            migrationBuilder.CreateTable(
                name: "AddressType",
                schema: "Person",
                columns: table => new
                {
                    AddressTypeID = table.Column<int>(nullable: false, comment: "Types of addresses stored in the Address table. ")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false, comment: "Types of addresses stored in the Address table. "),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())", comment: "Types of addresses stored in the Address table. "),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Types of addresses stored in the Address table. ")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressType", x => x.AddressTypeID);
                },
                comment: "Types of addresses stored in the Address table. ");

            migrationBuilder.CreateTable(
                name: "BusinessEntity",
                schema: "Person",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false, comment: "Source of the ID that connects vendors, customers, and employees with address and contact information.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())", comment: "Source of the ID that connects vendors, customers, and employees with address and contact information."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Source of the ID that connects vendors, customers, and employees with address and contact information.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessEntity", x => x.BusinessEntityID);
                },
                comment: "Source of the ID that connects vendors, customers, and employees with address and contact information.");

            migrationBuilder.CreateTable(
                name: "ContactType",
                schema: "Person",
                columns: table => new
                {
                    ContactTypeID = table.Column<int>(nullable: false, comment: "Lookup table containing the types of business entity contacts.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false, comment: "Lookup table containing the types of business entity contacts."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Lookup table containing the types of business entity contacts.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactType", x => x.ContactTypeID);
                },
                comment: "Lookup table containing the types of business entity contacts.");

            migrationBuilder.CreateTable(
                name: "CountryRegion",
                schema: "Person",
                columns: table => new
                {
                    CountryRegionCode = table.Column<string>(maxLength: 3, nullable: false, comment: "Lookup table containing the ISO standard codes for countries and regions."),
                    Name = table.Column<string>(maxLength: 50, nullable: false, comment: "Lookup table containing the ISO standard codes for countries and regions."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Lookup table containing the ISO standard codes for countries and regions.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryRegion_CountryRegionCode", x => x.CountryRegionCode);
                },
                comment: "Lookup table containing the ISO standard codes for countries and regions.");

            migrationBuilder.CreateTable(
                name: "PhoneNumberType",
                schema: "Person",
                columns: table => new
                {
                    PhoneNumberTypeID = table.Column<int>(nullable: false, comment: "Type of phone number of a person.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false, comment: "Type of phone number of a person."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Type of phone number of a person.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumberType", x => x.PhoneNumberTypeID);
                },
                comment: "Type of phone number of a person.");

            migrationBuilder.CreateTable(
                name: "Culture",
                schema: "Production",
                columns: table => new
                {
                    CultureID = table.Column<string>(fixedLength: true, maxLength: 6, nullable: false, comment: "Lookup table containing the languages in which some AdventureWorks data is stored."),
                    Name = table.Column<string>(maxLength: 50, nullable: false, comment: "Lookup table containing the languages in which some AdventureWorks data is stored."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Lookup table containing the languages in which some AdventureWorks data is stored.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Culture", x => x.CultureID);
                },
                comment: "Lookup table containing the languages in which some AdventureWorks data is stored.");

            migrationBuilder.CreateTable(
                name: "Illustration",
                schema: "Production",
                columns: table => new
                {
                    IllustrationID = table.Column<int>(nullable: false, comment: "Bicycle assembly diagrams.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diagram = table.Column<string>(type: "xml", nullable: true, comment: "Bicycle assembly diagrams."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Bicycle assembly diagrams.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Illustration", x => x.IllustrationID);
                },
                comment: "Bicycle assembly diagrams.");

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "Production",
                columns: table => new
                {
                    LocationID = table.Column<short>(nullable: false, comment: "Product inventory and manufacturing locations.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false, comment: "Product inventory and manufacturing locations."),
                    CostRate = table.Column<decimal>(type: "smallmoney", nullable: false, defaultValueSql: "((0.00))", comment: "Product inventory and manufacturing locations."),
                    Availability = table.Column<decimal>(type: "decimal(8, 2)", nullable: false, defaultValueSql: "((0.00))", comment: "Product inventory and manufacturing locations."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Product inventory and manufacturing locations.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationID);
                },
                comment: "Product inventory and manufacturing locations.");

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                schema: "Production",
                columns: table => new
                {
                    ProductCategoryID = table.Column<int>(nullable: false, comment: "High-level product categorization.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false, comment: "High-level product categorization."),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())", comment: "High-level product categorization."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "High-level product categorization.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.ProductCategoryID);
                },
                comment: "High-level product categorization.");

            migrationBuilder.CreateTable(
                name: "ProductDescription",
                schema: "Production",
                columns: table => new
                {
                    ProductDescriptionID = table.Column<int>(nullable: false, comment: "Product descriptions in several languages.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 400, nullable: false, comment: "Product descriptions in several languages."),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())", comment: "Product descriptions in several languages."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Product descriptions in several languages.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDescription", x => x.ProductDescriptionID);
                },
                comment: "Product descriptions in several languages.");

            migrationBuilder.CreateTable(
                name: "ProductModel",
                schema: "Production",
                columns: table => new
                {
                    ProductModelID = table.Column<int>(nullable: false, comment: "Product model classification.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false, comment: "Product model classification."),
                    CatalogDescription = table.Column<string>(type: "xml", nullable: true, comment: "Product model classification."),
                    Instructions = table.Column<string>(type: "xml", nullable: true, comment: "Product model classification."),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())", comment: "Product model classification."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Product model classification.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModel", x => x.ProductModelID);
                },
                comment: "Product model classification.");

            migrationBuilder.CreateTable(
                name: "ProductPhoto",
                schema: "Production",
                columns: table => new
                {
                    ProductPhotoID = table.Column<int>(nullable: false, comment: "Product images.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThumbNailPhoto = table.Column<byte[]>(nullable: true, comment: "Product images."),
                    ThumbnailPhotoFileName = table.Column<string>(maxLength: 50, nullable: true, comment: "Product images."),
                    LargePhoto = table.Column<byte[]>(nullable: true, comment: "Product images."),
                    LargePhotoFileName = table.Column<string>(maxLength: 50, nullable: true, comment: "Product images."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Product images.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPhoto", x => x.ProductPhotoID);
                },
                comment: "Product images.");

            migrationBuilder.CreateTable(
                name: "ScrapReason",
                schema: "Production",
                columns: table => new
                {
                    ScrapReasonID = table.Column<short>(nullable: false, comment: "Manufacturing failure reasons lookup table.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false, comment: "Manufacturing failure reasons lookup table."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Manufacturing failure reasons lookup table.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrapReason", x => x.ScrapReasonID);
                },
                comment: "Manufacturing failure reasons lookup table.");

            migrationBuilder.CreateTable(
                name: "TransactionHistoryArchive",
                schema: "Production",
                columns: table => new
                {
                    TransactionID = table.Column<int>(nullable: false, comment: "Transactions for previous years."),
                    ProductID = table.Column<int>(nullable: false, comment: "Transactions for previous years."),
                    ReferenceOrderID = table.Column<int>(nullable: false, comment: "Transactions for previous years."),
                    ReferenceOrderLineID = table.Column<int>(nullable: false, comment: "Transactions for previous years."),
                    TransactionDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Transactions for previous years."),
                    TransactionType = table.Column<string>(fixedLength: true, maxLength: 1, nullable: false, comment: "Transactions for previous years."),
                    Quantity = table.Column<int>(nullable: false, comment: "Transactions for previous years."),
                    ActualCost = table.Column<decimal>(type: "money", nullable: false, comment: "Transactions for previous years."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Transactions for previous years.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionHistoryArchive_TransactionID", x => x.TransactionID);
                },
                comment: "Transactions for previous years.");

            migrationBuilder.CreateTable(
                name: "UnitMeasure",
                schema: "Production",
                columns: table => new
                {
                    UnitMeasureCode = table.Column<string>(fixedLength: true, maxLength: 3, nullable: false, comment: "Unit of measure lookup table."),
                    Name = table.Column<string>(maxLength: 50, nullable: false, comment: "Unit of measure lookup table."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Unit of measure lookup table.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitMeasure_UnitMeasureCode", x => x.UnitMeasureCode);
                },
                comment: "Unit of measure lookup table.");

            migrationBuilder.CreateTable(
                name: "ShipMethod",
                schema: "Purchasing",
                columns: table => new
                {
                    ShipMethodID = table.Column<int>(nullable: false, comment: "Shipping company lookup table.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false, comment: "Shipping company lookup table."),
                    ShipBase = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))", comment: "Shipping company lookup table."),
                    ShipRate = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))", comment: "Shipping company lookup table."),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())", comment: "Shipping company lookup table."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Shipping company lookup table.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipMethod", x => x.ShipMethodID);
                },
                comment: "Shipping company lookup table.");

            migrationBuilder.CreateTable(
                name: "CreditCard",
                schema: "Sales",
                columns: table => new
                {
                    CreditCardID = table.Column<int>(nullable: false, comment: "Customer credit card information.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardType = table.Column<string>(maxLength: 50, nullable: false, comment: "Customer credit card information."),
                    CardNumber = table.Column<string>(maxLength: 25, nullable: false, comment: "Customer credit card information."),
                    ExpMonth = table.Column<byte>(nullable: false, comment: "Customer credit card information."),
                    ExpYear = table.Column<short>(nullable: false, comment: "Customer credit card information."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Customer credit card information.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCard", x => x.CreditCardID);
                },
                comment: "Customer credit card information.");

            migrationBuilder.CreateTable(
                name: "Currency",
                schema: "Sales",
                columns: table => new
                {
                    CurrencyCode = table.Column<string>(fixedLength: true, maxLength: 3, nullable: false, comment: "Lookup table containing standard ISO currencies."),
                    Name = table.Column<string>(maxLength: 50, nullable: false, comment: "Lookup table containing standard ISO currencies."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Lookup table containing standard ISO currencies.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency_CurrencyCode", x => x.CurrencyCode);
                },
                comment: "Lookup table containing standard ISO currencies.");

            migrationBuilder.CreateTable(
                name: "SalesReason",
                schema: "Sales",
                columns: table => new
                {
                    SalesReasonID = table.Column<int>(nullable: false, comment: "Lookup table of customer purchase reasons.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false, comment: "Lookup table of customer purchase reasons."),
                    ReasonType = table.Column<string>(maxLength: 50, nullable: false, comment: "Lookup table of customer purchase reasons."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Lookup table of customer purchase reasons.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesReason", x => x.SalesReasonID);
                },
                comment: "Lookup table of customer purchase reasons.");

            migrationBuilder.CreateTable(
                name: "SpecialOffer",
                schema: "Sales",
                columns: table => new
                {
                    SpecialOfferID = table.Column<int>(nullable: false, comment: "Sale discounts lookup table.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 255, nullable: false, comment: "Sale discounts lookup table."),
                    DiscountPct = table.Column<decimal>(type: "smallmoney", nullable: false, defaultValueSql: "((0.00))", comment: "Sale discounts lookup table."),
                    Type = table.Column<string>(maxLength: 50, nullable: false, comment: "Sale discounts lookup table."),
                    Category = table.Column<string>(maxLength: 50, nullable: false, comment: "Sale discounts lookup table."),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Sale discounts lookup table."),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Sale discounts lookup table."),
                    MinQty = table.Column<int>(nullable: false, comment: "Sale discounts lookup table."),
                    MaxQty = table.Column<int>(nullable: true, comment: "Sale discounts lookup table."),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())", comment: "Sale discounts lookup table."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Sale discounts lookup table.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialOffer", x => x.SpecialOfferID);
                },
                comment: "Sale discounts lookup table.");

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "Person",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false, comment: "Human beings involved with AdventureWorks: employees, customer contacts, and vendor contacts."),
                    PersonType = table.Column<string>(fixedLength: true, maxLength: 2, nullable: false, comment: "Human beings involved with AdventureWorks: employees, customer contacts, and vendor contacts."),
                    NameStyle = table.Column<bool>(nullable: false, comment: "Human beings involved with AdventureWorks: employees, customer contacts, and vendor contacts."),
                    Title = table.Column<string>(maxLength: 8, nullable: true, comment: "Human beings involved with AdventureWorks: employees, customer contacts, and vendor contacts."),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false, comment: "Human beings involved with AdventureWorks: employees, customer contacts, and vendor contacts."),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true, comment: "Human beings involved with AdventureWorks: employees, customer contacts, and vendor contacts."),
                    LastName = table.Column<string>(maxLength: 50, nullable: false, comment: "Human beings involved with AdventureWorks: employees, customer contacts, and vendor contacts."),
                    Suffix = table.Column<string>(maxLength: 10, nullable: true, comment: "Human beings involved with AdventureWorks: employees, customer contacts, and vendor contacts."),
                    EmailPromotion = table.Column<int>(nullable: false, comment: "Human beings involved with AdventureWorks: employees, customer contacts, and vendor contacts."),
                    AdditionalContactInfo = table.Column<string>(type: "xml", nullable: true, comment: "Human beings involved with AdventureWorks: employees, customer contacts, and vendor contacts."),
                    Demographics = table.Column<string>(type: "xml", nullable: true, comment: "Human beings involved with AdventureWorks: employees, customer contacts, and vendor contacts."),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())", comment: "Human beings involved with AdventureWorks: employees, customer contacts, and vendor contacts."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Human beings involved with AdventureWorks: employees, customer contacts, and vendor contacts.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person_BusinessEntityID", x => x.BusinessEntityID);
                    table.ForeignKey(
                        name: "FK_Person_BusinessEntity_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "Person",
                        principalTable: "BusinessEntity",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Human beings involved with AdventureWorks: employees, customer contacts, and vendor contacts.");

            migrationBuilder.CreateTable(
                name: "Vendor",
                schema: "Purchasing",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false, comment: "Companies from whom Adventure Works Cycles purchases parts or other goods."),
                    AccountNumber = table.Column<string>(maxLength: 15, nullable: false, comment: "Companies from whom Adventure Works Cycles purchases parts or other goods."),
                    Name = table.Column<string>(maxLength: 50, nullable: false, comment: "Companies from whom Adventure Works Cycles purchases parts or other goods."),
                    CreditRating = table.Column<byte>(nullable: false, comment: "Companies from whom Adventure Works Cycles purchases parts or other goods."),
                    PreferredVendorStatus = table.Column<bool>(nullable: false, defaultValueSql: "((1))", comment: "Companies from whom Adventure Works Cycles purchases parts or other goods."),
                    ActiveFlag = table.Column<bool>(nullable: false, defaultValueSql: "((1))", comment: "Companies from whom Adventure Works Cycles purchases parts or other goods."),
                    PurchasingWebServiceURL = table.Column<string>(maxLength: 1024, nullable: true, comment: "Companies from whom Adventure Works Cycles purchases parts or other goods."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Companies from whom Adventure Works Cycles purchases parts or other goods.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor_BusinessEntityID", x => x.BusinessEntityID);
                    table.ForeignKey(
                        name: "FK_Vendor_BusinessEntity_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "Person",
                        principalTable: "BusinessEntity",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Companies from whom Adventure Works Cycles purchases parts or other goods.");

            migrationBuilder.CreateTable(
                name: "SalesTerritory",
                schema: "Sales",
                columns: table => new
                {
                    TerritoryID = table.Column<int>(nullable: false, comment: "Sales territory lookup table.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false, comment: "Sales territory lookup table."),
                    CountryRegionCode = table.Column<string>(maxLength: 3, nullable: false, comment: "Sales territory lookup table."),
                    Group = table.Column<string>(maxLength: 50, nullable: false, comment: "Sales territory lookup table."),
                    SalesYTD = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))", comment: "Sales territory lookup table."),
                    SalesLastYear = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))", comment: "Sales territory lookup table."),
                    CostYTD = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))", comment: "Sales territory lookup table."),
                    CostLastYear = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))", comment: "Sales territory lookup table."),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())", comment: "Sales territory lookup table."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Sales territory lookup table.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesTerritory_TerritoryID", x => x.TerritoryID);
                    table.ForeignKey(
                        name: "FK_SalesTerritory_CountryRegion_CountryRegionCode",
                        column: x => x.CountryRegionCode,
                        principalSchema: "Person",
                        principalTable: "CountryRegion",
                        principalColumn: "CountryRegionCode",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Sales territory lookup table.");

            migrationBuilder.CreateTable(
                name: "ProductSubcategory",
                schema: "Production",
                columns: table => new
                {
                    ProductSubcategoryID = table.Column<int>(nullable: false, comment: "Product subcategories. See ProductCategory table.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCategoryID = table.Column<int>(nullable: false, comment: "Product subcategories. See ProductCategory table."),
                    Name = table.Column<string>(maxLength: 50, nullable: false, comment: "Product subcategories. See ProductCategory table."),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())", comment: "Product subcategories. See ProductCategory table."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Product subcategories. See ProductCategory table.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSubcategory", x => x.ProductSubcategoryID);
                    table.ForeignKey(
                        name: "FK_ProductSubcategory_ProductCategory_ProductCategoryID",
                        column: x => x.ProductCategoryID,
                        principalSchema: "Production",
                        principalTable: "ProductCategory",
                        principalColumn: "ProductCategoryID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Product subcategories. See ProductCategory table.");

            migrationBuilder.CreateTable(
                name: "ProductModelIllustration",
                schema: "Production",
                columns: table => new
                {
                    ProductModelID = table.Column<int>(nullable: false, comment: "Cross-reference table mapping product models and illustrations."),
                    IllustrationID = table.Column<int>(nullable: false, comment: "Cross-reference table mapping product models and illustrations."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Cross-reference table mapping product models and illustrations.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModelIllustration_ProductModelID_IllustrationID", x => new { x.ProductModelID, x.IllustrationID });
                    table.ForeignKey(
                        name: "FK_ProductModelIllustration_Illustration_IllustrationID",
                        column: x => x.IllustrationID,
                        principalSchema: "Production",
                        principalTable: "Illustration",
                        principalColumn: "IllustrationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductModelIllustration_ProductModel_ProductModelID",
                        column: x => x.ProductModelID,
                        principalSchema: "Production",
                        principalTable: "ProductModel",
                        principalColumn: "ProductModelID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Cross-reference table mapping product models and illustrations.");

            migrationBuilder.CreateTable(
                name: "ProductModelProductDescriptionCulture",
                schema: "Production",
                columns: table => new
                {
                    ProductModelID = table.Column<int>(nullable: false, comment: "Cross-reference table mapping product descriptions and the language the description is written in."),
                    ProductDescriptionID = table.Column<int>(nullable: false, comment: "Cross-reference table mapping product descriptions and the language the description is written in."),
                    CultureID = table.Column<string>(fixedLength: true, maxLength: 6, nullable: false, comment: "Cross-reference table mapping product descriptions and the language the description is written in."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Cross-reference table mapping product descriptions and the language the description is written in.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModelProductDescriptionCulture_ProductModelID_ProductDescriptionID_CultureID", x => new { x.ProductModelID, x.ProductDescriptionID, x.CultureID });
                    table.ForeignKey(
                        name: "FK_ProductModelProductDescriptionCulture_Culture_CultureID",
                        column: x => x.CultureID,
                        principalSchema: "Production",
                        principalTable: "Culture",
                        principalColumn: "CultureID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductModelProductDescriptionCulture_ProductDescription_ProductDescriptionID",
                        column: x => x.ProductDescriptionID,
                        principalSchema: "Production",
                        principalTable: "ProductDescription",
                        principalColumn: "ProductDescriptionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductModelProductDescriptionCulture_ProductModel_ProductModelID",
                        column: x => x.ProductModelID,
                        principalSchema: "Production",
                        principalTable: "ProductModel",
                        principalColumn: "ProductModelID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Cross-reference table mapping product descriptions and the language the description is written in.");

            migrationBuilder.CreateTable(
                name: "CountryRegionCurrency",
                schema: "Sales",
                columns: table => new
                {
                    CountryRegionCode = table.Column<string>(maxLength: 3, nullable: false, comment: "Cross-reference table mapping ISO currency codes to a country or region."),
                    CurrencyCode = table.Column<string>(fixedLength: true, maxLength: 3, nullable: false, comment: "Cross-reference table mapping ISO currency codes to a country or region."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Cross-reference table mapping ISO currency codes to a country or region.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryRegionCurrency_CountryRegionCode_CurrencyCode", x => new { x.CountryRegionCode, x.CurrencyCode });
                    table.ForeignKey(
                        name: "FK_CountryRegionCurrency_CountryRegion_CountryRegionCode",
                        column: x => x.CountryRegionCode,
                        principalSchema: "Person",
                        principalTable: "CountryRegion",
                        principalColumn: "CountryRegionCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CountryRegionCurrency_Currency_CurrencyCode",
                        column: x => x.CurrencyCode,
                        principalSchema: "Sales",
                        principalTable: "Currency",
                        principalColumn: "CurrencyCode",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Cross-reference table mapping ISO currency codes to a country or region.");

            migrationBuilder.CreateTable(
                name: "CurrencyRate",
                schema: "Sales",
                columns: table => new
                {
                    CurrencyRateID = table.Column<int>(nullable: false, comment: "Currency exchange rates.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyRateDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Currency exchange rates."),
                    FromCurrencyCode = table.Column<string>(fixedLength: true, maxLength: 3, nullable: false, comment: "Currency exchange rates."),
                    ToCurrencyCode = table.Column<string>(fixedLength: true, maxLength: 3, nullable: false, comment: "Currency exchange rates."),
                    AverageRate = table.Column<decimal>(type: "money", nullable: false, comment: "Currency exchange rates."),
                    EndOfDayRate = table.Column<decimal>(type: "money", nullable: false, comment: "Currency exchange rates."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Currency exchange rates.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyRate", x => x.CurrencyRateID);
                    table.ForeignKey(
                        name: "FK_CurrencyRate_Currency_FromCurrencyCode",
                        column: x => x.FromCurrencyCode,
                        principalSchema: "Sales",
                        principalTable: "Currency",
                        principalColumn: "CurrencyCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurrencyRate_Currency_ToCurrencyCode",
                        column: x => x.ToCurrencyCode,
                        principalSchema: "Sales",
                        principalTable: "Currency",
                        principalColumn: "CurrencyCode",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Currency exchange rates.");

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "HumanResources",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false, comment: "Employee information such as salary, department, and title."),
                    NationalIDNumber = table.Column<string>(maxLength: 15, nullable: false, comment: "Employee information such as salary, department, and title."),
                    LoginID = table.Column<string>(maxLength: 256, nullable: false, comment: "Employee information such as salary, department, and title."),
                    OrganizationLevel = table.Column<short>(nullable: true, computedColumnSql: "([OrganizationNode].[GetLevel]())", comment: "Employee information such as salary, department, and title."),
                    JobTitle = table.Column<string>(maxLength: 50, nullable: false, comment: "Employee information such as salary, department, and title."),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false, comment: "Employee information such as salary, department, and title."),
                    MaritalStatus = table.Column<string>(fixedLength: true, maxLength: 1, nullable: false, comment: "Employee information such as salary, department, and title."),
                    Gender = table.Column<string>(fixedLength: true, maxLength: 1, nullable: false, comment: "Employee information such as salary, department, and title."),
                    HireDate = table.Column<DateTime>(type: "date", nullable: false, comment: "Employee information such as salary, department, and title."),
                    SalariedFlag = table.Column<bool>(nullable: false, defaultValueSql: "((1))", comment: "Employee information such as salary, department, and title."),
                    VacationHours = table.Column<short>(nullable: false, comment: "Employee information such as salary, department, and title."),
                    SickLeaveHours = table.Column<short>(nullable: false, comment: "Employee information such as salary, department, and title."),
                    CurrentFlag = table.Column<bool>(nullable: false, defaultValueSql: "((1))", comment: "Employee information such as salary, department, and title."),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())", comment: "Employee information such as salary, department, and title."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Employee information such as salary, department, and title.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_BusinessEntityID", x => x.BusinessEntityID);
                    table.ForeignKey(
                        name: "FK_Employee_Person_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "Person",
                        principalTable: "Person",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Employee information such as salary, department, and title.");

            migrationBuilder.CreateTable(
                name: "BusinessEntityContact",
                schema: "Person",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false, comment: "Cross-reference table mapping stores, vendors, and employees to people"),
                    PersonID = table.Column<int>(nullable: false, comment: "Cross-reference table mapping stores, vendors, and employees to people"),
                    ContactTypeID = table.Column<int>(nullable: false, comment: "Cross-reference table mapping stores, vendors, and employees to people"),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())", comment: "Cross-reference table mapping stores, vendors, and employees to people"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Cross-reference table mapping stores, vendors, and employees to people")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessEntityContact_BusinessEntityID_PersonID_ContactTypeID", x => new { x.BusinessEntityID, x.PersonID, x.ContactTypeID });
                    table.ForeignKey(
                        name: "FK_BusinessEntityContact_BusinessEntity_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "Person",
                        principalTable: "BusinessEntity",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessEntityContact_ContactType_ContactTypeID",
                        column: x => x.ContactTypeID,
                        principalSchema: "Person",
                        principalTable: "ContactType",
                        principalColumn: "ContactTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessEntityContact_Person_PersonID",
                        column: x => x.PersonID,
                        principalSchema: "Person",
                        principalTable: "Person",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Cross-reference table mapping stores, vendors, and employees to people");

            migrationBuilder.CreateTable(
                name: "EmailAddress",
                schema: "Person",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false, comment: "Where to send a person email."),
                    EmailAddressID = table.Column<int>(nullable: false, comment: "Where to send a person email.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(maxLength: 50, nullable: true, comment: "Where to send a person email."),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())", comment: "Where to send a person email."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Where to send a person email.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAddress_BusinessEntityID_EmailAddressID", x => new { x.BusinessEntityID, x.EmailAddressID });
                    table.ForeignKey(
                        name: "FK_EmailAddress_Person_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "Person",
                        principalTable: "Person",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Where to send a person email.");

            migrationBuilder.CreateTable(
                name: "Password",
                schema: "Person",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false),
                    PasswordHash = table.Column<string>(unicode: false, maxLength: 128, nullable: false, comment: "One way hashed authentication information"),
                    PasswordSalt = table.Column<string>(unicode: false, maxLength: 10, nullable: false, comment: "One way hashed authentication information"),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())", comment: "One way hashed authentication information"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "One way hashed authentication information")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Password_BusinessEntityID", x => x.BusinessEntityID);
                    table.ForeignKey(
                        name: "FK_Password_Person_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "Person",
                        principalTable: "Person",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "One way hashed authentication information");

            migrationBuilder.CreateTable(
                name: "PersonPhone",
                schema: "Person",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false, comment: "Telephone number and type of a person."),
                    PhoneNumber = table.Column<string>(maxLength: 25, nullable: false, comment: "Telephone number and type of a person."),
                    PhoneNumberTypeID = table.Column<int>(nullable: false, comment: "Telephone number and type of a person."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Telephone number and type of a person.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonPhone_BusinessEntityID_PhoneNumber_PhoneNumberTypeID", x => new { x.BusinessEntityID, x.PhoneNumber, x.PhoneNumberTypeID });
                    table.ForeignKey(
                        name: "FK_PersonPhone_Person_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "Person",
                        principalTable: "Person",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonPhone_PhoneNumberType_PhoneNumberTypeID",
                        column: x => x.PhoneNumberTypeID,
                        principalSchema: "Person",
                        principalTable: "PhoneNumberType",
                        principalColumn: "PhoneNumberTypeID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Telephone number and type of a person.");

            migrationBuilder.CreateTable(
                name: "PersonCreditCard",
                schema: "Sales",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false, comment: "Cross-reference table mapping people to their credit card information in the CreditCard table. "),
                    CreditCardID = table.Column<int>(nullable: false, comment: "Cross-reference table mapping people to their credit card information in the CreditCard table. "),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Cross-reference table mapping people to their credit card information in the CreditCard table. ")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonCreditCard_BusinessEntityID_CreditCardID", x => new { x.BusinessEntityID, x.CreditCardID });
                    table.ForeignKey(
                        name: "FK_PersonCreditCard_Person_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "Person",
                        principalTable: "Person",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonCreditCard_CreditCard_CreditCardID",
                        column: x => x.CreditCardID,
                        principalSchema: "Sales",
                        principalTable: "CreditCard",
                        principalColumn: "CreditCardID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Cross-reference table mapping people to their credit card information in the CreditCard table. ");

            migrationBuilder.CreateTable(
                name: "StateProvince",
                schema: "Person",
                columns: table => new
                {
                    StateProvinceID = table.Column<int>(nullable: false, comment: "State and province lookup table.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateProvinceCode = table.Column<string>(fixedLength: true, maxLength: 3, nullable: false, comment: "State and province lookup table."),
                    CountryRegionCode = table.Column<string>(maxLength: 3, nullable: false, comment: "State and province lookup table."),
                    IsOnlyStateProvinceFlag = table.Column<bool>(nullable: false, defaultValueSql: "((1))", comment: "State and province lookup table."),
                    Name = table.Column<string>(maxLength: 50, nullable: false, comment: "State and province lookup table."),
                    TerritoryID = table.Column<int>(nullable: false, comment: "State and province lookup table."),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())", comment: "State and province lookup table."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "State and province lookup table.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateProvince", x => x.StateProvinceID);
                    table.ForeignKey(
                        name: "FK_StateProvince_CountryRegion_CountryRegionCode",
                        column: x => x.CountryRegionCode,
                        principalSchema: "Person",
                        principalTable: "CountryRegion",
                        principalColumn: "CountryRegionCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StateProvince_SalesTerritory_TerritoryID",
                        column: x => x.TerritoryID,
                        principalSchema: "Sales",
                        principalTable: "SalesTerritory",
                        principalColumn: "TerritoryID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "State and province lookup table.");

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Production",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false, comment: "Products sold or used in the manfacturing of sold products.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false, comment: "Products sold or used in the manfacturing of sold products."),
                    ProductNumber = table.Column<string>(maxLength: 25, nullable: false, comment: "Products sold or used in the manfacturing of sold products."),
                    MakeFlag = table.Column<bool>(nullable: false, defaultValueSql: "((1))", comment: "Products sold or used in the manfacturing of sold products."),
                    FinishedGoodsFlag = table.Column<bool>(nullable: false, defaultValueSql: "((1))", comment: "Products sold or used in the manfacturing of sold products."),
                    Color = table.Column<string>(maxLength: 15, nullable: true, comment: "Products sold or used in the manfacturing of sold products."),
                    SafetyStockLevel = table.Column<short>(nullable: false, comment: "Products sold or used in the manfacturing of sold products."),
                    ReorderPoint = table.Column<short>(nullable: false, comment: "Products sold or used in the manfacturing of sold products."),
                    StandardCost = table.Column<decimal>(type: "money", nullable: false, comment: "Products sold or used in the manfacturing of sold products."),
                    ListPrice = table.Column<decimal>(type: "money", nullable: false, comment: "Products sold or used in the manfacturing of sold products."),
                    Size = table.Column<string>(maxLength: 5, nullable: true, comment: "Products sold or used in the manfacturing of sold products."),
                    SizeUnitMeasureCode = table.Column<string>(fixedLength: true, maxLength: 3, nullable: true, comment: "Products sold or used in the manfacturing of sold products."),
                    WeightUnitMeasureCode = table.Column<string>(fixedLength: true, maxLength: 3, nullable: true, comment: "Products sold or used in the manfacturing of sold products."),
                    Weight = table.Column<decimal>(type: "decimal(8, 2)", nullable: true, comment: "Products sold or used in the manfacturing of sold products."),
                    DaysToManufacture = table.Column<int>(nullable: false, comment: "Products sold or used in the manfacturing of sold products."),
                    ProductLine = table.Column<string>(fixedLength: true, maxLength: 2, nullable: true, comment: "Products sold or used in the manfacturing of sold products."),
                    Class = table.Column<string>(fixedLength: true, maxLength: 2, nullable: true, comment: "Products sold or used in the manfacturing of sold products."),
                    Style = table.Column<string>(fixedLength: true, maxLength: 2, nullable: true, comment: "Products sold or used in the manfacturing of sold products."),
                    ProductSubcategoryID = table.Column<int>(nullable: true, comment: "Products sold or used in the manfacturing of sold products."),
                    ProductModelID = table.Column<int>(nullable: true, comment: "Products sold or used in the manfacturing of sold products."),
                    SellStartDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Products sold or used in the manfacturing of sold products."),
                    SellEndDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Products sold or used in the manfacturing of sold products."),
                    DiscontinuedDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Products sold or used in the manfacturing of sold products."),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())", comment: "Products sold or used in the manfacturing of sold products."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Products sold or used in the manfacturing of sold products.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Product_ProductModel_ProductModelID",
                        column: x => x.ProductModelID,
                        principalSchema: "Production",
                        principalTable: "ProductModel",
                        principalColumn: "ProductModelID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_ProductSubcategory_ProductSubcategoryID",
                        column: x => x.ProductSubcategoryID,
                        principalSchema: "Production",
                        principalTable: "ProductSubcategory",
                        principalColumn: "ProductSubcategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_UnitMeasure_SizeUnitMeasureCode",
                        column: x => x.SizeUnitMeasureCode,
                        principalSchema: "Production",
                        principalTable: "UnitMeasure",
                        principalColumn: "UnitMeasureCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_UnitMeasure_WeightUnitMeasureCode",
                        column: x => x.WeightUnitMeasureCode,
                        principalSchema: "Production",
                        principalTable: "UnitMeasure",
                        principalColumn: "UnitMeasureCode",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Products sold or used in the manfacturing of sold products.");

            migrationBuilder.CreateTable(
                name: "EmployeeDepartmentHistory",
                schema: "HumanResources",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false, comment: "Employee department transfers."),
                    DepartmentID = table.Column<short>(nullable: false, comment: "Employee department transfers."),
                    ShiftID = table.Column<byte>(nullable: false, comment: "Employee department transfers."),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false, comment: "Employee department transfers."),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true, comment: "Employee department transfers."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Employee department transfers.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDepartmentHistory_BusinessEntityID_StartDate_DepartmentID", x => new { x.BusinessEntityID, x.StartDate, x.DepartmentID, x.ShiftID });
                    table.ForeignKey(
                        name: "FK_EmployeeDepartmentHistory_Employee_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "HumanResources",
                        principalTable: "Employee",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeDepartmentHistory_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalSchema: "HumanResources",
                        principalTable: "Department",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeDepartmentHistory_Shift_ShiftID",
                        column: x => x.ShiftID,
                        principalSchema: "HumanResources",
                        principalTable: "Shift",
                        principalColumn: "ShiftID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Employee department transfers.");

            migrationBuilder.CreateTable(
                name: "EmployeePayHistory",
                schema: "HumanResources",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false, comment: "Employee pay history."),
                    RateChangeDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Employee pay history."),
                    Rate = table.Column<decimal>(type: "money", nullable: false, comment: "Employee pay history."),
                    PayFrequency = table.Column<byte>(nullable: false, comment: "Employee pay history."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Employee pay history.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePayHistory_BusinessEntityID_RateChangeDate", x => new { x.BusinessEntityID, x.RateChangeDate });
                    table.ForeignKey(
                        name: "FK_EmployeePayHistory_Employee_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "HumanResources",
                        principalTable: "Employee",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Employee pay history.");

            migrationBuilder.CreateTable(
                name: "JobCandidate",
                schema: "HumanResources",
                columns: table => new
                {
                    JobCandidateID = table.Column<int>(nullable: false, comment: "Résumés submitted to Human Resources by job applicants.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessEntityID = table.Column<int>(nullable: true, comment: "Résumés submitted to Human Resources by job applicants."),
                    Resume = table.Column<string>(type: "xml", nullable: true, comment: "Résumés submitted to Human Resources by job applicants."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Résumés submitted to Human Resources by job applicants.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCandidate", x => x.JobCandidateID);
                    table.ForeignKey(
                        name: "FK_JobCandidate_Employee_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "HumanResources",
                        principalTable: "Employee",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Résumés submitted to Human Resources by job applicants.");

            migrationBuilder.CreateTable(
                name: "PurchaseOrderHeader",
                schema: "Purchasing",
                columns: table => new
                {
                    PurchaseOrderID = table.Column<int>(nullable: false, comment: "General purchase order information. See PurchaseOrderDetail.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RevisionNumber = table.Column<byte>(nullable: false, comment: "General purchase order information. See PurchaseOrderDetail."),
                    Status = table.Column<byte>(nullable: false, defaultValueSql: "((1))", comment: "General purchase order information. See PurchaseOrderDetail."),
                    EmployeeID = table.Column<int>(nullable: false, comment: "General purchase order information. See PurchaseOrderDetail."),
                    VendorID = table.Column<int>(nullable: false, comment: "General purchase order information. See PurchaseOrderDetail."),
                    ShipMethodID = table.Column<int>(nullable: false, comment: "General purchase order information. See PurchaseOrderDetail."),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "General purchase order information. See PurchaseOrderDetail."),
                    ShipDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "General purchase order information. See PurchaseOrderDetail."),
                    SubTotal = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))", comment: "General purchase order information. See PurchaseOrderDetail."),
                    TaxAmt = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))", comment: "General purchase order information. See PurchaseOrderDetail."),
                    Freight = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))", comment: "General purchase order information. See PurchaseOrderDetail."),
                    TotalDue = table.Column<decimal>(type: "money", nullable: false, computedColumnSql: "(isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))", comment: "General purchase order information. See PurchaseOrderDetail."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "General purchase order information. See PurchaseOrderDetail.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderHeader_PurchaseOrderID", x => x.PurchaseOrderID);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderHeader_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalSchema: "HumanResources",
                        principalTable: "Employee",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderHeader_ShipMethod_ShipMethodID",
                        column: x => x.ShipMethodID,
                        principalSchema: "Purchasing",
                        principalTable: "ShipMethod",
                        principalColumn: "ShipMethodID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderHeader_Vendor_VendorID",
                        column: x => x.VendorID,
                        principalSchema: "Purchasing",
                        principalTable: "Vendor",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "General purchase order information. See PurchaseOrderDetail.");

            migrationBuilder.CreateTable(
                name: "SalesPerson",
                schema: "Sales",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false, comment: "Sales representative current information."),
                    TerritoryID = table.Column<int>(nullable: true, comment: "Sales representative current information."),
                    SalesQuota = table.Column<decimal>(type: "money", nullable: true, comment: "Sales representative current information."),
                    Bonus = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))", comment: "Sales representative current information."),
                    CommissionPct = table.Column<decimal>(type: "smallmoney", nullable: false, defaultValueSql: "((0.00))", comment: "Sales representative current information."),
                    SalesYTD = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))", comment: "Sales representative current information."),
                    SalesLastYear = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))", comment: "Sales representative current information."),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())", comment: "Sales representative current information."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Sales representative current information.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPerson_BusinessEntityID", x => x.BusinessEntityID);
                    table.ForeignKey(
                        name: "FK_SalesPerson_Employee_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "HumanResources",
                        principalTable: "Employee",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesPerson_SalesTerritory_TerritoryID",
                        column: x => x.TerritoryID,
                        principalSchema: "Sales",
                        principalTable: "SalesTerritory",
                        principalColumn: "TerritoryID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Sales representative current information.");

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "Person",
                columns: table => new
                {
                    AddressID = table.Column<int>(nullable: false, comment: "Street address information for customers, employees, and vendors.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressLine1 = table.Column<string>(maxLength: 60, nullable: false, comment: "Street address information for customers, employees, and vendors."),
                    AddressLine2 = table.Column<string>(maxLength: 60, nullable: true, comment: "Street address information for customers, employees, and vendors."),
                    City = table.Column<string>(maxLength: 30, nullable: false, comment: "Street address information for customers, employees, and vendors."),
                    StateProvinceID = table.Column<int>(nullable: false, comment: "Street address information for customers, employees, and vendors."),
                    PostalCode = table.Column<string>(maxLength: 15, nullable: false, comment: "Street address information for customers, employees, and vendors."),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())", comment: "Street address information for customers, employees, and vendors."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Street address information for customers, employees, and vendors.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_Address_StateProvince_StateProvinceID",
                        column: x => x.StateProvinceID,
                        principalSchema: "Person",
                        principalTable: "StateProvince",
                        principalColumn: "StateProvinceID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Street address information for customers, employees, and vendors.");

            migrationBuilder.CreateTable(
                name: "SalesTaxRate",
                schema: "Sales",
                columns: table => new
                {
                    SalesTaxRateID = table.Column<int>(nullable: false, comment: "Tax rate lookup table.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateProvinceID = table.Column<int>(nullable: false, comment: "Tax rate lookup table."),
                    TaxType = table.Column<byte>(nullable: false, comment: "Tax rate lookup table."),
                    TaxRate = table.Column<decimal>(type: "smallmoney", nullable: false, defaultValueSql: "((0.00))", comment: "Tax rate lookup table."),
                    Name = table.Column<string>(maxLength: 50, nullable: false, comment: "Tax rate lookup table."),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())", comment: "Tax rate lookup table."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Tax rate lookup table.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesTaxRate", x => x.SalesTaxRateID);
                    table.ForeignKey(
                        name: "FK_SalesTaxRate_StateProvince_StateProvinceID",
                        column: x => x.StateProvinceID,
                        principalSchema: "Person",
                        principalTable: "StateProvince",
                        principalColumn: "StateProvinceID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Tax rate lookup table.");

            migrationBuilder.CreateTable(
                name: "BillOfMaterials",
                schema: "Production",
                columns: table => new
                {
                    BillOfMaterialsID = table.Column<int>(nullable: false, comment: "Items required to make bicycles and bicycle subassemblies. It identifies the heirarchical relationship between a parent product and its components.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductAssemblyID = table.Column<int>(nullable: true, comment: "Items required to make bicycles and bicycle subassemblies. It identifies the heirarchical relationship between a parent product and its components."),
                    ComponentID = table.Column<int>(nullable: false, comment: "Items required to make bicycles and bicycle subassemblies. It identifies the heirarchical relationship between a parent product and its components."),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Items required to make bicycles and bicycle subassemblies. It identifies the heirarchical relationship between a parent product and its components."),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Items required to make bicycles and bicycle subassemblies. It identifies the heirarchical relationship between a parent product and its components."),
                    UnitMeasureCode = table.Column<string>(fixedLength: true, maxLength: 3, nullable: false, comment: "Items required to make bicycles and bicycle subassemblies. It identifies the heirarchical relationship between a parent product and its components."),
                    BOMLevel = table.Column<short>(nullable: false, comment: "Items required to make bicycles and bicycle subassemblies. It identifies the heirarchical relationship between a parent product and its components."),
                    PerAssemblyQty = table.Column<decimal>(type: "decimal(8, 2)", nullable: false, defaultValueSql: "((1.00))", comment: "Items required to make bicycles and bicycle subassemblies. It identifies the heirarchical relationship between a parent product and its components."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Items required to make bicycles and bicycle subassemblies. It identifies the heirarchical relationship between a parent product and its components.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillOfMaterials_BillOfMaterialsID", x => x.BillOfMaterialsID)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_BillOfMaterials_Product_ComponentID",
                        column: x => x.ComponentID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillOfMaterials_Product_ProductAssemblyID",
                        column: x => x.ProductAssemblyID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillOfMaterials_UnitMeasure_UnitMeasureCode",
                        column: x => x.UnitMeasureCode,
                        principalSchema: "Production",
                        principalTable: "UnitMeasure",
                        principalColumn: "UnitMeasureCode",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Items required to make bicycles and bicycle subassemblies. It identifies the heirarchical relationship between a parent product and its components.");

            migrationBuilder.CreateTable(
                name: "ProductCostHistory",
                schema: "Production",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false, comment: "Changes in the cost of a product over time."),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Changes in the cost of a product over time."),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Changes in the cost of a product over time."),
                    StandardCost = table.Column<decimal>(type: "money", nullable: false, comment: "Changes in the cost of a product over time."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Changes in the cost of a product over time.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCostHistory_ProductID_StartDate", x => new { x.ProductID, x.StartDate });
                    table.ForeignKey(
                        name: "FK_ProductCostHistory_Product_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Changes in the cost of a product over time.");

            migrationBuilder.CreateTable(
                name: "ProductInventory",
                schema: "Production",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false, comment: "Product inventory information."),
                    LocationID = table.Column<short>(nullable: false, comment: "Product inventory information."),
                    Shelf = table.Column<string>(maxLength: 10, nullable: false, comment: "Product inventory information."),
                    Bin = table.Column<byte>(nullable: false, comment: "Product inventory information."),
                    Quantity = table.Column<short>(nullable: false, comment: "Product inventory information."),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())", comment: "Product inventory information."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Product inventory information.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInventory_ProductID_LocationID", x => new { x.ProductID, x.LocationID });
                    table.ForeignKey(
                        name: "FK_ProductInventory_Location_LocationID",
                        column: x => x.LocationID,
                        principalSchema: "Production",
                        principalTable: "Location",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductInventory_Product_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Product inventory information.");

            migrationBuilder.CreateTable(
                name: "ProductListPriceHistory",
                schema: "Production",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false, comment: "Changes in the list price of a product over time."),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Changes in the list price of a product over time."),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Changes in the list price of a product over time."),
                    ListPrice = table.Column<decimal>(type: "money", nullable: false, comment: "Changes in the list price of a product over time."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Changes in the list price of a product over time.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductListPriceHistory_ProductID_StartDate", x => new { x.ProductID, x.StartDate });
                    table.ForeignKey(
                        name: "FK_ProductListPriceHistory_Product_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Changes in the list price of a product over time.");

            migrationBuilder.CreateTable(
                name: "ProductProductPhoto",
                schema: "Production",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false, comment: "Cross-reference table mapping products and product photos."),
                    ProductPhotoID = table.Column<int>(nullable: false, comment: "Cross-reference table mapping products and product photos."),
                    Primary = table.Column<bool>(nullable: false, comment: "Cross-reference table mapping products and product photos."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Cross-reference table mapping products and product photos.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductPhoto_ProductID_ProductPhotoID", x => new { x.ProductID, x.ProductPhotoID })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_ProductProductPhoto_Product_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductProductPhoto_ProductPhoto_ProductPhotoID",
                        column: x => x.ProductPhotoID,
                        principalSchema: "Production",
                        principalTable: "ProductPhoto",
                        principalColumn: "ProductPhotoID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Cross-reference table mapping products and product photos.");

            migrationBuilder.CreateTable(
                name: "ProductReview",
                schema: "Production",
                columns: table => new
                {
                    ProductReviewID = table.Column<int>(nullable: false, comment: "Customer reviews of products they have purchased.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(nullable: false, comment: "Customer reviews of products they have purchased."),
                    ReviewerName = table.Column<string>(maxLength: 50, nullable: false, comment: "Customer reviews of products they have purchased."),
                    ReviewDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Customer reviews of products they have purchased."),
                    EmailAddress = table.Column<string>(maxLength: 50, nullable: false, comment: "Customer reviews of products they have purchased."),
                    Rating = table.Column<int>(nullable: false, comment: "Customer reviews of products they have purchased."),
                    Comments = table.Column<string>(maxLength: 3850, nullable: true, comment: "Customer reviews of products they have purchased."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Customer reviews of products they have purchased.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReview", x => x.ProductReviewID);
                    table.ForeignKey(
                        name: "FK_ProductReview_Product_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Customer reviews of products they have purchased.");

            migrationBuilder.CreateTable(
                name: "TransactionHistory",
                schema: "Production",
                columns: table => new
                {
                    TransactionID = table.Column<int>(nullable: false, comment: "Record of each purchase order, sales order, or work order transaction year to date.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(nullable: false, comment: "Record of each purchase order, sales order, or work order transaction year to date."),
                    ReferenceOrderID = table.Column<int>(nullable: false, comment: "Record of each purchase order, sales order, or work order transaction year to date."),
                    ReferenceOrderLineID = table.Column<int>(nullable: false, comment: "Record of each purchase order, sales order, or work order transaction year to date."),
                    TransactionDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Record of each purchase order, sales order, or work order transaction year to date."),
                    TransactionType = table.Column<string>(fixedLength: true, maxLength: 1, nullable: false, comment: "Record of each purchase order, sales order, or work order transaction year to date."),
                    Quantity = table.Column<int>(nullable: false, comment: "Record of each purchase order, sales order, or work order transaction year to date."),
                    ActualCost = table.Column<decimal>(type: "money", nullable: false, comment: "Record of each purchase order, sales order, or work order transaction year to date."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Record of each purchase order, sales order, or work order transaction year to date.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionHistory_TransactionID", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_TransactionHistory_Product_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Record of each purchase order, sales order, or work order transaction year to date.");

            migrationBuilder.CreateTable(
                name: "WorkOrder",
                schema: "Production",
                columns: table => new
                {
                    WorkOrderID = table.Column<int>(nullable: false, comment: "Manufacturing work orders.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(nullable: false, comment: "Manufacturing work orders."),
                    OrderQty = table.Column<int>(nullable: false, comment: "Manufacturing work orders."),
                    StockedQty = table.Column<int>(nullable: false, computedColumnSql: "(isnull([OrderQty]-[ScrappedQty],(0)))", comment: "Manufacturing work orders."),
                    ScrappedQty = table.Column<short>(nullable: false, comment: "Manufacturing work orders."),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Manufacturing work orders."),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Manufacturing work orders."),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Manufacturing work orders."),
                    ScrapReasonID = table.Column<short>(nullable: true, comment: "Manufacturing work orders."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Manufacturing work orders.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrder", x => x.WorkOrderID);
                    table.ForeignKey(
                        name: "FK_WorkOrder_Product_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkOrder_ScrapReason_ScrapReasonID",
                        column: x => x.ScrapReasonID,
                        principalSchema: "Production",
                        principalTable: "ScrapReason",
                        principalColumn: "ScrapReasonID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Manufacturing work orders.");

            migrationBuilder.CreateTable(
                name: "ProductVendor",
                schema: "Purchasing",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false, comment: "Cross-reference table mapping vendors with the products they supply."),
                    BusinessEntityID = table.Column<int>(nullable: false, comment: "Cross-reference table mapping vendors with the products they supply."),
                    AverageLeadTime = table.Column<int>(nullable: false, comment: "Cross-reference table mapping vendors with the products they supply."),
                    StandardPrice = table.Column<decimal>(type: "money", nullable: false, comment: "Cross-reference table mapping vendors with the products they supply."),
                    LastReceiptCost = table.Column<decimal>(type: "money", nullable: true, comment: "Cross-reference table mapping vendors with the products they supply."),
                    LastReceiptDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Cross-reference table mapping vendors with the products they supply."),
                    MinOrderQty = table.Column<int>(nullable: false, comment: "Cross-reference table mapping vendors with the products they supply."),
                    MaxOrderQty = table.Column<int>(nullable: false, comment: "Cross-reference table mapping vendors with the products they supply."),
                    OnOrderQty = table.Column<int>(nullable: true, comment: "Cross-reference table mapping vendors with the products they supply."),
                    UnitMeasureCode = table.Column<string>(fixedLength: true, maxLength: 3, nullable: false, comment: "Cross-reference table mapping vendors with the products they supply."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Cross-reference table mapping vendors with the products they supply.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVendor_ProductID_BusinessEntityID", x => new { x.ProductID, x.BusinessEntityID });
                    table.ForeignKey(
                        name: "FK_ProductVendor_Vendor_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "Purchasing",
                        principalTable: "Vendor",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductVendor_Product_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductVendor_UnitMeasure_UnitMeasureCode",
                        column: x => x.UnitMeasureCode,
                        principalSchema: "Production",
                        principalTable: "UnitMeasure",
                        principalColumn: "UnitMeasureCode",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Cross-reference table mapping vendors with the products they supply.");

            migrationBuilder.CreateTable(
                name: "ShoppingCartItem",
                schema: "Sales",
                columns: table => new
                {
                    ShoppingCartItemID = table.Column<int>(nullable: false, comment: "Contains online customer orders until the order is submitted or cancelled.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingCartID = table.Column<string>(maxLength: 50, nullable: false, comment: "Contains online customer orders until the order is submitted or cancelled."),
                    Quantity = table.Column<int>(nullable: false, defaultValueSql: "((1))", comment: "Contains online customer orders until the order is submitted or cancelled."),
                    ProductID = table.Column<int>(nullable: false, comment: "Contains online customer orders until the order is submitted or cancelled."),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Contains online customer orders until the order is submitted or cancelled."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Contains online customer orders until the order is submitted or cancelled.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItem", x => x.ShoppingCartItemID);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_Product_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Contains online customer orders until the order is submitted or cancelled.");

            migrationBuilder.CreateTable(
                name: "SpecialOfferProduct",
                schema: "Sales",
                columns: table => new
                {
                    SpecialOfferID = table.Column<int>(nullable: false, comment: "Cross-reference table mapping products to special offer discounts."),
                    ProductID = table.Column<int>(nullable: false, comment: "Cross-reference table mapping products to special offer discounts."),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())", comment: "Cross-reference table mapping products to special offer discounts."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Cross-reference table mapping products to special offer discounts.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialOfferProduct_SpecialOfferID_ProductID", x => new { x.SpecialOfferID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_SpecialOfferProduct_Product_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecialOfferProduct_SpecialOffer_SpecialOfferID",
                        column: x => x.SpecialOfferID,
                        principalSchema: "Sales",
                        principalTable: "SpecialOffer",
                        principalColumn: "SpecialOfferID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Cross-reference table mapping products to special offer discounts.");

            migrationBuilder.CreateTable(
                name: "PurchaseOrderDetail",
                schema: "Purchasing",
                columns: table => new
                {
                    PurchaseOrderID = table.Column<int>(nullable: false, comment: "Individual products associated with a specific purchase order. See PurchaseOrderHeader."),
                    PurchaseOrderDetailID = table.Column<int>(nullable: false, comment: "Individual products associated with a specific purchase order. See PurchaseOrderHeader.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Individual products associated with a specific purchase order. See PurchaseOrderHeader."),
                    OrderQty = table.Column<short>(nullable: false, comment: "Individual products associated with a specific purchase order. See PurchaseOrderHeader."),
                    ProductID = table.Column<int>(nullable: false, comment: "Individual products associated with a specific purchase order. See PurchaseOrderHeader."),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false, comment: "Individual products associated with a specific purchase order. See PurchaseOrderHeader."),
                    LineTotal = table.Column<decimal>(type: "money", nullable: false, computedColumnSql: "(isnull([OrderQty]*[UnitPrice],(0.00)))", comment: "Individual products associated with a specific purchase order. See PurchaseOrderHeader."),
                    ReceivedQty = table.Column<decimal>(type: "decimal(8, 2)", nullable: false, comment: "Individual products associated with a specific purchase order. See PurchaseOrderHeader."),
                    RejectedQty = table.Column<decimal>(type: "decimal(8, 2)", nullable: false, comment: "Individual products associated with a specific purchase order. See PurchaseOrderHeader."),
                    StockedQty = table.Column<decimal>(type: "decimal(9, 2)", nullable: false, computedColumnSql: "(isnull([ReceivedQty]-[RejectedQty],(0.00)))", comment: "Individual products associated with a specific purchase order. See PurchaseOrderHeader."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Individual products associated with a specific purchase order. See PurchaseOrderHeader.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderDetail_PurchaseOrderID_PurchaseOrderDetailID", x => new { x.PurchaseOrderID, x.PurchaseOrderDetailID });
                    table.ForeignKey(
                        name: "FK_PurchaseOrderDetail_Product_ProductID",
                        column: x => x.ProductID,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderDetail_PurchaseOrderHeader_PurchaseOrderID",
                        column: x => x.PurchaseOrderID,
                        principalSchema: "Purchasing",
                        principalTable: "PurchaseOrderHeader",
                        principalColumn: "PurchaseOrderID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Individual products associated with a specific purchase order. See PurchaseOrderHeader.");

            migrationBuilder.CreateTable(
                name: "SalesPersonQuotaHistory",
                schema: "Sales",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false, comment: "Sales performance tracking."),
                    QuotaDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Sales performance tracking."),
                    SalesQuota = table.Column<decimal>(type: "money", nullable: false, comment: "Sales performance tracking."),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())", comment: "Sales performance tracking."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Sales performance tracking.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPersonQuotaHistory_BusinessEntityID_QuotaDate", x => new { x.BusinessEntityID, x.QuotaDate });
                    table.ForeignKey(
                        name: "FK_SalesPersonQuotaHistory_SalesPerson_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "Sales",
                        principalTable: "SalesPerson",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Sales performance tracking.");

            migrationBuilder.CreateTable(
                name: "SalesTerritoryHistory",
                schema: "Sales",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false, comment: "Sales representative transfers to other sales territories."),
                    TerritoryID = table.Column<int>(nullable: false, comment: "Sales representative transfers to other sales territories."),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Sales representative transfers to other sales territories."),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Sales representative transfers to other sales territories."),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())", comment: "Sales representative transfers to other sales territories."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Sales representative transfers to other sales territories.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesTerritoryHistory_BusinessEntityID_StartDate_TerritoryID", x => new { x.BusinessEntityID, x.StartDate, x.TerritoryID });
                    table.ForeignKey(
                        name: "FK_SalesTerritoryHistory_SalesPerson_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "Sales",
                        principalTable: "SalesPerson",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesTerritoryHistory_SalesTerritory_TerritoryID",
                        column: x => x.TerritoryID,
                        principalSchema: "Sales",
                        principalTable: "SalesTerritory",
                        principalColumn: "TerritoryID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Sales representative transfers to other sales territories.");

            migrationBuilder.CreateTable(
                name: "Store",
                schema: "Sales",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false, comment: "Customers (resellers) of Adventure Works products."),
                    Name = table.Column<string>(maxLength: 50, nullable: false, comment: "Customers (resellers) of Adventure Works products."),
                    SalesPersonID = table.Column<int>(nullable: true, comment: "Customers (resellers) of Adventure Works products."),
                    Demographics = table.Column<string>(type: "xml", nullable: true, comment: "Customers (resellers) of Adventure Works products."),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())", comment: "Customers (resellers) of Adventure Works products."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Customers (resellers) of Adventure Works products.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store_BusinessEntityID", x => x.BusinessEntityID);
                    table.ForeignKey(
                        name: "FK_Store_BusinessEntity_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "Person",
                        principalTable: "BusinessEntity",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Store_SalesPerson_SalesPersonID",
                        column: x => x.SalesPersonID,
                        principalSchema: "Sales",
                        principalTable: "SalesPerson",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Customers (resellers) of Adventure Works products.");

            migrationBuilder.CreateTable(
                name: "BusinessEntityAddress",
                schema: "Person",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false, comment: "Cross-reference table mapping customers, vendors, and employees to their addresses."),
                    AddressID = table.Column<int>(nullable: false, comment: "Cross-reference table mapping customers, vendors, and employees to their addresses."),
                    AddressTypeID = table.Column<int>(nullable: false, comment: "Cross-reference table mapping customers, vendors, and employees to their addresses."),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())", comment: "Cross-reference table mapping customers, vendors, and employees to their addresses."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Cross-reference table mapping customers, vendors, and employees to their addresses.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessEntityAddress_BusinessEntityID_AddressID_AddressTypeID", x => new { x.BusinessEntityID, x.AddressID, x.AddressTypeID });
                    table.ForeignKey(
                        name: "FK_BusinessEntityAddress_Address_AddressID",
                        column: x => x.AddressID,
                        principalSchema: "Person",
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessEntityAddress_AddressType_AddressTypeID",
                        column: x => x.AddressTypeID,
                        principalSchema: "Person",
                        principalTable: "AddressType",
                        principalColumn: "AddressTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessEntityAddress_BusinessEntity_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "Person",
                        principalTable: "BusinessEntity",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Cross-reference table mapping customers, vendors, and employees to their addresses.");

            migrationBuilder.CreateTable(
                name: "WorkOrderRouting",
                schema: "Production",
                columns: table => new
                {
                    WorkOrderID = table.Column<int>(nullable: false, comment: "Work order details."),
                    ProductID = table.Column<int>(nullable: false, comment: "Work order details."),
                    OperationSequence = table.Column<short>(nullable: false, comment: "Work order details."),
                    LocationID = table.Column<short>(nullable: false, comment: "Work order details."),
                    ScheduledStartDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Work order details."),
                    ScheduledEndDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Work order details."),
                    ActualStartDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Work order details."),
                    ActualEndDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Work order details."),
                    ActualResourceHrs = table.Column<decimal>(type: "decimal(9, 4)", nullable: true, comment: "Work order details."),
                    PlannedCost = table.Column<decimal>(type: "money", nullable: false, comment: "Work order details."),
                    ActualCost = table.Column<decimal>(type: "money", nullable: true, comment: "Work order details."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Work order details.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderRouting_WorkOrderID_ProductID_OperationSequence", x => new { x.WorkOrderID, x.ProductID, x.OperationSequence });
                    table.ForeignKey(
                        name: "FK_WorkOrderRouting_Location_LocationID",
                        column: x => x.LocationID,
                        principalSchema: "Production",
                        principalTable: "Location",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkOrderRouting_WorkOrder_WorkOrderID",
                        column: x => x.WorkOrderID,
                        principalSchema: "Production",
                        principalTable: "WorkOrder",
                        principalColumn: "WorkOrderID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Work order details.");

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "Sales",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false, comment: "Current customer information. Also see the Person and Store tables.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonID = table.Column<int>(nullable: true, comment: "Current customer information. Also see the Person and Store tables."),
                    StoreID = table.Column<int>(nullable: true, comment: "Current customer information. Also see the Person and Store tables."),
                    TerritoryID = table.Column<int>(nullable: true, comment: "Current customer information. Also see the Person and Store tables."),
                    AccountNumber = table.Column<string>(unicode: false, maxLength: 10, nullable: false, computedColumnSql: "(isnull('AW'+[dbo].[ufnLeadingZeros]([CustomerID]),''))", comment: "Current customer information. Also see the Person and Store tables."),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())", comment: "Current customer information. Also see the Person and Store tables."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Current customer information. Also see the Person and Store tables.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customer_Person_PersonID",
                        column: x => x.PersonID,
                        principalSchema: "Person",
                        principalTable: "Person",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customer_Store_StoreID",
                        column: x => x.StoreID,
                        principalSchema: "Sales",
                        principalTable: "Store",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customer_SalesTerritory_TerritoryID",
                        column: x => x.TerritoryID,
                        principalSchema: "Sales",
                        principalTable: "SalesTerritory",
                        principalColumn: "TerritoryID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Current customer information. Also see the Person and Store tables.");

            migrationBuilder.CreateTable(
                name: "SalesOrderHeader",
                schema: "Sales",
                columns: table => new
                {
                    SalesOrderID = table.Column<int>(nullable: false, comment: "General sales order information.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RevisionNumber = table.Column<byte>(nullable: false, comment: "General sales order information."),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "General sales order information."),
                    DueDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "General sales order information."),
                    ShipDate = table.Column<DateTime>(type: "datetime", nullable: true, comment: "General sales order information."),
                    Status = table.Column<byte>(nullable: false, defaultValueSql: "((1))", comment: "General sales order information."),
                    OnlineOrderFlag = table.Column<bool>(nullable: false, defaultValueSql: "((1))", comment: "General sales order information."),
                    SalesOrderNumber = table.Column<string>(maxLength: 25, nullable: false, computedColumnSql: "(isnull(N'SO'+CONVERT([nvarchar](23),[SalesOrderID]),N'*** ERROR ***'))", comment: "General sales order information."),
                    PurchaseOrderNumber = table.Column<string>(maxLength: 25, nullable: true, comment: "General sales order information."),
                    AccountNumber = table.Column<string>(maxLength: 15, nullable: true, comment: "General sales order information."),
                    CustomerID = table.Column<int>(nullable: false, comment: "General sales order information."),
                    SalesPersonID = table.Column<int>(nullable: true, comment: "General sales order information."),
                    TerritoryID = table.Column<int>(nullable: true, comment: "General sales order information."),
                    BillToAddressID = table.Column<int>(nullable: false, comment: "General sales order information."),
                    ShipToAddressID = table.Column<int>(nullable: false, comment: "General sales order information."),
                    ShipMethodID = table.Column<int>(nullable: false, comment: "General sales order information."),
                    CreditCardID = table.Column<int>(nullable: true, comment: "General sales order information."),
                    CreditCardApprovalCode = table.Column<string>(unicode: false, maxLength: 15, nullable: true, comment: "General sales order information."),
                    CurrencyRateID = table.Column<int>(nullable: true, comment: "General sales order information."),
                    SubTotal = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))", comment: "General sales order information."),
                    TaxAmt = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))", comment: "General sales order information."),
                    Freight = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((0.00))", comment: "General sales order information."),
                    TotalDue = table.Column<decimal>(type: "money", nullable: false, computedColumnSql: "(isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))", comment: "General sales order information."),
                    Comment = table.Column<string>(maxLength: 128, nullable: true, comment: "General sales order information."),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())", comment: "General sales order information."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "General sales order information.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderHeader_SalesOrderID", x => x.SalesOrderID);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_Address_BillToAddressID",
                        column: x => x.BillToAddressID,
                        principalSchema: "Person",
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_CreditCard_CreditCardID",
                        column: x => x.CreditCardID,
                        principalSchema: "Sales",
                        principalTable: "CreditCard",
                        principalColumn: "CreditCardID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_CurrencyRate_CurrencyRateID",
                        column: x => x.CurrencyRateID,
                        principalSchema: "Sales",
                        principalTable: "CurrencyRate",
                        principalColumn: "CurrencyRateID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalSchema: "Sales",
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_SalesPerson_SalesPersonID",
                        column: x => x.SalesPersonID,
                        principalSchema: "Sales",
                        principalTable: "SalesPerson",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_ShipMethod_ShipMethodID",
                        column: x => x.ShipMethodID,
                        principalSchema: "Purchasing",
                        principalTable: "ShipMethod",
                        principalColumn: "ShipMethodID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_Address_ShipToAddressID",
                        column: x => x.ShipToAddressID,
                        principalSchema: "Person",
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeader_SalesTerritory_TerritoryID",
                        column: x => x.TerritoryID,
                        principalSchema: "Sales",
                        principalTable: "SalesTerritory",
                        principalColumn: "TerritoryID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "General sales order information.");

            migrationBuilder.CreateTable(
                name: "SalesOrderDetail",
                schema: "Sales",
                columns: table => new
                {
                    SalesOrderID = table.Column<int>(nullable: false, comment: "Individual products associated with a specific sales order. See SalesOrderHeader."),
                    SalesOrderDetailID = table.Column<int>(nullable: false, comment: "Individual products associated with a specific sales order. See SalesOrderHeader.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarrierTrackingNumber = table.Column<string>(maxLength: 25, nullable: true, comment: "Individual products associated with a specific sales order. See SalesOrderHeader."),
                    OrderQty = table.Column<short>(nullable: false, comment: "Individual products associated with a specific sales order. See SalesOrderHeader."),
                    ProductID = table.Column<int>(nullable: false, comment: "Individual products associated with a specific sales order. See SalesOrderHeader."),
                    SpecialOfferID = table.Column<int>(nullable: false, comment: "Individual products associated with a specific sales order. See SalesOrderHeader."),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false, comment: "Individual products associated with a specific sales order. See SalesOrderHeader."),
                    UnitPriceDiscount = table.Column<decimal>(type: "money", nullable: false, comment: "Individual products associated with a specific sales order. See SalesOrderHeader."),
                    LineTotal = table.Column<decimal>(type: "numeric(38, 6)", nullable: false, computedColumnSql: "(isnull(([UnitPrice]*((1.0)-[UnitPriceDiscount]))*[OrderQty],(0.0)))", comment: "Individual products associated with a specific sales order. See SalesOrderHeader."),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())", comment: "Individual products associated with a specific sales order. See SalesOrderHeader."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Individual products associated with a specific sales order. See SalesOrderHeader.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID", x => new { x.SalesOrderID, x.SalesOrderDetailID });
                    table.ForeignKey(
                        name: "FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID",
                        column: x => x.SalesOrderID,
                        principalSchema: "Sales",
                        principalTable: "SalesOrderHeader",
                        principalColumn: "SalesOrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID",
                        columns: x => new { x.SpecialOfferID, x.ProductID },
                        principalSchema: "Sales",
                        principalTable: "SpecialOfferProduct",
                        principalColumns: new[] { "SpecialOfferID", "ProductID" },
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Individual products associated with a specific sales order. See SalesOrderHeader.");

            migrationBuilder.CreateTable(
                name: "SalesOrderHeaderSalesReason",
                schema: "Sales",
                columns: table => new
                {
                    SalesOrderID = table.Column<int>(nullable: false, comment: "Cross-reference table mapping sales orders to sales reason codes."),
                    SalesReasonID = table.Column<int>(nullable: false, comment: "Cross-reference table mapping sales orders to sales reason codes."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Cross-reference table mapping sales orders to sales reason codes.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderHeaderSalesReason_SalesOrderID_SalesReasonID", x => new { x.SalesOrderID, x.SalesReasonID });
                    table.ForeignKey(
                        name: "FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderID",
                        column: x => x.SalesOrderID,
                        principalSchema: "Sales",
                        principalTable: "SalesOrderHeader",
                        principalColumn: "SalesOrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrderHeaderSalesReason_SalesReason_SalesReasonID",
                        column: x => x.SalesReasonID,
                        principalSchema: "Sales",
                        principalTable: "SalesReason",
                        principalColumn: "SalesReasonID",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Cross-reference table mapping sales orders to sales reason codes.");

            migrationBuilder.CreateIndex(
                name: "AK_Department_Name",
                schema: "HumanResources",
                table: "Department",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Employee_LoginID",
                schema: "HumanResources",
                table: "Employee",
                column: "LoginID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Employee_NationalIDNumber",
                schema: "HumanResources",
                table: "Employee",
                column: "NationalIDNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Employee_rowguid",
                schema: "HumanResources",
                table: "Employee",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDepartmentHistory_DepartmentID",
                schema: "HumanResources",
                table: "EmployeeDepartmentHistory",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDepartmentHistory_ShiftID",
                schema: "HumanResources",
                table: "EmployeeDepartmentHistory",
                column: "ShiftID");

            migrationBuilder.CreateIndex(
                name: "IX_JobCandidate_BusinessEntityID",
                schema: "HumanResources",
                table: "JobCandidate",
                column: "BusinessEntityID");

            migrationBuilder.CreateIndex(
                name: "AK_Shift_Name",
                schema: "HumanResources",
                table: "Shift",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Shift_StartTime_EndTime",
                schema: "HumanResources",
                table: "Shift",
                columns: new[] { "StartTime", "EndTime" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Address_rowguid",
                schema: "Person",
                table: "Address",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_StateProvinceID",
                schema: "Person",
                table: "Address",
                column: "StateProvinceID");

            migrationBuilder.CreateIndex(
                name: "IX_Address_AddressLine1_AddressLine2_City_StateProvinceID_PostalCode",
                schema: "Person",
                table: "Address",
                columns: new[] { "AddressLine1", "AddressLine2", "City", "StateProvinceID", "PostalCode" },
                unique: true,
                filter: "[AddressLine2] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "AK_AddressType_Name",
                schema: "Person",
                table: "AddressType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_AddressType_rowguid",
                schema: "Person",
                table: "AddressType",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_BusinessEntity_rowguid",
                schema: "Person",
                table: "BusinessEntity",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessEntityAddress_AddressID",
                schema: "Person",
                table: "BusinessEntityAddress",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessEntityAddress_AddressTypeID",
                schema: "Person",
                table: "BusinessEntityAddress",
                column: "AddressTypeID");

            migrationBuilder.CreateIndex(
                name: "AK_BusinessEntityAddress_rowguid",
                schema: "Person",
                table: "BusinessEntityAddress",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessEntityContact_ContactTypeID",
                schema: "Person",
                table: "BusinessEntityContact",
                column: "ContactTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessEntityContact_PersonID",
                schema: "Person",
                table: "BusinessEntityContact",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "AK_BusinessEntityContact_rowguid",
                schema: "Person",
                table: "BusinessEntityContact",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_ContactType_Name",
                schema: "Person",
                table: "ContactType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_CountryRegion_Name",
                schema: "Person",
                table: "CountryRegion",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddress_EmailAddress",
                schema: "Person",
                table: "EmailAddress",
                column: "EmailAddress");

            migrationBuilder.CreateIndex(
                name: "PXML_Person_AddContact",
                schema: "Person",
                table: "Person",
                column: "AdditionalContactInfo");

            migrationBuilder.CreateIndex(
                name: "XMLVALUE_Person_Demographics",
                schema: "Person",
                table: "Person",
                column: "Demographics");

            migrationBuilder.CreateIndex(
                name: "AK_Person_rowguid",
                schema: "Person",
                table: "Person",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_LastName_FirstName_MiddleName",
                schema: "Person",
                table: "Person",
                columns: new[] { "LastName", "FirstName", "MiddleName" });

            migrationBuilder.CreateIndex(
                name: "IX_PersonPhone_PhoneNumber",
                schema: "Person",
                table: "PersonPhone",
                column: "PhoneNumber");

            migrationBuilder.CreateIndex(
                name: "IX_PersonPhone_PhoneNumberTypeID",
                schema: "Person",
                table: "PersonPhone",
                column: "PhoneNumberTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_StateProvince_CountryRegionCode",
                schema: "Person",
                table: "StateProvince",
                column: "CountryRegionCode");

            migrationBuilder.CreateIndex(
                name: "AK_StateProvince_Name",
                schema: "Person",
                table: "StateProvince",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_StateProvince_rowguid",
                schema: "Person",
                table: "StateProvince",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StateProvince_TerritoryID",
                schema: "Person",
                table: "StateProvince",
                column: "TerritoryID");

            migrationBuilder.CreateIndex(
                name: "AK_StateProvince_StateProvinceCode_CountryRegionCode",
                schema: "Person",
                table: "StateProvince",
                columns: new[] { "StateProvinceCode", "CountryRegionCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BillOfMaterials_ComponentID",
                schema: "Production",
                table: "BillOfMaterials",
                column: "ComponentID");

            migrationBuilder.CreateIndex(
                name: "IX_BillOfMaterials_UnitMeasureCode",
                schema: "Production",
                table: "BillOfMaterials",
                column: "UnitMeasureCode");

            migrationBuilder.CreateIndex(
                name: "AK_BillOfMaterials_ProductAssemblyID_ComponentID_StartDate",
                schema: "Production",
                table: "BillOfMaterials",
                columns: new[] { "ProductAssemblyID", "ComponentID", "StartDate" },
                unique: true)
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "AK_Culture_Name",
                schema: "Production",
                table: "Culture",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Location_Name",
                schema: "Production",
                table: "Location",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Product_Name",
                schema: "Production",
                table: "Product",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductModelID",
                schema: "Production",
                table: "Product",
                column: "ProductModelID");

            migrationBuilder.CreateIndex(
                name: "AK_Product_ProductNumber",
                schema: "Production",
                table: "Product",
                column: "ProductNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductSubcategoryID",
                schema: "Production",
                table: "Product",
                column: "ProductSubcategoryID");

            migrationBuilder.CreateIndex(
                name: "AK_Product_rowguid",
                schema: "Production",
                table: "Product",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_SizeUnitMeasureCode",
                schema: "Production",
                table: "Product",
                column: "SizeUnitMeasureCode");

            migrationBuilder.CreateIndex(
                name: "IX_Product_WeightUnitMeasureCode",
                schema: "Production",
                table: "Product",
                column: "WeightUnitMeasureCode");

            migrationBuilder.CreateIndex(
                name: "AK_ProductCategory_Name",
                schema: "Production",
                table: "ProductCategory",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_ProductCategory_rowguid",
                schema: "Production",
                table: "ProductCategory",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_ProductDescription_rowguid",
                schema: "Production",
                table: "ProductDescription",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventory_LocationID",
                schema: "Production",
                table: "ProductInventory",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "PXML_ProductModel_CatalogDescription",
                schema: "Production",
                table: "ProductModel",
                column: "CatalogDescription");

            migrationBuilder.CreateIndex(
                name: "PXML_ProductModel_Instructions",
                schema: "Production",
                table: "ProductModel",
                column: "Instructions");

            migrationBuilder.CreateIndex(
                name: "AK_ProductModel_Name",
                schema: "Production",
                table: "ProductModel",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_ProductModel_rowguid",
                schema: "Production",
                table: "ProductModel",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductModelIllustration_IllustrationID",
                schema: "Production",
                table: "ProductModelIllustration",
                column: "IllustrationID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModelProductDescriptionCulture_CultureID",
                schema: "Production",
                table: "ProductModelProductDescriptionCulture",
                column: "CultureID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModelProductDescriptionCulture_ProductDescriptionID",
                schema: "Production",
                table: "ProductModelProductDescriptionCulture",
                column: "ProductDescriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductPhoto_ProductPhotoID",
                schema: "Production",
                table: "ProductProductPhoto",
                column: "ProductPhotoID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReview_ProductID",
                schema: "Production",
                table: "ProductReview",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReview_ProductID_Name",
                schema: "Production",
                table: "ProductReview",
                columns: new[] { "Comments", "ProductID", "ReviewerName" });

            migrationBuilder.CreateIndex(
                name: "AK_ProductSubcategory_Name",
                schema: "Production",
                table: "ProductSubcategory",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductSubcategory_ProductCategoryID",
                schema: "Production",
                table: "ProductSubcategory",
                column: "ProductCategoryID");

            migrationBuilder.CreateIndex(
                name: "AK_ProductSubcategory_rowguid",
                schema: "Production",
                table: "ProductSubcategory",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_ScrapReason_Name",
                schema: "Production",
                table: "ScrapReason",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_ProductID",
                schema: "Production",
                table: "TransactionHistory",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_ReferenceOrderID_ReferenceOrderLineID",
                schema: "Production",
                table: "TransactionHistory",
                columns: new[] { "ReferenceOrderID", "ReferenceOrderLineID" });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistoryArchive_ProductID",
                schema: "Production",
                table: "TransactionHistoryArchive",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistoryArchive_ReferenceOrderID_ReferenceOrderLineID",
                schema: "Production",
                table: "TransactionHistoryArchive",
                columns: new[] { "ReferenceOrderID", "ReferenceOrderLineID" });

            migrationBuilder.CreateIndex(
                name: "AK_UnitMeasure_Name",
                schema: "Production",
                table: "UnitMeasure",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrder_ProductID",
                schema: "Production",
                table: "WorkOrder",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrder_ScrapReasonID",
                schema: "Production",
                table: "WorkOrder",
                column: "ScrapReasonID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderRouting_LocationID",
                schema: "Production",
                table: "WorkOrderRouting",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderRouting_ProductID",
                schema: "Production",
                table: "WorkOrderRouting",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVendor_BusinessEntityID",
                schema: "Purchasing",
                table: "ProductVendor",
                column: "BusinessEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVendor_UnitMeasureCode",
                schema: "Purchasing",
                table: "ProductVendor",
                column: "UnitMeasureCode");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderDetail_ProductID",
                schema: "Purchasing",
                table: "PurchaseOrderDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderHeader_EmployeeID",
                schema: "Purchasing",
                table: "PurchaseOrderHeader",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderHeader_ShipMethodID",
                schema: "Purchasing",
                table: "PurchaseOrderHeader",
                column: "ShipMethodID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderHeader_VendorID",
                schema: "Purchasing",
                table: "PurchaseOrderHeader",
                column: "VendorID");

            migrationBuilder.CreateIndex(
                name: "AK_ShipMethod_Name",
                schema: "Purchasing",
                table: "ShipMethod",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_ShipMethod_rowguid",
                schema: "Purchasing",
                table: "ShipMethod",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Vendor_AccountNumber",
                schema: "Purchasing",
                table: "Vendor",
                column: "AccountNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CountryRegionCurrency_CurrencyCode",
                schema: "Sales",
                table: "CountryRegionCurrency",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "AK_CreditCard_CardNumber",
                schema: "Sales",
                table: "CreditCard",
                column: "CardNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Currency_Name",
                schema: "Sales",
                table: "Currency",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyRate_FromCurrencyCode",
                schema: "Sales",
                table: "CurrencyRate",
                column: "FromCurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyRate_ToCurrencyCode",
                schema: "Sales",
                table: "CurrencyRate",
                column: "ToCurrencyCode");

            migrationBuilder.CreateIndex(
                name: "AK_CurrencyRate_CurrencyRateDate_FromCurrencyCode_ToCurrencyCode",
                schema: "Sales",
                table: "CurrencyRate",
                columns: new[] { "CurrencyRateDate", "FromCurrencyCode", "ToCurrencyCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Customer_AccountNumber",
                schema: "Sales",
                table: "Customer",
                column: "AccountNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_PersonID",
                schema: "Sales",
                table: "Customer",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "AK_Customer_rowguid",
                schema: "Sales",
                table: "Customer",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_StoreID",
                schema: "Sales",
                table: "Customer",
                column: "StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_TerritoryID",
                schema: "Sales",
                table: "Customer",
                column: "TerritoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonCreditCard_CreditCardID",
                schema: "Sales",
                table: "PersonCreditCard",
                column: "CreditCardID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderDetail_ProductID",
                schema: "Sales",
                table: "SalesOrderDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "AK_SalesOrderDetail_rowguid",
                schema: "Sales",
                table: "SalesOrderDetail",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderDetail_SpecialOfferID_ProductID",
                schema: "Sales",
                table: "SalesOrderDetail",
                columns: new[] { "SpecialOfferID", "ProductID" });

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeader_BillToAddressID",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "BillToAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeader_CreditCardID",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "CreditCardID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeader_CurrencyRateID",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "CurrencyRateID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeader_CustomerID",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "AK_SalesOrderHeader_rowguid",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_SalesOrderHeader_SalesOrderNumber",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "SalesOrderNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeader_SalesPersonID",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "SalesPersonID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeader_ShipMethodID",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "ShipMethodID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeader_ShipToAddressID",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "ShipToAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeader_TerritoryID",
                schema: "Sales",
                table: "SalesOrderHeader",
                column: "TerritoryID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderHeaderSalesReason_SalesReasonID",
                schema: "Sales",
                table: "SalesOrderHeaderSalesReason",
                column: "SalesReasonID");

            migrationBuilder.CreateIndex(
                name: "AK_SalesPerson_rowguid",
                schema: "Sales",
                table: "SalesPerson",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesPerson_TerritoryID",
                schema: "Sales",
                table: "SalesPerson",
                column: "TerritoryID");

            migrationBuilder.CreateIndex(
                name: "AK_SalesPersonQuotaHistory_rowguid",
                schema: "Sales",
                table: "SalesPersonQuotaHistory",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_SalesTaxRate_rowguid",
                schema: "Sales",
                table: "SalesTaxRate",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_SalesTaxRate_StateProvinceID_TaxType",
                schema: "Sales",
                table: "SalesTaxRate",
                columns: new[] { "StateProvinceID", "TaxType" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesTerritory_CountryRegionCode",
                schema: "Sales",
                table: "SalesTerritory",
                column: "CountryRegionCode");

            migrationBuilder.CreateIndex(
                name: "AK_SalesTerritory_Name",
                schema: "Sales",
                table: "SalesTerritory",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_SalesTerritory_rowguid",
                schema: "Sales",
                table: "SalesTerritory",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_SalesTerritoryHistory_rowguid",
                schema: "Sales",
                table: "SalesTerritoryHistory",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesTerritoryHistory_TerritoryID",
                schema: "Sales",
                table: "SalesTerritoryHistory",
                column: "TerritoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_ProductID",
                schema: "Sales",
                table: "ShoppingCartItem",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_ShoppingCartID_ProductID",
                schema: "Sales",
                table: "ShoppingCartItem",
                columns: new[] { "ShoppingCartID", "ProductID" });

            migrationBuilder.CreateIndex(
                name: "AK_SpecialOffer_rowguid",
                schema: "Sales",
                table: "SpecialOffer",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpecialOfferProduct_ProductID",
                schema: "Sales",
                table: "SpecialOfferProduct",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "AK_SpecialOfferProduct_rowguid",
                schema: "Sales",
                table: "SpecialOfferProduct",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PXML_Store_Demographics",
                schema: "Sales",
                table: "Store",
                column: "Demographics");

            migrationBuilder.CreateIndex(
                name: "AK_Store_rowguid",
                schema: "Sales",
                table: "Store",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Store_SalesPersonID",
                schema: "Sales",
                table: "Store",
                column: "SalesPersonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AWBuildVersion");

            migrationBuilder.DropTable(
                name: "DatabaseLog");

            migrationBuilder.DropTable(
                name: "ErrorLog");

            migrationBuilder.DropTable(
                name: "EmployeeDepartmentHistory",
                schema: "HumanResources");

            migrationBuilder.DropTable(
                name: "EmployeePayHistory",
                schema: "HumanResources");

            migrationBuilder.DropTable(
                name: "JobCandidate",
                schema: "HumanResources");

            migrationBuilder.DropTable(
                name: "BusinessEntityAddress",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "BusinessEntityContact",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "EmailAddress",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "Password",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "PersonPhone",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "BillOfMaterials",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductCostHistory",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductInventory",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductListPriceHistory",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductModelIllustration",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductModelProductDescriptionCulture",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductProductPhoto",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductReview",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "TransactionHistory",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "TransactionHistoryArchive",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "WorkOrderRouting",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductVendor",
                schema: "Purchasing");

            migrationBuilder.DropTable(
                name: "PurchaseOrderDetail",
                schema: "Purchasing");

            migrationBuilder.DropTable(
                name: "CountryRegionCurrency",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "PersonCreditCard",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesOrderDetail",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesOrderHeaderSalesReason",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesPersonQuotaHistory",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesTaxRate",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesTerritoryHistory",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "ShoppingCartItem",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "HumanResources");

            migrationBuilder.DropTable(
                name: "Shift",
                schema: "HumanResources");

            migrationBuilder.DropTable(
                name: "AddressType",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "ContactType",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "PhoneNumberType",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "Illustration",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "Culture",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductDescription",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductPhoto",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "WorkOrder",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "PurchaseOrderHeader",
                schema: "Purchasing");

            migrationBuilder.DropTable(
                name: "SpecialOfferProduct",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesOrderHeader",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SalesReason",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "ScrapReason",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "Vendor",
                schema: "Purchasing");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "SpecialOffer",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "CreditCard",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "CurrencyRate",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "ShipMethod",
                schema: "Purchasing");

            migrationBuilder.DropTable(
                name: "ProductModel",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "ProductSubcategory",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "UnitMeasure",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "StateProvince",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "Currency",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Store",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "ProductCategory",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "SalesPerson",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Employee",
                schema: "HumanResources");

            migrationBuilder.DropTable(
                name: "SalesTerritory",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "CountryRegion",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "BusinessEntity",
                schema: "Person");
        }
    }
}
