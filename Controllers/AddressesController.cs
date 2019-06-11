using Isas.Data;
using Isas.Models;
using Isas.Models.InsurerViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Isas.Controllers
{
    [Authorize]
    public class AddressesController : Controller
    {
        private readonly InsurerDbContext _context;

        public AddressesController(InsurerDbContext context)
        {
            _context = context;    
        }

        // GET: Addresses
        public async Task<IActionResult> Index(Guid itemId)
        {
            var addresses = await (from c in _context.Addresses
                               where _context.AddressAssignments.Any(p => (p.AddressID == c.ID) && (p.ItemID == itemId))
                               orderby c.City
                               select c).ToListAsync();

            AddressesViewModel viewModel = new AddressesViewModel
            {
                ItemID = itemId,
                Addresses = addresses
            };
            return View(viewModel);
        }

        // GET: Addresses/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses.SingleOrDefaultAsync(m => m.ID == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // GET: Addresses/Create
        public IActionResult Create(Guid itemId, string controllername)
        {
            AddressViewModel viewModel = new AddressViewModel
            {
                ControllerName = controllername,
                ItemID = itemId
            };
            return View(viewModel);
        }

        // POST: Addresses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddressViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Address address = new Address();
                AddressAssignment addressassignment = new AddressAssignment();
                address = viewModel.Address;
                address.ID = Guid.NewGuid();
                _context.Add(address);
                await _context.SaveChangesAsync();

                addressassignment.ItemID = viewModel.ItemID;
                addressassignment.AddressID = address.ID;
                _context.Add(addressassignment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", viewModel.ControllerName, new { id = viewModel.ItemID });
            }
            return View(viewModel);
        }

        // GET: Addresses/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses.SingleOrDefaultAsync(m => m.ID == id);
            if (address == null)
            {
                return NotFound();
            }
            AddressViewModel viewModel = new AddressViewModel
            {
                Address = address
            };
            return View(viewModel);
        }

        // POST: Addresses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AddressViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Address address = new Address();
                address = viewModel.Address;
                try
                {
                    _context.Update(address);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressExists(address.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", new { itemId = viewModel.ItemID });
            }
            return View(viewModel);
        }

        // GET: Addresses/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses.SingleOrDefaultAsync(m => m.ID == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            Guid _itemId = Guid.Parse(HttpContext.Session.GetString("ItemID"));

            var address = await _context.Addresses.SingleOrDefaultAsync(m => m.ID == id);
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { itemId = _itemId });
        }

        private bool AddressExists(Guid id)
        {
            return _context.Addresses.Any(e => e.ID == id);
        }
    }
}
