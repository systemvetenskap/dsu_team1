using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.IO;

namespace Team_1_Halslaget_GK
{
    public partial class Dagbok : System.Web.UI.Page
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
            //SetScoreCard();
            BindGridDiaryNotes();
        }

        private void BindGridDiaryNotes()
        {
            string userid = "2"; //CHange to session username.
            Diary GetAllNotes = new Diary();
            DataTable dt = GetAllNotes.GetUserAllDiaryNotes(userid);

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        private void SetDiaryNote(string noteID)
        {
            Diary GetSpec = new Diary();
            string diaryNote = GetSpec.GetSpecificDiaryNote(noteID);

            System.Web.UI.HtmlControls.HtmlGenericControl newsdiv2 = new System.Web.UI.HtmlControls.HtmlGenericControl();
            string News = "fullBox";
            newsdiv2.InnerHtml = diaryNote;
            newsdiv2.Attributes["class"] = News;
            diaryNoteDiv.Controls.Add(newsdiv2);
        }

        private void SetScoreCard(string noteID)
        {
                Diary testGrid = new Diary();
                //string id = "4";
                DataTable dt = testGrid.GetUserXML(noteID);
            foreach(DataRow row in dt.Rows)
            {
                object value = row["resultxml"];
                
                if(value == DBNull.Value)
                {
                    //lblTotal.Text = "Tomt";
                    ClearLabels();
                }
                else
                {
                    DataSet datasettest = new DataSet();
                    foreach (DataRow dr in dt.Rows)
                    {
                        StringReader sr = new StringReader(dr[0].ToString());
                        datasettest.ReadXml(sr);
                    }

                    //List<string> listTest = new List<string>();
                    //for (int j = 0; j < datasettest.Tables[0].Rows.Count; j++) 
                    //{
                    //    DataRow dr00 = datasettest.Tables[0].Rows[j];
                    //    listTest.Add(dr00["slag"].ToString());
                    //}

                    //ListView1.DataSource = listTest;
                    //ListView1.DataBind();

                    //Im tired. This will do for demo.
                    DataRow dr0 = datasettest.Tables[0].Rows[0];
                    Label_1.Text = dr0["slag"].ToString();

                    DataRow dr1 = datasettest.Tables[0].Rows[1];
                    Label_2.Text = dr1["slag"].ToString();

                    DataRow dr2 = datasettest.Tables[0].Rows[2];
                    Label_3.Text = dr2["slag"].ToString();

                    DataRow dr3 = datasettest.Tables[0].Rows[3];
                    Label_4.Text = dr3["slag"].ToString();

                    DataRow dr4 = datasettest.Tables[0].Rows[4];
                    Label_5.Text = dr4["slag"].ToString();

                    DataRow dr5 = datasettest.Tables[0].Rows[5];
                    Label_6.Text = dr5["slag"].ToString();

                    DataRow dr6 = datasettest.Tables[0].Rows[6];
                    Label_7.Text = dr6["slag"].ToString();

                    DataRow dr7 = datasettest.Tables[0].Rows[7];
                    Label_8.Text = dr7["slag"].ToString();

                    DataRow dr8 = datasettest.Tables[0].Rows[8];
                    Label_9.Text = dr8["slag"].ToString();

                    DataRow dr9 = datasettest.Tables[0].Rows[9];
                    Label_10.Text = dr9["slag"].ToString();

                    DataRow dr10 = datasettest.Tables[0].Rows[10];
                    Label_11.Text = dr10["slag"].ToString();

                    DataRow dr11 = datasettest.Tables[0].Rows[11];
                    Label_12.Text = dr11["slag"].ToString();

                    DataRow dr12 = datasettest.Tables[0].Rows[12];
                    Label_13.Text = dr12["slag"].ToString();

                    DataRow dr13 = datasettest.Tables[0].Rows[13];
                    Label_14.Text = dr13["slag"].ToString();

                    DataRow dr14 = datasettest.Tables[0].Rows[14];
                    Label_15.Text = dr14["slag"].ToString();

                    DataRow dr15 = datasettest.Tables[0].Rows[15];
                    Label_16.Text = dr15["slag"].ToString();

                    DataRow dr16 = datasettest.Tables[0].Rows[16];
                    Label_17.Text = dr16["slag"].ToString();

                    DataRow dr17 = datasettest.Tables[0].Rows[17];
                    Label_18.Text = dr17["slag"].ToString();

                    DataRow dr18 = datasettest.Tables[0].Rows[18];
                    lblTotal.Text = dr18["totalSlag"].ToString();

                    DataRow dr19 = datasettest.Tables[0].Rows[19];
                    lblScore.Text = dr19["score"].ToString();        
                }
            }                
        }

        private void ClearLabels()
        {
            Label_1.Text = "";
            Label_2.Text = "";
            Label_3.Text = "";
            Label_4.Text = "";
            Label_5.Text = "";
            Label_6.Text = "";
            Label_7.Text = "";
            Label_8.Text = "";
            Label_9.Text = "";
            Label_10.Text = "";
            Label_11.Text = "";
            Label_12.Text = "";
            Label_13.Text = "";
            Label_14.Text = "";
            Label_15.Text = "";
            Label_16.Text = "";
            Label_17.Text = "";
            Label_18.Text = "";
            lblScore.Text = "";
            lblTotal.Text = "";
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                lblTitle.Text = GridView1.Rows[rowIndex].Cells[1].Text;
                string noteID = GridView1.DataKeys[rowIndex].Values["id"].ToString();
                SetDiaryNote(noteID);
                SetScoreCard(noteID);
            }
        }

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
    }
}