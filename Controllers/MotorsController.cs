using Isas.Data;
using Isas.Models;
using Isas.Models.InsurerViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Isas.Controllers
{
    [Authorize]
    public class MotorsController : Controller
    {
        private readonly InsurerDbContext _context;

        public MotorsController(InsurerDbContext context)
        {
            _context = context;
        }

        // GET: Motors
        public async Task<IActionResult> Index(Guid policyId)
        {
            var motors = _context.Motors
                .Include(m => m.Coverage)
                .Include(m => m.DriverType)
                .Include(m => m.MotorMake)
                .Include(m => m.MotorType)
                .Include(m => m.Policy)
                .AsNoTracking()
                .Where(m => m.PolicyID == policyId);
            
            return View(await motors.OrderBy(m => m.RegistrationNumber).ToListAsync());
        }

        public JsonResult MotorMakes()
        {
            var makes = (from m in _context.MotorMakes
                                .OrderBy(m => m.Name)
                                select m).ToList();

            return Json(makes);
        }

        [HttpPost]
        public IActionResult MotorModels(Guid motorMakeId)
        {
            var models = (from m in _context.MotorModels
                                .Where(m => m.MotorMakeID == motorMakeId)
                                .AsNoTracking()
                          select m).ToList();

            return Json(models);
        }

        // GET: Motors/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motor = await _context.Motors.SingleOrDefaultAsync(m => m.ID == id);
            if (motor == null)
            {
                return NotFound();
            }

            return View(motor);
        }

        // GET: Motors/Create
        public async Task<IActionResult> Create(Guid productId, Guid clientId, Guid policyId)
        {
            Motor motor = new Motor
            {
                StartDate = DateTime.Now,      //  Get Policy Cover Start Date
                EndDate = DateTime.Now       //  Get Policy Cover End Date
            };

            MotorViewModel viewModel = new MotorViewModel
            {
                ProductID = productId,
                ClientID = clientId,
                PolicyID = policyId,
                Motor = motor,
                CoverageList = new SelectList(await _context.Coverages
                                        .AsNoTracking()
                                        .ToListAsync(), "ID", "Name"),
                DriverTypeList = new SelectList(await _context.DriverTypes
                                        .AsNoTracking()
                                        .ToListAsync(), "ID", "Name"),
                MotorMakeList = new SelectList(await _context.MotorMakes
                                        .AsNoTracking()
                                        .ToListAsync(), "ID", "Name"),
                MotorModelList = new SelectList(await _context.MotorModels
                                        .AsNoTracking()
                                        .ToListAsync(), "ID", "Name"),
                MotorTypeList = new SelectList(await _context.MotorTypes
                                        .AsNoTracking()
                                        .ToListAsync(), "ID", "Name")
            };

            return View(viewModel);
        }

        // POST: Motors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MotorViewModel viewModel)
        {
            var engineNumber = viewModel.Motor.EngineNumber;
            var registrationNumber = viewModel.Motor.RegistrationNumber;
            var chassisNumber = viewModel.Motor.ChassisNumber;
            try
            {
                if (ModelState.IsValid)
                {
                    //  Check that Start Date and End Date are within Policy Cover Start and Cover End Date
                    Guid policyId = viewModel.PolicyID;
                    viewModel.ErrMsg = string.Empty;

                    //var startDate = viewModel.Motor.StartDate;
                    //var endDate = viewModel.Motor.EndDate;

                    //CompareDates compareDates = new CompareDates(_context);

                    //if (compareDates.CompareStartDate(policyId, startDate) < 0)
                    //{
                    //    viewModel.ErrMsg = $"Start Date cannot be earlier than Policy Cover Start Date";
                    //    ModelState.AddModelError(string.Empty, viewModel.ErrMsg);
                    //}

                    //if (compareDates.CompareEndDate(policyId, endDate) > 0)
                    //{
                    //    viewModel.ErrMsg = $"End Date cannot be later than Policy Cover End Date";
                    //    ModelState.AddModelError(string.Empty, viewModel.ErrMsg);
                    //}
                    
                    if (string.IsNullOrEmpty(viewModel.ErrMsg))
                    {
                        Motor motor = viewModel.Motor;
                        motor.ID = Guid.NewGuid();
                        motor.PolicyID = policyId;
                        _context.Add(motor);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("PolicyRisks", "Policies",
                            new { productId = viewModel.ProductID, clientId = viewModel.ClientID, policyId = viewModel.PolicyID });
                    }
                }
            }
            catch(DbUpdateException ex)
            {                
                var errorMsg = ex.InnerException.Message.ToString();

                viewModel.ErrMsg = errorMsg;

                if (errorMsg.Contains("IX_Motor_RegistrationNumber"))
                {
                    viewModel.ErrMsg = $"Duplicate Registration Number {registrationNumber} exists.";
                    ModelState.AddModelError(string.Empty, viewModel.ErrMsg);
                }

                if (errorMsg.Contains("IX_Motor_EngineNumber"))
                {
                    viewModel.ErrMsg = $"Duplicate Engine Number {engineNumber} exists.";
                    ModelState.AddModelError(string.Empty, viewModel.ErrMsg);
                }

                if (errorMsg.Contains("IX_Motor_ChassisNumber"))
                {
                    viewModel.ErrMsg = $"Duplicate Chassis Number {chassisNumber} exists.";
                    ModelState.AddModelError(string.Empty, viewModel.ErrMsg);
                }
            }

            viewModel.CoverageList = new SelectList(await _context.Coverages
                                            .AsNoTracking()
                                            .ToListAsync(), "ID", "Name", viewModel.Motor.CoverageID);
            viewModel.DriverTypeList = new SelectList(await _context.DriverTypes
                                            .AsNoTracking()
                                            .ToListAsync(), "ID", "Name", viewModel.Motor.DriverTypeID);
            viewModel.MotorMakeList = new SelectList(await _context.MotorMakes
                                            .AsNoTracking()
                                            .ToListAsync(), "ID", "Name", viewModel.Motor.MotorMakeID);
            viewModel.MotorModelList = new SelectList(await _context.MotorModels
                                            .AsNoTracking()
                                            .ToListAsync(), "ID", "Name", viewModel.Motor.MotorModelID);
            viewModel.MotorTypeList = new SelectList(await _context.MotorTypes
                                            .AsNoTracking()
                                            .ToListAsync(), "ID", "Name", viewModel.Motor.MotorTypeID);
            return View(viewModel);
        }

        // GET: Motors/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motor = await _context.Motors.SingleOrDefaultAsync(m => m.ID == id);
            if (motor == null)
            {
                return NotFound();
            }
            ViewData["CoverageID"] = new SelectList(_context.Coverages, "ID", "Name", motor.CoverageID);
            ViewData["DriverTypeID"] = new SelectList(_context.DriverTypes, "ID", "Name", motor.DriverTypeID);
            ViewData["MotorMakeID"] = new SelectList(_context.MotorMakes, "ID", "Name", motor.MotorMakeID);
            ViewData["MotorTypeID"] = new SelectList(_context.MotorTypes, "ID", "Name", motor.MotorTypeID);
            ViewData["PolicyID"] = new SelectList(_context.Policies, "ID", "PolicyNumber", motor.PolicyID);
            return View(motor);
        }

        // POST: Motors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,CFG,ChassisNumber,CoverageID,DriverTypeID,EndDate,EngineNumber,HasAlarm,HasImmobiliser,IsBusinessUse,IsGreyImport,IsPrivateUse,ManufacturerYear,MotorMakeID,MotorModelID,MotorTypeID,PolicyID,Premium,RegistrationNumber,StartDate,TerritorialLimit,Value")] Motor motor)
        {
            if (id != motor.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotorExists(motor.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
    //            return RedirectToAction("PolicyRisks", "Policies",
    //                      new { productId = viewModel.ProductID, clientId = viewModel.ClientID, policyId = viewModel.PolicyID });
            }
            ViewData["CoverageID"] = new SelectList(_context.Coverages, "ID", "Name", motor.CoverageID);
            ViewData["DriverTypeID"] = new SelectList(_context.DriverTypes, "ID", "Name", motor.DriverTypeID);
            ViewData["MotorMakeID"] = new SelectList(_context.MotorMakes, "ID", "Name", motor.MotorMakeID);
            ViewData["MotorTypeID"] = new SelectList(_context.MotorTypes, "ID", "Name", motor.MotorTypeID);
            ViewData["PolicyID"] = new SelectList(_context.Policies, "ID", "PolicyNumber", motor.PolicyID);
            return View(motor);
        }

        // GET: Motors/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motor = await _context.Motors.SingleOrDefaultAsync(m => m.ID == id);
            if (motor == null)
            {
                return NotFound();
            }

            return View(motor);
        }

        // POST: Motors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var motor = await _context.Motors.SingleOrDefaultAsync(m => m.ID == id);
            _context.Motors.Remove(motor);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MotorExists(Guid id)
        {
            return _context.Motors.Any(e => e.ID == id);
        }
    }
}
