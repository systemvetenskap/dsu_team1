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

        public string GetSpecificDiaryNote(string noteID)
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            try
            {
                conn.Open();
                NpgsqlCommand cmdGetSpcDiaryNote = new NpgsqlCommand("SELECT txt FROM dagbok where id = @noteid;", conn);
                cmdGetSpcDiaryNote.Parameters.AddWithValue("@noteid", noteID);
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
                NpgsqlCommand cmdUserAllDiaryNotes = new NpgsqlCommand("SELECT * FROM dagbok WHERE id_medlem = @id ORDER BY date DESC LIMIT 10;", conn);
                cmdUserAllDiaryNotes.Parameters.AddWithValue("@id", id);
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

        public DataTable GetUserDiaryNotesBasedOnDates(string id, string minDate, string maxDate)
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            try
            {
                conn.Open();
                NpgsqlCommand cmdUserAllDiaryNotes = new NpgsqlCommand("SELECT * FROM dagbok WHERE id_medlem = @id " +
                                                                       "AND date >= @mindate AND date <= @maxdate ORDER BY date DESC;", conn);
                cmdUserAllDiaryNotes.Parameters.AddWithValue("@id", id);
                cmdUserAllDiaryNotes.Parameters.AddWithValue("@mindate", minDate);
                cmdUserAllDiaryNotes.Parameters.AddWithValue("@maxdate", maxDate);
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

        public DataTable GetUserXML(string id)
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            try
            {
                conn.Open();
                NpgsqlCommand cmdUserAllDiaryNotes = new NpgsqlCommand("SELECT resultxml FROM dagbok WHERE id = @id;", conn);
                cmdUserAllDiaryNotes.Parameters.AddWithValue("@id", id);
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

        public DataTable GetMinAndMaxDate(string id)
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            try
            {
                conn.Open();
                NpgsqlCommand cmdUserAllDiaryNotes = new NpgsqlCommand("SELECT MIN(date), MAX(date) FROM dagbok WHERE id_medlem = @id; ", conn);
                cmdUserAllDiaryNotes.Parameters.AddWithValue("@id", id);
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

        public string GetUserDiaryStats(string id)
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            try
            {
                conn.Open();
                NpgsqlCommand cmdUserAllDiaryNotes = new NpgsqlCommand("SELECT COUNT(id) FROM dagbok WHERE id_medlem = @id; ", conn);
                cmdUserAllDiaryNotes.Parameters.AddWithValue("@id", id);
                NpgsqlDataAdapter nda = new NpgsqlDataAdapter();
                nda.SelectCommand = cmdUserAllDiaryNotes;
                DataTable dt = new DataTable();
                nda.Fill(dt);

                string total = dt.Rows[0]["count"].ToString();

                return total;
            }
            catch (NpgsqlException ex)
            {
                //NpgsqlException = ex.Message;
                return "0";
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}