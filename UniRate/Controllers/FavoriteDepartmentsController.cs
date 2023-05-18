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
    public class FavoriteDepartmentsController : Controller
    {
        private readonly UniRateContext _context;

        public FavoriteDepartmentsController(UniRateContext context)
        {
            _context = context;
        }

        // GET: FavoriteDepartments
        public async Task<IActionResult> Index()
        {
              return _context.FavoriteDepartment != null ? 
                          View(await _context.FavoriteDepartment.ToListAsync()) :
                          Problem("Entity set 'UniRateContext.FavoriteDepartment'  is null.");
        }

        // GET: FavoriteDepartments/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.FavoriteDepartment == null)
            {
                return NotFound();
            }

            var favoriteDepartment = await _context.FavoriteDepartment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (favoriteDepartment == null)
            {
                return NotFound();
            }

            return View(favoriteDepartment);
        }

        // GET: FavoriteDepartments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FavoriteDepartments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] FavoriteDepartment favoriteDepartment)
        {
            if (ModelState.IsValid)
            {
                favoriteDepartment.Id = Guid.NewGuid();
                _context.Add(favoriteDepartment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(favoriteDepartment);
        }

        // GET: FavoriteDepartments/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.FavoriteDepartment == null)
            {
                return NotFound();
            }

            var favoriteDepartment = await _context.FavoriteDepartment.FindAsync(id);
            if (favoriteDepartment == null)
            {
                return NotFound();
            }
            return View(favoriteDepartment);
        }

        // POST: FavoriteDepartments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id")] FavoriteDepartment favoriteDepartment)
        {
            if (id != favoriteDepartment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(favoriteDepartment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavoriteDepartmentExists(favoriteDepartment.Id))
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
            return View(favoriteDepartment);
        }

        // GET: FavoriteDepartments/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.FavoriteDepartment == null)
            {
                return NotFound();
            }

            var favoriteDepartment = await _context.FavoriteDepartment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (favoriteDepartment == null)
            {
                return NotFound();
            }

            return View(favoriteDepartment);
        }

        // POST: FavoriteDepartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.FavoriteDepartment == null)
            {
                return Problem("Entity set 'UniRateContext.FavoriteDepartment'  is null.");
            }
            var favoriteDepartment = await _context.FavoriteDepartment.FindAsync(id);
            if (favoriteDepartment != null)
            {
                _context.FavoriteDepartment.Remove(favoriteDepartment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FavoriteDepartmentExists(Guid id)
        {
          return (_context.FavoriteDepartment?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
