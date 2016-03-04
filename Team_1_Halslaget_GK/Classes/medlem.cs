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
        public string kon { get; set; }
        public string medlemsKategori { get; set; }
        public bool payStatus { get; set; }
        public DateTime senastebetalning { get; set; }
        public string fodelseDatum { get; set; }
        
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
                NpgsqlCommand cmdGetMemberInfo = new NpgsqlCommand("SELECT fornamn, efternamn, adress, postnummer, ort, epost, hcp, medlemskategori, telefonnummer, medlemsavgift_betald FROM medlem WHERE id = @id", conn);
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

        /// <summary>
        /// Gets the differents types of memberships that the golfclub has and returns it as a datatable.
        /// </summary>
        /// <returns>Membertyps in a datatable.</returns>
        public DataTable GetMemberTypes()
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            try
            {
                conn.Open();
                NpgsqlCommand cmdGetMemberInfo = new NpgsqlCommand("SELECT namntyp FROM medlemstyper; ", conn);
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
        /// Inserts a new member to the database. 
        /// </summary>
        /// <returns>Returns true or false depending on succesful or not.</returns>
        public bool InsertNewMember()
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            try
            {
                ID = SetNewID(); //TEMPORARY SOLUTION SHOULD REALLY BE REMOVED AND REPLACED WITH SERIAL IN DATABASE INSTEAD.
                DateTime payDate = SetMedlemsAvgiftDate();
                string golfID = CreateGolfID();

                conn.Open();
                NpgsqlCommand cmdUpdateMemberInfo = new NpgsqlCommand("INSERT INTO medlem (id, fornamn, efternamn, adress, postnummer, ort, epost, kon, hcp, golfid, medlemskategori, telefonnummer, medlemsavgift_betald) " +
                                                                        " VALUES (@id, @fornamn, @efternamn, @adress, @postnummer, @ort, @epost, @kon, @hcp, @golfid, @medlemsKategori, @telefonnummer, @paydate); ", conn);
                
                cmdUpdateMemberInfo.Parameters.AddWithValue("@id", ID);
                cmdUpdateMemberInfo.Parameters.AddWithValue("@fornamn", fornamn);
                cmdUpdateMemberInfo.Parameters.AddWithValue("@efternamn", efternamn);
                cmdUpdateMemberInfo.Parameters.AddWithValue("@adress", adress);
                cmdUpdateMemberInfo.Parameters.AddWithValue("@postnummer", postnummer);
                cmdUpdateMemberInfo.Parameters.AddWithValue("@ort", ort);
                cmdUpdateMemberInfo.Parameters.AddWithValue("@epost", epost);
                cmdUpdateMemberInfo.Parameters.AddWithValue("@kon", kon);
                cmdUpdateMemberInfo.Parameters.AddWithValue("@hcp", handikapp);
                cmdUpdateMemberInfo.Parameters.AddWithValue("@golfid", golfID);
                cmdUpdateMemberInfo.Parameters.AddWithValue("@medlemsKategori", medlemsKategori);
                cmdUpdateMemberInfo.Parameters.AddWithValue("@telefonnummer", telefonNummer);
                cmdUpdateMemberInfo.Parameters.AddWithValue("@paydate", payDate);

                cmdUpdateMemberInfo.ExecuteNonQuery();

                return true;
            }
            catch (NpgsqlException ex)
            {
                //NpgsqlException = ex.Message;
                return false;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        /// <summary>
        /// Sets a date for when membership was paid or not paid. 
        /// Paid date is the today date when it was changed by an admin.
        /// Not paid date is a fake date to indicate that it was not paid.
        /// </summary>
        /// <returns></returns>
        private DateTime SetMedlemsAvgiftDate()
        {
            DateTime payDate;
            if (payStatus)
            {
                payDate = DateTime.Now;
                return payDate;
            }
            else
            {
                string fakeDate = "1900-01-01"; //This is a fake date far back in time to indicate that member has not paid for his/hers membership.
                payDate = DateTime.Parse(fakeDate);
                return payDate;
            }
        }

        /// <summary>
        /// Creates a golfid with the members date of birth and ID from database.
        /// </summary>
        /// <returns></returns>
        private string CreateGolfID()
        {
            int newID = SetNewID();
            string golfID = fodelseDatum + "_" + newID.ToString();
            return golfID;
        }

        /// <summary>
        /// THIS IS A TEMPORARY WORKAROUND SINCE THE PROBLEM IN THE DATABASE IS THAT ITS
        /// CURRENTLY ONLY INTEGER VALUES IN THE ID COLUMN. 
        /// THIS
        /// IS
        /// A
        /// TEMPORARY
        /// WORKAROUND
        /// AND HAS TO BE CHANGED WHEN THE DATABASE IS UPDATED TO BE SERIAL.
        /// Method collects highest value from id column of medlem table and retuns it.
        /// </summary>
        private int GetMaxMemberID()
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            int id;
            try
            {
                conn.Open();
                NpgsqlCommand cmdGetMaxID = new NpgsqlCommand("SELECT MAX(id) FROM medlem; ", conn);
                NpgsqlDataAdapter nda = new NpgsqlDataAdapter();
                nda.SelectCommand = cmdGetMaxID;
                DataTable dt = new DataTable();
                nda.Fill(dt);

                id = Convert.ToInt32(dt.Rows[0]["max"].ToString());

                return id;
            }
            catch (NpgsqlException ex)
            {
                //NpgsqlException = ex.Message;
                id = -1;
                return id;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        /// <summary>
        /// THIS IS A TEMPORARY WORKAROUND SINCE THE PROBLEM IN THE DATABASE IS THAT ITS
        /// CURRENTLY ONLY INTEGER VALUES IN THE ID COLUMN. 
        /// THIS
        /// IS
        /// A
        /// TEMPORARY
        /// WORKAROUND
        /// AND HAS TO BE CHANGED WHEN THE DATABASE IS UPDATED TO BE SERIAL.
        /// Method uses GetMaxMemberID and adds +1 on it and returns new value;
        /// </summary>
        private int SetNewID()
        {
            int oldID = GetMaxMemberID();
            int newID = oldID + 1;
            return newID;
        }

        /// <summary>
        /// Seems like this method is not necessary. But save it for later just in case.
        /// Replaces comma sign with dot in double handikapp due to european (?)
        /// culture standard so it can be inserted into database correctly.
        /// </summary>
        /// <returns>Returns handicap with a dot instead. </returns>
        //private double ReplaceComma()
        //{
        //    string hcpString = handikapp.ToString();
        //    string hcpStringDot = hcpString.Replace(",", ".");
        //    double hcpDoubleDot = Convert.ToDouble(hcpStringDot);
        //    return hcpDoubleDot;
        //}

        public override string ToString()
        {
            return ID + " " + fornamn + " " + efternamn + " " + " " + handikapp;
        }
    }
}