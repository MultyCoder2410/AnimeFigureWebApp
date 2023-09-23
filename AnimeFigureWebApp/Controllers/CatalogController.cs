using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AnimeFigureWebApp.Data;
using AnimeFigureWebApp.Models;

namespace AnimeFigureWebApp.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatalogController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Catalog
        public async Task<IActionResult> Index()
        {
              return _context.Figures != null ? 
                          View(await _context.Figures.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Figures'  is null.");
        }

        // GET: Catalog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Figures == null)
            {
                return NotFound();
            }

            var animeFigure = await _context.Figures
                .FirstOrDefaultAsync(m => m.AnimeFigureId == id);
            if (animeFigure == null)
            {
                return NotFound();
            }

            return View(animeFigure);
        }

        // GET: Catalog/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Catalog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnimeFigureId,Name,Description,Price,Value")] AnimeFigure animeFigure)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animeFigure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(animeFigure);
        }

        // GET: Catalog/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Figures == null)
            {
                return NotFound();
            }

            var animeFigure = await _context.Figures.FindAsync(id);
            if (animeFigure == null)
            {
                return NotFound();
            }
            return View(animeFigure);
        }

        // POST: Catalog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnimeFigureId,Name,Description,Price,Value")] AnimeFigure animeFigure)
        {
            if (id != animeFigure.AnimeFigureId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animeFigure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimeFigureExists(animeFigure.AnimeFigureId))
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
            return View(animeFigure);
        }

        // GET: Catalog/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Figures == null)
            {
                return NotFound();
            }

            var animeFigure = await _context.Figures
                .FirstOrDefaultAsync(m => m.AnimeFigureId == id);
            if (animeFigure == null)
            {
                return NotFound();
            }

            return View(animeFigure);
        }

        // POST: Catalog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Figures == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Figures'  is null.");
            }
            var animeFigure = await _context.Figures.FindAsync(id);
            if (animeFigure != null)
            {
                _context.Figures.Remove(animeFigure);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimeFigureExists(int id)
        {
          return (_context.Figures?.Any(e => e.AnimeFigureId == id)).GetValueOrDefault();
        }
    }
}
