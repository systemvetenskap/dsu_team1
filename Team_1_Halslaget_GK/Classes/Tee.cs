using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Npgsql;
using System.Web.Configuration;

namespace Team_1_Halslaget_GK
{
    public class Tee
    {

        public DataTable GetAllTees()
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            try
            {
                conn.Open();
                NpgsqlCommand cmdGetAllTees = new NpgsqlCommand("SELECT * FROM teetable ORDER BY id ASC;", conn);
                NpgsqlDataAdapter nda = new NpgsqlDataAdapter();
                nda.SelectCommand = cmdGetAllTees;
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

        public DataTable GetSpecificTee(string id)
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            try
            {
                conn.Open();
                NpgsqlCommand cmdGetAllTees = new NpgsqlCommand("SELECT * FROM teetable WHERE id = @id;", conn);
                cmdGetAllTees.Parameters.AddWithValue("@id", id);
                NpgsqlDataAdapter nda = new NpgsqlDataAdapter();
                nda.SelectCommand = cmdGetAllTees;
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