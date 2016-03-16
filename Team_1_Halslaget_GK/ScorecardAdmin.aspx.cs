using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using System.Data;
using System.Drawing;

namespace Team_1_Halslaget_GK
{
    public partial class ScorecardAdmin : System.Web.UI.Page
    {
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
        /// Initilization of gui with standardvalues.
        /// </summary>
        private void InitilizeGUI()
        {
            BindDropDownCompetition();
            LockTextBoxes();
        }

        /// <summary>
        /// Binds dropdowncompetition with all the current competitions.
        /// </summary>
        private void BindDropDownCompetition()
        {
            Competition getCompetitions = new Competition();
            DataTable competitions = getCompetitions.GetAllCompetitions();

            dropDownCompetition.DataSource = competitions;
            dropDownCompetition.DataTextField = "namn";
            dropDownCompetition.DataValueField = "id";
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

            if (lblType.Text == "singel")
            {
                Hole h19 = new Hole();
                h19.totalSlag = calculateTotal();
                round.Add(h19);

                //string score = lblScore.Text;
                Hole h20 = new Hole();
                h20.score = calculateScore();
                round.Add(h20);
            }

            if (lblType.Text == "lag")
            {

            }

            return round;
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

        private void calculateTeamScore(DataSet dsp1, DataSet dsp2, DataSet dsp3, DataSet dsp4, int teamid)
        {
            int totalscore = 0;
            Hole h = new Hole();
            DataTable holeinfo = h.GetHoleInfo();
            int i = 0;
            List<int> scorecount = new List<int>();

            foreach (DataRow dr in dsp1.Tables[0].Rows)
            {
                if (Convert.ToInt32(dr["slag"]) >= Convert.ToInt32(holeinfo.Rows[i]["par"]) + 2)
                {
                    scorecount.Add(0);
                }

                else
                {
                    int points = 2 + (Convert.ToInt32(holeinfo.Rows[i]["par"]) - Convert.ToInt32(dr["slag"]));
                    scorecount.Add(points);
                }

                DataRow dr2 = dsp2.Tables[0].Rows[i];
                if (Convert.ToInt32(dr2["slag"]) >= Convert.ToInt32(holeinfo.Rows[i]["par"]) + 2)
                {
                    scorecount.Add(0);
                }

                else
                {
                    int points = 2 + (Convert.ToInt32(holeinfo.Rows[i]["par"]) - Convert.ToInt32(dr2["slag"]));
                    scorecount.Add(points);
                }

                DataRow dr3 = dsp3.Tables[0].Rows[i];
                if (Convert.ToInt32(dr3["slag"]) >= Convert.ToInt32(holeinfo.Rows[i]["par"]) + 2)
                {
                    scorecount.Add(0);
                }

                else
                {
                    int points = 2 + (Convert.ToInt32(holeinfo.Rows[i]["par"]) - Convert.ToInt32(dr3["slag"]));
                    scorecount.Add(points);
                }

                DataRow dr4 = dsp4.Tables[0].Rows[i];
                if (Convert.ToInt32(dr4["slag"]) >= Convert.ToInt32(holeinfo.Rows[i]["par"]) + 2)
                {
                    scorecount.Add(0);
                }

                else
                {
                    int points = 2 + (Convert.ToInt32(holeinfo.Rows[i]["par"]) - Convert.ToInt32(dr4["slag"]));
                    scorecount.Add(points);
                }

                scorecount.OrderByDescending(p => p).ToList();
                scorecount.RemoveAt(3);

                totalscore += scorecount.Sum();
                scorecount.Clear();
                i++;
            }

            Team t = new Team();
            t.SetTeamResult(totalscore, teamid);
        }

        protected void deserializeScore()
        {
            int memberid = Convert.ToInt32(lblMemberId.Text);
            int compid = Convert.ToInt32(lblCompetitionID.Text);
            
            Team lag = new Team();
            DataTable dt = lag.GetTeamXML(memberid, compid);
            int teamid = Convert.ToInt32(dt.Rows[0][0]);

            int playercount = 0;

            DataSet dsp1 = new DataSet();
            DataSet dsp2 = new DataSet();
            DataSet dsp3 = new DataSet();
            DataSet dsp4 = new DataSet();

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["resultatxml"].ToString() != "")
                {
                    if (playercount == 3)
                    {
                        playercount++;

                        try
                        {
                            StringReader sr = new StringReader(dr[1].ToString());
                            dsp1.ReadXml(sr);
                        }

                        catch (Exception ex)
                        {

                        }
                    }

                    if (playercount == 2)
                    {
                        playercount++;

                        try
                        {
                            StringReader sr = new StringReader(dr[1].ToString());
                            dsp2.ReadXml(sr);
                        }

                        catch (Exception ex)
                        {

                        }
                    }

                    if (playercount == 1)
                    {
                        playercount++;

                        try
                        {
                            StringReader sr = new StringReader(dr[1].ToString());
                            dsp3.ReadXml(sr);
                        }

                        catch (Exception ex)
                        {

                        }
                    }

                    if (playercount == 0)
                    {
                        playercount++;

                        try
                        {
                            StringReader sr = new StringReader(dr[1].ToString());
                            dsp4.ReadXml(sr);
                        }

                        catch (Exception ex)
                        {

                        }
                    }

                    if (playercount == 4)
                    {
                        calculateTeamScore(dsp1, dsp2, dsp3, dsp4, teamid);
                    }
                }
            }
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
        /// Updates the GUI with new and relevant values. 
        /// </summary>
        private void UpdateGUI()
        {
            LockTextBoxes();

            string id = dropDownCompetition.SelectedValue;
            SetCompetitionInfoLabels(id);
            BindGridPlayers(id);

            lblMemberId.Text = "";
            lblFirstName.Text = "";
            lblLastName.Text = "";
            lblhcp.Text = "";
            lblKon.Text = "";
            lblteef.Text = "";
            lblteem.Text = "";
            txtBoxMemberID.Text = "";
        }

        /// <summary>
        /// Binds the grid with players from a specific competition.
        /// </summary>
        /// <param name="id"></param>
        private void BindGridPlayers(string id)
        {
            Competition getPlayers = new Competition();
            DataTable dt = getPlayers.GetSpecificCompetitionPlayers(id);

            GridView1.DataSource = dt;
            GridView1.DataBind();
            lblAnyPlayers.Style.Add("display", "none");
            if (GridView1.Rows.Count == 0)
            {
                lblAnyPlayers.Style.Add("display", "inline");
                lblAnyPlayers.Text = "Inga deltagare funna.\nEller så har alla deltagare ifyllda scorekort för denna tävling.";
            }
        }

        /// <summary>
        /// Sets the labels for a specific competition.
        /// </summary>
        /// <param name="id"></param>
        private void SetCompetitionInfoLabels(string id)
        {
            Competition specCompetition = new Competition();
            DataTable competition = specCompetition.GetSpecificCompetition(id);

            lblCompetitionID.Text = competition.Rows[0]["id"].ToString();
            lblDate.Text = DateTime.Parse(competition.Rows[0]["datum"].ToString()).ToShortDateString(); ;
            lblEndTime.Text = DateTime.Parse(competition.Rows[0]["sluttid"].ToString()).ToShortTimeString();
            lblStartTime.Text = DateTime.Parse(competition.Rows[0]["starttid"].ToString()).ToShortTimeString();
            lblType.Text = competition.Rows[0]["type"].ToString();
        }

        /// <summary>
        /// Event for when user wants to save the scorecard.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            int memberid = Convert.ToInt32(lblMemberId.Text);
            int compid = Convert.ToInt32(lblCompetitionID.Text);
            List<Hole> round = FindNOShots();
            Hole h = new Hole();

            if (lblType.Text == "singel")
            {
                string xml = SerializeRound(round);

                h.SetRound(xml, compid, memberid);
            }

            else
            {
                string xml = SerializeRound(round);
                h.SetRoundTeam(xml, compid, memberid);
                deserializeScore();

            }

            UpdateGUI();
        }

        /// <summary>
        /// Event for dropdowncompetition. 
        /// </summary>
        protected void dropDownCompetition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(dropDownCompetition.Text == "Välj")
            {
                lblCompetitionID.Text = "";
                lblDate.Text = "";
                lblEndTime.Text = "";
                lblStartTime.Text = "";
                lblType.Text = "";
            }
            else
            { 
                string id = dropDownCompetition.SelectedValue;
                SetCompetitionInfoLabels(id);
                BindGridPlayers(id);
            }

            //if (lblType.Text == "lag")
            //{
            //    dropDownTee.Enabled = false;
            //}

            //if (lblType.Text == "singel")
            //{
            //    dropDownTee.Enabled = true;
            //}
        }

        /// <summary>
        /// Event for when selected index is changed. Currently only changes the color
        /// of the row.
        /// </summary>
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowIndex == GridView1.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#6C6C6C");
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                }
            }
        }

        /// <summary>
        /// Event for rowcommand, when user clicks select/markera.
        /// </summary>
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {                
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                SetMemberInfoLabels(rowIndex);
                string kon = lblKon.Text;

                if(kon == "Female" || kon == "Kvinna")
                {
                    string teeID = lblteef.Text;
                    SetTeeSpecifications(teeID);
                }
                else
                {
                    string teeID = lblteem.Text;
                    SetTeeSpecifications(teeID);
                }

                OpenTextBoxes();
            }
        }

        /// <summary>
        /// Sets the memberinfo labels in order to be used to validate what player
        /// and what tee he/she is on.
        /// </summary>
        /// <param name="rowIndex">Chosen row in the gridview.</param>
        private void SetMemberInfoLabels(int rowIndex)
        {
            lblMemberId.Text = GridView1.Rows[rowIndex].Cells[0].Text;
            lblFirstName.Text = GridView1.Rows[rowIndex].Cells[1].Text;
            lblLastName.Text = GridView1.Rows[rowIndex].Cells[2].Text;
            lblhcp.Text = GridView1.DataKeys[rowIndex].Values["hcp"].ToString();
            lblKon.Text = GridView1.DataKeys[rowIndex].Values["kon"].ToString();
            lblteef.Text = GridView1.DataKeys[rowIndex].Values["teef"].ToString();
            lblteem.Text = GridView1.DataKeys[rowIndex].Values["teem"].ToString();
            txtBoxMemberID.Text = GridView1.Rows[rowIndex].Cells[1].Text;
        }

        /// <summary>
        /// Sets hidden labels to be used by javascript to calculate
        /// score and stuff and also for the C# to use to calculate the same stuff.
        /// </summary>
        /// <param name="id">id for what tee to get.</param>
        private void SetTeeSpecifications(string id)
        {
            Tee specTee = new Tee();
            DataTable specificTee = specTee.GetSpecificTee(id);

            lblSlopeValue.Text = specificTee.Rows[0]["slopevalue"].ToString();
            lblCourseRating.Text = specificTee.Rows[0]["courserating"].ToString();
            lblPar.Text = specificTee.Rows[0]["par"].ToString();
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
        
        ///// <summary>
        ///// Event for dropdowntee NOT NEEDED ANY MORE BUT SAVE CODE JUST IN CASE.
        ///// </summary>
        //protected void dropDownTee_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (dropDownTee.Text != "Välj")
        //    {
        //        Tee specTee = new Tee();
        //        string id = dropDownTee.SelectedValue;
        //        DataTable specificTee = specTee.GetSpecificTee(id);

        //        lblSlopeValue.Text = specificTee.Rows[0]["slopevalue"].ToString();
        //        lblCourseRating.Text = specificTee.Rows[0]["courserating"].ToString();
        //        lblPar.Text = specificTee.Rows[0]["par"].ToString();
        //    }
        //    else
        //    {
        //        lblSlopeValue.Text = "";
        //        lblCourseRating.Text = "";
        //        lblPar.Text = "";
        //    }
        //}

        ///// <summary>
        ///// NOT NEEDED ANYMORE.
        ///// Click event for btnGetMemberInfo, uses medlem class to get memberinfo and
        ///// most importantly memberid from database. Uses golfid to identify what member to take.
        ///// </summary>
        //protected void btnGetMemberInfo_Click(object sender, EventArgs e)
        //{
        //    medlem getMedlem = new medlem();
        //    string golfID = txtGoldID.Text;
        //    txtGoldID.Text = "";
        //    DataTable memberInfo = getMedlem.GetMemberWithGolfID(golfID);

        //    if (memberInfo.Rows.Count <= 0)
        //    {
        //        lblErrorNoMember.Text = "Det fanns ingen medlem med golf id " + golfID;
        //    }
        //    else
        //    {
        //        lblErrorNoMember.Text = "";
        //        lblMemberId.Text = memberInfo.Rows[0]["id"].ToString();
        //        lblFirstName.Text = memberInfo.Rows[0]["fornamn"].ToString();
        //        lblLastName.Text = memberInfo.Rows[0]["efternamn"].ToString();
        //        lblhcp.Text = memberInfo.Rows[0]["hcp"].ToString();
        //        txtBoxMemberID.Text = lblMemberId.Text = memberInfo.Rows[0]["id"].ToString();
        //        OpenTextBoxes();
        //    }
        //}

        ///// <summary>
        ///// Binds dropdowntee with all available tees.
        ///// </summary>
        //private void BindDropDownTee()
        //{
        //    Tee getTee = new Tee();
        //    DataTable allTees = getTee.GetAllTees();

        //    dropDownTee.DataSource = allTees;
        //    dropDownTee.DataTextField = "name";
        //    dropDownTee.DataValueField = "id";
        //    dropDownTee.DataBind();
        //    this.dropDownTee.Items.Insert(0, "Välj");
        //}
    }
}