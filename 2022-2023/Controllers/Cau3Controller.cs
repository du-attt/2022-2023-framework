using _2022_2023.Models;
using Microsoft.AspNetCore.Mvc;

namespace _2022_2023.Controllers
{
    public class Cau3Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ThemHanhKhachVaoChuyenBay(string MaCH, string MaHK, string SoGhe, string LoaiGhe)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(_2022_2023.Models.StoreContext)) as StoreContext;
            return View(context.ThemHanhKhachVaoChuyenBay(MaCH, MaHK, SoGhe, LoaiGhe));
        }
        public IActionResult TrangSua(string HoTen, string MaHK, string MaCH)
        {
            ViewBag.MaCH = MaCH;
            ViewBag.HoTen = HoTen;
            ViewBag.MaHK = MaHK;
            return View();
        }
        public void SuaHanhKhach(string MaCH, string MaHK, string SoGhe, string LoaiGhe)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(_2022_2023.Models.StoreContext)) as StoreContext;
            context.SuaHanhKhach(MaCH, MaHK, SoGhe, LoaiGhe);
        }
        public void XoaHanhKhach(string MaCH, string MaHK)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(_2022_2023.Models.StoreContext)) as StoreContext;
            context.XoaHanhKhach(MaCH, MaHK);
        }
    }
 
}
