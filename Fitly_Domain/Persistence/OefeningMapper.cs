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
                           "WHERE Workout_idWorkout = @workoutId";

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
                            int idOefening;
                            string naam, omschrijving;
                            int calorieën, herhalingen;
                            double duur;
                            int fkType = 1;

                            if (reader["idOefening"] != DBNull.Value)
                                idOefening = Convert.ToInt32(reader["idOefening"]);
                            else
                                idOefening = 0;

                            if (reader["Naam"] != DBNull.Value)
                                naam = Convert.ToString(reader["Naam"]);
                            else
                                naam = string.Empty;

                            if (reader["Omschrijving"] != DBNull.Value)
                                omschrijving = Convert.ToString(reader["Omschrijving"]);
                            else
                                omschrijving = string.Empty;

                            if (reader["Calorieen"] != DBNull.Value)
                                calorieën = Convert.ToInt32(reader["Calorieen"]);
                            else
                                calorieën = 0;

                            if (reader["Herhalingen"] != DBNull.Value)
                                herhalingen = Convert.ToInt32(reader["Herhalingen"]);
                            else
                                herhalingen = 0;

                            if (reader["Duur"] != DBNull.Value)
                                duur = Convert.ToDouble(reader["Duur"]);
                            else
                                duur = 0;

                            Oefening oefening = new Oefening(idOefening, naam, omschrijving, fkType, calorieën, herhalingen, duur);
                            returnList.Add(oefening);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving oefeningen: " + ex.Message);
                }
            }

            return returnList;
        }
    }
}

