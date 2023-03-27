using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageDemo.Data;
using RazorPageDemo.Model;

namespace RazorPageDemo.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        public Category Category { get; set; }
        public AppDbContext _db;
        public EditModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Category=_db.Category.Find(id);
        }
        public async Task<IActionResult>OnPost()
        {
            if(Category.Name==Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name","The DisplayOrder can not exactly match the name.");
            }
            if(ModelState.IsValid)
            {
                _db.Category.Update(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category updated successfully!";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
