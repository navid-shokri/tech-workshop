using System.Data;
using System.Linq.Expressions;
using EFDualContextTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDualContextTest.Repository;

public class GenericRepository<C,T> : IGenericRepository<T> where T : BaseEntity where C : DbContext 
{
    protected ILogger<GenericRepository<C, T>> Logger;
    protected readonly C DbContext;
    
    public GenericRepository(C dbContext, ILogger<GenericRepository<C,T>> logger)
    {
        DbContext = dbContext;
        Logger = logger;
    }
    protected IDbConnection DataBaseConnection => DbContext.Database.GetDbConnection();

    public virtual async Task SoftDeleteAsync(Guid id)
    {
        var item = await DbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        item.SetAsDeleted();
        await DbContext.SaveChangesAsync();
    }

    public virtual async Task AddAsync(T entity)
    {
        await DbContext.Set<T>().AddAsync(entity);
        await DbContext.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(T entity)
    {
        DbContext.Attach(entity);
        DbContext.Entry(entity).State = EntityState.Modified;
        await DbContext.SaveChangesAsync();
    }

    
    public virtual async Task<T> GetByIdAsync(Guid id, bool asNoTracking = true)
    {
        var query = DbContext.Set<T>().AsQueryable();
        if (asNoTracking)
            query = query.AsNoTracking();
        
        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }

    public virtual async Task<IEnumerable<T>> QueryAsync(Expression<Func<T, bool>> predict, bool asNoTracking = true)
    {
        var query = DbContext.Set<T>().Where(predict);
        
        if (asNoTracking)
        {
            query = query.AsNoTracking();
        }

        return await query.ToListAsync();
    }
}