using EPizzaHub.Core.Contracts;
using EPizzaHub.Core.JWTToken;
using EPizzaHub.Models.Response;
using EPizzaHub.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPizzaHub.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly Token _token;

        public AuthController(IAuthService authService,Token token)
        {
            _authService = authService;
            _token = token;
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult ValidateUser(string username,string password)
        {
            var check = _authService.CheckUser(username, password);

            if(check != null)
            {
                var securitytoken = _token.GenerateToken(check);
                var response = new AuthApiResponse
                {
                    AccessToken = securitytoken
                };

                //var commonresponse = new ApiResponseModel<AuthApiResponse>
                //{
                //    Data = response,
                //    Message = "User is Valid",
                //    Success = true
                    
                //};

                return Ok(response);
            }

            return BadRequest("User Response is not valid");
        }

    }
}
