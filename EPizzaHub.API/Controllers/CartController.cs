using EPizzaHub.Core.Contracts;
using EPizzaHub.Models.Request;
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
        public async Task<IActionResult> GetCartDetails(Guid cartid)
        {
            var cartdata = await _cartService.GetCartdetailsAysn(cartid);
            
            return Ok(cartdata);
        }

        [HttpPost]
        [Route("Add-Item-to-Cart")]
        public async Task<IActionResult> AdditemtoCart(AddtoCartRequest addtoCartRequest)
        {
            var addcartitem = await _cartService.AddItemtoCartAsyn(addtoCartRequest);

            return Ok(addcartitem);

        }
    }
}
