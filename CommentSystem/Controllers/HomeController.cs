using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CommentSystem.Models;
using CommentSystem.Data;
using Microsoft.AspNetCore.Identity;

namespace CommentSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _Context;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, 
            ApplicationDbContext applicationDbContext,
            UserManager<IdentityUser> userManager )
        {
            _logger = logger;
            _Context = applicationDbContext;
            _userManager = userManager;
        }

        public IActionResult Index()
        {

            ViewBag.Comment= _Context.Comments.OrderBy(x => x.CommentDate).ToList();
            var model = _Context.Comments.OrderBy(x => x.CommentDate).FirstOrDefault();
            return View(model);
        }
        public IActionResult CreateComments(Comment comment)
        {
            var cuurentuser = _userManager.GetUserName(User);
            if (ModelState.IsValid)
            {
                comment = new Comment()
                {
                    CommentText = comment.CommentText,
                    CommentDate = DateTime.Now,
                    Username = cuurentuser,
                };
                _Context.Add(comment);
                _Context.SaveChanges();
                ModelState.Clear();

            }
            return RedirectToAction("Index");
            
        }
    
        public IActionResult Privacy()
        {
            return View();
        }
    

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
