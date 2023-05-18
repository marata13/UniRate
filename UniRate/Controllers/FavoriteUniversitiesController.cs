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
    public class FavoriteUniversitiesController : Controller
    {
        private readonly UniRateContext _context;

        public FavoriteUniversitiesController(UniRateContext context)
        {
            _context = context;
        }

        // GET: FavoriteUniversities
        public async Task<IActionResult> Index()
        {
              return _context.FavoriteUniversity != null ? 
                          View(await _context.FavoriteUniversity.ToListAsync()) :
                          Problem("Entity set 'UniRateContext.FavoriteUniversity'  is null.");
        }

        // GET: FavoriteUniversities/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.FavoriteUniversity == null)
            {
                return NotFound();
            }

            var favoriteUniversity = await _context.FavoriteUniversity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (favoriteUniversity == null)
            {
                return NotFound();
            }

            return View(favoriteUniversity);
        }

        // GET: FavoriteUniversities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FavoriteUniversities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] FavoriteUniversity favoriteUniversity)
        {
            if (ModelState.IsValid)
            {
                favoriteUniversity.Id = Guid.NewGuid();
                _context.Add(favoriteUniversity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(favoriteUniversity);
        }

        // GET: FavoriteUniversities/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.FavoriteUniversity == null)
            {
                return NotFound();
            }

            var favoriteUniversity = await _context.FavoriteUniversity.FindAsync(id);
            if (favoriteUniversity == null)
            {
                return NotFound();
            }
            return View(favoriteUniversity);
        }

        // POST: FavoriteUniversities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id")] FavoriteUniversity favoriteUniversity)
        {
            if (id != favoriteUniversity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(favoriteUniversity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavoriteUniversityExists(favoriteUniversity.Id))
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
            return View(favoriteUniversity);
        }

        // GET: FavoriteUniversities/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.FavoriteUniversity == null)
            {
                return NotFound();
            }

            var favoriteUniversity = await _context.FavoriteUniversity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (favoriteUniversity == null)
            {
                return NotFound();
            }

            return View(favoriteUniversity);
        }

        // POST: FavoriteUniversities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.FavoriteUniversity == null)
            {
                return Problem("Entity set 'UniRateContext.FavoriteUniversity'  is null.");
            }
            var favoriteUniversity = await _context.FavoriteUniversity.FindAsync(id);
            if (favoriteUniversity != null)
            {
                _context.FavoriteUniversity.Remove(favoriteUniversity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FavoriteUniversityExists(Guid id)
        {
          return (_context.FavoriteUniversity?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
