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
                NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT from_medlem, meddelande, tid, fornamn, efternamn FROM meddelande INNER JOIN medlem ON from_medlem = medlem.id WHERE to_medlem = @id", conn);
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