using Fitly_Domain.Business;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitly_Domain.Persistence
{
    internal class OefeningMapper
    {
        private string _connectionString;

        public OefeningMapper()
        {
            _connectionString = "server = localhost; user id = root; password=1234;database=fitly";
        }

        public List<Oefening> GetOefeningenByWorkout(int workoutId)
        {
            List<Oefening> returnList = new List<Oefening>();
            string query = "SELECT o.idOefening, o.Naam, o.Omschrijving, o.Calorieen, o.Herhalingen, o.Duur " +
                           "FROM fitly.oefening o " +
                           "JOIN fitly.workout_has_oefening wh ON o.idOefening = wh.FKoefening " +
                           "WHERE wh.FKWorkout = @workoutId;";

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@workoutId", workoutId);

                try
                {
                    conn.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idOefening = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            string naam = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                            string omschrijving = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                            int calorieën = reader.IsDBNull(3) ? 0 : Convert.ToInt32(reader.GetString(3)); // Calorieen is LONGTEXT
                            int herhalingen = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                            double duur = reader.IsDBNull(5) ? 0 : reader.GetDouble(5);

                            Oefening oefening = new Oefening(idOefening, naam, omschrijving, 1, calorieën, herhalingen, duur);
                            returnList.Add(oefening);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error in oefeningen: " + ex.Message);
                }
            }

            return returnList;
        }
    }
}

