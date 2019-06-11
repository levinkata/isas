using Isas.Data;
using Isas.Models;
using Isas.Models.InsurerViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Isas.Controllers
{
    // [Authorize(Roles = "Administrator, Manager")] Commented out by Levi Nkata 24/04/2019 until roles are
    //  defined for users
    public class ProductsController : Controller
    {
        private readonly InsurerDbContext _context;

        public ProductsController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: Products
        public async Task<IActionResult> Index(Guid containerId)
        {
            var products = from p in _context.Products
                           .Include(p => p.Container)
                           .AsNoTracking()
                           .OrderBy(n => n.Name)
                           .Where(c => c.ContainerID == containerId)
                           select p;

            ProductsViewModel viewModel = new ProductsViewModel
            {
                ContainerID = containerId,
                ContainerName = ContainerName(containerId),
                Products = await products.AsNoTracking().ToListAsync()
            };
            return View(viewModel);
        }

        // GET: Products/ProductRequisitions
        public async Task<IActionResult> Authorise(Guid productId)
        {
            var authorised = await (_context.ClaimTransactions
                        .Include(c => c.Account)
                        .Include(c => c.Affected)
                        .Include(c => c.Claim)
                        .Include(c => c.Payee)
                        .Include(c => c.TransactionType)
                        .AsNoTracking()
                        .Where(p => // p.Claim.Policy.ProductID == productId &&
                        p.Authorised == true && p.PassForPayment == 0)
                        .OrderBy(t => t.TransactionNumber)
                        .OrderBy(c => c.InvoiceDate)).ToListAsync();

            var unauthorised = await (_context.ClaimTransactions
                                    .Include(c => c.Account)
                                    .Include(c => c.Affected)
                                    .Include(c => c.Claim)
                                    .Include(c => c.Payee)
                                    .Include(c => c.TransactionType)
                                    .AsNoTracking()
                                    .Where(p => // p.Claim.Policy.ProductID == productId &&
                                    p.Authorised == false && p.PassForPayment == 0)
                                    .OrderBy(t => t.TransactionNumber)
                                    .OrderBy(c => c.InvoiceDate)).ToListAsync();

            AuthoriseViewModel viewModel = new AuthoriseViewModel()
            {
                ProductID = productId,
                ProductName = ProductName(productId),
                Authorised = authorised,
                UnAuthorised = unauthorised
            };
            return View(viewModel);
        }

        public async Task<IActionResult> SetAuthorise(Guid productId, Guid Id, bool authorised)
        {
            Guid _productId = productId;
            bool authValue = authorised ? false : true;
            var userId = authValue ? this.User.FindFirstValue(ClaimTypes.NameIdentifier) : null;
            var myParams = new object[] { authValue, userId, Id };

            await _context.Database.ExecuteSqlCommandAsync(
                "UPDATE ClaimTransaction SET Authorised = {0}, AuthoriserID = {1} WHERE ID = {2}",
                parameters: myParams);
            return RedirectToAction("Authorise", new { productId = _productId });
        }
        
        public async Task<IActionResult> ProductRisks(Guid productId)
        {
            var productrisks = await (from r in _context.ProductRisks
                           .Where(r => r.ProductID == productId)
                           .Include(p => p.Risk)
                           .AsNoTracking()
                           orderby r.Risk.Name
                           select r).ToListAsync();

            ProductRisksViewModel viewModel = new ProductRisksViewModel
            {
                ProductID = productId,
                ProductName = ProductName(productId),
                ProductRisks = productrisks
            };

            return View(viewModel);
        }

        // GET: Products/EditProductRisk/5
        public async Task<IActionResult> EditProductRisk(Guid? id)
        {
            var productrisk = await _context.ProductRisks
                                    .Include(r => r.Risk)
                                    .SingleOrDefaultAsync(m => m.ID == id);
            ProductRiskViewModel viewModel = new ProductRiskViewModel
            {
                ProductRisk = productrisk
            };

            return View(viewModel);
        }

        // POST: Products/EditProductRisk/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProductRisk(ProductRiskViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                ProductRisk productrisk = new ProductRisk();
                productrisk = viewModel.ProductRisk;

                try
                {
                    _context.Update(productrisk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(viewModel.ProductRisk.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("ProductRisks", new { productId = viewModel.ProductRisk.ProductID });
            }
            return View(viewModel);
        }

        public async Task<IActionResult> ProductRiskBenefits(Guid productId, Guid productriskId)
        {
            ViewData["ProductID"] = productId;
            ViewData["ProductName"] = ProductName(productId);
            ViewData["ProductRiskID"] = productriskId;

            var risks = await _context.ProductRiskBenefits
                                    .Where(r => r.ProductRiskID == productriskId)
                                    .Include(c => c.ProductRisk)
                                        .ThenInclude(r => r.Risk)
                                    .AsNoTracking()
                                    .OrderBy(c => c.Benefit)
                                    .ToListAsync();

            return View(risks.ToList());
        }

        // GET: Claims
        public async Task<IActionResult> ProductClaims(Guid productId)
        {
            var claims = await (from c in _context.Claims
                            .Include(p => p.Policy)
                            .Include(c => c.ClaimClass)
                            .Include(c => c.ClaimStatus)
                            .Include(c => c.Incident)
                            .Include(c => c.Region)
                            .OrderBy(r => r.ClaimNumber)
                            .AsNoTracking()
                            //.Where(p => p.Policy.ProductID == productId)
                         select c).ToListAsync();

            ProductClaimsViewModel viewModel = new ProductClaimsViewModel
            {
                ProductID =productId,
                ProductName = ProductName(productId),
                Claims = claims
            };
            return View(viewModel);
        }

        public async Task<IActionResult> ProductClients(Guid productId, string sortOrder,
            string currentFilter, string searchString, int? page)
        {
            ViewData["ProductID"] = productId;
            ViewData["ProductName"] = ProductName(productId);
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;

            var clients = from c in _context.ProductClients
                          .Where(c => c.ProductID == productId)
                          .Include(c => c.Client)
                          select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                clients = clients.Where(c => c.Client.LastName.Contains(searchString)
                                    || c.Client.FirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    clients = clients.OrderByDescending(c => c.Client.LastName);
                    break;
                default:
                    clients = clients.OrderBy(c => c.Client.LastName);
                    break;
            }
            int pageSize = 10;
            return View(await PaginatedList<ProductClient>.CreateAsync
                (clients.AsNoTracking(), page ?? 1, pageSize));
        }

        public async Task<ActionResult> Board(Guid Id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(m => m.ID == Id);

            ProductViewModel viewModel = new ProductViewModel
            {
                ContainerID = product.ContainerID,
                ContainerName = ContainerName(product.ContainerID),
                Product = product
                
            };
            return View(viewModel);
        }

        public async Task<ActionResult> SelectLoadFormat(Guid productId)
        {
            LoadFormatsViewModel viewModel = new LoadFormatsViewModel
            {
                ProductID = productId,
                ProductName = ProductName(productId),
                LoadFormats = await _context.LoadFormats.AsNoTracking().Where(m => m.ProductID == productId).ToListAsync()
            };
            return View(viewModel);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.SingleOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create(Guid containerId)
        {
            ProductViewModel viewModel = new ProductViewModel
            {
                ContainerID = containerId,
                ContainerName = ContainerName(containerId)
            };

            return View(viewModel);
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product();
                product = viewModel.Product;

                product.ID = Guid.NewGuid();
                product.ContainerID = viewModel.ContainerID;
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { containerid = viewModel.ContainerID });
            }
            return View(viewModel);
        }

        // GET: Products/CreateProductRisk
        public async Task<IActionResult> CreateProductRisk(Guid productId)
        {
            var productrisk = new ProductRisk
            {
                ProductID = productId
            };

            ProductRiskViewModel viewModel = new ProductRiskViewModel
            {
                ProductRisk = productrisk,
                RiskList = new SelectList(await (from c in _context.Risks
                                                 where !_context.ProductRisks.Any(p => (p.RiskID == c.ID) && (p.ProductID == productId))
                                                 select c).ToListAsync(), "ID", "Name")
            };
            return View(viewModel);
        }

        // POST: Products/CreateProductRisk
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProductRisk(ProductRiskViewModel viewModel)
        {
            var currentClaimPrefix = viewModel.ProductRisk.ClaimPrefix;
            var productId = viewModel.ProductRisk.ProductID;
            var riskId = viewModel.ProductRisk.RiskID;

            try
            {
                if (ModelState.IsValid)
                {
                    ProductRisk productrisk = viewModel.ProductRisk;
                    productrisk.ID = Guid.NewGuid();
                    _context.Add(productrisk);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("ProductRisks", new { productid = productId });
                }
            }
            catch (DbUpdateException ex)
            {
                var errorMsg = ex.InnerException.Message.ToString();

                viewModel.ErrMsg = errorMsg;

                if (errorMsg.Contains("IX_ProductRisk_ClaimPrefix"))
                    viewModel.ErrMsg = $"Duplicate Claim Prefix {currentClaimPrefix} exists.";

                ModelState.AddModelError(string.Empty, viewModel.ErrMsg);
            }

            viewModel.RiskList = new SelectList(await (from c in _context.Risks
                                                       where !_context.ProductRisks.Any(p => (p.RiskID == c.ID) &&
                                                       (p.ProductID == productId))
                                                       select c).ToListAsync(), "ID", "Name", riskId);
            return View(viewModel);
        }

        // GET: Products/CreateProductRiskBenefit
        public IActionResult CreateProductRiskBenefit(Guid productId, Guid productRiskId)
        {
            ProductRiskBenefit productriskbenefit = new ProductRiskBenefit
            {
                ProductRiskID = productRiskId
            };
            ProductRiskBenefitViewModel viewModel = new ProductRiskBenefitViewModel
            {
                ProductID = productId,
                ProductRiskBenefit = productriskbenefit
            };
            return View(viewModel);
        }

        // POST: Products/CreateProductRiskBenefit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProductRiskBenefit(ProductRiskBenefitViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                ProductRiskBenefit productriskbenefit = new ProductRiskBenefit();
                productriskbenefit = viewModel.ProductRiskBenefit;
                productriskbenefit.ID = Guid.NewGuid();
                _context.Add(productriskbenefit);
                await _context.SaveChangesAsync();
                return RedirectToAction("ProductRiskBenefits", new { productId = viewModel.ProductID,
                                            productriskId = viewModel.ProductRiskBenefit.ProductRiskID });
            }
            return View(viewModel);
        }

        // GET: Products/BulkProductClient
        public IActionResult BulkProductClient(Guid productId, Guid loadFormatId, UploadFileTypes uploadFileType, string delimiter)
        {
            UpLoadViewModel viewModel = new UpLoadViewModel
            {
                ProductID = productId,
                LoadFormatID = loadFormatId,
                UploadFileType = uploadFileType,
                Delimiter = delimiter,
                TableName = "Client"
            };
            return View(viewModel);
        }

        // POST: Products/BulkProductClient
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BulkProductClient(UpLoadViewModel viewModel)
        {
            Guid currentproductId = viewModel.ProductID;
            Guid currentUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            int startRow = viewModel.StartRow;

            string FirstNamePos = string.Empty;
            string LastNamePos = string.Empty;
            string IDNumberPos = string.Empty;
            string BirthDatePos = string.Empty;
            string TitlePos = string.Empty;
            string GenderPos = string.Empty;
            string OccupationPos = string.Empty;
            string CountryPos = string.Empty;

            //  Uncomment/comment the below if residue data was not deleted in the ClientTemp table.

            Guid myParam = currentUserId;
            await _context.Database.ExecuteSqlCommandAsync(
                                    "DELETE FROM ClientTemp WHERE UserID = {0}",
                                    parameters: myParam);

            var formattypes = _context.FormatTypes
                                .Where(l => l.LoadFormatID == viewModel.LoadFormatID &&
                                l.TableName == viewModel.TableName)
                                .ToList();

            foreach(var row in formattypes)
            {
                switch (row.FieldName)
                {
                    case "IDNumber":
                        IDNumberPos = row.Position;
                        break;
                    case "FirstName":
                        FirstNamePos = row.Position;
                        break;
                    case "LastName":
                        LastNamePos = row.Position;
                        break;
                    case "BirthDate":
                        BirthDatePos = row.Position;
                        break;
                    case "Title":
                        TitlePos = row.Position;
                        break;
                    case "Gender":
                        GenderPos = row.Position;
                        break;
                    case "Occupation":
                        OccupationPos = row.Position;
                        break;
                    case "Country":
                        CountryPos = row.Position;
                        break;
                    case "default":
                        break;
                }
            }

            IFormFile uploadFile = viewModel.UpLoadFile;
            IList<ClientTemp> ClientTemps = new List<ClientTemp>();

            using (MemoryStream ms = new MemoryStream())
            {
                await uploadFile.CopyToAsync(ms);
                try
                {
                    if (viewModel.UploadFileType == UploadFileTypes.Excel)
                    {
                        using (OfficeOpenXml.ExcelPackage package = new OfficeOpenXml.ExcelPackage(ms))
                        {
                            ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                            int rowCount = worksheet.Dimension.Rows;

                            for (int row = startRow; row <= rowCount; row++)
                            {
                                ClientTemp clienttemp = new ClientTemp
                                {
                                    UserID = currentUserId,
                                    ProductID = currentproductId
                                };

                                if (worksheet.Cells[IDNumberPos + row].Value != null && IDNumberPos != null)
                                    clienttemp.IDNumber = worksheet.Cells[IDNumberPos + row].Value.ToString().Trim();
                                else
                                    break;

                                if (worksheet.Cells[LastNamePos + row].Value != null && LastNamePos != null)
                                    clienttemp.LastName = ProperCase.ToProperCase(worksheet.Cells[LastNamePos + row].Value.ToString().Trim());
                                else
                                    clienttemp.LastName = string.Empty;

                                if (worksheet.Cells[FirstNamePos + row].Value != null && FirstNamePos != null)
                                    clienttemp.FirstName = ProperCase.ToProperCase(worksheet.Cells[FirstNamePos + row].Value.ToString().Trim());
                                else
                                    clienttemp.FirstName = string.Empty;

                                if (worksheet.Cells[BirthDatePos + row].Value != null && BirthDatePos != null)
                                {
                                    var birthdate = worksheet.Cells[BirthDatePos + row].Value.ToString().Trim();
                                    DateTime dt = Convert.ToDateTime(birthdate);
                                    clienttemp.BirthDate = dt;
                                }
                                else
                                    clienttemp.BirthDate = null;

                                if (worksheet.Cells[GenderPos + row].Value != null && GenderPos != null)
                                {
                                    var gender = worksheet.Cells[GenderPos + row].Value.ToString().Trim();
                                    clienttemp.Gender = (gender == "M" || gender == "Male") ? Gender.Male : Gender.Female;
                                }
                                else
                                    clienttemp.Gender = Gender.Unspecified;

                                if (worksheet.Cells[OccupationPos + row].Value != null && OccupationPos != null)
                                {
                                    var occupation = worksheet.Cells[OccupationPos + row].Value.ToString().Trim();
                                    clienttemp.OccupationID = (occupation != null) ? GetOccupationId(occupation) :
                                                                                    GetOccupationId("NotApplicable");
                                }
                                else
                                    clienttemp.OccupationID = GetOccupationId("NotApplicable");

                                if (worksheet.Cells[TitlePos + row].Value != null && TitlePos != null)
                                {
                                    var title = worksheet.Cells[TitlePos + row].Value.ToString().Trim();
                                    clienttemp.TitleID = (title != null) ? GetTitleId(title) :
                                                                        GetTitleId("NotApplicable");
                                }
                                else
                                    clienttemp.TitleID = GetTitleId("NotApplicable");

                                if (worksheet.Cells[CountryPos + row].Value != null && CountryPos != null)
                                {
                                    var country = worksheet.Cells[CountryPos + row].Value.ToString().Trim();
                                    clienttemp.CountryID = (country != null) ? GetCountryId(country) :
                                                                            GetCountryId("NotApplicable");
                                }
                                else
                                    clienttemp.CountryID = GetCountryId("NotApplicable");

                                ClientTemps.Add(clienttemp);
                            }
                        }
                    }
                    else if (viewModel.UploadFileType == UploadFileTypes.CSV)
                    {
                        char[] delimiter = viewModel.Delimiter.ToCharArray(); // Get Delimiter

                        using (StreamReader sr = new StreamReader(uploadFile.OpenReadStream()))
                        {
                            string line = string.Empty;

                            //  Skip rows to where valid data row starts
                            if (startRow  > 0)
                                for (int i = 0; i < startRow - 1; i++)
                                    sr.ReadLine();

                            while ((line = sr.ReadLine()) != null)
                            {
                                ClientTemp clienttemp = new ClientTemp
                                {
                                    UserID = currentUserId,
                                    ProductID = currentproductId
                                };

                                string[] cols = line.Split(delimiter);

                                if (cols[int.Parse(IDNumberPos)] != null && IDNumberPos != null)
                                    clienttemp.IDNumber = cols[int.Parse(IDNumberPos)];
                                else
                                    break;

                                if (cols[int.Parse(LastNamePos)] != null && LastNamePos != null)
                                    clienttemp.LastName = ProperCase.ToProperCase(cols[int.Parse(LastNamePos)]);
                                else
                                    clienttemp.LastName = string.Empty;

                                if (cols[int.Parse(FirstNamePos)] != null && FirstNamePos != null)
                                    clienttemp.FirstName = ProperCase.ToProperCase(cols[int.Parse(FirstNamePos)]);
                                else
                                    clienttemp.FirstName = string.Empty;

                                if (cols[int.Parse(BirthDatePos)] != null && BirthDatePos != null)
                                {
                                    var birthdate = cols[int.Parse(BirthDatePos)];
                                    DateTime dt = Convert.ToDateTime(birthdate);
                                    clienttemp.BirthDate = dt;
                                }
                                else
                                    clienttemp.BirthDate = null;

                                if (cols[int.Parse(GenderPos)] != null && GenderPos != null)
                                {
                                    var gender = cols[int.Parse(GenderPos)];
                                    clienttemp.Gender = (gender == "M" || gender == "Male") ? Gender.Male : Gender.Female;
                                }
                                else
                                    clienttemp.Gender = Gender.Unspecified;

                                if (cols[int.Parse(OccupationPos)] != null && OccupationPos != null)
                                {
                                    var occupation = cols[int.Parse(OccupationPos)];
                                    clienttemp.OccupationID = (occupation != null) ? GetOccupationId(occupation) :
                                                                                    GetOccupationId("NotApplicable");
                                }
                                else
                                    clienttemp.OccupationID = GetOccupationId("NotApplicable");

                                if (cols[int.Parse(TitlePos)] != null && TitlePos != null)
                                {
                                    var title = cols[int.Parse(TitlePos)];
                                    clienttemp.TitleID = (title != null) ? GetTitleId(title) :
                                                                        GetTitleId("NotApplicable");
                                }
                                else
                                    clienttemp.TitleID = GetTitleId("NotApplicable");

                                if (cols[int.Parse(CountryPos)] != null && CountryPos != null)
                                {
                                    var country = cols[int.Parse(CountryPos)];
                                    clienttemp.CountryID = (country != null) ? GetCountryId(country) :
                                                                            GetCountryId("NotApplicable");
                                }
                                else
                                    clienttemp.CountryID = GetCountryId("NotApplicable");

                                ClientTemps.Add(clienttemp);
                            }
                        }
                    }
                    else if (viewModel.UploadFileType == UploadFileTypes.FixedLengthDelimited)
                    {
                        int FirstNameLen = 0;
                        int LastNameLen = 0;
                        int IDNumberLen = 0;
                        int BirthDateLen = 0;
                        int TitleLen = 0;
                        int GenderLen = 0;
                        int OccupationLen = 0;
                        int CountryLen = 0;

                        foreach (var row in formattypes)
                        {
                            switch (row.FieldName)
                            {
                                case "IDNumber":
                                    IDNumberLen = row.ColumnLength;
                                    break;
                                case "FirstName":
                                    FirstNameLen = row.ColumnLength;
                                    break;
                                case "LastName":
                                    LastNameLen = row.ColumnLength;
                                    break;
                                case "BirthDate":
                                    BirthDateLen = row.ColumnLength;
                                    break;
                                case "Title":
                                    TitleLen = row.ColumnLength;
                                    break;
                                case "Gender":
                                    GenderLen = row.ColumnLength;
                                    break;
                                case "Occupation":
                                    OccupationLen = row.ColumnLength;
                                    break;
                                case "Country":
                                    CountryLen = row.ColumnLength;
                                    break;
                                case "default":
                                    break;
                            }
                        }

                        using (StreamReader sr = new StreamReader(uploadFile.OpenReadStream()))
                        {
                            string line = string.Empty;

                            //  Skip rows to where valid data row starts
                            if (startRow > 0)
                                for (int i = 0; i < startRow - 1; i++)
                                    sr.ReadLine();

                            while ((line = sr.ReadLine()) != null)
                            {
                                ClientTemp clienttemp = new ClientTemp
                                {
                                    UserID = currentUserId,
                                    ProductID = currentproductId
                                };

                                if (line.Substring(int.Parse(IDNumberPos), IDNumberLen) != null && IDNumberPos != null)
                                    clienttemp.IDNumber = line.Substring(int.Parse(IDNumberPos), IDNumberLen);
                                else
                                    break;

                                if (line.Substring(int.Parse(LastNamePos), LastNameLen) != null && LastNamePos != null)
                                    clienttemp.LastName = ProperCase.ToProperCase(line.Substring(int.Parse(LastNamePos), LastNameLen));
                                else
                                    clienttemp.LastName = string.Empty;

                                if (line.Substring(int.Parse(FirstNamePos), FirstNameLen) != null && FirstNamePos != null)
                                    clienttemp.FirstName = ProperCase.ToProperCase(line.Substring(int.Parse(FirstNamePos), FirstNameLen));
                                else
                                    clienttemp.FirstName = string.Empty;

                                if (line.Substring(int.Parse(BirthDatePos), BirthDateLen) != null && BirthDatePos != null)
                                {
                                    var birthdate = line.Substring(int.Parse(BirthDatePos), BirthDateLen);
                                    DateTime dt = Convert.ToDateTime(birthdate);
                                    clienttemp.BirthDate = dt;
                                }
                                else
                                    clienttemp.BirthDate = null;

                                if (line.Substring(int.Parse(GenderPos), GenderLen) != null && GenderPos != null)
                                {
                                    var gender = line.Substring(int.Parse(GenderPos), GenderLen);
                                    clienttemp.Gender = (gender == "M" || gender == "Male") ? Gender.Male : Gender.Female;
                                }
                                else
                                    clienttemp.Gender = Gender.Unspecified;


                                if (line.Substring(int.Parse(OccupationPos), OccupationLen) != null && OccupationPos != null)
                                {
                                    var occupation = line.Substring(int.Parse(OccupationPos), OccupationLen);
                                    clienttemp.OccupationID = (occupation != null) ? GetOccupationId(occupation) :
                                                                                    GetOccupationId("NotApplicable");
                                }
                                else
                                    clienttemp.OccupationID = GetOccupationId("NotApplicable");

                                if (line.Substring(int.Parse(TitlePos), TitleLen) != null && TitlePos != null)
                                {
                                    var title = line.Substring(int.Parse(TitlePos), TitleLen);
                                    clienttemp.TitleID = (title != null) ? GetTitleId(title) :
                                                                        GetTitleId("NotApplicable");
                                }
                                else
                                    clienttemp.TitleID = GetTitleId("NotApplicable");

                                if (line.Substring(int.Parse(CountryPos), CountryLen) != null && CountryPos != null)
                                {
                                    var country = line.Substring(int.Parse(CountryPos), CountryLen);
                                    clienttemp.CountryID = (country != null) ? GetCountryId(country) :
                                                                            GetCountryId("NotApplicable");
                                }
                                else
                                    clienttemp.CountryID = GetCountryId("NotApplicable");

                                ClientTemps.Add(clienttemp);
                            }
                        }
                    }
                    ms.Flush();
                    ViewData["Message"] = "The records are all the data that has been successfully uploaded from the input file." + "\n" +
                                          "You can proceed to load them to the database.";

                    foreach (ClientTemp c in ClientTemps)
                    {
                        _context.ClientTemps.Add(c);
                    }
                    _context.SaveChanges();

                    return RedirectToAction("LoadClients", new { userId = currentUserId,
                                                        productId = currentproductId });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Some error occured while exporting. ", ex.Message);
                }
                ms.Flush();
            }
            return View();
        }

        // GET: Products/LoadClients
        public async Task<IActionResult> LoadClients (Guid userId, Guid productId)
        {
            var clienttemps = await (from c in _context.ClientTemps
                                   .Where(u => u.UserID == userId)
                                   .Include(c => c.Country)
                                   .Include(o => o.Occupation)
                                   .Include(t => t.Title)
                                   .OrderBy(c => c.LastName)
                                   select c).ToListAsync();

            ClientTempsViewModel viewModel = new ClientTempsViewModel
            {
                ClientTemps = clienttemps,
                ProductID = productId,
                UserID = userId
            };

            return View(viewModel);
        }

        // GET: Products/LoadClientsConfirmed
        [HttpPost, ActionName("LoadClients")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoadClientsConfirmed(ClientTempsViewModel viewModel)
        {
            Guid currentUserId = viewModel.UserID;
            Guid currentproductId = viewModel.ProductID;
            Guid currentClientId;

            BulkHandles bulkhandle = new BulkHandles();

            int newbulkhandle = bulkhandle.GetBulkHandle(_context);

            var clienttemps = from c in _context.ClientTemps
                                  .Where(u => u.UserID == currentUserId)
                                  .Include(c => c.Country)
                                  .Include(o => o.Occupation)
                                  .Include(t => t.Title)
                                  .OrderBy(c => c.LastName)
                                    select c;

            int recCount = clienttemps.Count();

            foreach (var c in clienttemps)
            {
                Client client = new Client();
                ProductClient productclient = new ProductClient();
                
                if (!ClientExists(c.IDNumber))
                {
                    var clientParams = new object[] { Guid.NewGuid(), _context.ClientTypes.Single(n => n.IsFirm == false).ID,
                                        GetTitleId("NotApplicable"), c.FirstName, c.LastName, c.BirthDate, c.Gender,
                                        c.IDNumber, c.OccupationID, c.CountryID, 3, 0, newbulkhandle, currentUserId, DateTime.Now, null, null };

                    await _context.Database.ExecuteSqlCommandAsync(
                                            "INSERT INTO Client(ID, ClientTypeID, TitleID, FirstName, LastName, " +
                                            "BirthDate, Gender, IDNumber, OccupationID, CountryID, PayeeClassID, Payable, BulkHandle, AddedBy, DateAdded, ModifiedBy, DateModified) " +
                                            "Values ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16})",
                                            parameters: clientParams);
                }
                else
                {
                    //  Generate a log file
                }

                currentClientId = _context.Clients.Single(i => i.IDNumber == c.IDNumber).ID;

                var productclientParams = new object[] { currentproductId, currentClientId };

                await _context.Database.ExecuteSqlCommandAsync(
                                        "INSERT INTO ProductClient(ProductID, ClientID) " +
                                        "Values ({0}, {1})",
                                        parameters: productclientParams);
            }

            Guid myParam = currentUserId;
            await _context.Database.ExecuteSqlCommandAsync(
                                    "DELETE FROM ClientTemp WHERE UserID = {0}",
                                    parameters: myParam);

            var bulkParams = new object[] { newbulkhandle, "Client", DateTime.Now, recCount, DateTime.Now, currentUserId };

            await _context.Database.ExecuteSqlCommandAsync(
                                    "INSERT INTO BulkHandleGenerator(BulkNumber, TableName, BulkDate, RecordCount, DateAdded, AddedBy) " +
                                    "Values ({0}, {1}, {2}, {3}, {4}, {5})",
                                    parameters: bulkParams);

            return RedirectToAction("ProductClients", new { productId = currentproductId });
        }

        // GET: Products/CreateProductClient
        public async Task<IActionResult> CreateProductClient(
            Guid productId, string searchString, int? page, int onproduct)
        {
            ViewData["ProductID"] = productId;
            ViewData["CheckOnProduct"] = onproduct;
            ViewData["ProductMessage"] = "";

            if (searchString != null)
            {
                page = 1;
            }
            
            ViewData["currentFilter"] = searchString;

            var clients = from c in _context.Clients
                              .AsNoTracking()
                              .OrderBy(r => r.LastName)
                            where !_context.ProductClients.Any(p => (p.ClientID == c.ID) &&
                                    (p.ProductID == productId))
                            select c;
            
            if (!String.IsNullOrEmpty(searchString) && (onproduct == 0))
            {
                clients = clients.Where(c => c.LastName.Contains(searchString)
                                    || c.FirstName.Contains(searchString));
            }
            else if (!String.IsNullOrEmpty(searchString) && (onproduct == 1))
            {
                clients = from c in _context.Clients
                          .OrderBy(r => r.LastName)
                          .Where(c => c.LastName.Contains(searchString) || c.FirstName.Contains(searchString))
                          where _context.ProductClients.Any(p => (p.ClientID == c.ID) && (p.ProductID == productId))
                              select c;
                if (clients.Count() > 0)
                {
                    ViewData["Message"] = "Clients on product matching selection";
                }
            }
            int pageSize = 10;
            return View(await PaginatedList<Client>.CreateAsync
                (clients.AsNoTracking(), page ?? 1, pageSize));
        }

        public async Task<IActionResult> AddClient(Guid productId, Guid clientId )
        {
            HttpContext.Session.SetString("ProductID", productId.ToString());

            var client = await _context.Clients.SingleOrDefaultAsync(c => c.ID == clientId);

            return View(client);
        }

        [HttpPost, ActionName("AddClient")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostClient(Guid productId, Guid clientId)
        {
            ProductClient productclient = new ProductClient
            {
                ProductID = productId,
                ClientID = clientId
            };
            var client = await _context.Clients.SingleOrDefaultAsync(m => m.ID == clientId);
            if (ModelState.IsValid)
            {
                _context.Add(productclient);
                await _context.SaveChangesAsync();
                ViewData["RecordAdded"] = "1";
            }
            return View(client);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }
            ProductViewModel viewModel = new ProductViewModel
            {
                Product = product
            };

            return View(viewModel);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product();
                product = viewModel.Product;

                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", new { containerId = product.ContainerID });
            }
            return View(viewModel);
        }

        // GET: Products/DeleteProductRisk/5
        public async Task<IActionResult> DeleteProductRisk(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productrisk = await _context.ProductRisks.Include(r => r.Risk).SingleOrDefaultAsync(m => m.ID == id);
            if (productrisk == null)
            {
                return NotFound();
            }

            return View(productrisk);
        }

        // POST: Products/DeleteProductRisk/5
        [HttpPost, ActionName("DeleteProductRisk")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProductRiskConfirmed(Guid id)
        {
            var productrisk = await _context.ProductRisks.SingleOrDefaultAsync(m => m.ID == id);
            _context.ProductRisks.Remove(productrisk);
            await _context.SaveChangesAsync();
            return RedirectToAction("ProductRisks", new { productid = productrisk.ProductID });
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.SingleOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(m => m.ID == id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { containerId = product.ContainerID });
        }

        // GET: Products/DeleteProductClient/5
        public async Task<IActionResult> DeleteProductClient(Guid productId, Guid clientId)
        {
            var productclient = await _context.ProductClients
                                    .Include(c => c.Client)
                                    .SingleOrDefaultAsync(p => p.ProductID == productId &&
                                                            p.ClientID == clientId);
            return View(productclient);
        }

        // POST: Products/DeleteProductClient/5
        [HttpPost, ActionName("DeleteProductClient")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProductClientConfirmed(Guid productId, Guid clientId)
        {
            var productclient = await _context.ProductClients
                                    .SingleOrDefaultAsync(p => p.ProductID == productId &&
                                                            p.ClientID == clientId);
            _context.ProductClients.Remove(productclient);
            await _context.SaveChangesAsync();
            return RedirectToAction("ProductClients", new { productId = productclient.ProductID });
        }
        private bool ClaimPrefixExists(int claimPrefix)
        {
            return _context.ProductRisks.Any(c => c.ClaimPrefix == claimPrefix);
        }

        private string ContainerName(Guid containerId)
        {
            return _context.Containers.SingleOrDefault(c => c.ID == containerId).Name;
        }

        private string ProductName(Guid productId)
        {
            return _context.Products.SingleOrDefault(c => c.ID == productId).Name;
        }

        private bool ProductExists(Guid id)
        {
            return _context.Products.Any(e => e.ID == id);
        }

        private Guid GetCountryId(string country)
        {
            return _context.Countries.Any(c => c.Name == country) ?
                    _context.Countries.Single(c => c.Name == country).ID :
                    _context.Countries.Single(c => c.Name == "NotApplicable").ID;
        }

        private Guid GetOccupationId(string occupation)
        {
            return _context.Occupations.Any(o => o.Name == occupation) ?
                    _context.Occupations.Single(o => o.Name == occupation).ID :
                    _context.Occupations.Single(o => o.Name == "NotApplicable").ID;
        }

        private Guid GetTitleId(string title)
        {
            return _context.Titles.Any(t => t.Name == title) ?
                    _context.Titles.Single(t => t.Name == title).ID :
                    _context.Titles.Single(t => t.Name == "NotApplicable").ID;
        }

        private bool ClientExists(string IdNumber)
        {
            return _context.Clients.Any(e => e.IDNumber == IdNumber);
        }
    }
}
