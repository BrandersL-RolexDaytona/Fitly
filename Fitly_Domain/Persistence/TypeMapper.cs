using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitly_Domain.Business;

namespace Fitly_Domain.Persistence
{
    internal class TypeMapper
    {
        private string _connectionString;
        public TypeMapper()
        {
            _connectionString = "server = localhost; user id = root; password=1234;database=fitly";
        }
        public TypeMapper(string connstring)
        {
            _connectionString = connstring;
        }
        
        public List<OefeningType> GetAllTypes()
        {
            List<OefeningType> returnList = new List<OefeningType>();
            string command = "SELECT idType, Spieren FROM fitly.type";

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            using (MySqlCommand cmd = new MySqlCommand(command, conn))
            {
                try
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idType = reader["idType"] != DBNull.Value ? Convert.ToInt32(reader["idType"]) : 0;
                            string spier = reader["Spieren"] != DBNull.Value ? Convert.ToString(reader["Spieren"]) : string.Empty;

                            OefeningType item = new OefeningType
                            {
                                IdType = idType,
                                Spieren = spier
                            };

                            returnList.Add(item);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Fout bij ophalen types", ex);
                }
            }

            return returnList;
        }

    }
}
