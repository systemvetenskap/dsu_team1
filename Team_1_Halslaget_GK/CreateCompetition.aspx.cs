using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Npgsql;
using System.Web.UI.WebControls;

namespace Team_1_Halslaget_GK
{
    public partial class CreateCompetition : System.Web.UI.Page
    {
        string date = "";
        List<string> dateList = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            bookDate.Visible = false;
        }
        protected void newDate_Click(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dateFiller.InnerHtml = "";
            }
            else
            {
                bookDate.Visible = true;
                dateFiller.InnerHtml += "<ul>";
                dateFiller.InnerHtml += "<li>" + dropDownMonth.Text + " " + dropDownDay.Text + "</li>";
                dateFiller.InnerHtml += "</ul>";
                date = dropDownYear.Text + "-" + dropDownMonth.Text + "-" + dropDownDay.Text;
                dateList.Add(date);
                date = "";
            }
        }
        protected void bookDate_Click(object sender, EventArgs e)
        {
            string competitionChecked = "";
            if (checkBoxLag.Checked == true)
            {
                competitionChecked = "lag";
            }
            else
            {
                competitionChecked = "singel";
            }
            foreach (var item in dateList)
            {
                string thisDate = item;
                DateTime datum = Convert.ToDateTime(thisDate);
                string sql = "INSERT INTO tavling (datum, description, namn, type) VALUES ('" + datum + "', '" + descriptionBox.InnerText + "', '" + nameBox.Text + "', '" + competitionChecked + "');";
                NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se; Port=5432; Database=dsu_golf; User Id=dsu_g1; Password=dsu_g1; SslMode=Require");
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            dateFiller.InnerHtml = "";
        }
    }
}