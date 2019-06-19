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

namespace Handled.Controllers
{
    public class IncidentsController : Controller
    {
        private readonly UserManager<Cyclist> _userManager;
        private readonly ApplicationDbContext _context;

        public IncidentsController(ApplicationDbContext context, UserManager<Cyclist> userManager)
        {
            _context = context;
            _userManager = userManager;

        }
        private Task<Cyclist> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Incidents
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();

            var incidents = _context.Incident
                //.Where(i => i.BicycleRider.CyclistId == user.Id)
                .Include(i => i.BicycleRider.Bicycle)
                .Include(i => i.CarDriver.Driver);

            return View(await incidents.ToListAsync());
        }

        //public async Task<IActionResult> Index()
        //{
        //    var user = await GetCurrentUserAsync();

        //    var contacts = _context.EmergencyContact
        //        .Where(e => e.CyclistId == user.Id);
        //    return View(await contacts.ToListAsync());
        //}

        // GET: Incidents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incident = await _context.Incident
                .Include(i => i.BicycleRider.Bicycle)
                .Include(i => i.BicycleRider.Cyclist)
                .Include(i => i.CarDriver.Car)
                .Include(i => i.CarDriver.Driver)
                .FirstOrDefaultAsync(m => m.IncidentId == id);
            if (incident == null)
            {
                return NotFound();
            }

            return View(incident);
        }

        // GET: Incidents/Create
        public IActionResult Create()
        {
            IncidentPhotoUploadViewModel viewincident = new IncidentPhotoUploadViewModel();
            ViewData["BicycleRiderId"] = new SelectList(_context.BicycleRider, "BicycleRiderId", "BicycleRiderId");
            ViewData["CarDriverId"] = new SelectList(_context.CarDriver, "CarDriverId", "CarDriverId");
            return View(viewincident);
        }

        // POST: Incidents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IncidentPhotoUploadViewModel viewincident)
        {
            if (ModelState.IsValid)
            {
                if (viewincident.ImageFile != null)
                {
                    var fileName = Path.GetFileName(viewincident.ImageFile.FileName);
                    Path.GetTempFileName();
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await viewincident.ImageFile.CopyToAsync(stream);
                    }

                    viewincident.Incident.ImagePath = viewincident.ImageFile.FileName;
                }
                _context.Add(viewincident.Incident);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BicycleRiderId"] = new SelectList(_context.BicycleRider, "BicycleRiderId", "BicycleRiderId", viewincident.Incident.BicycleRiderId);
            ViewData["CarDriverId"] = new SelectList(_context.CarDriver, "CarDriverId", "CarDriverId", viewincident.Incident.CarDriverId);
            return View(viewincident);
        }

        // GET: Incidents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            IncidentPhotoUploadViewModel viewincident = new IncidentPhotoUploadViewModel();
            viewincident.Incident = new Incident();
            if (id == null)
            {
                return NotFound();
            }

            var incident = await _context.Incident.FindAsync(id);
            viewincident.Incident = incident;

            if (incident == null)
            {
                return NotFound();
            }
            ViewData["BicycleRiderId"] = new SelectList(_context.BicycleRider, "BicycleRiderId", "BicycleRiderId", incident.BicycleRiderId);
            ViewData["CarDriverId"] = new SelectList(_context.CarDriver, "CarDriverId", "CarDriverId", incident.CarDriverId);
            return View(viewincident);
        }

        // POST: Incidents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IncidentPhotoUploadViewModel viewincident)
        {
            if (id != viewincident.Incident.IncidentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (viewincident.ImageFile != null)
                {
                    var fileName = Path.GetFileName(viewincident.ImageFile.FileName);
                    Path.GetTempFileName();
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await viewincident.ImageFile.CopyToAsync(stream);
                    }

                    viewincident.Incident.ImagePath = viewincident.ImageFile.FileName;
                }
                try
                {
                    _context.Update(viewincident.Incident);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncidentExists(viewincident.Incident.IncidentId))
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
            ViewData["BicycleRiderId"] = new SelectList(_context.BicycleRider, "BicycleRiderId", "BicycleRiderId", viewincident.Incident.BicycleRiderId);
            ViewData["CarDriverId"] = new SelectList(_context.CarDriver, "CarDriverId", "CarDriverId", viewincident.Incident.CarDriverId);
            return View(viewincident);
        }

        // GET: Incidents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incident = await _context.Incident
                .Include(i => i.BicycleRider)
                .Include(i => i.CarDriver)
                .FirstOrDefaultAsync(m => m.IncidentId == id);
            if (incident == null)
            {
                return NotFound();
            }

            return View(incident);
        }

        // POST: Incidents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incident = await _context.Incident.FindAsync(id);
            _context.Incident.Remove(incident);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncidentExists(int id)
        {
            return _context.Incident.Any(e => e.IncidentId == id);
        }
    }
}
