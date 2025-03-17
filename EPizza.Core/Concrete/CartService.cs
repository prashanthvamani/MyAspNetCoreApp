using EPizzaHub.Core.Contracts;
using EPizzaHub.Core.Mappers;
using EPizzaHub.Domain.Models;
using EPizzaHub.Models.Request;
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

        public async Task<bool> AddItemtoCartAsyn(AddtoCartRequest request)
        {
            var cartdetails = await _cartRepository.GetCartAsync(request.Cartid);

            if(cartdetails == null)
            {
                //int itemsadded = AddNewCart(request);

                int itemsadded = AddNewCart(request);

                return itemsadded > 0;
            }
            return false;

        }

        public async Task<CartResponseModel> GetCartdetailsAysn(Guid cartId)
        {
            var cartdetails = await _cartRepository.GetCartAsync(cartId);

            if(cartdetails != null)
            {
                 return cartdetails.ConverttoUserResponseModel();
            }

            return null;
        }

        private int  AddNewCart(AddtoCartRequest request)
        {
            Cart? cartdetails = new Cart
            {
                Id = request.Cartid,
                UserId = request.Userid,
                CreatedDate = DateTime.UtcNow,
                IsActive = true,
            };
            CartItem items = new CartItem
            {
                CartId = request.Cartid,
                ItemId = request.Itemid,
                UnitPrice = request.Unitprice,
                Quantity = request.Quantity,
            };

            cartdetails.CartItems.Add(items);
            _cartRepository.Add(cartdetails);
            return _cartRepository.CommitChanges();
        }
    }
}
