using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Team_1_Halslaget_GK
{
    public partial class StartList : System.Web.UI.Page
    {

        NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["Username"] == null)
            //{
            //    Response.Redirect("~/NotAllowed.aspx");
            //}
            if (!IsPostBack)
            {
                InitializeGUI();
            }
            GridView1.Visible = false;
            btnGeneratePlaylist.Visible = false;
            BtnGeneratePlaylistLag.Visible = false;
        }

        protected void InitializeGUI()
        {
            BindDropDownCompetition();
        }

        private void BindDropDownCompetition()
        {
            Competition comp = new Competition();
                      
            gvComps.DataSource = comp.GetAllUpcomingCompetitions();
            gvComps.DataBind();

        }

        protected void BindGrid(string xml)
        {

            
        }

        protected void btnGeneratePlaylist_Click(object sender, EventArgs e)
        {
            string tavling_id = gvComps.SelectedValue.ToString();
            string sql = "SELECT * FROM medlem_tavling WHERE tavling_id = @tavling_id";

            List<medlem> ListOfMedlem = new List<medlem>();
            List<Teamslump> ListOfBokningsID = new List<Teamslump>();
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@tavling_id", tavling_id);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                medlem medlem = new medlem();
                medlem.ID = Convert.ToInt32(dr["medlem_id"]);
                ListOfMedlem.Add(medlem);
            }
            conn.Close();

            string sql1 = "SELECT * FROM tavling WHERE id = @id ";
            conn.Open();
            NpgsqlCommand cmd1 = new NpgsqlCommand(sql1, conn);
            cmd1.Parameters.AddWithValue("@id", gvComps.SelectedValue.ToString());
            NpgsqlDataReader dr1 = cmd1.ExecuteReader();

            Competition c = new Competition();

            while (dr1.Read())
            {
                c.starttid = dr1["starttid"].ToString();
                c.sluttid = dr1["sluttid"].ToString();
            }
            conn.Close();

            string sql2 = "SELECT * FROM bokning WHERE starttid >= @starttid AND starttid <= @sluttid";

            conn.Open();
            NpgsqlCommand cmd2 = new NpgsqlCommand(sql2, conn);
            cmd2.Parameters.AddWithValue("@starttid", c.starttid);
            cmd2.Parameters.AddWithValue("@sluttid", c.sluttid);
            NpgsqlDataReader dr2 = cmd2.ExecuteReader();

            while (dr2.Read())
            {
                Teamslump newt = new Teamslump();
                newt.id = Convert.ToInt32(dr2["slot_id"]);
                ListOfBokningsID.Add(newt);

            }
            conn.Close();

            Random R = new Random();

            foreach (Teamslump b in ListOfBokningsID)
            {
                int index = R.Next(0, ListOfMedlem.Count);

                medlem temp = ListOfMedlem[index];

                string sql3 = "UPDATE medlem_tavling SET starttid_id = @starttid_id WHERE medlem_id = @medlem_id AND tavling_id = @tavling_id";
                conn.Open();
                NpgsqlCommand cmd3 = new NpgsqlCommand(sql3, conn);
                cmd3.Parameters.AddWithValue("@starttid_id", b.id);
                cmd3.Parameters.AddWithValue("@medlem_id", temp.ID.ToString());
                cmd3.Parameters.AddWithValue("@tavling_id", tavling_id);
                cmd3.ExecuteNonQuery();
                conn.Close();

                ListOfMedlem.RemoveAt(index);

                index = R.Next(0, ListOfMedlem.Count);

                if (ListOfMedlem.Count == 0)
                {
                    break;
                }

                medlem temp2 = ListOfMedlem[index];

                string sql4 = "UPDATE medlem_tavling SET starttid_id = @starttid_id WHERE medlem_id = @medlem_id AND tavling_id = @tavling_id";
                conn.Open();
                NpgsqlCommand cmd4 = new NpgsqlCommand(sql4, conn);
                cmd4.Parameters.AddWithValue("@starttid_id", b.id);
                cmd4.Parameters.AddWithValue("@medlem_id", temp2.ID.ToString());
                cmd4.Parameters.AddWithValue("@tavling_id", tavling_id);
                cmd4.ExecuteNonQuery();
                conn.Close();

                ListOfMedlem.RemoveAt(index);

                if (ListOfMedlem.Count == 0)
                {
                    break;
                }

                medlem temp3 = ListOfMedlem[index];

                string sql5 = "UPDATE medlem_tavling SET starttid_id = @starttid_id WHERE medlem_id = @medlem_id AND tavling_id = @tavling_id";
                conn.Open();
                NpgsqlCommand cmd5 = new NpgsqlCommand(sql5, conn);
                cmd5.Parameters.AddWithValue("@starttid_id", b.id);
                cmd5.Parameters.AddWithValue("@medlem_id", temp3.ID.ToString());
                cmd5.Parameters.AddWithValue("@tavling_id", tavling_id);
                cmd5.ExecuteNonQuery();
                conn.Close();

                ListOfMedlem.RemoveAt(index);

                if (ListOfMedlem.Count == 0)
                {
                    break;
                }
            }



        }

        protected void gvComps_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowIndex == GridView1.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#6C6C6C");
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                }

            }

            GridView1.Visible = true;                      

            if (gvComps.SelectedRow.Cells[3].Text.ToLower() == "singel")
            {
                DataTable dt1 = getSingelCompPlaylist(gvComps.SelectedValue.ToString());
                GridView1.DataSource = dt1;

                btnGeneratePlaylist.Visible = true;

                if(dt1.Rows.Count > 0)
                {
                    BtnGeneratePlaylistLag.Visible = false;
                    btnGeneratePlaylist.Visible = false;
                }            

                GridView1.Columns[3].Visible = false;

                lblcount.Text = "Det finns " + countsingle(gvComps.SelectedValue.ToString()).ToString() + " anmälda till den här tävlingen";
            }
            if (gvComps.SelectedRow.Cells[3].Text.ToLower() == "lag")
            {
                DataTable dt2 = getTeamCompPlaylist(gvComps.SelectedValue.ToString());
                GridView1.DataSource = dt2;

                BtnGeneratePlaylistLag.Visible = true;

                if (dt2.Rows.Count > 0)
                {
                    BtnGeneratePlaylistLag.Visible = false;
                    btnGeneratePlaylist.Visible = false;
                }

                GridView1.Columns[3].Visible = true;

                lblcount.Text = "Det finns " + countteam(gvComps.SelectedValue.ToString()).ToString() + " anmälda lag till den här tävlingen";
            }
            GridView1.DataBind();
        }

        protected void BtnGeneratePlaylistLag_Click(object sender, EventArgs e)
        {
            string tavling_id = gvComps.SelectedValue.ToString();
            string sql = "SELECT * FROM lag_tavling WHERE id_tavling = @tavling_id";

            List<Team> ListofTeams = new List<Team>();
            List<Teamslump> ListOfBokningsID = new List<Teamslump>();
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@tavling_id", tavling_id);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Team team = new Team();
                team.id = dr["id_lag"].ToString();
                ListofTeams.Add(team);
            }
            conn.Close();

            string sql1 = "SELECT * FROM tavling WHERE id = @id ";
            conn.Open();
            NpgsqlCommand cmd1 = new NpgsqlCommand(sql1, conn);
            cmd1.Parameters.AddWithValue("@id", gvComps.SelectedValue.ToString());
            NpgsqlDataReader dr1 = cmd1.ExecuteReader();

            Competition c = new Competition();

            while (dr1.Read())
            {
                c.starttid = dr1["starttid"].ToString();
                c.sluttid = dr1["sluttid"].ToString();
            }
            conn.Close();
            string sql2 = "SELECT * FROM bokning WHERE starttid >= @starttid AND starttid <= @sluttid";

            conn.Open();
            NpgsqlCommand cmd2 = new NpgsqlCommand(sql2, conn);
            cmd2.Parameters.AddWithValue("@starttid", c.starttid);
            cmd2.Parameters.AddWithValue("@sluttid", c.sluttid);     
            NpgsqlDataReader dr2 = cmd2.ExecuteReader();

            while (dr2.Read())
            {
                Teamslump newt = new Teamslump();
                newt.id = Convert.ToInt32(dr2["slot_id"]);
                ListOfBokningsID.Add(newt);
                
            }
            conn.Close();

            Random R = new Random();

            foreach (Teamslump b in ListOfBokningsID)
            {
                int index = R.Next(0, ListofTeams.Count);

                Team temp = ListofTeams[index];

                string sql3 = "UPDATE lag_tavling SET starttid_id = @starttid_id WHERE id_lag = @lag_id AND id_tavling = @tavling_id";
                conn.Open();
                NpgsqlCommand cmd3 = new NpgsqlCommand(sql3, conn);
                cmd3.Parameters.AddWithValue("@starttid_id", b.id);
                cmd3.Parameters.AddWithValue("@lag_id", temp.id);
                cmd3.Parameters.AddWithValue("@tavling_id", tavling_id);
                cmd3.ExecuteNonQuery();
                conn.Close();

                ListofTeams.RemoveAt(index);

                index = R.Next(0, ListofTeams.Count);
                

                Team temp2 = ListofTeams[index];

                string sql4 = "UPDATE lag_tavling SET starttid_id = @starttid_id WHERE id_lag = @lag_id AND id_tavling = @tavling_id";
                conn.Open();
                NpgsqlCommand cmd4 = new NpgsqlCommand(sql4, conn);
                cmd4.Parameters.AddWithValue("@starttid_id", b.id);
                cmd4.Parameters.AddWithValue("@lag_id", temp2.id);
                cmd4.Parameters.AddWithValue("@tavling_id", tavling_id);
                cmd4.ExecuteNonQuery();
                conn.Close();

                ListofTeams.RemoveAt(index);

                if (ListofTeams.Count == 0)
                {
                    break;
                }
            }
        }

        public DataTable getSingelCompPlaylist(string compid)
        {
            string sql = "SELECT  bokning.starttid, medlem.fornamn, medlem.efternamn FROM tavling INNER JOIN medlem_tavling ON (tavling.id = medlem_tavling.tavling_id) INNER JOIN bokning ON (medlem_tavling.starttid_id = bokning.slot_id) INNER JOIN medlem ON( medlem_tavling.medlem_id = medlem.id) WHERE tavling.id = @tavling_id ORDER BY bokning.starttid ASC";
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@tavling_id", compid);
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter();
            nda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            nda.Fill(dt);
            conn.Close();
            return dt;
        }

        public DataTable getTeamCompPlaylist(string compid)
        {
            string sql = "SELECT medlem.fornamn, medlem.efternamn, bokning.starttid, lag_medlem.lag_id FROM tavling INNER JOIN lag_tavling ON( tavling.id = lag_tavling.id_tavling) INNER JOIN lag_medlem ON (lag_tavling.id_lag = lag_medlem.lag_id) INNER JOIN medlem ON (lag_medlem.medlem_id = medlem.id) INNER JOIN bokning ON(lag_tavling.starttid_id = bokning.slot_id) WHERE tavling.id = @tavling_id ORDER BY bokning.starttid, lag_medlem.lag_id ASC";
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@tavling_id", compid);
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter();
            nda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            nda.Fill(dt);
            conn.Close();
            return dt;
        }

        public int countsingle(string compid)
        {
            string sql = "SELECT Count(*) FROM medlem_tavling WHERE tavling_id = @id_tavling";
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id_tavling", compid);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            
            conn.Close();
            return count;
        }

        public int countteam(string compid)
        {
            string sql = "SELECT Count(*) FROM lag_tavling WHERE id_tavling = @id_tavling";
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id_tavling", compid);
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            conn.Close();
            return count;
        }



    }
}