using Fitly_Domain.Business;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitly_Domain.Persistence
{
    internal class WorkoutMapper
    {
        private string _connectionString;
        public WorkoutMapper()
        {
            _connectionString = "server = localhost; user id = root; password=1234;database=fitly";
        }
        public WorkoutMapper(string connstring)
        {
            _connectionString = connstring;
        }
        public List<Workout> LoadWorkoutsFromDB()
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            string command = "SELECT idWorkout, NaamWorkout FROM fitly.workout";
            MySqlCommand cmd = new MySqlCommand(command, conn);

            List<Workout> returnList = new List<Workout>();

            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int idWorkout;
                    string naamWorkout;

                    if (reader["idWorkout"] != DBNull.Value)
                        idWorkout = Convert.ToInt32(reader["idWorkout"]);
                    else
                        idWorkout = 0;

                    if (reader["NaamWorkout"] != DBNull.Value)
                        naamWorkout = Convert.ToString(reader["NaamWorkout"]);
                    else
                        naamWorkout = string.Empty;

                    Workout item = new Workout(idWorkout, naamWorkout);
                    returnList.Add(item);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
            finally
            {
                conn.Close();
            }

            return returnList;
        }
    }
}
