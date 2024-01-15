using _2022_2023.Models;
using Microsoft.AspNetCore.Mvc;

namespace _2022_2023.Controllers
{
    public class Cau1Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ThemHanhKhach(HanhKhach hk)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(_2022_2023.Models.StoreContext)) as StoreContext;
            context.ThemHanhKhach(hk);
            return View("index");
        }
    }
}
