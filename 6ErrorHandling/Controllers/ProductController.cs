using _6ErrorHandling.Filters;
using Microsoft.AspNetCore.Mvc;

namespace _6ErrorHandling.Controllers
{
    [CustomHandleExceptionFilter(ErrorPage = "hata2")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            throw new Exception("veri tabanında bir hata meydana geldi");    
            return View();
        }
        //public IActionResult Hata2()
        //{

        //    return View();
        //}
    }
}
