using Microsoft.AspNetCore.Mvc;
using _2022_2023.Models;

namespace _2022_2023.Controllers
{
    public class Cau2Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LietKeChuyenBay(string MaCH)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(_2022_2023.Models.StoreContext)) as StoreContext;
            var (ChuyenBay, DanhSachHanhKhach) = context.LietKeChuyenBay(MaCH);
            return View((ChuyenBay, DanhSachHanhKhach));
            //StoreContext context = HttpContext.RequestServices.GetService(typeof(_2022_2023.Models.StoreContext)) as StoreContext;
            //return View(context.LietKeChuyenBay(mach));
        }

    }
}
