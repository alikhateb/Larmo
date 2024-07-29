using Larmo.Core.Repository;
using Larmo.Domain.Domain;
using Larmo.Infrastructure.Context;

namespace Larmo.Infrastructure.Repository;

public class OperationRepository(BaseContext context) : Repository<Operation>(context), IOperationRepository;