using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

namespace Team_1_Halslaget_GK
{
    public partial class ScorecardAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected List<Hole> FindNOShots()
        {
            Hole h = new Hole();
            List<Hole> round = new List<Hole>();

            h.slag = Convert.ToInt32(TextBox1.Text); // Tänkte loopa här först men de visade sig vara krångligare än planeat.
                                                     // Kanske behövs det inte loopas heller egentligen, eller så gör det det. Kör man alltid 18 hål?
            h.nummer = 1;                            // - Dunno, LoL. Erik.D.
            round.Add(h);

            h.slag = Convert.ToInt32(TextBox2.Text);
            h.nummer = 2;
            round.Add(h);

            h.slag = Convert.ToInt32(TextBox3.Text);
            h.nummer = 3;
            round.Add(h);

            h.slag = Convert.ToInt32(TextBox4.Text);
            h.nummer = 4;
            round.Add(h);

            h.slag = Convert.ToInt32(TextBox5.Text);
            h.nummer = 5;
            round.Add(h);

            h.slag = Convert.ToInt32(TextBox6.Text);
            h.nummer = 6;
            round.Add(h);

            h.slag = Convert.ToInt32(TextBox7.Text);
            h.nummer = 7;
            round.Add(h);

            h.slag = Convert.ToInt32(TextBox8.Text);
            h.nummer = 8;
            round.Add(h);

            h.slag = Convert.ToInt32(TextBox9.Text);
            h.nummer = 9;
            round.Add(h);

            h.slag = Convert.ToInt32(TextBox10.Text);
            h.nummer = 10;
            round.Add(h);

            h.slag = Convert.ToInt32(TextBox11.Text);
            h.nummer = 11;
            round.Add(h);

            h.slag = Convert.ToInt32(TextBox12.Text);
            h.nummer = 12;
            round.Add(h);

            h.slag = Convert.ToInt32(TextBox13.Text);
            h.nummer = 13;
            round.Add(h);

            h.slag = Convert.ToInt32(TextBox14.Text);
            h.nummer = 14;
            round.Add(h);

            h.slag = Convert.ToInt32(TextBox15.Text);
            h.nummer = 15;
            round.Add(h);

            h.slag = Convert.ToInt32(TextBox16.Text);
            h.nummer = 16;
            round.Add(h);

            h.slag = Convert.ToInt32(TextBox17.Text);
            h.nummer = 17;
            round.Add(h);

            h.slag = Convert.ToInt32(TextBox18.Text);
            h.nummer = 18;
            round.Add(h);

            return round;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int memberid = 4;
            int compid = 1;

            List<Hole> round = FindNOShots();
            string xml = SerializeRound(round);
            
            Hole h = new Hole();
            h.SetRound(xml, compid, memberid);
        }

        protected string SerializeRound(List<Hole> round)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Hole>));

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, round);
                return textWriter.ToString();
            }
        }
    }
}