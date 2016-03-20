using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
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
            if (Session["Username"] == null && Session["admin"] == null)
            {
                Response.Redirect("~/NotAllowed.aspx");
            }
            Label1.Visible = true;
            UpdateTable(GetBookedTimes());

            if (!IsPostBack)
            {
                Table1.Visible = false;
                Calendar1.SelectedDate = DateTime.Today;
            }

            if (hidden1others.Text == "1")
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "showDiv2", "showDiv2();", true);
                hidden1others.Text = "1";
            }
            if (hidden2search.Text == "1")
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "showDiv()", "showDiv();", true);
                hidden2search.Text = "1";
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            ShowHiddenSearchDiv.Visible = true;
            hidden1others.Text = "1";

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
                confirmBtn.Enabled = false;
                confirmBtn.Visible = false;
                lblotherplayers.Text = "Den här tiden är tyvärr fullbokad!";
                lblotherplayers.ForeColor = Color.Red;
                Label1.Visible = false;
            }
            
        }                     

        protected void Calendar1_SelectionChanged1(object sender, EventArgs e)
        {
            hidden1others.Text = "0";

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

                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "closeotherplayers()", "closeotherplayers();", true);
                hidden1others.Text = "0";
                hidden2search.Text = "0";
                tbFullName.Text = "";
                lbMembers.DataSource = "";
                lbMembers.DataBind();

            }
            else
            {
                lblotherplayers.Text = "Handikapp överstiger tyvärr 100";
            }
            
            UpdateTable(GetBookedTimes());
        }
     
        protected void Removeplayer1Btn_Click(object sender, EventArgs e)
        {

            int medlems_id = Convert.ToInt32(Session["player1ID"]);
            int bokning_id = Convert.ToInt32(Session["BokningsID"]);
            string date = Session["selectedDate"].ToString();

            Deletebooking(medlems_id, bokning_id, date);

            lblPlayer1.Text = "";
            lblPlayer1.Visible = false;
            Removeplayer1Btn.Visible = false;
            tbPlayer4.Visible = true;
            ShowHiddenSearchDiv.Visible = true;
            confirmBtn.Visible = true;
            confirmBtn.Enabled = true;
        }

        protected void Removeplayer2Btn_Click(object sender, EventArgs e)
        {
            int medlems_id = Convert.ToInt32(Session["player2ID"]);
            int bokning_id = Convert.ToInt32(Session["BokningsID"]);
            string date = Session["selectedDate"].ToString();

            Deletebooking(medlems_id, bokning_id, date);

            lblPlayer2.Visible = false;
            Removeplayer2Btn.Visible = false;
            tbPlayer3.Visible = true;
            ShowHiddenSearchDiv.Visible = true;
            confirmBtn.Visible = true;
            confirmBtn.Enabled = true;
        }

        protected void Removeplayer3Btn_Click(object sender, EventArgs e)
        {
            int medlems_id = Convert.ToInt32(Session["player3ID"]);
            int bokning_id = Convert.ToInt32(Session["BokningsID"]);
            string date = Session["selectedDate"].ToString();

            Deletebooking(medlems_id, bokning_id, date);

            lblPlayer3.Visible = false;
            Removeplayer3Btn.Visible = false;
            tbPlayer2.Visible = true;
            ShowHiddenSearchDiv.Visible = true;
            confirmBtn.Visible = true;
            confirmBtn.Enabled = true;
        }

        protected void Removeplayer4Btn_Click(object sender, EventArgs e)
        {
            int medlems_id = Convert.ToInt32(Session["player4ID"]);
            int bokning_id = Convert.ToInt32(Session["BokningsID"]);
            string date = Session["selectedDate"].ToString();

            Deletebooking(medlems_id, bokning_id, date);

            lblPlayer4.Visible = false;
            Removeplayer4Btn.Visible = false;
            tbPlayer1.Visible = true;
            ShowHiddenSearchDiv.Visible = true;
            confirmBtn.Visible = true;
            confirmBtn.Enabled = true;
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {

            if (e.Day.Date < DateTime.Today || e.Day.Date > DateTime.Today.AddDays(30))
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray;
            }

            //Season setDates = new Season();
            //string year = DateTime.Now.Year.ToString();
            //DateTime start = setDates.GetSeasonStartDate(year);
            //DateTime end = setDates.GetSeasonEndDate(year);

            //if (start <= DateTime.Today) //Sets so that any date before today is not selactable.
            //{
            //    start = DateTime.Today;
            //    if ((e.Day.Date < start) || (e.Day.Date > end))
            //    {
            //        e.Day.IsSelectable = false;
            //        e.Cell.ForeColor = System.Drawing.Color.Black;
            //        e.Cell.BackColor = System.Drawing.Color.Gray;
            //        e.Cell.Style.Add("cursor", "not-allowed");
            //        e.Cell.ToolTip = "Du kan inte välja dessa tider, de ligger utanför säsongen.";
            //    }

            //    if (e.Day.Date > start.AddMonths(1))
            //    {
            //        e.Day.IsSelectable = false;
            //        e.Cell.ForeColor = System.Drawing.Color.Black;
            //        e.Cell.BackColor = System.Drawing.Color.Gray;
            //        e.Cell.Style.Add("cursor", "not-allowed");
            //        e.Cell.ToolTip = "Du kan enbart boka banan en månad i förväg.";
            //    }
            //}
            //else
            //{
            //    if ((e.Day.Date < start) || (e.Day.Date > end))
            //    {
            //        e.Day.IsSelectable = false;
            //        e.Cell.ForeColor = System.Drawing.Color.Black;
            //        e.Cell.BackColor = System.Drawing.Color.Gray;
            //        e.Cell.Style.Add("cursor", "not-allowed");
            //        e.Cell.ToolTip = "Du kan inte välja dessa tider, de ligger utanför säsongen.";
            //    }
            //}
        }

        protected void ShowHiddenSearchDiv_Click(object sender, EventArgs e)
        {
            if (hidden2search.Text == "0" || hidden2search.Text == "")
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "showSlideDiv()", "showSlideDiv();", true);
                hidden2search.Text = "1";
            }
            else if (hidden2search.Text == "1")
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "hideSlideDiv()", "hideSlideDiv();", true);
                hidden2search.Text = "0";

                tbFullName.Text = "";
                lbMembers.DataSource = "";
                lbMembers.DataBind();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "closeotherplayers()", "closeotherplayers();", true);
            hidden1others.Text = "0";
            hidden2search.Text = "0";
            tbFullName.Text = "";
            lbMembers.DataSource = "";
            lbMembers.DataBind();
        }

        protected void BtnSearchMember_Click(object sender, EventArgs e)
        {
            lbMembers.DataSource = "";
            lbMembers.DataBind();

            if (tbFullName.Text.Contains(" "))
            {
                string[] name = tbFullName.Text.Split(null);

                SearchMember(name[0], name[1]);
            }
            else
            {
                SearchMember(tbFullName.Text, "");
            }
        }

        protected void btnPickMember_Click(object sender, EventArgs e)
        {
            string golfid = lbMembers.SelectedValue.ToString();

            if (tbPlayer1.Text == "" && tbPlayer1.Visible == true)
            {
                tbPlayer1.Text = golfid;
            }
            else if (tbPlayer2.Text == "" && tbPlayer2.Visible == true && tbPlayer1.Text != golfid)
            {
                tbPlayer2.Text = golfid;
            }
            else if (tbPlayer3.Text == "" && tbPlayer3.Visible == true && tbPlayer1.Text != golfid && tbPlayer2.Text != golfid)
            {
                tbPlayer3.Text = golfid;
            }
            else if (tbPlayer4.Text == "" && tbPlayer4.Visible == true && tbPlayer1.Text != golfid && tbPlayer2.Text != golfid && tbPlayer3.Text != golfid)
            {
                tbPlayer4.Text = golfid;
            }
        }

        /* -------------------------------------- Funktioner -------------------------------*/


        //Sök på namn för att få golfid
        public void SearchMember(string fornamn, string efternamn)
        {
            string sql = "SELECT fornamn, efternamn, golfid FROM medlem WHERE fornamn ~* @fornamn AND efternamn ~* @efternamn OR fornamn ~* @efternamn AND efternamn ~* @fornamn";
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@fornamn", fornamn);
            cmd.Parameters.AddWithValue("@efternamn", efternamn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.Columns.Add("FullName", typeof(string), "fornamn+' '+efternamn");
            conn.Close();

            lbMembers.DataTextField = "FullName";
            lbMembers.DataValueField = "golfid";

            lbMembers.DataSource = dt;
            lbMembers.DataBind();
        }

        //Ta bort en bokning
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

        //Uppdatera tablet med tider så att det syns vilka tider som är bokade
        public void UpdateTable(List<Player> Players)
        {
            int playercount = 0;
            int cellcount = 0;

            foreach (TableRow tr in Table1.Rows)
            {

                foreach (TableCell tc in tr.Cells)
                {
                    cellcount++;
                    playercount = 0;
                    tc.BackColor = ColorTranslator.FromHtml("#7cff82");

                    foreach (Player time in Players)
                    {
                        if (cellcount == time.slot_id)
                        {

                            playercount++;
                            if (playercount >= 4 || time.tavlingsid != 0)
                            {
                                tc.BackColor = Color.Red; //byta ut till css class sen
                            }

                            if (playercount <= 3 && time.tavlingsid == 0)
                            {
                                tc.BackColor = Color.Yellow;
                            }

                        }
                    }
                }
            }
        }

        //Hämta vilka tider som redan är bokade
        public List<Player> GetBookedTimes()
        {
            DateTime selecteddate = Convert.ToDateTime(Session["selectedDate"]);
            string selecteddatestring = selecteddate.ToString("yyyy-MM-dd");

            List<Booking> BookedTimes = new List<Booking>();
            List<Player> Players = new List<Player>();

            string sql = "SELECT bokning_id, tavlings_id, medlem_id, hcp, golfid, kon, bokning.starttid, namn FROM medlem_bokning FULL JOIN medlem ON medlem_id = medlem.id FULL JOIN tavling ON tavlings_id = tavling.id FULL JOIN bokning ON bokning_id = slot_id WHERE medlem_bokning.datum = @selecteddate ORDER BY bokning_id ASC";

            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@selecteddate", selecteddatestring);

            try
            {
                conn.Open();
                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Player golfplayer = new Player();

                    golfplayer.slot_id = Convert.ToInt32(dr["bokning_id"]);

                    if (dr["golfid"] != DBNull.Value)
                    {
                        golfplayer.golfID = dr["golfid"].ToString();
                    }

                    else
                    {
                        golfplayer.golfID = "";
                    }

                    if (dr["kon"] != DBNull.Value)
                    {
                        golfplayer.kon = dr["kon"].ToString();
                    }

                    else
                    {
                        golfplayer.kon = "";
                    }

                    if (dr["hcp"] != DBNull.Value)
                    {
                        golfplayer.hcp = Convert.ToInt32(dr["hcp"]);
                    }

                    else
                    {
                        golfplayer.hcp = 0;
                    }

                    if (dr["medlem_id"] != DBNull.Value)
                    {
                        golfplayer.id = Convert.ToInt32(dr["medlem_id"]);
                    }

                    else
                    {
                        golfplayer.id = 0;
                    }

                    if (dr["tavlings_id"] != DBNull.Value)
                    {
                        golfplayer.tavlingsid = Convert.ToInt32(dr["tavlings_id"]);
                    }

                    else
                    {
                        golfplayer.tavlingsid = 0;
                    }

                    if (dr["namn"] != DBNull.Value)
                    {
                        golfplayer.tavlingsnamn = dr["namn"].ToString();
                        Session["compname"] = golfplayer.tavlingsnamn;
                    }

                    else
                    {
                        golfplayer.tavlingsnamn = "";
                    }

                    DateTime starttid = Convert.ToDateTime(dr["starttid"]);
                    golfplayer.startid = starttid.ToString("HH:mm");

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

        //Visa Info om de spelare som redan finns bokade
        public void ShowPlayerInfo(string time)
        {
            List<Player> Players = GetBookedTimes();
            int playercount = 1;
            
            foreach (Player golfplayer in Players)
            {

                if (golfplayer.tavlingsnamn.ToString() != "" && golfplayer.startid == time)
                {
                    lblPlayer4.Text = "Denna tid är uppbokad för tävlingen " + Session["compname"].ToString();
                    tbPlayer1.Visible = false;
                    tbPlayer2.Visible = false;
                    tbPlayer3.Visible = false;
                    tbPlayer4.Visible = false;
                }

                else if (golfplayer.startid == time && playercount == 1)
                {
                    lblPlayer1.Text = "Handikapp: " + golfplayer.hcp + " " + "Kön: " + golfplayer.kon;
                    lblPlayer1.ID = golfplayer.golfID;
                    Session["player1"] = golfplayer.hcp;
                    Session["player1ID"] = golfplayer.id;
                    lblPlayer1.Visible = true;
                    Removeplayer1Btn.Visible = true;
                    tbPlayer4.Visible = false;
                    playercount++;
                }

                else if (golfplayer.startid == time && playercount == 2)
                {
                    lblPlayer2.Text = "Handikapp: " + golfplayer.hcp + " " + "Kön: " + golfplayer.kon;
                    lblPlayer2.ID = golfplayer.golfID;
                    Session["player2"] = golfplayer.hcp;
                    Session["player2ID"] = golfplayer.id;
                    lblPlayer2.Visible = true;
                    Removeplayer2Btn.Visible = true;
                    tbPlayer3.Visible = false;
                    tbPlayer4.Visible = false;
                    playercount++;
                }

                else if (golfplayer.startid == time && playercount == 3)
                {
                    lblPlayer3.Text = "Handikapp: " + golfplayer.hcp + " " + "Kön: " + golfplayer.kon;
                    lblPlayer2.ID = golfplayer.golfID;
                    Session["player3"] = golfplayer.hcp;
                    Session["player3ID"] = golfplayer.id;
                    lblPlayer3.Visible = true;
                    Removeplayer3Btn.Visible = true;
                    tbPlayer2.Visible = false;
                    tbPlayer3.Visible = false;
                    tbPlayer4.Visible = false;
                    playercount++;
                }

                else if (golfplayer.startid == time && playercount == 4)
                {
                    lblPlayer4.Text = "Handikapp: " + golfplayer.hcp + " " + "Kön: " + golfplayer.kon;
                    lblPlayer2.ID = golfplayer.golfID;
                    Session["player4"] = golfplayer.hcp;
                    Session["player4ID"] = golfplayer.id;
                    lblPlayer4.Visible = true;
                    Removeplayer4Btn.Visible = true;
                    tbPlayer1.Visible = false;
                    tbPlayer2.Visible = false;
                    tbPlayer3.Visible = false;
                    tbPlayer4.Visible = false;
                    ShowHiddenSearchDiv.Visible = false;
                    playercount++;
                }
            }
        }

        //Kolla om angivet golfid redan finns bokad på tiden
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
    }
}