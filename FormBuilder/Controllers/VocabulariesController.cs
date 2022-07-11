using FormBuilder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormBuilder.Controllers
{
    public class VocabulariesController : Controller
    {
        private readonly AppDbContext _context;

        public VocabulariesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Vocabularies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vocabularies.ToListAsync());
        }

        // GET: Vocabularies/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Vocabularies == null)
            {
                return NotFound();
            }

            var vocabularie = await _context.Vocabularies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vocabularie == null)
            {
                return NotFound();
            }

            return View(vocabularie);
        }

        // GET: Vocabularies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vocabularies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,OrderBy")] Vocabularie vocabularie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vocabularie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vocabularie);
        }

        // GET: Vocabularies/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Vocabularies == null)
            {
                return NotFound();
            }

            var vocabularie = await _context.Vocabularies.FindAsync(id);
            if (vocabularie == null)
            {
                return NotFound();
            }
            return View(vocabularie);
        }

        // POST: Vocabularies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,OrderBy")] Vocabularie vocabularie)
        {
            if (id != vocabularie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vocabularie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VocabularieExists(vocabularie.Id))
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
            return View(vocabularie);
        }

        // GET: Vocabularies/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Vocabularies == null)
            {
                return NotFound();
            }

            var vocabularie = await _context.Vocabularies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vocabularie == null)
            {
                return NotFound();
            }

            return View(vocabularie);
        }

        // POST: Vocabularies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Vocabularies == null)
            {
                return Problem("Entity set 'AppDbContext.Vocabularies'  is null.");
            }
            var vocabularie = await _context.Vocabularies.FindAsync(id);
            if (vocabularie != null)
            {
                _context.Vocabularies.Remove(vocabularie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VocabularieExists(long id)
        {
            return _context.Vocabularies.Any(e => e.Id == id);
        }
    }
}
