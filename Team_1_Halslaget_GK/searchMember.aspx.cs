using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using System.Data;

public partial class searchMember : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void buttonSearch_Click(object sender, EventArgs e)
    {
        string checkIDorName = "";
        string query = textBoxSearch.Text;

        if (checkBoxName.Checked == true)
        {
            checkIDorName = "name";
        }
        if (checkBoxID.Checked == true)
        {
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
}