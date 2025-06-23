using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TvcLesson10EF.Models;

namespace TvcLesson10EF.Controllers
{
    public class TvcHomeController : Controller
    {
        private readonly ILogger<TvcHomeController> _logger;

        public TvcHomeController(ILogger<TvcHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult TvcIndex()
        {
            return View();
        }

        public IActionResult TvcAbout()
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
