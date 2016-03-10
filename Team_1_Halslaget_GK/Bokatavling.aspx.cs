using Npgsql;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            Competition newcomp = new Competition();
            gvTavlingar.DataSource = newcomp.GetAllCompetitions();
            gvTavlingar.DataBind();
            lblTavlingDesc.Visible = false;
            lblTavlingNamn.Visible = false;
            lblTavlingTyp.Visible = false;

        }

        protected void gvTavlingar_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvTavlingar.Rows)
            {
                if (row.RowIndex == gvTavlingar.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#6C6C6C");
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                }
            }

            Competition newcom = GetspecificComp(gvTavlingar.SelectedValue.ToString());
           
            lblTavlingNamn.Text = newcom.namn;
            lblTavlingTyp.Text = newcom.type;
            lblTavlingDesc.Text = newcom.desc;

            lblTavlingDesc.Visible = true;
            lblTavlingNamn.Visible = true;
            lblTavlingTyp.Visible = true;

           
        }

        public Competition GetspecificComp(string compid)
        {
            Competition newcom = new Competition();

            string sql = "SELECT * FROM tavling where id = @id";

            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", compid);
            conn.Open();

            NpgsqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                newcom.id = dr["id"].ToString();
                newcom.namn = dr["namn"].ToString();
                newcom.starttid = dr["starttid"].ToString();
                newcom.sluttid = dr["sluttid"].ToString();
                newcom.desc = dr["description"].ToString();
                newcom.type = dr["type"].ToString();
            }

            conn.Close();

            return newcom;
        }
    }
}