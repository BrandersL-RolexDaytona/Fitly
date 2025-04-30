using Fitly_Domain.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;

namespace Fitly_Domain.Persistence
{

    internal class SporterMapper
    {

        private string _connectionString;
        public SporterMapper()
        {
            _connectionString = "server = localhost; user id = root; password=1234;database=fitly";
        }
        public SporterMapper(string connstring)
        {
            _connectionString = connstring;
        }

        public List<Sporter> GetDeelnemersFromDB()
        {
            List<Sporter> returnList = new List<Sporter>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string command = "SELECT * FROM fitly.sporter"; 
                    using (MySqlCommand cmd = new MySqlCommand(command, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader["idSporter"] != DBNull.Value ? Convert.ToInt32(reader["idSporter"]) : 0;
                            string naam = reader["Naam"] != DBNull.Value ? reader["Naam"].ToString() : string.Empty;
                            string voornaam = reader["Voornaam"] != DBNull.Value ? reader["Voornaam"].ToString() : string.Empty;
                            string email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : string.Empty;
                            string wachtwoord = reader["Wachtwoord"] != DBNull.Value ? reader["Wachtwoord"].ToString() : string.Empty;  // Fetch Wachtwoord

                            DateTime geboortedatum = reader["Geboortedatum"] != DBNull.Value ? Convert.ToDateTime(reader["Geboortedatum"]) : DateTime.MinValue;
                            string geslacht = reader["Geslacht"] != DBNull.Value ? reader["Geslacht"].ToString() : string.Empty;
                            double lengte = reader["Lengte"] != DBNull.Value ? Convert.ToDouble(reader["Lengte"]) : 0.0;
                            double totaleCalorieën = reader["TotaleCalorieën"] != DBNull.Value ? Convert.ToDouble(reader["TotaleCalorieën"]) : 0.0;

                            returnList.Add(new Sporter(id, naam, voornaam, email, wachtwoord, geboortedatum, geslacht, lengte, totaleCalorieën));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fout", ex);
            }

            return returnList;
        }
        public void AddSporterToDB(Sporter newSporter)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string command = "INSERT INTO fitly.sporter (Naam, Voornaam, Email, Wachtwoord, Geboortedatum, Geslacht, Lengte) " +
                        "VALUES (@Naam, @Voornaam, @Email, @Wachtwoord, @Geboortedatum, @Geslacht, @Lengte)";

                    using (MySqlCommand cmd = new MySqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@Naam", newSporter.NaamSporter);
                        cmd.Parameters.AddWithValue("@Voornaam", newSporter.VoornaamSporter);
                        cmd.Parameters.AddWithValue("@Email", newSporter.MailSporter);
                        cmd.Parameters.AddWithValue("@Wachtwoord", newSporter.Wachtwoord);
                        cmd.Parameters.AddWithValue("@Geboortedatum", newSporter.GeboortedatumSporter);
                        cmd.Parameters.AddWithValue("@Geslacht", newSporter.Geslacht);
                        cmd.Parameters.AddWithValue("@Lengte", newSporter.Lengte);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fout", ex);
            }
        }



        public void DeleteSporterFromDB(int sporterId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string command = "DELETE FROM fitly.sporter WHERE IdSporter = @SporterID";

                    using (MySqlCommand cmd = new MySqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@SporterID", sporterId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fout bij het verwijderen van de sporter", ex);
            }
        }

        public Sporter GetSporterById(int id)
        {
            Sporter sporter = null;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string command = "SELECT * FROM fitly.sporter WHERE IdSporter = @Id";
                    using (MySqlCommand cmd = new MySqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int sporterId = Convert.ToInt32(reader["idSporter"]);
                                string naam = reader["Naam"].ToString();
                                string voornaam = reader["Voornaam"].ToString();
                                string email = reader["Email"].ToString();
                                string wachtwoord = reader["Wachtwoord"].ToString();
                                DateTime geboortedatum = Convert.ToDateTime(reader["Geboortedatum"]);
                                string geslacht = reader["Geslacht"].ToString();
                                double lengte = Convert.ToDouble(reader["Lengte"]);
                                double totaleCalorieën = reader["TotaleCalorieën"] != DBNull.Value ? Convert.ToDouble(reader["TotaleCalorieën"]) : 0.0;

                                sporter = new Sporter(sporterId, naam, voornaam, email, wachtwoord, geboortedatum, geslacht, lengte, totaleCalorieën);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fout bij het ophalen van de sporter", ex);
            }

            return sporter;
        }

        public void UpdateSporter(Sporter updatedSporter)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string command = @"UPDATE fitly.sporter 
                               SET Naam = @Naam,
                                   Voornaam = @Voornaam,
                                   Email = @Email,
                                   Wachtwoord = @Wachtwoord,
                                   Geboortedatum = @Geboortedatum,
                                   Geslacht = @Geslacht,
                                   Lengte = @Lengte,
                                   TotaleCalorieën = @TotaleCalorieën
                               WHERE IdSporter = @Id";



                    using (MySqlCommand cmd = new MySqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@Naam", updatedSporter.NaamSporter);
                        cmd.Parameters.AddWithValue("@Voornaam", updatedSporter.VoornaamSporter);
                        cmd.Parameters.AddWithValue("@Email", updatedSporter.MailSporter);
                        cmd.Parameters.AddWithValue("@Wachtwoord", updatedSporter.Wachtwoord);
                        cmd.Parameters.AddWithValue("@Geboortedatum", updatedSporter.GeboortedatumSporter);
                        cmd.Parameters.AddWithValue("@Geslacht", updatedSporter.Geslacht);
                        cmd.Parameters.AddWithValue("@Lengte", updatedSporter.Lengte);
                        cmd.Parameters.AddWithValue("@Id", updatedSporter.Id);
                        cmd.Parameters.AddWithValue("@TotaleCalorieën", updatedSporter.TotaleCalorieën);


                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fout bij het bijwerken van de sporter", ex);
            }
        }
        public double VoegCalorieënToeAanSporter(Sporter sporter, List<Oefening> oefeningen)
        {
            double totaalCalorieën = 0;

            foreach (var oef in oefeningen)
            {
                totaalCalorieën += oef.Calorieën * oef.Duur;
            }

            sporter.TotaleCalorieën += totaalCalorieën;

            return totaalCalorieën;
        }

        public void UpdateCalorieënVanSporter(int sporterId, double nieuweCalorieën)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string command = @"UPDATE fitly.sporter 
                               SET TotaleCalorieën = @TotaleCalorieën
                               WHERE IdSporter = @Id";

                    using (MySqlCommand cmd = new MySqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@TotaleCalorieën", nieuweCalorieën);
                        cmd.Parameters.AddWithValue("@Id", sporterId);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fout bij het bijwerken van de calorieën van de sporter", ex);
            }
        }
    
    public Sporter GetSporterByEmailAndPassword(string email, string wachtwoord)
        {
            Sporter sporter = null;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string command = "SELECT * FROM fitly.sporter WHERE Email = @Email AND Wachtwoord = @Wachtwoord";
                    using (MySqlCommand cmd = new MySqlCommand(command, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Wachtwoord", wachtwoord);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int sporterId = Convert.ToInt32(reader["idSporter"]);
                                string naam = reader["Naam"].ToString();
                                string voornaam = reader["Voornaam"].ToString();
                                string emailAdres = reader["Email"].ToString();
                                string wachtwoordDb = reader["Wachtwoord"].ToString();
                                DateTime geboortedatum = Convert.ToDateTime(reader["Geboortedatum"]);
                                string geslacht = reader["Geslacht"].ToString();
                                double lengte = Convert.ToDouble(reader["Lengte"]);
                                double totaleCalorieën = reader["TotaleCalorieën"] != DBNull.Value ? Convert.ToDouble(reader["TotaleCalorieën"]) : 0.0;

                                sporter = new Sporter(sporterId, naam, voornaam, emailAdres, wachtwoordDb, geboortedatum, geslacht, lengte, totaleCalorieën);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fout bij het ophalen van de sporter via email en wachtwoord", ex);
            }

            return sporter;
        }
    }
    }



