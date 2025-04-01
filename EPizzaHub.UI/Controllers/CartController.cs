using EPizzaHub.UI.Models.APIRequests;
using EPizzaHub.UI.Models.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace EPizzaHub.UI.Controllers
{
    [Route("Cart")]
    public class CartController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<CartController> _logger;
        public CartController(IHttpClientFactory httpClientFactory, ILogger<CartController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        Guid CartId
        {
            get
            {
                Guid id;
                string CartId = Request.Cookies["CartId"];
                if (CartId == null)
                {
                    id = Guid.NewGuid();
                    Response.Cookies.Append(
                        "CartId", id.ToString(),
                            new CookieOptions
                            {
                                Expires = DateTime.Now.AddDays(1)
                            });
                }
                else
                {
                    id = Guid.Parse(CartId);
                }
                return id;
            }
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            using var httpClient = _httpClientFactory.CreateClient("ePizaaApiClient");

            var CartItems = await httpClient.GetFromJsonAsync<ApiResponseModel<GetCartResponseModel>>($"api/Cart/get-cart-details?cartid={CartId}");

            return View(CartItems.Data);
        }

        [HttpGet("AddToCart/{itemid:int}/{price:decimal}/{quantity:int}")]
        public async Task<IActionResult> AddtoCart(int itemid,decimal price,int quantity)
        {
            //using var httpClient = _httpClientFactory.CreateClient("ePizaaApiClient");
            using var httpClient = _httpClientFactory.CreateClient("ePizaaApiClient");

            AddToCartRequest addtocard = new AddToCartRequest()
            {
                Itemid = itemid,
                Unitprice = price,
                Quantity = quantity,
                Cartid = CartId
            };

            var AdditemToCart = await httpClient.PostAsJsonAsync<AddToCartRequest>("api/Cart/Add-item-to-cart", addtocard);


            return Json(new { Count = 1 });

        }

        [HttpGet("Checkout")]
        public IActionResult Checkout()
        {
            return View();
        }
    }
}
