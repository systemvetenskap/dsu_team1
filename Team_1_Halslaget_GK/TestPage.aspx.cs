using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using System.Data;
using System.Web.Configuration;

namespace Team_1_Halslaget_GK
{
    public partial class TestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private void TestDates()
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int test1 = Convert.ToInt32(TextBox1.Text);
            DateTime test2 = DateTime.Now;
            string test3 = TextBox3.Text;

            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            try
            {
                conn.Open();
                NpgsqlCommand cmdInsertTestToNyhet = new NpgsqlCommand("INSERT INTO nyhet (id, publ_date, txt) VALUES (@test1, '2016-03-01', 'Hej')", conn);
                cmdInsertTestToNyhet.Parameters.AddWithValue("@test1", test1);
                cmdInsertTestToNyhet.Parameters.AddWithValue("@test2", test2);
                cmdInsertTestToNyhet.Parameters.AddWithValue("@test3", test3);
                cmdInsertTestToNyhet.ExecuteNonQuery();             
            }
            catch (NpgsqlException ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            string startDate = "2016-05-01";
            string endDate = "2016-08-30";
            DateTime start = DateTime.Parse(startDate);
            DateTime end = DateTime.Parse(endDate);

            if((e.Day.Date < start) || (e.Day.Date > end))
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Black;
                e.Cell.BackColor = System.Drawing.Color.Gray;
                e.Cell.Style.Add("cursor", "not-allowed");
                e.Cell.ToolTip = "Du kan inte boka dessa tider. Det är utan för golfsäsongen.";
            }

        }
    }
}