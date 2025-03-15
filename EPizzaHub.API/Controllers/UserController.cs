using EPizzaHub.Core.Concrete;
using EPizzaHub.Core.Contracts;
using EPizzaHub.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPizzaHub.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        
        public async Task<IActionResult> GetAll()
        {
            var Userresponse = _userService.GetAllUsers();

            return Ok(Userresponse);

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest createUserReq)
        {
            if (ModelState.IsValid)
            {
                var createuser = _userService.Adduser(createUserReq);

                return Ok();
            }
            return BadRequest(ModelState.Select(x => x.Key));

        }
    }
}
