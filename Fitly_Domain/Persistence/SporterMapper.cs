﻿using Fitly_Domain.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

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
                    string command = "SELECT * FROM fitly.sporter";  // Include Wachtwoord in the query
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

                            // Add Wachtwoord to the Sporter object
                            returnList.Add(new Sporter(id, naam, voornaam, email, wachtwoord, geboortedatum, geslacht, lengte));
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
    }
    }
