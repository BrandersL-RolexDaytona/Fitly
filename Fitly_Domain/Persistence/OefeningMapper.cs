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
            string query = "SELECT o.idOefening, o.Naam, o.Omschrijving, o.Calorieen,o.FkType, o.Herhalingen, o.Duur " +
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
                            int fkType = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);


                            Oefening oefening = new Oefening(idOefening, naam, omschrijving, calorieën, fkType, herhalingen, duur);
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

        public List<Oefening> GetOefeningenByIds(List<int> ids)
        {
            List<Oefening> result = new List<Oefening>();

            if (ids == null || ids.Count == 0)
                return result;

            // Create a list of placeholders for the IN clause
            string placeholders = string.Join(",", ids.Select(_ => "?"));

            string query = $"SELECT idOefening, Naam, Omschrijving, Calorieen, FkType, Herhalingen, Duur " +
                           $"FROM fitly.oefening WHERE idOefening IN ({placeholders})";

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                // Add parameters corresponding to each placeholder
                foreach (var id in ids)
                {
                    cmd.Parameters.AddWithValue(null, id);
                }

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
                            int fkType = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                            int herhalingen = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
                            double duur = reader.IsDBNull(6) ? 0 : reader.GetDouble(6);

                            Oefening oefening = new Oefening(idOefening, naam, omschrijving, calorieën, fkType, herhalingen, duur);
                            result.Add(oefening);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error fetching oefeningen by IDs: " + ex.Message);
                }
            }

            return result;
        }
    }
}

