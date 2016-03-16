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
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            deserializeScore();
        }

        protected void deserializeScore()
        {
            int tavlingid = 27; //Hämtas från dropdownlist eller nåt sen

            Team lag = new Team();
            DataTable dt = lag.GetTeamXML(tavlingid);
            
            int teamid = Convert.ToInt32(dt.Rows[0][0]);
            int playercount = 0;
            int row = 0;

            DataSet dsp1 = new DataSet();
            DataSet dsp2 = new DataSet();
            DataSet dsp3 = new DataSet();
            DataSet dsp4 = new DataSet();

            foreach (DataRow dr in dt.Rows)
            {
                row++;
                if (dr["resultatxml"].ToString() != "")
                {                   
                    if (teamid == Convert.ToInt32(dr[0]) && playercount == 3)
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

                    if (teamid == Convert.ToInt32(dr[0]) && playercount == 2)
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

                    if (teamid == Convert.ToInt32(dr[0]) && playercount == 1)
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

                    if (teamid == Convert.ToInt32(dr[0]) && playercount == 0)
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

                        if (row < dt.Rows.Count)
                        {
                            teamid = Convert.ToInt32(dt.Rows[row + 1][0]);
                        }                      
                    }
                }                

                else if (row % 4 == 0 && row < dt.Rows.Count)
                {
                    teamid = Convert.ToInt32(dt.Rows[row + 1][0]);
                }
            }
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
    }
}