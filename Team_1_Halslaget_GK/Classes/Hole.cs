using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.Web.Configuration;

namespace Team_1_Halslaget_GK
{
    [Serializable]
    public class Hole
    {
        NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

        public int nummer { get; set; }
        public int slag { get; set; }
        public int totalSlag { get; set; }
        public int score { get; set; }


        public void SetRound(string xml, int compid, int memberid)
        {
            string sql = "UPDATE medlem_tavling SET resultatxml = @resultatxml WHERE medlem_id = @medlem_id AND tavling_id = @tavling_id";

            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@medlem_id", memberid);
            cmd.Parameters.AddWithValue("@tavling_id", compid);
            cmd.Parameters.AddWithValue("@resultatxml", xml);

            try
            {
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

        public void SetRoundTeam(string xml, int compid, int memberid)
        {
            string sql = "UPDATE lag_medlem SET resultatxml = @resultatxml WHERE medlem_id = @medlem_id AND lag_id = (SELECT lag_id FROM lag_medlem WHERE lag_id IN (SELECT lag_id FROM lag_tavling WHERE id_tavling = 27) AND medlem_id = @medlem_id)";

            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@medlem_id", memberid);
            cmd.Parameters.AddWithValue("@tavling_id", compid);
            cmd.Parameters.AddWithValue("@resultatxml", xml);

            try
            {
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