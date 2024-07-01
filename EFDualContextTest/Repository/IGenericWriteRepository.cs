using EFDualContextTest.Models;

namespace EFDualContextTest.Repository;
public interface IGenericWriteRepository<T> where T : BaseEntity 
{
    Task SoftDeleteAsync(Guid id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
}