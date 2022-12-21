using DotNetWelcome.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DotNetWelcome.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string? Email)
        {
            if(Email != null)
            {
                ViewBag.Email = Email;
            }
            SubmitModel model = new SubmitModel();

            return View(model);
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
        public IActionResult SubmitEmail(SubmitModel model)
        {
            return RedirectToAction("Index",new { Email =model.Email});
        }
    }
}