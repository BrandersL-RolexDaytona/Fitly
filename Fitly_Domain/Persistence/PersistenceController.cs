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
    }
}
