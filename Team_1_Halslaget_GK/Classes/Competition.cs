using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Npgsql;
using System.Web.Configuration;

namespace Team_1_Halslaget_GK
{
    public class Competition
    {
        public string namn { get; set; }
        public string starttid { get; set; }
        public string sluttid { get; set; }
        public string desc { get; set; }
        public string type { get; set; }
        public string id { get; set; }

        /// <summary>
        /// Gets all the competition that is in the database.
        /// </summary>
        public DataTable GetAllCompetitions()
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            try
            {
                conn.Open();
                NpgsqlCommand cmdGetCompetitions = new NpgsqlCommand("SELECT * FROM tavling ORDER BY id ASC", conn);
                NpgsqlDataAdapter nda = new NpgsqlDataAdapter();
                nda.SelectCommand = cmdGetCompetitions;
                DataTable dt = new DataTable();
                nda.Fill(dt);

                return dt;
            }
            catch (NpgsqlException ex)
            {
                //NpgsqlException = ex.Message;
                return null;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        /// <summary>
        /// Gets a specific competition based on tournaments name
        /// </summary>
        public DataTable GetSpecificCompetition(string compName)
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            try
            {
                conn.Open();
                NpgsqlCommand cmdGetSpecComp = new NpgsqlCommand("SELECT * FROM tavling WHERE namn = @compName", conn);
                cmdGetSpecComp.Parameters.AddWithValue("@compName", compName);
                NpgsqlDataAdapter nda = new NpgsqlDataAdapter();
                nda.SelectCommand = cmdGetSpecComp;
                DataTable dt = new DataTable();
                nda.Fill(dt);

                return dt;
            }
            catch (NpgsqlException ex)
            {
                //NpgsqlException = ex.Message;
                return null;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}