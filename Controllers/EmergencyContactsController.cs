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
    public class EmergencyContactsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmergencyContactsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmergencyContacts
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmergencyContact.ToListAsync());
        }

        // GET: EmergencyContacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emergencyContact = await _context.EmergencyContact
                .FirstOrDefaultAsync(m => m.EmergencyContactId == id);
            if (emergencyContact == null)
            {
                return NotFound();
            }

            return View(emergencyContact);
        }

        // GET: EmergencyContacts/Create
        public IActionResult Create()
        {
            ViewData["CyclistId"] = new SelectList(_context.Cyclist, "CyclistId", "LastName");
            return View();
        }

        // POST: EmergencyContacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmergencyContactId,FirstName,LastName,Relation,PhoneNumber,Email,CyclistId")] EmergencyContact emergencyContact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emergencyContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CyclistId"] = new SelectList(_context.Cyclist, "CyclistId", "LastName", emergencyContact.CyclistId);
            return View(emergencyContact);
        }

        // GET: EmergencyContacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emergencyContact = await _context.EmergencyContact.FindAsync(id);
            if (emergencyContact == null)
            {
                return NotFound();
            }
            return View(emergencyContact);
        }

        // POST: EmergencyContacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmergencyContactId,FirstName,LastName,Relation,PhoneNumber,Email,CyclistId")] EmergencyContact emergencyContact)
        {
            if (id != emergencyContact.EmergencyContactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emergencyContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmergencyContactExists(emergencyContact.EmergencyContactId))
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
            return View(emergencyContact);
        }

        // GET: EmergencyContacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emergencyContact = await _context.EmergencyContact
                .FirstOrDefaultAsync(m => m.EmergencyContactId == id);
            if (emergencyContact == null)
            {
                return NotFound();
            }

            return View(emergencyContact);
        }

        // POST: EmergencyContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emergencyContact = await _context.EmergencyContact.FindAsync(id);
            _context.EmergencyContact.Remove(emergencyContact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmergencyContactExists(int id)
        {
            return _context.EmergencyContact.Any(e => e.EmergencyContactId == id);
        }
    }
}
