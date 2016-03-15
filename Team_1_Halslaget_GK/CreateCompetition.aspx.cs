using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Npgsql;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;

namespace Team_1_Halslaget_GK
{
    public partial class CreateCompetition : System.Web.UI.Page
    {
        NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["Username"] == null && Session["admin"] == null)
            //{
            //    Response.Redirect("~/NotAllowed.aspx");
            //}
            if (!IsPostBack)
            {
                fillTime();
                Calendar1.SelectedDate = DateTime.Today;
            }           
        }

        public void fillTime()
        {
            string sql = "SELECT * FROM bokning ORDER BY slot_id ASC";
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter();
            nda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            nda.Fill(dt);
            ddlendtime.DataSource = dt;
            ddlstarttime.DataSource = dt;

            ddlstarttime.DataTextField = "starttid";
            ddlendtime.DataTextField = "starttid";

            ddlendtime.DataBind();
            ddlstarttime.DataBind();

            ddlstarttime.Items.Insert(0, new ListItem("Välj starttid", "Välj starttid"));
            ddlendtime.Items.Insert(0, new ListItem("Välj sluttid", "Välj sluttid"));

        }

        public void CreateComp()
        {
            Competition newComp = new Competition();

            newComp.desc = tbCompDesc.Text;
            newComp.namn = tbCompName.Text;
            newComp.starttid = ddlstarttime.SelectedItem.ToString();
            newComp.sluttid = ddlendtime.SelectedItem.ToString();
            newComp.date = Calendar1.SelectedDate;
            newComp.type = ddlCompType.SelectedItem.ToString();
            newComp.firstRegDate = Calendar1.SelectedDate.AddDays(-14);
            newComp.lastRegDate = Calendar1.SelectedDate.AddDays(-2);

            string sql = "INSERT INTO tavling (datum, starttid, sluttid, description, namn, type, firstregdate, lastregdate) VALUES(@datum, @starttid, @sluttid, @description, @namn, @type, @firstregdate, @lastregdate)";
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@datum", newComp.date);       
            cmd.Parameters.AddWithValue("@starttid", newComp.starttid);
            cmd.Parameters.AddWithValue("@sluttid", newComp.sluttid);
            cmd.Parameters.AddWithValue("@description", newComp.desc);
            cmd.Parameters.AddWithValue("@namn", newComp.namn);
            cmd.Parameters.AddWithValue("@type", newComp.type.ToLower());
            cmd.Parameters.AddWithValue("@firstregdate", newComp.firstRegDate);
            cmd.Parameters.AddWithValue("@lastregdate", newComp.lastRegDate);

            cmd.ExecuteNonQuery();
            conn.Close();

            Resetpage();
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            CreateComp();
        }

        public void Resetpage()
        {
            Calendar1.SelectedDate = DateTime.Today;
            tbCompName.Text = "";
            tbCompDesc.Text = "";
            ddlCompType.SelectedIndex = 0;
            ddlstarttime.SelectedIndex = 0;
            ddlendtime.SelectedIndex = 0;
        }
    } 
}