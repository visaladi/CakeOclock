using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Tangy_DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {      

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<CustomProduct> CustomProducts { get; set; }
        public DbSet<CustomOrderHeader> CustomOrderHeaders { get; set; }
        public DbSet<CustomOrderDetail> CustomOrderDetails { get; set; }
    }
}