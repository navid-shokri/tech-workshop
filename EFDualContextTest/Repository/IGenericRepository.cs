using EFDualContextTest.Models;

namespace EFDualContextTest.Repository;

public interface IGenericRepository<T> : IGenericWriteRepository<T>, IGenericReadRepository<T> where T: BaseEntity
{
}