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

namespace Team_1_Halslaget_GK
{
    public partial class result : System.Web.UI.Page
    {

        NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

        Competition selectedComp;

        protected void Page_Load(object sender, EventArgs e)
        {
            Competition comp = new Competition();

            GvComps.DataSource = comp.GetAllPastCompetitions();
            GvComps.DataBind();
            
        }

        protected void GvComps_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GvComps.Rows)
            {
                if (row.RowIndex == GvComps.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#6C6C6C");
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                }
            }

            selectedComp = new Competition();
            selectedComp.id = GvComps.SelectedValue.ToString();

            if (GvComps.SelectedRow.Cells[3].Text.ToLower() == "singel")
            {
                DataTable dt1 = getSingelCompResultlist(selectedComp.id);
                GvResult.DataSource = dt1;

                GvResult.Columns[3].Visible = false;


            }
            if (GvComps.SelectedRow.Cells[3].Text.ToLower() == "lag")
            {
                DataTable dt2 = getTeamCompResultlist(selectedComp.id);
                GvResult.DataSource = dt2;

                GvResult.Columns[3].Visible = true;
              
            }

            GvResult.DataBind();

        }

        /* ------------------- Funktioner ---------------------*/

        public DataTable getSingelCompResultlist(string compid)
        {
            string sql = "SELECT medlem_tavling.score, medlem.fornamn, medlem.efternamn FROM tavling INNER JOIN medlem_tavling ON (tavling.id = medlem_tavling.tavling_id) INNER JOIN medlem ON( medlem_tavling.medlem_id = medlem.id) WHERE tavling.id = @tavling_id ORDER by score ASC";
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

        public DataTable getTeamCompResultlist(string compid)
        {
            string sql = "SELECT medlem.fornamn, medlem.efternamn, lag_medlem.slutresultat, lag_medlem.lag_id FROM tavling INNER JOIN lag_tavling ON( tavling.id = lag_tavling.id_tavling) INNER JOIN lag_medlem ON (lag_tavling.id_lag = lag_medlem.lag_id) INNER JOIN medlem ON (lag_medlem.medlem_id = medlem.id)  WHERE tavling.id = @tavling_id ORDER BY slutresultat, lag_medlem.lag_id ASC";
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


    }
}