using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Team_1_Halslaget_GK
{
    public partial class MyPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            BindListViews();
        }

        private void BindListViews()
        {
            ListViewFutureTeeTimes.DataSource = GetMockFutureTeeTimeData();
            ListViewFutureTeeTimes.DataBind();
        }

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

        protected void btnEditPersonInfo_Click(object sender, EventArgs e)
        {
        }
    }
}