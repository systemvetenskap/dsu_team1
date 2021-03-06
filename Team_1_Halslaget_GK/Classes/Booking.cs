﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.Data;
using System.Web.Configuration;

namespace Team_1_Halslaget_GK
{
    public class Booking
    {
        NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
        //Properties
        public int ID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime Date { get; set; }
        public string lagid { get; set; }
        public string tavlingid { get; set; }

        /// <summary>
        /// Method retrieves booked tee times for a member.
        /// </summary>
        public DataTable GetFutureTeeTimeData(string memberID)
        {
            try
            {
                conn.Open();
                string sql = "SELECT bokningsnr, datum, starttid FROM medlem_bokning INNER JOIN bokning ON bokning_id = slot_id WHERE medlem_id = @id AND datum > CURRENT_DATE";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", memberID);
                NpgsqlDataAdapter nda = new NpgsqlDataAdapter();
                nda.SelectCommand = cmd;
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
        /// Deletes a certain members booking based on the bookingnumber.
        /// </summary>
        /// <param name="bokningsnr"></param>
        public void CancelBooking(string bokningsnr)
        {
            try
            {
                conn.Open();
                string sql = "DELETE FROM medlem_bokning WHERE bokningsnr = @bokningsnr";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@bokningsnr", bokningsnr);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                NpgsqlException ex;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        // Adds a new booking to a signed in member.
        public bool Newbooking(int medlems_id, int boknings_id, DateTime date)
        {
            try
            {
                string sql = "INSERT INTO medlem_bokning (medlem_id, bokning_id, datum) VALUES (@medlem_id, @bokning_id, @datum)";
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@medlem_id", medlems_id);
                cmd.Parameters.AddWithValue("@bokning_id", boknings_id);
                cmd.Parameters.AddWithValue("@datum", date);

                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                return false;
            }
            finally
            {
                conn.Close();                
            }
            return true;

        }

    }
}