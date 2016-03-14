﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Team_1_Halslaget_GK
{
    public partial class StartList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["Username"] == null)
            //{
            //    Response.Redirect("~/NotAllowed.aspx");
            //}
            if (!IsPostBack)
            {
                InitializeGUI();
            }
        }

        protected void InitializeGUI()
        {
            BindDropDownCompetition();
        }

        private void BindDropDownCompetition()
        {
            Competition comp = new Competition();
            DataTable comps = comp.GetAllUpcomingCompetitions();

            DropDownList1.DataSource = comps;
            DropDownList1.DataTextField = "namn";
            DropDownList1.DataValueField = "id";
            DropDownList1.DataBind();
            this.DropDownList1.Items.Insert(0, "Välj");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string compName = DropDownList1.SelectedValue.ToString();

            if(DropDownList1.Text == "hej")
            {
                infotext.InnerText = "";
                NOcompetitorstext.InnerText = "";
                btnGeneratePlaylist.Enabled = false;
                GridView1.Visible = false;

            }

            else
            {
                Competition specCompetition = new Competition();
                compName = DropDownList1.SelectedValue.ToString();
                DataTable competition = specCompetition.GetSpecificCompetition(compName);

                infotext.InnerText = DateTime.Parse(competition.Rows[0]["datum"].ToString()).ToShortDateString();

                int players = Convert.ToInt32(specCompetition.GetNOcompetitors(compName));
                NOcompetitorstext.InnerText =  players.ToString() + " spelare är anmälda";

                if (players > 0)
                {
                    btnGeneratePlaylist.Visible = true;

                }
                if (players == 0)
                {
                    btnGeneratePlaylist.Visible = false;
                }
                

                if (competition.Rows[0]["startlistxml"] is DBNull)
                {
                    GridView1.Visible = false;
                }

                else
                {
                    BindGrid(competition.Rows[0]["startlistxml"].ToString());
                    GridView1.Visible = true;
                }
            }      
        }

        protected void BindGrid(string xml)
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

        protected void btnGeneratePlaylist_Click(object sender, EventArgs e)
        {
            string compName = DropDownList1.Text;
            Competition comp = new Competition();
            DataTable players = comp.GetCompetitors(compName);

            DataTable competitioninfo = comp.GetSpecificCompetition(compName);
            string starttime = Convert.ToString(competitioninfo.Rows[0]["starttid"]);



            DataTable RndStartList = SetCompetitorsTeeTimes(players, starttime);
            
            string xml;
            using (StringWriter sw = new StringWriter())
            {
                RndStartList.WriteXml(sw);
                xml = sw.ToString();
            }

            comp.SetStartList(xml, compName);
            
        }

        protected DataTable SetCompetitorsTeeTimes(DataTable dt, string starttime)
        {
            Random r = new Random();
            DataTable RndTeeTimes = new DataTable();
            RndTeeTimes.Columns.Add("Starttid");
            RndTeeTimes.Columns.Add("Golf ID");
            RndTeeTimes.Columns.Add("Förnamn");
            RndTeeTimes.Columns.Add("Efternamn");
            RndTeeTimes.TableName = "StartTimes";

            int i = 0;
            DateTime starttimedt = Convert.ToDateTime(starttime);

            while (dt.Rows.Count > 0)
            {
                int rndrow = r.Next(dt.Rows.Count);

                RndTeeTimes.Rows.Add();
                RndTeeTimes.Rows[i][0] = starttimedt.ToString("HH:mm");
                RndTeeTimes.Rows[i][1]  = dt.Rows[rndrow]["golfid"];
                RndTeeTimes.Rows[i][2] = dt.Rows[rndrow]["fornamn"];
                RndTeeTimes.Rows[i][3] = dt.Rows[rndrow]["efternamn"];

                DataRow dr = dt.Rows[rndrow];
                dr.Delete();
                dt.AcceptChanges();

                i++;

                if (i % 3 == 0)
                {
                    starttimedt = starttimedt.AddMinutes(10);
                }
            }

            GridView1.DataSource = RndTeeTimes;
            GridView1.DataBind();
            GridView1.Visible = true;
            return RndTeeTimes;
        }
    }
}