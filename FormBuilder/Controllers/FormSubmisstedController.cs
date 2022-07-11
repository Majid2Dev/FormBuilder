using FormBuilder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormBuilder.Controllers
{
    public class FormSubmisstedController : Controller
    {
        private readonly AppDbContext _context;

        public FormSubmisstedController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(long formId)
        {
            var Findfields = await _context.Fields.Where(x => x.FormId == formId).ToListAsync();
            return View(Findfields);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> FromApply()
        {
            var ResponseData = new List<Response>();
            var FormId = HttpContext.Request.Form["Id"];
            var GettingFromDataAsync = await HttpContext.Request.ReadFormAsync();

            foreach (var Item in GettingFromDataAsync)
            {
                if (Item.Key == "__RequestVerificationToken" || Item.Key=="Id")
                {
                    continue;
                }
                else
                {
                    long FieldId = long.Parse(Item.Key.Split("_")[1]);
                    var Values = Item.Value.ToString().Split(",");
                    if (Values.Length>=2)
                    {
                        for (int i = 0; i < Values.Length; i++)
                        {
                            ResponseData.Add(new Response()
                            {
                                FieldId = FieldId,
                                FormId = long.Parse(FormId.ToString()),
                                Resonses = Values[i]
                            });
                        }
                    }
                    else
                    {
                        ResponseData.Add(new Response()
                        {
                            FieldId = FieldId,
                            FormId = long.Parse(FormId.ToString()),
                            Resonses = Item.Value
                        });
                    }
                   
                }
          
            }

            await _context.Responses.AddRangeAsync(ResponseData);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
            return RedirectToAction("Index",new { formId = FormId });
        }
    }
}
