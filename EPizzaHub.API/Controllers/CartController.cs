using EPizzaHub.Core.Contracts;
using EPizzaHub.Models.Request;
using EPizzaHub.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPizzaHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }


        [HttpGet]
        [Route("get-cart-details")]
        public async Task<IActionResult> GetCartItemsDetailsAsync(Guid cartid)
        {
            var data = await _cartService.GetCartDetailsAysnc(cartid);
            return Ok(data);
        }

        [HttpPost]
        [Route("Add-item-to-cart")]
        public async Task<IActionResult> AddItemCart([FromBody]AddToCartRequest addToCart)
        {
            var additemcart = await _cartService.AddToCartAsync(addToCart);
            return Ok(additemcart);
        }

    }
}
