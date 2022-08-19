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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "تکنولوژی",
                    Descreption = "تکنولوژی"
                },
                new Category
                {
                    Id = 2,
                    Name = "پوشاک",
                    Descreption = "پوشاک"
                }, 
                new Category
                {
                    Id = 3,
                    Name = "لوازم جانبی خودرو",
                    Descreption = "لوازم جانبی خودرو"
                }, new Category
                {
                    Id = 4,
                    Name = "مواد غذایی",
                    Descreption = "مواد غذایی"
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
