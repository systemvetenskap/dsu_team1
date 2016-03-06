using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using System.Drawing;

namespace Team_1_Halslaget_GK
{
	public partial class Tidsbokning : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
                                     
        }

        protected List<Player> GetBookedTimes()
        {
            string selectedDate = "'"+Session["selectedDate"].ToString()+"'";
            string date = "'2016-06-11'";
            List<Booking> BookedTimes = new List<Booking>();
            List<Player> Players = new List<Player>();
            NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se; Port=5432; Database=dsu_golf; User Id=dsu_g1; Password=dsu_g1; SslMode=Require");
            string sql = "SELECT bokning_id, kon, hcp, golfID, starttid FROM medlem_bokning INNER JOIN medlem ON medlem_id = id AND datum = "+ date + " INNER JOIN bokning ON bokning_id = slot_id ORDER BY bokning_id";

            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

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
                conn.Dispose();
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

        public class ClickableTableCell : TableCell, IPostBackEventHandler
        {
            public event EventHandler Click;

            public override void RenderBeginTag(HtmlTextWriter writer)
            {
                Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(this, null));
                base.RenderBeginTag(writer);
            }

            public void RaisePostBackEvent(string eventArgument)
            {
                OnClick(new EventArgs());
            }

            protected void OnClick(EventArgs e)
            {
                if (Click != null)
                    Click(this, e);
            }

        }

        protected void LinkButton_Click(object sender, EventArgs e)
        {
            lblPlayer1.Text = "";
            lblPlayer2.Text = "";
            lblPlayer3.Text = "";
            lblPlayer4.Text = ""; 
            LinkButton btn = (LinkButton)sender;
            ShowPlayerInfo(btn.Text);
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

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Label1.Text = Calendar1.SelectedDate.ToShortDateString();
            Session["selectedDate"] = Calendar1.SelectedDate.ToShortDateString();
            UpdateTable(GetBookedTimes());
        }
    }
}