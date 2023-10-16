using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandlingMVC.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("Error/{statusCode}")]
        [AllowAnonymous] 
        public IActionResult Error(int statusCode)
        {
            var errorDetails = HttpContext.Features.Get<IExceptionHandlerFeature>();
            ViewBag.ErrorPath = errorDetails.Path;
            ViewBag.ErrorMessage = errorDetails.Error.Message;
            return View("Error");
        }


        
    }
}
