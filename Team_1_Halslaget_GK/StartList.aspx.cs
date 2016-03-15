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
            GridView1.Visible = false;
            btnGeneratePlaylist.Visible = true;
            BtnGeneratePlaylistLag.Visible = false;

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