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
    public class DepRatingsController : Controller
    {
        private readonly UniRateContext _context;

        public DepRatingsController(UniRateContext context)
        {
            _context = context;
        }

        // GET: DepRatings
        public async Task<IActionResult> Index()
        {
              return _context.DepRating != null ? 
                          View(await _context.DepRating.ToListAsync()) :
                          Problem("Entity set 'UniRateContext.DepRating'  is null.");
        }

        // GET: DepRatings/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.DepRating == null)
            {
                return NotFound();
            }

            var depRating = await _context.DepRating
                .FirstOrDefaultAsync(m => m.Id == id);
            if (depRating == null)
            {
                return NotFound();
            }

            return View(depRating);
        }

        // GET: DepRatings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DepRatings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DifficultyRating,ProfessorsRating,SubjectsRating,FreshnessRating,OrganisationRating,OverallRating,Review,DateTime")] DepRating depRating)
        {
            if (ModelState.IsValid)
            {
                depRating.Id = Guid.NewGuid();
                _context.Add(depRating);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(depRating);
        }

        // GET: DepRatings/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.DepRating == null)
            {
                return NotFound();
            }

            var depRating = await _context.DepRating.FindAsync(id);
            if (depRating == null)
            {
                return NotFound();
            }
            return View(depRating);
        }

        // POST: DepRatings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,DifficultyRating,ProfessorsRating,SubjectsRating,FreshnessRating,OrganisationRating,OverallRating,Review,DateTime")] DepRating depRating)
        {
            if (id != depRating.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(depRating);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepRatingExists(depRating.Id))
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
            return View(depRating);
        }

        // GET: DepRatings/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.DepRating == null)
            {
                return NotFound();
            }

            var depRating = await _context.DepRating
                .FirstOrDefaultAsync(m => m.Id == id);
            if (depRating == null)
            {
                return NotFound();
            }

            return View(depRating);
        }

        // POST: DepRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.DepRating == null)
            {
                return Problem("Entity set 'UniRateContext.DepRating'  is null.");
            }
            var depRating = await _context.DepRating.FindAsync(id);
            if (depRating != null)
            {
                _context.DepRating.Remove(depRating);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepRatingExists(Guid id)
        {
          return (_context.DepRating?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
