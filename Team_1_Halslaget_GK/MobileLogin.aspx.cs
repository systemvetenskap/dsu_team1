using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using System.Web.Configuration;
using System.Data;

namespace Team_1_Halslaget_GK
{
    public partial class MobileLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelWrongPW.Text = "";
        }
        private static string HashSHA1(string value)
        {
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var inputBytes = Encoding.ASCII.GetBytes(value);
            var hash = sha1.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        protected void loginButton_Click(object sender, EventArgs e)
        {
            string password = "";
            int id = -1;
            string guid = "";
            bool admin = false;
            string hcp = "";
            string golfid = "";

            string sql = "SELECT id, pw, guid, admin, hcp, golfid FROM medlem WHERE epost = @epost";


            NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se; Port=5432; Database=dsu_golf; User Id=dsu_g1; Password=dsu_g1; SslMode=Require");
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@epost", userNameInput.Text);

            conn.Open();

            NpgsqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {

                while (dr.Read())
                {
                    id = Convert.ToInt32(dr[0]);
                    password = dr[1].ToString();
                    guid = dr[2].ToString();
                    admin = Convert.ToBoolean(dr[3]);
                    hcp = dr[4].ToString();
                    golfid = dr[5].ToString();
                }
            }

            else
            {
                LabelWrongPW.Text = "Felaktig email eller lösenord.";
                LabelWrongPW.Visible = true;
                LabelWrongPW.ForeColor = System.Drawing.Color.Red;

            }

            conn.Close();
            conn.Dispose();

            if (password == HashSHA1(passWordInput.Text + guid))
            {
                Session["admin"] = admin.ToString();
                Session["hcp"] = hcp.ToString();
                Session["Username"] = id.ToString();
                Session["GolfID"] = golfid;
                Response.Redirect("~/MobileIndex.aspx");
            }

            else
            {
                LabelWrongPW.Text = "Felaktig email eller lösenord.";
                LabelWrongPW.Visible = true;
                LabelWrongPW.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}