using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppFitly.Models;
using Fitly_Domain;
using Fitly_Domain.Business;


namespace WebAppFitly.Controllers
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Fitly_Domain.Business.Controller _controller;

        
        
        

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _controller = new Fitly_Domain.Business.Controller();
        }
        public IActionResult Sporter()
        {
            return View(_controller.GetDeelnemers());
        }
        public IActionResult CreateEditSporter()
        {

            return View();

        }
        public IActionResult CreateEditSporterForm(Sporter sporter)
        {
            _controller.AddSporter(sporter);
            View(_controller.GetDeelnemers());
            return RedirectToAction("index");

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
    }
}
