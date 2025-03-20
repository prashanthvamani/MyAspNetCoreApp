using EPizzaHub.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPizzaHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }


        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetCartItemsDetailsAsync(Guid cartid)
        {
            var data = await _cartRepository.GetCartDetailsAysnc(cartid);
            return Ok(data);
        }

    }
}
