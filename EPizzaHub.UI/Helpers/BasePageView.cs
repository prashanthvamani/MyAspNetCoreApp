using EPizzaHub.UI.Models;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Security.Claims;

namespace EPizzaHub.UI.Helpers
{
    public abstract class BasePageView<TModel>: RazorPage<TModel>
    {
        public UserModel CurrentUser
        {
            get
            {
                if (User.Claims.Count() > 0)
                {
                    string Username = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
                    string Email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;

                    return new UserModel
                    {
                        Email = Email,
                        Name = Username
                    };
                }
                return null;
            }
        }
    }
}
