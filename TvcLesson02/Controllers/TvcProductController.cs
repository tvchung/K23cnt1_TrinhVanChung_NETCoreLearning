using Microsoft.AspNetCore.Mvc;

namespace TvcLesson02.Controllers
{
    public class TvcProductController : Controller
    {
        public IActionResult TvcIndex()
        {
            ViewData["messageData"] = "Dữ liệu từ viewData";
            ViewBag.messageData = "Dữ liệu từ ViewBag";
            TempData["messageData"] = "Dữ liệu từ TempData";
            return View();
        }
    }
}
