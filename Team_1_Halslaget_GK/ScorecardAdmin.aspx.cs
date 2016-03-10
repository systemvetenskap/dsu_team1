using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using System.Data;

namespace Team_1_Halslaget_GK
{
    public partial class ScorecardAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["Username"] == null && Session["admin"] == null)
            //{
            //    Response.Redirect("~/NotAllowed.aspx");
            //}

            if(!IsPostBack)
            {
                InitilizeGUI();
            }
        }

        private void InitilizeGUI()
        {
            BindDropDownCompetition();
            LockTextBoxes();
        }

        private void BindDropDownCompetition()
        {
            Competition getCompetitions = new Competition();
            DataTable competitions = getCompetitions.GetAllCompetitions();

            dropDownCompetition.DataSource = competitions;
            dropDownCompetition.DataTextField = "namn";
            dropDownCompetition.DataBind();
            this.dropDownCompetition.Items.Insert(0, "Välj");
        }

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

            return round;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int memberid = 4; //lblMemberId.Text; //Kommentera bort för att använda medlemsid.
            int compid = 1; //lblCompetitionID.Text; //Kommentera bort för att använda tävlingsid.

            List<Hole> round = FindNOShots();
            string xml = SerializeRound(round);
            
            Hole h = new Hole();
            h.SetRound(xml, compid, memberid);

        }

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
        /// Click event for btnGetMemberInfo, uses medlem class to get memberinfo and
        /// most importantly memberid from database. Uses golfid to identify what member to take.
        /// </summary>
        protected void btnGetMemberInfo_Click(object sender, EventArgs e)
        {
            medlem getMedlem = new medlem();
            string golfID = txtGoldID.Text;
            txtGoldID.Text = "";
            DataTable memberInfo = getMedlem.GetMemberWithGolfID(golfID);

            if(memberInfo.Rows.Count <= 0)
            {
                lblErrorNoMember.Text = "Det fanns ingen medlem med golf id " + golfID;
            }
            else
            {
                lblErrorNoMember.Text = "";
                lblMemberId.Text = memberInfo.Rows[0]["id"].ToString();
                lblFirstName.Text = memberInfo.Rows[0]["fornamn"].ToString();
                lblLastName.Text = memberInfo.Rows[0]["efternamn"].ToString();
                lblhcp.Text = memberInfo.Rows[0]["hcp"].ToString();
                txtBoxMemberID.Text = lblMemberId.Text = memberInfo.Rows[0]["id"].ToString();
                OpenTextBoxes();
            }
        }

        /// <summary>
        /// Event for dropdown. 
        /// </summary>
        protected void dropDownCompetition_SelectedIndexChanged(object sender, EventArgs e)
        {
            string compName = dropDownCompetition.Text;
            if(compName == "Välj")
            {
                lblCompetitionID.Text = "";
                lblDate.Text = "";
                lblEndTime.Text = "";
                lblStartTime.Text = "";
            }
            else
            {
                Competition specCompetition = new Competition();
                compName = dropDownCompetition.Text;
                DataTable competition = specCompetition.GetSpecificCompetition(compName);

                lblCompetitionID.Text = competition.Rows[0]["id"].ToString();
                lblDate.Text = DateTime.Parse(competition.Rows[0]["datum"].ToString()).ToShortDateString(); ;
                lblEndTime.Text = DateTime.Parse(competition.Rows[0]["sluttid"].ToString()).ToShortTimeString();
                lblStartTime.Text = DateTime.Parse(competition.Rows[0]["starttid"].ToString()).ToShortTimeString();
            }            
        }

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
        }

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

        }
    }
}