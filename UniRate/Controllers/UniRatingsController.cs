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
    public class UniRatingsController : Controller
    {
        private readonly UniRateContext _context;

        public UniRatingsController(UniRateContext context)
        {
            _context = context;
        }

        // GET: UniRatings
        public async Task<IActionResult> Index()
        {
              return _context.UniRating != null ? 
                          View(await _context.UniRating.ToListAsync()) :
                          Problem("Entity set 'UniRateContext.UniRating'  is null.");
        }

        // GET: UniRatings/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.UniRating == null)
            {
                return NotFound();
            }

            var uniRating = await _context.UniRating
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uniRating == null)
            {
                return NotFound();
            }

            return View(uniRating);
        }

        // GET: UniRatings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UniRatings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SchoolRating,ActionsRating,Locationrating,AccessabilityRating,OrganisationRating,OverallRating,Review,DateTime")] UniRating uniRating)
        {
            if (ModelState.IsValid)
            {
                uniRating.Id = Guid.NewGuid();
                _context.Add(uniRating);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uniRating);
        }

        // GET: UniRatings/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.UniRating == null)
            {
                return NotFound();
            }

            var uniRating = await _context.UniRating.FindAsync(id);
            if (uniRating == null)
            {
                return NotFound();
            }
            return View(uniRating);
        }

        // POST: UniRatings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,SchoolRating,ActionsRating,Locationrating,AccessabilityRating,OrganisationRating,OverallRating,Review,DateTime")] UniRating uniRating)
        {
            if (id != uniRating.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uniRating);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniRatingExists(uniRating.Id))
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
            return View(uniRating);
        }

        // GET: UniRatings/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.UniRating == null)
            {
                return NotFound();
            }

            var uniRating = await _context.UniRating
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uniRating == null)
            {
                return NotFound();
            }

            return View(uniRating);
        }

        // POST: UniRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.UniRating == null)
            {
                return Problem("Entity set 'UniRateContext.UniRating'  is null.");
            }
            var uniRating = await _context.UniRating.FindAsync(id);
            if (uniRating != null)
            {
                _context.UniRating.Remove(uniRating);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniRatingExists(Guid id)
        {
          return (_context.UniRating?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
