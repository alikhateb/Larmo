using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Larmo.Core.Repository;
using Larmo.Infrastructure.Context;

namespace Larmo.Infrastructure.Repository;

public class Repository<T> : RepositoryBase<T>, IRepository<T>
    where T : class
{
    protected Repository(BaseContext context)
        : base(context, SpecificationEvaluator.Default)
    {
    }

    public IQueryable<T> AsPage(ISpecification<T> specification)
    {
        return ApplySpecification(specification);
    }
}
