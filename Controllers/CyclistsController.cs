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
    public class CyclistsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CyclistsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cyclists
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cyclist.ToListAsync());
        }

        // GET: Cyclists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cyclist = await _context.Cyclist
                .FirstOrDefaultAsync(m => m.CyclistId == id);
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
        public async Task<IActionResult> Edit(int? id)
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
        public async Task<IActionResult> Edit(int id, CyclistPhotoUploadViewModel viewcyclist)
        {
            if (id != viewcyclist.Cyclist.CyclistId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viewcyclist.Cyclist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CyclistExists(viewcyclist.Cyclist.CyclistId))
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cyclist = await _context.Cyclist
                .FirstOrDefaultAsync(m => m.CyclistId == id);
            if (cyclist == null)
            {
                return NotFound();
            }

            return View(cyclist);
        }

        // POST: Cyclists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cyclist = await _context.Cyclist.FindAsync(id);
            _context.Cyclist.Remove(cyclist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CyclistExists(int id)
        {
            return _context.Cyclist.Any(e => e.CyclistId == id);
        }
    }
}
