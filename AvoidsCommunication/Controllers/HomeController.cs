
using AvoidsCommunication.DAL;
using Microsoft.AspNetCore.Mvc;

namespace AvoidsCommunication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
