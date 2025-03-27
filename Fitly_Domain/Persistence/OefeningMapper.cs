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
            string query = "SELECT idOefening, Naam, Omschrijving, Calorieen, Herhalingen, Duur " +
                           "FROM fitly.oefening " +
                           "WHERE IdWorkout = @workoutId;";  // The query remains the same

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                // Adding the parameter for the query
                cmd.Parameters.AddWithValue("@workoutId", workoutId);

                try
                {
                    conn.Open();  // Open the connection

                    using (MySqlDataReader reader = cmd.ExecuteReader())  // Execute the query
                    {
                        while (reader.Read())
                        {
                            int idOefening = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            string naam = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                            string omschrijving = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                            int calorieën = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                            int herhalingen = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                            double duur = reader.IsDBNull(5) ? 0 : reader.GetDouble(5);

                            // Create Oefening object and add it to the list
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

