using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Npgsql;
using System.Web.UI.WebControls;

namespace Team_1_Halslaget_GK
{
    public partial class MobileLeaderboard : System.Web.UI.Page
    {
        int holeNr = 1;
        int antalSlag;
        //string username = Session["username"].ToString();
        string username = "2"; //Temporary
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                antalSlag = 0;
                holeNr = 1;
                string tavling;
                LabelHole.Text = holeNr.ToString();
                //LabelAntalSlag.Text = antalSlag.ToString();

                string sql = "SELECT namn from tavling WHERE id =(SELECT max(id) FROM tavling WHERE id = (SELECT tavling_id FROM medlem_tavling WHERE medlem_id = "+ username +"));";
                NpgsqlConnection con = new NpgsqlConnection("Server=webblabb.miun.se; Port=5432; Database=dsu_golf; User Id=dsu_g1; Password=dsu_g1; SslMode=Require");
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                con.Open();
                NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tavling = dr["namn"].ToString();
                    LabelTavlingsID.Text = "Tävling: " + tavling;
                }
                con.Close();
                sql = "INSERT INTO scoreboard (medlem_id, tavling_id) SELECT '" + username + "', (SELECT max(id) FROM tavling WHERE id = (SELECT tavling_id FROM medlem_tavling WHERE medlem_id = " + username + ")) WHERE NOT EXISTS(SELECT 1 FROM scoreboard WHERE medlem_id = " + username + ")";
                NpgsqlCommand cmd2 = new NpgsqlCommand(sql, con);
                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();
                con.Dispose();
            }
            else if (IsPostBack)
            {
                string par = "";
                antalSlag = int.Parse(LabelAntalSlag.Text);
                antalSlag += int.Parse(TextBox1.Text);
                LabelAntalSlag.Text = antalSlag.ToString();
                holeNr = int.Parse(LabelHole.Text);
                string sql = "SELECT par from holes WHERE holeno = " + holeNr.ToString() +"";
                NpgsqlConnection con = new NpgsqlConnection("Server=webblabb.miun.se; Port=5432; Database=dsu_golf; User Id=dsu_g1; Password=dsu_g1; SslMode=Require");
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    par = dr["par"].ToString();
                }
                int par2 = int.Parse(par);
                int score = antalSlag - par2;
                sql = "UPDATE scoreboard SET hole= " + holeNr.ToString() + ", score = " + score.ToString() + " WHERE medlem_id = " + username + "";
                NpgsqlCommand cmd2 = new NpgsqlCommand(sql, con);
                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();
                con.Dispose();
            }

        }
        protected void buttonNext_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
            {
                LabelFeedback.ForeColor = System.Drawing.Color.Red;
                LabelFeedback.Text = "Du måste fylla i antal slag";
            }
            else if (TextBox1.Text != "")
            {
                LabelFeedback.Text = "";
                //Counter for current hole
                holeNr = int.Parse(LabelHole.Text);
                holeNr = holeNr + 1;
                LabelHole.Text = holeNr.ToString();
                //Reset
                buttonNext.Text = "";
            }
        }
    }
}