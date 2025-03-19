using EPizzaHub.Core.Contracts;
using EPizzaHub.Domain.Models;
using EPizzaHub.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPizzaHub.Core.Concrete
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<CartItem> GetCartItemAsync(Guid CartId)
        {
            var cartdetails = await _cartRepository.GetCartDetailsAysnc(CartId);

            if(cartdetails !=null)
            {
                return cartdetails.con
            }
            return null;
        }
    }
}
