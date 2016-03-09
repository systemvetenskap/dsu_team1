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
            if(!IsPostBack)
            {
                InitilizeGUI();
            }
        }

        private void InitilizeGUI()
        {
            BindDropDownCompetition();
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
            Hole h = new Hole();
            List<Hole> round = new List<Hole>();

            h.slag = Convert.ToInt32(TextBox1.Text); // Tänkte loopa här först men de visade sig vara krångligare än planeat.
                                                     // Kanske behövs det inte loopas heller egentligen, eller så gör det det. Kör man alltid 18 hål?
            h.nummer = 1;                            // - Dunno, LoL. Erik.D.
            round.Add(h);

            h.slag = Convert.ToInt32(TextBox2.Text);
            h.nummer = 2;
            round.Add(h);

            h.slag = Convert.ToInt32(TextBox3.Text);
            h.nummer = 3;
            round.Add(h);

            h.slag = Convert.ToInt32(TextBox4.Text);
            h.nummer = 4;
            round.Add(h);

            h.slag = Convert.ToInt32(TextBox5.Text);
            h.nummer = 5;
            round.Add(h);

            h.slag = Convert.ToInt32(TextBox6.Text);
            h.nummer = 6;
            round.Add(h);

            h.slag = Convert.ToInt32(TextBox7.Text);
            h.nummer = 7;
            round.Add(h);

            h.slag = Convert.ToInt32(TextBox8.Text);
            h.nummer = 8;
            round.Add(h);

            h.slag = Convert.ToInt32(TextBox9.Text);
            h.nummer = 9;
            round.Add(h);

            h.slag = Convert.ToInt32(TextBox10.Text);
            h.nummer = 10;
            round.Add(h);

            h.slag = Convert.ToInt32(TextBox11.Text);
            h.nummer = 11;
            round.Add(h);

            h.slag = Convert.ToInt32(TextBox12.Text);
            h.nummer = 12;
            round.Add(h);

            h.slag = Convert.ToInt32(TextBox13.Text);
            h.nummer = 13;
            round.Add(h);

            h.slag = Convert.ToInt32(TextBox14.Text);
            h.nummer = 14;
            round.Add(h);

            h.slag = Convert.ToInt32(TextBox15.Text);
            h.nummer = 15;
            round.Add(h);

            h.slag = Convert.ToInt32(TextBox16.Text);
            h.nummer = 16;
            round.Add(h);

            h.slag = Convert.ToInt32(TextBox17.Text);
            h.nummer = 17;
            round.Add(h);

            h.slag = Convert.ToInt32(TextBox18.Text);
            h.nummer = 18;
            round.Add(h);

            return round;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int memberid = int.Parse(lblMemberId.Text); //BOrde fungera.
            int compid = int.Parse(lblCompetitionID.Text); //Borde fungera.

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
                txtBoxMemberID.Text = lblMemberId.Text = memberInfo.Rows[0]["id"].ToString();
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
    }
}