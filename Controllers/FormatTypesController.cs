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
    public class FormatTypesController : Controller
    {
        private readonly InsurerDbContext _context;

        public FormatTypesController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: FormatTypes
        public async Task<IActionResult> Index(Guid loadFormatId, UploadFileTypes uploadFileType)
        {
            var tables = _context.FormatTypes
                            .Where(t => t.LoadFormatID == loadFormatId)
                            .Select(t => t.TableName).Distinct()
                            .ToList();

            var _tablename = tables.FirstOrDefault();

            var formattypes = await _context.FormatTypes
                                .Include(f => f.LoadFormat)
                                .AsNoTracking()
                                .OrderBy(c => c.FieldName)
                                .Where(f => f.LoadFormatID == loadFormatId &&
                                f.TableName == _tablename).ToListAsync();

            FormatTypesViewModel viewModel = new FormatTypesViewModel
            {
                FormatTypes = formattypes,
                UploadFileType = uploadFileType
            };
            return View(viewModel);
        }

        // GET: FormatTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formatType = await _context.FormatTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (formatType == null)
            {
                return NotFound();
            }

            return View(formatType);
        }

        // GET: FormatTypes/Create
        public IActionResult Create()
        {
            ViewData["LoadFormatID"] = new SelectList(_context.LoadFormats, "ID", "ID");
            return View();
        }

        // POST: FormatTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ColumnLength,Delimiter,FieldName,LoadFormatID,IsKey,Position,TableName")] FormatType formatType)
        {
            if (ModelState.IsValid)
            {
                formatType.ID = Guid.NewGuid();
                _context.Add(formatType);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["LoadFormatID"] = new SelectList(_context.LoadFormats, "ID", "ID", formatType.LoadFormatID);
            return View(formatType);
        }

        // GET: FormatTypes/Edit/5
        public async Task<IActionResult> Edit(Guid productId, Guid Id, UploadFileTypes uploadFileType)
        {
            var formatType = await _context.FormatTypes.SingleOrDefaultAsync(m => m.ID == Id);
            FormatTypeViewModel viewModel = new FormatTypeViewModel
            {
                ProductID = productId,
                UploadFileType = uploadFileType,
                FormatType = formatType
            };
            return View(viewModel);
        }

        // POST: FormatTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FormatTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                FormatType formatType = new FormatType();
                formatType = viewModel.FormatType;
                try
                {
                    _context.Update(formatType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormatTypeExists(formatType.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("EditFormatType", "LoadFormats", new { productId = viewModel.ProductID, loadFormatId = formatType.LoadFormatID,
                                          tableName = formatType.TableName, uploadFileType = viewModel.UploadFileType });
            }
            return View(viewModel);
        }

        // GET: FormatTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formatType = await _context.FormatTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (formatType == null)
            {
                return NotFound();
            }

            return View(formatType);
        }

        // POST: FormatTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var formatType = await _context.FormatTypes.SingleOrDefaultAsync(m => m.ID == id);
            _context.FormatTypes.Remove(formatType);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FormatTypeExists(Guid id)
        {
            return _context.FormatTypes.Any(e => e.ID == id);
        }
    }
}
