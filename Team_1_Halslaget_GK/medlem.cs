//Jacob Hyllengren (some dated)
//Revised Erik Drysén 2016-03-01.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.Data;
using System.Web.Configuration;

namespace Team_1_Halslaget_GK
{
    public class medlem
    {        
        //Properties
        public int ID { get; set; }
        public string fornamn { get; set; }
        public string efternamn { get; set; }
        public double handikapp { get; set; }
        public string telefonNummer { get; set; }
        public string epost { get; set; }
        public string adress { get; set; }
        public string postnummer {get; set;}
        public string ort {get; set;}

        /// <summary>
        /// Gets a specific members info based on member ID. 
        /// Can be rewritten to include all of the columns in order to be used elsewhere as well.
        /// </summary>
        /// <returns>REturns a datatable with info.</returns>
        public DataTable GetSpecificMember()
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            try
            {
                conn.Open();
                NpgsqlCommand cmdGetMemberInfo = new NpgsqlCommand("SELECT fornamn, efternamn, adress, postnummer, ort, epost, hcp, medlemskategori, telefonnummer FROM medlem WHERE id = @id", conn);
                cmdGetMemberInfo.Parameters.AddWithValue("@id", ID);
                NpgsqlDataAdapter nda = new NpgsqlDataAdapter();
                nda.SelectCommand = cmdGetMemberInfo;
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

        /// <summary>
        /// Updates a members info. For now this is only applicaple when a user
        /// updates his/hers own info. But I guess it can be re-written to be used elswhere.
        /// </summary>
        public void UpdateMemberInfo()
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            try
            {
                conn.Open();
                NpgsqlCommand cmdUpdateMemberInfo = new NpgsqlCommand("UPDATE medlem SET fornamn = @fornamn, efternamn = @efternamn, adress = @adress, postnummer = @postnummer, ort = @ort, epost = @epost, telefonnummer = @telefonnummer WHERE id = @id ", conn);
                cmdUpdateMemberInfo.Parameters.AddWithValue("@fornamn", fornamn);
                cmdUpdateMemberInfo.Parameters.AddWithValue("@efternamn", efternamn);
                cmdUpdateMemberInfo.Parameters.AddWithValue("@adress", adress);
                cmdUpdateMemberInfo.Parameters.AddWithValue("@postnummer", postnummer);
                cmdUpdateMemberInfo.Parameters.AddWithValue("@ort", ort);
                cmdUpdateMemberInfo.Parameters.AddWithValue("@epost", epost);
                cmdUpdateMemberInfo.Parameters.AddWithValue("@telefonnummer", telefonNummer);
                cmdUpdateMemberInfo.Parameters.AddWithValue("@id", ID);

                cmdUpdateMemberInfo.ExecuteNonQuery();
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

        public override string ToString()
        {
            return ID + " " + fornamn + " " + efternamn + " " + " " + handikapp;
        }
    }
}