using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlaywrightSharp;
using ScreenshottingApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;

namespace ScreenshottingApp.Controllers
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Screenshot(string url)
        {
            var path = Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "browsers");
            var pw = await Playwright.CreateAsync(browsersPath: path);
            var chromium = await pw.Chromium.LaunchAsync();
            var page = await chromium.NewPageAsync();
            await page.GoToAsync(HttpUtility.UrlDecode(url));
            var screenshot = await page.ScreenshotAsync();

            return File(screenshot, "image/png");            
        }
    }
}
