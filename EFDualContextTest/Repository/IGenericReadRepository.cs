using System.Linq.Expressions;
using EFDualContextTest.Models;

namespace EFDualContextTest.Repository;

public interface IGenericReadRepository<T> where T: BaseEntity
{
    Task<T> GetByIdAsync(Guid id, bool asNoTracking = true);
    Task<IEnumerable<T>> QueryAsync(Expression<Func<T, bool>> predict,bool asNoTracking = true);
}