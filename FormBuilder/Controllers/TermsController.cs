using FormBuilder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FormBuilder.Controllers
{
    public class TermsController : Controller
    {
        private readonly AppDbContext _context;

        public TermsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Terms
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Terms.Include(t => t.Vocabularie);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Terms/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Terms == null)
            {
                return NotFound();
            }

            var term = await _context.Terms
                .Include(t => t.Vocabularie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (term == null)
            {
                return NotFound();
            }

            return View(term);
        }

        // GET: Terms/Create
        public IActionResult Create()
        {
            ViewData["VocabularieId"] = new SelectList(_context.Vocabularies, "Id", "Name");
            ViewData["VocabularieId"] = new SelectList(_context.Vocabularies, "Id", "Name");
            return View();
        }

        // POST: Terms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Value,OrderBy,VocabularieId")] Term term)
        {
            if (ModelState.IsValid)
            {
                _context.Add(term);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VocabularieId"] = new SelectList(_context.Vocabularies, "Id", "Name");
            return View(term);
        }

        // GET: Terms/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Terms == null)
            {
                return NotFound();
            }

            var term = await _context.Terms.FindAsync(id);
            if (term == null)
            {
                return NotFound();
            }
            ViewData["VocabularieId"] = new SelectList(_context.Vocabularies, "Id", "Name");
            return View(term);
        }

        // POST: Terms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Value,OrderBy,VocabularieId")] Term term)
        {
            if (id != term.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(term);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TermExists(term.Id))
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
            ViewData["VocabularieId"] = new SelectList(_context.Vocabularies, "Id", "Name");
            return View(term);
        }

        // GET: Terms/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Terms == null)
            {
                return NotFound();
            }

            var term = await _context.Terms
                .Include(t => t.Vocabularie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (term == null)
            {
                return NotFound();
            }

            return View(term);
        }

        // POST: Terms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Terms == null)
            {
                return Problem("Entity set 'AppDbContext.Terms'  is null.");
            }
            var term = await _context.Terms.FindAsync(id);
            if (term != null)
            {
                _context.Terms.Remove(term);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TermExists(long id)
        {
            return _context.Terms.Any(e => e.Id == id);
        }
    }
}
