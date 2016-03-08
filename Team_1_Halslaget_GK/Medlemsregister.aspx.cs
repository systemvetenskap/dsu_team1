using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Npgsql;
using System.Security.Cryptography;
using System.Text;
using System.Globalization;


namespace Team_1_Halslaget_GK
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        List<medlem> medlemmar = new List<medlem>();

        protected void Page_Load(object sender, EventArgs e) //Fyller i listboxen med alla medlemmar vid start
        {
            if (Session["Username"] == null && Session["admin"] == null)
            {
                Response.Redirect("~/NotAllowed.aspx");
            }
            if(!IsPostBack)
            {
                InitilizeGUI();
            }
        }


        /// <summary>
        /// Initiilizes the gui with standard values.
        /// </summary>
        private void InitilizeGUI()
        {
            BindListBoxWithMembers();
            ClearAllTxtBoxes();
        }

        /// <summary>
        /// Binds the listbox with members using medlem class.
        /// </summary>
        private void BindListBoxWithMembers()
        {
            medlem fillMemberList = new medlem();

            medlemmar = fillMemberList.GetAllMembers();

            ListBoxMedlemsregister.DataSource = medlemmar;
            ListBoxMedlemsregister.DataBind();
        }

        /// <summary>
        /// Sorts the listbox depending on what the user chooses.
        /// </summary>
        protected void RadioButtonListSortera_OnSelectedIndexChanged(object sender, EventArgs e) //Byter ordning på de listade medlemmarna när man klickar på en radiobutton
        {
            if (TextBoxEfternamnSok.Text != "" || TextBoxFornamnSok.Text != "")
            {
                Search();
            }

            else
            {
                BindListBoxWithMembers();
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

        /// <summary>
        /// Collects a value from the database from another method and sets the current paystatus on a member.
        /// </summary>
        private string SetIntitialPayStatus(DateTime payDate)
        {
            string paystatus = "Ja";
            DateTime oneYearAgo = DateTime.Now.AddYears(-1);
            if(payDate > oneYearAgo)
            {
                paystatus = "Nej";
                return paystatus;
            }
            else
            {
                paystatus = "Ja";
                return paystatus;
            }
        }

        /// <summary>
        /// Sets a new paystatus, true or false depending on whats been choosen from the dropdown.
        /// </summary>
        /// <returns></returns>
        private bool SetPayStatus()
        {
            string choice = dropDownPayStatus.Text;
            if (choice == "Ja")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Clears all the labels and textboxes of values.
        /// </summary>
        private void ClearAllTxtBoxes()
        {
            lblMedlemsID.Text = "";
            TextBoxFornamn.Text = "";
            TextBoxEfternamn.Text = "";
            TextBoxEmail.Text = "";
            TextBoxHandikapp.Text = "";
            TextBoxOrt.Text = "";
            TextBoxPostnummer.Text = "";
            TextBoxTelefonNummer.Text = "";
            TextBoxAdress.Text = "";
        }

        /// <summary>
        /// When user selects a member from the listbox this is the method that gets selected member from
        /// database and presents it in the textboxes. 
        /// </summary>
        /// <param name="id"></param>
        private void VisaMedlem(int id) //Visar medlemsinfo
        {
            medlem showMember = new medlem();
            showMember.ID = id;
            DataTable memberTable = showMember.GetSpecificMember();

            lblMedlemsID.Text = memberTable.Rows[0]["id"].ToString();
            TextBoxFornamn.Text = memberTable.Rows[0]["fornamn"].ToString();
            TextBoxEfternamn.Text = memberTable.Rows[0]["efternamn"].ToString();
            TextBoxAdress.Text = memberTable.Rows[0]["adress"].ToString();
            TextBoxPostnummer.Text = memberTable.Rows[0]["postnummer"].ToString();
            TextBoxOrt.Text = memberTable.Rows[0]["ort"].ToString();
            TextBoxEmail.Text = memberTable.Rows[0]["epost"].ToString();
            TextBoxHandikapp.Text = memberTable.Rows[0]["hcp"].ToString();
            TextBoxTelefonNummer.Text = memberTable.Rows[0]["telefonnummer"].ToString();
            
            DateTime payDate = DateTime.Parse(memberTable.Rows[0]["medlemsavgift_betald"].ToString());

            dropDownPayStatus.SelectedValue = SetIntitialPayStatus(payDate);

        }

        /// <summary>
        /// Event for when user clicks button to save member info.
        /// </summary>
        protected void ButtonSpara_Click (object sender, EventArgs e)
        {
            medlem saveMember = new medlem();
            saveMember.ID = Convert.ToInt32(lblMedlemsID.Text);
            saveMember.fornamn = TextBoxFornamn.Text;
            saveMember.efternamn = TextBoxEfternamn.Text;
            saveMember.adress = TextBoxAdress.Text;
            saveMember.postnummer = TextBoxPostnummer.Text;
            saveMember.ort = TextBoxOrt.Text;
            saveMember.epost = TextBoxEmail.Text;
            saveMember.handikapp = Convert.ToDouble(TextBoxHandikapp.Text);
            saveMember.telefonNummer = TextBoxTelefonNummer.Text;
            saveMember.payStatus = SetPayStatus();
            
            if (saveMember.AdminUpdateMemberInfo())
            {
                lblSavedConfirmed.Text = "T";
                lblConfirmed.Text = "Uppgifterna sparades.";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "openConfirmMessage", "openConfirmMessage();", true);
                ClearAllTxtBoxes();
            }
            else
            {
                lblSavedConfirmed.Text = "F";
                lblConfirmed.Text = "Uppgifterna sparades inte. Något gick fel.";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "openConfirmMessage", "openConfirmMessage();", true);
            }
        }

        protected void ButtonRadera_Click (object sender, EventArgs e)
        {
            //string sql = "DELETE FROM medlem WHERE id = " + Convert.ToInt32(lblMedlemsID.Text);
            //NpgsqlConnection con = new NpgsqlConnection("Server=webblabb.miun.se; Port=5432; Database=dsu_golf; User Id=dsu_g1; Password=dsu_g1; SslMode=Require");

            //NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();
            //con.Dispose();

            medlem deleteMember = new medlem();
            deleteMember.ID = Convert.ToInt32(lblMedlemsID.Text);
            deleteMember.DeleteMember();

            InitilizeGUI();
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
            string fnamnSok = TextBoxFornamnSok.Text;
            string fnamnLower = fnamnSok.ToLower();
            char[] fnamnCharArray = fnamnLower.ToCharArray();
            fnamnCharArray[0] = char.ToUpper(fnamnCharArray[0]);
            return new string(fnamnCharArray);
        }

        private string StorBokstavEnamn()
        {
            string enamnSok = TextBoxEfternamnSok.Text;
            string enamnLower = enamnSok.ToLower();
            char[] enamnCharArray = enamnLower.ToCharArray();
            enamnCharArray[0] = char.ToUpper(enamnCharArray[0]);
            return new string(enamnCharArray);
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
                if(dr.HasRows)
                {
                while (dr.Read())
                {
                    medlem nymedlem = new medlem();
                    nymedlem.ID = Convert.ToInt32(dr["id"]);
                    nymedlem.fornamn = Convert.ToString(dr["fornamn"]);
                    nymedlem.efternamn = Convert.ToString(dr["efternamn"]);
                    nymedlem.handikapp = Convert.ToDouble(dr["hcp"]);

                    medlemmar.Add(nymedlem);
                        RensaOchBindListbox();
                    }
                }
                else
                {
                    ListBoxMedlemsregister.Items.Clear();
                    ListBoxMedlemsregister.Items.Add("Kunde inte hitta namnet du sökte på, pröva igen.");
                }


                con.Close();
                con.Dispose();            
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