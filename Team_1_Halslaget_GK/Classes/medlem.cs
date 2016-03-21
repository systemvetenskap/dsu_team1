//Jacob Hyllengren (some dated)
//Revised Erik Drysén 2016-03-01.
//Revised Erik Drysén 2016-03-04.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.Data;
using System.Web.Configuration;
using System.Globalization;

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
        public string golfid { get; set; }
        
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
                NpgsqlCommand cmdGetMemberInfo = new NpgsqlCommand("SELECT id, fornamn, efternamn, adress, postnummer, ort, epost, hcp, medlemskategori, telefonnummer, medlemsavgift_betald FROM medlem WHERE id = @id", conn);
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
                NpgsqlCommand cmdInsertNewMember = new NpgsqlCommand("INSERT INTO medlem (id, fornamn, efternamn, adress, postnummer, ort, epost, kon, hcp, golfid, medlemskategori, telefonnummer, medlemsavgift_betald, admin) " +
                                                                        " VALUES (@id, @fornamn, @efternamn, @adress, @postnummer, @ort, @epost, @kon, @hcp, @golfid, @medlemsKategori, @telefonnummer, @paydate, @adminStatus); ", conn);

                cmdInsertNewMember.Parameters.AddWithValue("@id", ID);
                cmdInsertNewMember.Parameters.AddWithValue("@fornamn", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(fornamn.ToLower()));
                cmdInsertNewMember.Parameters.AddWithValue("@efternamn", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(efternamn.ToLower()));
                cmdInsertNewMember.Parameters.AddWithValue("@adress", adress);
                cmdInsertNewMember.Parameters.AddWithValue("@postnummer", postnummer);
                cmdInsertNewMember.Parameters.AddWithValue("@ort", ort);
                cmdInsertNewMember.Parameters.AddWithValue("@epost", epost);
                cmdInsertNewMember.Parameters.AddWithValue("@kon", kon);
                cmdInsertNewMember.Parameters.AddWithValue("@hcp", handikapp);
                cmdInsertNewMember.Parameters.AddWithValue("@golfid", golfID);
                cmdInsertNewMember.Parameters.AddWithValue("@medlemsKategori", medlemsKategori);
                cmdInsertNewMember.Parameters.AddWithValue("@telefonnummer", telefonNummer);
                cmdInsertNewMember.Parameters.AddWithValue("@paydate", payDate);
                cmdInsertNewMember.Parameters.AddWithValue("@adminStatus", false); //Temporary work around should be changed later so one can insert an admin later.

                cmdInsertNewMember.ExecuteNonQuery();

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
        /// Genereates a random number with 5 digits and creates it with the new id for the member. 
        /// </summary>
        /// <returns></returns>
        private string CreateGolfID()
        {
            int newID = SetNewID();
            Random r = new Random();
            double randomNum = r.Next(10000, 99999);
            string golfID = randomNum.ToString() +"_" + newID.ToString();
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
        /// Method gets all the members in the database.
        /// </summary>
        /// <returns>List with all members.</returns>
        public List<medlem> GetAllMembers()
        {
            List<medlem> medlemmar = new List<medlem>();
            NpgsqlConnection con = new NpgsqlConnection("Server=webblabb.miun.se; Port=5432; Database=dsu_golf; User Id=dsu_g1; Password=dsu_g1; SslMode=Require");
            try
            {
                string sql = "SELECT id, fornamn, efternamn, hcp FROM medlem";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);


                con.Open();

                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    medlem nymedlem = new medlem();
                    nymedlem.ID = Convert.ToInt32(dr["id"]);
                    nymedlem.fornamn = Convert.ToString(dr["fornamn"]);
                    nymedlem.efternamn = Convert.ToString(dr["efternamn"]);
                    nymedlem.handikapp = Convert.ToDouble(dr["hcp"]);

                    medlemmar.Add(nymedlem);
                }
                return medlemmar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }            
        }

        /// <summary>
        /// Method updates a members information from the admin side.
        /// </summary>
        /// <returns></returns>
        public bool AdminUpdateMemberInfo()
        {
            NpgsqlConnection con = new NpgsqlConnection("Server=webblabb.miun.se; Port=5432; Database=dsu_golf; User Id=dsu_g1; Password=dsu_g1; SslMode=Require");
            try
            {
                DateTime payDate = SetMedlemsAvgiftDate();
                string sql = "UPDATE medlem SET fornamn = @fornamn, efternamn = @efternamn, adress = @adress, postnummer = @postnummer, ort = @ort, epost = @epost, hcp = @handikapp, telefonnummer = @telefonnummer, medlemsavgift_betald = @paydate WHERE id = @id"; 


                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@fornamn", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(fornamn.ToLower()));
                cmd.Parameters.AddWithValue("@efternamn", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(efternamn.ToLower()));
                cmd.Parameters.AddWithValue("@adress", adress);
                cmd.Parameters.AddWithValue("@postnummer", postnummer);
                cmd.Parameters.AddWithValue("@ort", ort);
                cmd.Parameters.AddWithValue("@epost", epost);
                cmd.Parameters.AddWithValue("@handikapp", handikapp);
                cmd.Parameters.AddWithValue("@telefonnummer", telefonNummer);
                cmd.Parameters.AddWithValue("@paydate", payDate);

                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }

        }

        /// <summary>
        /// Method deletes a member from the database.
        /// </summary>
        public void DeleteMember()
        {

            NpgsqlConnection con = new NpgsqlConnection("Server=webblabb.miun.se; Port=5432; Database=dsu_golf; User Id=dsu_g1; Password=dsu_g1; SslMode=Require");
            try
            {
                string sql = "DELETE FROM medlem WHERE id = @id;";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", ID);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public DataTable GetMemberWithGolfID(string golfID)
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            try
            {
                string golfID1 = golfID;
                conn.Open();
                NpgsqlCommand cmdGetMemberInfo = new NpgsqlCommand("SELECT id, fornamn, efternamn,hcp FROM medlem WHERE golfid = @golfid; ", conn);
                cmdGetMemberInfo.Parameters.AddWithValue("@golfid", golfID1);
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

        public override string ToString()
        {
            return ID + " " + fornamn + " " + efternamn + " " + " " + handikapp;
        }

        public DataTable SearchMember(string fornamn, string efternamn)
        {

            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

            try
            {
                string sql = "SELECT fornamn, efternamn, id FROM medlem WHERE fornamn ~* @fornamn AND efternamn ~* @efternamn OR fornamn ~* @efternamn AND efternamn ~* @fornamn";
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@fornamn", fornamn);
                cmd.Parameters.AddWithValue("@efternamn", efternamn);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                dt.Columns.Add("FullName", typeof(string), "fornamn+' '+efternamn");
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
    }
}