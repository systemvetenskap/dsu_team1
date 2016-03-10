using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team_1_Halslaget_GK
{
    public partial class Bokatavling : System.Web.UI.Page
    {
        NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            FilllbTavlingar();
        }

        public void GetAllCompetions(List<Competition> CompList)
        {
            string sql = "SELECT * FROM tavling";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

            conn.Open();

            NpgsqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Competition newcompetition = new Competition();
                newcompetition.namn = dr["namn"].ToString();
                newcompetition.desc = dr["description"].ToString();
                newcompetition.type = dr["type"].ToString();
                newcompetition.sluttid = dr["sluttid"].ToString();
                newcompetition.starttid = dr["starttid"].ToString();
                newcompetition.id = dr["id"].ToString();
                CompList.Add(newcompetition);
            }

            conn.Close();
        }
    }
}