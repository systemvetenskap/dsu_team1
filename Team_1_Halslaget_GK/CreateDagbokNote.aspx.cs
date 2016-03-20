using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml.Serialization;
using System.Drawing;
using System.IO;

namespace Team_1_Halslaget_GK
{
    public partial class CreateDagbokNote : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("~/NotAllowed.aspx");
            }

            if(!IsPostBack)
            {
                InitilizeGUI();
            }
        }

        /// <summary>
        /// Set standard values to the GUI
        /// </summary>
        private void InitilizeGUI()
        {
            LockTextBoxes();
            BindDropDownTee();
            lblhcp.Text = GetMemberHcp();
        }

        /// <summary>
        /// Updates Gui with new and relevant values.
        /// </summary>
        private void UpdateGUI()
        {
            LockTextBoxes();
            dropDownTee.SelectedIndex = 0;
            dropDownTee.Enabled = false;
            txtTitle.Text = "";
            txtHTMLContent.Text = "";
            checkBoxScoreCard.Checked = false;
        }

        /// <summary>
        /// Gets the logged in members hcp.
        /// </summary>
        /// <returns></returns>
        private string GetMemberHcp()
        {
            string user = Session["Username"].ToString();
            medlem medlemHcp = new medlem();
            medlemHcp.ID = Convert.ToInt32(user);
            DataTable memberInfo = medlemHcp.GetSpecificMember();

            string hcp = memberInfo.Rows[0]["hcp"].ToString();

            return hcp;
        }

        /// <summary>
        /// Binds dropdown with values from database.
        /// </summary>
        private void BindDropDownTee()
        {
            Tee getTee = new Tee();
            DataTable allTees = getTee.GetAllTees();

            dropDownTee.DataSource = allTees;
            dropDownTee.DataTextField = "name";
            dropDownTee.DataValueField = "id";
            dropDownTee.DataBind();
            this.dropDownTee.Items.Insert(0, "Välj tee");
            dropDownTee.Enabled = false;
            dropDownTee.Style.Add("cursor", "not-allowed");
        }

        /// <summary>
        /// Checks that no textbox is empty.
        /// </summary>
        /// <returns></returns>
        private bool CheckTextBoxes()
        {
            bool ok = false;
            ok = !string.IsNullOrEmpty(TextBox1.Text) &&
                !string.IsNullOrEmpty(TextBox2.Text) &&
                !string.IsNullOrEmpty(TextBox3.Text) &&
                !string.IsNullOrEmpty(TextBox4.Text) &&
                !string.IsNullOrEmpty(TextBox5.Text) &&
                !string.IsNullOrEmpty(TextBox6.Text) &&
                !string.IsNullOrEmpty(TextBox7.Text) &&
                !string.IsNullOrEmpty(TextBox8.Text) &&
                !string.IsNullOrEmpty(TextBox9.Text) &&
                !string.IsNullOrEmpty(TextBox10.Text) &&
                !string.IsNullOrEmpty(TextBox11.Text) &&
                !string.IsNullOrEmpty(TextBox12.Text) &&
                !string.IsNullOrEmpty(TextBox13.Text) &&
                !string.IsNullOrEmpty(TextBox14.Text) &&
                !string.IsNullOrEmpty(TextBox15.Text) &&
                !string.IsNullOrEmpty(TextBox16.Text) && 
                !string.IsNullOrEmpty(TextBox17.Text) && 
                !string.IsNullOrEmpty(TextBox18.Text);

            return ok;
        }

        /// <summary>
        /// Checks that a value has been selected in the dropdown menu.
        /// </summary>
        /// <returns></returns>
        private bool CheckDropDown()
        {
            bool ok = false;
            if (dropDownTee.Text == "Välj tee" || dropDownTee.SelectedIndex == 0 )
            {
                ok = false;
            }
            else
            {
                ok = true;
            }
            return ok;
        }

        /// <summary>
        /// Adds all the textboxws togheter.
        /// </summary>
        private int calculateTotal()
        {
            int txt1 = Convert.ToInt32(TextBox1.Text);
            int txt2 = Convert.ToInt32(TextBox2.Text);
            int txt3 = Convert.ToInt32(TextBox3.Text);
            int txt4 = Convert.ToInt32(TextBox4.Text);
            int txt5 = Convert.ToInt32(TextBox5.Text);
            int txt6 = Convert.ToInt32(TextBox6.Text);
            int txt7 = Convert.ToInt32(TextBox7.Text);
            int txt8 = Convert.ToInt32(TextBox8.Text);
            int txt9 = Convert.ToInt32(TextBox9.Text);
            int txt10 = Convert.ToInt32(TextBox10.Text);
            int txt11 = Convert.ToInt32(TextBox11.Text);
            int txt12 = Convert.ToInt32(TextBox12.Text);
            int txt13 = Convert.ToInt32(TextBox13.Text);
            int txt14 = Convert.ToInt32(TextBox14.Text);
            int txt15 = Convert.ToInt32(TextBox15.Text);
            int txt16 = Convert.ToInt32(TextBox16.Text);
            int txt17 = Convert.ToInt32(TextBox17.Text);
            int txt18 = Convert.ToInt32(TextBox18.Text);

            int total = txt1 + txt2 + txt3 + txt4 + txt5 + txt6 + txt7 + txt8 + txt9 + txt10 + txt11 + txt12 + txt13 + txt14 + txt15 + txt16 + txt17 + txt18;

            return total;
        }

        /// <summary>
        /// Calculates the score.
        /// </summary>
        private int calculateScore()
        {
            int total = calculateTotal();
            double slope = Convert.ToDouble(lblSlopeValue.Text);
            double courseRating = Convert.ToDouble(lblCourseRating.Text);
            double par = Convert.ToDouble(lblPar.Text);
            double playerActualHcp = Convert.ToDouble(lblhcp.Text);

            double diff = slope / 113;
            double diff2 = courseRating - par;

            double score = playerActualHcp * diff;
            score = score + diff2;

            int theScore = total - Convert.ToInt32(score);

            return theScore;
        }


        /// <summary>
        /// Kopierat jacobs kod.
        /// </summary>
        /// <returns></returns>
        protected List<Hole> FindNOShots()
        {
            List<Hole> round = new List<Hole>();

            Hole h1 = new Hole();
            h1.slag = Convert.ToInt32(TextBox1.Text); // Tänkte loopa här först men de visade sig vara krångligare än planeat.                                                     // Kanske behövs det inte loopas heller egentligen, eller så gör det det. Kör man alltid 18 hål?
            h1.nummer = 1;
            round.Add(h1);

            Hole h2 = new Hole();
            h2.slag = Convert.ToInt32(TextBox2.Text);
            h2.nummer = 2;
            round.Add(h2);

            Hole h3 = new Hole();
            h3.slag = Convert.ToInt32(TextBox3.Text);
            h3.nummer = 3;
            round.Add(h3);

            Hole h4 = new Hole();
            h4.slag = Convert.ToInt32(TextBox4.Text);
            h4.nummer = 4;
            round.Add(h4);

            Hole h5 = new Hole();
            h5.slag = Convert.ToInt32(TextBox5.Text);
            h5.nummer = 5;
            round.Add(h5);

            Hole h6 = new Hole();
            h6.slag = Convert.ToInt32(TextBox6.Text);
            h6.nummer = 6;
            round.Add(h6);

            Hole h7 = new Hole();
            h7.slag = Convert.ToInt32(TextBox7.Text);
            h7.nummer = 7;
            round.Add(h7);

            Hole h8 = new Hole();
            h8.slag = Convert.ToInt32(TextBox8.Text);
            h8.nummer = 8;
            round.Add(h8);

            Hole h9 = new Hole();
            h9.slag = Convert.ToInt32(TextBox9.Text);
            h9.nummer = 9;
            round.Add(h9);

            Hole h10 = new Hole();
            h10.slag = Convert.ToInt32(TextBox10.Text);
            h10.nummer = 10;
            round.Add(h10);

            Hole h11 = new Hole();
            h11.slag = Convert.ToInt32(TextBox11.Text);
            h11.nummer = 11;
            round.Add(h11);

            Hole h12 = new Hole();
            h12.slag = Convert.ToInt32(TextBox12.Text);
            h12.nummer = 12;
            round.Add(h12);

            Hole h13 = new Hole();
            h13.slag = Convert.ToInt32(TextBox13.Text);
            h13.nummer = 13;
            round.Add(h13);

            Hole h14 = new Hole();
            h14.slag = Convert.ToInt32(TextBox14.Text);
            h14.nummer = 14;
            round.Add(h14);

            Hole h15 = new Hole();
            h15.slag = Convert.ToInt32(TextBox15.Text);
            h15.nummer = 15;
            round.Add(h15);

            Hole h16 = new Hole();
            h16.slag = Convert.ToInt32(TextBox16.Text);
            h16.nummer = 16;
            round.Add(h16);

            Hole h17 = new Hole();
            h17.slag = Convert.ToInt32(TextBox17.Text);
            h17.nummer = 17;
            round.Add(h17);

            Hole h18 = new Hole();
            h18.slag = Convert.ToInt32(TextBox18.Text);
            h18.nummer = 18;
            round.Add(h18);

            Hole h19 = new Hole();
            h19.nummer = 19;
            h19.totalSlag = calculateTotal();
            round.Add(h19);
  
            Hole h20 = new Hole();
            h20.nummer = 20;
            h20.score = calculateScore();
            round.Add(h20);

            return round;
        }

        /// <summary>
        /// Kopoierat Jacobx kod.
        /// </summary>
        /// <param name="round"></param>
        /// <returns></returns>
        protected string SerializeRound(List<Hole> round)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Hole>));

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, round);
                return textWriter.ToString();
            }
        }

        /// <summary>
        /// Event for when checkbox is clicked on clientside.
        /// </summary>
        protected void checkBoxScoreCard_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxScoreCard.Checked)
            {
                dropDownTee.Enabled = true;
                dropDownTee.Style.Add("cursor", "pointer");
            }
            else
            {
                dropDownTee.Enabled = false;
                dropDownTee.Style.Add("cursor", "not-allowed");
                LockTextBoxes();
            }
        }

        /// <summary>
        /// Event for when the user changes item in dropdownlist.
        /// </summary>
        protected void dropDownTee_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (dropDownTee.Text != "Välj tee" || dropDownTee.SelectedIndex > 0 )
            {
                Tee specTee = new Tee();
                string id = dropDownTee.SelectedValue;
                DataTable specificTee = specTee.GetSpecificTee(id);

                lblSlopeValue.Text = specificTee.Rows[0]["slopevalue"].ToString();
                lblCourseRating.Text = specificTee.Rows[0]["courserating"].ToString();
                lblPar.Text = specificTee.Rows[0]["par"].ToString();
                OpenTextBoxes();
            }
            else
            {
                lblSlopeValue.Text = "";
                lblCourseRating.Text = "";
                lblPar.Text = "";
                LockTextBoxes();
            }
        }

        /// <summary>
        /// Event for when button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveDiary_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string diaryText = txtHTMLContent.Text;
            DateTime date = DateTime.Now;
            int userID = Convert.ToInt32(Session["Username"].ToString());
            Diary dagbok = new Diary();

            if(checkBoxScoreCard.Checked)
            {
                if(CheckDropDown())
                {
                    if (CheckTextBoxes())
                    {
                        List<Hole> round = FindNOShots();
                        string resultXml = SerializeRound(round);
                        dagbok.InsertDiaryNote(title, diaryText, date, resultXml, userID);
                        UpdateGUI();
                    }
                    else
                    {
                        lblError.Text = "Du verkar ha glömt fylla i något scorekortet.";
                    }
                }
                else
                {
                    lblError.Text = "Du måste välja vilken tee du spelat från eller klicka ur att du vill fylla i scorekortet.";
                }
            }
            else
            {
                dagbok.InsertDiaryNote(title, diaryText, date, userID);
                UpdateGUI();
            }
        }

        /// <summary>
        /// Locks all the textboxes and sets color and cursor.
        /// </summary>
        private void LockTextBoxes()
        {
            TextBox1.ReadOnly = true;
            TextBox1.ToolTip = "Du måste välja en medlem först";
            TextBox1.BackColor = System.Drawing.Color.Gray;
            TextBox1.Style.Add("cursor", "not-allowed");

            TextBox2.ReadOnly = true;
            TextBox2.ToolTip = "Du måste välja en medlem först";
            TextBox2.BackColor = System.Drawing.Color.Gray;
            TextBox2.Style.Add("cursor", "not-allowed");

            TextBox3.ReadOnly = true;
            TextBox3.ToolTip = "Du måste välja en medlem först";
            TextBox3.BackColor = System.Drawing.Color.Gray;
            TextBox3.Style.Add("cursor", "not-allowed");

            TextBox4.ReadOnly = true;
            TextBox4.ToolTip = "Du måste välja en medlem först";
            TextBox4.BackColor = System.Drawing.Color.Gray;
            TextBox4.Style.Add("cursor", "not-allowed");

            TextBox5.ReadOnly = true;
            TextBox5.ToolTip = "Du måste välja en medlem först";
            TextBox5.BackColor = System.Drawing.Color.Gray;
            TextBox5.Style.Add("cursor", "not-allowed");

            TextBox6.ReadOnly = true;
            TextBox6.ToolTip = "Du måste välja en medlem först";
            TextBox6.BackColor = System.Drawing.Color.Gray;
            TextBox6.Style.Add("cursor", "not-allowed");

            TextBox7.ReadOnly = true;
            TextBox7.ToolTip = "Du måste välja en medlem först";
            TextBox7.BackColor = System.Drawing.Color.Gray;
            TextBox7.Style.Add("cursor", "not-allowed");

            TextBox8.ReadOnly = true;
            TextBox8.ToolTip = "Du måste välja en medlem först";
            TextBox8.BackColor = System.Drawing.Color.Gray;
            TextBox8.Style.Add("cursor", "not-allowed");

            TextBox9.ReadOnly = true;
            TextBox9.ToolTip = "Du måste välja en medlem först";
            TextBox9.BackColor = System.Drawing.Color.Gray;
            TextBox9.Style.Add("cursor", "not-allowed");

            TextBox10.ReadOnly = true;
            TextBox10.ToolTip = "Du måste välja en medlem först";
            TextBox10.BackColor = System.Drawing.Color.Gray;
            TextBox10.Style.Add("cursor", "not-allowed");

            TextBox11.ReadOnly = true;
            TextBox11.ToolTip = "Du måste välja en medlem först";
            TextBox11.BackColor = System.Drawing.Color.Gray;
            TextBox11.Style.Add("cursor", "not-allowed");

            TextBox12.ReadOnly = true;
            TextBox12.ToolTip = "Du måste välja en medlem först";
            TextBox12.BackColor = System.Drawing.Color.Gray;
            TextBox12.Style.Add("cursor", "not-allowed");

            TextBox13.ReadOnly = true;
            TextBox13.ToolTip = "Du måste välja en medlem först";
            TextBox13.BackColor = System.Drawing.Color.Gray;
            TextBox13.Style.Add("cursor", "not-allowed");

            TextBox14.ReadOnly = true;
            TextBox14.ToolTip = "Du måste välja en medlem först";
            TextBox14.BackColor = System.Drawing.Color.Gray;
            TextBox14.Style.Add("cursor", "not-allowed");

            TextBox15.ReadOnly = true;
            TextBox15.ToolTip = "Du måste välja en medlem först";
            TextBox15.BackColor = System.Drawing.Color.Gray;
            TextBox15.Style.Add("cursor", "not-allowed");

            TextBox16.ReadOnly = true;
            TextBox16.ToolTip = "Du måste välja en medlem först";
            TextBox16.BackColor = System.Drawing.Color.Gray;
            TextBox16.Style.Add("cursor", "not-allowed");

            TextBox17.ReadOnly = true;
            TextBox17.ToolTip = "Du måste välja en medlem först";
            TextBox17.BackColor = System.Drawing.Color.Gray;
            TextBox17.Style.Add("cursor", "not-allowed");

            TextBox18.ReadOnly = true;
            TextBox18.ToolTip = "Du måste välja en medlem först";
            TextBox18.BackColor = System.Drawing.Color.Gray;
            TextBox18.Style.Add("cursor", "not-allowed");

            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox12.Text = "";
            TextBox13.Text = "";
            TextBox14.Text = "";
            TextBox15.Text = "";
            TextBox16.Text = "";
            TextBox17.Text = "";
            TextBox18.Text = "";
        }

        /// <summary>
        /// Opens all the textboxes and sets cursor and color.
        /// </summary>
        private void OpenTextBoxes()
        {
            TextBox1.ReadOnly = false;
            TextBox2.ReadOnly = false;
            TextBox3.ReadOnly = false;
            TextBox4.ReadOnly = false;
            TextBox5.ReadOnly = false;
            TextBox6.ReadOnly = false;
            TextBox7.ReadOnly = false;
            TextBox8.ReadOnly = false;
            TextBox9.ReadOnly = false;
            TextBox10.ReadOnly = false;
            TextBox11.ReadOnly = false;
            TextBox12.ReadOnly = false;
            TextBox13.ReadOnly = false;
            TextBox14.ReadOnly = false;
            TextBox15.ReadOnly = false;
            TextBox16.ReadOnly = false;
            TextBox17.ReadOnly = false;
            TextBox18.ReadOnly = false;
            TextBox1.BackColor = System.Drawing.Color.White;
            TextBox2.BackColor = System.Drawing.Color.White;
            TextBox3.BackColor = System.Drawing.Color.White;
            TextBox4.BackColor = System.Drawing.Color.White;
            TextBox5.BackColor = System.Drawing.Color.White;
            TextBox6.BackColor = System.Drawing.Color.White;
            TextBox7.BackColor = System.Drawing.Color.White;
            TextBox8.BackColor = System.Drawing.Color.White;
            TextBox9.BackColor = System.Drawing.Color.White;
            TextBox10.BackColor = System.Drawing.Color.White;
            TextBox11.BackColor = System.Drawing.Color.White;
            TextBox12.BackColor = System.Drawing.Color.White;
            TextBox13.BackColor = System.Drawing.Color.White;
            TextBox14.BackColor = System.Drawing.Color.White;
            TextBox15.BackColor = System.Drawing.Color.White;
            TextBox16.BackColor = System.Drawing.Color.White;
            TextBox17.BackColor = System.Drawing.Color.White;
            TextBox18.BackColor = System.Drawing.Color.White;
            TextBox1.Style.Add("cursor", "text");
            TextBox2.Style.Add("cursor", "text");
            TextBox3.Style.Add("cursor", "text");
            TextBox4.Style.Add("cursor", "text");
            TextBox5.Style.Add("cursor", "text");
            TextBox6.Style.Add("cursor", "text");
            TextBox7.Style.Add("cursor", "text");
            TextBox8.Style.Add("cursor", "text");
            TextBox9.Style.Add("cursor", "text");
            TextBox10.Style.Add("cursor", "text");
            TextBox11.Style.Add("cursor", "text");
            TextBox12.Style.Add("cursor", "text");
            TextBox13.Style.Add("cursor", "text");
            TextBox14.Style.Add("cursor", "text");
            TextBox15.Style.Add("cursor", "text");
            TextBox16.Style.Add("cursor", "text");
            TextBox17.Style.Add("cursor", "text");
            TextBox18.Style.Add("cursor", "text");

            TextBox1.ToolTip = "Fyll i antal slag.";
            TextBox2.ToolTip = "Fyll i antal slag.";
            TextBox3.ToolTip = "Fyll i antal slag.";
            TextBox4.ToolTip = "Fyll i antal slag.";
            TextBox5.ToolTip = "Fyll i antal slag.";
            TextBox6.ToolTip = "Fyll i antal slag.";
            TextBox7.ToolTip = "Fyll i antal slag.";
            TextBox8.ToolTip = "Fyll i antal slag.";
            TextBox9.ToolTip = "Fyll i antal slag.";
            TextBox10.ToolTip = "Fyll i antal slag.";
            TextBox11.ToolTip = "Fyll i antal slag.";
            TextBox12.ToolTip = "Fyll i antal slag.";
            TextBox13.ToolTip = "Fyll i antal slag.";
            TextBox14.ToolTip = "Fyll i antal slag.";
            TextBox15.ToolTip = "Fyll i antal slag.";
            TextBox16.ToolTip = "Fyll i antal slag.";
            TextBox17.ToolTip = "Fyll i antal slag.";
            TextBox18.ToolTip = "Fyll i antal slag.";
        }
    }
}