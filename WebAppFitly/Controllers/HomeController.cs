using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppFitly.Models;
using Fitly_Domain;
using Fitly_Domain.Business;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System.Linq;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using Microsoft.AspNetCore.Authorization;
using WebAppFitly.Data;
using Org.BouncyCastle.Utilities;
using Google.Protobuf.WellKnownTypes;





namespace WebAppFitly.Controllers
{

    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Fitly_Domain.Business.Controller _controller;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;




        public IActionResult LoginSporter()
        {
            return View();
        }

        public HomeController(UserManager<IdentityUser> userManager, ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _controller = new Fitly_Domain.Business.Controller();
            _userManager = userManager;
            _context = context;
        }


        public IActionResult Index()
        {
            int? sporterId = HttpContext.Session.GetInt32("SporterId");

            if (sporterId != null)
            {
                return RedirectToAction("Progressie");
            }

            else
            {
                return View();
            }

        }
        public IActionResult Workout()
        {
            int? sporterId = HttpContext.Session.GetInt32("SporterId");

            if (sporterId == null)
                return RedirectToAction("LoginSporter");

            var workouts = _controller.GetWorkouts();
            return View(workouts);
        }

        public IActionResult Sporter()
        {
            return View(_controller.GetDeelnemers());
        }


        public IActionResult EditSporter(int id)
        {

            var sporter = _controller.GetSporterById(id);
            return View("EditSporter", sporter);
        }

        [HttpPost]
        public IActionResult EditSporter(Sporter model)
        {

            _controller.UpdatedSporter(model);
            return RedirectToAction("Index");
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
        public IActionResult CreateEditSporter(Sporter sporter)
        {
            return View(sporter);


        }



        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult GekozenOefeningen(List<int> gekozenOefeningen)
        {
            if (gekozenOefeningen == null || !gekozenOefeningen.Any())
            {
                return View(new List<Oefening>());
            }

            List<Oefening> oefeningen = _controller.GetOefeningsById(gekozenOefeningen);
            return View(oefeningen);
        }



        [HttpPost]
        public IActionResult SlaCalorieënOp(List<Oefening> oefeningen)
        {

            int? sporterId = HttpContext.Session.GetInt32("SporterId");

            if (sporterId == null)
            {

                return RedirectToAction("LoginSporter");
            }
            Sporter sporter = _controller.GetSporterById(sporterId.Value);
            if (sporter == null)
            {
                return NotFound("Sporter niet gevonden.");
            }


            _controller.VoegCalorieënToeAanSporter(sporter, oefeningen);
            _controller.UpdatedSporter(sporter);


            return RedirectToAction("Index");
        }

        public IActionResult Login(Sporter model)
        {
            Sporter sporter = _controller.GetSporterByEmailAndPassword(model.MailSporter, model.Wachtwoord);

            if (sporter != null)
            {
                HttpContext.Session.SetInt32("SporterId", sporter.Id);
                HttpContext.Session.SetString("SporterNaam", sporter.NaamSporter);

                return RedirectToAction("Workout");
            }
            else
            {

                ModelState.AddModelError(string.Empty, "Email of wachtwoord is ongeldig.");
                return View("LoginSporter", model);
            }
        }
        public IActionResult Progressie()
        {
            int? sporterId = HttpContext.Session.GetInt32("SporterId");

            if (sporterId == null)
                return RedirectToAction("LoginSporter");

            var sporter = _controller.GetSporterById(sporterId.Value);
            if (sporter == null)
                return NotFound();

            return View(sporter);
        }
        public IActionResult Logout()
        {

            HttpContext.Session.Remove("SporterId");




            return RedirectToAction("Index");
        }
        public IActionResult AddDeleteChangeWorkout()
        {
            var model = new BeheerWorkoutsViewModel
            {
                Workouts = _controller.GetWorkouts().ToList(),
                OefeningTypes = _controller.GetAllTypes().ToList(),
                Oefenings = _controller.GetAllOefeningen().ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult VoegWorkoutToe(string workoutNaam)
        {
            if (string.IsNullOrWhiteSpace(workoutNaam))
            {

                return RedirectToAction("Index");
            }

            var workout = new Workout
            {
                Naamworkout = workoutNaam

            };

            _controller.AddWorkoutToDB(workout);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult VoegOefeningToe(int workoutId, string Naam, string Omschrijving, int Calorieën, int FkType, int Herhalingen)
        {
            if (string.IsNullOrWhiteSpace(Naam) || workoutId <= 0 || FkType <= 0)
            {
                TempData["Error"] = "Vul alle verplichte velden correct in.";
                return RedirectToAction("AddDeleteChangeWorkout");
            }

            var oefening = new Oefening
            {
                Naam = Naam,
                Omschrijving = Omschrijving,
                Calorieën = Calorieën,
                Herhalingen = Herhalingen,

                FKType = FkType

            };

            _controller.AddOefeningToDB(oefening);

            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult VerwijderWorkout(int workoutId)
        {
            if (workoutId > 0)
            {
                _controller.VerwijderWorkout(workoutId); 
            }

            return RedirectToAction("Index");
        }


        public IActionResult VerwijderOefening(int oefeningId)
        {
            if (oefeningId > 0)
            {
                _controller.VerwijderOefening(oefeningId);
            }

            return RedirectToAction("Index");
        }
    }
    }
