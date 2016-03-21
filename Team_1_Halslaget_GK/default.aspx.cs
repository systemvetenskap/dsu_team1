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
    public partial class deafult : System.Web.UI.Page
    {
        NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

        Competition newcomp = new Competition();

        protected void Page_Load(object sender, EventArgs e)
        {
                
                LoadNews();
                

                gvComp.DataSource = newcomp.GetAllUpcomingCompetitions();
                gvComp.DataBind();

            if(gvComp.Rows.Count > 0)
            {
                lblcomp.Text = "Om du vill anmäla dig till en tävling kan du logga in eller kontakta receptionen.";
            }
            else
            {
                lblcomp.Text = "Just nu finns det inga kommande tävlingar.";
            }

        }      
        //Visar banans status
        private void SetTableBanstatus(DataTable dt)
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
        //Laddar in de tre senaste publicera nyheterna och lägger till dem på startsidan
        private void LoadNews()
        {
            List<news> newsList = new List<news>();
            string sql = "SELECT * FROM nyhet ORDER BY id DESC LIMIT 3;";

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

            string News = "fullBox newsBox";

            foreach (news news in newsList.OfType<news>())
            {
                System.Web.UI.HtmlControls.HtmlGenericControl newsdiv2 = new System.Web.UI.HtmlControls.HtmlGenericControl();

                newsdiv2.InnerHtml = news.publDate + news.txt;
                newsdiv2.Attributes["class"] = News;    
                newsdiv.Controls.Add(newsdiv2);
            }                             
        }
        //Laddar in de medlemstyper som finns i databasen så att man kan välja medlemstyp när man ansöker om medlemskap från startsidan
        private void LoadMedlemstyper()
        {
            medlem nymedlem = new medlem();

            DataTable medlemstyper = nymedlem.GetMemberTypes();

            dropDownMembertype.DataSource = medlemstyper;
            dropDownMembertype.DataTextField = "namntyp";
            dropDownMembertype.DataBind();
            dropDownMembertype.Items.Insert(0, "Välj medlemstyp");
        }
        //Loggar in
        protected void signInBtn_Click(object sender, EventArgs e)
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

            cmd.Parameters.AddWithValue("@epost", TextBoxEmailLogin.Text);

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
                ClientScript.RegisterStartupScript(GetType(), "hwa", "Openoverlay();", true);

            }

            conn.Close();
            conn.Dispose();

            medlem member = new medlem();
            if (password == HashSHA1(TextBoxPwLogin.Text + guid) && admin == false)
            {
                Session["admin"] = admin.ToString();
                Session["hcp"] = hcp.ToString();
                Session["Username"] = id.ToString();
                Session["GolfID"] = golfid;
                Session["login"] = DateTime.Now;
                member.SetLatestLogin(id.ToString());
                Response.Redirect("~/MyPage.aspx");
            }

            else if (password == HashSHA1(TextBoxPwLogin.Text + guid) && admin == true)
            {
                Session["admin"] = admin.ToString();
                Session["hcp"] = hcp.ToString();
                Session["Username"] = id.ToString();
                Session["login"] = DateTime.Now;    
                member.SetLatestLogin(id.ToString());
                Response.Redirect("~/AdminPanel.aspx");
            }

            else 
            {
                LabelWrongPW.Text = "Felaktig email eller lösenord.";
                LabelWrongPW.Visible = true;
                LabelWrongPW.ForeColor = System.Drawing.Color.Red;
                ClientScript.RegisterStartupScript(GetType(), "hwa", "Openoverlay();", true);
            }
        }
        //Skickar in en medlemsansökan
        protected void Button2_Click(object sender, EventArgs e)
        {
            medlem MedlemObj = new medlem();

            MedlemObj.fornamn = tbName.Text;
            MedlemObj.efternamn = tbLastname.Text;
            MedlemObj.handikapp = Convert.ToDouble(tbhcp.Text);
            MedlemObj.telefonNummer = tbPonenumber.Text;
            MedlemObj.epost = tbEmail.Text;
            MedlemObj.adress = tbAdress.Text;
            MedlemObj.postnummer = tbZipcode.Text;
            MedlemObj.ort = tbCity.Text;
            MedlemObj.kon = DdlKon.Text;
            MedlemObj.medlemsKategori = dropDownMembertype.Text;
            MedlemObj.payStatus = false;

            MedlemObj.InsertNewMember();

            tbName.Text = "";
            tbLastname.Text = "";
        }
        //Funktioner

    }
}