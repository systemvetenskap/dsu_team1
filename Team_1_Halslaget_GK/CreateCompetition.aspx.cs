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
            if (Session["Username"] == null && Session["admin"] == null)
            {
                Response.Redirect("~/NotAllowed.aspx");
            }
            if (!IsPostBack)
            {
                fillTime();
                fillTee();
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

            conn.Close();
            ddlstarttime.DataTextField = "starttid";
            ddlendtime.DataTextField = "starttid";

            ddlendtime.DataBind();
            ddlstarttime.DataBind();

            ddlstarttime.Items.Insert(0, new ListItem("Välj starttid", "Välj starttid"));
            ddlendtime.Items.Insert(0, new ListItem("Välj sluttid", "Välj sluttid"));

            ddlstarttime.Items.RemoveAt(67);
            ddlendtime.Items.RemoveAt(67);

        }

        public void fillTee()
        {
            string sql1 = "SELECT * FROM teetable WHERE gender = 1";
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sql1, conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable teeF = new DataTable();
            da.Fill(teeF);
            conn.Close();

            string sql2 = "SELECT * FROM teetable WHERE gender = 2";
            conn.Open();
            NpgsqlCommand cmd2 = new NpgsqlCommand(sql2, conn);
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter();
            da2.SelectCommand = cmd2;
            DataTable teeM = new DataTable();
            da2.Fill(teeM);
            conn.Close();

            ddlTeeF.DataSource = teeF;
            ddlTeeM.DataSource = teeM;

            ddlTeeF.DataTextField = "name";
            ddlTeeM.DataTextField = "name";
            ddlTeeF.DataValueField = "id";
            ddlTeeM.DataValueField = "id";

            ddlTeeF.DataBind();
            ddlTeeM.DataBind();

            ddlTeeM.Items.Insert(0, new ListItem("Välj tee för herrar", "Välj tee för herrar"));
            ddlTeeF.Items.Insert(0, new ListItem("Välj tee för damer", "Välj tee för damer"));
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
            newComp.teeM = Convert.ToInt32(ddlTeeM.SelectedValue);
            newComp.teeF = Convert.ToInt32(ddlTeeF.SelectedValue);

            string sql = "INSERT INTO tavling (datum, starttid, sluttid, description, namn, type, firstregdate, lastregdate, teem, teef) VALUES(@datum, @starttid, @sluttid, @description, @namn, @type, @firstregdate, @lastregdate, @teeM, @teeF) RETURNING id";

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
            cmd.Parameters.AddWithValue("@teeM", newComp.teeM);
            cmd.Parameters.AddWithValue("@teeF", newComp.teeF);

            int tavlingsid = Convert.ToInt32(cmd.ExecuteScalar());

            conn.Close();

            BookCompTimes(tavlingsid);

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
            ddlTeeF.SelectedIndex = 0;
            ddlTeeM.SelectedIndex = 0;
        }

        public void BookCompTimes(int tavlingsid)
        {
            List<Booking> ListOfBookings = new List<Booking>();
            string sql = "SELECT * FROM bokning WHERE starttid >= @starttid AND starttid <= @sluttid";

            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@starttid", ddlstarttime.Text);
            cmd.Parameters.AddWithValue("@sluttid", ddlendtime.Text);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Booking b = new Booking();
                b.ID = Convert.ToInt32(dr["slot_id"]);
                ListOfBookings.Add(b);
            }
            conn.Close();

            foreach (Booking b in ListOfBookings)
            {
                string sql2 = "DELETE FROM medlem_bokning WHERE bokning_id = @bokning_id AND datum = @date";
                conn.Open();
                NpgsqlCommand cmd2 = new NpgsqlCommand(sql2, conn);
                cmd2.Parameters.AddWithValue("@bokning_id", b.ID.ToString());
                cmd2.Parameters.AddWithValue("@date", Calendar1.SelectedDate);
                cmd2.ExecuteNonQuery();
                conn.Close();

                string sql3 = "INSERT INTO medlem_bokning (bokning_id, datum,tavlings_id) VALUES(@bokning_id, @date, @tavlings_id)";
                conn.Open();
                NpgsqlCommand cmd3 = new NpgsqlCommand(sql3, conn);
                cmd3.Parameters.AddWithValue("@bokning_id", b.ID.ToString());
                cmd3.Parameters.AddWithValue("@date", Calendar1.SelectedDate);
                cmd3.Parameters.AddWithValue("@tavlings_id", tavlingsid.ToString());

                cmd3.ExecuteNonQuery();
                conn.Close();
            }
        }
    } 
}