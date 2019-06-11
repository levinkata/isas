using Microsoft.EntityFrameworkCore;
using Isas.Models;
using System.Linq;

namespace Isas.Data
{
    public class InsurerDbContext : DbContext
    {
        public InsurerDbContext(DbContextOptions<InsurerDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<AccountChart> AccountCharts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressAssignment> AddressAssignments { get; set; }
        public DbSet<Affected> Affecteds { get; set; }
        public DbSet<AllRisk> AllRisks { get; set; }
        public DbSet<AllRiskHistory> AllRisksHistory { get; set; }
        public DbSet<Attorney> Attorneys { get; set; }
        public DbSet<Authoriser> Authorisers { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<BankBranch> BankBranches { get; set; }
        public DbSet<BankDirectDebit> BankDirectDebits { get; set; }
        public DbSet<BatchNumberGenerator> BatchNumberGenerators { get; set; }
        public DbSet<BulkHandleGenerator> BulkHandleGenerators { get; set; }
        public DbSet<Cheque> Cheques { get; set; }
        public DbSet<ChequeBook> ChequeBooks { get; set; }
        public DbSet<ChequeSummaryTemp> ChequeSummaryTemps { get; set; }        
        public DbSet<ChequeTemp> ChequeTemps { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<ClaimAccounting> ClaimAccounting { get; set; }
        public DbSet<ClaimAttorney> ClaimAttorneys { get; set; }
        public DbSet<ClaimClass> ClaimClasses { get; set; }
        public DbSet<ClaimDiary> ClaimDiaries { get; set; }
        public DbSet<ClaimDocument> ClaimDocuments { get; set; }
        public DbSet<ClaimDocumentSubmit> ClaimDocumentSubmits { get; set; }
        public DbSet<ClaimDriver> ClaimDrivers { get; set; }
        public DbSet<ClaimLossAdjuster> ClaimLossAdjusters { get; set; }
        public DbSet<ClaimNumberGenerator> ClaimNumberGenerators { get; set; }
        public DbSet<ClaimRecovery> ClaimRecoveries { get; set; }
        public DbSet<ClaimRepairer> ClaimRepairers { get; set; }
        public DbSet<ClaimStatus> ClaimStatuses { get; set; }
        public DbSet<ClaimThirdParty> ClaimThirdParties { get; set; }
        public DbSet<ClaimTracingAgent> ClaimTracingAgents { get; set; }
        public DbSet<ClaimTransaction> ClaimTransactions { get; set; }
        public DbSet<ClaimTransactionGenerator> ClaimTransactionGenerators { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientAccounting> ClientAccountings { get; set; }
        public DbSet<ClientType> ClientTypes { get; set; }
        public DbSet<ClientTemp> ClientTemps { get; set; }
        public DbSet<Commercial> Commercials { get; set; }
        public DbSet<CommercialHistory> CommercialsHistory { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<ComplaintDetail> ComplaintDetails { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<Container> Containers { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<ContentHistory> ContentsHistory { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Coverage> Coverages { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<DriverType> DriverTypes { get; set; }
        public DbSet<FormatType> FormatTypes { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<IncidentContact> IncidentContacts { get; set; }
        public DbSet<IncomeClass> IncomeClasses { get; set; }
        public DbSet<Insurer> Insurers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<InvoiceNumberGenerator> InvoiceNumberGenerators { get; set; }
        public DbSet<LoadFormat> LoadFormats { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<LoanHistory> LoansHistory { get; set; }
        public DbSet<LoanTemp> LoanTemps { get; set; }
        public DbSet<LossAdjuster> LossAdjusters { get; set; }
        public DbSet<Motor> Motors { get; set; }
        public DbSet<MotorHistory> MotorsHistory { get; set; }
        public DbSet<MotorMake> MotorMakes { get; set; }
        public DbSet<MotorModel> MotorModels { get; set; }
        public DbSet<MotorSection> MotorSections { get; set; }
        public DbSet<MotorThirdParty> MotorThirdParties { get; set; }
        public DbSet<MotorType> MotorTypes { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<Payable> Payables { get; set; }
        public DbSet<PayableExport> PayableExports { get; set; }
        public DbSet<Payee> Payees { get; set; }
        public DbSet<PayeeBankAccount> PayeeBankAccounts { get; set; }
        public DbSet<PayeeClass> PayeeClasses { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<PolicyBankAccount> PolicyBankAccounts { get; set; }
        public DbSet<PolicyFrequency> PolicyFrequencies { get; set; }
        public DbSet<PolicyNumberGenerator> PolicyNumberGenerators { get; set; }
        public DbSet<PolicyHistory> PolicyHistories { get; set; }
        public DbSet<PolicyStatus> PolicyStatuses { get; set; }
        public DbSet<PolicyTemp> PolicyTemps { get; set; }
        public DbSet<Premium> Premiums { get; set; }
        public DbSet<PremiumRefund> PremiumRefunds { get; set; }
        public DbSet<PremiumTemp> PremiumTemps { get; set; }
        public DbSet<PremiumType> PremiumTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductClient> ProductClients { get; set; }
        public DbSet<ProductRisk> ProductRisks { get; set; }
        public DbSet<ProductRiskBenefit> ProductRiskBenefits { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyHistory> PropertiesHistory { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Receivable> Receivables { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Repairer> Repairers { get; set; }
        public DbSet<ResidenceType> ResidenceTypes { get; set; }
        public DbSet<Risk> Risks { get; set; }
        public DbSet<RiskClaimClass> RiskClaimClasses { get; set; }
        public DbSet<RiskClaimDocument> RiskClaimDocuments { get; set; }        
        public DbSet<RiskIncident> RiskIncidents { get; set; }
        public DbSet<RoofType> RoofTypes { get; set; }
        public DbSet<ThirdParty> ThirdParties { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<TracingAgent> TracingAgents { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<WallType> WallTypes { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<AccountChart>().ToTable("AccountChart");
            modelBuilder.Entity<Address>().ToTable("Address");

            modelBuilder.Entity<AddressAssignment>(p =>
            {
                // Maps to the AddressAssignment table
                p.ToTable("AddressAssignment");

                // Composite primary key consisting of the ItemID and AddressID
                p.HasKey(a => new { a.ItemID, a.AddressID }).HasName("PK_AddressAssignment");
            });

            modelBuilder.Entity<Affected>().ToTable("Affected");

            modelBuilder.Entity<AllRisk>(p =>
            {
                //  Map to the table AllRisk
                p.ToTable("AllRisk");

                //  Set the database number storage format for the column
                p.Property(r => r.Value).HasColumnType("decimal(18,2)");
                p.Property(r => r.Premium).HasColumnType("decimal(18,2)");
                p.Property(r => r.PolicyFee).HasColumnType("decimal(18,2)");
                p.Property(r => r.InsurerFee).HasColumnType("decimal(18,2)");
                p.Property(r => r.Commission).HasColumnType("decimal(18,2)");
                p.Property(r => r.AdminFee).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<AllRiskHistory>(p =>
            {
                //  Map to the table AllRAllRiskHistoryisk
                p.ToTable("AllRiskHistory");

                //  Set the database number storage format for the column
                p.Property(r => r.Value).HasColumnType("decimal(18,2)");
                p.Property(r => r.Premium).HasColumnType("decimal(18,2)");
                p.Property(r => r.PolicyFee).HasColumnType("decimal(18,2)");
                p.Property(r => r.InsurerFee).HasColumnType("decimal(18,2)");
                p.Property(r => r.Commission).HasColumnType("decimal(18,2)");
                p.Property(r => r.AdminFee).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Attorney>().ToTable("Attorney");
            modelBuilder.Entity<Authoriser>().ToTable("Authoriser");

            modelBuilder.Entity<Bank>(p =>
            {
                //  Map to the Bank table
                p.ToTable("Bank");

                //  Has many BankBranches side of a one-to-many relationship
                p.HasMany(c => c.BankBranches).WithOne(e => e.Bank);
            });

            modelBuilder.Entity<BankAccount>().ToTable("BankAccount");

            modelBuilder.Entity<BankBranch>(p =>
            {
                //  Map to the BankBranch table
                p.ToTable("BankBranch");

                //  Has a one-to-many relationship
                p.HasOne(e => e.Bank).WithMany(c => c.BankBranches);
            });

            modelBuilder.Entity<BankDirectDebit>().ToTable("BankDirectDebit");

            modelBuilder.Entity<BatchNumberGenerator>(p =>
            {
                //  Map to the table BatchNumberGenerator
                p.ToTable("BatchNumberGenerator");

                //Primary key consisting of the BatchNumber
                p.HasKey(r => new { r.BatchNumber }).HasName("PK_BatchNumberGenerator");

                p.Property(r => r.BatchNumber).ValueGeneratedNever();
            });

            modelBuilder.Entity<BulkHandleGenerator>(p =>
            {
                //  Map to the table BulkHandleGenerator
                p.ToTable("BulkHandleGenerator");

                //Primary key consisting of the BulkNumber
                p.HasKey(r => new { r.BulkNumber }).HasName("PK_BulkHandleGenerator");

                p.Property(r => r.BulkNumber).ValueGeneratedNever();
            });

            modelBuilder.Entity<Cheque>(p =>
            {
                //  Map to the table Cheque
                p.ToTable("Cheque");

                //  Index for ChequeNumber to allow efficient lookups
                p.HasIndex(r => new { r.ChequeNumber }).IsUnique().HasName("IX_ChequeNumber");

                //  Set the database number storage format for the column
                p.Property(r => r.ChequeDate).HasColumnType("Date");
                p.Property(r => r.Amount).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<ChequeBook>().ToTable("ChequeBook");

            modelBuilder.Entity<ChequeSummaryTemp>(p =>
            {
                //  Map to the table ChequeSummaryTemp
                p.ToTable("ChequeSummaryTemp");

                // Composite primary key consisting of the PayeeID and ProductID
                p.HasKey(r => new { r.PayeeID, r.ProductID }).HasName("PK_ChequeSummaryTemp");

                //  Set the database number storage format for the column
                p.Property(r => r.Amount).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<ChequeTemp>(p =>
            {
                //  Map to the table ChequeTemp
                p.ToTable("ChequeTemp");

                //  Set the database number storage format for the column
                p.Property(r => r.Amount).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Claim>(p =>
            {
                //  Map to the Claim table
                p.ToTable("Claim");

                //  Primary key consisting of the ClaimNumber
                p.HasKey(r => new { r.ClaimNumber }).HasName("PK_Claim");

                //  ClaimNumber column is not to be populated when the table is inserted
                p.Property(r => r.ClaimNumber).ValueGeneratedNever();

                p.HasOne(b => b.Policy).WithMany(a => a.Claims).OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Claim_Policy_PolicyID");

                //  Set the database number storage format for the column
                p.Property(r => r.ReserveInsured).HasColumnType("decimal(18,2)");
                p.Property(r => r.ReserveThirdParty).HasColumnType("decimal(18,2)");
                p.Property(r => r.ReserveInsuredRevised).HasColumnType("decimal(18,2)");
                p.Property(r => r.ReserveThirdPartyRevised).HasColumnType("decimal(18,2)");
                p.Property(r => r.ClaimExcess).HasColumnType("decimal(18,2)");

                //  DateAdded column is populated when the table is inserted
                p.Property(r => r.DateAdded).ValueGeneratedOnAdd().HasComputedColumnSql("GetDate()");

                //  DateModified column is populated when the table is updated
                p.Property(r => r.DateModified).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetDate()");
            });

            modelBuilder.Entity<ClaimAccounting>(p =>
            {
                //  Map to the table ClaimAccounting
                p.ToTable("ClaimAccounting");

                //  Set the database storage format for the column
                p.Property(r => r.InvoiceDate).HasColumnType("Date");
                p.Property(r => r.Amount).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<ClaimAttorney>(p =>
            {
                //  Map to the table ClaimAttorney
                p.ToTable("ClaimAttorney");

                // Composite primary key consisting of the ClaimNumber and AttorneyID
                p.HasKey(r => new { r.ClaimNumber, r.AttorneyID }).HasName("PK_ClaimAttorney");
            });

            modelBuilder.Entity<ClaimClass>().ToTable("ClaimClass");
            modelBuilder.Entity<ClaimDiary>().ToTable("ClaimDiary");
            modelBuilder.Entity<ClaimDocument>().ToTable("ClaimDocument");
            modelBuilder.Entity<ClaimDocumentSubmit>().ToTable("ClaimDocumentSubmit");

            modelBuilder.Entity<ClaimDriver>(p =>
            {
                //  Map to the table ClaimDriver
                p.ToTable("ClaimDriver");

                // Composite primary key consisting of the ClaimNumber and DriverID
                p.HasKey(r => new { r.ClaimNumber, r.DriverID }).HasName("PK_ClaimDriver");
            });

            modelBuilder.Entity<ClaimLossAdjuster>(p =>
            {
                //  Map to the table ClaimLossAdjuster
                p.ToTable("ClaimLossAdjuster");

                // Composite primary key consisting of the ClaimNumber and LossAdjusterID
                p.HasKey(r => new { r.ClaimNumber, r.LossAdjusterID }).HasName("PK_ClaimLossAdjuster");

                //  Set the database number storage format for the column
                p.Property(r => r.ClaimExcess).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<ClaimNumberGenerator>(p =>
            {
                //  Map to the ClaimGenerator table
                p.ToTable("ClaimNumberGenerator");

                // Composite primary key consisting of the ClaimPrefix and ClaimNumber
                p.HasKey(r => new { r.ClaimPrefix, r.ClaimNumber }).HasName("PK_ClaimNumberGenerator");
            });

            modelBuilder.Entity<ClaimRecovery>(p =>
            {
                //  Map to the table ClaimRecovery
                p.ToTable("ClaimRecovery");

                //  Set the database number storage format for the column
                p.Property(r => r.Amount).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<ClaimRepairer>(p =>
            {
                //  Map to the table ClaimRepairer
                p.ToTable("ClaimRepairer");

                // Composite primary key consisting of the ClaimNumber and RepairerID
                p.HasKey(r => new { r.ClaimNumber, r.RepairerID }).HasName("PK_ClaimRepairer");
            });

            modelBuilder.Entity<ClaimStatus>().ToTable("ClaimStatus");

            modelBuilder.Entity<ClaimThirdParty>(p =>
            {
                //  Map to the ClaimThirdParty table
                p.ToTable("ClaimThirdParty");

                // Composite primary key consisting of the ClaimNumber and ThirdPartyID
                p.HasKey(r => new { r.ClaimNumber, r.ThirdPartyID }).HasName("PK_ClaimThirdParty");
            });

            modelBuilder.Entity<ClaimTracingAgent>(p =>
            {
                //  Map to the ClaimTracingAgent table
                p.ToTable("ClaimTracingAgent");

                // Composite primary key consisting of the ClaimNumber and TracingAgentID
                p.HasKey(r => new { r.ClaimNumber, r.TracingAgentID }).HasName("PK_ClaimTracingAgent");
            });

            modelBuilder.Entity<ClaimTransaction>(p =>
            {
                //  Map to the ClaimTransaction table
                p.ToTable("ClaimTransaction");

                //  Index for InvoiceNumber to allow efficient lookups
                p.HasIndex(i => i.InvoiceNumber).IsUnique().HasName("IX_InvoiceNumber");

                //  Index for TransactionNumber to allow efficient lookups
                p.HasIndex(i => i.TransactionNumber).IsUnique().HasName("IX_TransactionNumber");

                //  Set the database number storage format for the column
                p.Property(r => r.Amount).HasColumnType("decimal(18,2)");
                p.Property(r => r.TaxAmount).HasColumnType("decimal(18,2)");
                p.Property(r => r.ReserveInsured).HasColumnType("decimal(18,2)");
                p.Property(r => r.ReserveThirdParty).HasColumnType("decimal(18,2)");

                // HasColumnType("money").HasComputedColumnSql("[Quantity]*[UnitCost]");
            });

            modelBuilder.Entity<ClaimTransactionGenerator>(p =>
            {
                //  Map to the table ClaimTransactionGenerator
                p.ToTable("ClaimTransactionGenerator");

                //Primary key consisting of the TransactionNumber
                p.HasKey(r => new { r.TransactionNumber }).HasName("PK_TransactionNumber");

                p.Property(r => r.TransactionNumber).ValueGeneratedNever();
            });

            modelBuilder.Entity<Client>(p =>
            {
                //  Maps to the Client table
                p.ToTable("Client");

                //  Index for IDNumber to allow efficient lookups
                p.HasIndex(i => i.IDNumber).IsUnique().HasName("IX_IDNumber");

                //  Limit the size of columns to use efficient database types
                p.Property(l => l.FirstName).HasMaxLength(50);
                p.Property(l => l.LastName).HasMaxLength(50).IsRequired();

                //  Set the database storage format for the column
                p.Property(r => r.BirthDate).HasColumnType("Date");
            });

            modelBuilder.Entity<ClientAccounting>(p =>
            {
                //  Maps to the ClientAccounting table
                p.ToTable("ClientAccounting");

                //  Set the database number storage format for the column
                p.Property(r => r.Amount).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<ClientTemp>().ToTable("ClientTemp");
            modelBuilder.Entity<ClientType>().ToTable("ClientType");

            modelBuilder.Entity<Commercial>(p =>
            {
                //  Map to the table Commercial
                p.ToTable("Commercial");

                //  Set the database number storage format for the column
                p.Property(r => r.Rate).HasColumnType("decimal(18,2)");
                p.Property(r => r.Value).HasColumnType("decimal(18,2)");
                p.Property(r => r.Premium).HasColumnType("decimal(18,2)");
                p.Property(r => r.PolicyFee).HasColumnType("decimal(18,2)");
                p.Property(r => r.InsurerFee).HasColumnType("decimal(18,2)");
                p.Property(r => r.Commission).HasColumnType("decimal(18,2)");
                p.Property(r => r.AdminFee).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<CommercialHistory>(p =>
            {
                //  Map to the table CommercialHistory
                p.ToTable("CommercialHistory");

                //  Set the database number storage format for the column
                p.Property(r => r.Rate).HasColumnType("decimal(18,2)");
                p.Property(r => r.Value).HasColumnType("decimal(18,2)");
                p.Property(r => r.Premium).HasColumnType("decimal(18,2)");
                p.Property(r => r.PolicyFee).HasColumnType("decimal(18,2)");
                p.Property(r => r.InsurerFee).HasColumnType("decimal(18,2)");
                p.Property(r => r.Commission).HasColumnType("decimal(18,2)");
                p.Property(r => r.AdminFee).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Complaint>().ToTable("Complaint");
            modelBuilder.Entity<ComplaintDetail>().ToTable("ComplaintDetail");
            modelBuilder.Entity<Component>().ToTable("Component");
            modelBuilder.Entity<Container>().ToTable("Container");

            modelBuilder.Entity<Content>(p =>
            {
                //  Map to the table Content
                p.ToTable("Content");

                //  Set the database number storage format for the column
                p.Property(r => r.Value).HasColumnType("decimal(18,2)");
                p.Property(r => r.Premium).HasColumnType("decimal(18,2)");
                p.Property(r => r.PolicyFee).HasColumnType("decimal(18,2)");
                p.Property(r => r.Commission).HasColumnType("decimal(18,2)");
                p.Property(r => r.InsurerFee).HasColumnType("decimal(18,2)");
                p.Property(r => r.AdminFee).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<ContentHistory>(p =>
            {
                //  Map to the table ContentHistory
                p.ToTable("ContentHistory");

                //  Set the database number storage format for the column
                p.Property(r => r.Value).HasColumnType("decimal(18,2)");
                p.Property(r => r.Premium).HasColumnType("decimal(18,2)");
                p.Property(r => r.PolicyFee).HasColumnType("decimal(18,2)");
                p.Property(r => r.InsurerFee).HasColumnType("decimal(18,2)");
                p.Property(r => r.Commission).HasColumnType("decimal(18,2)");
                p.Property(r => r.AdminFee).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Country>(p=>
            {
                //  Map to the table Country
                p.ToTable("Country");

                //  Set the database number storage format for the column
                p.Property(r => r.Tax).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Coverage>().ToTable("Coverage");
            modelBuilder.Entity<Driver>().ToTable("Driver");
            modelBuilder.Entity<DriverType>().ToTable("DriverType");
            modelBuilder.Entity<FormatType>().ToTable("FormatType");
            modelBuilder.Entity<Incident>().ToTable("Incident");
            modelBuilder.Entity<IncidentContact>().ToTable("IncidentContact");
            modelBuilder.Entity<IncomeClass>().ToTable("IncomeClass");
            modelBuilder.Entity<Insurer>().ToTable("Insurer");
            
            modelBuilder.Entity<Invoice>(p =>
            {
                //  Maps to the Invoice table
                p.ToTable("Invoice");

                //  Primary key consisting of the InvoiceNumber
                p.HasKey(r => new { r.InvoiceNumber }).HasName("PK_Invoice");

                //  InvoiceNumber column is not to be populated when the table is inserted
                p.Property(r => r.InvoiceNumber).ValueGeneratedNever();
            });

            modelBuilder.Entity<InvoiceItem>(p =>
            {
                //  Map to the table InvoiceItem
                p.ToTable("InvoiceItem");

                //  Set the database number storage format for the column
                p.Property(r => r.Premium).HasColumnType("decimal(18,2)").HasDefaultValue(0);
                p.Property(r => r.TaxAmount).HasColumnType("decimal(18,2)").HasDefaultValue(0);
            });
            
            modelBuilder.Entity<InvoiceNumberGenerator>(p =>
            {
                //  Map to the table InvoiceNumberGenerator
                p.ToTable("InvoiceNumberGenerator");

                //Primary key consisting of the InvoiceNumber
                p.HasKey(r => new { r.InvoiceNumber }).HasName("PK_InvoiceNumberGenerator");

                p.Property(r => r.InvoiceNumber).ValueGeneratedNever();
            });

            modelBuilder.Entity<LoadFormat>().ToTable("LoadFormat");

            modelBuilder.Entity<Loan>(p =>
            {
                //  Map to the table Loan
                p.ToTable("Loan");

                //  Set the database number storage format for the column
                p.Property(r => r.Term).HasColumnType("decimal(18,2)");
                p.Property(r => r.Rate).HasColumnType("decimal(18,2)");
                p.Property(r => r.Value).HasColumnType("decimal(18,2)");
                p.Property(r => r.Premium).HasColumnType("decimal(18,2)");
                p.Property(r => r.PolicyFee).HasColumnType("decimal(18,2)");
                p.Property(r => r.InsurerFee).HasColumnType("decimal(18,2)");
                p.Property(r => r.Commission).HasColumnType("decimal(18,2)");
                p.Property(r => r.AdminFee).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<LoanHistory>(p =>
            {
                //  Map to the table LoanHistory
                p.ToTable("LoanHistory");

                //  Set the database number storage format for the column
                p.Property(r => r.Term).HasColumnType("decimal(18,2)");
                p.Property(r => r.Rate).HasColumnType("decimal(18,2)");
                p.Property(r => r.Value).HasColumnType("decimal(18,2)");
                p.Property(r => r.Premium).HasColumnType("decimal(18,2)");
                p.Property(r => r.PolicyFee).HasColumnType("decimal(18,2)");
                p.Property(r => r.InsurerFee).HasColumnType("decimal(18,2)");
                p.Property(r => r.Commission).HasColumnType("decimal(18,2)");
                p.Property(r => r.AdminFee).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<LoanTemp>(p =>
            {
                //  Map to the table LoanTemp
                p.ToTable("LoanTemp");

                //  Set the database number storage format for the column
                p.Property(r => r.Term).HasColumnType("decimal(18,2)");
                p.Property(r => r.Rate).HasColumnType("decimal(18,2)");
                p.Property(r => r.Value).HasColumnType("decimal(18,2)");
                p.Property(r => r.Premium).HasColumnType("decimal(18,2)");
            });
             
            modelBuilder.Entity<LossAdjuster>().ToTable("LossAdjuster");

            modelBuilder.Entity<Motor>(p =>
            {
                //  Maps to the Motor table
                p.ToTable("Motor");

                // Index for RegistrationNumber to allow efficient lookups
                p.HasIndex(r => r.RegistrationNumber).IsUnique().HasName("IX_RegistrationNumber");

                // Index for EngineNumber to allow efficient lookups
                p.HasIndex(e => e.EngineNumber).IsUnique().HasName("IX_EngineNumber");

                // Index for ChassisNumber to allow efficient lookups
                p.HasIndex(c => c.ChassisNumber).IsUnique().HasName("IX_ChassisNumber");

                //  Set the database number storage format for the column
                p.Property(r => r.Value).HasColumnType("decimal(18,2)");
                p.Property(r => r.Premium).HasColumnType("decimal(18,2)");
                p.Property(r => r.PolicyFee).HasColumnType("decimal(18,2)");
                p.Property(r => r.InsurerFee).HasColumnType("decimal(18,2)");
                p.Property(r => r.Commission).HasColumnType("decimal(18,2)");
                p.Property(r => r.AdminFee).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<MotorDriver>(p =>
            {
                //  Map to the MotorDriver table
                p.ToTable("MotorDriver");

                // Composite primary key consisting of the MotorID and DriverID
                p.HasKey(r => new { r.MotorID, r.DriverID }).HasName("PK_MotorDriver");
            });

            modelBuilder.Entity<MotorHistory>(p =>
            {
                //  Maps to the MotorHistory table
                p.ToTable("MotorHistory");

                //  Set the database number storage format for the column
                p.Property(r => r.Value).HasColumnType("decimal(18,2)");
                p.Property(r => r.Premium).HasColumnType("decimal(18,2)");
                p.Property(r => r.PolicyFee).HasColumnType("decimal(18,2)");
                p.Property(r => r.InsurerFee).HasColumnType("decimal(18,2)");
                p.Property(r => r.Commission).HasColumnType("decimal(18,2)");
                p.Property(r => r.AdminFee).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<MotorMake>().ToTable("MotorMake");
            modelBuilder.Entity<MotorModel>().ToTable("MotorModel");

            modelBuilder.Entity<MotorSection>(p =>
            {
                //  Map to the table MotorSection
                p.ToTable("MotorSection");

                //  Set the database number storage format for the column
                p.Property(r => r.Value).HasColumnType("decimal(18,2)");
                p.Property(r => r.Premium).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<MotorThirdParty>().ToTable("MotorThirdParty");
            modelBuilder.Entity<MotorType>().ToTable("MotorType");
            modelBuilder.Entity<Occupation>().ToTable("Occupation");

            modelBuilder.Entity<Payable>(p =>
            {
                //  Map to the table Payable
                p.ToTable("Payable");

                // Index for Reference to allow efficient lookups
                p.HasIndex(r => r.Reference).IsUnique().HasName("IX_PayableReference");

                //  Set the database number storage format for the column
                p.Property(r => r.Amount).HasColumnType("decimal(18,2)");
            });
            
            modelBuilder.Entity<PayableExport>().ToTable("PayableExport");

            modelBuilder.Entity<Payee>(p =>
            {
                //  Map to the table Payee
                p.ToTable("Payee");

                p.HasIndex(r => new { r.PayeeClassID, r.PayeeItemID }).IsUnique().HasName("IX_PayeeClassItem");
            });

            modelBuilder.Entity<PayeeBankAccount>(p =>
            {
                //  Map to the PayeeBankAccount table
                p.ToTable("PayeeBankAccount");

                // Composite primary key consisting of the PayeeID and BankAccountID
                p.HasKey(r => new { r.PayeeID, r.BankAccountID }).HasName("PK_PayeeBankAccount");
            });

            modelBuilder.Entity<PayeeClass>().ToTable("PayeeClass");
            modelBuilder.Entity<PaymentType>().ToTable("PaymentType");

            modelBuilder.Entity<Policy>(p =>
            {
                //  Maps to the Policy table
                p.ToTable("Policy");

                //  Limit the size of columns to use efficient database types
                p.Property(l => l.PolicyNumber).HasMaxLength(50).IsRequired();
                p.Property(l => l.InsurerNumber).HasMaxLength(50);

                // Index for PolicyNumber to allow efficient lookups
                p.HasIndex(i => i.PolicyNumber).IsUnique().HasName("IX_PolicyNumber");

                //  Set CoverStartDate to Datetime datatype and default value to today
                p.Property(e => e.EffectiveDate).HasColumnType("Date").HasDefaultValueSql("GetDate()");
            });

            modelBuilder.Entity<PolicyBankAccount>(p =>
            {
                //  Map to the PolicyBankAccount table
                p.ToTable("PolicyBankAccount");

                // Composite primary key consisting of the PolicyID and BankAccountID
                p.HasKey(r => new { r.PolicyID, r.BankAccountID }).HasName("PK_PolicyBankAccount");
            });

            modelBuilder.Entity<PolicyFrequency>().ToTable("PolicyFrequency");
            modelBuilder.Entity<PolicyHistory>().ToTable("PolicyHistory");

            modelBuilder.Entity<PolicyNumberGenerator>(p =>
            {
                //  Map to the PolicyNumberGenerator table
                p.ToTable("PolicyNumberGenerator");

                //  Primary key consisting of the PolicyNumber
                p.HasKey(r => new { r.PolicyNumber }).HasName("PK_PolicyNumberGenerator");

                p.Property(r => r.PolicyNumber).ValueGeneratedNever();
            });

            modelBuilder.Entity<PolicyStatus>().ToTable("PolicyStatus");
            modelBuilder.Entity<PolicyTemp>().ToTable("PolicyTemp");

            modelBuilder.Entity<Premium>(p =>
            {
                //  Map to the table Premium
                p.ToTable("Premium");

                //  Set the database number storage format for the column
                p.Property(r => r.Amount).HasColumnType("decimal(18,2)");
                p.Property(r => r.PolicyFee).HasColumnType("decimal(18,2)");
                p.Property(r => r.Commission).HasColumnType("decimal(18,2)");
                p.Property(r => r.AdminFee).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<PremiumRefund>(p =>
            {
                //  Map to the table PremiumRefund
                p.ToTable("PremiumRefund");

                //  Set the database number storage format for the column
                p.Property(r => r.Amount).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<PremiumTemp>(p =>
            {
                //  Map to the table PremiumTemp
                p.ToTable("PremiumTemp");

                //  Set the database number storage format for the column
                p.Property(r => r.Amount).HasColumnType("decimal(18,2)");
                p.Property(r => r.PaymentAmount).HasColumnType("decimal(18,2)");
                p.Property(r => r.PolicyFee).HasColumnType("decimal(18,2)");
                p.Property(r => r.Commission).HasColumnType("decimal(18,2)");
                p.Property(r => r.AdminFee).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<PremiumType>().ToTable("PremiumType");

            modelBuilder.Entity<Product>().ToTable("Product");

            modelBuilder.Entity<ProductClient>(p =>
            {
                //  Map to the ProductClient table
                p.ToTable("ProductClient");

                // Composite primary key consisting of the ProductID and ClientID
                p.HasKey(r => new { r.ProductID, r.ClientID }).HasName("PK_ProductClient");
            });

            modelBuilder.Entity<ProductRisk>(p =>
            {
                //   Map to the table ProductRisk
                p.ToTable("ProductRisk");

                //  Set the database number storage format for the column
                p.Property(r => r.ClaimLimit).HasColumnType("decimal(18,2)");
                p.Property(r => r.PolicyFee).HasColumnType("decimal(18,2)");
                p.Property(r => r.Commission).HasColumnType("decimal(18,2)");
                p.Property(r => r.AdminFee).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<ProductRiskBenefit>().ToTable("ProductRiskBenefit");

            modelBuilder.Entity<Property>(p =>
            {
                //  Map to the table Property
                p.ToTable("Property");

                //  Set the database number storage format for the column
                p.Property(r => r.Value).HasColumnType("decimal(18,2)");
                p.Property(r => r.Premium).HasColumnType("decimal(18,2)");
                p.Property(r => r.PolicyFee).HasColumnType("decimal(18,2)");
                p.Property(r => r.Commission).HasColumnType("decimal(18,2)");
                p.Property(r => r.InsurerFee).HasColumnType("decimal(18,2)");
                p.Property(r => r.AdminFee).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<PropertyHistory>(p =>
            {
                //  Map to the table PropertyHistory
                p.ToTable("PropertyHistory");

                //  Set the database number storage format for the column
                p.Property(r => r.Value).HasColumnType("decimal(18,2)");
                p.Property(r => r.Premium).HasColumnType("decimal(18,2)");
                p.Property(r => r.PolicyFee).HasColumnType("decimal(18,2)");
                p.Property(r => r.Commission).HasColumnType("decimal(18,2)");
                p.Property(r => r.InsurerFee).HasColumnType("decimal(18,2)");
                p.Property(r => r.AdminFee).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Province>().ToTable("Province");

            modelBuilder.Entity<Receivable>(p =>
            {
                //  Map to the Receivable table
                p.ToTable("Receivable");

                // Index for Reference to allow efficient lookups
                p.HasIndex(r => r.Reference).IsUnique().HasName("IX_ReceivableReference");

                //  Set the database number storage format for the column
                p.Property(r => r.Amount).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Region>().ToTable("Region");
            modelBuilder.Entity<Repairer>().ToTable("Repairer");
            modelBuilder.Entity<ResidenceType>().ToTable("ResidenceType");
            
            modelBuilder.Entity<Risk>(p =>
            {
                //  Map to the table Risk
                p.ToTable("Risk");
            });

            modelBuilder.Entity<RiskClaimClass>(p =>
            {
                //  Map to the RiskClaimClass table
                p.ToTable("RiskClaimClass");

                // Composite primary key consisting of the RiskID and ClaimClassID
                p.HasKey(r => new { r.RiskID, r.ClaimClassID }).HasName("PK_RiskClaimClass");
            });

            modelBuilder.Entity<RiskClaimDocument>(p =>
            {
                //  Map to the RiskClaimDocument table
                p.ToTable("RiskClaimDocument");

                // Composite primary key consisting of the RiskID and ClaimDocumentID
                p.HasKey(r => new { r.RiskID, r.ClaimDocumentID }).HasName("PK_RiskClaimDocument");
            });

            modelBuilder.Entity<RiskIncident>(p =>
            {
                //  Map to the RiskIncident table
                p.ToTable("RiskIncident");

                // Composite primary key consisting of the RiskID and IncidentID
                p.HasKey(r => new { r.RiskID, r.IncidentID }).HasName("PK_RiskIncident");
            });

            modelBuilder.Entity<RoofType>().ToTable("RoofType");
            modelBuilder.Entity<ThirdParty>().ToTable("ThirdParty");
            modelBuilder.Entity<Title>().ToTable("Title");
            modelBuilder.Entity<TracingAgent>().ToTable("TracingAgent");
            modelBuilder.Entity<TransactionType>().ToTable("TransactionType");
            modelBuilder.Entity<WallType>().ToTable("WallType");
        }
    }
}
