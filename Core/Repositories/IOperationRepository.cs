using Core.Models;

namespace Core.Repositories;
public interface IOperationRepository : IGenericRepository<Operation>
{
    Task<Operation?> GetFullOperationAsync(Guid operationId);
}
