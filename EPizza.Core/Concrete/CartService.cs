using EPizzaHub.Core.Contracts;
using EPizzaHub.Domain.Models;
using EPizzaHub.Models.Response;
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

        public async Task<CartResponseModel> GetCartdetailsAysn(Guid cartId)
        {
            var cartdetails = await _cartRepository.GetCartAsync(cartId);

            if(cartdetails != null)
            {
                CartResponseModel response = new CartResponseModel();

                response.Id = cartdetails.Id;
                response.UserId = cartdetails.UserId;
                response.CreatedDate = cartdetails.CreatedDate;
                response.Items = cartdetails.CartItems.Select(
                    x => new CartItemFResponse
                    {
                        Id = x.Id,
                        ItemId = x.ItemId,
                        Quantity = x.Quantity,
                        UnitPrice = x.UnitPrice,
                    }).ToList();
                response.Total = response.Items.Sum(x => x.Quantity * x.UnitPrice);
                response.Tax = Math.Round(response.Total * 0.05m, 2);
                response.Grandtotal = response.Total + response.Tax;

                return response;
            }

            return null;
        }
    }
}
