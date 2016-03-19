using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Team_1_Halslaget_GK.Classes
{
    public class Message
    {
        public DataTable GetMessages(int id)
        {
            DataTable dt = new DataTable();
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

            try
            {
                NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT maxmax, fornamn, efternamn, tbl4.id, tid, meddelande FROM meddelande INNER JOIN (SELECT DISTINCT max(maxid) AS maxmax, fornamn, efternamn, id FROM (SELECT DISTINCT tbl2.id, fornamn, efternamn, maxid FROM (SELECT fornamn, efternamn, tbl.from_medlem, tbl.to_medlem, medlem.id, maxid FROM medlem INNER JOIN (SELECT max(id) AS maxid, from_medlem, to_medlem FROM meddelande GROUP BY from_medlem, to_medlem) tbl ON (CASE WHEN from_medlem = @id THEN to_medlem = medlem.id WHEN from_medlem != @id THEN from_medlem = medlem.id END)) tbl2 WHERE tbl2.from_medlem = @id OR tbl2.to_medlem = @id) tbl3 GROUP BY fornamn, efternamn, id) tbl4 ON meddelande.id = maxmax", conn);
                da.SelectCommand.Parameters.AddWithValue("@id", id);
                conn.Open();
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

        public DataTable GetMessagesSpecificMember(int id)
        {
            DataTable dt = new DataTable();
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

            try
            {
                NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT fornamn, efternamn, tid, meddelande, from_medlem, to_medlem FROM meddelande INNER JOIN medlem ON from_medlem = medlem.id WHERE from_medlem = @id OR to_medlem = @id ORDER BY tid ASC", conn);
                da.SelectCommand.Parameters.AddWithValue("@id", id);
                conn.Open();
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

        public bool SendMessage(string msg, int idfrom, int idto)
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO meddelande (from_medlem, to_medlem, meddelande, tid) VALUES (@idfrom, @idto, @meddelande, @tid)", conn);
                cmd.Parameters.AddWithValue("@idfrom", idfrom);
                cmd.Parameters.AddWithValue("idto", idto);
                cmd.Parameters.AddWithValue("@meddelande", msg);
                cmd.Parameters.AddWithValue("@tid", DateTime.Now);
                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }

            catch (NpgsqlException ex)
            {
                return false;
            }

            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        
    }
}