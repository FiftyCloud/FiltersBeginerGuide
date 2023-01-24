using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Filters;
using MyBlog.Models;
using System.Diagnostics;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [TypeFilter(typeof(AuthFilter))]
        public IActionResult CreatePost()
        {
            return View();
        }

        [TypeFilter(typeof(LogExecutionTimeAttribute))]
        public IActionResult Index()
        {
            return View();
        }

        [AddHeader("X-Powered-By", "MyBlog")]
        public IActionResult Privacy()
        {
            return View();
        }

        [TypeFilter(typeof(LogErrorAttribute))]
        public IActionResult ThrowError()
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