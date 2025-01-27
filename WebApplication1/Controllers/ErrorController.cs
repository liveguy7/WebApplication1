using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;
        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;

        }
        public IActionResult HttpStatusCodeHander(int statusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "The Resource Cannot Be Found!";
                    _logger.LogWarning($"404 Error Occured. Path = {statusCodeResult.OriginalPath}");
                    break;
                    
            }
            return View("_Notfound");
        }

        [Route("Error")]
        [AllowAnonymous]
        public  IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            _logger.LogError($"The path {exceptionDetails.Path} threw an exception {exceptionDetails.Error}");

            return View("_Error");
        }
    }
}






