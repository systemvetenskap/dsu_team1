using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using System.Data;

namespace Team_1_Halslaget_GK
{
    public partial class searchMembers : System.Web.UI.Page
    {
        List<medlem> medlemmar = new List<medlem>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string checkIDorName = "";
            string query = textBoxSearch.Text;

            if (CheckBox1.Checked == true) {
                checkIDorName = "name";
            }
            if (CheckBox2.Checked == true) {
                checkIDorName = "id";
            }
                NpgsqlConnection con = new NpgsqlConnection("Server=webblabb.miun.se; Port=5432; Database=dsu_golf; User Id=dsu_g1; Password=dsu_g1; SslMode=Require");
                string sql = "SELECT" + checkIDorName + " FROM medlem";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                con.Open();
                NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    {
                        if (checkIDorName == "name")
                        {
                            databaseFill.InnerHtml = "<li>" + dr["fornamn"] + dr["efternamn"];
                        }
                        else
                        {
                            databaseFill.InnerHtml = "<li>" + dr["id"] + dr["fornamn"] + dr["efternamn"];
                        }
                    }
                    databaseFill.InnerHtml = "</ul>";
                }
                con.Close();
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true)
            { CheckBox2.Checked = false;}
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox2.Checked == true)
            { CheckBox1.Checked = false; }
        }

    
    }
}