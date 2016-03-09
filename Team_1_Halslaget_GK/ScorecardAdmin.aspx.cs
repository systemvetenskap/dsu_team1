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
        }
    }
}