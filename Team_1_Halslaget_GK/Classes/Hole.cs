using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.Web.Configuration;
using System.Data;

namespace Team_1_Halslaget_GK
{
    [Serializable]
    public class Hole
    {
        NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

        public List<Hole> round = new List<Hole>();

        public int nummer { get; set; }
        public int slag { get; set; }
        public int totalSlag { get; set; }
        public int score { get; set; }
        public double playerhcp { get; set; }
        public int teeid { get; set; }


        public void SetRound(string xml, int compid, int memberid, int score)
        {
            string sql = "UPDATE medlem_tavling SET resultatxml = @resultatxml, score = @score WHERE medlem_id = @medlem_id AND tavling_id = @tavling_id";

            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@medlem_id", memberid);
            cmd.Parameters.AddWithValue("@tavling_id", compid);
            cmd.Parameters.AddWithValue("@resultatxml", xml);
            cmd.Parameters.AddWithValue("@score", score);

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
            string sql = "UPDATE lag_medlem SET resultatxml = @resultatxml WHERE medlem_id = @medlem_id AND lag_id = (SELECT lag_id FROM lag_medlem WHERE lag_id IN (SELECT lag_id FROM lag_tavling WHERE id_tavling = @tavling_id) AND medlem_id = @medlem_id)";

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

        public DataTable GetHoleInfo()
        {
            string sql = "SELECT * FROM holes";

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);

            try
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }

            catch (NpgsqlException ex)
            {
                return null;
            }

            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public int GetGameHcp(double hcp, int teeid)
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

            string sql = "SELECT spelhcp FROM slope WHERE hcphigh >= @hcp AND hcplow <= @hcp and tee_id = @tee_id";

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@hcp", hcp);
            cmd.Parameters.AddWithValue("@tee_id", teeid);

            try
            {
                conn.Open();
                int spelhcp = Convert.ToInt32(cmd.ExecuteScalar());
                return spelhcp;
            }

            catch (NpgsqlException ex)
            {
                return 0;
            }

            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}