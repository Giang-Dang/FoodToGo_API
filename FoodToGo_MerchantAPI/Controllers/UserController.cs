using Microsoft.AspNetCore.Mvc;

namespace FoodToGo_API.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
