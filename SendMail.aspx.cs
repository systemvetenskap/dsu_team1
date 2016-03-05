using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team_1_Halslaget_GK
{
    public partial class SendMail : System.Web.UI.Page
    {
  
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public class epostkod
        {
            public string epost { get; set; }
        }
     
        protected void Button4_Click(object sender, EventArgs e)
        {

            try
            {
                NpgsqlConnection con = new NpgsqlConnection("Server=webblabb.miun.se; Port=5432; Database=dsu_golf; User Id=dsu_g1; Password=dsu_g1; SslMode=Require");
                string SendMessage = "SELECT epost FROM medlem";
                NpgsqlCommand cmdCommand = new NpgsqlCommand(SendMessage, con);
                con.Open();

                NpgsqlDataReader dr = cmdCommand.ExecuteReader();

                ArrayList emailArray = new ArrayList();
                var emails = new List<epostkod>();
                dr = cmdCommand.ExecuteReader();

                while (dr.Read())
                {
                    emails.Add(new epostkod
                    {
                            epost = Convert.ToString(dr["email"]),
                     });
                }
                foreach (epostkod email in emails)
                {
                    //           var smtp = new SmtpClient
                    //           {
                    //            string username = "anv.namn";  
                    //            string password = "password";    
                    //              Host = "smtp.live.com",
                    //              Port = 587,
                    //              EnableSsl = true,
                    //              DeliveryMethod = SmtpDeliveryMethod.Network,
                    //              UseDefaultCredentials = false,
                    //              Credentials = new NetworkCredential(anv.namn, password)
                    //           };


                    MailMessage mailMessage = new MailMessage();
                    MailAddress fromAddress = new MailAddress("Halslaget_GK@golf.se");
                    mailMessage.From = fromAddress;
                    mailMessage.To.Add("Medlemmar@golf.se");
                    //mailMessage.To.Add(email.epost); Mail-adress från dB
                    mailMessage.Subject = TextBox2.Text;
                    mailMessage.Body = TextBox1.Text;
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Host = "localhost";
                    smtpClient.Send(mailMessage); //Skickar en textsträng till "C:\epost"
                    //smtp.Send(mailmessage);

                }


            }
            catch (Exception)
            {
            }
        }


    }

}
