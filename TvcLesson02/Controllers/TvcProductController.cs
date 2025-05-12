using Microsoft.AspNetCore.Mvc;
using TvcLesson02.Models;

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
        public IActionResult TvcGetProduct()
        {
            TvcProduct p = new TvcProduct()
            {
                tvcProductId=1,
                tvcProductName="IPhone 16 Pro Max",
                tvcYearRelease=2025,
                tvcPrice=1600f
            };
            ViewData["tvcProduct"] = p;
            return View();
        }
    }
}
