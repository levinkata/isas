using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Isas.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountChart",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    AccountCode = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    IncomeOrExpense = table.Column<int>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountChart", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Affected",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Affected", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Attorney",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    PayeeClassID = table.Column<int>(nullable: false),
                    Payable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attorney", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Authoriser",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    JobTitle = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authoriser", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    PayeeClassID = table.Column<int>(nullable: false),
                    Payable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BankDirectDebit",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ProductID = table.Column<Guid>(nullable: false),
                    PolicyID = table.Column<Guid>(nullable: false),
                    BIC = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDirectDebit", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BatchNumberGenerator",
                columns: table => new
                {
                    BatchNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchNumberGenerator", x => x.BatchNumber);
                });

            migrationBuilder.CreateTable(
                name: "BulkHandleGenerator",
                columns: table => new
                {
                    BulkNumber = table.Column<int>(nullable: false),
                    TableName = table.Column<string>(maxLength: 50, nullable: true),
                    BulkDate = table.Column<DateTime>(nullable: false),
                    RecordCount = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BulkHandleGenerator", x => x.BulkNumber);
                });

            migrationBuilder.CreateTable(
                name: "Cheque",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ProductID = table.Column<Guid>(nullable: false),
                    ChequeNumber = table.Column<string>(maxLength: 50, nullable: true),
                    ChequeDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BatchNumber = table.Column<string>(maxLength: 50, nullable: true),
                    Void = table.Column<bool>(nullable: false),
                    VoidReason = table.Column<string>(maxLength: 50, nullable: true),
                    Remarks = table.Column<string>(maxLength: 50, nullable: true),
                    ChequeExportID = table.Column<Guid>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<Guid>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cheque", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ChequeBook",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ProductID = table.Column<Guid>(nullable: false),
                    FirstChequeNumber = table.Column<int>(nullable: false),
                    LastChequeNumber = table.Column<int>(nullable: false),
                    LastChequeDate = table.Column<DateTime>(nullable: false),
                    PayeeRow = table.Column<short>(nullable: false),
                    PayeeCol = table.Column<int>(nullable: false),
                    PayeeAddressRow = table.Column<int>(nullable: false),
                    PayeeAddressCol = table.Column<int>(nullable: false),
                    PayeeCityRow = table.Column<int>(nullable: false),
                    PayeeCityCol = table.Column<int>(nullable: false),
                    LetterDateRow = table.Column<int>(nullable: false),
                    LetterDateCol = table.Column<int>(nullable: false),
                    SalutationRowRow = table.Column<int>(nullable: false),
                    SalutationRowCol = table.Column<int>(nullable: false),
                    TextLineRow = table.Column<int>(nullable: false),
                    TextLineCol = table.Column<int>(nullable: false),
                    TextLine = table.Column<string>(maxLength: 100, nullable: true),
                    TextChequeRow = table.Column<int>(nullable: false),
                    TextChequeCol = table.Column<int>(nullable: false),
                    TextAmountRow = table.Column<int>(nullable: false),
                    TextAmountCol = table.Column<int>(nullable: false),
                    TransHeaderRow = table.Column<int>(nullable: false),
                    TransHeaderCol = table.Column<int>(nullable: false),
                    SignatoryRow = table.Column<int>(nullable: false),
                    SignatoryCol = table.Column<int>(nullable: false),
                    Signatory = table.Column<string>(maxLength: 50, nullable: true),
                    Company = table.Column<string>(maxLength: 50, nullable: true),
                    CompanyRow = table.Column<int>(nullable: false),
                    CompanyCol = table.Column<int>(nullable: false),
                    LineSpacing = table.Column<int>(nullable: false),
                    ChequePayeeRow = table.Column<int>(nullable: false),
                    ChequePayeeCol = table.Column<int>(nullable: false),
                    ChequePayeePad = table.Column<int>(nullable: false),
                    ChequeDateRow = table.Column<int>(nullable: false),
                    ChequeDateCol = table.Column<int>(nullable: false),
                    ChequeWordsRow = table.Column<int>(nullable: false),
                    ChequeWordsCol = table.Column<int>(nullable: false),
                    ChequeDigitsRow = table.Column<int>(nullable: false),
                    ChequeDigitsCol = table.Column<int>(nullable: false),
                    PaperSize = table.Column<int>(nullable: false),
                    Orientation = table.Column<string>(maxLength: 50, nullable: true),
                    DefaultPrinter = table.Column<string>(maxLength: 50, nullable: true),
                    UserPaperHeight = table.Column<int>(nullable: false),
                    UserPaperWidth = table.Column<int>(nullable: false),
                    FontName = table.Column<string>(maxLength: 50, nullable: true),
                    FontSize = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<Guid>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChequeBook", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ChequeSummaryTemp",
                columns: table => new
                {
                    PayeeID = table.Column<Guid>(nullable: false),
                    ProductID = table.Column<Guid>(nullable: false),
                    Payee = table.Column<string>(maxLength: 50, nullable: true),
                    PostalAddress = table.Column<string>(maxLength: 50, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayeeCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChequeSummaryTemp", x => new { x.PayeeID, x.ProductID });
                });

            migrationBuilder.CreateTable(
                name: "ChequeTemp",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ProductID = table.Column<Guid>(nullable: false),
                    ClaimNumber = table.Column<int>(nullable: false),
                    PayeeID = table.Column<Guid>(nullable: false),
                    Payee = table.Column<string>(maxLength: 50, nullable: true),
                    InvoiceNumber = table.Column<string>(maxLength: 50, nullable: true),
                    AccountCode = table.Column<string>(maxLength: 50, nullable: true),
                    Affected = table.Column<string>(maxLength: 50, nullable: true),
                    Authorised = table.Column<bool>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Client = table.Column<string>(maxLength: 50, nullable: true),
                    Insurer = table.Column<string>(maxLength: 50, nullable: true),
                    Product = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChequeTemp", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ClaimAccounting",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ClientID = table.Column<Guid>(nullable: false),
                    InsurerID = table.Column<Guid>(nullable: false),
                    PolicyID = table.Column<Guid>(nullable: false),
                    ClaimNumber = table.Column<int>(nullable: false),
                    ClaimClassID = table.Column<Guid>(nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayeeID = table.Column<Guid>(nullable: false),
                    AffectedID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimAccounting", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ClaimClass",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    AffectCFG = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimClass", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ClaimDocument",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Mandatory = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimDocument", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ClaimNumberGenerator",
                columns: table => new
                {
                    ClaimPrefix = table.Column<int>(nullable: false),
                    ClaimNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimNumberGenerator", x => new { x.ClaimPrefix, x.ClaimNumber });
                });

            migrationBuilder.CreateTable(
                name: "ClaimStatus",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Updatable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ClaimTransactionGenerator",
                columns: table => new
                {
                    TransactionNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionNumber", x => x.TransactionNumber);
                });

            migrationBuilder.CreateTable(
                name: "ClientAccounting",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ClientID = table.Column<Guid>(nullable: false),
                    InsurerID = table.Column<Guid>(nullable: false),
                    PolicyID = table.Column<Guid>(nullable: false),
                    PremiumID = table.Column<Guid>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Adjustment = table.Column<Guid>(nullable: false),
                    Refund = table.Column<Guid>(nullable: false),
                    AccountStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientAccounting", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ClientType",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    IsFirm = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CommercialHistory",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PolicyID = table.Column<Guid>(nullable: false),
                    ComponentID = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    Motor = table.Column<bool>(nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Premium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    PolicyFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InsurerFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Commission = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AdminFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<Guid>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommercialHistory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Complaint",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    ComplaintDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaint", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Component",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Component", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ContentHistory",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PolicyID = table.Column<Guid>(nullable: false),
                    Location = table.Column<string>(maxLength: 50, nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Premium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    WallTypeID = table.Column<Guid>(nullable: false),
                    RoofTypeID = table.Column<Guid>(nullable: false),
                    ResidenceTypeID = table.Column<Guid>(nullable: false),
                    PolicyFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InsurerFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Commission = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AdminFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<Guid>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentHistory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ISOCode = table.Column<string>(maxLength: 3, nullable: true),
                    ISOCurrency = table.Column<string>(maxLength: 3, nullable: true),
                    DialingCode = table.Column<int>(nullable: true),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Coverage",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coverage", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DriverType",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Incident",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incident", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IncomeClass",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeClass", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Insurer",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    PayeeClassID = table.Column<int>(nullable: false),
                    Payable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    InvoiceNumber = table.Column<int>(nullable: false),
                    PolicyID = table.Column<Guid>(nullable: false),
                    InvoiceDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.InvoiceNumber);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceNumberGenerator",
                columns: table => new
                {
                    InvoiceNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceNumberGenerator", x => x.InvoiceNumber);
                });

            migrationBuilder.CreateTable(
                name: "LoadFormat",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ProductID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    UploadFileType = table.Column<int>(nullable: false),
                    Delimiter = table.Column<string>(maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadFormat", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LoanHistory",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PolicyID = table.Column<Guid>(nullable: false),
                    ComponentID = table.Column<Guid>(nullable: false),
                    AccountNumber = table.Column<string>(maxLength: 50, nullable: false),
                    Term = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LoanDate = table.Column<DateTime>(nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Premium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SettlementDate = table.Column<DateTime>(nullable: false),
                    PolicyFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InsurerFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Commission = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AdminFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BulkHandle = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<Guid>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanHistory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LossAdjuster",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    PayeeClassID = table.Column<int>(nullable: false),
                    Payable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LossAdjuster", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MotorHistory",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PolicyID = table.Column<Guid>(nullable: false),
                    RegistrationNumber = table.Column<string>(maxLength: 50, nullable: false),
                    MotorTypeID = table.Column<Guid>(nullable: false),
                    MotorMakeID = table.Column<Guid>(nullable: false),
                    MotorModelID = table.Column<Guid>(nullable: false),
                    ManufacturerYear = table.Column<int>(nullable: false),
                    EngineNumber = table.Column<string>(maxLength: 50, nullable: false),
                    ChassisNumber = table.Column<string>(maxLength: 50, nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Premium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    CoverageID = table.Column<Guid>(nullable: false),
                    DriverTypeID = table.Column<Guid>(nullable: false),
                    PrivateUse = table.Column<bool>(nullable: false),
                    BusinessUse = table.Column<bool>(nullable: false),
                    CFG = table.Column<int>(nullable: false),
                    Immobiliser = table.Column<bool>(nullable: false),
                    Alarm = table.Column<bool>(nullable: false),
                    GreyImport = table.Column<bool>(nullable: false),
                    TerritorialLimit = table.Column<string>(maxLength: 250, nullable: true),
                    PolicyFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InsurerFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Commission = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AdminFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<Guid>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorHistory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MotorMake",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorMake", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MotorType",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Occupation",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupation", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PayableExport",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ExportDate = table.Column<DateTime>(nullable: false),
                    FileObject = table.Column<string>(nullable: true),
                    ExternalReference = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayableExport", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PayeeClass",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayeeClass", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PolicyFrequency",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Divisor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyFrequency", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PolicyHistory",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    HistoryID = table.Column<Guid>(nullable: false),
                    ProductID = table.Column<Guid>(nullable: false),
                    ClientID = table.Column<Guid>(nullable: false),
                    PolicyNumber = table.Column<string>(nullable: true),
                    InsurerID = table.Column<Guid>(nullable: false),
                    InsurerNumber = table.Column<string>(nullable: true),
                    PolicyFrequencyID = table.Column<Guid>(nullable: false),
                    CoverStartDate = table.Column<DateTime>(nullable: false),
                    CoverEndDate = table.Column<DateTime>(nullable: false),
                    PolicyStatusID = table.Column<Guid>(nullable: false),
                    StatusDate = table.Column<DateTime>(nullable: true),
                    PremiumDueDate = table.Column<DateTime>(nullable: true),
                    PolicyVersion = table.Column<int>(nullable: false),
                    InceptionDate = table.Column<DateTime>(nullable: true),
                    Renewable = table.Column<bool>(nullable: false),
                    IncomeClassID = table.Column<Guid>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    BulkHandle = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<Guid>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyHistory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PolicyNumberGenerator",
                columns: table => new
                {
                    PolicyNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyNumberGenerator", x => x.PolicyNumber);
                });

            migrationBuilder.CreateTable(
                name: "PolicyStatus",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Updatable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PremiumType",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PremiumType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PropertyHistory",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PolicyID = table.Column<Guid>(nullable: false),
                    Location = table.Column<string>(maxLength: 50, nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Premium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    CoverageID = table.Column<Guid>(nullable: false),
                    WallTypeID = table.Column<Guid>(nullable: false),
                    RoofTypeID = table.Column<Guid>(nullable: false),
                    ResidenceTypeID = table.Column<Guid>(nullable: false),
                    BondHolder = table.Column<string>(maxLength: 50, nullable: true),
                    PolicyFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InsurerFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Commission = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AdminFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<Guid>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyHistory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Repairer",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    PayeeClassID = table.Column<int>(nullable: false),
                    Payable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ResidenceType",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidenceType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Risk",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Risk", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RoofType",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoofType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ThirdParty",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    IDNumber = table.Column<string>(maxLength: 50, nullable: false),
                    PayeeClassID = table.Column<int>(nullable: false),
                    Payable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThirdParty", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Title",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Title", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TracingAgent",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    PayeeClassID = table.Column<int>(nullable: false),
                    Payable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TracingAgent", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TransactionType",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WallType",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WallType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BankBranch",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    BankID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    BIC = table.Column<string>(maxLength: 50, nullable: true),
                    SwiftCode = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankBranch", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BankBranch_Bank_BankID",
                        column: x => x.BankID,
                        principalTable: "Bank",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComplaintDetail",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ComplaintID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    ComplaintDetailDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ComplaintDetail_Complaint_ComplaintID",
                        column: x => x.ComplaintID,
                        principalTable: "Complaint",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AllRiskHistory",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PolicyID = table.Column<Guid>(nullable: false),
                    ComponentID = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Premium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(maxLength: 50, nullable: true),
                    PolicyFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InsurerFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Commission = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AdminFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<Guid>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllRiskHistory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AllRiskHistory_Component_ComponentID",
                        column: x => x.ComponentID,
                        principalTable: "Component",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoanTemp",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    ProductID = table.Column<Guid>(nullable: false),
                    IDNumber = table.Column<string>(nullable: true),
                    ComponentID = table.Column<Guid>(nullable: false),
                    AccountNumber = table.Column<string>(nullable: true),
                    Term = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LoanDate = table.Column<DateTime>(nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Premium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SettlementDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanTemp", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LoanTemp_Component_ComponentID",
                        column: x => x.ComponentID,
                        principalTable: "Component",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PhysicalAddress = table.Column<string>(maxLength: 100, nullable: true),
                    PostalAddress = table.Column<string>(maxLength: 50, nullable: true),
                    CountryID = table.Column<Guid>(nullable: false),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    ProvinceID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Address_Country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Container",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ContactPerson = table.Column<string>(maxLength: 50, nullable: true),
                    Business = table.Column<string>(maxLength: 50, nullable: true),
                    CountryID = table.Column<Guid>(nullable: false),
                    AddedBy = table.Column<Guid>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Container", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Container_Country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CountryID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Province_Country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItem",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    InvoiceID = table.Column<int>(nullable: false),
                    RiskID = table.Column<int>(nullable: false),
                    RiskItemID = table.Column<Guid>(nullable: false),
                    Premium = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InvoiceItem_Invoice_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoice",
                        principalColumn: "InvoiceNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FormatType",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    LoadFormatID = table.Column<Guid>(nullable: false),
                    TableName = table.Column<string>(maxLength: 50, nullable: true),
                    FieldName = table.Column<string>(maxLength: 50, nullable: true),
                    FieldLabel = table.Column<string>(maxLength: 50, nullable: true),
                    Position = table.Column<string>(maxLength: 50, nullable: true),
                    ColumnLength = table.Column<int>(nullable: false),
                    IsKey = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormatType", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FormatType_LoadFormat_LoadFormatID",
                        column: x => x.LoadFormatID,
                        principalTable: "LoadFormat",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClaimLossAdjuster",
                columns: table => new
                {
                    ClaimNumber = table.Column<Guid>(nullable: false),
                    LossAdjusterID = table.Column<Guid>(nullable: false),
                    ClaimExcess = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Location = table.Column<string>(maxLength: 50, nullable: true),
                    AgreeRepair = table.Column<bool>(nullable: false),
                    AgreeCost = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimLossAdjuster", x => new { x.ClaimNumber, x.LossAdjusterID });
                    table.ForeignKey(
                        name: "FK_ClaimLossAdjuster_LossAdjuster_LossAdjusterID",
                        column: x => x.LossAdjusterID,
                        principalTable: "LossAdjuster",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MotorModel",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    MotorMakeID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MotorModel_MotorMake_MotorMakeID",
                        column: x => x.MotorMakeID,
                        principalTable: "MotorMake",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payee",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PayeeClassID = table.Column<int>(nullable: false),
                    PayeeItemID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payee", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Payee_PayeeClass_PayeeClassID",
                        column: x => x.PayeeClassID,
                        principalTable: "PayeeClass",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payable",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ProductID = table.Column<Guid>(nullable: false),
                    Reference = table.Column<string>(maxLength: 50, nullable: false),
                    PayableDate = table.Column<DateTime>(nullable: false),
                    PaymentTypeID = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BatchNumber = table.Column<string>(maxLength: 50, nullable: true),
                    Void = table.Column<bool>(nullable: false),
                    VoidReason = table.Column<string>(maxLength: 100, nullable: true),
                    Remarks = table.Column<string>(maxLength: 50, nullable: true),
                    PayableExportID = table.Column<Guid>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<Guid>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payable", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Payable_PaymentType_PaymentTypeID",
                        column: x => x.PaymentTypeID,
                        principalTable: "PaymentType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Receivable",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ProductID = table.Column<Guid>(nullable: false),
                    Reference = table.Column<string>(maxLength: 50, nullable: false),
                    ReceivableDate = table.Column<DateTime>(nullable: false),
                    PaymentTypeID = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BatchNumber = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<Guid>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receivable", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Receivable_PaymentType_PaymentTypeID",
                        column: x => x.PaymentTypeID,
                        principalTable: "PaymentType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PolicyTemp",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    ProductID = table.Column<Guid>(nullable: false),
                    ClientID = table.Column<Guid>(nullable: false),
                    IDNumber = table.Column<string>(nullable: true),
                    PolicyNumber = table.Column<string>(nullable: true),
                    InsurerID = table.Column<Guid>(nullable: false),
                    InsurerNumber = table.Column<string>(nullable: true),
                    PolicyFrequencyID = table.Column<Guid>(nullable: false),
                    EffectiveDate = table.Column<DateTime>(nullable: true),
                    ExpiryDate = table.Column<DateTime>(nullable: true),
                    PolicyStatusID = table.Column<Guid>(nullable: false),
                    StatusDate = table.Column<DateTime>(nullable: true),
                    PremiumDueDate = table.Column<DateTime>(nullable: true),
                    PolicyVersion = table.Column<int>(nullable: false),
                    InceptionDate = table.Column<DateTime>(nullable: true),
                    Renewable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyTemp", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PolicyTemp_Insurer_InsurerID",
                        column: x => x.InsurerID,
                        principalTable: "Insurer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PolicyTemp_PolicyFrequency_PolicyFrequencyID",
                        column: x => x.PolicyFrequencyID,
                        principalTable: "PolicyFrequency",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PolicyTemp_PolicyStatus_PolicyStatusID",
                        column: x => x.PolicyStatusID,
                        principalTable: "PolicyStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PremiumTemp",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    ProductID = table.Column<Guid>(nullable: false),
                    RiskID = table.Column<int>(nullable: false),
                    IDNumber = table.Column<string>(maxLength: 50, nullable: true),
                    Reference = table.Column<string>(maxLength: 50, nullable: true),
                    ReceivableDate = table.Column<DateTime>(nullable: false),
                    PaymentTypeID = table.Column<Guid>(nullable: false),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BatchNumber = table.Column<string>(maxLength: 50, nullable: true),
                    PremiumDate = table.Column<DateTime>(nullable: true),
                    PremiumTypeID = table.Column<Guid>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PolicyFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Commission = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AdminFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PremiumTemp", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PremiumTemp_PremiumType_PremiumTypeID",
                        column: x => x.PremiumTypeID,
                        principalTable: "PremiumType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RiskClaimClass",
                columns: table => new
                {
                    RiskID = table.Column<int>(nullable: false),
                    ClaimClassID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskClaimClass", x => new { x.RiskID, x.ClaimClassID });
                    table.ForeignKey(
                        name: "FK_RiskClaimClass_ClaimClass_ClaimClassID",
                        column: x => x.ClaimClassID,
                        principalTable: "ClaimClass",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskClaimClass_Risk_RiskID",
                        column: x => x.RiskID,
                        principalTable: "Risk",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RiskClaimDocument",
                columns: table => new
                {
                    RiskID = table.Column<int>(nullable: false),
                    ClaimDocumentID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskClaimDocument", x => new { x.RiskID, x.ClaimDocumentID });
                    table.ForeignKey(
                        name: "FK_RiskClaimDocument_ClaimDocument_ClaimDocumentID",
                        column: x => x.ClaimDocumentID,
                        principalTable: "ClaimDocument",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskClaimDocument_Risk_RiskID",
                        column: x => x.RiskID,
                        principalTable: "Risk",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RiskIncident",
                columns: table => new
                {
                    RiskID = table.Column<int>(nullable: false),
                    IncidentID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskIncident", x => new { x.RiskID, x.IncidentID });
                    table.ForeignKey(
                        name: "FK_RiskIncident_Incident_IncidentID",
                        column: x => x.IncidentID,
                        principalTable: "Incident",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RiskIncident_Risk_RiskID",
                        column: x => x.RiskID,
                        principalTable: "Risk",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ClientTypeID = table.Column<Guid>(nullable: false),
                    TitleID = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "Date", nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    IDNumber = table.Column<string>(maxLength: 50, nullable: false),
                    Phone = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    OccupationID = table.Column<Guid>(nullable: false),
                    CountryID = table.Column<Guid>(nullable: false),
                    PayeeClassID = table.Column<int>(nullable: false),
                    Payable = table.Column<bool>(nullable: false),
                    BulkHandle = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<Guid>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Client_ClientType_ClientTypeID",
                        column: x => x.ClientTypeID,
                        principalTable: "ClientType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Client_Country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Client_Occupation_OccupationID",
                        column: x => x.OccupationID,
                        principalTable: "Occupation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Client_Title_TitleID",
                        column: x => x.TitleID,
                        principalTable: "Title",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientTemp",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    ProductID = table.Column<Guid>(nullable: false),
                    ClientClassID = table.Column<int>(nullable: false),
                    TitleID = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    Gender = table.Column<int>(nullable: true),
                    IDNumber = table.Column<string>(nullable: true),
                    OccupationID = table.Column<Guid>(nullable: false),
                    CountryID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTemp", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClientTemp_Country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientTemp_Occupation_OccupationID",
                        column: x => x.OccupationID,
                        principalTable: "Occupation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientTemp_Title_TitleID",
                        column: x => x.TitleID,
                        principalTable: "Title",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TitleID = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Phone = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    IDNumber = table.Column<string>(maxLength: 50, nullable: false),
                    LicenseNumber = table.Column<string>(maxLength: 50, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    LicenseIssueDate = table.Column<DateTime>(nullable: false),
                    LicenseExpiryDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Driver_Title_TitleID",
                        column: x => x.TitleID,
                        principalTable: "Title",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BankAccount",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    BankBranchID = table.Column<Guid>(nullable: false),
                    AccountNumber = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BankAccount_BankBranch_BankBranchID",
                        column: x => x.BankBranchID,
                        principalTable: "BankBranch",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AddressAssignment",
                columns: table => new
                {
                    ItemID = table.Column<Guid>(nullable: false),
                    AddressID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressAssignment", x => new { x.ItemID, x.AddressID });
                    table.ForeignKey(
                        name: "FK_AddressAssignment_Address_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Address",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ContainerID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    RenewalPeriod = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Product_Container_ContainerID",
                        column: x => x.ContainerID,
                        principalTable: "Container",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Policy",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ClientID = table.Column<Guid>(nullable: false),
                    PolicyNumber = table.Column<string>(maxLength: 50, nullable: false),
                    InsurerID = table.Column<Guid>(nullable: false),
                    InsurerNumber = table.Column<string>(maxLength: 50, nullable: true),
                    PolicyFrequencyID = table.Column<Guid>(nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "Date", nullable: false, defaultValueSql: "GetDate()"),
                    ExpireDate = table.Column<DateTime>(nullable: false),
                    PolicyStatusID = table.Column<Guid>(nullable: false),
                    StatusDate = table.Column<DateTime>(nullable: false),
                    PremiumDueDate = table.Column<DateTime>(nullable: false),
                    PolicyVersion = table.Column<int>(nullable: false),
                    InceptionDate = table.Column<DateTime>(nullable: false),
                    Renewable = table.Column<bool>(nullable: false),
                    IncomeClassID = table.Column<Guid>(nullable: false),
                    Comment = table.Column<string>(maxLength: 50, nullable: true),
                    BulkHandle = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<Guid>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Policy_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Policy_IncomeClass_IncomeClassID",
                        column: x => x.IncomeClassID,
                        principalTable: "IncomeClass",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Policy_Insurer_InsurerID",
                        column: x => x.InsurerID,
                        principalTable: "Insurer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Policy_PolicyFrequency_PolicyFrequencyID",
                        column: x => x.PolicyFrequencyID,
                        principalTable: "PolicyFrequency",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Policy_PolicyStatus_PolicyStatusID",
                        column: x => x.PolicyStatusID,
                        principalTable: "PolicyStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PayeeBankAccount",
                columns: table => new
                {
                    PayeeID = table.Column<Guid>(nullable: false),
                    BankAccountID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayeeBankAccount", x => new { x.PayeeID, x.BankAccountID });
                    table.ForeignKey(
                        name: "FK_PayeeBankAccount_BankAccount_BankAccountID",
                        column: x => x.BankAccountID,
                        principalTable: "BankAccount",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayeeBankAccount_Payee_PayeeID",
                        column: x => x.PayeeID,
                        principalTable: "Payee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductClient",
                columns: table => new
                {
                    ProductID = table.Column<Guid>(nullable: false),
                    ClientID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductClient", x => new { x.ProductID, x.ClientID });
                    table.ForeignKey(
                        name: "FK_ProductClient_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductClient_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductRisk",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ProductID = table.Column<Guid>(nullable: false),
                    RiskID = table.Column<int>(nullable: false),
                    ClaimLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClaimPrefix = table.Column<int>(nullable: false),
                    UseCFG = table.Column<bool>(nullable: false),
                    PolicyFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Commission = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AdminFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRisk", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductRisk_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductRisk_Risk_RiskID",
                        column: x => x.RiskID,
                        principalTable: "Risk",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AllRisk",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PolicyID = table.Column<Guid>(nullable: false),
                    ComponentID = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Premium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(maxLength: 50, nullable: true),
                    PolicyFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InsurerFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Commission = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AdminFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<Guid>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllRisk", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AllRisk_Component_ComponentID",
                        column: x => x.ComponentID,
                        principalTable: "Component",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AllRisk_Policy_PolicyID",
                        column: x => x.PolicyID,
                        principalTable: "Policy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Claim",
                columns: table => new
                {
                    ClaimNumber = table.Column<int>(nullable: false),
                    PolicyID = table.Column<Guid>(nullable: false),
                    RiskID = table.Column<int>(nullable: false),
                    RiskItemID = table.Column<Guid>(nullable: false),
                    ReportDate = table.Column<DateTime>(nullable: false),
                    IncidentDate = table.Column<DateTime>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    ReserveInsured = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReserveThirdParty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReserveInsuredRevised = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReserveThirdPartyRevised = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClaimExcess = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClaimClassID = table.Column<Guid>(nullable: false),
                    RecoverFromThirdParty = table.Column<bool>(nullable: false),
                    IncidentID = table.Column<Guid>(nullable: false),
                    CountryID = table.Column<Guid>(nullable: false),
                    RegionID = table.Column<Guid>(nullable: false),
                    ClaimStatusID = table.Column<Guid>(nullable: false),
                    IncidentDetail = table.Column<string>(maxLength: 100, nullable: true),
                    Comment = table.Column<string>(maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true, computedColumnSql: "GetDate()"),
                    AddedBy = table.Column<Guid>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true, computedColumnSql: "GetDate()"),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    AffectedID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claim", x => x.ClaimNumber);
                    table.ForeignKey(
                        name: "FK_Claim_Affected_AffectedID",
                        column: x => x.AffectedID,
                        principalTable: "Affected",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Claim_ClaimClass_ClaimClassID",
                        column: x => x.ClaimClassID,
                        principalTable: "ClaimClass",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Claim_ClaimStatus_ClaimStatusID",
                        column: x => x.ClaimStatusID,
                        principalTable: "ClaimStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Claim_Country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Claim_Incident_IncidentID",
                        column: x => x.IncidentID,
                        principalTable: "Incident",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Claim_Policy_PolicyID",
                        column: x => x.PolicyID,
                        principalTable: "Policy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Claim_Region_RegionID",
                        column: x => x.RegionID,
                        principalTable: "Region",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Claim_Risk_RiskID",
                        column: x => x.RiskID,
                        principalTable: "Risk",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Commercial",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PolicyID = table.Column<Guid>(nullable: false),
                    ComponentID = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    Motor = table.Column<bool>(nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Premium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    PolicyFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InsurerFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Commission = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AdminFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<Guid>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commercial", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Commercial_Component_ComponentID",
                        column: x => x.ComponentID,
                        principalTable: "Component",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commercial_Policy_PolicyID",
                        column: x => x.PolicyID,
                        principalTable: "Policy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PolicyID = table.Column<Guid>(nullable: false),
                    Location = table.Column<string>(maxLength: 50, nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Premium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    WallTypeID = table.Column<Guid>(nullable: false),
                    RoofTypeID = table.Column<Guid>(nullable: false),
                    ResidenceTypeID = table.Column<Guid>(nullable: false),
                    PolicyFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InsurerFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Commission = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AdminFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<Guid>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Content_Policy_PolicyID",
                        column: x => x.PolicyID,
                        principalTable: "Policy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Content_ResidenceType_ResidenceTypeID",
                        column: x => x.ResidenceTypeID,
                        principalTable: "ResidenceType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Content_RoofType_RoofTypeID",
                        column: x => x.RoofTypeID,
                        principalTable: "RoofType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Content_WallType_WallTypeID",
                        column: x => x.WallTypeID,
                        principalTable: "WallType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Loan",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PolicyID = table.Column<Guid>(nullable: false),
                    ComponentID = table.Column<Guid>(nullable: false),
                    AccountNumber = table.Column<string>(maxLength: 50, nullable: false),
                    Term = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LoanDate = table.Column<DateTime>(nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Premium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SettlementDate = table.Column<DateTime>(nullable: true),
                    PolicyFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InsurerFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Commission = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AdminFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BulkHandle = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<Guid>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loan", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Loan_Component_ComponentID",
                        column: x => x.ComponentID,
                        principalTable: "Component",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Loan_Policy_PolicyID",
                        column: x => x.PolicyID,
                        principalTable: "Policy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Motor",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PolicyID = table.Column<Guid>(nullable: false),
                    RegistrationNumber = table.Column<string>(maxLength: 50, nullable: false),
                    MotorTypeID = table.Column<Guid>(nullable: false),
                    MotorMakeID = table.Column<Guid>(nullable: false),
                    MotorModelID = table.Column<Guid>(nullable: false),
                    ManufacturerYear = table.Column<int>(nullable: false),
                    EngineNumber = table.Column<string>(maxLength: 50, nullable: false),
                    ChassisNumber = table.Column<string>(maxLength: 50, nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Premium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    CoverageID = table.Column<Guid>(nullable: false),
                    DriverTypeID = table.Column<Guid>(nullable: false),
                    PrivateUse = table.Column<bool>(nullable: false),
                    BusinessUse = table.Column<bool>(nullable: false),
                    CFG = table.Column<int>(nullable: false),
                    Immobiliser = table.Column<bool>(nullable: false),
                    Alarm = table.Column<bool>(nullable: false),
                    GreyImport = table.Column<bool>(nullable: false),
                    TerritorialLimit = table.Column<string>(maxLength: 250, nullable: true),
                    PolicyFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InsurerFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Commission = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AdminFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<Guid>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Motor_Coverage_CoverageID",
                        column: x => x.CoverageID,
                        principalTable: "Coverage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Motor_DriverType_DriverTypeID",
                        column: x => x.DriverTypeID,
                        principalTable: "DriverType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Motor_MotorMake_MotorMakeID",
                        column: x => x.MotorMakeID,
                        principalTable: "MotorMake",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Motor_MotorType_MotorTypeID",
                        column: x => x.MotorTypeID,
                        principalTable: "MotorType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Motor_Policy_PolicyID",
                        column: x => x.PolicyID,
                        principalTable: "Policy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PolicyBankAccount",
                columns: table => new
                {
                    PolicyID = table.Column<Guid>(nullable: false),
                    BankAccountID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyBankAccount", x => new { x.PolicyID, x.BankAccountID });
                    table.ForeignKey(
                        name: "FK_PolicyBankAccount_BankAccount_BankAccountID",
                        column: x => x.BankAccountID,
                        principalTable: "BankAccount",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PolicyBankAccount_Policy_PolicyID",
                        column: x => x.PolicyID,
                        principalTable: "Policy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Premium",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PolicyID = table.Column<Guid>(nullable: false),
                    RiskID = table.Column<int>(nullable: false),
                    RiskItemID = table.Column<Guid>(nullable: false),
                    PremiumDate = table.Column<DateTime>(nullable: false),
                    PremiumTypeID = table.Column<Guid>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PolicyFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Commission = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AdminFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReceivableID = table.Column<Guid>(nullable: false),
                    BulkHandle = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<Guid>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Premium", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Premium_Policy_PolicyID",
                        column: x => x.PolicyID,
                        principalTable: "Policy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Premium_PremiumType_PremiumTypeID",
                        column: x => x.PremiumTypeID,
                        principalTable: "PremiumType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Premium_Receivable_ReceivableID",
                        column: x => x.ReceivableID,
                        principalTable: "Receivable",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Premium_Risk_RiskID",
                        column: x => x.RiskID,
                        principalTable: "Risk",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PolicyID = table.Column<Guid>(nullable: false),
                    Location = table.Column<string>(maxLength: 50, nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Premium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    CoverageID = table.Column<Guid>(nullable: false),
                    WallTypeID = table.Column<Guid>(nullable: false),
                    RoofTypeID = table.Column<Guid>(nullable: false),
                    ResidenceTypeID = table.Column<Guid>(nullable: false),
                    BondHolder = table.Column<string>(maxLength: 50, nullable: true),
                    PolicyFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InsurerFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Commission = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AdminFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<Guid>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Property_Coverage_CoverageID",
                        column: x => x.CoverageID,
                        principalTable: "Coverage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Property_Policy_PolicyID",
                        column: x => x.PolicyID,
                        principalTable: "Policy",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Property_ResidenceType_ResidenceTypeID",
                        column: x => x.ResidenceTypeID,
                        principalTable: "ResidenceType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Property_RoofType_RoofTypeID",
                        column: x => x.RoofTypeID,
                        principalTable: "RoofType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Property_WallType_WallTypeID",
                        column: x => x.WallTypeID,
                        principalTable: "WallType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductRiskBenefit",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ProductRiskID = table.Column<Guid>(nullable: false),
                    Benefit = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRiskBenefit", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductRiskBenefit_ProductRisk_ProductRiskID",
                        column: x => x.ProductRiskID,
                        principalTable: "ProductRisk",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClaimAttorney",
                columns: table => new
                {
                    ClaimNumber = table.Column<Guid>(nullable: false),
                    AttorneyID = table.Column<Guid>(nullable: false),
                    ClaimNumber1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimAttorney", x => new { x.ClaimNumber, x.AttorneyID });
                    table.ForeignKey(
                        name: "FK_ClaimAttorney_Attorney_AttorneyID",
                        column: x => x.AttorneyID,
                        principalTable: "Attorney",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClaimAttorney_Claim_ClaimNumber1",
                        column: x => x.ClaimNumber1,
                        principalTable: "Claim",
                        principalColumn: "ClaimNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClaimDiary",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ClaimNumber = table.Column<int>(nullable: false),
                    Activity = table.Column<string>(maxLength: 100, nullable: true),
                    ActivityDate = table.Column<DateTime>(nullable: false),
                    DocumentPath = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimDiary", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClaimDiary_Claim_ClaimNumber",
                        column: x => x.ClaimNumber,
                        principalTable: "Claim",
                        principalColumn: "ClaimNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClaimDocumentSubmit",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ClaimNumber = table.Column<int>(nullable: false),
                    ClaimDocumentID = table.Column<Guid>(nullable: false),
                    SubmitDate = table.Column<DateTime>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    AddedBy = table.Column<Guid>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimDocumentSubmit", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClaimDocumentSubmit_ClaimDocument_ClaimDocumentID",
                        column: x => x.ClaimDocumentID,
                        principalTable: "ClaimDocument",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClaimDocumentSubmit_Claim_ClaimNumber",
                        column: x => x.ClaimNumber,
                        principalTable: "Claim",
                        principalColumn: "ClaimNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClaimDriver",
                columns: table => new
                {
                    ClaimNumber = table.Column<Guid>(nullable: false),
                    DriverID = table.Column<Guid>(nullable: false),
                    ClaimNumber1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimDriver", x => new { x.ClaimNumber, x.DriverID });
                    table.ForeignKey(
                        name: "FK_ClaimDriver_Claim_ClaimNumber1",
                        column: x => x.ClaimNumber1,
                        principalTable: "Claim",
                        principalColumn: "ClaimNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClaimDriver_Driver_DriverID",
                        column: x => x.DriverID,
                        principalTable: "Driver",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClaimRecovery",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ClaimNumber = table.Column<int>(nullable: false),
                    ThirdPartyID = table.Column<Guid>(nullable: false),
                    Reference = table.Column<string>(maxLength: 50, nullable: false),
                    RecoveryDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentReceivedID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimRecovery", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClaimRecovery_Claim_ClaimNumber",
                        column: x => x.ClaimNumber,
                        principalTable: "Claim",
                        principalColumn: "ClaimNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClaimRecovery_ThirdParty_ThirdPartyID",
                        column: x => x.ThirdPartyID,
                        principalTable: "ThirdParty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClaimRepairer",
                columns: table => new
                {
                    ClaimNumber = table.Column<Guid>(nullable: false),
                    RepairerID = table.Column<Guid>(nullable: false),
                    ClaimNumber1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimRepairer", x => new { x.ClaimNumber, x.RepairerID });
                    table.ForeignKey(
                        name: "FK_ClaimRepairer_Claim_ClaimNumber1",
                        column: x => x.ClaimNumber1,
                        principalTable: "Claim",
                        principalColumn: "ClaimNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClaimRepairer_Repairer_RepairerID",
                        column: x => x.RepairerID,
                        principalTable: "Repairer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClaimThirdParty",
                columns: table => new
                {
                    ClaimNumber = table.Column<int>(nullable: false),
                    ThirdPartyID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimThirdParty", x => new { x.ClaimNumber, x.ThirdPartyID });
                    table.ForeignKey(
                        name: "FK_ClaimThirdParty_Claim_ClaimNumber",
                        column: x => x.ClaimNumber,
                        principalTable: "Claim",
                        principalColumn: "ClaimNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClaimThirdParty_ThirdParty_ThirdPartyID",
                        column: x => x.ThirdPartyID,
                        principalTable: "ThirdParty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClaimTracingAgent",
                columns: table => new
                {
                    ClaimNumber = table.Column<Guid>(nullable: false),
                    TracingAgentID = table.Column<Guid>(nullable: false),
                    ClaimNumber1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimTracingAgent", x => new { x.ClaimNumber, x.TracingAgentID });
                    table.ForeignKey(
                        name: "FK_ClaimTracingAgent_Claim_ClaimNumber1",
                        column: x => x.ClaimNumber1,
                        principalTable: "Claim",
                        principalColumn: "ClaimNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClaimTracingAgent_TracingAgent_TracingAgentID",
                        column: x => x.TracingAgentID,
                        principalTable: "TracingAgent",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClaimTransaction",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ClaimNumber = table.Column<int>(nullable: false),
                    PayeeID = table.Column<Guid>(nullable: false),
                    InvoiceNumber = table.Column<string>(maxLength: 50, nullable: true),
                    InvoiceDate = table.Column<DateTime>(nullable: false),
                    RequisitionDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionTypeID = table.Column<Guid>(nullable: false),
                    AffectedID = table.Column<Guid>(nullable: false),
                    AccountID = table.Column<Guid>(nullable: false),
                    Taxable = table.Column<bool>(nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReserveInsured = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReserveThirdParty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HoldForPayment = table.Column<int>(nullable: false),
                    PassForPayment = table.Column<int>(nullable: false),
                    Authorised = table.Column<bool>(nullable: false),
                    AuthoriserID = table.Column<Guid>(nullable: true),
                    PayableID = table.Column<Guid>(nullable: true),
                    Finalise = table.Column<bool>(nullable: false),
                    TransactionNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimTransaction", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClaimTransaction_AccountChart_AccountID",
                        column: x => x.AccountID,
                        principalTable: "AccountChart",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClaimTransaction_Affected_AffectedID",
                        column: x => x.AffectedID,
                        principalTable: "Affected",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClaimTransaction_Claim_ClaimNumber",
                        column: x => x.ClaimNumber,
                        principalTable: "Claim",
                        principalColumn: "ClaimNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClaimTransaction_Payable_PayableID",
                        column: x => x.PayableID,
                        principalTable: "Payable",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClaimTransaction_Payee_PayeeID",
                        column: x => x.PayeeID,
                        principalTable: "Payee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClaimTransaction_TransactionType_TransactionTypeID",
                        column: x => x.TransactionTypeID,
                        principalTable: "TransactionType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IncidentContact",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ClaimNumber = table.Column<int>(nullable: false),
                    IssueDate = table.Column<DateTime>(nullable: false),
                    Phone = table.Column<string>(maxLength: 50, nullable: true),
                    Mobile = table.Column<string>(maxLength: 50, nullable: true),
                    AuthoriserID = table.Column<Guid>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentContact", x => x.ID);
                    table.ForeignKey(
                        name: "FK_IncidentContact_Claim_ClaimNumber",
                        column: x => x.ClaimNumber,
                        principalTable: "Claim",
                        principalColumn: "ClaimNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MotorThirdParty",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ClaimNumber = table.Column<int>(nullable: false),
                    RegistrationNumber = table.Column<string>(maxLength: 50, nullable: false),
                    MotorTypeID = table.Column<Guid>(nullable: false),
                    MotorMakeID = table.Column<Guid>(nullable: false),
                    MotorModelID = table.Column<Guid>(nullable: false),
                    ManufacturerYear = table.Column<int>(nullable: false),
                    EngineNumber = table.Column<string>(maxLength: 50, nullable: false),
                    ChassisNumber = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorThirdParty", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MotorThirdParty_Claim_ClaimNumber",
                        column: x => x.ClaimNumber,
                        principalTable: "Claim",
                        principalColumn: "ClaimNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MotorDriver",
                columns: table => new
                {
                    MotorID = table.Column<Guid>(nullable: false),
                    DriverID = table.Column<Guid>(nullable: false),
                    IsPrimaryDriver = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorDriver", x => new { x.MotorID, x.DriverID });
                    table.ForeignKey(
                        name: "FK_MotorDriver_Driver_DriverID",
                        column: x => x.DriverID,
                        principalTable: "Driver",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MotorDriver_Motor_MotorID",
                        column: x => x.MotorID,
                        principalTable: "Motor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MotorSection",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    MotorID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Premium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorSection", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MotorSection_Motor_MotorID",
                        column: x => x.MotorID,
                        principalTable: "Motor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PremiumRefund",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PremiumID = table.Column<Guid>(nullable: false),
                    RequsitionDate = table.Column<DateTime>(nullable: false),
                    RefundDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AccountID = table.Column<Guid>(nullable: false),
                    Reference = table.Column<string>(maxLength: 50, nullable: true),
                    IsAuthorised = table.Column<bool>(nullable: false),
                    AuthoriserID = table.Column<Guid>(nullable: false),
                    PaymentMadeID = table.Column<Guid>(nullable: false),
                    BatchNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PremiumRefund", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PremiumRefund_AccountChart_AccountID",
                        column: x => x.AccountID,
                        principalTable: "AccountChart",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PremiumRefund_Premium_PremiumID",
                        column: x => x.PremiumID,
                        principalTable: "Premium",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CountryID",
                table: "Address",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_AddressAssignment_AddressID",
                table: "AddressAssignment",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_AllRisk_ComponentID",
                table: "AllRisk",
                column: "ComponentID");

            migrationBuilder.CreateIndex(
                name: "IX_AllRisk_PolicyID",
                table: "AllRisk",
                column: "PolicyID");

            migrationBuilder.CreateIndex(
                name: "IX_AllRiskHistory_ComponentID",
                table: "AllRiskHistory",
                column: "ComponentID");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_BankBranchID",
                table: "BankAccount",
                column: "BankBranchID");

            migrationBuilder.CreateIndex(
                name: "IX_BankBranch_BankID",
                table: "BankBranch",
                column: "BankID");

            migrationBuilder.CreateIndex(
                name: "IX_ChequeNumber",
                table: "Cheque",
                column: "ChequeNumber",
                unique: true,
                filter: "[ChequeNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Claim_AffectedID",
                table: "Claim",
                column: "AffectedID");

            migrationBuilder.CreateIndex(
                name: "IX_Claim_ClaimClassID",
                table: "Claim",
                column: "ClaimClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Claim_ClaimStatusID",
                table: "Claim",
                column: "ClaimStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Claim_CountryID",
                table: "Claim",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Claim_IncidentID",
                table: "Claim",
                column: "IncidentID");

            migrationBuilder.CreateIndex(
                name: "IX_Claim_PolicyID",
                table: "Claim",
                column: "PolicyID");

            migrationBuilder.CreateIndex(
                name: "IX_Claim_RegionID",
                table: "Claim",
                column: "RegionID");

            migrationBuilder.CreateIndex(
                name: "IX_Claim_RiskID",
                table: "Claim",
                column: "RiskID");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimAttorney_AttorneyID",
                table: "ClaimAttorney",
                column: "AttorneyID");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimAttorney_ClaimNumber1",
                table: "ClaimAttorney",
                column: "ClaimNumber1");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimDiary_ClaimNumber",
                table: "ClaimDiary",
                column: "ClaimNumber");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimDocumentSubmit_ClaimDocumentID",
                table: "ClaimDocumentSubmit",
                column: "ClaimDocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimDocumentSubmit_ClaimNumber",
                table: "ClaimDocumentSubmit",
                column: "ClaimNumber");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimDriver_ClaimNumber1",
                table: "ClaimDriver",
                column: "ClaimNumber1");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimDriver_DriverID",
                table: "ClaimDriver",
                column: "DriverID");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimLossAdjuster_LossAdjusterID",
                table: "ClaimLossAdjuster",
                column: "LossAdjusterID");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimRecovery_ClaimNumber",
                table: "ClaimRecovery",
                column: "ClaimNumber");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimRecovery_ThirdPartyID",
                table: "ClaimRecovery",
                column: "ThirdPartyID");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimRepairer_ClaimNumber1",
                table: "ClaimRepairer",
                column: "ClaimNumber1");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimRepairer_RepairerID",
                table: "ClaimRepairer",
                column: "RepairerID");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimThirdParty_ThirdPartyID",
                table: "ClaimThirdParty",
                column: "ThirdPartyID");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimTracingAgent_ClaimNumber1",
                table: "ClaimTracingAgent",
                column: "ClaimNumber1");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimTracingAgent_TracingAgentID",
                table: "ClaimTracingAgent",
                column: "TracingAgentID");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimTransaction_AccountID",
                table: "ClaimTransaction",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimTransaction_AffectedID",
                table: "ClaimTransaction",
                column: "AffectedID");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimTransaction_ClaimNumber",
                table: "ClaimTransaction",
                column: "ClaimNumber");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceNumber",
                table: "ClaimTransaction",
                column: "InvoiceNumber",
                unique: true,
                filter: "[InvoiceNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimTransaction_PayableID",
                table: "ClaimTransaction",
                column: "PayableID");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimTransaction_PayeeID",
                table: "ClaimTransaction",
                column: "PayeeID");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionNumber",
                table: "ClaimTransaction",
                column: "TransactionNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClaimTransaction_TransactionTypeID",
                table: "ClaimTransaction",
                column: "TransactionTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Client_ClientTypeID",
                table: "Client",
                column: "ClientTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Client_CountryID",
                table: "Client",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_IDNumber",
                table: "Client",
                column: "IDNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Client_OccupationID",
                table: "Client",
                column: "OccupationID");

            migrationBuilder.CreateIndex(
                name: "IX_Client_TitleID",
                table: "Client",
                column: "TitleID");

            migrationBuilder.CreateIndex(
                name: "IX_ClientTemp_CountryID",
                table: "ClientTemp",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_ClientTemp_OccupationID",
                table: "ClientTemp",
                column: "OccupationID");

            migrationBuilder.CreateIndex(
                name: "IX_ClientTemp_TitleID",
                table: "ClientTemp",
                column: "TitleID");

            migrationBuilder.CreateIndex(
                name: "IX_Commercial_ComponentID",
                table: "Commercial",
                column: "ComponentID");

            migrationBuilder.CreateIndex(
                name: "IX_Commercial_PolicyID",
                table: "Commercial",
                column: "PolicyID");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintDetail_ComplaintID",
                table: "ComplaintDetail",
                column: "ComplaintID");

            migrationBuilder.CreateIndex(
                name: "IX_Container_CountryID",
                table: "Container",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Content_PolicyID",
                table: "Content",
                column: "PolicyID");

            migrationBuilder.CreateIndex(
                name: "IX_Content_ResidenceTypeID",
                table: "Content",
                column: "ResidenceTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Content_RoofTypeID",
                table: "Content",
                column: "RoofTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Content_WallTypeID",
                table: "Content",
                column: "WallTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Driver_TitleID",
                table: "Driver",
                column: "TitleID");

            migrationBuilder.CreateIndex(
                name: "IX_FormatType_LoadFormatID",
                table: "FormatType",
                column: "LoadFormatID");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentContact_ClaimNumber",
                table: "IncidentContact",
                column: "ClaimNumber");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItem_InvoiceID",
                table: "InvoiceItem",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Loan_ComponentID",
                table: "Loan",
                column: "ComponentID");

            migrationBuilder.CreateIndex(
                name: "IX_Loan_PolicyID",
                table: "Loan",
                column: "PolicyID");

            migrationBuilder.CreateIndex(
                name: "IX_LoanTemp_ComponentID",
                table: "LoanTemp",
                column: "ComponentID");

            migrationBuilder.CreateIndex(
                name: "IX_ChassisNumber",
                table: "Motor",
                column: "ChassisNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Motor_CoverageID",
                table: "Motor",
                column: "CoverageID");

            migrationBuilder.CreateIndex(
                name: "IX_Motor_DriverTypeID",
                table: "Motor",
                column: "DriverTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_EngineNumber",
                table: "Motor",
                column: "EngineNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Motor_MotorMakeID",
                table: "Motor",
                column: "MotorMakeID");

            migrationBuilder.CreateIndex(
                name: "IX_Motor_MotorTypeID",
                table: "Motor",
                column: "MotorTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Motor_PolicyID",
                table: "Motor",
                column: "PolicyID");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationNumber",
                table: "Motor",
                column: "RegistrationNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MotorDriver_DriverID",
                table: "MotorDriver",
                column: "DriverID");

            migrationBuilder.CreateIndex(
                name: "IX_MotorModel_MotorMakeID",
                table: "MotorModel",
                column: "MotorMakeID");

            migrationBuilder.CreateIndex(
                name: "IX_MotorSection_MotorID",
                table: "MotorSection",
                column: "MotorID");

            migrationBuilder.CreateIndex(
                name: "IX_MotorThirdParty_ClaimNumber",
                table: "MotorThirdParty",
                column: "ClaimNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Payable_PaymentTypeID",
                table: "Payable",
                column: "PaymentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_PayableReference",
                table: "Payable",
                column: "Reference",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PayeeClassItem",
                table: "Payee",
                columns: new[] { "PayeeClassID", "PayeeItemID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PayeeBankAccount_BankAccountID",
                table: "PayeeBankAccount",
                column: "BankAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_ClientID",
                table: "Policy",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_IncomeClassID",
                table: "Policy",
                column: "IncomeClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_InsurerID",
                table: "Policy",
                column: "InsurerID");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_PolicyFrequencyID",
                table: "Policy",
                column: "PolicyFrequencyID");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyNumber",
                table: "Policy",
                column: "PolicyNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Policy_PolicyStatusID",
                table: "Policy",
                column: "PolicyStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyBankAccount_BankAccountID",
                table: "PolicyBankAccount",
                column: "BankAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyTemp_InsurerID",
                table: "PolicyTemp",
                column: "InsurerID");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyTemp_PolicyFrequencyID",
                table: "PolicyTemp",
                column: "PolicyFrequencyID");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyTemp_PolicyStatusID",
                table: "PolicyTemp",
                column: "PolicyStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Premium_PolicyID",
                table: "Premium",
                column: "PolicyID");

            migrationBuilder.CreateIndex(
                name: "IX_Premium_PremiumTypeID",
                table: "Premium",
                column: "PremiumTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Premium_ReceivableID",
                table: "Premium",
                column: "ReceivableID");

            migrationBuilder.CreateIndex(
                name: "IX_Premium_RiskID",
                table: "Premium",
                column: "RiskID");

            migrationBuilder.CreateIndex(
                name: "IX_PremiumRefund_AccountID",
                table: "PremiumRefund",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_PremiumRefund_PremiumID",
                table: "PremiumRefund",
                column: "PremiumID");

            migrationBuilder.CreateIndex(
                name: "IX_PremiumTemp_PremiumTypeID",
                table: "PremiumTemp",
                column: "PremiumTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ContainerID",
                table: "Product",
                column: "ContainerID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductClient_ClientID",
                table: "ProductClient",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRisk_ProductID",
                table: "ProductRisk",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRisk_RiskID",
                table: "ProductRisk",
                column: "RiskID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRiskBenefit_ProductRiskID",
                table: "ProductRiskBenefit",
                column: "ProductRiskID");

            migrationBuilder.CreateIndex(
                name: "IX_Property_CoverageID",
                table: "Property",
                column: "CoverageID");

            migrationBuilder.CreateIndex(
                name: "IX_Property_PolicyID",
                table: "Property",
                column: "PolicyID");

            migrationBuilder.CreateIndex(
                name: "IX_Property_ResidenceTypeID",
                table: "Property",
                column: "ResidenceTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Property_RoofTypeID",
                table: "Property",
                column: "RoofTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Property_WallTypeID",
                table: "Property",
                column: "WallTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Province_CountryID",
                table: "Province",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Receivable_PaymentTypeID",
                table: "Receivable",
                column: "PaymentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivableReference",
                table: "Receivable",
                column: "Reference",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RiskClaimClass_ClaimClassID",
                table: "RiskClaimClass",
                column: "ClaimClassID");

            migrationBuilder.CreateIndex(
                name: "IX_RiskClaimDocument_ClaimDocumentID",
                table: "RiskClaimDocument",
                column: "ClaimDocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_RiskIncident_IncidentID",
                table: "RiskIncident",
                column: "IncidentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressAssignment");

            migrationBuilder.DropTable(
                name: "AllRisk");

            migrationBuilder.DropTable(
                name: "AllRiskHistory");

            migrationBuilder.DropTable(
                name: "Authoriser");

            migrationBuilder.DropTable(
                name: "BankDirectDebit");

            migrationBuilder.DropTable(
                name: "BatchNumberGenerator");

            migrationBuilder.DropTable(
                name: "BulkHandleGenerator");

            migrationBuilder.DropTable(
                name: "Cheque");

            migrationBuilder.DropTable(
                name: "ChequeBook");

            migrationBuilder.DropTable(
                name: "ChequeSummaryTemp");

            migrationBuilder.DropTable(
                name: "ChequeTemp");

            migrationBuilder.DropTable(
                name: "ClaimAccounting");

            migrationBuilder.DropTable(
                name: "ClaimAttorney");

            migrationBuilder.DropTable(
                name: "ClaimDiary");

            migrationBuilder.DropTable(
                name: "ClaimDocumentSubmit");

            migrationBuilder.DropTable(
                name: "ClaimDriver");

            migrationBuilder.DropTable(
                name: "ClaimLossAdjuster");

            migrationBuilder.DropTable(
                name: "ClaimNumberGenerator");

            migrationBuilder.DropTable(
                name: "ClaimRecovery");

            migrationBuilder.DropTable(
                name: "ClaimRepairer");

            migrationBuilder.DropTable(
                name: "ClaimThirdParty");

            migrationBuilder.DropTable(
                name: "ClaimTracingAgent");

            migrationBuilder.DropTable(
                name: "ClaimTransaction");

            migrationBuilder.DropTable(
                name: "ClaimTransactionGenerator");

            migrationBuilder.DropTable(
                name: "ClientAccounting");

            migrationBuilder.DropTable(
                name: "ClientTemp");

            migrationBuilder.DropTable(
                name: "Commercial");

            migrationBuilder.DropTable(
                name: "CommercialHistory");

            migrationBuilder.DropTable(
                name: "ComplaintDetail");

            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.DropTable(
                name: "ContentHistory");

            migrationBuilder.DropTable(
                name: "FormatType");

            migrationBuilder.DropTable(
                name: "IncidentContact");

            migrationBuilder.DropTable(
                name: "InvoiceItem");

            migrationBuilder.DropTable(
                name: "InvoiceNumberGenerator");

            migrationBuilder.DropTable(
                name: "Loan");

            migrationBuilder.DropTable(
                name: "LoanHistory");

            migrationBuilder.DropTable(
                name: "LoanTemp");

            migrationBuilder.DropTable(
                name: "MotorDriver");

            migrationBuilder.DropTable(
                name: "MotorHistory");

            migrationBuilder.DropTable(
                name: "MotorModel");

            migrationBuilder.DropTable(
                name: "MotorSection");

            migrationBuilder.DropTable(
                name: "MotorThirdParty");

            migrationBuilder.DropTable(
                name: "PayableExport");

            migrationBuilder.DropTable(
                name: "PayeeBankAccount");

            migrationBuilder.DropTable(
                name: "PolicyBankAccount");

            migrationBuilder.DropTable(
                name: "PolicyHistory");

            migrationBuilder.DropTable(
                name: "PolicyNumberGenerator");

            migrationBuilder.DropTable(
                name: "PolicyTemp");

            migrationBuilder.DropTable(
                name: "PremiumRefund");

            migrationBuilder.DropTable(
                name: "PremiumTemp");

            migrationBuilder.DropTable(
                name: "ProductClient");

            migrationBuilder.DropTable(
                name: "ProductRiskBenefit");

            migrationBuilder.DropTable(
                name: "Property");

            migrationBuilder.DropTable(
                name: "PropertyHistory");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropTable(
                name: "RiskClaimClass");

            migrationBuilder.DropTable(
                name: "RiskClaimDocument");

            migrationBuilder.DropTable(
                name: "RiskIncident");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Attorney");

            migrationBuilder.DropTable(
                name: "LossAdjuster");

            migrationBuilder.DropTable(
                name: "Repairer");

            migrationBuilder.DropTable(
                name: "ThirdParty");

            migrationBuilder.DropTable(
                name: "TracingAgent");

            migrationBuilder.DropTable(
                name: "Payable");

            migrationBuilder.DropTable(
                name: "TransactionType");

            migrationBuilder.DropTable(
                name: "Complaint");

            migrationBuilder.DropTable(
                name: "LoadFormat");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Component");

            migrationBuilder.DropTable(
                name: "Driver");

            migrationBuilder.DropTable(
                name: "Motor");

            migrationBuilder.DropTable(
                name: "Claim");

            migrationBuilder.DropTable(
                name: "Payee");

            migrationBuilder.DropTable(
                name: "BankAccount");

            migrationBuilder.DropTable(
                name: "AccountChart");

            migrationBuilder.DropTable(
                name: "Premium");

            migrationBuilder.DropTable(
                name: "ProductRisk");

            migrationBuilder.DropTable(
                name: "ResidenceType");

            migrationBuilder.DropTable(
                name: "RoofType");

            migrationBuilder.DropTable(
                name: "WallType");

            migrationBuilder.DropTable(
                name: "ClaimDocument");

            migrationBuilder.DropTable(
                name: "Coverage");

            migrationBuilder.DropTable(
                name: "DriverType");

            migrationBuilder.DropTable(
                name: "MotorMake");

            migrationBuilder.DropTable(
                name: "MotorType");

            migrationBuilder.DropTable(
                name: "Affected");

            migrationBuilder.DropTable(
                name: "ClaimClass");

            migrationBuilder.DropTable(
                name: "ClaimStatus");

            migrationBuilder.DropTable(
                name: "Incident");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "PayeeClass");

            migrationBuilder.DropTable(
                name: "BankBranch");

            migrationBuilder.DropTable(
                name: "Policy");

            migrationBuilder.DropTable(
                name: "PremiumType");

            migrationBuilder.DropTable(
                name: "Receivable");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Risk");

            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "IncomeClass");

            migrationBuilder.DropTable(
                name: "Insurer");

            migrationBuilder.DropTable(
                name: "PolicyFrequency");

            migrationBuilder.DropTable(
                name: "PolicyStatus");

            migrationBuilder.DropTable(
                name: "PaymentType");

            migrationBuilder.DropTable(
                name: "Container");

            migrationBuilder.DropTable(
                name: "ClientType");

            migrationBuilder.DropTable(
                name: "Occupation");

            migrationBuilder.DropTable(
                name: "Title");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
