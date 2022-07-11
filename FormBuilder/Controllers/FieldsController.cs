using FormBuilder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FormBuilder.Controllers
{
    public class FieldsController : Controller
    {
        private readonly AppDbContext _context;

        public FieldsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Fields
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Fields.Include(x => x.Form);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Fields/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Fields == null)
            {
                return NotFound();
            }

            var @field = await _context.Fields
                .Include(x => x.Form)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@field == null)
            {
                return NotFound();
            }

            return View(@field);
        }

        // GET: Fields/Create
        public IActionResult Create(long? formId)
        {
            ViewData["FormId"] = new SelectList(_context.Forms, "Id", "Name");
            return View();
        }

        // POST: Fields/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,DataType,FormId,VocabularieId")] Field field)
        {
            if (ModelState.IsValid)
            {
                _context.Add(field);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FormId"] = new SelectList(_context.Forms, "Id", "Name", field.FormId);
            return View(field);
        }

        // GET: Fields/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Fields == null)
            {
                return NotFound();
            }

            var @field = await _context.Fields.FindAsync(id);
            if (@field == null)
            {
                return NotFound();
            }
            ViewData["FormId"] = new SelectList(_context.Forms, "Id", "Name", @field.FormId);
            return View(@field);
        }

        // POST: Fields/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,DataType,FormId")] Field @field)
        {
            if (id != @field.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@field);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FieldExists(@field.Id))
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
            ViewData["FormId"] = new SelectList(_context.Forms, "Id", "Name", @field.FormId);
            return View(@field);
        }

        // GET: Fields/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Fields == null)
            {
                return NotFound();
            }

            var field = await _context.Fields
                .Include(x => x.Form)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (field == null)
            {
                return NotFound();
            }

            return View(field);
        }

        // POST: Fields/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Fields == null)
            {
                return Problem("Entity set 'AppDbContext.Fields'  is null.");
            }
            var @field = await _context.Fields.FindAsync(id);
            if (@field != null)
            {
                _context.Fields.Remove(@field);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FieldExists(long id)
        {
            return _context.Fields.Any(e => e.Id == id);
        }
        [Route("/GetAllVocabularie")]
        public async Task<IActionResult> GetVocabularie()
        {
            var GetAllVocabularie = await _context.Vocabularies.ToListAsync();
            return Json(JsonConvert.SerializeObject(GetAllVocabularie));
        }

    }
}
