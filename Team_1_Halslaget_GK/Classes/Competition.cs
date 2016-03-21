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
        public DateTime firstRegDate { get; set; }
        public DateTime lastRegDate { get; set; }
        public int teeM { get; set; }
        public int teeF { get; set; }

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

        public DataTable GetAllUpcomingCompetitionsRegdates()
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            try
            {
                conn.Open();
                NpgsqlCommand cmdGetCompetitions = new NpgsqlCommand("SELECT * FROM tavling WHERE CURRENT_DATE BETWEEN firstregdate AND lastregdate ORDER BY id ASC", conn);
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

        public DataTable GetAllPastCompetitions()
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            try
            {
                conn.Open();
                NpgsqlCommand cmdGetCompetitions = new NpgsqlCommand("SELECT * FROM tavling WHERE datum < CURRENT_DATE ORDER BY id ASC", conn);
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
                NpgsqlCommand cmdGetCompetitions = new NpgsqlCommand("SELECT  id, namn, datum, bokning.starttid FROM tavling INNER JOIN medlem_tavling ON (tavling.id = medlem_tavling.tavling_id) INNER JOIN bokning ON (medlem_tavling.starttid_id = bokning.slot_id) WHERE medlem_id = @medlem_id", conn);
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

        public DataTable  GetComingTeamCompetitionMember(int id)
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            string sql = "SELECT id, namn, datum, bokning.starttid FROM lag_medlem INNER JOIN lag_tavling ON(lag_medlem.lag_id = lag_tavling.id_lag) INNER JOIN tavling ON (lag_tavling.id_tavling = tavling.id) INNER JOIN bokning ON(lag_tavling.starttid_id = bokning.slot_id) WHERE medlem_id = @medlem_id";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@medlem_id", id);
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter();
            nda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            nda.Fill(dt);

            return dt;
        }

        /// <summary>
        /// Gets all players from a competition where they have NO resultxml.
        /// </summary>
        public DataTable GetSpecificCompetitionPlayers(string competitionID)
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            try
            {
                conn.Open();
                NpgsqlCommand cmdGetCompetitions = new NpgsqlCommand("SELECT medlem.id, fornamn, efternamn, hcp, kon, teef, teem FROM medlem_tavling " +
                                                                     "INNER JOIN tavling ON tavling.id = tavling_id "+
                                                                     "INNER JOIN medlem ON medlem.id = medlem_id " +
                                                                     "WHERE tavling_id = @tavlingid " +
                                                                     "AND resultatxml IS NULL;", conn);
                cmdGetCompetitions.Parameters.AddWithValue("@tavlingid", competitionID);
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

        public DataTable GetSpecificCompetitionTeamPlayers(string competitionID)
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            try
            {
                conn.Open();
                NpgsqlCommand cmdGetCompetitions = new NpgsqlCommand("SELECT medlem.id, fornamn, efternamn, hcp, kon, teef, teem FROM medlem INNER JOIN lag_medlem ON medlem.id = medlem_id INNER JOIN lag_tavling ON lag_id = id_lag INNER JOIN tavling ON id_tavling = tavling.id WHERE tavling.id = @tavling_id AND resultatxml IS NULL", conn);
                cmdGetCompetitions.Parameters.AddWithValue("@tavling_id", competitionID);
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