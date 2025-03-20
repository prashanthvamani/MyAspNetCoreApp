using EPizzaHub.Domain.Models;
using EPizzaHub.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPizzaHub.Repositories.Concrete
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(ePizzaHubDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<Cart> GetCartDetailsAsync(Guid cartId)
        {
            return await _dbContext.Carts
                .Include(x => x.CartItems)
                .Where(x => x.Id == cartId && x.IsActive == true)
                .FirstAsync();
            //throw new NotImplementedException();


            //return await _dbContext
            //          .Carts
            //          .Include(x => x.CartItems)
            //          .Where(
            //                 x => x.Id == cartId && x.IsActive == true)
            //         .FirstOrDefaultAsync();
        }

       
    }
}
