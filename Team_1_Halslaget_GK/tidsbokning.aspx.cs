using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using System.Drawing;
using System.Data;

namespace Team_1_Halslaget_GK
{
	public partial class Tidsbokning : System.Web.UI.Page
	{
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se; Port=5432; Database=dsu_golf; User Id=dsu_g1; Password=dsu_g1; SslMode=Require");

        protected void Page_Load(object sender, EventArgs e)
		{
            if (Session["userID"] == null)
            {
                Response.Redirect("~/NotAllowed.aspx");
            }

            bool admin = Convert.ToBoolean(Session["admin"]);

            lblPlayer1.Text = "";
            lblPlayer2.Text = "";
            lblPlayer3.Text = "";
            lblPlayer4.Text = "";

            if (!IsPostBack)
            {
                Table1.Visible = false;
                Calendar1.SelectedDate = DateTime.Today;

                if(admin) 
                {
                    tbPlayer1.Visible = true;
                }

            }
                              
        }

        protected List<Player> GetBookedTimes()
        {
            DateTime selecteddate = Convert.ToDateTime(Session["selectedDate"]);
            string selecteddatestring = selecteddate.ToString("yyyy-MM-dd");         

            List<Booking> BookedTimes = new List<Booking>();
            List<Player> Players = new List<Player>();
            
            string sql = "SELECT bokning_id, kon, hcp, golfID, starttid, id FROM medlem_bokning INNER JOIN medlem ON medlem_id = id AND datum = @selecteddate INNER JOIN bokning ON bokning_id = slot_id ORDER BY bokning_id";

            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@selecteddate", selecteddatestring);
                ;
            try
            {
                conn.Open();
                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Player golfplayer = new Player();

                    golfplayer.slot_id = Convert.ToInt32(dr["bokning_id"]);
                    golfplayer.golfID = dr["golfid"].ToString();
                    golfplayer.kon = dr["kon"].ToString();
                    golfplayer.hcp = Convert.ToInt32(dr["hcp"]);
                    DateTime starttid = Convert.ToDateTime(dr["starttid"]);
                    golfplayer.startid = starttid.ToString("HH:mm");
                    golfplayer.id = Convert.ToInt32(dr["id"]);
                    Players.Add(golfplayer);                    
                }
            }

            catch
            {
                NpgsqlException ex;
            }

            finally
            {
                conn.Close();
            }

            return Players;
            
        }

        public void UpdateTable(List<Player> Players)
        {
            int playercount = 0;
            int cellcount = 0;

            foreach (TableRow tr in Table1.Rows)
            {
                
                for (int i = 0; i < 6; i++)
                {
                    cellcount++;
                    playercount = 0;
                    tr.Cells[i].BackColor = ColorTranslator.FromHtml("#7cff82");
                    foreach (Player time in Players)
                    {
                        if (cellcount == time.slot_id)
                        {
                            
                            playercount++;
                            if (playercount >= 4)
                            {
                                tr.Cells[i].BackColor = Color.Red; //byta ut till css class sen
                            }

                            if(playercount <= 3)
                            {
                                tr.Cells[i].BackColor = Color.Yellow;
                            }

                        }
                    }
                }
            }
        }

        protected void LinkButton_Click(object sender, EventArgs e)
        {
            confirmBtn.Enabled = true;
            confirmBtn.Visible = true;
            lblGolfID.Visible = true;
            lblOtherPlayerGolfID.Visible = true;
            tbPlayer1.Visible = true;
            tbPlayer2.Visible = true;
            tbPlayer3.Visible = true;
            tbPlayer4.Visible = true;

            lblotherplayers.ForeColor = Color.White;

            LinkButton btn = (LinkButton)sender;

            lblPlayer1.Text = "";
            lblPlayer2.Text = "";
            lblPlayer3.Text = "";
            lblPlayer4.Text = ""; 
            
            ShowPlayerInfo(btn.Text);

            string LinkButtonID = btn.ID;
            string bokningsID = LinkButtonID.Remove(0,10);

            Session["BokningsID"] = bokningsID;

            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "showotherplayers", "showotherplayers();", true);

            tbPlayer1.Text = Session["GolfID"].ToString();
            tbPlayer1.Enabled = false;

            lblotherplayers.Text = "På den här tiden finns det inga tidigare bokningar";

            if (lblPlayer1.Text != "")
            {
                tbPlayer4.Visible = false;
                lblotherplayers.Text = "På den här tiden finns det redan vissa bokningar";
            }
            if (lblPlayer2.Text != "")
            {
                tbPlayer3.Visible = false;
                lblotherplayers.Text = "På den här tiden finns det redan vissa bokningar";
            }
            if (lblPlayer3.Text != "")
            {
                tbPlayer2.Visible = false;
                lblotherplayers.Text = "På den här tiden finns det redan vissa bokningar";
            }
            if (lblPlayer4.Text != "")
            {
                tbPlayer1.Visible = false;
                confirmBtn.Enabled = false;
                confirmBtn.Visible = false;
                lblOtherPlayerGolfID.Visible = false;
                lblGolfID.Visible = false;

                lblotherplayers.Text = "Den här tiden är tyvärr fullbokad!";
                lblotherplayers.ForeColor = Color.Red;
            }

        }

        protected void ShowPlayerInfo(string time)
        {
            List<Player> Players = GetBookedTimes();
            int playercount = 1;

            foreach (Player golfplayer in Players)
            {                
                     
                if (golfplayer.startid == time && playercount == 1)
                {
                    lblPlayer1.Text = "Handikapp: " + golfplayer.hcp + " " + "Kön: "+ golfplayer.kon;                  
                    playercount++;
                }

                else if (golfplayer.startid == time && playercount == 2)
                {
                    lblPlayer2.Text = "Handikapp: " + golfplayer.hcp + " " + "Kön: " + golfplayer.kon;
                    playercount++;
                }

                else if (golfplayer.startid == time && playercount == 3)
                {
                    lblPlayer3.Text = "Handikapp: " + golfplayer.hcp + " " + "Kön: " + golfplayer.kon;
                    playercount++;
                }

                else if (golfplayer.startid == time && playercount == 4)
                {
                    lblPlayer4.Text = "Handikapp: " + golfplayer.hcp + " " + "Kön: " + golfplayer.kon;
                    playercount++;
                }
            }

                

        }

        protected void confirmBtn_Click(object sender, EventArgs e)
        {
            DataTable dt = CheckNoOfPlayers();
            int boknings_id = Convert.ToInt32(Session["BokningsID"]);
            DateTime date = Convert.ToDateTime(Session["selectedDate"]);
            Booking newbooking = new Booking();
            bool admin = Convert.ToBoolean(Session["admin"]);

            if (CheckSeason() && CheckBookingRestrictions(dt))
            {
                if(!admin)
                {
                    int medlems_id = Convert.ToInt32(Session["userID"]);

                    bool success = newbooking.Newbooking(medlems_id, boknings_id, date, conn);
                    if (success)
                    {
                        BookingInfoText.InnerText = "Bokning lyckades";
                        ClientScript.RegisterStartupScript(GetType(), "hwa", "openOverlayInfoBox();", true);
                    }
                }

                if (dt.Rows.Count > 0)
                {
                    bool success = newbooking.Newbooking(Convert.ToInt32(dt.Rows[0][0]), boknings_id, date, conn);
                    
                    if (dt.Rows.Count == 1 && success)
                    {
                        BookingInfoText.InnerText = "Bokning lyckades";
                        ClientScript.RegisterStartupScript(GetType(), "hwa", "openOverlayInfoBox();", true);
                    }
                }

                if (dt.Rows.Count > 1)
                {
                    bool success = newbooking.Newbooking(Convert.ToInt32(dt.Rows[1][0]), boknings_id, date, conn);

                    if (dt.Rows.Count == 2 && success)
                    {
                        BookingInfoText.InnerText = "Bokning lyckades";
                        ClientScript.RegisterStartupScript(GetType(), "hwa", "openOverlayInfoBox();", true);
                    }
                }

                if (dt.Rows.Count > 2)
                {
                    bool success = newbooking.Newbooking(Convert.ToInt32(dt.Rows[2][0]), boknings_id, date, conn);

                    if (dt.Rows.Count == 3 && success)
                    {
                        BookingInfoText.InnerText = "Bokning lyckades";
                        ClientScript.RegisterStartupScript(GetType(), "hwa", "openOverlayInfoBox();", true);
                    }
                }

                if (dt.Rows.Count > 3)
                {
                    bool success = newbooking.Newbooking(Convert.ToInt32(dt.Rows[3][0]), boknings_id, date, conn);

                    if (dt.Rows.Count == 4 && success)
                    {
                        BookingInfoText.InnerText = "Bokning lyckades";
                        ClientScript.RegisterStartupScript(GetType(), "hwa", "openOverlayInfoBox();", true);
                    }
                }
            }

            else
            {
                //Do nothing
            }

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Session["selectedDate"] = Calendar1.SelectedDate.ToShortDateString();

            if (!CheckSeason())
            {
                foreach (TableRow tr in Table1.Rows)
                {
                    foreach (TableCell tc in tr.Cells)
                    {
                        tc.BackColor = Color.Red;
                    }
                }
            }

            else
            {
                UpdateTable(GetBookedTimes());
            }
            
            Table1.Visible = true;
        }

        protected bool CheckSeason()
        {
            string sql = "SELECT startdatum, slutdatum, bana FROM season WHERE slutdatum > @selecteddate AND startdatum < @selecteddate";
            DateTime selecteddate = Calendar1.SelectedDate;
            string selecteddatestring = selecteddate.ToString("yyyy-MM-dd");

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@selecteddate", selecteddatestring);
            DataTable dt = new DataTable();

            try
            {
                da.Fill(dt);
            }

            catch
            {
                NpgsqlException ex;
            }

            finally
            {
                conn.Close();
            }

            if (dt.Rows.Count == 0)
            {
                BookingInfoText.InnerText = "Golfbanan har tyvärr inte öppet detta datum";
                ClientScript.RegisterStartupScript(GetType(), "hwa", "openOverlayInfoBox();", true);
                return false;
            }

            else if (dt.Rows.Count == 1 && dt.Rows[0]["bana"] == "range")
            {
                BookingInfoText.InnerText = "Golfbanan har tyvärr inte öppet detta datum";
                ClientScript.RegisterStartupScript(GetType(), "hwa", "openOverlayInfoBox();", true);
                return false;
            }

            else
            {
                return true;
            }
        }

        protected bool CheckBookingRestrictions(DataTable dt)
        {
            double hcp = 0;
            int playercount;
            bool admin = Convert.ToBoolean(Session["admin"]);

            if (admin)
            {
                playercount = 0;
                hcp = 0;
            }

            else
            {
                playercount = 1;
                hcp = Convert.ToDouble(Session["hcp"]);

            }
            

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    hcp += Convert.ToInt32(dt.Rows[i][1]);
                }
            }
                      
            int boknings_id = Convert.ToInt32(Session["BokningsID"]);
            List<Player> Players = GetBookedTimes();

            foreach (Player pl in Players)
            {
                if (pl.slot_id == boknings_id)
                {
                    hcp += pl.hcp;
                    playercount++;

                    if (!admin && Convert.ToInt32(Session["userID"]) == pl.id)
                    {
                        BookingInfoText.InnerText = "Du är redan inbokad på denna tid";
                        ClientScript.RegisterStartupScript(GetType(), "hwa", "openOverlayInfoBox();", true);
                        return false;
                    }

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(dt.Rows[i][0]) == pl.id)
                        {
                            BookingInfoText.InnerText = "Spelare med Golf ID " + dt.Rows[i][2].ToString() + " är redan inbokad denna tid";
                            ClientScript.RegisterStartupScript(GetType(), "hwa", "openOverlayInfoBox();", true);
                            return false;
                        }
                    }
                }
            }

            if (playercount + dt.Rows.Count > 4)
            {
                BookingInfoText.InnerText = "Max 4 spelare kan boka tid samtidigt";
                ClientScript.RegisterStartupScript(GetType(), "hwa", "openOverlayInfoBox();", true);
                return false;               
            }

            else if (hcp > 100)
            {
                BookingInfoText.InnerText = "Sammanlagt handikapp på en bokning får tyvärr inte överstiga 100";
                ClientScript.RegisterStartupScript(GetType(), "hwa", "openOverlayInfoBox();", true);
                return false;
            }

            else
            {
                return true;
            }
        }

        protected DataTable CheckNoOfPlayers()
        {

            if (tbPlayer1.Text == "" && tbPlayer2.Text == "" && tbPlayer3.Text == "" && tbPlayer4.Text == "")
            {
                DataTable dt = new DataTable();
                return dt;
            }

            else if (tbPlayer1.Text != "" && tbPlayer2.Text != "" && tbPlayer3.Text != "" && tbPlayer4.Text != "")
            {
                string sql = "SELECT id, hcp FROM medlem WHERE golfid IN (@golfid1, @golfid2 , @golfid3, @golfid4)";
                int no = 4;
                return GetExtraPlayerInfo(sql, no);
            }

            else if (tbPlayer2.Text != "" && tbPlayer3.Text != "" && tbPlayer4.Text != "")
            {
                string sql = "SELECT id, hcp, golfid FROM medlem WHERE golfid IN (@golfid2, @golfid3 , @golfid4)";
                int no = 3;
                return GetExtraPlayerInfo(sql, no);
            }

            else if (tbPlayer1.Text != "" && tbPlayer2.Text != "" && tbPlayer3.Text != "")
            {
                string sql = "SELECT id, hcp FROM medlem WHERE golfid, golfid IN (@golfid1, @golfid2 , @golfid3)";
                int no = 3;
                return GetExtraPlayerInfo(sql, no);
            }

            else if (tbPlayer2.Text != "" && tbPlayer3.Text != "")
            {
                string sql = "SELECT id, hcp FROM medlem WHERE golfid, golfid IN (@golfid2, @golfid3)";
                int no = 2;
                return GetExtraPlayerInfo(sql, no);
            }

            else if (tbPlayer1.Text != "" && tbPlayer2.Text != "")
            {
                string sql = "SELECT id, hcp FROM medlem WHERE golfid, golfid IN (@golfid1, @golfid2)";
                int no = 2;
                return GetExtraPlayerInfo(sql, no);
            }

            else if (tbPlayer2.Text != "")
            {
                string sql = "SELECT id, hcp FROM medlem WHERE golfid, golfid IN (@golfid2)";
                int no = 1;
                return GetExtraPlayerInfo(sql, no);
            }

            else
            {
                string sql = "SELECT id, hcp FROM medlem WHERE golfid, golfid IN (@golfid1)";
                int no = 1;
                return GetExtraPlayerInfo(sql, no);
            }    
        }

        protected DataTable GetExtraPlayerInfo(string sql, int no)
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@golfid1", tbPlayer1.Text);
            da.SelectCommand.Parameters.AddWithValue("@golfid2", tbPlayer2.Text);
            da.SelectCommand.Parameters.AddWithValue("@golfid3", tbPlayer3.Text);
            da.SelectCommand.Parameters.AddWithValue("@golfid4", tbPlayer4.Text);


            try
            {
                conn.Open();
                da.Fill(dt);
            }

            catch(NpgsqlException ex)
            {

            }

            finally
            {
                conn.Close();
            }

            if (dt.Rows.Count < no)
            {
                BookingInfoText.InnerText = "Felaktigt golf ID";
                ClientScript.RegisterStartupScript(GetType(), "hwa", "openOverlayInfoBox();", true);
                return dt;
            }

            else
            {
                return dt;
            }
        }      
    }
}