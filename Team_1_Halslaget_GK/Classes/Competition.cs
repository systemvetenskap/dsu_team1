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
        public DateTime date { get; set; }

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
        public DataTable GetSpecificCompetition(string id)
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            try
            {
                conn.Open();
                NpgsqlCommand cmdGetSpecComp = new NpgsqlCommand("SELECT * FROM tavling WHERE id = @id", conn);
                cmdGetSpecComp.Parameters.AddWithValue("@id", id);
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

        public DataTable GetAllUpcomingCompetitions()
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            try
            {
                conn.Open();
                NpgsqlCommand cmdGetCompetitions = new NpgsqlCommand("SELECT * FROM tavling WHERE datum > CURRENT_DATE ORDER BY id ASC", conn);
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

        public int GetNOcompetitors(string id)
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            try
            {
                conn.Open();
                NpgsqlCommand cmdGetPlayers = new NpgsqlCommand("SELECT count(medlem_id) FROM medlem_tavling WHERE tavling_id = (SELECT id FROM tavling WHERE id = @id)", conn);
                cmdGetPlayers.Parameters.AddWithValue("@id", id);
                int noplayers = Convert.ToInt32(cmdGetPlayers.ExecuteScalar());

                return noplayers;
            }
            catch (NpgsqlException ex)
            {
                //NpgsqlException = ex.Message;
                return 0;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

        }

        public DataTable GetCompetitors(string compName)
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT fornamn, efternamn, golfid FROM medlem INNER JOIN medlem_tavling ON medlem_id = id INNER JOIN tavling t ON t.id = (SELECT tavling_id FROM tavling WHERE namn = @compName)", conn);
                da.SelectCommand.Parameters.AddWithValue("@compName", compName);

                da.Fill(dt);

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

        public void SetStartList(string xml, string compId)
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            NpgsqlCommand cmd = new NpgsqlCommand("UPDATE tavling SET startlistxml = @xml WHERE id = @compid", conn);
            cmd.Parameters.AddWithValue("@compid", compId);
            cmd.Parameters.AddWithValue("@xml", xml);
            
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                //NpgsqlException = ex.Message;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public DataTable GetComingCompetitionMember(int id)
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            try
            {
                conn.Open();
                NpgsqlCommand cmdGetCompetitions = new NpgsqlCommand("SELECT * FROM tavling WHERE id IN (SELECT tavling_id FROM medlem_tavling WHERE medlem_id = @medlem_id) AND datum > CURRENT_DATE", conn);
                cmdGetCompetitions.Parameters.AddWithValue("@medlem_id", id);
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
        

    }
}