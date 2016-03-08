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

            tbPlayer2.Text = "";
            tbPlayer3.Text = "";
            tbPlayer4.Text = "";

            Session["player1"] = null;
            Session["player2"] = null;
            Session["player3"] = null;
            Session["player4"] = null;

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

            List<double> oldplayersList = new List<double>();

            if (Session["player1"] != null)
            {
                oldplayersList.Add(Convert.ToDouble(Session["player1"]));
            }
            if (Session["player2"] != null)
            {
                oldplayersList.Add(Convert.ToDouble(Session["player2"]));
            }
            if (Session["player3"] != null)
            {
                oldplayersList.Add(Convert.ToDouble(Session["player3"]));
            }
            if (Session["player4"] != null)
            {
                oldplayersList.Add(Convert.ToDouble(Session["player4"]));
            }

            double totalhcp = 0;

            foreach (double hcp in oldplayersList)
            {
                totalhcp += hcp;
            }

            string sql = "SELECT id, hcp FROM medlem WHERE golfid = '" + tbPlayer1.Text + "'";

            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

            conn.Open();

            NpgsqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                medlem newmedlem = new medlem();
                newmedlem.ID = Convert.ToInt32(dr[0]);
                newmedlem.handikapp = Convert.ToDouble(dr[1]);
                totalhcp += newmedlem.handikapp;               
            }
            conn.Close();

            if (totalhcp > 100)
            {
                tbPlayer1.Visible = false;
                confirmBtn.Enabled = false;
                confirmBtn.Visible = false;
                lblOtherPlayerGolfID.Visible = false;
                lblGolfID.Visible = false;
                tbPlayer2.Visible = false;
                tbPlayer3.Visible = false;
                tbPlayer4.Visible = false;
                lblotherplayers.Text = "Gemensam handikapp blir tyvärr för hög.";
                lblotherplayers.ForeColor = Color.Red;
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

            if (tbPlayer1.Text == lblPlayer1.ID || tbPlayer1.Text == lblPlayer2.ID || tbPlayer1.Text == lblPlayer3.ID || tbPlayer1.Text == lblPlayer4.ID)
            {
                tbPlayer1.Visible = false;
                confirmBtn.Enabled = false;
                confirmBtn.Visible = false;
                lblOtherPlayerGolfID.Visible = false;
                lblGolfID.Visible = false;
                tbPlayer2.Visible = false;
                tbPlayer3.Visible = false;
                tbPlayer4.Visible = false;
                lblotherplayers.Text = "Du är redan inbokad på den här tiden!";
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
                    lblPlayer1.ID = golfplayer.golfID;
                    Session["player1"] = golfplayer.hcp;          
                    playercount++;
                }

                else if (golfplayer.startid == time && playercount == 2)
                {
                    lblPlayer2.Text = "Handikapp: " + golfplayer.hcp + " " + "Kön: " + golfplayer.kon;
                    lblPlayer2.ID = golfplayer.golfID;
                    Session["player2"] = golfplayer.hcp;
                    playercount++;
                }

                else if (golfplayer.startid == time && playercount == 3)
                {
                    lblPlayer3.Text = "Handikapp: " + golfplayer.hcp + " " + "Kön: " + golfplayer.kon;
                    lblPlayer2.ID = golfplayer.golfID;
                    Session["player3"] = golfplayer.hcp;
                    playercount++;
                }

                else if (golfplayer.startid == time && playercount == 4)
                {
                    lblPlayer4.Text = "Handikapp: " + golfplayer.hcp + " " + "Kön: " + golfplayer.kon;
                    lblPlayer2.ID = golfplayer.golfID;
                    Session["player4"] = golfplayer.hcp;
                    playercount++;
                }
            }

                

        }

        protected void confirmBtn_Click(object sender, EventArgs e)
        {
            List<double> oldplayersList = new List<double>();

            if (Session["player1"] != null)
            {
                oldplayersList.Add(Convert.ToDouble(Session["player1"]));
            }
            if (Session["player2"] != null)
            {
                oldplayersList.Add(Convert.ToDouble(Session["player2"]));
            }
            if (Session["player3"] != null)
            {
                oldplayersList.Add(Convert.ToDouble(Session["player3"]));
            }
            if (Session["player4"] != null)
            {
                oldplayersList.Add(Convert.ToDouble(Session["player4"]));
            }

            double totalhcp = 0;

            foreach (double hcp in oldplayersList)
            {
                totalhcp += hcp;
            }
               
            Booking newbooking = new Booking();
            int bokningsid = Convert.ToInt32(Session["BokningsID"]);
            DateTime date = Convert.ToDateTime(Session["selectedDate"]);

            List<string> golfidlist = new List<string>();

            foreach (TextBox tb in otherplayers.Controls.OfType<TextBox>())
            {
                if(tb.Text != "")
                {
                    golfidlist.Add(tb.Text);
                }
            }

            List<medlem> medlemsidlist = new List<medlem>();

            foreach (string golfid in golfidlist)
            {
                string sql = "SELECT id, hcp FROM medlem WHERE golfid = '" + golfid + "'";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

                conn.Open();

                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    medlem newmedlem = new medlem();
                    newmedlem.ID = Convert.ToInt32(dr[0]);
                    newmedlem.handikapp = Convert.ToDouble(dr[1]);
                    totalhcp += newmedlem.handikapp;
                    medlemsidlist.Add(newmedlem);
                }
                conn.Close();
            }

            if(totalhcp <= 100)
            {
                foreach (medlem medlem in medlemsidlist)
                {
                    newbooking.Newbooking(medlem.ID, bokningsid, date);
                }
            }
            lblotherplayers.Text = "Handikapp överstiger tyvärr 100";
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Session["selectedDate"] = Calendar1.SelectedDate.ToShortDateString();

            UpdateTable(GetBookedTimes());
            
            Table1.Visible = true;
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

                            if (playercount <= 3)
                            {
                                tr.Cells[i].BackColor = Color.Yellow;
                            }

                        }
                    }
                }
            }
        }
    }
}