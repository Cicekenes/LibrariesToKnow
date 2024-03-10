using _5Hangfire.BackgroundJobs;
using _5Hangfire.Models;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _5Hangfire.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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

        public IActionResult SignUp()
        {
            //Üyelik kayýt iþlemi bu methodda gerçekleþiyor.

            FireAndForgetJobs.EmailSendToUserJob("1234", "Sitemize hoþgeldiniz");
            return View();
        }

        public IActionResult PictureSave()
        {
            BackgroundJobs.RecurringJobs.ReportingJob();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PictureSave(IFormFile picture)
        {
            string newFileName = String.Empty;
            if (picture != null && picture.Length > 0)
            {
                newFileName = Guid.NewGuid().ToString() + Path.GetExtension(picture.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/lib/pictures", newFileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await picture.CopyToAsync(stream);
                }

                string jobId = DelayedJobs.AddWaterMarkJob(newFileName, "www.mysite.com");
                BackgroundJobs.ContinuationsJobs.WriteWatermarkStatusJob(jobId, newFileName);
            }
            return View();
        }
    }
}
