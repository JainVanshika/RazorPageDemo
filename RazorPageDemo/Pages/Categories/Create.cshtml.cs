using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageDemo.Data;
using RazorPageDemo.Model;

namespace RazorPageDemo.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        public AppDbContext _db;
        public CreateModel(AppDbContext db)
        {
            _db = db;
        }
        public Category Category { get; set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult>OnPost()
        {
            if(Category.Name==Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name","The Display Order can not exactly match the name.");
            }
            if(ModelState.IsValid)
            {
                await _db.Category.AddAsync(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category created successfully!";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
