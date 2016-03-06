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
            
            if (!IsPostBack)
            {
                Table1.Visible = false;
                Calendar1.SelectedDate = DateTime.Today;
            }
                              
        }

        protected List<Player> GetBookedTimes()
        {
            DateTime selecteddate = Calendar1.SelectedDate;
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

                    foreach (Player time in Players)
                    {

                        playercount++;
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
            if (CheckSeason() && CheckBookingRestrictions())
            {
                int medlems_id = 5;
                int boknings_id = Convert.ToInt32(Session["BokningsID"]);

                DateTime date = Convert.ToDateTime(Session["selectedDate"]);

                Booking newbooking = new Booking();

                newbooking.Newbooking(medlems_id, boknings_id, date, conn);
            }

            else
            {
                //Varninsruta
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

        protected bool CheckBookingRestrictions()
        {
            int boknings_id = Convert.ToInt32(Session["BokningsID"]);
            List<Player> Players = GetBookedTimes();
            int hcp = 0;

            foreach (Player pl in Players)
            {
                hcp += pl.hcp;
            }

            if (hcp + 15 > 100) //Session["hcp"]
            {
                //Varningsruta, för dåliga spelare
                return false;
            }

            else if (Players.Count == 4)
            {
                //Varningsruta, för många spelare
                return false;               
            }

            else
            {
                return true;
            }
        }
    }
}