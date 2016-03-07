//Code behind for adminpanel.
//Erik Drysén 2016-03-01.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team_1_Halslaget_GK
{
    public partial class AdminPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }
        }

        protected void btnGoToBooking_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tidsbokning.aspx");                
        }

        protected void btnGoToHandleBookings_Click(object sender, EventArgs e)
        {

        }

        protected void btnGoToMemberRegistry_Click(object sender, EventArgs e)
        {
            //Send username using session here I think? Right now only for show, not actual implementaion
            Response.Redirect("~/Medlemsregister.aspx");
        }

        protected void btnGoToCreateNewMember_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CreateNewMember.aspx");                
        }
    }
}