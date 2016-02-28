//Code behind for mypage.aspx. Mainly controls for the GUI and that kinda of interaction. 
//Is going to use instances of other and future classes. At the moment, there is
//datatables with mockdata.
//Erik Drysén 2016-02-27.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Web.UI.HtmlControls; 

namespace Team_1_Halslaget_GK
{
    public partial class MyPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            BindGridView();
            SetMemberInfoLabels();
            SetMemberTextBoxes();

            //Sets cancelbooking button to disabled so user has to choose what time to cancel before one can press said button.

        }

        /// <summary>
        /// Binds the mock datatable with the gridview.
        /// </summary>
        private void BindGridView()
        {
            //ListViewFutureTeeTimes.DataSource = GetMockFutureTeeTimeData();
            //ListViewFutureTeeTimes.DataBind();

            GridView1.DataSource = GetMockFutureTeeTimeData();
            GridView1.DataBind();
        }

        /// <summary>
        /// Method uses Getmemberinfo to retreive a
        /// mock datatable to set labels on gui
        /// </summary>
        private void SetMemberInfoLabels()
        {
            DataTable dt = GetMemberInfo();
            lblFirstName.Text = dt.Rows[0]["firstname"].ToString();
            lblLastName.Text = dt.Rows[0]["lastname"].ToString();
            lblPhoneNum.Text = dt.Rows[0]["phonenumber"].ToString();
            lblEmail.Text = dt.Rows[0]["email"].ToString();
            lblStreet.Text = dt.Rows[0]["street"].ToString();
            lblPostalCode.Text = dt.Rows[0]["postalcode"].ToString();
            lblCity.Text = dt.Rows[0]["city"].ToString();
            lblCurrentHandicap.Text = dt.Rows[0]["handicap"].ToString();
        }

        /// <summary>
        /// Method uses getmemberinfo to retreive a 
        /// mock datatable to set txtboxes on gui.
        /// </summary>
        private void SetMemberTextBoxes()
        {
            DataTable dt = GetMemberInfo();

            txtFirstName.Text = dt.Rows[0]["firstname"].ToString();
            txtLastName.Text = dt.Rows[0]["lastname"].ToString();
            txtPhoneNum.Text = dt.Rows[0]["phonenumber"].ToString();
            txtEmail.Text = dt.Rows[0]["email"].ToString();
            txtStreet.Text = dt.Rows[0]["street"].ToString();
            txtPostalCode.Text = dt.Rows[0]["postalcode"].ToString();
            txtCity.Text = dt.Rows[0]["city"].ToString();
        }

        /// <summary>
        /// A method which returns a mock datatable with some fake values
        /// To be removed.
        /// </summary>
        /// <returns></returns>
        private DataTable GetMockFutureTeeTimeData()
        {
            string date1 = "2016-03-15";
            string date2 = "2016-03-30";
            string starttime1 = "07:10";
            string starttime2 = "15:40";

            DataTable MockTeeTime = new DataTable();

            MockTeeTime.Columns.Add("id", typeof(int));
            MockTeeTime.Columns.Add("date", typeof(DateTime));
            MockTeeTime.Columns.Add("starttime", typeof(DateTime));
            //MockTeeTime.Columns.Add("emptymessage", typeof(string));
            
            MockTeeTime.Rows.Add(1, Convert.ToDateTime(date1), Convert.ToDateTime(starttime1));
            MockTeeTime.Rows.Add(2, Convert.ToDateTime(date2), Convert.ToDateTime(starttime2));
            MockTeeTime.Rows.Add(3, Convert.ToDateTime(date1), Convert.ToDateTime(starttime1));
            MockTeeTime.Rows.Add(4, Convert.ToDateTime(date2), Convert.ToDateTime(starttime2));
            MockTeeTime.Rows.Add(5, Convert.ToDateTime(date1), Convert.ToDateTime(starttime1));
            MockTeeTime.Rows.Add(6, Convert.ToDateTime(date2), Convert.ToDateTime(starttime2));

            return MockTeeTime;            
        }

        /// <summary>
        /// Method creates a datatable with mock data to fill
        /// the gui with things for test purpoese.
        /// </summary>
        /// <returns></returns>
        private DataTable GetMemberInfo()
        {

            DataTable MockTeeTime = new DataTable();

            MockTeeTime.Columns.Add("firstname", typeof(string));
            MockTeeTime.Columns.Add("lastname", typeof(string));
            MockTeeTime.Columns.Add("phonenumber", typeof(string));
            MockTeeTime.Columns.Add("email", typeof(string));
            MockTeeTime.Columns.Add("street", typeof(string));
            MockTeeTime.Columns.Add("postalcode", typeof(string));
            MockTeeTime.Columns.Add("city", typeof(string));
            MockTeeTime.Columns.Add("handicap", typeof(string));

            MockTeeTime.Rows.Add("John", "Doe", "555-32 43 45", "john.doe@email.com", "The Street", "78123", "The City", "23");

            return MockTeeTime;
        }

        protected void btnEditPersonInfo_Click(object sender, EventArgs e)
        {
        }

        protected void ListViewFutureTeeTimes_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                    row.BackColor = ColorTranslator.FromHtml("#E5C100");
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                }
            }
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

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }
    }
}