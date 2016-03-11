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
        int times = 0;
        string date;
        List<string> booking = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            bookDate.Visible = false;
        }
        protected void newDate_Click(object sender, EventArgs e)
        {
            times += 1;
            if (!Page.IsPostBack)
            {
                dateFiller.InnerHtml = "";
            }
            else
            {
                bookDate.Visible = true;
                dateFiller.InnerHtml += "<ul>";
                dateFiller.InnerHtml += "<li>" + dropDownMonth.Text.ToString() + " " + dropDownDay.Text + "</li>";
                dateFiller.InnerHtml += "</ul>";
                date = dropDownYear.Text.ToString() + "-" + dropDownMonth.Text.ToString() + "-" + dropDownDay.Text.ToString();
            }
        }
        protected void bookDate_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < times; i++)
            //{
            string competitionChecked = "";
            if (checkBoxLag.Checked == true)
            {
                competitionChecked = "lag";
            }
            else
            {
                competitionChecked = "singel";
            }
            DateTime datum = Convert.ToDateTime(date);
            string sql = "INSERT INTO tavling (datum, description, namn, type) VALUES ('" + datum + "', '" + descriptionBox.InnerText + "', '" + nameBox.Text + "', '" + competitionChecked + "');";
            NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se; Port=5432; Database=dsu_golf; User Id=dsu_g1; Password=dsu_g1; SslMode=Require");
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            dateFiller.InnerHtml = "";
            //}
        }
    }
}