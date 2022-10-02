using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class CardRepository : GenericRepository<Card>, ICardRepository
{
    public CardRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<Card?> GetByNumberAsync(string number)
    {
        return await _entities.FirstOrDefaultAsync(card => card.Number == number);
    }
}
