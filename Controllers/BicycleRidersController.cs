using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Handled.Data;
using Handled.Models;
using Microsoft.AspNetCore.Identity;

namespace Handled.Controllers
{
    public class BicycleRidersController : Controller
    {
        private readonly UserManager<Cyclist> _userManager;
        private readonly ApplicationDbContext _context;

        public BicycleRidersController(ApplicationDbContext context, UserManager<Cyclist> userManager)
        {
            _context = context;
            _userManager = userManager;

        }
        private Task<Cyclist> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: BicycleRiders
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var applicationDbContext = _context.BicycleRider
                .Where(b => b.CyclistId == user.Id)
                .Include(b => b.Bicycle)
                .Include(b => b.Cyclist);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BicycleRiders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicycleRider = await _context.BicycleRider
                .Include(b => b.Bicycle)
                .Include(b => b.Cyclist)
                .FirstOrDefaultAsync(m => m.BicycleRiderId == id);
            if (bicycleRider == null)
            {
                return NotFound();
            }

            return View(bicycleRider);
        }

        // GET: BicycleRiders/Create
        public IActionResult Create()
        {
            ViewData["BicycleId"] = new SelectList(_context.Bicycle, "BicycleId", "Make");
            //ViewData["CyclistId"] = new SelectList(_context.Cyclist, "CyclistId", "Email");
            return View();
        }

        // POST: BicycleRiders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BicycleRider bicycleRider)
        {
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                bicycleRider.UserId = user.Id;
                bicycleRider.CyclistId = user.Id;
                _context.Add(bicycleRider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BicycleId"] = new SelectList(_context.Bicycle, "BicycleId", "Make", bicycleRider.BicycleId);
            //ViewData["CyclistId"] = new SelectList(_context.Cyclist, "CyclistId", "Email", bicycleRider.CyclistId);
            return View(bicycleRider);
        }

        // GET: BicycleRiders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicycleRider = await _context.BicycleRider.FindAsync(id);
            if (bicycleRider == null)
            {
                return NotFound();
            }
            ViewData["BicycleId"] = new SelectList(_context.Bicycle, "BicycleId", "VIN", bicycleRider.BicycleId);
            ViewData["CyclistId"] = new SelectList(_context.Cyclist, "CyclistId", "Email", bicycleRider.CyclistId);
            return View(bicycleRider);
        }

        // POST: BicycleRiders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BicycleRiderId,CyclistId,BicycleId")] BicycleRider bicycleRider)
        {
            if (id != bicycleRider.BicycleRiderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bicycleRider);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BicycleRiderExists(bicycleRider.BicycleRiderId))
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
            ViewData["BicycleId"] = new SelectList(_context.Bicycle, "BicycleId", "Make", bicycleRider.BicycleId);
            //ViewData["CyclistId"] = new SelectList(_context.Cyclist, "CyclistId", "Email", bicycleRider.CyclistId);
            return View(bicycleRider);
        }

        // GET: BicycleRiders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicycleRider = await _context.BicycleRider
                .Include(b => b.Bicycle)
                .Include(b => b.Cyclist)
                .FirstOrDefaultAsync(m => m.BicycleRiderId == id);
            if (bicycleRider == null)
            {
                return NotFound();
            }

            return View(bicycleRider);
        }

        // POST: BicycleRiders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await GetCurrentUserAsync();

            var bicyclerider = await _context.BicycleRider.FindAsync(id);

            //if (bicyclerider != null)
            //{
                var incident = await _context.Incident
                    .Where(i => i.BicycleRiderId == bicyclerider.BicycleRiderId)
                    .FirstOrDefaultAsync();

                if (incident != null)
                     //&& incident.UserId == user.Id
                {
                    _context.Incident
                        .Remove(incident);
                }
            //}
            //if (bicyclerider.UserId == user.Id)
            //{
                _context.BicycleRider.Remove(bicyclerider);
            //}
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BicycleRiderExists(int id)
        {
            return _context.BicycleRider.Any(e => e.BicycleRiderId == id);
        }
    }
}
