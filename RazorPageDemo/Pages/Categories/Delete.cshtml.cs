using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageDemo.Data;
using RazorPageDemo.Model;

namespace RazorPageDemo.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        public Category Category { get; set; }
        public AppDbContext _db;
        public DeleteModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Category=_db.Category.Find(id);
        }
        public async Task<IActionResult>OnPost()
        {
                var categoryDelete = _db.Category.Find(Category.Id);
                if(categoryDelete != null)
                {
                    _db.Category.Remove(categoryDelete);
                    await _db.SaveChangesAsync();
                TempData["success"] = "Category deleted successfully!";
                return RedirectToPage("Index");
                }
            return Page();
        }
    }
}
