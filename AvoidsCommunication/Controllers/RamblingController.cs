using AvoidsCommunication.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AvoidsCommunication.Controllers
{
    public class RamblingController : Controller
    {

        IRamblingService _ramblingService;

        public RamblingController(IRamblingService ramblingService)
        {
            _ramblingService = ramblingService;
        }

        public async Task<ActionResult> RamblingPage(int id)
        {
            var response = await _ramblingService.GetRambling(id);
            return View(response.Data);
        }
    }
}
