using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team_1_Halslaget_GK
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se; Port=5432; Database=dsu_golf; User Id=dsu_g1; Password=dsu_g1; SslMode=Require");

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Username"] == null)
            {
                Response.Redirect("~/NotAllowed.aspx");
            }

            if (!IsPostBack)
            {
                if(Session["type"].ToString().ToLower() == "singel")
                {
                    DataTable dt1 = getSingelCompPlaylist(Session["compid"].ToString());
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();
                }
                if (Session["type"].ToString().ToLower() == "lag")
                {
                    DataTable dt2 = getTeamCompPlaylist(Session["compid"].ToString());
                    GridView1.DataSource = dt2;
                    GridView1.DataBind();
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
    }
}