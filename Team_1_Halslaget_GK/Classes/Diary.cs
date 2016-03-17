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
    }
}