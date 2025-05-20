using Microsoft.AspNetCore.Mvc;
using TvcLesson05Model.Models.DataModels;

namespace TvcLesson05Model.Controllers
{
    public class TvcMemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TvcGetMember()
        {
            var tvcMember = new TvcMember();
            tvcMember.TvcMemberId = Guid.NewGuid().ToString();
            tvcMember.TvcUserName = "ChungChung";
            tvcMember.TvcFullName = "Trịnh Văn Chung";
            tvcMember.TvcPassword = "123456a@";
            tvcMember.TvcEmail = "chungtrinhj@gmail.com";

            ViewBag.tvcMember = tvcMember;
            return View();
        }
    }
}
