using Fitly_Domain.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Fitly_Domain.Persistence.TypeMapper;

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
            
            return _persistenceController.GetWorkouts();
        }
        public List<Oefening> GetOefeningsFromDB(int workoutId)
        {
            
            return _persistenceController.GetOefeningsFromDB(workoutId);
        }
        public void AddSporter(Sporter sporters)
        {
           
            _persistenceController.AddSporter(sporters);


        }
        public void DeleteSporter(Sporter sporter)
        {
           
            _persistenceController.DeleteSporter(sporter);
        }
        public Sporter GetSporterById(int id)
        {
           
            return _persistenceController.GetSporterById(id);
        }
        public void UpdatedSporter(Sporter sporter)
        {
            
            _persistenceController.UpdatedSporter(sporter);
        }
        public List<Oefening> GetOefeningsById(List<int> OefeningenId)
        {
         

            return _persistenceController.GetOefeningsById(OefeningenId);
        }
        public double VoegCalorieënToeAanSporter(Sporter sporter, List<Oefening> oefeningen)
        {
          
            return _persistenceController.VoegCalorieënToeAanSporter(sporter, oefeningen);
        }
        public Sporter GetSporterByEmailAndPassword(string email, string wachtwoord)
        {
           

            return _persistenceController.GetSporterByEmailAndPassword(email, wachtwoord);
        }
        public void AddWorkoutToDB(Workout newWorkout)
        {
            
            _persistenceController.AddWorkoutToDB(newWorkout);
        }
        public int AddOefeningToDB(Oefening oef, int workoutId)
        {
            

            return _persistenceController.AddOefeningToDB(oef, workoutId);
        }
        public List<OefeningType> GetAllTypes()
        {
            
            return _persistenceController.GetAllTypes();
        }
        public List<Oefening> GetAllOefeningen()
        {
           

            return _persistenceController.GetAllOefeningen();
        }
        public void VerwijderOefening(int oefeningId)
        {
            

            _persistenceController.VerwijderOefening(oefeningId);

        }
        public void VerwijderWorkout(int workoutId)
        {
            WorkoutMapper workoutMapper = new WorkoutMapper();
            workoutMapper.VerwijderWorkout(workoutId);
        }
    }
}
