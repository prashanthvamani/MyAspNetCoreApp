using EPizzaHub.Core.Contracts;
using EPizzaHub.Domain.Models;
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

        public async Task<CartResponseModel> GetCartDetailsAysnc(Guid CartId)
        {
            var cartdetails = await _cartRepository.GetCartDetailsAysnc(CartId);

            if (cartdetails != null)
            {
                CartResponseModel response = new CartResponseModel();

                response.Id = cartdetails.Id;
                response.Userid = cartdetails.UserId;
                response.CreatedDate = cartdetails.CreatedDate;
                response.Items = cartdetails.CartItems.Select(
                    x => new CartItemResponse
                    {
                        Id = x.Id,
                        Itemid = x.ItemId,
                        Quantity = x.Quantity,
                        UnitPrice = x.UnitPrice
                    }).ToList();

                response.Total = response.Items.Sum(x => x.Quantity * x.UnitPrice);
                response.Tax = Math.Round(response.Total * 0.05m, 2);
                response.GrandTotal = response.Total + response.Tax;

                return response;
            }

            return null;

        }
    }
}
