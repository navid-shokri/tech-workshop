using EFDualContextTest.DataAccess;
using EFDualContextTest.Models;

namespace EFDualContextTest.Repository;

public class ProductRepository : GenericRepository<OrderDbContext, Product>, IProductRepository
{
    public ProductRepository(OrderDbContext dbContext, ILogger<GenericRepository<OrderDbContext, Product>> logger) : base(dbContext, logger)
    {
    }
}