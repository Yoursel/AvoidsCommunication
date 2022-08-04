using AvoidsCommunication.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AvoidsCommunication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRamblingService _ramblingService;

        public HomeController(IRamblingService ramblingService)
        { 
            _ramblingService = ramblingService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var response = _ramblingService.GetRamblings();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return View();
        }
    }
}
