using Microsoft.AspNetCore.Mvc;
using TvcLesson07.Models;

namespace TvcLesson07.Controllers
{
    public class TvcEmployeeController : Controller
    {
        private static List<TvcEmployee> tvcListEmployees = new List<TvcEmployee>
        {
            new TvcEmployee { TvcId = 230001122, TvcName = "Chung Trịnh", TvcBirthDay = new DateTime(1979, 5, 25), TvcEmail = "chungtrinhj@gmail.com", TvcPhone = "0978611889", TvcSalary = 12000000, TvcStatus = true },
            new TvcEmployee { TvcId = 2, TvcName = "Trần Thị B", TvcBirthDay = new DateTime(1992, 5, 15), TvcEmail = "b@example.com", TvcPhone = "0912233445", TvcSalary = 15000000, TvcStatus = true },
            new TvcEmployee { TvcId = 3, TvcName = "Lê Văn C", TvcBirthDay = new DateTime(1988, 9, 20), TvcEmail = "c@example.com", TvcPhone = "0922123456", TvcSalary = 11000000, TvcStatus = false },
            new TvcEmployee { TvcId = 4, TvcName = "Phạm Thị D", TvcBirthDay = new DateTime(1995, 3, 10), TvcEmail = "d@example.com", TvcPhone = "0933445566", TvcSalary = 13000000, TvcStatus = true },
            new TvcEmployee { TvcId = 5, TvcName = "Đỗ Văn E", TvcBirthDay = new DateTime(1991, 7, 25), TvcEmail = "e@example.com", TvcPhone = "0944567890", TvcSalary = 10000000, TvcStatus = false }
        };
        public IActionResult TvcIndex()
        {
            return View(tvcListEmployees);
        }

        // GET: /TvcEmployee/TvcCreate
        public IActionResult TvcCreate()
        {
            var tvcModel = new TvcEmployee();
            return View(tvcModel);
        }

        // POST: /TvcEmployee/TvcCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TvcCreate(TvcEmployee tvcModel)
        {
            try
            {
                // Tự động sinh mã nếu cần
                if (tvcModel.TvcId == 0)
                {
                    tvcModel.TvcId = tvcListEmployees.Max(e => e.TvcId) + 1;
                }
                tvcListEmployees.Add(tvcModel);
                return RedirectToAction(nameof(TvcIndex));
            }
            catch
            {
                return View();
            }
        }


        //  GET: /TvcEmployee/TvcEdit/5
        public IActionResult TvcEdit(int id)
        {
            var tvcModel = tvcListEmployees.FirstOrDefault(x => x.TvcId == id);
            return View(tvcModel);
        }
        // POST: TvcEmployee/TvcEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TvcEdit(int id, TvcEmployee tvcModel)
        {
            try
            {
                // cập nhật model vào danh sách 
                for (int i = 0; i < tvcListEmployees.Count; i++)
                {
                    if (tvcListEmployees[i].TvcId == id)
                    {
                        tvcListEmployees[i] = tvcModel;
                        break;
                    }
                }
                return RedirectToAction(nameof(TvcIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: TvcEmployee/TvcDetails/5
        public ActionResult TvcDetails(int id)
        {
            var tvcModel = tvcListEmployees.FirstOrDefault(x => x.TvcId == id);
            return View(tvcModel);
        }


        // GET: TvcEmployee/TvcDelete/5
        public ActionResult TvcDelete(int id)
        {
            var tvcModel = tvcListEmployees.FirstOrDefault(x => x.TvcId == id);
            return View(tvcModel);
        }

        // POST: TvcEmployee/TvcDelete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TvcDelete(int id, TvcEmployee tvcModel)
        {
            try
            {
                // cập nhật xóa model khỏi danh sách
                for (int i = 0; i < tvcListEmployees.Count; i++)
                {
                    if (tvcListEmployees[i].TvcId == id)
                    {
                        tvcListEmployees.RemoveAt(i);
                        break;
                    }
                }
                return RedirectToAction(nameof(TvcIndex));
            }
            catch
            {
                return View();
            }
        }
    }
}
