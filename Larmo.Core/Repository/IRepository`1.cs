using Ardalis.Specification;

namespace Larmo.Core.Repository;

public interface IRepository<T> : IRepositoryBase<T>
    where T : class
{
    IQueryable<T> AsPage(ISpecification<T> specification);
}