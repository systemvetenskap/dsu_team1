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
            bool admin = true; //Convert.ToBoolean(Session["admin"])
   
            if (!IsPostBack)
            {
                Table1.Visible = false;
                Calendar1.SelectedDate = DateTime.Today;

                if(admin) 
                {
                    TextBoxPlayer1.Visible = true;
                    LabelPlayer1.Visible = true;
                }
            }
                              
        }

        protected List<Player> GetBookedTimes()
        {
            DateTime selecteddate = Convert.ToDateTime(Session["selectedDate"]);
            string selecteddatestring = selecteddate.ToString("yyyy-MM-dd");         

            List<Booking> BookedTimes = new List<Booking>();
            List<Player> Players = new List<Player>();
            
            string sql = "SELECT bokning_id, kon, hcp, golfID, starttid FROM medlem_bokning INNER JOIN medlem ON medlem_id = id AND datum = @selecteddate INNER JOIN bokning ON bokning_id = slot_id ORDER BY bokning_id";

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
                    tr.Cells[i].BackColor = Color.Green;
                    cellcount++;
                    playercount = 0;

                    foreach (Player time in Players)
                    {
                        if (cellcount == time.slot_id)
                        {
                            playercount++;
                            if (playercount == 4)
                            {
                                tr.Cells[i].BackColor = Color.Red; //byta ut till css class sen
                            }

                            else
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
            LinkButton btn = (LinkButton)sender;

            lblPlayer1.Text = "";
            lblPlayer2.Text = "";
            lblPlayer3.Text = "";
            lblPlayer4.Text = ""; 
            
            ShowPlayerInfo(btn.Text);

            string LinkButtonID = btn.ID;
            string bokningsID = LinkButtonID.Remove(0,10);

            Session["BokningsID"] = bokningsID;            
        }

        protected void ShowPlayerInfo(string time)
        {
            List<Player> Players = GetBookedTimes();
            int playercount = 1;

            foreach (Player golfplayer in Players)
            {               
                if (golfplayer.startid == time && playercount == 1)
                {
                    lblPlayer1.Text = golfplayer.golfID + " " + golfplayer.hcp + " " + golfplayer.kon;
                    playercount++;
                }

                else if (golfplayer.startid == time && playercount == 2)
                {
                    lblPlayer2.Text = golfplayer.golfID + " " + golfplayer.hcp + " " + golfplayer.kon;
                    playercount++;
                }

                else if (golfplayer.startid == time && playercount == 3)
                {
                    lblPlayer3.Text = golfplayer.golfID + " " + golfplayer.hcp + " " + golfplayer.kon;
                    playercount++;
                }

                else if (golfplayer.startid == time && playercount == 4)
                {
                    lblPlayer4.Text = golfplayer.golfID + " " + golfplayer.hcp + " " + golfplayer.kon;
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
            bool admin = true;//Convert.ToBoolean(Session["admin"]);

            if (CheckSeason() && CheckBookingRestrictions(dt))
            {
                if(!admin)
                {
                    int medlems_id = 5; //Session["Username"]

                    newbooking.Newbooking(medlems_id, boknings_id, date, conn);
                }

                if (dt.Rows.Count > 0)
                {
                    newbooking.Newbooking(Convert.ToInt32(dt.Rows[0][0]), boknings_id, date, conn);
                }

                if (dt.Rows.Count > 1)
                {
                    newbooking.Newbooking(Convert.ToInt32(dt.Rows[1][0]), boknings_id, date, conn);
                }

                if (dt.Rows.Count > 2)
                {
                    newbooking.Newbooking(Convert.ToInt32(dt.Rows[2][0]), boknings_id, date, conn);
                }

                if (dt.Rows.Count > 3)
                {
                    newbooking.Newbooking(Convert.ToInt32(dt.Rows[2][0]), boknings_id, date, conn);
                }
            }

            else
            {
                //Varningsruta
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
                return false;
            }

            else if (dt.Rows.Count == 1 && dt.Rows[0]["bana"] == "range")
            {
                return false;
            }

            else
            {
                return true;
            }
        }

        protected bool CheckBookingRestrictions(DataTable dt)
        {
            int hcp = 0;
            int playercount;
            bool admin = true;//Convert.ToBoolean(Session["admin"]);

            if (admin)
            {
                playercount = 0;
            }

            else
            {
                playercount = 1;
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
                }
            }

            if (hcp + 15 > 100) //Session["hcp"]
            {
                //Varningsruta, för dåliga spelare
                return false;
            }

            else if (playercount + dt.Rows.Count > 4)
            {
                //Varningsruta, för många spelare
                return false;               
            }

            else
            {
                return true;
            }
        }

        protected DataTable CheckNoOfPlayers()
        {

            if (TextBoxPlayer1.Text == "" && TextBoxPlayer2.Text == "" && TextBoxPlayer3.Text == "" && TextBoxPlayer4.Text == "")
            {
                DataTable dt = new DataTable();
                return dt;
            }

            else if (TextBoxPlayer1.Text != "" && TextBoxPlayer2.Text != "" && TextBoxPlayer3.Text != "" && TextBoxPlayer4.Text != "")
            {
                string sql = "SELECT id, hcp FROM medlem WHERE golfid IN (@golfid1, @golfid2 , @golfid3, @golfid4)";
                int no = 4;
                return GetExtraPlayerInfo(sql, no);
            }

            else if (TextBoxPlayer2.Text != "" && TextBoxPlayer3.Text != "" && TextBoxPlayer4.Text != "")
            {
                string sql = "SELECT id, hcp FROM medlem WHERE golfid IN (@golfid2, @golfid3 , @golfid4)";
                int no = 3;
                return GetExtraPlayerInfo(sql, no);
            }

            else if (TextBoxPlayer1.Text != "" && TextBoxPlayer2.Text != "" && TextBoxPlayer3.Text != "")
            {
                string sql = "SELECT id, hcp FROM medlem WHERE golfid IN (@golfid1, @golfid2 , @golfid3)";
                int no = 3;
                return GetExtraPlayerInfo(sql, no);
            }

            else if (TextBoxPlayer2.Text != "" && TextBoxPlayer3.Text != "")
            {
                string sql = "SELECT id, hcp FROM medlem WHERE golfid IN (@golfid2, @golfid3)";
                int no = 2;
                return GetExtraPlayerInfo(sql, no);
            }

            else if (TextBoxPlayer1.Text != "" && TextBoxPlayer2.Text != "")
            {
                string sql = "SELECT id, hcp FROM medlem WHERE golfid IN (@golfid1, @golfid2)";
                int no = 2;
                return GetExtraPlayerInfo(sql, no);
            }

            else if (TextBoxPlayer2.Text != "")
            {
                string sql = "SELECT id, hcp FROM medlem WHERE golfid IN (@golfid2)";
                int no = 1;
                return GetExtraPlayerInfo(sql, no);
            }

            else
            {
                string sql = "SELECT id, hcp FROM medlem WHERE golfid IN (@golfid1)";
                int no = 1;
                return GetExtraPlayerInfo(sql, no);
            }    
        }

        protected DataTable GetExtraPlayerInfo(string sql, int no)
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.AddWithValue("@golfid1", TextBoxPlayer1.Text);
            da.SelectCommand.Parameters.AddWithValue("@golfid2", TextBoxPlayer2.Text);
            da.SelectCommand.Parameters.AddWithValue("@golfid3", TextBoxPlayer3.Text);
            da.SelectCommand.Parameters.AddWithValue("@golfid4", TextBoxPlayer4.Text);


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
                //varningsruta fel golfid
                return null;
            }

            else
            {
                return dt;
            }
        }

        protected void DropDownListNOPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabelPlayer2.Visible = false;
            LabelPlayer3.Visible = false;
            LabelPlayer4.Visible = false;
            TextBoxPlayer2.Visible = false;
            TextBoxPlayer3.Visible = false;
            TextBoxPlayer4.Visible = false;


            if (DropDownListNOPlayers.SelectedIndex == 1)
            {
                LabelPlayer2.Visible = true;
                TextBoxPlayer2.Visible = true;
            }

            if (DropDownListNOPlayers.SelectedIndex == 2)
            {
                LabelPlayer2.Visible = true;
                TextBoxPlayer2.Visible = true;
                LabelPlayer3.Visible = true;
                TextBoxPlayer3.Visible = true;
            }

            if (DropDownListNOPlayers.SelectedIndex == 3)
            {
                LabelPlayer2.Visible = true;
                TextBoxPlayer2.Visible = true;
                LabelPlayer3.Visible = true;
                TextBoxPlayer3.Visible = true;
                LabelPlayer4.Visible = true;
                TextBoxPlayer4.Visible = true;
            }
        }
    }
}