using _6ErrorHandling.Filters;
using _6ErrorHandling.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _6ErrorHandling.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //[CustomHandleExceptionFilter(ErrorPage ="hata1")]
        public IActionResult Index()
        {
            int value1 = 5, value2 = 0;
            int result = value1 / value2;
            return View();
        }
        //[CustomHandleExceptionFilter(ErrorPage = "hata2")]
        public IActionResult Privacy()
        {
            throw new FileNotFoundException("Dosya bulunamadư");
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.path = exception?.Path;
            ViewBag.message = exception.Error.Message;
            return View();
        }

        public IActionResult Hata1()
        {

            return View();
        }

        public IActionResult Hata2()
        {

            return View();
        }

    }
}
