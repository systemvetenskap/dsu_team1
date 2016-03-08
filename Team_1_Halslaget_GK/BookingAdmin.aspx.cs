using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using System.Data;
using System.Drawing;

namespace Team_1_Halslaget_GK
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                lblTempBookingID.Text = GridView1.Rows[rowIndex].Cells[0].Text;
                lblTempDate.Text = GridView1.Rows[rowIndex].Cells[1].Text;
                lblTempStartTime.Text = GridView1.Rows[rowIndex].Cells[2].Text;
            }
        }

        private void BindGridView()
        {
            GridViewRow row = GridView2.SelectedRow;
            string medlemid = row.Cells[0].Text;


            Booking medlemObj = new Booking();

            Booking getBookings = new Booking();
            DataTable dt = getBookings.GetFutureTeeTimeData(medlemid);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            if (GridView1.Rows.Count == 0)
            {
                CancelBookingInfo.InnerText = "Medlem har inga bokade tider.";
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowIndex == GridView1.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#6C6C6C");
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                }
            }
        }

        protected void GridView1_SelectedIndexChanging(object sender, EventArgs e)
        {

        }

        protected void btnGoToBooking_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (TextBoxFirstName.Text == "" && TextBoxLastName.Text == "" && TextBoxGolfID.Text == "")
            {

            }

            else
            {
                Search();
            }
        }



        private string StorBokstavFnamn()
        {
            string fnamnSok = TextBoxFirstName.Text;
            string fnamnLower = fnamnSok.ToLower();
            char[] fnamnCharArray = fnamnLower.ToCharArray();
            fnamnCharArray[0] = char.ToUpper(fnamnCharArray[0]);
            return new string(fnamnCharArray);;  
        }

        private string StorBokstavEnamn()
        {
            string enamnSok = TextBoxLastName.Text;
            string enamnLower = enamnSok.ToLower();
            char[] enamnCharArray = enamnLower.ToCharArray();
            enamnCharArray[0] = char.ToUpper(enamnCharArray[0]);
            return new string(enamnCharArray);

        }
        private void Search()
        {
            string sql;
            string enamn ="";
            string fnamn = "";
            string golfid = "";

            if (TextBoxLastName.Text == "" && TextBoxGolfID.Text == "")
            {
                sql = "SELECT id, fornamn, efternamn, golfid FROM medlem WHERE fornamn LIKE @fornamn ORDER BY fornamn";
                fnamn = StorBokstavFnamn() + "%";
            }

            else if (TextBoxFirstName.Text == "" && TextBoxGolfID.Text == "")
            {
                sql = "SELECT id, fornamn, efternamn, golfid FROM medlem WHERE efternamn LIKE @efternamn ORDER BY efternamn";
                enamn = StorBokstavEnamn() + "%";
            }

            else if (TextBoxFirstName.Text == "" && TextBoxLastName.Text == "")
            {
                sql = "SELECT id, fornamn, efternamn, golfid FROM medlem WHERE efternamn LIKE @golfid ORDER BY golfid";
                golfid = TextBoxGolfID.Text + "%";
            }

            else if (TextBoxFirstName.Text == "")
            {
                sql = "SELECT id, fornamn, efternamn, golfid FROM medlem WHERE efternamn LIKE @efternamn AND golfid LIKE @golfid ORDER BY efternamn";
                enamn = StorBokstavEnamn() + "%";
                golfid = TextBoxGolfID.Text + "%";
            }

            else if (TextBoxLastName.Text == "")
            {
                sql = "SELECT id, fornamn, efternamn, golfid FROM medlem WHERE fornamn LIKE @fornamn AND golfid LIKE @golfid ORDER BY fornamn";
                golfid = TextBoxGolfID.Text + "%";
                fnamn = StorBokstavFnamn() + "%";
            }

            else
            {
                sql = "SELECT id, fornamn, efternamn, golfid FROM medlem WHERE fornamn LIKE @fornamn AND efternamn LIKE @efternamn ORDER BY efternamn";
                fnamn = StorBokstavFnamn() + "%";
                enamn = StorBokstavEnamn() + "%";            
            }

            DataTable dt = new DataTable();

            NpgsqlConnection con = new NpgsqlConnection("Server=webblabb.miun.se; Port=5432; Database=dsu_golf; User Id=dsu_g1; Password=dsu_g1; SslMode=Require");

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con);

            da.SelectCommand.Parameters.AddWithValue("@fornamn", fnamn);
            da.SelectCommand.Parameters.AddWithValue("@efternamn", enamn);
            da.SelectCommand.Parameters.AddWithValue("@golfid", golfid);

            try
            {
                con.Open();
                da.Fill(dt);
            }
            
            catch (NpgsqlException ex)
            {

            }

            finally
            {
                con.Close();
                con.Dispose();
            }
            
            if (dt.Rows.Count > 0)
            {
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }

            else
            {
                // Fel
            }

            con.Close();
            con.Dispose();
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridView();
        }

        protected void btnCancelBooking_Click(object sender, EventArgs e)
        {
            Booking cancel = new Booking();
            GridViewRow row = GridView1.SelectedRow;
            string bookingID = row.Cells[0].Text;
            cancel.CancelBooking(bookingID);
        }
    }
}