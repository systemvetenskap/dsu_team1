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
    public partial class PublishNewsAdmin : System.Web.UI.Page
    {
        NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null && Session["admin"] == null)
            {
                Response.Redirect("~/NotAllowed.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
                    
            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO nyhet (publ_date, txt) VALUES (@publ_date, @txt)", conn);
                cmd.Parameters.AddWithValue("@txt", txtHTMLContent.Text);
                cmd.Parameters.AddWithValue("@publ_date", now);
                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}