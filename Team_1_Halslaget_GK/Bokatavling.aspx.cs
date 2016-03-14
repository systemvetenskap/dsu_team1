using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team_1_Halslaget_GK
{
    public partial class Bokatavling : System.Web.UI.Page
    {
        NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
        Competition newcomp = new Competition();
        medlem openmedlem;

        protected void Page_Load(object sender, EventArgs e)
        {          
            if (Session["Username"] == null)
            {
                Response.Redirect("~/NotAllowed.aspx");
            }

            openmedlem = Getmember(Session["Username"].ToString());
            OpenPage();
            if (!IsPostBack)
            {
                gvTavlingar.DataSource = newcomp.GetAllUpcomingCompetitions();
                gvTavlingar.DataBind();
                
            }
           
        }

        protected void gvTavlingar_SelectedIndexChanged(object sender, EventArgs e)
        {
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

            string type = lblTavlingTyp.Text;

            if (type.ToLower() == "singel")
            {
                bookSingelPage();
            }

            else if (type.ToLower() == "lag")
            {
                bookTeamPage();
            }

            if (alreadybooked())
            {
                cancelSingelPage();
            }

            if (Teamalreadybooked())
            {
                cancelTeamPage();
            }   
                  
        }     

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            string tavlingid = gvTavlingar.SelectedValue.ToString();
            string medlemid = openmedlem.ID.ToString();
            
           if (bookMember(medlemid, tavlingid))
            {
                tbsearchTavling.Text = "";
                gvTavlingar.DataSource = newcomp.GetAllUpcomingCompetitions();
                gvTavlingar.DataBind();
            }
            else
            {
               
            }
            
        }

        protected void btnConfirm2_Click(object sender, EventArgs e)
        {
            if (bookTeam())
            {
                tbsearchTavling.Text = "";
                gvTavlingar.DataSource = newcomp.GetAllUpcomingCompetitions();
                gvTavlingar.DataBind();
            }                       
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            if (cancelbookingsingel(openmedlem.ID.ToString(), gvTavlingar.SelectedValue.ToString()))
            {
                tbsearchTavling.Text = "";
                gvTavlingar.DataSource = newcomp.GetAllUpcomingCompetitions();
                gvTavlingar.DataBind();
            }
            
        }
    
        protected void BtnRemove2_Click(object sender, EventArgs e)
        {
            if (CancelBookingTeam(Session["lagid"].ToString(), gvTavlingar.SelectedValue.ToString()))
            {
                tbsearchTavling.Text = "";
                gvTavlingar.DataSource = newcomp.GetAllUpcomingCompetitions();
                gvTavlingar.DataBind();
            }
        }

        protected void BtnSearch_Click1(object sender, EventArgs e)
        {
            OpenPage();
            gvTavlingar.DataSource = Search();
            gvTavlingar.DataBind();
            rdlTavlingType.SelectedIndex = 0;
        }

        protected void rdlTavlingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdlTavlingType.SelectedIndex == 0)
            {
                gvTavlingar.DataSource = Search();
                gvTavlingar.DataBind();
            }
            if (rdlTavlingType.SelectedIndex == 1)
            {
                gvTavlingar.DataSource = SorteraTavlingar("singel");
                gvTavlingar.DataBind();
            }
            if (rdlTavlingType.SelectedIndex == 2)
            {
                gvTavlingar.DataSource = SorteraTavlingar("lag");
                gvTavlingar.DataBind();
            }
        }





        // ----------- Funktioner --------- //

        // Hämta en tavling på tävlings id
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

        //Hämta medlem på medlems id
        public medlem Getmember(string id)
        {
            medlem newmedlem = new medlem();

            string sql = "SELECT * FROM medlem where id = @id";

            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();

            NpgsqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                newmedlem.ID = Convert.ToInt32(dr["id"]);
                newmedlem.golfid = dr["golfid"].ToString();
            }

            conn.Close();

            return newmedlem;
        }

        //Boka in en medlem på en tävling
        public bool bookMember(string medlemid, string tavlingid)
        {
            try
            {
                string sql = "INSERT INTO medlem_tavling (medlem_id, tavling_id) VALUES (@medlem_id, @bokning_id)";
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@medlem_id", medlemid);
                cmd.Parameters.AddWithValue("@bokning_id", tavlingid);
                
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
            newteam.Listofmedlem.Add(openmedlem);
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

            string sql4 = "INSERT INTO lag_tavling (id_lag, id_tavling) VALUES (@lag_id, @tavling_id)";
            conn.Open();
            NpgsqlCommand cmd4 = new NpgsqlCommand(sql4, conn);
            cmd4.Parameters.AddWithValue("@lag_id", teamid);
            cmd4.Parameters.AddWithValue("@tavling_id", gvTavlingar.SelectedValue.ToString());
            cmd4.ExecuteNonQuery();
            conn.Close();

            return true;
        }

        //Ta bort en medlems bokning på en tävling
        public bool cancelbookingsingel(string medlemid, string tavlingid)
        {
            try
            {
                string sql = "DELETE FROM medlem_tavling WHERE medlem_id = @medlem_id AND tavling_id = @tavling_id";
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@medlem_id", medlemid);
                cmd.Parameters.AddWithValue("@tavling_id", tavlingid);

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

        //Ta bort ett lags bokning på en tävling
        public bool CancelBookingTeam(string lagid, string tavlingid)
        {
            try
            {
                string sql = "DELETE FROM lag_tavling WHERE id_lag = @id_lag AND id_tavling = @id_tavling";
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id_lag", lagid);
                cmd.Parameters.AddWithValue("@id_tavling", tavlingid);

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

        //Kolla om den inloggade medlem redan är bokad på tävlingen
        public bool alreadybooked()

        {
            List<string> tavlingid = new List<string>();
            medlem newmedlem = Getmember(Session["Username"].ToString());
            string sql = "SELECT * FROM medlem_tavling WHERE medlem_id = @medlem_id";
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@medlem_id", newmedlem.ID.ToString());

            NpgsqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string id;
                id = dr["tavling_id"].ToString() + newmedlem.ID.ToString();
                tavlingid.Add(id);
            }

            conn.Close();

            string tmidselected = gvTavlingar.SelectedValue.ToString() + newmedlem.ID.ToString();

            foreach (string tmid in tavlingid)
            {
                if(tmid == tmidselected)
                {
                    return true;                    
                }
            }

            return false;
        }

        //Kolla om något lag som den inloggade medlemmen är med i är bokat på tävlingen
        public bool Teamalreadybooked()
        {
            List<Team> ListofTeams = GetTeams(openmedlem);

            foreach (Team t in ListofTeams)
            {
                List<Booking> ListofBookings = GetTeamBookings(t);

                foreach (Booking b in ListofBookings)
                {
                    if (b.ID == Convert.ToInt32(gvTavlingar.SelectedValue))
                    {
                        Session["lagid"] = t.id;
                        return true;
                    }
                }
            }

            return false;
        }

        //Hämtar de lag som medlemmen är med i
        public List<Team> GetTeams(medlem medlem)
        {

            List<Team> ListofTeam = new List<Team>();
            
            string sql = "SELECT * FROM lag_medlem WHERE medlem_id = @medlem_id";
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@medlem_id", medlem.ID.ToString());

            NpgsqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Team newteam = new Team();
                newteam.id = dr["lag_id"].ToString();
                ListofTeam.Add(newteam);

            }

            conn.Close();

            return ListofTeam;
        }

        //Hämtar de tävlings id på tävlingar laget är bokat på
        public List<Booking> GetTeamBookings (Team team)
        {
            List<Booking> ListOfBookings = new List<Booking>();

            string sql = "SELECT * FROM lag_tavling WHERE id_lag = @id_lag";
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id_lag", team.id);

            NpgsqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Booking newbooking = new Booking();
                newbooking.ID = Convert.ToInt32(dr["id_tavling"]);
                ListOfBookings.Add(newbooking);
            }
            conn.Close();
            return ListOfBookings;
        }

        //Sök på Tävlingar
        public DataTable Search()
        {           
            try
            {
                conn.Open();
                NpgsqlCommand cmdGetCompetitions = new NpgsqlCommand("SELECT* FROM tavling WHERE namn ~*'"+ tbsearchTavling.Text+"'", conn);
                NpgsqlDataAdapter nda = new NpgsqlDataAdapter();
                nda.SelectCommand = cmdGetCompetitions;
                DataTable dt = new DataTable();
                nda.Fill(dt);
                return dt;
            }
            catch (NpgsqlException ex)
            {
                //NpgsqlException = ex.Message;
                return null;
            }
            finally
            {
                conn.Close();             
            }
        }

        //Visa alla, singel eller lagtävlingar
        public DataTable SorteraTavlingar(string type)
        {
            try
            {
                conn.Open();
                NpgsqlCommand cmdGetCompetitions = new NpgsqlCommand("SELECT * FROM tavling WHERE type = '" + type + "' AND namn ~*'" + tbsearchTavling.Text + "'", conn);
                NpgsqlDataAdapter nda = new NpgsqlDataAdapter();
                nda.SelectCommand = cmdGetCompetitions;
                DataTable dt = new DataTable();
                nda.Fill(dt);
                return dt;
            }
            catch (NpgsqlException ex)
            {
                //NpgsqlException = ex.Message;
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        //Göm allt
        public void OpenPage()
        {           

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

        //Team-layoout för Boka
        public void bookTeamPage()
        {
            lblTavlingDesc.Visible = true;
            lblTavlingNamn.Visible = true;
            lblTavlingTyp.Visible = true;

            tbgolfid1.Visible = true;
            tbgolfid1.Enabled = false;
            tbgolfid1.Text = openmedlem.golfid.ToString(); ;
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
            tbgolfid1.Enabled = false;
            tbgolfid1.Text = openmedlem.golfid.ToString();
            btnConfirm.Visible = true;
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

    }
}