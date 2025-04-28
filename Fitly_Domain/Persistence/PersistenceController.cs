using Fitly_Domain.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Fitly_Domain.Persistence
{
    internal class PersistenceController
    {
        private string _connectionString;
        public PersistenceController()
        {
            _connectionString = "server = localhost; user id = root; password=1234;database=koshrun";
        }
        public PersistenceController(string connstring)
        {
            _connectionString = connstring;
        }
        public List<Sporter> GetDeelnemers()
        {
            SporterMapper mapper = new SporterMapper();
            return mapper.GetDeelnemersFromDB();
        }
        public List<Workout> GetWorkouts()
        {
            WorkoutMapper mapper = new WorkoutMapper();
            return mapper.LoadWorkoutsFromDB();
        }
        public List<Oefening> GetOefeningsFromDB(int workoutId)
        {
            OefeningMapper mapper = new OefeningMapper();
            return mapper.GetOefeningenByWorkout(workoutId);
        }
        public void AddSporter(Sporter sporters)
        {
            SporterMapper mapper = new SporterMapper();
            mapper.AddSporterToDB(sporters);
        }
        public void DeleteSporter(Sporter sporter)
        {
            SporterMapper mapper = new SporterMapper();
            mapper.DeleteSporterFromDB(sporter.Id);
        }
        public Sporter GetSporterById(int id)
        {
            SporterMapper mapper = new SporterMapper();
            return mapper.GetSporterById(id);
        }
        public void UpdatedSporter(Sporter sporter)
        {
            SporterMapper mapper = new SporterMapper();
            mapper.UpdateSporter(sporter);
        }
        public List<Oefening> GetOefeningsById(List<int> OefeningenId)
        {
            OefeningMapper mapper = new OefeningMapper();
            return mapper.GetOefeningenByIds(OefeningenId);
        }
        public double VoegCalorieënToeAanSporter(Sporter sporter, List<Oefening> oefeningen)
        {
            SporterMapper sporterMapper = new SporterMapper();
            return sporterMapper.VoegCalorieënToeAanSporter(sporter, oefeningen);
        }
        public Sporter GetSporterByEmailAndPassword(string email, string wachtwoord)
        {
            SporterMapper sporterMapper = new SporterMapper();
            return sporterMapper.GetSporterByEmailAndPassword(email,wachtwoord);
        }

    }
}
