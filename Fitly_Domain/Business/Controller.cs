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

    }
}
