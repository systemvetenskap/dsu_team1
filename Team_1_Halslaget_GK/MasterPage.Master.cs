using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team_1_Halslaget_GK
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogOut_ServerClick(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/default.aspx");

        }

        protected void btnLogOutResponsive_ServerClick(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/default.aspx");
        }

        protected void btnGoToBookingResponsive_ServerClick(object sender, EventArgs e)
        {
            string userID = Session["Username"].ToString();
            Session["userID"] = userID;
            Response.Redirect("~/Tidsbokning.aspx");
        }

        protected void btnGoToBookingMain_ServerClick(object sender, EventArgs e)
        {
            string userID = Session["Username"].ToString();
            Session["userID"] = userID;
            Response.Redirect("~/Tidsbokning.aspx");
        }

        protected void btnGoToMyPage_ServerClick(object sender, EventArgs e)
        {
            string userID = Session["Username"].ToString();
            Session["userID"] = userID;
            Response.Redirect("~/MyPage.aspx");
        }

        protected void btnGoToMyPageResponsive_ServerClick(object sender, EventArgs e)
        {
            string userID = Session["Username"].ToString();
            Session["userID"] = userID;
            Response.Redirect("~/MyPage.aspx");
        }

        protected void btnGotoBokatavling_ServerClick(object sender, EventArgs e)
        {
            string userID = Session["Username"].ToString();
            Session["userID"] = userID;
            Response.Redirect("~/Bokatavling.aspx");
        }

        protected void btnGoToBokatavlingResponsive_ServerClick(object sender, EventArgs e)
        {
            string userID = Session["Username"].ToString();
            Session["userID"] = userID;
            Response.Redirect("~/Bokatavling.aspx");
        }

        protected void BtnGoToMessages_ServerClick(object sender, EventArgs e)
        {
            string userID = Session["Username"].ToString();
            Session["userID"] = userID;
            Response.Redirect("~/Messages.aspx");
        }

        protected void btnGoToMessagesResponsive_ServerClick(object sender, EventArgs e)
        {
            string userID = Session["Username"].ToString();
            Session["userID"] = userID;
            Response.Redirect("~/Messages.aspx");
        }

        protected void btnGotoDagbok_ServerClick(object sender, EventArgs e)
        {
            string userID = Session["Username"].ToString();
            Session["userID"] = userID;
            Response.Redirect("~/Dagbok.aspx");
        }

        protected void btnGoToDagbokResponsive_ServerClick(object sender, EventArgs e)
        {
            string userID = Session["Username"].ToString();
            Session["userID"] = userID;
            Response.Redirect("~/Dagbok.aspx");
        }
    }
}