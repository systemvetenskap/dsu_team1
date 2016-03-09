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


        public void SetRound(string xml, int compid, int memberid)
        {
            string sql = "INSERT INTO medlem_tavling (medlem_id, tavling_id, resultatxml) VALUES (@medlem_id, @tavling_id, @resultatxml)";

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