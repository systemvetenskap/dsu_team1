﻿using System;
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
    }
}