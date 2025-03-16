using EPizzaHub.Domain.Models;
using EPizzaHub.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EPizzaHub.Repositories.Concrete
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(ePizzaHubDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<Cart> GetCartAsync(Guid Cartid)
        {
            return await _dbContext
                    .Carts
                    .Include(x => x.CartItems)
                    .Where(x => x.Id == Cartid && x.IsActive == true).FirstOrDefaultAsync();
        }
    }
}
