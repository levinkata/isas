using Isas.Data;
using Isas.Models;
using Isas.Models.InsurerViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Syncfusion.EJ.Export;
using Syncfusion.JavaScript;
using Syncfusion.JavaScript.DataSources;
using Syncfusion.JavaScript.Models;
using Syncfusion.Linq;
using Syncfusion.XlsIO;
using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Isas.Controllers
{
    [Authorize]
    public class ClientsController : Controller
    {
        private readonly InsurerDbContext _context;

        public ClientsController(InsurerDbContext context)
        {
            _context = context;
        }

        // GET: Clients
        public async Task<IActionResult> Index(string sortOrder,
            string currentFilter, string searchString, int? page, int payeeClassId)
        {
            ViewData["PayeeClassID"] = payeeClassId;
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["IDSortParm"] = sortOrder == "ID" ? "id_desc" : "ID";
            
            if(searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var clients = from c in _context.Clients
                          select c;

            if(!String.IsNullOrEmpty(searchString))
            {
                clients = clients.Where(c => c.LastName.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0);
                                    //|| c.FirstName.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            switch (sortOrder)
            {
                case "name_desc":
                    clients = clients.OrderByDescending(c => c.LastName);
                    break;
                case "ID":
                    clients = clients.OrderBy(c => c.IDNumber);
                    break;
                case "id_desc":
                    clients = clients.OrderByDescending(c => c.IDNumber);
                    break;
                default:
                    clients = clients.OrderBy(c => c.LastName);
                    break;
            }
            int pageSize = 10;
            return View(await PaginatedList<Client>.CreateAsync(clients.AsNoTracking(), page ?? 1,
                pageSize));
        }

        public ActionResult DataSource(DataManager dm)
        {
            var clients = (from c in _context.Clients
                                             orderby c.LastName
                                             select c).ToList();

            IEnumerable DataSource = clients;

            DataResult result = new DataResult();
            DataOperations operation = new DataOperations();

            if (dm.Sorted != null && dm.Sorted.Count > 0) //Sorting
            {
                DataSource = operation.PerformSorting(DataSource, dm.Sorted);
            }
            
            result.Result = DataSource;
            
            var resCount = clients.Count;

            Expression convertExpr = Expression.Convert(
                            Expression.Constant(resCount),
                            typeof(Int32)
                        );

            int output = Expression.Lambda<Func<Int32>>(convertExpr).Compile()();

            result.Count = output;

            if (dm.Skip > 0)
                result.Result = operation.PerformSkip(result.Result, dm.Skip);

            if (dm.Take > 0)
                result.Result = operation.PerformTake(result.Result, dm.Take);

            return Json(result);
        }

        public class DataResult
        {
            public IEnumerable Result { get; set; }
            public int Count { get; set; }
        }

        public IActionResult Grid(int payeeclassId)
        {
            var clients = (from c in _context.Clients.AsNoTracking()
                            .Include(u => u.Country)
                            .Include(o => o.Occupation)
                           orderby c.LastName
                           select new
                           {
                               ID = c.ID.ToString(),
                               c.LastName,
                               c.FirstName,
                               Gender = c.Gender.ToString(),
                               c.BirthDate,
                               c.IDNumber,
                               Country = c.Country.Name,
                               Occupation = c.Occupation.Name,
                               c.Payable
                           }).ToList();

            ClientsViewModel viewModel = new ClientsViewModel
            {
                Clients = clients,
                PayeeClassID = payeeclassId
            };
            return View(viewModel);
        }

        public IActionResult RefreshData(int payeeclassId)
        {
            var clients = (from c in _context.Clients.AsNoTracking()
                            .Include(u => u.Country)
                            .Include(o => o.Occupation)
                           orderby c.LastName
                           select new
                           {
                               ID = c.ID.ToString(),
                               c.LastName,
                               c.FirstName,
                               Gender = c.Gender.ToString(),
                               c.BirthDate,
                               c.IDNumber,
                               Country = c.Country.Name,
                               Occupation = c.Occupation.Name,
                               c.Payable
                           }).ToList();


            return Json(clients);
        }

        public ActionResult CellEditUpdate([FromBody]CRUDModel<Client> client)
        {
            _context.Update(client.Value);
            _context.SaveChanges();
            return Json(client);
        }

        public ActionResult CellEditInsert([FromBody]CRUDModel<Client> client)
        {
            client.Value.ID = Guid.NewGuid();
            _context.Add(client.Value);
            _context.SaveChanges();
            return Json(client);
        }

        public ActionResult CellEditDelete([FromBody]CRUDModel<Client> client)
        {
            var clienttoremove = _context.Clients.SingleOrDefault(c => c.ID == Guid.Parse(client.Key.ToString()));

            _context.Clients.Remove(clienttoremove);
            _context.SaveChanges();

            return Json(client);
        }

        public ActionResult ExportToExcel(string GridModel)
        {
            ExcelExport exp = new ExcelExport();
            var DataSource = _context.Clients
                                .Include(c => c.Country)
                                .Include(o => o.Occupation).Take(100).ToList();
            GridProperties gridProp = ConvertGridObject(GridModel);
            GridExcelExport excelExp = new GridExcelExport
            {
                FileName = "Export.xlsx",
                Excelversion = ExcelVersion.Excel2010,
                Theme = "flat-saffron"
            };
            return exp.Export(gridProp, DataSource, excelExp);
        }

        public ActionResult ExportToWord(string GridModel)
        {
            WordExport exp = new WordExport();
            var DataSource = _context.Clients
                                .Include(c => c.Country)
                                .Include(o => o.Occupation).Take(100).ToList();
            GridProperties gridProp = ConvertGridObject(GridModel);
            GridWordExport wrdExp = new GridWordExport
            {
                FileName = "Export.docx",
                Theme = "flat-saffron"
            };
            return exp.Export(gridProp, DataSource, wrdExp);
        }

        public ActionResult ExportToPdf(string GridModel)
        {
            PdfExport exp = new PdfExport();
            var DataSource = _context.Clients
                                .Include(c => c.Country)
                                .Include(o => o.Occupation).Take(100).ToList();
            GridProperties gridProp = ConvertGridObject(GridModel);
            GridPdfExport pdfExp = new GridPdfExport
            {
                FileName = "Export.pdf",
                Theme = "flat-saffron"
            };
            return exp.Export(gridProp, DataSource, pdfExp);
        }

        private GridProperties ConvertGridObject(string gridProperty)
        {
            GridProperties gridProp = new GridProperties();
            gridProp = (GridProperties)JsonConvert.DeserializeObject(gridProperty, typeof(GridProperties));
            return gridProp;
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                                .AsNoTracking()
                                .SingleOrDefaultAsync(m => m.ID == id);

            return View(client);
        }

        // GET: Clients/Create
        public async Task<IActionResult> Create(int payeeClassId)
        {
            Client client = new Client
            {
                BirthDate = DateTime.Now,
                PayeeClassID = payeeClassId
            };

            ClientViewModel viewModel = new ClientViewModel
            {
                Client = client,
                ClientTypeList =  new SelectList(await _context.ClientTypes
                                                .OrderBy(c => c.Name)
                                                .AsNoTracking()
                                                .ToListAsync(), "ID", "Name"),
                CountryList =  new SelectList(await _context.Countries
                                                .OrderBy(c => c.Name)
                                                .AsNoTracking()
                                                .ToListAsync(), "ID", "Name"),
                OccupationList = new SelectList(await _context.Occupations
                                                .OrderBy(o => o.Name)
                                                .AsNoTracking()
                                                .ToListAsync(), "ID", "Name"),
                TitleList = new SelectList(await _context.Titles
                                                .OrderBy(t => t.Name)
                                                .AsNoTracking()
                                                .ToListAsync(), "ID", "Name"),
                GenderList = new SelectList(Enum.GetValues(typeof(Gender))
                                                .Cast<Gender>().Select(g => new
                                                                {
                                                                    Text = g.ToString(),
                                                                    Value = g.ToString()
                                                                }).ToList(), "Value", "Text")
            };
            return View(viewModel);
        }

        // POST: Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClientViewModel viewModel)
        {
            var idNumber = viewModel.Client.IDNumber;
            try
            {
                if (ModelState.IsValid)
                {
                    Client client = new Client();
                    client = viewModel.Client;

                    //  Get Client Class is not an organisation or is an individual
                    //  Process: FirstName, Gender, Occupation and Title
                    if (!IsFirm(client.ClientTypeID))
                    {
                        client.BirthDate = DateTime.ParseExact("01/01/1900", "dd'/'MM'/'yyyy",
                                                    CultureInfo.CurrentCulture.DateTimeFormat);
                        client.FirstName = string.Empty;
                        client.Gender = Gender.Unspecified;
                        client.OccupationID = _context.Occupations.Single(o => o.Name == "NotApplicable").ID;
                        client.TitleID = _context.Titles.Single(t => t.Name == "NotApplicable").ID;
                    }
                    client.ID = Guid.NewGuid();
                    _context.Add(client);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", new { payeeclassId = viewModel.Client.PayeeClassID });
                }
            }
            catch (DbUpdateException ex)
            {
                var errorMsg = ex.InnerException.Message.ToString();

                if (errorMsg.Contains("IX_Client_IDNumber"))
                    viewModel.ErrMsg = $"Duplicate ID Number {idNumber} exists.";
                else
                    viewModel.ErrMsg = errorMsg;

                ModelState.AddModelError(string.Empty, viewModel.ErrMsg);
            }

            viewModel.ClientTypeList = new SelectList(await _context.ClientTypes
                                        .OrderBy(c => c.Name)
                                        .AsNoTracking()
                                        .ToListAsync(), "ID", "Name", viewModel.Client.ClientTypeID);
            viewModel.CountryList = new SelectList(await _context.Countries
                                        .OrderBy(c => c.Name)
                                        .AsNoTracking()
                                        .ToListAsync(), "ID", "Name", viewModel.Client.CountryID);
            viewModel.OccupationList = new SelectList(await _context.Occupations
                                            .OrderBy(o => o.Name)
                                            .AsNoTracking()
                                            .ToListAsync(), "ID", "Name", viewModel.Client.OccupationID);
            viewModel.TitleList = new SelectList(await _context.Titles
                                        .OrderBy(t => t.Name)
                                        .AsNoTracking()
                                        .ToListAsync(), "ID", "Name", viewModel.Client.TitleID);
            viewModel.GenderList = new SelectList(Enum.GetValues(typeof(Gender))
                                        .Cast<Gender>().Select(g => new
                                        {
                                            Text = g.ToString(),
                                            Value = g.ToString()
                                        }).ToList(), "Value", "Text", viewModel.Client.Gender);
            return View(viewModel);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(Guid Id)
        {
            ClientViewModel viewModel = new ClientViewModel
            {
                Client = await _context.Clients.SingleOrDefaultAsync(m => m.ID == Id),
                ClientTypeList = new SelectList(await _context.ClientTypes
                                            .OrderBy(c => c.Name)
                                            .AsNoTracking()
                                            .ToListAsync(), "ID", "Name"),
                CountryList = new SelectList(await _context.Countries
                                                .OrderBy(c => c.Name)
                                                .AsNoTracking()
                                                .ToListAsync(), "ID", "Name"),
                OccupationList = new SelectList(await _context.Occupations
                                                .OrderBy(o => o.Name)
                                                .AsNoTracking()
                                                .ToListAsync(), "ID", "Name"),
                TitleList = new SelectList(await _context.Titles
                                                .OrderBy(t => t.Name)
                                                .AsNoTracking()
                                                .ToListAsync(), "ID", "Name"),
                GenderList = new SelectList(Enum.GetValues(typeof(Gender))
                                                .Cast<Gender>().Select(g => new
                                                {
                                                    Text = g.ToString(),
                                                    Value = g.ToString()
                                                }).ToList(), "Value", "Text")
            };
            return View(viewModel);
        }

        // POST: Clients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ClientViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Client client = new Client();
                    client = viewModel.Client;
                    _context.Update(client);
                    await _context.SaveChangesAsync();

                    var FullName = (client.FirstName == null) ? client.LastName : client.FirstName + ' ' + client.LastName;
                    var payeeParams = new object[] { client.ID, FullName };
                    await _context.Database.ExecuteSqlCommandAsync(
                                            "UPDATE Payee SET Name = {0} WHERE PayeeItemID = {1}",
                                            parameters: payeeParams);
                    return RedirectToAction("Index", new { payeeclassId = viewModel.Client.PayeeClassID });
                }
                catch (DbUpdateException ex)
                {
                    var errorMsg = ex.InnerException.Message.ToString();

                    viewModel.ErrMsg = errorMsg;
                    ModelState.AddModelError(string.Empty, viewModel.ErrMsg);
                }
            }
            viewModel.ClientTypeList = new SelectList(await _context.ClientTypes
                                                .OrderBy(c => c.Name)
                                                .AsNoTracking()
                                                .ToListAsync(), "ID", "Name", viewModel.Client.ClientTypeID);
            viewModel.CountryList = new SelectList(await _context.Countries
                                                .OrderBy(c => c.Name)
                                                .AsNoTracking()
                                                .ToListAsync(), "ID", "Name", viewModel.Client.CountryID);
            viewModel.OccupationList = new SelectList(await _context.Occupations
                                                .OrderBy(o => o.Name)
                                                .AsNoTracking()
                                                .ToListAsync(), "ID", "Name", viewModel.Client.OccupationID);
            viewModel.TitleList = new SelectList(await _context.Titles
                                                .OrderBy(t => t.Name)
                                                .AsNoTracking()
                                                .ToListAsync(), "ID", "Name", viewModel.Client.TitleID);
            viewModel.GenderList = new SelectList(Enum.GetValues(typeof(Gender))
                                                .Cast<Gender>().Select(g => new
                                                {
                                                    Text = g.ToString(),
                                                    Value = g.ToString()
                                                }).ToList(), "Value", "Text", viewModel.Client.Gender);
            return View(viewModel);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.SingleOrDefaultAsync(m => m.ID == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var client = await _context.Clients.SingleOrDefaultAsync(m => m.ID == id);
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ClientExists(string idnumber)
        {
            return _context.Clients.Any(e => e.IDNumber == idnumber);
        }

        public IActionResult VerifyIDNumber(string IDNumber)
        {
            if (ClientExists(IDNumber))
            {
                return Json(data: $"IDNumber {IDNumber} already exists.");
            }
            return Json(data: true);
        }

        private bool IsFirm(Guid ClientTypeId)
        {
            return _context.ClientTypes.Single(c => c.ID == ClientTypeId).IsFirm;
        }
    }
}
