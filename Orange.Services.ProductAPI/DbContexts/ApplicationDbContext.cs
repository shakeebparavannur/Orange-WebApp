using Microsoft.EntityFrameworkCore;
using Orange.Services.ProductAPI.Models;

namespace Orange.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                
        }
        public DbSet<Product>Products { get; set; }
    }
}
