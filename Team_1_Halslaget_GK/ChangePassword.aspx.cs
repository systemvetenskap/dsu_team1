using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team_1_Halslaget_GK
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var tuple = GetPassword();
            string testa = tuple.Item1 + tuple.Item2;
            
            if (txtNewPasswordOne.Text != txtNewPasswordTwo.Text)
            {
                PwResultText.InnerText = "Det två lösenorden matchar inte";
                ClientScript.RegisterStartupScript(GetType(), "hwa", "openOverlayPasswordChange();", true);
            }

            else if (HashSHA1(txtOldPassword.Text + tuple.Item2) == tuple.Item1)
            {
                SetNewPassword(tuple.Item2);
                PwResultText.InnerText = "Ditt lösenord har ändrats";
                ClientScript.RegisterStartupScript(GetType(), "hwa", "openOverlayPasswordChange();", true);
            }

            else
            {
                PwResultText.InnerText = "Du har angivit fel lösenord";
                ClientScript.RegisterStartupScript(GetType(), "hwa", "openOverlayPasswordChange();", true);

            }
        }

        protected Tuple<string, string> GetPassword()
        {
            string password = "";
            string guid = "";

            string sql = "SELECT pw, guid FROM medlem WHERE id = @id";

            NpgsqlConnection con = new NpgsqlConnection("Server=webblabb.miun.se; Port=5432; Database=dsu_golf; User Id=dsu_g1; Password=dsu_g1; SslMode=Require");

            DataTable dt = new DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con); //gjorde denna med datareader först men hur jag än gjorde så fick jag inga värden, bytte till da och funkade klockrent

            //Session["Username"].ToString() ska in här nedan ist för 2
            da.SelectCommand.Parameters.AddWithValue("@id", 2);

            try
            {
                con.Open();

                da.Fill(dt);
                int i = dt.Rows.Count;
                password = dt.Rows[0][0].ToString();
                guid = dt.Rows[0][1].ToString();
             }

             catch
             {
                 NpgsqlException ex;
             }

             finally    
             {
                con.Close();
                con.Dispose();
             }
            return Tuple.Create(password, guid);           
        }

        protected void SetNewPassword(string guid)
        {
            string sql = "UPDATE medlem SET pw = @pw WHERE id = @id"; 

            NpgsqlConnection con = new NpgsqlConnection("Server=webblabb.miun.se; Port=5432; Database=dsu_golf; User Id=dsu_g1; Password=dsu_g1; SslMode=Require");
            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@pw", HashSHA1(txtNewPasswordOne.Text + guid));
            cmd.Parameters.AddWithValue("@id", 2); //Session["Username"].ToString()

            try 
            {
                con.Open();
                cmd.ExecuteNonQuery();
                //Visa ruta att bytet lyckats
            }

            catch
            {
                NpgsqlException ex;
            }

            finally
            {
                con.Close();
                con.Dispose();                
            }
        }

        protected static string HashSHA1(string value)
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
    }
}