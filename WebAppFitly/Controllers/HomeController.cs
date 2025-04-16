using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppFitly.Models;
using Fitly_Domain;
using Fitly_Domain.Business;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;


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
        
       

        public IActionResult Index()
        {
            var workouts = _controller.GetWorkouts(); 
            return View(workouts); 
        }
        public IActionResult Sporter()
        {
            return View(_controller.GetDeelnemers());
        }
        public IActionResult CreateEditSporter()
        {

            return View();

        }
        public IActionResult Oefeningen(int workoutId)
        {
            var oefeningen = _controller.GetOefeningsFromDB(workoutId);

            return View(oefeningen);
        }
        public IActionResult DeleteSporter(Sporter sporter)
        {
            _controller.DeleteSporter(sporter);
            View(_controller.GetDeelnemers());
            return RedirectToAction("sporter");
            
        }
        public IActionResult CreateEditSporterForm(Sporter sporter)
        {
            _controller.AddSporter(sporter);
            View(_controller.GetDeelnemers());
            return RedirectToAction("index");

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
