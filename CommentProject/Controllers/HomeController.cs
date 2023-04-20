using CommentProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Diagnostics;

namespace CommentProject.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public HomeController(IConfiguration configuration, ILogger logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public IActionResult Index()
        {
            //var result = _configuration["AppName"];
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