using EPizzaHub.UI.Models;
using EPizzaHub.UI.Models.ApiResponses;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EPizzaHub.UI.Controllers
{
    public class LoginController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public LoginController(IHttpClientFactory httpClientFactory)
        {
             _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async  Task<ActionResult> Login(Login loginmodel)
        {
            if(ModelState.IsValid)
            {
                var APIClient = _httpClientFactory.CreateClient("ePizaaApiClient");

                //var userResponse = await APIClient.GetFromJsonAsync<bool>($"api/Auth/ValidateUser?username={loginmodel.Username}&password={loginmodel.Password}");

                var userResponse = await APIClient.GetFromJsonAsync<ApiResponseModel<ValidateUserResponseModel>>(
                    $"api/Auth/ValidateUser?username={loginmodel.Username}&password={loginmodel.Password}");

                
                if (userResponse.Success) 
                {
                    var accessToken = userResponse.Data.AccessToken;

                    var Tokenhandler = new JwtSecurityTokenHandler();


                    var tokendetails = Tokenhandler.ReadToken(accessToken) as JwtSecurityToken;



                    //List<Claim> claims = new List<Claim>();
                    //var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    //var principal = new ClaimsPrincipal(identity);
                    //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                    //{
                    //    IsPersistent = true,
                    //    ExpiresUtc = DateTime.UtcNow.AddMinutes(60)
                    //});

                    List<Claim> claims = new List<Claim>();

                    foreach(var item in tokendetails.Claims)
                    {
                        claims.Add(new Claim(item.Type,item.Value));
                    }
                    await GenerateTicket(claims);


                    //HttpContext.Session.SetString("Usersname", loginmodel.Username);

                    //return RedirectToAction("Welcome");

                    bool IsAdmin = Convert.ToBoolean(claims.Where(x => x.Type == "IsAdmin").FirstOrDefault().Value);

                    if(IsAdmin)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home", new { area = "User" });
                    }
                }
                else
                {
                    ModelState.AddModelError("Error","InvalidCredentilas");
                }
            }
            return View(); 
        }

        private async Task GenerateTicket(List<Claim> claims)
        {
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                new AuthenticationProperties()
                {
                    IsPersistent = false,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(60)
                });
        }

        [HttpGet]
        [Authorize]
        public IActionResult Welcome()
        {
            string message = null;

            if(HttpContext.Session != null)
            {
                message = HttpContext.Session.GetString("Usersname");
                if(string.IsNullOrEmpty(message))
                {
                    message = "Session Time Out";
                }
            }
            ViewData["Message"] = message;
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");
        }
    }
}
