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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Handled.Controllers
{
    public class BicyclesController : Controller
    {
        private readonly UserManager<Cyclist> _userManager;
        private readonly ApplicationDbContext _context;

        public BicyclesController(ApplicationDbContext context, UserManager<Cyclist> userManager)
        {
            _context = context;
            _userManager = userManager;

        }
        private Task<Cyclist> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Bicycles
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();

            var bicycles = _context.Bicycle.Where(b => b.CyclistId == user.Id);
                return View( await bicycles.ToListAsync());
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
            //ViewData["CyclistId"] = new SelectList(_context.Cyclist, "CyclistId", "Email");
            return View(viewbicycle);
        }

        // POST: Bicycles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BicyclePhotoUploadViewModel viewbicycle)
        {
           var user = await GetCurrentUserAsync();
            viewbicycle.Bicycle.CyclistId = user.Id;
            viewbicycle.Bicycle.UserId = user.Id;
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
                _context.Add(viewbicycle.Bicycle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["CyclistId"] = new SelectList(_context.Cyclist, "CyclistId", "Email", viewbicycle.Bicycle.Cyclist.Id);
            return View(viewbicycle);
        }

        // GET: Bicycles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            BicyclePhotoUploadViewModel viewbicycle = new BicyclePhotoUploadViewModel();
            viewbicycle.Bicycle = new Bicycle();

            if (id == null)
            {
                return NotFound();
            }

            var bicycle = await _context.Bicycle.FindAsync(id);

            viewbicycle.Bicycle = bicycle;

            if (bicycle == null)
            {
                return NotFound();
            }
            //ViewData["CyclistId"] = new SelectList(_context.Cyclist, "CyclistId", "Email", viewbicycle.Bicycle.Cyclist.Id);
            return View(viewbicycle);
        }

        // POST: Bicycles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BicyclePhotoUploadViewModel viewbicycle)
        {
            var user = await GetCurrentUserAsync();
            if (id != viewbicycle.Bicycle.BicycleId)
            {
                return NotFound();
            }
                if (ModelState.IsValid)
                {
                    try
                    {
                        viewbicycle.Bicycle.UserId = user.Id;
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
                        _context.Update(viewbicycle.Bicycle);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!BicycleExists(viewbicycle.Bicycle.BicycleId))
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
            
            return View(viewbicycle);
        }

        // GET: Bicycles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            BicyclePhotoUploadViewModel viewbicycle = new BicyclePhotoUploadViewModel();
            viewbicycle.Bicycle = new Bicycle();

            if (id == null)
            {
                return NotFound();
            }

            var bicycle = await _context.Bicycle
                .Include(b => b.Cyclist)
                .FirstOrDefaultAsync(m => m.BicycleId == id);

            viewbicycle.Bicycle = bicycle;

            if (bicycle == null)
            {
                return NotFound();
            }

            return View(viewbicycle);
        }

        // POST: Bicycles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, BicyclePhotoUploadViewModel viewbicycle)
        {
            var user = await GetCurrentUserAsync();
            var bicycle = await _context.Bicycle.FindAsync(id);
            var bicyclerider = await _context.BicycleRider.Where(br => br.BicycleId == id).SingleOrDefaultAsync();
            viewbicycle.Bicycle = bicycle;

            if (bicyclerider != null)
            {
                var incident = await _context.Incident.Where(i => i.BicycleRiderId == bicyclerider.BicycleRiderId).SingleOrDefaultAsync();

                if (incident != null && incident.UserId == user.Id)
                {
                    _context.Incident.Remove(incident);
                }
                if (bicyclerider.UserId == user.Id)
                {
                    _context.BicycleRider.Remove(bicyclerider);
                }
            }
            if (bicycle.UserId == user.Id)
            {
                _context.Bicycle.Remove(bicycle);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BicycleExists(int id)
        {
            return _context.Bicycle.Any(e => e.BicycleId == id);
        }
    }
}
