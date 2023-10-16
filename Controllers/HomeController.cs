using ErrorHandlingMVC.Exceptions;
using ErrorHandlingMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ErrorHandlingMVC.Controllers
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

        public IActionResult Privacy(string num)
        {
           if(num == null)
            {
                throw new CustomException("The value cannot be null");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}