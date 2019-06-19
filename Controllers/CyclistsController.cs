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
    public class CyclistsController : Controller
    {
        private readonly UserManager<Cyclist> _userManager;
        private readonly ApplicationDbContext _context;

        public CyclistsController(ApplicationDbContext context, UserManager<Cyclist> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private Task<Cyclist> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Cyclists
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var profiles = _context.Cyclist.Where(c => c.Id == user.Id);
            return View(await profiles.ToListAsync());
        }

        // GET: Cyclists/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cyclist = await _context.Cyclist
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cyclist == null)
            {
                return NotFound();
            }

            return View(cyclist);
        }

        // GET: Cyclists/Create
        public IActionResult Create()
        {
            CyclistPhotoUploadViewModel viewcyclist = new CyclistPhotoUploadViewModel();
            return View(viewcyclist);
        }

        // POST: Cyclists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CyclistPhotoUploadViewModel viewcyclist)
        {
            if (ModelState.IsValid)
            {
                if (viewcyclist.ImageFile != null)
                {
                    var fileName = Path.GetFileName(viewcyclist.ImageFile.FileName);
                    Path.GetTempFileName();
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await viewcyclist.ImageFile.CopyToAsync(stream);
                    }

                    viewcyclist.Cyclist.ImagePath = viewcyclist.ImageFile.FileName;
                }
                _context.Add(viewcyclist.Cyclist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewcyclist);
        }

        // GET: Cyclists/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            CyclistPhotoUploadViewModel viewcyclist = new CyclistPhotoUploadViewModel();
            viewcyclist.Cyclist = new Cyclist();

            if (id == null)
            {
                return NotFound();
            }

            var cyclist = await _context.Cyclist.FindAsync(id);

            viewcyclist.Cyclist = cyclist;

            if (cyclist == null)
            {
                return NotFound();
            }
            return View(viewcyclist);
        }

        // POST: Cyclists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, CyclistPhotoUploadViewModel viewcyclist)
        {
            if (id != viewcyclist.Cyclist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _userManager.UpdateAsync(viewcyclist.Cyclist);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CyclistExists(viewcyclist.Cyclist.Id))
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
            return View(viewcyclist);
        }

        // GET: Cyclists/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cyclist = await _context.Cyclist
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cyclist == null)
            {
                return NotFound();
            }

            return View(cyclist);
        }

        // POST: Cyclists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cyclist = await _context.Cyclist.FindAsync(id);
            _context.Cyclist.Remove(cyclist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CyclistExists(string id)
        {
            return _context.Cyclist.Any(e => e.Id == id);
        }
    }
}
