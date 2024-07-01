using EFDualContextTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDualContextTest.DataAccess;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {
        
    }
    public DbSet<Product> Products { get; set; }
}