using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TvcLesson10EF.Models;

namespace TvcLesson10EF.Controllers
{
    public class TvcCategoriesController : Controller
    {
        private readonly TvcBookStoreContext _context;

        public TvcCategoriesController(TvcBookStoreContext context)
        {
            _context = context;
        }

        // GET: TvcCategories
        public async Task<IActionResult> TvcIndex(string keyword)
        {
            var tvcCategories = await _context.Categories.ToListAsync();
            if (!string.IsNullOrEmpty(keyword))
            {
                tvcCategories =  tvcCategories.Where(x=>x.CategoryName.Contains(keyword)).ToList();
            }
            return View(tvcCategories);
        }

        // GET: TvcCategories/TvcDetails/5
        public async Task<IActionResult> TvcDetails(int? tvcId)
        {
            if (tvcId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == tvcId);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: TvcCategories/TvcCreate
        public IActionResult TvcCreate()
        {
            var tvcCategory = new Category();
            return View(tvcCategory);
        }

        // POST: TvcCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TvcCreate([Bind("CategoryId,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(TvcIndex));
            }
            return View(category);
        }

        // GET: TvcCategories/TvcEdit/5
        public async Task<IActionResult> TvcEdit(int? tvcId)
        {
            if (tvcId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(tvcId);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: TvcCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TvcEdit(int tvcId, [Bind("CategoryId,CategoryName")] Category category)
        {
            if (tvcId != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(TvcIndex));
            }
            return View(category);
        }

        // GET: TvcCategories/TvcDelete/5
        public async Task<IActionResult> TvcDelete(int? tvcId)
        {
            if (tvcId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == tvcId);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: TvcCategories/TvcDelete/5
        [HttpPost, ActionName("TvcDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TvcDeleteConfirmed(int tvcId)
        {
            var category = await _context.Categories.FindAsync(tvcId);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(TvcIndex));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryId == id);
        }
    }
}
