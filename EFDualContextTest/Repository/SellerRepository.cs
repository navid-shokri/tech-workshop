using EFDualContextTest.DataAccess;
using EFDualContextTest.Models;

namespace EFDualContextTest.Repository;

public class SellerRepository : GenericRepository<OrderDbContext,Seller>, ISellerRepository 
{
    public SellerRepository(OrderDbContext dbContext, ILogger<GenericRepository<OrderDbContext, Seller>> logger) : base(dbContext, logger)
    {
    }

    public override Task AddAsync(Seller entity)
    {
        DbContext.Products.Attach(entity.Product);
        return base.AddAsync(entity);
    }
}