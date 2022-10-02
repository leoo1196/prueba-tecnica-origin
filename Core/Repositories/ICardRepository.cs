using Core.Models;

namespace Core.Repositories;
public interface ICardRepository : IGenericRepository<Card>
{
    Task<Card?> GetByNumberAsync(string number);
}
