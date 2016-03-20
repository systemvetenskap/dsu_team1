using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

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
            Diary GetSpec = new Diary();
            string diaryNote = GetSpec.GetSpecificDiaryNote();

            System.Web.UI.HtmlControls.HtmlGenericControl newsdiv2 = new System.Web.UI.HtmlControls.HtmlGenericControl();
            string News = "fullBox";
            newsdiv2.InnerHtml = diaryNote;
            newsdiv2.Attributes["class"] = News;
            diaryNoteDiv.Controls.Add(newsdiv2);        
        }

        private void BindGridDiaryNotes()
        {
            string id = "2";
            Diary GetAllNotes = new Diary();
            DataTable allNotes = GetAllNotes.GetUserAllDiaryNotes(id);

            GridView1.DataSource = allNotes;
            GridView1.DataBind();
        }
    }
}