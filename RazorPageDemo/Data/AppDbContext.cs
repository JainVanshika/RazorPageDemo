using Microsoft.EntityFrameworkCore;
using RazorPageDemo.Model;

namespace RazorPageDemo.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Category> Category { get; set; }
    }
}
