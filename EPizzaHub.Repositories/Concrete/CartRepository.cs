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

        public async Task<bool> DeleteCartIDAsync(Guid CartId, int itemid)
        {
            var Items = await _dbContext.CartItems.FirstOrDefaultAsync(x => x.CartId == CartId && x.ItemId == itemid);

            if(Items != null)
            {
                _dbContext.CartItems.Remove(Items);
                int deleterecord = await _dbContext.SaveChangesAsync();

                return deleterecord > 0;
            }
            return false;
        }

        public async Task<Cart> GetCartDetailsAsync(Guid cartId)
        {
            return await _dbContext.Carts
                .Include(x => x.CartItems)
                .Where(x => x.Id == cartId && x.IsActive == true)
                .FirstOrDefaultAsync();
            //throw new NotImplementedException();


            //return await _dbContext
            //          .Carts
            //          .Include(x => x.CartItems)
            //          .Where(
            //                 x => x.Id == cartId && x.IsActive == true)
            //         .FirstOrDefaultAsync();
        }

        public async Task<int> GetCartItemsQuantity(Guid CartId)
        {
            return await _dbContext.CartItems.Where(x => x.CartId == CartId).CountAsync();
        }
    }
}
