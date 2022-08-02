using Microsoft.AspNetCore.Mvc;

namespace AvoidsCommunication.Controllers
{
    public class LogInController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
