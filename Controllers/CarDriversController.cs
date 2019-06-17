using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Handled.Data;
using Handled.Models;

namespace Handled.Controllers
{
    public class CarDriversController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarDriversController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CarDrivers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CarDriver.Include(c => c.Car).Include(c => c.Driver);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CarDrivers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carDriver = await _context.CarDriver
                .Include(c => c.Car)
                .Include(c => c.Driver)
                .FirstOrDefaultAsync(m => m.CarDriverId == id);
            if (carDriver == null)
            {
                return NotFound();
            }

            return View(carDriver);
        }

        // GET: CarDrivers/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Car, "CarId", "VIN");
            ViewData["DriverId"] = new SelectList(_context.Driver, "DriverId", "LastName");
            return View();
        }

        // POST: CarDrivers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarDriverId,DriverId,CarId")] CarDriver carDriver)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carDriver);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "Incidents", new { area = "" });
            }
            ViewData["CarId"] = new SelectList(_context.Car, "CarId", "VIN", carDriver.CarId);
            ViewData["DriverId"] = new SelectList(_context.Driver, "DriverId", "FirstName", carDriver.DriverId);
            return View(carDriver);
        }

        // GET: CarDrivers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carDriver = await _context.CarDriver.FindAsync(id);
            if (carDriver == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Car, "CarId", "VIN", carDriver.CarId);
            ViewData["DriverId"] = new SelectList(_context.Driver, "DriverId", "FirstName", carDriver.DriverId);
            return View(carDriver);
        }

        // POST: CarDrivers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarDriverId,DriverId,CarId")] CarDriver carDriver)
        {
            if (id != carDriver.CarDriverId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carDriver);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarDriverExists(carDriver.CarDriverId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Car, "CarId", "VIN", carDriver.CarId);
            ViewData["DriverId"] = new SelectList(_context.Driver, "DriverId", "FirstName", carDriver.DriverId);
            return View(carDriver);
        }

        // GET: CarDrivers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carDriver = await _context.CarDriver
                .Include(c => c.Car)
                .Include(c => c.Driver)
                .FirstOrDefaultAsync(m => m.CarDriverId == id);
            if (carDriver == null)
            {
                return NotFound();
            }

            return View(carDriver);
        }

        // POST: CarDrivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carDriver = await _context.CarDriver.FindAsync(id);
            _context.CarDriver.Remove(carDriver);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarDriverExists(int id)
        {
            return _context.CarDriver.Any(e => e.CarDriverId == id);
        }
    }
}
