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
            List<Hole> round = new List<Hole>();

            Hole h1 = new Hole();
            h1.slag = Convert.ToInt32(TextBox1.Text); // Tänkte loopa här först men de visade sig vara krångligare än planeat.                                                     // Kanske behövs det inte loopas heller egentligen, eller så gör det det. Kör man alltid 18 hål?
            h1.nummer = 1;
            round.Add(h1);

            Hole h2 = new Hole();
            h2.slag = Convert.ToInt32(TextBox2.Text);
            h2.nummer = 2;
            round.Add(h2);

            Hole h3 = new Hole();
            h3.slag = Convert.ToInt32(TextBox3.Text);
            h3.nummer = 3;
            round.Add(h3);

            Hole h4 = new Hole();
            h4.slag = Convert.ToInt32(TextBox4.Text);
            h4.nummer = 4;
            round.Add(h4);

            Hole h5 = new Hole();
            h5.slag = Convert.ToInt32(TextBox5.Text);
            h5.nummer = 5;
            round.Add(h5);

            Hole h6 = new Hole();
            h6.slag = Convert.ToInt32(TextBox6.Text);
            h6.nummer = 6;
            round.Add(h6);

            Hole h7 = new Hole();
            h7.slag = Convert.ToInt32(TextBox7.Text);
            h7.nummer = 7;
            round.Add(h7);

            Hole h8 = new Hole();
            h8.slag = Convert.ToInt32(TextBox8.Text);
            h8.nummer = 8;
            round.Add(h8);

            Hole h9 = new Hole();
            h9.slag = Convert.ToInt32(TextBox9.Text);
            h9.nummer = 9;
            round.Add(h9);

            Hole h10 = new Hole();
            h10.slag = Convert.ToInt32(TextBox10.Text);
            h10.nummer = 10;
            round.Add(h10);

            Hole h11 = new Hole();
            h11.slag = Convert.ToInt32(TextBox11.Text);
            h11.nummer = 11;
            round.Add(h11);

            Hole h12 = new Hole();
            h12.slag = Convert.ToInt32(TextBox12.Text);
            h12.nummer = 12;
            round.Add(h12);

            Hole h13 = new Hole();
            h13.slag = Convert.ToInt32(TextBox13.Text);
            h13.nummer = 13;
            round.Add(h13);

            Hole h14 = new Hole();
            h14.slag = Convert.ToInt32(TextBox14.Text);
            h14.nummer = 14;
            round.Add(h14);

            Hole h15 = new Hole();
            h15.slag = Convert.ToInt32(TextBox15.Text);
            h15.nummer = 15;
            round.Add(h15);

            Hole h16 = new Hole();
            h16.slag = Convert.ToInt32(TextBox16.Text);
            h16.nummer = 16;
            round.Add(h16);

            Hole h17 = new Hole();
            h17.slag = Convert.ToInt32(TextBox17.Text);
            h17.nummer = 17;
            round.Add(h17);

            Hole h18 = new Hole();
            h18.slag = Convert.ToInt32(TextBox18.Text);
            h18.nummer = 18;
            round.Add(h18);

            return round;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int memberid = 2;
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