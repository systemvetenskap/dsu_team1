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
            DataSet ds = new DataSet();

            try
            {
                StringReader sr = new StringReader(xml);
                ds.ReadXml(sr);
            }

            catch (Exception ex)
            {

            }

            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            
        }

        protected void btnGeneratePlaylist_Click(object sender, EventArgs e)
        {
            string compName = gvComps.SelectedValue.ToString();
            Competition comp = new Competition();
            DataTable players = comp.GetCompetitors(compName);

            DataTable competitioninfo = comp.GetSpecificCompetition(compName);
            string starttime = Convert.ToString(competitioninfo.Rows[0]["starttid"]);



            DataTable RndStartList = SetCompetitorsTeeTimes(players, starttime);
            
            string xml;
            using (StringWriter sw = new StringWriter())
            {
                RndStartList.WriteXml(sw);
                xml = sw.ToString();
            }

            comp.SetStartList(xml, compName);
            
        }

        protected DataTable SetCompetitorsTeeTimes(DataTable dt, string starttime)
        {
            Random r = new Random();
            DataTable RndTeeTimes = new DataTable();
            RndTeeTimes.Columns.Add("Starttid");
            RndTeeTimes.Columns.Add("Golf ID");
            RndTeeTimes.Columns.Add("Förnamn");
            RndTeeTimes.Columns.Add("Efternamn");
            RndTeeTimes.TableName = "StartTimes";

            int i = 0;
            DateTime starttimedt = Convert.ToDateTime(starttime);

            while (dt.Rows.Count > 0)
            {
                int rndrow = r.Next(dt.Rows.Count);

                RndTeeTimes.Rows.Add();
                RndTeeTimes.Rows[i][0] = starttimedt.ToString("HH:mm");
                RndTeeTimes.Rows[i][1]  = dt.Rows[rndrow]["golfid"];
                RndTeeTimes.Rows[i][2] = dt.Rows[rndrow]["fornamn"];
                RndTeeTimes.Rows[i][3] = dt.Rows[rndrow]["efternamn"];

                DataRow dr = dt.Rows[rndrow];
                dr.Delete();
                dt.AcceptChanges();

                i++;

                if (i % 3 == 0)
                {
                    starttimedt = starttimedt.AddMinutes(10);
                }
            }

            GridView1.DataSource = RndTeeTimes;
            GridView1.DataBind();
            GridView1.Visible = true;
            return RndTeeTimes;
        }

        protected void gvComps_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.Visible = false;
            btnGeneratePlaylist.Visible = false;
            BtnGeneratePlaylistLag.Visible = false;
            foreach (GridViewRow row in gvComps.Rows)
            {
                if (row.RowIndex == gvComps.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#6C6C6C");
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                }
            }

            Competition specCompetition = new Competition();
            string compName = gvComps.SelectedValue.ToString();
            DataTable competition = specCompetition.GetSpecificCompetition(compName);

            int players = Convert.ToInt32(specCompetition.GetNOcompetitors(compName));

            if (gvComps.SelectedRow.Cells[3].Text.ToLower() == "singel")
            {
                lblinfo.Text = players.ToString() + " spelare är anmälda";
                btnGeneratePlaylist.Visible = true;

                if (players > 0)
                {
                    btnGeneratePlaylist.Visible = true;

                }

                if (players == 0)
                {
                    btnGeneratePlaylist.Visible = false;
                }

                if (competition.Rows[0]["startlistxml"] is DBNull)
                {
                    GridView1.Visible = false;
                    btnGeneratePlaylist.Visible = true;
                }

                else
                {
                    BindGrid(competition.Rows[0]["startlistxml"].ToString());
                    GridView1.Visible = true;
                    btnGeneratePlaylist.Visible = false;
                }
            }
            if (gvComps.SelectedRow.Cells[3].Text.ToLower() == "lag")
            {
                
                BtnGeneratePlaylistLag.Visible = true;
            }
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

    }
}