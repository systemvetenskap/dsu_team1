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
    public partial class WebForm1 : System.Web.UI.Page
    {

        List<medlem> medlemmar = new List<medlem>();

        protected void Page_Load(object sender, EventArgs e) //Fyller i listboxen med alla medlemmar vid start
        {
            if(!IsPostBack)
            {
                HamtaMedlemmar();
            }
        }

        private void HamtaMedlemmar()
        {
            NpgsqlConnection con = new NpgsqlConnection("Server=webblabb.miun.se; Port=5432; Database=dsu_golf; User Id=dsu_g1; Password=dsu_g1; SslMode=Require");
            string sql = "SELECT id, fornamn, efternamn, hcp FROM medlem";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);


            con.Open();

            NpgsqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                medlem nymedlem = new medlem();
                nymedlem.ID = Convert.ToInt32(dr["id"]);
                nymedlem.fornamn = Convert.ToString(dr["fornamn"]);
                nymedlem.efternamn = Convert.ToString(dr["efternamn"]);
                nymedlem.handikapp = Convert.ToDouble(dr["hcp"]);

                medlemmar.Add(nymedlem);
            }

            con.Close();
            con.Dispose();

            ListBoxMedlemsregister.DataSource = medlemmar;
            ListBoxMedlemsregister.DataBind();
        }

        protected void RadioButtonListSortera_OnSelectedIndexChanged(object sender, EventArgs e) //Byter ordning på de listade medlemmarna när man klickar på en radiobutton
        {
            if (TextBoxEfternamnSok.Text != "" || TextBoxFornamnSok.Text != "")
            {
                Search();
            }

            else
            {
                HamtaMedlemmar();
            }

            if (RadioButtonListSortera.Text == "ID")
            {
                medlemmar.Sort((x1, x2) => x1.ID.CompareTo(x2.ID));

                RensaOchBindListbox();
            }

            if (RadioButtonListSortera.Text == "Förnamn")
            {
                medlemmar.Sort((x, y) => string.Compare(x.fornamn, y.fornamn));

                RensaOchBindListbox();

            }

            if (RadioButtonListSortera.Text == "Efternamn")
            {
                medlemmar.Sort((x, y) => string.Compare(x.efternamn, y.efternamn));

                RensaOchBindListbox();

            }

            if (RadioButtonListSortera.Text == "Handikapp")
            {
                medlemmar.Sort((x1, x2) => x1.handikapp.CompareTo(x2.handikapp));

                RensaOchBindListbox();

            }
            
        }

        protected void ButtonVisaMedlemInfo_Click (object sender, EventArgs e) //Hittar den markerade medlemmen när visa medlem klickas
        {   
            if (ListBoxMedlemsregister.SelectedIndex == -1)
            {

            }

            else
            {                      
                int s;
                string idstring = null;
                string text = ListBoxMedlemsregister.SelectedItem.Text;

                foreach (char c in text)
                {
                    bool siffra = Int32.TryParse(c.ToString(), out s);
                    if (siffra)
                    {
                        idstring += s.ToString();
                    }

                    else
                    {
                        break;
                    }
                }

                int id = Convert.ToInt32(idstring);

                VisaMedlem(id);
            }
        }

        protected void VisaMedlem(int id) //Visar medlemsinfo
        {

            //Kommenterade ut lite saker för att visa nya funktionene med listbox.selectedindexchanged. Går självkalrt att ändra tillbaka.

            //ListBoxMedlemsregister.Visible = false;
            //RadioButtonListSortera.Visible = false;
            //ButtonVisaMedlemInfo.Visible = false;
            //ButtonRedigera.Visible = true;
            //ButtonTillbaka.Visible = true;            

            string sql = "SELECT fornamn, efternamn, adress, postnummer, ort, epost, hcp, medlemskategori FROM medlem WHERE id = " + id;
            NpgsqlConnection con = new NpgsqlConnection("Server=webblabb.miun.se; Port=5432; Database=dsu_golf; User Id=dsu_g1; Password=dsu_g1; SslMode=Require");
            DataTable dt = new DataTable();

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con);

            con.Open();
            da.Fill(dt);
            con.Close();
            con.Dispose();

            //TextBoxID.Visible = true;
            //TextBoxFornamn.Visible = true;
            //TextBoxEfternamn.Visible = true;
            //TextBoxAdress.Visible = true;
            //TextBoxPostnummer.Visible = true;
            //TextBoxOrt.Visible = true;
            //TextBoxEmail.Visible = true;
            //TextBoxHandikapp.Visible = true;

            TextBoxID.Text = id.ToString();
            TextBoxFornamn.Text = dt.Rows[0][0].ToString();
            TextBoxEfternamn.Text = dt.Rows[0][1].ToString();
            TextBoxAdress.Text = dt.Rows[0][2].ToString();
            TextBoxPostnummer.Text = dt.Rows[0][3].ToString();
            TextBoxOrt.Text = dt.Rows[0][4].ToString();
            TextBoxEmail.Text = dt.Rows[0][5].ToString();
            TextBoxHandikapp.Text = dt.Rows[0][6].ToString();

            //TextBoxID.ReadOnly = true;
            //TextBoxFornamn.ReadOnly = true;
            //TextBoxEfternamn.ReadOnly = true;
            //TextBoxAdress.ReadOnly = true;
            //TextBoxPostnummer.ReadOnly = true;
            //TextBoxOrt.ReadOnly = true;
            //TextBoxEmail.ReadOnly = true;
            //TextBoxHandikapp.ReadOnly = true;
        }

        protected void ButtonRedigera_Click (object sender, EventArgs e)
        {
            TextBoxID.ReadOnly = true;
            TextBoxFornamn.ReadOnly = false;
            TextBoxEfternamn.ReadOnly = false;
            TextBoxAdress.ReadOnly = false;
            TextBoxPostnummer.ReadOnly = false;
            TextBoxOrt.ReadOnly = false;
            TextBoxEmail.ReadOnly = false;
            TextBoxHandikapp.ReadOnly = false;

            ButtonSpara.Visible = true;
            ButtonRadera.Visible = true;
            ButtonRedigera.Visible = false;
        }

        protected void ButtonSpara_Click (object sender, EventArgs e)
        {
            string sql = "UPDATE medlem SET fornamn = @fornamn, efternamn = @efternamn, adress = @adress, postnummer = @postnummer, ort = @ort, epost = @epost, hcp = @handikapp WHERE id = " + Convert.ToInt32(TextBoxID.Text);
            NpgsqlConnection con = new NpgsqlConnection("Server=webblabb.miun.se; Port=5432; Database=dsu_golf; User Id=dsu_g1; Password=dsu_g1; SslMode=Require");

            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@fornamn", TextBoxFornamn.Text);
            cmd.Parameters.AddWithValue("@efternamn", TextBoxEfternamn.Text);
            cmd.Parameters.AddWithValue("@adress", TextBoxAdress.Text);
            cmd.Parameters.AddWithValue("@postnummer", TextBoxPostnummer.Text);
            cmd.Parameters.AddWithValue("@ort", TextBoxOrt.Text);
            cmd.Parameters.AddWithValue("@epost", TextBoxEmail.Text);
            cmd.Parameters.AddWithValue("@handikapp", TextBoxHandikapp.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
        }

        protected void ButtonRadera_Click (object sender, EventArgs e)
        {
            string sql = "DELETE FROM medlem WHERE id = " + Convert.ToInt32(TextBoxID.Text);
            NpgsqlConnection con = new NpgsqlConnection("Server=webblabb.miun.se; Port=5432; Database=dsu_golf; User Id=dsu_g1; Password=dsu_g1; SslMode=Require");

            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
        }

        private void RensaOchBindListbox()
        {
            ListBoxMedlemsregister.Items.Clear();
            ListBoxMedlemsregister.DataSource = null;
            ListBoxMedlemsregister.DataBind();
            ListBoxMedlemsregister.DataSource = medlemmar;
            ListBoxMedlemsregister.DataBind();
        }

        protected void ButtonSearch_Click (object sender, EventArgs e)
        {
            if (TextBoxFornamnSok.Text == "" && TextBoxEfternamnSok.Text == "")
            {

            }

            else
            {
                Search();
            }
        }

        private string StorBokstavFnamn()
        {
            string fnamn = TextBoxFornamnSok.Text;
            string fnamnny = "";

            if (fnamnny.Length > 1)
            {
                foreach (char c in fnamn)
                {
                    char.ToLower(c);
                    fnamnny += c;
                }

                return char.ToUpper(fnamnny[0]) + fnamnny.Substring(1);
            }

            return fnamnny.ToUpper();  
        }

        private string StorBokstavEnamn()
        {
            string enamn = TextBoxEfternamnSok.Text;
            string enamnny = "";

            if (enamnny.Length > 1)
            {
                foreach (char c in enamn)
                {
                    char.ToLower(c);
                    enamnny += c;
                }

                return char.ToUpper(enamnny[0]) + enamnny.Substring(1);
            }

            return enamnny.ToUpper();
        }

        private void Search()
        {
            string sql;
            medlemmar.Clear();


                if (TextBoxEfternamnSok.Text == "")
                {
                    sql = "SELECT id, fornamn, efternamn, hcp FROM medlem WHERE fornamn LIKE '" + StorBokstavFnamn() + "%' ORDER BY fornamn";
                }

                else if (TextBoxFornamnSok.Text == "")
                {
                    sql = "SELECT id, fornamn, efternamn, hcp FROM medlem WHERE efternamn LIKE '" + StorBokstavEnamn() + "%' ORDER BY efternamn";
                }

                else
                {
                    sql = "SELECT id, fornamn, efternamn, hcp FROM medlem WHERE fornamn LIKE '" + StorBokstavFnamn() + "%' AND efternamn LIKE '" + StorBokstavEnamn() + "%' ORDER BY efternamn";
                }

                NpgsqlConnection con = new NpgsqlConnection("Server=webblabb.miun.se; Port=5432; Database=dsu_golf; User Id=dsu_g1; Password=dsu_g1; SslMode=Require");

                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

                con.Open();
                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    medlem nymedlem = new medlem();
                    nymedlem.ID = Convert.ToInt32(dr["id"]);
                    nymedlem.fornamn = Convert.ToString(dr["fornamn"]);
                    nymedlem.efternamn = Convert.ToString(dr["efternamn"]);
                    nymedlem.handikapp = Convert.ToDouble(dr["hcp"]);

                    medlemmar.Add(nymedlem);
                }

                con.Close();
                con.Dispose();

                RensaOchBindListbox();
            
        }


        /// <summary>
        /// La till detta eventet. Tänkte att det kanske blir lättare för användaren
        /// om hen bara behöver klicka på den personen som hen vill åt i listboxen istället för att först
        /// välja och sedan trycka på knapp? 
        /// </summary>
        protected void ListBoxMedlemsregister_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBoxMedlemsregister.SelectedIndex == -1)
            {

            }

            else
            {
                int s;
                string idstring = null;
                string text = ListBoxMedlemsregister.SelectedItem.Text;

                foreach (char c in text)
                {
                    bool siffra = Int32.TryParse(c.ToString(), out s);
                    if (siffra)
                    {
                        idstring += s.ToString();
                    }

                    else
                    {
                        break;
                    }
                }

                int id = Convert.ToInt32(idstring);

                VisaMedlem(id);
            }
        }
    }
}