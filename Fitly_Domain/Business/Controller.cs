using Fitly_Domain.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitly_Domain.Business
{
    public class Controller
    {
        private PersistenceController _persistenceController;


        public Controller()
        {
            _persistenceController = new PersistenceController();
            SporterRepository.SporterLijst = _persistenceController.GetDeelnemers();
            WorkoutRepository.WorkoutLijst = _persistenceController.GetWorkouts();

        }
        public List<Sporter> GetDeelnemers()
        { return SporterRepository.SporterLijst; }
        public List<Workout> GetWorkouts()
        {
            _persistenceController = new PersistenceController();
            return _persistenceController.GetWorkouts();
        }
        public List<Oefening> GetOefeningsFromDB(int workoutId)
        {
            _persistenceController = new PersistenceController();
            return _persistenceController.GetOefeningsFromDB(workoutId);
        }
        public void AddSporter(Sporter sporters)
        {
            _persistenceController = new PersistenceController();
            _persistenceController.AddSporter(sporters);


        }
        public void DeleteSporter(Sporter sporter)
        {
            _persistenceController = new PersistenceController();
            _persistenceController.DeleteSporter(sporter);
        }
        public Sporter GetSporterById(int id)
        {
            _persistenceController = new PersistenceController();
            return _persistenceController.GetSporterById(id);
        }
        public void UpdatedSporter(Sporter sporter)
        {
            _persistenceController = new PersistenceController();
            _persistenceController.UpdatedSporter(sporter);
        }
        public List<Oefening> GetOefeningsById(List<int> OefeningenId)
        {
            _persistenceController = new PersistenceController();

            return _persistenceController.GetOefeningsById(OefeningenId);
        }
        public double VoegCalorieënToeAanSporter(Sporter sporter, List<Oefening> oefeningen)
        {
            _persistenceController = new PersistenceController();
            return _persistenceController.VoegCalorieënToeAanSporter(sporter, oefeningen);
        }
        public Sporter GetSporterByEmailAndPassword(string email, string wachtwoord)
        {
            _persistenceController = new PersistenceController();

            return _persistenceController.GetSporterByEmailAndPassword(email, wachtwoord);
        }
    }
}
