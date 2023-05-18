using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniRate.Data;
using UniRate.Models;

namespace UniRate.Controllers
{
    public class UniversitiesController : Controller
    {
        private readonly UniRateContext _context;

        public UniversitiesController(UniRateContext context)
        {
            _context = context;
        }

        // GET: Universities
        public async Task<IActionResult> Index()
        {
              return _context.University != null ? 
                          View(await _context.University.ToListAsync()) :
                          Problem("Entity set 'UniRateContext.University'  is null.");
        }

        // GET: Universities/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.University == null)
            {
                return NotFound();
            }

            var university = await _context.University
                .FirstOrDefaultAsync(m => m.Id == id);
            if (university == null)
            {
                return NotFound();
            }

            return View(university);
        }

        // GET: Universities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Universities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LogoUrl,BackroundPhotoUrl,Dean,Location,Address,SiteUrl,LocationUrl,Phone,ContactUrl")] University university)
        {
            if (ModelState.IsValid)
            {
                university.Id = Guid.NewGuid();
                _context.Add(university);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(university);
        }

        // GET: Universities/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.University == null)
            {
                return NotFound();
            }

            var university = await _context.University.FindAsync(id);
            if (university == null)
            {
                return NotFound();
            }
            return View(university);
        }

        // POST: Universities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,LogoUrl,BackroundPhotoUrl,Dean,Location,Address,SiteUrl,LocationUrl,Phone,ContactUrl")] University university)
        {
            if (id != university.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(university);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniversityExists(university.Id))
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
            return View(university);
        }

        // GET: Universities/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.University == null)
            {
                return NotFound();
            }

            var university = await _context.University
                .FirstOrDefaultAsync(m => m.Id == id);
            if (university == null)
            {
                return NotFound();
            }

            return View(university);
        }

        // POST: Universities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.University == null)
            {
                return Problem("Entity set 'UniRateContext.University'  is null.");
            }
            var university = await _context.University.FindAsync(id);
            if (university != null)
            {
                _context.University.Remove(university);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniversityExists(Guid id)
        {
          return (_context.University?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
