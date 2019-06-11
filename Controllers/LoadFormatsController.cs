using Isas.Data;
using Isas.Models;
using Isas.Models.InsurerViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Isas.Controllers
{
    [Authorize]
    public class LoadFormatsController : Controller
    {
        private readonly InsurerDbContext _context;

        public enum FileTypes
        {
            Excel = 1, CSV = 2, FixedLengthDelimited = 3
        }

        public LoadFormatsController(InsurerDbContext context)
        {
            _context = context;    
        }

        public async Task<IActionResult> SelectTable(Guid productId, Guid loadFormatId, UploadFileTypes uploadFileType)
        {
            var tables = await _context.FormatTypes
                            .Select(t => t.TableName).Distinct()
                            .ToListAsync();

            SelectedTableViewModel viewModel = new SelectedTableViewModel
            {
                ProductID = productId,
                LoadFormatID = loadFormatId,
                UploadFileType = uploadFileType,
                TableList = new SelectList(tables.Select(tablename => new SelectListItem
                                                                            {
                                                                                Value = tablename,
                                                                                Text = tablename
                                                                            }).ToList(), "Value", "Text", tables.FirstOrDefault())
            };
            return View(viewModel);
        }

        // POST: LoadFormats/SelectTable/5
        [HttpPost, ActionName("SelectTable")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SelectTableConfirmed(SelectedTableViewModel selectedTable)
        {
            var tables = await _context.FormatTypes
                .Select(t => t.TableName).Distinct()
                .ToListAsync();

            if (ModelState.IsValid)
            {
                return RedirectToAction("EditFormatType", new {
                                                productId = selectedTable.ProductID,
                                                loadFormatId = selectedTable.LoadFormatID,
                                                tableName = selectedTable.TableName,
                                                uploadFileType = selectedTable.UploadFileType});
            }

            selectedTable.TableList = new SelectList(
                                                tables.Select(tablename =>
                                                new SelectListItem
                                                {
                                                    Value = tablename,
                                                    Text = tablename
                                                }).ToList(), "Value", "Text", tables.FirstOrDefault());

            return View(selectedTable);
        }

        // GET: LoadFormats/EditFormatType
        public async Task<IActionResult> EditFormatType(Guid productId, Guid loadFormatId,
                                            string tableName, UploadFileTypes uploadFileType)
        {
            var formattypes = await (from r in _context.FormatTypes
                                     where r.LoadFormatID == loadFormatId &&
                                            r.TableName == tableName
                                     orderby r.FieldLabel
                                     select r).ToListAsync();

            FormatTypesViewModel viewModel = new FormatTypesViewModel
            {
                ProductID = productId,
                UploadFileType = uploadFileType,
                FormatTypes = formattypes
            };
            return View(viewModel);
        }

        // GET: LoadFormats
        public async Task<IActionResult> Index(Guid productId)
        {
            LoadFormatsViewModel viewModel = new LoadFormatsViewModel
            {
                ProductID = productId,
                LoadFormats = await _context.LoadFormats
                                    .AsNoTracking()
                                    .Where(p => p.ProductID == productId).ToListAsync()
            };

            return View(viewModel);
        }

        // GET: LoadFormats/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loadFormat = await _context.LoadFormats.SingleOrDefaultAsync(m => m.ID == id);
            if (loadFormat == null)
            {
                return NotFound();
            }

            return View(loadFormat);
        }

        // GET: LoadFormats/Create
        public IActionResult Create(Guid productId)
        {
            FileTypes[] values = (FileTypes[])Enum.GetValues(typeof(FileTypes));
            var list = (from value in values
                       select new SelectListItem()
                       {
                           Value = ((int)value).ToString(),
                           Text = value.ToString()
                       }).ToList();

            LoadFormatViewModel viewModel = new LoadFormatViewModel
            {
                ProductID = productId,
                FileTypeList = new SelectList(list, "Value", "Text")
            };
            return View(viewModel);
        }

        // POST: LoadFormats/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LoadFormatViewModel viewModel)
        {
            FileTypes[] values = (FileTypes[])Enum.GetValues(typeof(FileTypes));

            if (ModelState.IsValid)
            {
                LoadFormat loadFormat = new LoadFormat();
                loadFormat = viewModel.LoadFormat;
                loadFormat.ID = Guid.NewGuid();
                loadFormat.ProductID = viewModel.ProductID;
                _context.Add(loadFormat);
                await _context.SaveChangesAsync();
                //  Populate Format Types

                var loadFormatId = loadFormat.ID;
                PopulateFormatTypes(loadFormatId);
                return RedirectToAction("Index" , new { productId = viewModel.ProductID});
            }
            var list = (from value in values
                        select new SelectListItem()
                        {
                            Value = ((int)value).ToString(),
                            Text = value.ToString()
                        }).ToList();

            viewModel.FileTypeList = new SelectList(list, "Value", "Text");
            return View(viewModel);
        }

        // GET: LoadFormats/Edit/5
        public async Task<IActionResult> Edit(Guid? Id)
        {
            var loadFormat = await _context.LoadFormats.SingleOrDefaultAsync(m => m.ID == Id);
            if (loadFormat == null)
            {
                return NotFound();
            }

            FileTypes[] values = (FileTypes[])Enum.GetValues(typeof(FileTypes));

            var list = (from value in values
                        select new SelectListItem()
                        {
                            Value = ((int)value).ToString(),
                            Text = value.ToString()
                        }).ToList();

            LoadFormatViewModel viewModel = new LoadFormatViewModel
            {
                LoadFormat = loadFormat,
                FileTypeList = new SelectList(list, "Value", "Text", loadFormat.UploadFileType)
            };
            return View(viewModel);
        }

        // POST: LoadFormats/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LoadFormatViewModel viewModel)
        {
            FileTypes[] values = (FileTypes[])Enum.GetValues(typeof(FileTypes));

            var list = (from value in values
                        select new SelectListItem()
                        {
                            Value = ((int)value).ToString(),
                            Text = value.ToString()
                        }).ToList();

            if (ModelState.IsValid)
            {
                LoadFormat loadFormat = new LoadFormat();
                loadFormat = viewModel.LoadFormat;
                try
                {
                    _context.Update(loadFormat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoadFormatExists(loadFormat.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", new { productId = loadFormat.ProductID });
            }
            viewModel.FileTypeList = new SelectList(list, "Value", "Text", viewModel.LoadFormat.UploadFileType);
            return View(viewModel);
        }

        // GET: LoadFormats/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loadFormat = await _context.LoadFormats.SingleOrDefaultAsync(m => m.ID == id);
            if (loadFormat == null)
            {
                return NotFound();
            }

            return View(loadFormat);
        }

        // POST: LoadFormats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var loadFormat = await _context.LoadFormats.SingleOrDefaultAsync(m => m.ID == id);
            _context.LoadFormats.Remove(loadFormat);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        void PopulateFormatTypes(Guid loadFormatTypeId)
        {
            var formatTypes = new FormatType[]
            {
               new FormatType {ID=Guid.NewGuid(),LoadFormatID=loadFormatTypeId,TableName="Client",FieldName="Title",FieldLabel="Title",Position=null,ColumnLength=0,IsKey=false},
               new FormatType {ID=Guid.NewGuid(),LoadFormatID=loadFormatTypeId,TableName="Client",FieldName="FirstName",FieldLabel="First Name",Position=null,ColumnLength=0,IsKey=false},
               new FormatType {ID=Guid.NewGuid(),LoadFormatID=loadFormatTypeId,TableName="Client",FieldName="LastName",FieldLabel="Last Name",Position=null,ColumnLength=0,IsKey=false},
               new FormatType {ID=Guid.NewGuid(),LoadFormatID=loadFormatTypeId,TableName="Client",FieldName="BirthDate",FieldLabel="Birth Date",Position=null,ColumnLength=0,IsKey=false},
               new FormatType {ID=Guid.NewGuid(),LoadFormatID=loadFormatTypeId,TableName="Client",FieldName="Gender",FieldLabel="Gender",Position=null,ColumnLength=0,IsKey=false},
               new FormatType {ID=Guid.NewGuid(),LoadFormatID=loadFormatTypeId,TableName="Client",FieldName="IDNumber",FieldLabel="ID Number",Position=null,ColumnLength=0,IsKey=true},
               new FormatType {ID=Guid.NewGuid(),LoadFormatID=loadFormatTypeId,TableName="Client",FieldName="Occupation",FieldLabel="Occupation",Position=null,ColumnLength=0,IsKey=false},
               new FormatType {ID=Guid.NewGuid(),LoadFormatID=loadFormatTypeId,TableName="Client",FieldName="Country",FieldLabel="Country",Position=null,ColumnLength=0,IsKey=false},

               new FormatType {ID=Guid.NewGuid(),LoadFormatID=loadFormatTypeId,TableName="Policy",FieldName="IDNumber",FieldLabel="ID Number",Position=null,ColumnLength=0,IsKey=true},
               new FormatType {ID=Guid.NewGuid(),LoadFormatID=loadFormatTypeId,TableName="Policy",FieldName="InsurerNumber",FieldLabel="Insurer Number",Position=null,ColumnLength=0,IsKey=false},
               new FormatType {ID=Guid.NewGuid(),LoadFormatID=loadFormatTypeId,TableName="Policy",FieldName="CoverStartDate",FieldLabel="Cover Start Date",Position=null,ColumnLength=0,IsKey=false},
               new FormatType {ID=Guid.NewGuid(),LoadFormatID=loadFormatTypeId,TableName="Policy",FieldName="CoverEndDate",FieldLabel="Cover End Date",Position=null,ColumnLength=0,IsKey=false},

               new FormatType {ID=Guid.NewGuid(),LoadFormatID=loadFormatTypeId,TableName="Premium",FieldName="IDNumber",FieldLabel="ID Number",Position=null,ColumnLength=0,IsKey=true},
               new FormatType {ID=Guid.NewGuid(),LoadFormatID=loadFormatTypeId,TableName="Premium",FieldName="PremiumDate",FieldLabel="Premium Date",Position=null,ColumnLength=0,IsKey=true},
               new FormatType {ID=Guid.NewGuid(),LoadFormatID=loadFormatTypeId,TableName="Premium",FieldName="Amount",FieldLabel="Premium",Position=null,ColumnLength=0,IsKey=false},

               new FormatType {ID=Guid.NewGuid(),LoadFormatID=loadFormatTypeId,TableName="Claim",FieldName="ClaimID",FieldLabel="Claim Number",Position=null,ColumnLength=0,IsKey=true},
               new FormatType {ID=Guid.NewGuid(),LoadFormatID=loadFormatTypeId,TableName="Claim",FieldName="ReportDate",FieldLabel="Report Date",Position=null,ColumnLength=0,IsKey=false},
               new FormatType {ID=Guid.NewGuid(),LoadFormatID=loadFormatTypeId,TableName="Claim",FieldName="IncidentDate",FieldLabel="Incident Date",Position=null,ColumnLength=0,IsKey=false},
               new FormatType {ID=Guid.NewGuid(),LoadFormatID=loadFormatTypeId,TableName="Claim",FieldName="RegisterDate",FieldLabel="Register Date",Position=null,ColumnLength=0,IsKey=false},
               new FormatType {ID=Guid.NewGuid(),LoadFormatID=loadFormatTypeId,TableName="Claim",FieldName="ReserveInsured",FieldLabel="Reserve Insured",Position=null,ColumnLength=0,IsKey=false},
               new FormatType {ID=Guid.NewGuid(),LoadFormatID=loadFormatTypeId,TableName="Claim",FieldName="ReserveThirdParty",FieldLabel="Reserve Third Party",Position=null,ColumnLength=0,IsKey=false},
               new FormatType {ID=Guid.NewGuid(),LoadFormatID=loadFormatTypeId,TableName="Claim",FieldName="ReserveInsuredRevised",FieldLabel="Reserve Insured Revised",Position=null,ColumnLength=0,IsKey=false},
               new FormatType {ID=Guid.NewGuid(),LoadFormatID=loadFormatTypeId,TableName="Claim",FieldName="ReserveThirdPartyRevised",FieldLabel="Reserve Third Party Revised",Position=null,ColumnLength=0,IsKey=false},
               new FormatType {ID=Guid.NewGuid(),LoadFormatID=loadFormatTypeId,TableName="Claim",FieldName="ClaimExcess",FieldLabel="Claim Excess",Position=null,ColumnLength=0,IsKey=false},
               new FormatType {ID=Guid.NewGuid(),LoadFormatID=loadFormatTypeId,TableName="Claim",FieldName="RecoverFromThirdParty",FieldLabel="Recover From Third Party",Position=null,ColumnLength=0,IsKey=false},
               new FormatType {ID=Guid.NewGuid(),LoadFormatID=loadFormatTypeId,TableName="Claim",FieldName="ManualClaimNumber",FieldLabel="Manual Claim Number",Position=null,ColumnLength=0,IsKey=false},
               new FormatType {ID=Guid.NewGuid(),LoadFormatID=loadFormatTypeId,TableName="Claim",FieldName="InsurerClaimNumber",FieldLabel="Insurer Claim Number",Position=null,ColumnLength=0,IsKey=false},
            };

            foreach (FormatType f in formatTypes)
            {
                _context.FormatTypes.Add(f);
            }
            _context.SaveChanges();
        }

        private bool LoadFormatExists(Guid id)
        {
            return _context.LoadFormats.Any(e => e.ID == id);
        }
    }
}
