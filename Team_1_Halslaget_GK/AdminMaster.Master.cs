using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team_1_Halslaget_GK
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogOut_ServerClick(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/deafult.aspx");
        }

        protected void btnLogOutResponsive_ServerClick(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/deafult.aspx");
        }
    }
}