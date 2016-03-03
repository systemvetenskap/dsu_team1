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
    public partial class SeasonSettings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                InitializeGUI();
            }
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

            cmd.Parameters.AddWithValue("@startdatum", calenderStartDate.SelectedDate);
            cmd.Parameters.AddWithValue("@slutdatum", calenderEndDate.SelectedDate);

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

        private void InitializeGUI()
        {
            SetYearInDropDown();

            calenderEndDate.Enabled = false;
            calenderStartDate.Enabled = false;

            CheckBox1to9.Checked = true;
            CheckBox10to18.Checked = true;
            CheckBoxRange.Checked = true;
        }

        /// <summary>
        /// Binds the dropdown list with a list of years.
        /// </summary>       
        private void SetYearInDropDown()
        {
            Season newSeason = new Season();
            dropDownYearSelect.DataSource = newSeason.CreateYearList();
            dropDownYearSelect.DataBind();
            this.dropDownYearSelect.Items.Insert(0, "Välj säsong");
        }

        /// <summary>
        /// Creates a startdate for the dayrender event to use.
        /// </summary>
        private DateTime SetStartDate(string year)
        {
            if (string.IsNullOrEmpty(year) || year == "Välj säsong")
            {
                string dateString = "2099-01-01";
                DateTime startDate = DateTime.Parse(dateString);

                return startDate;
            }
            else
            {
                string dateString = year + "-01-01";
                DateTime startDate = DateTime.Parse(dateString);

                return startDate;
            }
        }

        /// <summary>
        /// Creates a startdate for the dayrender event to use.
        /// </summary>
        private DateTime SetEndDate(string year)
        {
            if (string.IsNullOrEmpty(year) || year == "Välj säsong")
            {
                string dateString = "2099-12-31";
                DateTime endDate = DateTime.Parse(dateString);

                return endDate;
            }
            else
            {
                string dateString = year + "-12-31";
                DateTime endDate = DateTime.Parse(dateString);

                return endDate;
            }
        }

        /// <summary>
        /// Event for when user changes what year to work with.
        /// </summary>
        protected void dropDownYearSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(dropDownYearSelect.Text == "Välj säsong")
            {
                calenderStartDate.Enabled = false;   
                calenderEndDate.Enabled = false;
            }
            else
            {
                calenderEndDate.Enabled = true;
                calenderStartDate.Enabled = true;   
            }      
        }

        /// <summary>
        /// Dayrender event. It does alot of stuff this one.
        /// </summary>
        protected void calenderStartDate_DayRender(object sender, DayRenderEventArgs e)
        {
            if(!IsPostBack)
            {
                string year = "";
                DateTime start = SetStartDate(year);
                DateTime end = SetEndDate(year);
                if ((e.Day.Date < start) || (e.Day.Date > end))
                {
                    e.Day.IsSelectable = false;
                    e.Cell.ForeColor = System.Drawing.Color.Black;
                    e.Cell.BackColor = System.Drawing.Color.Gray;
                    e.Cell.Style.Add("cursor", "not-allowed");
                    e.Cell.ToolTip = "Du måste välja vilket säsongsår först.";
                }
            }
            else
            {
                string year = dropDownYearSelect.Text; ;
                DateTime start = SetStartDate(year);
                DateTime end = SetEndDate(year);

                if(start <= DateTime.Today)
                {
                    start = DateTime.Today;
                    if ((e.Day.Date < start) || (e.Day.Date > end))
                    {
                        e.Day.IsSelectable = false;
                        e.Cell.ForeColor = System.Drawing.Color.Black;
                        e.Cell.BackColor = System.Drawing.Color.Gray;
                        e.Cell.Style.Add("cursor", "not-allowed");
                        e.Cell.ToolTip = "Du måste välja vilket säsongsår först.";
                    }
                }
                else
                {
                    if ((e.Day.Date < start) || (e.Day.Date > end))
                    {
                        e.Day.IsSelectable = false;
                        e.Cell.ForeColor = System.Drawing.Color.Black;
                        e.Cell.BackColor = System.Drawing.Color.Gray;
                        e.Cell.Style.Add("cursor", "not-allowed");
                        e.Cell.ToolTip = "Du måste välja vilket säsongsår först.";
                    }
                }
            }
        }

        /// <summary>
        /// Dayrender event. It does alot of stuff this one.
        /// </summary>
        protected void calenderEndDate_DayRender(object sender, DayRenderEventArgs e)
        {
            if (!IsPostBack)
            {
                string year = "";
                DateTime start = SetStartDate(year);
                DateTime end = SetEndDate(year);
                if ((e.Day.Date < start) || (e.Day.Date > end))
                {
                    e.Day.IsSelectable = false;
                    e.Cell.ForeColor = System.Drawing.Color.Black;
                    e.Cell.BackColor = System.Drawing.Color.Gray;
                    e.Cell.Style.Add("cursor", "not-allowed");
                    e.Cell.ToolTip = "Du måste välja vilket säsongsår först.";
                }
            }
            else
            {
                if(calenderStartDate.SelectedDate.Date == DateTime.MinValue) //No date choosen in calenderstart.
                {
                    string year = "";
                    DateTime start = SetStartDate(year);
                    DateTime end = SetEndDate(year);
                    if ((e.Day.Date < start) || (e.Day.Date > end))
                    {
                        e.Day.IsSelectable = false;
                        e.Cell.ForeColor = System.Drawing.Color.Black;
                        e.Cell.BackColor = System.Drawing.Color.Gray;
                        e.Cell.Style.Add("cursor", "not-allowed");
                        e.Cell.ToolTip = "Du måste välja vilket säsongsår först.";
                    }
                }
                else
                {
                    string year = dropDownYearSelect.Text;
                    DateTime start = calenderStartDate.SelectedDate.AddDays(1);
                    DateTime end = SetEndDate(year);

                    if ((e.Day.Date < start) || (e.Day.Date > end))
                    {
                        e.Day.IsSelectable = false;
                        e.Cell.ForeColor = System.Drawing.Color.Black;
                        e.Cell.BackColor = System.Drawing.Color.Gray;
                        e.Cell.Style.Add("cursor", "not-allowed");
                        e.Cell.ToolTip = "TEST";
                    }
                }
            }
        }
        protected void calenderStartDate_SelectionChanged(object sender, EventArgs e)
        {
            txtStartDate.Text = calenderStartDate.SelectedDate.Date.ToString();
        }

        protected void calenderEndDate_SelectionChanged(object sender, EventArgs e)
        {
            txtEndDate.Text = calenderEndDate.SelectedDate.Date.ToString();
        }

        //Events that I tried with but failed. 
        protected void Calendar1_PreRender(object sender, EventArgs e)
        {

        }

        protected void calenderStartDate_PreRender(object sender, EventArgs e)
        {

        }

        protected void calenderEndDate_PreRender(object sender, EventArgs e)
        {

        }

        protected void calenderStartDate_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {

        }
    }
}