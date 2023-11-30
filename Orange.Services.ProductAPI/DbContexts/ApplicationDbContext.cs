using Microsoft.EntityFrameworkCore;
using Orange.Services.ProductAPI.Models;

namespace Orange.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Name = "Samosa",
                Price = 15,
                Description = "roin posuere sollicitudin odio, quis malesuada metus ornare et. Morbi quis gravida eros. Vivamus aliquam iaculis lorem, gravida lobortis est mollis sit amet. Donec ut sapien a neque luctus feugiat in at orci. Cras odio massa, elementum vitae euismod vitae, dapibus et quam. Pellentesque ex arcu, ornare non libero sed, vestibulum vehicula tortor.",
                CategoryName = "Appetizer",
                ImageUrl = ""
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "Paneer Tikka",
                Price = 13.99,
                Description = "roin posuere sollicitudin odio, quis malesuada metus ornare et. Morbi quis gravida eros. Vivamus aliquam iaculis lorem, gravida lobortis est mollis sit amet. Donec ut sapien a neque luctus feugiat in at orci. Cras odio massa, elementum vitae euismod vitae, dapibus et quam. Pellentesque ex arcu, ornare non libero sed, vestibulum vehicula tortor.",
                CategoryName = "Appetizer",
                ImageUrl = ""
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "Paneer Tikka",
                Price = 13.99,
                Description = "roin posuere sollicitudin odio, quis malesuada metus ornare et. Morbi quis gravida eros. Vivamus aliquam iaculis lorem, gravida lobortis est mollis sit amet. Donec ut sapien a neque luctus feugiat in at orci. Cras odio massa, elementum vitae euismod vitae, dapibus et quam. Pellentesque ex arcu, ornare non libero sed, vestibulum vehicula tortor.",
                CategoryName = "Appetizer",
                ImageUrl = ""
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Name = "Sweet Pie",
                Price = 13.99,
                Description = "roin posuere sollicitudin odio, quis malesuada metus ornare et. Morbi quis gravida eros. Vivamus aliquam iaculis lorem, gravida lobortis est mollis sit amet. Donec ut sapien a neque luctus feugiat in at orci. Cras odio massa, elementum vitae euismod vitae, dapibus et quam. Pellentesque ex arcu, ornare non libero sed, vestibulum vehicula tortor.",
                CategoryName = "Desert",
                ImageUrl = ""
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                Name = "Pav Bhaji",
                Price = 15,
                Description = "roin posuere sollicitudin odio, quis malesuada metus ornare et. Morbi quis gravida eros. Vivamus aliquam iaculis lorem, gravida lobortis est mollis sit amet. Donec ut sapien a neque luctus feugiat in at orci. Cras odio massa, elementum vitae euismod vitae, dapibus et quam. Pellentesque ex arcu, ornare non libero sed, vestibulum vehicula tortor.",
                CategoryName = "Entree",
                ImageUrl = ""
            });

        }
    }
}
