using Microsoft.AspNetCore.Mvc;

namespace EPizzaHub.UI.Areas.User.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
