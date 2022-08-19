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
        public DbSet<Product> Products { get; set; }
        public DbSet<CategoryToProduct> CategoryToProducts { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryToProduct>().HasKey(X => new {X.ProductId, X.CategoryId});
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
