using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class OperationRepository : GenericRepository<Operation>, IOperationRepository
{
    public OperationRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<Operation?> GetFullOperationAsync(Guid operationId)
    {
        return await _entities.Include(e => e.Card).FirstOrDefaultAsync(operation => operation.Id == operationId);
    }
}
