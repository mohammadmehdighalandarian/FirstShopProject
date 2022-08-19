using FirstProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Data
{
    public class FirstProjectContext:DbContext
    {
        public FirstProjectContext(DbContextOptions<FirstProjectContext> options):base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
    }
}
