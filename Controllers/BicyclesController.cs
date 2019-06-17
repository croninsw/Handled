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
    public class BicyclesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BicyclesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bicycles
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Bicycle.Include(b => b.Cyclist);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Bicycles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicycle = await _context.Bicycle
                .Include(b => b.Cyclist)
                .FirstOrDefaultAsync(m => m.BicycleId == id);
            if (bicycle == null)
            {
                return NotFound();
            }

            return View(bicycle);
        }

        // GET: Bicycles/Create
        public IActionResult Create()
        {
            BicyclePhotoUploadViewModel viewbicycle = new BicyclePhotoUploadViewModel();
            ViewData["CyclistId"] = new SelectList(_context.Cyclist, "CyclistId", "Email");
            return View(viewbicycle);
        }

        // POST: Bicycles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BicyclePhotoUploadViewModel viewbicycle)
        {
            if (ModelState.IsValid)
            {
                if (viewbicycle.ImageFile != null)
                {
                    var fileName = Path.GetFileName(viewbicycle.ImageFile.FileName);
                    Path.GetTempFileName();
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await viewbicycle.ImageFile.CopyToAsync(stream);
                    }

                    viewbicycle.Bicycle.ImagePath = viewbicycle.ImageFile.FileName;
                }
                _context.Add(viewbicycle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CyclistId"] = new SelectList(_context.Cyclist, "CyclistId", "Email", viewbicycle.Bicycle.CyclistId);
            return View(viewbicycle);
        }

        // GET: Bicycles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicycle = await _context.Bicycle.FindAsync(id);
            if (bicycle == null)
            {
                return NotFound();
            }
            ViewData["CyclistId"] = new SelectList(_context.Cyclist, "CyclistId", "Email", bicycle.CyclistId);
            return View(bicycle);
        }

        // POST: Bicycles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BicycleId,VIN,Make,Model,Color,ManufactureYear,CyclistId")] Bicycle bicycle)
        {
            if (id != bicycle.BicycleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bicycle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BicycleExists(bicycle.BicycleId))
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
            ViewData["CyclistId"] = new SelectList(_context.Cyclist, "CyclistId", "Email", bicycle.CyclistId);
            return View(bicycle);
        }

        // GET: Bicycles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicycle = await _context.Bicycle
                .Include(b => b.Cyclist)
                .FirstOrDefaultAsync(m => m.BicycleId == id);
            if (bicycle == null)
            {
                return NotFound();
            }

            return View(bicycle);
        }

        // POST: Bicycles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bicycle = await _context.Bicycle.FindAsync(id);
            _context.Bicycle.Remove(bicycle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BicycleExists(int id)
        {
            return _context.Bicycle.Any(e => e.BicycleId == id);
        }
    }
}
