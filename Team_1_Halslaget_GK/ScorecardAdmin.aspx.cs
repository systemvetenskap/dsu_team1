using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team_1_Halslaget_GK
{
    public partial class ScorecardAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Beräkna_Slope_Click(object sender, EventArgs e)
        {
            //Beräkning av slope => spelhandicap = Exakthandicap * (Slopevärde/113) + (banvärde - banans par).  Banvärde = "CR"

            //Beräkning av spelhandikap Herrar Gul o Röd

            double Exakt_Hcp;
            double Spel_Hcp_Gul_Herrar;
            double Spel_Hcp_Gul_Damer;
            double Spel_Hcp_Red_Herrar;
            double Spel_Hcp_Red_Damer;

            string Exakt_Hcp_input = TextBox_Hcp.Text;

            Exakt_Hcp = Convert.ToDouble(Exakt_Hcp_input);

            if (Exakt_Hcp < -4 || Exakt_Hcp > 54)
            {
                Response.Write("<script type=\"text/javascript\">alert('Angivet Hcp är inte inom intervallet (-4 -- 54)');</script>");

            }
            else if(Exakt_Hcp > -4 || Exakt_Hcp < 54)
            {
                Spel_Hcp_Red_Damer = Exakt_Hcp *  (124/113)-(73 - 72);


            



            }








            //Beräkning av spelhandikap Damer Gul o Röd


        }
    }
}