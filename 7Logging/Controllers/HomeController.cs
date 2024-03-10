using _7Logging.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _7Logging.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly ILoggerFactory _loggerFactory;

        public HomeController(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public IActionResult Index()
        {
            
            var _logger = _loggerFactory.CreateLogger("HomeSýnýfý");
            _logger.LogTrace("Index sayfasýna girildi");
            _logger.LogDebug("Index sayfasýna girildi");
            _logger.LogWarning("Index sayfasýna girildi");
            _logger.LogInformation("Index sayfasýna girildi");
            _logger.LogError("Index sayfasýna girildi");
            _logger.LogCritical("Index sayfasýna girildi");
            return View();
        }

        public IActionResult Privacy()
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

//Build-in Logging Provider
//Console Provider,
//Debug Provider,
//Azure Application,
//Insights Provider

//Logging levels
//Trace(0)
//Debug(1)
//Information(2)
//Warning(3)
//Error(4)
//Critical(5)

//3.Parti loglama araçlarý
//NLog
//SeriLog
//elmah.io
//Gelf
//JSNLog
//KissLog
//Loggr