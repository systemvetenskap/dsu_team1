using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Team_1_Halslaget_GK
{
    public class Team
    {
        public string id { get; set; }
        public string namn { get; set; }

        public List<medlem> Listofmedlem = new List<medlem>();

        public DataTable GetTeamXML(int memberid, int compid)
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT lag_id, resultatxml FROM lag_medlem WHERE lag_id =( SELECT lag_id FROM lag_medlem WHERE medlem_id = @memberid) AND lag_id IN (SELECT lag_id FROM lag_tavling WHERE id_tavling = @compid)", conn);
                cmd.Parameters.AddWithValue("@memberid", memberid);
                cmd.Parameters.AddWithValue("@compid", compid);

                NpgsqlDataAdapter da = new NpgsqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
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

        public void SetTeamResult(int result, int teamid)
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("UPDATE lag_medlem SET slutresultat = @slutresultat WHERE lag_id = @lag_id", conn);
                cmd.Parameters.AddWithValue("@slutresultat", result);
                cmd.Parameters.AddWithValue("lag_id", teamid);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            catch (NpgsqlException ex)
            {

            }

            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}