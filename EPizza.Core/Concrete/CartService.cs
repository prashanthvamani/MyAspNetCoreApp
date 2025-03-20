using Azure.Core;
using EPizzaHub.Core.Contracts;
using EPizzaHub.Core.Mappers;
using EPizzaHub.Domain.Models;
using EPizzaHub.Models.Request;
using EPizzaHub.Models.Response;
using EPizzaHub.Repositories.Contracts;

namespace EPizzaHub.Core.Concrete
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<bool> AddToCartAsync(AddToCartRequest request)
        {
            var cartDetails = await _cartRepository.GetCartDetailsAsync(request.CartId);

            if (cartDetails == null)
            {
                int itemsAdded = AddNewCart(request);

                return itemsAdded > 0;
            }
            return false;
        }

        public async Task<CartResponseModel> GetCartDetailsAysnc(Guid CartId)
        {
            var cartdetails = await _cartRepository.GetCartDetailsAsync(CartId);

            if (cartdetails != null)
            {
                return cartdetails.ConvertToCartResponseModel();
            }

            return null;

        }

        private int AddNewCart(AddToCartRequest request)
        {
            Cart? cartDetails = new Cart
            {
                Id = request.CartId,
                UserId = request.UserId,
                CreatedDate = DateTime.UtcNow,
                IsActive = true,
            };

            CartItem item = new CartItem
            {
                CartId = request.CartId,
                ItemId = request.ItemId,
                UnitPrice = request.UnitPrice,
                Quantity = request.Quantity,
            };

            cartDetails.CartItems.Add(item);
            _cartRepository.Add(cartDetails);
            return _cartRepository.CommitChanges();
        }

     
    }
}
