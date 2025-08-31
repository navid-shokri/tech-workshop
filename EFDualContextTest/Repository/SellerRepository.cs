using EFDualContextTest.DataAccess;
using EFDualContextTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDualContextTest.Repository;

public class SellerRepository : GenericRepository<OrderDbContext,Seller>, ISellerRepository 
{
    public SellerRepository(OrderDbContext dbContext, ILogger<GenericRepository<OrderDbContext, Seller>> logger) : base(dbContext, logger)
    {
    }

    public override async Task<Seller> GetByIdAsync(Guid id, bool asNoTracking = true)
    {
        return await DbContext.Sellers.Include(x => x.Product).FirstOrDefaultAsync(x => x.Id == id);
    }

    public override Task AddAsync(Seller entity)
    {
        return base.AddAsync(entity);
    }
}