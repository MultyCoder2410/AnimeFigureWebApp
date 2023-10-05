using AnimeFigureWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AnimeFigureWebApp.Controllers
{

    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {

            _logger = logger;

        }

        /// <summary>
        /// Shows Index page
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Index()
        {

            return View();

        }

        /// <summary>
        /// Gives back error view.
        /// </summary>
        /// <returns>View with ErrorViewModel</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() { return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }); }

    }

}