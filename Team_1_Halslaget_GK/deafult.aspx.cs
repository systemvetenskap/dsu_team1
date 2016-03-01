using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;

namespace Team_1_Halslaget_GK
{
    public partial class deafult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

        protected void signInBtn_Click(object sender, EventArgs e)
        {   
            string password = "";
            int id;
            string guid = "";

            string sql = "SELECT id, pw, guid FROM medlem WHERE epost = '" + TextBoxEmailLogin.Text + "'";

            NpgsqlConnection con = new NpgsqlConnection("Server=webblabb.miun.se; Port=5432; Database=dsu_golf; User Id=dsu_g1; Password=dsu_g1; SslMode=Require");
            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

            con.Open();

            NpgsqlDataReader dr = cmd.ExecuteReader();
            
            if (dr.HasRows)
            {

                while (dr.Read())
                {
                    id = Convert.ToInt32(dr[0]);
                    password = dr[1].ToString();
                    guid = dr[2].ToString();
                }                
            }

            else
            {
                //Ruta.visa(Fel lösenord eller email);
            }

            con.Close();
            con.Dispose();

            if (password == HashSHA1(TextBoxPwLogin.Text + guid))
            {
                //GÖr saker
            }

            else 
            {
                //Ruta.Visa(Fel lösenord eller email);
            }


        }
    }
}