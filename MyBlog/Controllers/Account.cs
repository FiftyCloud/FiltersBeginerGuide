using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers
{
    public class Account : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
