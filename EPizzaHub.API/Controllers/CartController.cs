using EPizzaHub.Core.Contracts;
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
        public async Task<IActionResult> GetCartDetails(Guid cartid)
        {
            var cartdata = await _cartService.GetCartdetailsAysn(cartid);
            
            return Ok(cartdata);
        }
    }
}
