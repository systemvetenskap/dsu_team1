using Npgsql;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team_1_Halslaget_GK
{
    public partial class tidsbokningAdmin : System.Web.UI.Page
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se; Port=5432; Database=dsu_golf; User Id=dsu_g1; Password=dsu_g1; SslMode=Require");

        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateTable(GetBookedTimes());
            if (!IsPostBack)
            {
                Table1.Visible = false;
                Calendar1.SelectedDate = DateTime.Today;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            confirmBtn.Enabled = true;
            confirmBtn.Visible = true;
            tbPlayer1.Visible = true;
            tbPlayer2.Visible = true;
            tbPlayer3.Visible = true;
            tbPlayer4.Visible = true;

            Removeplayer1Btn.Visible = false;
            Removeplayer2Btn.Visible = false;
            Removeplayer3Btn.Visible = false;
            Removeplayer4Btn.Visible = false;

            lblotherplayers.ForeColor = Color.White;

            LinkButton btn = (LinkButton)sender;

            lblPlayer1.Text = "";
            lblPlayer2.Text = "";
            lblPlayer3.Text = "";
            lblPlayer4.Text = "";

            tbPlayer1.Text = "";
            tbPlayer2.Text = "";
            tbPlayer3.Text = "";
            tbPlayer4.Text = "";

            Session["player1"] = null;
            Session["player2"] = null;
            Session["player3"] = null;
            Session["player4"] = null;

            ShowPlayerInfo(btn.Text);

            string LinkButtonID = btn.ID;
            string bokningsID = LinkButtonID.Remove(0, 10);

            Session["BokningsID"] = bokningsID;

            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "showotherplayers", "showotherplayers();", true);

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
           
            if (lblPlayer4.Text != "")
            {
                tbPlayer1.Visible = false;
                confirmBtn.Enabled = false;
                confirmBtn.Visible = false;
                lblotherplayers.Text = "Den här tiden är tyvärr fullbokad!";
                lblotherplayers.ForeColor = Color.Red;
                Label1.Visible = false;
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
                    lblPlayer1.Text = "Handikapp: " + golfplayer.hcp + " " + "Kön: " + golfplayer.kon;
                    lblPlayer1.ID = golfplayer.golfID;
                    Session["player1"] = golfplayer.hcp;
                    Session["player1ID"] = golfplayer.id;
                    Removeplayer1Btn.Visible = true;
                    playercount++;
                }

                else if (golfplayer.startid == time && playercount == 2)
                {
                    lblPlayer2.Text = "Handikapp: " + golfplayer.hcp + " " + "Kön: " + golfplayer.kon;
                    lblPlayer2.ID = golfplayer.golfID;
                    Session["player2"] = golfplayer.hcp;
                    Session["player2ID"] = golfplayer.id;
                    Removeplayer2Btn.Visible = true;
                    playercount++;
                }

                else if (golfplayer.startid == time && playercount == 3)
                {
                    lblPlayer3.Text = "Handikapp: " + golfplayer.hcp + " " + "Kön: " + golfplayer.kon;
                    lblPlayer2.ID = golfplayer.golfID;
                    Session["player3"] = golfplayer.hcp;
                    Session["player3ID"] = golfplayer.id;
                    Removeplayer3Btn.Visible = true;
                    playercount++;
                }

                else if (golfplayer.startid == time && playercount == 4)
                {
                    lblPlayer4.Text = "Handikapp: " + golfplayer.hcp + " " + "Kön: " + golfplayer.kon;
                    lblPlayer2.ID = golfplayer.golfID;
                    Session["player4"] = golfplayer.hcp;
                    Session["player4ID"] = golfplayer.id;
                    Removeplayer4Btn.Visible = true;
                    playercount++;
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

                            if (playercount <= 3)
                            {
                                tr.Cells[i].BackColor = Color.Yellow;
                            }

                        }
                    }
                }
            }
        }

        protected void Calendar1_SelectionChanged1(object sender, EventArgs e)
        {
            Session["selectedDate"] = Calendar1.SelectedDate.ToShortDateString();

            UpdateTable(GetBookedTimes());

            Table1.Visible = true;
        }

        protected void confirmBtn_Click1(object sender, EventArgs e)
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
                if (tb.Text != "")
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

            if (totalhcp <= 100)
            {
                foreach (medlem medlem in medlemsidlist)
                {
                    newbooking.Newbooking(medlem.ID, bokningsid, date);
                }
            }

            lblotherplayers.Text = "Handikapp överstiger tyvärr 100";
            UpdateTable(GetBookedTimes());
        }

        public void Deletebooking(int medlem_id, int bokning_id, string date)
        {
                    try
                    {
                        conn.Open();
                        string sql = "DELETE FROM medlem_bokning WHERE medlem_id = @medlem_id AND bokning_id = @bokning_id AND datum = @datum" ;
                        NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@medlem_id", medlem_id);
                        cmd.Parameters.AddWithValue("@bokning_id", bokning_id);
                        cmd.Parameters.AddWithValue("@datum", date);
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        NpgsqlException ex;
                    }
                    finally
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }

        protected void Removeplayer1Btn_Click(object sender, EventArgs e)
        {
            int medlems_id = Convert.ToInt32(Session["player1ID"]);
            int bokning_id = Convert.ToInt32(Session["BokningsID"]);
            string date = Session["selectedDate"].ToString();

            Deletebooking(medlems_id, bokning_id, date);
            
        }

        protected void Removeplayer2Btn_Click(object sender, EventArgs e)
        {
            int medlems_id = Convert.ToInt32(Session["player2ID"]);
            int bokning_id = Convert.ToInt32(Session["BokningsID"]);
            string date = Session["selectedDate"].ToString();

            Deletebooking(medlems_id, bokning_id, date);
            
        }

        protected void Removeplayer3Btn_Click(object sender, EventArgs e)
        {
            int medlems_id = Convert.ToInt32(Session["player3ID"]);
            int bokning_id = Convert.ToInt32(Session["BokningsID"]);
            string date = Session["selectedDate"].ToString();

            Deletebooking(medlems_id, bokning_id, date);
            
        }

        protected void Removeplayer4Btn_Click(object sender, EventArgs e)
        {
            int medlems_id = Convert.ToInt32(Session["player4ID"]);
            int bokning_id = Convert.ToInt32(Session["BokningsID"]);
            string date = Session["selectedDate"].ToString();

            Deletebooking(medlems_id, bokning_id, date);
          
        }
    }
}