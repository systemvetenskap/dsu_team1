using Npgsql;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team_1_Halslaget_GK
{
    public partial class AdminBokatavling : System.Web.UI.Page
    {
        NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
        Competition newcomp = new Competition();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["Username"] == null && Session["admin"] == null)
            //{
            //    Response.Redirect("~/NotAllowed.aspx");
            //}
            if (!IsPostBack)
            {
                OpenPage();
            }

            gvTavlingar.DataSource = newcomp.GetAllUpcomingCompetitionsRegdates();
            gvTavlingar.DataBind();
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            string tavlingid = gvTavlingar.SelectedValue.ToString();
            string medlemid = getIDByGolfId(tbgolfid1.Text);


            if (!checkifalreadybookedsingel(medlemid, tavlingid))
            {
                if (bookMember(medlemid, tavlingid))
                {
                    OpenPage();
                    gvTavlingar.DataSource = newcomp.GetAllUpcomingCompetitions();
                    gvTavlingar.DataBind();
                }
                else
                {

                }
            }
            else
            {
                tbgolfid1.BackColor = Color.Red;
            }


        }

        protected void btnConfirm2_Click(object sender, EventArgs e)
        {
            string tavlingid = gvTavlingar.SelectedValue.ToString();

            bool exists = false;
            foreach (TextBox tb in teamtb.Controls.OfType<TextBox>())
            {
                string medlemid = getIDByGolfId(tb.Text);

                if(checkifalreadybookedlag(medlemid, tavlingid))
                {
                    tb.BackColor = Color.Red;
                    exists = true;                  
                }

                
            }

            if(exists == false)
            {
                 bookTeam();
                 OpenPage();                
            }

        }

        protected void gvTavlingar_SelectedIndexChanged(object sender, EventArgs e)
        {
            OpenPage();
            

            foreach (GridViewRow row in gvTavlingar.Rows)
            {
                if (row.RowIndex == gvTavlingar.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#6C6C6C");
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                }
            }

            Competition newcom = GetspecificComp(gvTavlingar.SelectedValue.ToString());

            lblTavlingNamn.Text = newcom.namn;           
            lblTavlingTyp.Text = newcom.type;
            lblTavlingDesc.Text = newcom.desc;

            lblTavlingNamn.Visible = true;
            lblTavlingTyp.Visible = true;
            lblTavlingDesc.Visible = true;

            string type = lblTavlingTyp.Text;

            if (type.ToLower() == "singel")
            {
                bookSingelPage();
                btnConfirm.Visible = true;
                btnConfirm2.Visible = false;

            }

            else if (type.ToLower() == "lag")
            {
                bookTeamPage();
                btnConfirm.Visible = false;
                btnConfirm2.Visible = true;
            }

        }

        protected void BtnSearchMember_Click(object sender, EventArgs e)
        {

        }


        /* ----------- Funktioner --------- */

        //Hämtar tävling på tävlings id
        public Competition GetspecificComp(string compid)
        {
            Competition newcom = new Competition();

            string sql = "SELECT * FROM tavling where id = @id";

            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", compid);
            conn.Open();

            NpgsqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                newcom.id = dr["id"].ToString();
                newcom.namn = dr["namn"].ToString();
                newcom.starttid = dr["starttid"].ToString();
                newcom.sluttid = dr["sluttid"].ToString();
                newcom.desc = dr["description"].ToString();
                newcom.type = dr["type"].ToString();
            }

            conn.Close();

            return newcom;
        }

        //Team-layoout för Boka
        public void bookTeamPage()
        {
            lblTavlingDesc.Visible = true;
            lblTavlingNamn.Visible = true;
            lblTavlingTyp.Visible = true;

            tbgolfid1.Visible = true;
            tbgolfid1.Enabled = true;
            
            tbgolfid2.Visible = true;
            tbgolfid3.Visible = true;
            tbgolfid4.Visible = true;
            btnConfirm2.Visible = true;
        }

        //Singel-layout för Boka
        public void bookSingelPage()
        {
            lblTavlingDesc.Visible = true;
            lblTavlingNamn.Visible = true;
            lblTavlingTyp.Visible = true;

            tbgolfid1.Visible = true;
            tbgolfid1.Enabled = true;           
            btnConfirm.Visible = true;
        }

        //Göm allt
        public void OpenPage()
        {

            tbgolfid1.Text = "";
            tbgolfid2.Text = "";
            tbgolfid3.Text = "";
            tbgolfid4.Text = "";

            tbgolfid1.BackColor = Color.White;
            tbgolfid2.BackColor = Color.White;
            tbgolfid3.BackColor = Color.White;
            tbgolfid4.BackColor = Color.White;

            lblTavlingDesc.Visible = false;
            lblTavlingNamn.Visible = false;
            lblTavlingTyp.Visible = false;

            tbgolfid1.Visible = false;
            tbgolfid2.Visible = false;
            tbgolfid3.Visible = false;
            tbgolfid4.Visible = false;

            btnConfirm.Visible = false;
            btnConfirm2.Visible = false;
            btnRemove.Visible = false;
            BtnRemove2.Visible = false;
        }

        //Team-layout för Avboka 
        public void cancelTeamPage()
        {
            lblTavlingDesc.Visible = true;
            lblTavlingNamn.Visible = true;
            lblTavlingTyp.Visible = true;

            tbgolfid1.Visible = false;
            tbgolfid2.Visible = false;
            tbgolfid3.Visible = false;
            tbgolfid4.Visible = false;

            btnConfirm.Visible = false;
            btnConfirm2.Visible = false;
            BtnRemove2.Visible = true;

        }

        //Singel-layout för Avboka
        public void cancelSingelPage()
        {
            lblTavlingDesc.Visible = true;
            lblTavlingNamn.Visible = true;
            lblTavlingTyp.Visible = true;

            tbgolfid1.Visible = false;
            tbgolfid2.Visible = false;
            tbgolfid3.Visible = false;
            tbgolfid4.Visible = false;

            btnConfirm.Visible = false;
            btnConfirm2.Visible = false;
            btnRemove.Visible = true;
        }

        //Boka medlem på tävling
        public bool bookMember(string medlemid, string tavlingid)
        {
            try
            {
                string sql = "INSERT INTO medlem_tavling (medlem_id, tavling_id, starttid_id) VALUES (@medlem_id, @bokning_id, @starttid_id)";
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@medlem_id", medlemid);
                cmd.Parameters.AddWithValue("@bokning_id", tavlingid);
                cmd.Parameters.AddWithValue("@starttid_id", "67");

                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                return false;
            }
            finally
            {
                conn.Close();

            }
            return true;

        }

        //Skapa ett lag, lägg till lagmedlemmar och boka laget på en tävling
        public bool bookTeam()
        {
            Team newteam = new Team();          
            List<string> GolfidList = new List<string>();

            foreach (TextBox tb in teamtb.Controls.OfType<TextBox>())
            {
                GolfidList.Add(tb.Text);
            }

            foreach (string golfid in GolfidList)
            {
                string sql = "SELECT * FROM medlem WHERE golfid = @golfid";

                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("golfid", golfid);

                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    medlem newmedlem = new medlem();
                    newmedlem.ID = Convert.ToInt32(dr["id"]);
                    newteam.Listofmedlem.Add(newmedlem);
                }
                conn.Close();
            }

            string sql2 = "INSERT INTO lag(lag_namn) VALUES(@lag_namn) RETURNING lag_id";
            conn.Open();
            NpgsqlCommand cmd2 = new NpgsqlCommand(sql2, conn);
            cmd2.Parameters.AddWithValue("@lag_namn", "null");
            string teamid = cmd2.ExecuteScalar().ToString();
            conn.Close();

            foreach (medlem m in newteam.Listofmedlem)
            {
                string sql3 = "INSERT INTO lag_medlem (medlem_id, lag_id) VALUES (@medlem_id, @lag_id)";
                conn.Open();
                NpgsqlCommand cmd3 = new NpgsqlCommand(sql3, conn);
                cmd3.Parameters.AddWithValue("@medlem_id", m.ID.ToString());
                cmd3.Parameters.AddWithValue("lag_id", teamid);
                cmd3.ExecuteNonQuery();
                conn.Close();
            }

            string sql4 = "INSERT INTO lag_tavling (id_lag, id_tavling, starttid_id) VALUES (@lag_id, @tavling_id, @starttid_id)";
            conn.Open();
            NpgsqlCommand cmd4 = new NpgsqlCommand(sql4, conn);
            cmd4.Parameters.AddWithValue("@lag_id", teamid);
            cmd4.Parameters.AddWithValue("@tavling_id", gvTavlingar.SelectedValue.ToString());
            cmd4.Parameters.AddWithValue("@starttid_id", "67");
            cmd4.ExecuteNonQuery();
            conn.Close();

            return true;
        }

        //Hämtar medlems id på Golf id
        public string getIDByGolfId(string golfid)
        {
            string sql = "SELECT * FROM medlem WHERE golfid = @golfid";
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@golfid", golfid);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            medlem newmedlem = new medlem();

            while (dr.Read())
            {
                newmedlem.ID = Convert.ToInt32(dr["id"]);
            }
            conn.Close();

            return newmedlem.ID.ToString();
        }

        //Kolla om angivet golfid redan finns bokad på tävlingen
        public bool checkifalreadybookedsingel(string medlemid, string tavlingid)
        {
            string sql = "SELECT EXISTS (SELECT * FROM medlem_tavling WHERE medlem_id = @medlem_id AND tavling_id = @tavling_id) AS exists";
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@medlem_id", medlemid);
            cmd.Parameters.AddWithValue("@tavling_id", tavlingid);
            bool exists = Convert.ToBoolean(cmd.ExecuteScalar());
            conn.Close();         
            return exists;
        }

        //Kolla om angivna golfid redans finns på tävlingen
        public bool checkifalreadybookedlag(string medlemid, string tavlingid)
        {
            string sql = "SELECT EXISTS(SELECT * FROM lag_medlem INNER JOIN lag_tavling ON(lag_medlem.lag_id = lag_tavling.id_lag)WHERE lag_medlem.medlem_id = @medlem_id AND lag_tavling.id_tavling = @tavling_id)";
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@medlem_id", medlemid);
            cmd.Parameters.AddWithValue("@tavling_id", tavlingid);
            bool exists = Convert.ToBoolean(cmd.ExecuteScalar());
            conn.Close();
            return exists;          
        }

        //Sök på namn för att få fram golfid
        public void SearchMember(string searchstring)
        {
            string sql = "SELECT * medlem WHERE fornamn = @fornamn";
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@fornamn", searchstring);
        }
        

    }
}