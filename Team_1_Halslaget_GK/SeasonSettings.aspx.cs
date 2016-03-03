using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;

namespace Team_1_Halslaget_GK
{
    public partial class SeasonSettings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSetSeason_Click(object sender, EventArgs e)
        {
            string sql ="";

            if (CheckBox1to9.Checked && CheckBox10to18.Checked && CheckBoxRange.Checked)
            {
                sql = "INSERT INTO season (startdatum, slutdatum, bana) VALUES (@startdatum, @slutdatum, '1-9'),(@startdatum, @slutdatum, '10-18'),(@startdatum, @slutdatum, 'range')";
            }

            else if (CheckBox1to9.Checked && CheckBox10to18.Checked)
            {
                sql = "INSERT INTO season (startdatum, slutdatum, bana) VALUES (@startdatum, @slutdatum, '1-9'),(@startdatum, @slutdatum, '10-18')";
            }

            else if (CheckBox1to9.Checked && CheckBoxRange.Checked)
            {
                sql = "INSERT INTO season (startdatum, slutdatum, bana) VALUES (@startdatum, @slutdatum, '1-9'),(@startdatum, @slutdatum, 'range')";               
            }

            else if (CheckBox10to18.Checked && CheckBoxRange.Checked)
            {
                sql = "INSERT INTO season (startdatum, slutdatum, bana) VALUES (@startdatum, @slutdatum, '10-18'),(@startdatum, @slutdatum, 'range')";
            }

            else if (CheckBox1to9.Checked)
            {
                sql = "INSERT INTO season (startdatum, slutdatum, bana) VALUES (@startdatum, @slutdatum, '1-9')";
            }

            else if (CheckBox10to18.Checked)
            {
                sql = "INSERT INTO season (startdatum, slutdatum, bana) VALUES (@startdatum, @slutdatum, '10-18')";
            }

            else if (CheckBoxRange.Checked)
            {
                sql = "INSERT INTO season (startdatum, slutdatum, bana) VALUES (@startdatum, @slutdatum, 'range')";
            }

            NpgsqlConnection con = new NpgsqlConnection("Server=webblabb.miun.se; Port=5432; Database=dsu_golf; User Id=dsu_g1; Password=dsu_g1; SslMode=Require");
            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@startdatum", Calendar1.SelectedDate);
            cmd.Parameters.AddWithValue("@slutdatum", Calendar2.SelectedDate);

            try
            {
                con.Open();

                cmd.ExecuteNonQuery();
            }

            catch
            {
                NpgsqlException ex;
            }

            finally
            {
                con.Close();
                con.Dispose();

                //Confirmation på att man gjort något
            }
        }
    }
}