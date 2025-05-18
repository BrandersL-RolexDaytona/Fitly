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

       
            string placeholders = string.Join(",", ids.Select(_ => "?"));

            string query = $"SELECT idOefening, Naam, Omschrijving, Calorieen, FkType, Herhalingen, Duur " +
                           $"FROM fitly.oefening WHERE idOefening IN ({placeholders})";

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
             
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
                            int calorieën = reader.IsDBNull(3) ? 0 : Convert.ToInt32(reader.GetString(3)); 
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

        public int AddOefeningToDB(Oefening oef, int workoutId)
        {
            int newId = 0;

            try
            {
                using (var conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();

                    using (var transaction = conn.BeginTransaction())
                    {
                        // Stap 1: Voeg oefening toe
                        string insertOefeningQuery = @"
                    INSERT INTO fitly.oefening (Naam, Omschrijving, Calorieen, fkType, Herhalingen, Duur)
                    VALUES (@naam, @omschrijving, @calorieen, @fkType, @herhalingen, @duur);
                    SELECT LAST_INSERT_ID();";

                        using (var cmd = new MySqlCommand(insertOefeningQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@naam", oef.Naam);
                            cmd.Parameters.AddWithValue("@omschrijving", oef.Omschrijving ?? string.Empty);
                            cmd.Parameters.AddWithValue("@calorieen", oef.Calorieën);
                            cmd.Parameters.AddWithValue("@fkType", oef.FKType);
                            cmd.Parameters.AddWithValue("@herhalingen", oef.Herhalingen);
                            cmd.Parameters.AddWithValue("@duur", oef.Duur);

                            object result = cmd.ExecuteScalar();
                            if (result != null && int.TryParse(result.ToString(), out int id))
                            {
                                newId = id;
                            }
                            else
                            {
                                throw new Exception("Kon geen nieuw oefening-ID ophalen.");
                            }
                        }

                        // Stap 2: Koppel oefening aan workout
                        string insertRelatieQuery = @"
                    INSERT INTO fitly.workout_has_oefening (FKWorkout, FKOefening)
                    VALUES (@fkWorkout, @fkOefening);";

                        using (var relCmd = new MySqlCommand(insertRelatieQuery, conn, transaction))
                        {
                            relCmd.Parameters.AddWithValue("@fkWorkout", workoutId);
                            relCmd.Parameters.AddWithValue("@fkOefening", newId);
                            relCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Databasefout bij toevoegen van oefening of koppeling: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Onverwachte fout bij toevoegen van oefening of koppeling.", ex);
            }

            return newId;
        }

        public List<Oefening> GetAlleOefeningen()
        {
            List<Oefening> result = new List<Oefening>();

            string query = "SELECT idOefening, Naam, Omschrijving, Calorieen, FkType, Herhalingen, Duur FROM fitly.oefening";

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
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

                            
                            int calorieen = 0;
                            if (!reader.IsDBNull(3))
                            {
                                string calorieText = reader.GetString(3);
                                int.TryParse(calorieText, out calorieen);
                            }

                            int fkType = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                            int herhalingen = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);
                            double duur = reader.IsDBNull(6) ? 0 : reader.GetDouble(6);

                            result.Add(new Oefening(idOefening, naam, omschrijving, calorieen, fkType, herhalingen, duur));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Fout bij het ophalen van oefeningen: " + ex.Message);
                }
            }

            return result;
        }
        public void VerwijderOefening(int oefeningId)
        {
            string query = "DELETE FROM fitly.oefening WHERE idOefening = @id";

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", oefeningId);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Fout bij verwijderen van oefening: " + ex.Message);
                }
            }
        }

    }
}

