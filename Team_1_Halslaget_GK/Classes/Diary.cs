using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Globalization;
using System.Data;
using Npgsql;

namespace Team_1_Halslaget_GK
{
    public class Diary
    {
        //public string Title { get; set; }
        //public string DiaryText { get; set; }
        //public DateTime Date { get; set; }
        //public string ScoreXml { get; set; }

        public void InsertDiaryNote(string Title, string DiaryText, DateTime Date, string ScoreXml, int idperson)
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            try
            {
                conn.Open();
                NpgsqlCommand cmdInsertDiaryNote = new NpgsqlCommand("INSERT INTO dagbok (title, date, txt, resultxml, id_medlem) " +
                                                                        " VALUES (@title, @date, @txt, @scorexml, @idperson); ", conn);

                cmdInsertDiaryNote.Parameters.AddWithValue("@title", Title);
                cmdInsertDiaryNote.Parameters.AddWithValue("@txt", DiaryText);
                cmdInsertDiaryNote.Parameters.AddWithValue("@date", Date);
                cmdInsertDiaryNote.Parameters.AddWithValue("@scorexml", ScoreXml);
                cmdInsertDiaryNote.Parameters.AddWithValue("@idperson", idperson);

                cmdInsertDiaryNote.ExecuteNonQuery();

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

        public void InsertDiaryNote(string Title, string DiaryText, DateTime Date, int idperson)
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            try
            {
                conn.Open();
                NpgsqlCommand cmdInsertDiaryNote = new NpgsqlCommand("INSERT INTO dagbok (title, date, txt, id_medlem) " +
                                                                        " VALUES (@title, @date, @txt, @idperson); ", conn);

                cmdInsertDiaryNote.Parameters.AddWithValue("@title", Title);
                cmdInsertDiaryNote.Parameters.AddWithValue("@txt", DiaryText);
                cmdInsertDiaryNote.Parameters.AddWithValue("@date", Date);
                cmdInsertDiaryNote.Parameters.AddWithValue("@idperson", idperson);

                cmdInsertDiaryNote.ExecuteNonQuery();

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

        public string GetSpecificDiaryNote()
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            try
            {
                conn.Open();
                NpgsqlCommand cmdGetSpcDiaryNote = new NpgsqlCommand("SELECT txt FROM dagbok where id = 3;", conn);
                NpgsqlDataAdapter nda = new NpgsqlDataAdapter();
                nda.SelectCommand = cmdGetSpcDiaryNote;
                DataTable dt = new DataTable();
                nda.Fill(dt);
                string diaryNote = dt.Rows[0]["txt"].ToString();
                return diaryNote;

            }
            catch (NpgsqlException ex)
            {
                //NpgsqlException = ex.Message;
                return "Nope";
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public DataTable GetUserAllDiaryNotes(string id)
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            try
            {
                conn.Open();
                NpgsqlCommand cmdUserAllDiaryNotes = new NpgsqlCommand("SELECT * FROM dagbok WHERE id_medlem = @id;", conn);
                cmdUserAllDiaryNotes.Parameters.AddWithValue("@id_medlem", id);
                NpgsqlDataAdapter nda = new NpgsqlDataAdapter();
                nda.SelectCommand = cmdUserAllDiaryNotes;
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