//Code behind for mypage.aspx. Mainly controls for the GUI and that kinda of interaction. 
//Is going to use instances of other and future classes. At the moment, there is SOME
//datatables with mockdata and some use of the proper database.
//Erik Drysén 2016-02-27.
//Revised 2016-03-04 Erik Drysén

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Web.UI.HtmlControls;
using Npgsql;
using System.Globalization;
using System.IO;

namespace Team_1_Halslaget_GK
{
    public partial class MyPage : System.Web.UI.Page
    {
        //Field for medlems object.
        medlem medlemObj;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["Username"] == null)
            //{
            //    Response.Redirect("~/NotAllowed.aspx");
            //}
            if(!IsPostBack)
            {
                InitializeGUI();
            }
        }

        /// <summary>
        /// To initilize values that is meant to be shown for the user when he/she logs in
        /// Uses other method to get said vaules.
        /// </summary>
        private void InitializeGUI()
        {
            //Initialize medlem object.
            medlemObj = new medlem();

            //Row 43 and 44, Set medlemID, currently ASSUMING that when user/member is logged in member/username vill be displayed in lblUserName 
            //and either a method is being used to retrieve member ID from database or it comes with a session. Some of it anyway.
            medlemObj.ID = Convert.ToInt32(Session["Username"]); //ID kommer in med session här, bara att aktivera när det är dags/jacob
            lblMemberID.Text = medlemObj.ID.ToString();

            BindGridView();
            SetMemberInfoLabels();
            SetMemberTextBoxes();
            SetCompGrid();
        }

        /// <summary>
        /// Binds gridview with datatable using method from BOoking class to retrieve
        /// data.
        /// </summary>
        private void BindGridView()
        {
            Booking getBookings = new Booking();
            DataTable dt = getBookings.GetFutureTeeTimeData(medlemObj.ID.ToString());
            GridView1.DataSource = dt;
            GridView1.DataBind();

            if(GridView1.Rows.Count == 0)
            {
                CancelBookingInfo.InnerText = "Du har inga kommande bokade tider!";
            }
        }

        /// <summary>
        /// Method uses medelobj to retrieve a specific member and sets labels on GUI.
        /// </summary>
        private void SetMemberInfoLabels()
        {
            DataTable dt = medlemObj.GetSpecificMember();

            lblFirstName.Text = dt.Rows[0]["fornamn"].ToString();
            lblUserName.Text = dt.Rows[0]["fornamn"].ToString();
            lblLastName.Text = dt.Rows[0]["efternamn"].ToString();
            lblPhoneNum.Text = dt.Rows[0]["telefonnummer"].ToString();
            lblEmail.Text = dt.Rows[0]["epost"].ToString();
            lblStreet.Text = dt.Rows[0]["adress"].ToString();
            lblPostalCode.Text = dt.Rows[0]["postnummer"].ToString();
            lblCity.Text = dt.Rows[0]["ort"].ToString();
            lblCurrentHandicap.Text = dt.Rows[0]["hcp"].ToString();
            lblAmountOfRounds.Text = GetRoundStatistics();

            PaymentReminder(Convert.ToDateTime(dt.Rows[0]["medlemsavgift_betald"]));
        }

        /// <summary>
        /// Method uses medelobj to retrieve a specific member and sets labels on GUI.
        /// </summary>
        /// 
        private void SetMemberTextBoxes()
        {
            DataTable dt = medlemObj.GetSpecificMember();

            txtFirstName.Text = dt.Rows[0]["fornamn"].ToString();
            txtLastName.Text = dt.Rows[0]["efternamn"].ToString();
            txtPhoneNum.Text = dt.Rows[0]["telefonnummer"].ToString();
            txtEmail.Text = dt.Rows[0]["epost"].ToString();
            txtStreet.Text = dt.Rows[0]["adress"].ToString();
            txtPostalCode.Text = dt.Rows[0]["postnummer"].ToString();
            txtCity.Text = dt.Rows[0]["ort"].ToString();
        }

        /// <summary>
        /// A method which returns a mock datatable with some fake values
        /// To be removed and replaced with a proper method.
        /// </summary>
        /// <returns></returns>
        /// 

        private DataTable GetFutureTeeTimeData()
        {
            DataTable TeeTime = new DataTable();

            string sql = "SELECT bokningsnr, datum, starttid FROM medlem_bokning INNER JOIN bokning ON bokning_id = slot_id WHERE medlem_id = @id AND datum > CURRENT_DATE";
            NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se; Port=5432; Database=dsu_golf; User Id=dsu_g1; Password=dsu_g1; SslMode=Require");

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@id", Session["Username"].ToString());

            try
            {
                conn.Open();
                da.Fill(TeeTime);
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

            CancelBookingInfo.InnerText = "Du har inga bokade tider";
            return TeeTime;
        }

        private void SetCompGrid()
        {
            Competition newcomp = new Competition();
            DataTable dt1 = newcomp.GetComingCompetitionMember(medlemObj.ID);
            DataTable dt2 = newcomp.GetComingTeamCompetitionMember(medlemObj.ID);

            dt1.Merge(dt2);

            GridView2.DataSource = dt1;
            GridView2.DataBind();
        }

        /// <summary>
        /// When user selects a row this event highlights and changes the colour.
        /// </summary>
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

        /// <summary>
        /// Sets propertis in medlem class and triggers UpdateMemberInfo in same class
        /// to update member info in database. 
        /// </summary>
        /// 
        protected void btnUpdateUserinfo_Click(object sender, EventArgs e)
        {
            medlemObj = new medlem();

            medlemObj.ID = Convert.ToInt32(lblMemberID.Text);
            medlemObj.fornamn = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtFirstName.Text.ToLower());
            medlemObj.efternamn = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtLastName.Text.ToLower());
            medlemObj.adress = txtStreet.Text;
            medlemObj.postnummer = txtPostalCode.Text;
            medlemObj.ort = txtCity.Text;
            medlemObj.epost = txtEmail.Text;
            medlemObj.telefonNummer = txtPhoneNum.Text;

            medlemObj.UpdateMemberInfo();

            //Updates the GUI with newest values again. 
            InitializeGUI();
        }

        /// <summary>
        /// Event for canceling a booked time.
        /// </summary>
        protected void btnCancelBooking_Click(object sender, EventArgs e)
        {
            Booking cancel = new Booking();
            GridViewRow row = GridView1.SelectedRow;
            string bookingID = row.Cells[0].Text;
            cancel.CancelBooking(bookingID);

            InitializeGUI();
        }

        /// <summary>
        /// Uses the built in command something to take values from the gridview and store in 
        /// labels that can be found on the frontend of this.
        /// </summary>
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName =="Select")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                lblTempBookingID.Text = GridView1.Rows[rowIndex].Cells[0].Text;   
                lblTempDate.Text = GridView1.Rows[rowIndex].Cells[1].Text;
                lblTempStartTime.Text = GridView1.Rows[rowIndex].Cells[2].Text;
            }
        }

        protected string GetRoundStatistics()
        {
            string sql = "SELECT count(medlem_id) FROM medlem_bokning WHERE medlem_id = @id AND datum < CURRENT_DATE";
            NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se; Port=5432; Database=dsu_golf; User Id=dsu_g1; Password=dsu_g1; SslMode=Require");

            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

            conn.Open();

            cmd.Parameters.AddWithValue("@id", lblMemberID.Text);

            string rundor = Convert.ToString(cmd.ExecuteScalar());

            return rundor;
        }

        protected void PaymentReminder(DateTime latest)
        {
            DateTime reminddate = latest.AddMonths(11);

            if (latest.AddYears(1) < DateTime.Today)
            {
                lblPaymentReminder.Text = "Ditt medlemsskap har gått ut. Du måste betala medlemsavgiften för att fortsätta vara medlem";
                lblPaymentReminder.Visible = true;
            }

            else if (reminddate < DateTime.Today)
            {
                latest.AddYears(1);
                lblPaymentReminder.Text = "Kom ihåg att betala din medlemsavgift innan den " + latest.Day + "/" + latest.Month + " - " + latest.Year + ".";
                lblPaymentReminder.Visible = true;
            }
        }

        protected void btnGoToAccountSettings_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ChangePassword.aspx");

        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void btnEditPersonInfo_Click(object sender, EventArgs e)
        {

        }

        protected void ListViewFutureTeeTimes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnGoToBooking_Click(object sender, EventArgs e)
        {
            Session["userID"] = lblMemberID.Text;
            Response.Redirect("~/Tidsbokning.aspx");              

        }

        protected void btnShowStartList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ViewStartList.aspx");
            
        }

        protected void btnGoToDiary_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CreateDagbokNote.aspx");
        }

    }
}