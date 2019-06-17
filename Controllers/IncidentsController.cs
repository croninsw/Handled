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
    public class IncidentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IncidentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Incidents
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Incident.Include(i => i.BicycleRider).Include(i => i.CarDriver);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Incidents/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Incidents/Create
        public IActionResult Create()
        {
            ViewData["BicycleRiderId"] = new SelectList(_context.BicycleRider, "BicycleRiderId", "BicycleRiderId");
            ViewData["CarDriverId"] = new SelectList(_context.CarDriver, "CarDriverId", "CarDriverId");
            return View();
        }

        // POST: Incidents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IncidentId,BicycleRiderId,CarDriverId,IncidentDate")] Incident incident)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incident);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BicycleRiderId"] = new SelectList(_context.BicycleRider, "BicycleRiderId", "BicycleRiderId", incident.BicycleRiderId);
            ViewData["CarDriverId"] = new SelectList(_context.CarDriver, "CarDriverId", "CarDriverId", incident.CarDriverId);
            return View(incident);
        }

        // GET: Incidents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incident = await _context.Incident.FindAsync(id);
            if (incident == null)
            {
                return NotFound();
            }
            ViewData["BicycleRiderId"] = new SelectList(_context.BicycleRider, "BicycleRiderId", "BicycleRiderId", incident.BicycleRiderId);
            ViewData["CarDriverId"] = new SelectList(_context.CarDriver, "CarDriverId", "CarDriverId", incident.CarDriverId);
            return View(incident);
        }

        // POST: Incidents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IncidentId,BicycleRiderId,CarDriverId,IncidentDate")] Incident incident)
        {
            if (id != incident.IncidentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incident);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncidentExists(incident.IncidentId))
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
            ViewData["BicycleRiderId"] = new SelectList(_context.BicycleRider, "BicycleRiderId", "BicycleRiderId", incident.BicycleRiderId);
            ViewData["CarDriverId"] = new SelectList(_context.CarDriver, "CarDriverId", "CarDriverId", incident.CarDriverId);
            return View(incident);
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
