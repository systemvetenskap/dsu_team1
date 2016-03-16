using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team_1_Halslaget_GK
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Username"] == null)
            {
                Response.Redirect("~/NotAllowed.aspx");
            }

            if (!IsPostBack)
            {
                Competition comp = new Competition();
                DataTable dt = comp.GetSpecificCompetition(Session["compid"].ToString());

                LoadStartList(dt.Rows[0]["startlistxml"].ToString());   
            }         
        }

        protected void LoadStartList(string xml)
        {
            DataSet ds = new DataSet();

            try
            {
                StringReader sr = new StringReader(xml);
                ds.ReadXml(sr);
            }

            catch (Exception ex)
            {

            }

            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
    }
}