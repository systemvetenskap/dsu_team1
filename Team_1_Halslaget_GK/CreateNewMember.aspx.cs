using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Globalization;

namespace Team_1_Halslaget_GK
{
	public partial class CreateNewMember : System.Web.UI.Page
	{
        
        medlem MedlemObj;

		protected void Page_Load(object sender, EventArgs e)
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
        /// Initilizes the GUI with standard values.
        /// </summary>
        private void InitilizeGUI()
        {
            MedlemObj = new medlem();
            BindDropDown();
        }

        /// <summary>
        /// Binds the dropdownlist with values from database.
        /// </summary>
        private void BindDropDown()
        {            
            DataTable memberTypes = MedlemObj.GetMemberTypes();

            dropDownMemberType.DataSource = memberTypes;
            dropDownMemberType.DataTextField = "namntyp";
            dropDownMemberType.DataBind();
            this.dropDownMemberType.Items.Insert(0, "Välj");
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

        /// <summary>
        /// Event for btnAddMember
        /// </summary>
        protected void btnAddMember_Click(object sender, EventArgs e)
        {
            MedlemObj = new medlem();

            MedlemObj.fornamn = txtFistName.Text;
            MedlemObj.efternamn = txtLastName.Text;
            MedlemObj.handikapp = Convert.ToDouble(txtHcp.Text);
            MedlemObj.telefonNummer = txtPhone.Text;
            MedlemObj.epost = txtEmail.Text;
            MedlemObj.adress = txtAddress.Text;
            MedlemObj.postnummer = txtPostalCode.Text;
            MedlemObj.ort = txtCity.Text;
            MedlemObj.kon = dropDownListKon.Text;
            MedlemObj.medlemsKategori = dropDownMemberType.Text;
            MedlemObj.payStatus = SetPayStatus();
            MedlemObj.password = HashSHA1("arne123").ToString();

            if(MedlemObj.InsertNewMember())
            {
                lblSavedConfirm.Text = "T";
                lblConfirmed.Text = "Medlem skapad.";
                SetGUIBoxesStdValue();
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "openConfirmMessage", "openConfirmMessage();", true);
            }
            else
            {
                lblSavedConfirm.Text = "F";
                lblConfirmed.ForeColor = System.Drawing.Color.Red;
                lblConfirmed.Text = "Medlem skapades inte. Något gick fel.";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "openConfirmMessage", "openConfirmMessage();", true);
            }
        }

        private void SetGUIBoxesStdValue()
        {
            txtFistName.Text = "";
            txtLastName.Text = "";
            txtHcp.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtPostalCode.Text = "";
            txtCity.Text = "";

            dropDownListKon.SelectedIndex = 0;
            dropDownPayStatus.SelectedIndex = 0;
            BindDropDown();
        }

        private bool SetPayStatus()
        {
            string choice = dropDownPayStatus.Text;
            if(choice == "Ja")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

	}
}