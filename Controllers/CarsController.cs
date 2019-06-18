using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Handled.Data;
using Handled.Models;
using Handled.Models.ViewModels;
using System.IO;

namespace Handled.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Car.Include(c => c.Driver);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .Include(c => c.Driver)
                .FirstOrDefaultAsync(m => m.CarId == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            CarPhotoUploadViewModel viewcar = new CarPhotoUploadViewModel();
            ViewData["DriverId"] = new SelectList(_context.Driver, "DriverId", "LastName");
            return View(viewcar);
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarPhotoUploadViewModel viewcar)
        {
            if (ModelState.IsValid)
            {
                if (viewcar.ImageFile != null)
                {
                    var fileName = Path.GetFileName(viewcar.ImageFile.FileName);
                    Path.GetTempFileName();
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await viewcar.ImageFile.CopyToAsync(stream);
                    }

                    viewcar.Car.ImagePath = viewcar.ImageFile.FileName;
                }
                _context.Add(viewcar.Car);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "CarDrivers", new { area = "" });
            }
            ViewData["DriverId"] = new SelectList(_context.Driver, "DriverId", "LastName", viewcar.Car.DriverId);
            return View(viewcar);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            CarPhotoUploadViewModel viewcar = new CarPhotoUploadViewModel();
            viewcar.Car = new Car();

            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car.FindAsync(id);

            viewcar.Car = car;

            if (car == null)
            {
                return NotFound();
            }
            ViewData["DriverId"] = new SelectList(_context.Driver, "DriverId", "FirstName", viewcar.Car.DriverId);
            return View(viewcar);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CarPhotoUploadViewModel viewcar)
        {
            if (id != viewcar.Car.CarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viewcar.Car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(viewcar.Car.CarId))
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
            ViewData["DriverId"] = new SelectList(_context.Driver, "DriverId", "FirstName", viewcar.Car.DriverId);
            return View(viewcar);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            CarPhotoUploadViewModel viewcar = new CarPhotoUploadViewModel();

            viewcar.Car = new Car();
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .Include(c => c.Driver)
                .FirstOrDefaultAsync(m => m.CarId == id);

            viewcar.Car = car;
            if (car == null)
            {
                return NotFound();
            }

            return View(viewcar);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, CarPhotoUploadViewModel viewcar)
        {

            var car = await _context.Car.FindAsync(id);
            var cardriver = await _context.CarDriver.Where(cd => cd.CarId == id).FirstOrDefaultAsync();
            var incident = await _context.Incident.Where(i => i.CarDriverId == cardriver.DriverId).FirstOrDefaultAsync();
            viewcar.Car = car;
            if (incident != null)
            {
                _context.Incident.Remove(incident);
            }
            if (cardriver != null)
            {
                _context.CarDriver.Remove(cardriver);
            }
            _context.Car.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Car.Any(e => e.CarId == id);
        }
    }
}
