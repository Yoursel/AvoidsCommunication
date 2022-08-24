using System.IO;
using AvoidsCommunication.Domain.ViewModel.Comment;
using AvoidsCommunication.Domain.ViewModel.Rambling;
using AvoidsCommunication.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AvoidsCommunication.Controllers
{
    public class RamblingController : Controller
    {

        IRamblingService _ramblingService;
        ICommentService _commentService;

        public RamblingController(IRamblingService ramblingService, ICommentService commentService)
        {
            _ramblingService = ramblingService;
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<ActionResult> RamblingPage(int id)
        {
            var rambling = await _ramblingService.GetRambling(id);

            var comment = new CommentViewModel();
            var response = new RamblingPageViewModel();

            response.Rambling = rambling;
            response.Comment = comment;
            return View(response);
        }


        //[HttpPost]
        //public async Task<IActionResult> CreateComment(CommentViewModel model, int id)
        //{
        //    ClaimsPrincipal currentUser = this.User;
        //    var currentUserID = currentUser.Identity.Name;

        //    if (ModelState.IsValid)
        //    {
        //        if (model.CommentId == 0)
        //        {
        //            await _commentService.Create(model, currentUserID);
        //        }
        //        else
        //        {
        //            await _commentService.Edit(model.CommentId, model);
        //        }
        //        return RedirectToAction("RamblingPage", "Rambling", new { id = model.RumblingId });
        //    }

        //    var rambling = await _ramblingService.GetRambling(id);

        //    var comment = new CommentViewModel();
        //    var response = new RamblingPageViewModel();

        //    response.Rambling = rambling;
        //    response.Comment = comment;

        //    return Redirect("~/Home/Index");
        //}

        [HttpGet]
        public IActionResult CreateRambling() => View();

        [HttpPost]
        public async Task<IActionResult> CreateRambling(RamblingViewModel model)
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.Identity.Name;
            if (ModelState.IsValid)
            {
                if (model.RamblingId == 0)
                {
                    byte[] imageData = null;

                    if (model.Image != null)
                    {
                        using (var binaryReader = new BinaryReader(model.Image.OpenReadStream()))
                        {
                            imageData = binaryReader.ReadBytes((int)model.Cover.Length);
                        }
                    }
                    await _ramblingService.Create(model, imageData, currentUserID );
                }
                else
                {
                   // await _ramblingService.Edit(model.RamblingId, model);
                }
                return Redirect("~/Home/Index");
            }
            return View();
        }

    }
}