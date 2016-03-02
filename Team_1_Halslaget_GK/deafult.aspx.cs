using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using System.Web.Configuration;

namespace Team_1_Halslaget_GK
{
    public partial class deafult : System.Web.UI.Page
    {
        NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadNews();
        }

        //Används för att kryptera lösenord
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

        private void LoadNews()
        {
            List<news> newsList = new List<news>();
            string sql = "SELECT txt, publ_date FROM nyhet";

            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

            conn.Open();

            NpgsqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                news news = new news();
                news.publDate = Convert.ToDateTime(dr["publ_date"]);
                news.txt = Convert.ToString(dr["txt"]);
                newsList.Add(news);
                              
            }

            conn.Close();

            int count = 1;

            string firstNews = "fullBox newsBox";
            string NotfirstNews = "fullBox newsBox NotfirstNews article";

            foreach (news news in newsList.OfType<news>().Reverse())
            {
                System.Web.UI.HtmlControls.HtmlGenericControl newsdiv2 = new System.Web.UI.HtmlControls.HtmlGenericControl();
                newsdiv2.InnerHtml = news.publDate + news.txt ;

                if (count == 1)
                {
                    newsdiv2.Attributes["class"] = firstNews;  
                }
                else
                {
                    newsdiv2.Attributes["class"] = NotfirstNews;
                }
                count++;    
                newsdiv.Controls.Add(newsdiv2);
            }
            
            
            
        }

        private void LoadMedlemstyper()
        {

        }

        protected void signInBtn_Click(object sender, EventArgs e)
        {   
            string password = "";
            int id = -1;
            string guid = "";
            bool admin = false;

            string sql = "SELECT id, pw, guid, admin FROM medlem WHERE epost = '" + TextBoxEmailLogin.Text + "'";

            
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

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
                }

                Session["Username"] = id.ToString();
            }

            else
            {
                //Ruta.visa(Fel lösenord eller email);
            }

            conn.Close();
            conn.Dispose();

            if (password == HashSHA1(TextBoxPwLogin.Text + guid) && admin == false)
            {
                Response.Redirect("~/MyPage.aspx");                
            }

            else if (password == HashSHA1(TextBoxPwLogin.Text + guid) && admin == true)
            {
                Response.Redirect("~/AdminPanel.aspx");
            }

            else 
            {
                //Ruta.Visa(Fel lösenord eller email);
            }


        }
    }
}