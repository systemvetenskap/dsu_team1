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

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "Alla medlemmar")
            {
                try
                {

                    MailMessage mailMessage = new MailMessage();
                    MailAddress fromAddress = new MailAddress("Halslaget_GK@golf.se");
                    mailMessage.From = fromAddress;
                    mailMessage.To.Add("Alla_Medlemmar@golf.se");
                    mailMessage.Body = TextBox1.Text + " Med Vanliga Halsningnar Halslaget GK";
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Subject = "Meddelande till alla medlemmar: " + TextBox2.Text;
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Host = "localhost";
                    smtpClient.Send(mailMessage);
                }
                catch (Exception)
                {
                }
            }

            if (DropDownList1.SelectedValue == "Senior")
            {
                try
                {

                    MailMessage mailMessage = new MailMessage();
                    MailAddress fromAddress = new MailAddress("Halslaget_GK@golf.se");
                    mailMessage.From = fromAddress;
                    mailMessage.To.Add("senoir@golf.se");
                    mailMessage.Body = TextBox1.Text + " Med Vanliga Halsningnar Halslaget GK";
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Subject = "Meddelande till Seniorer: " + TextBox2.Text;
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Host = "localhost";
                    smtpClient.Send(mailMessage);
                }
                catch (Exception)
                {
                }
            }
            if (DropDownList1.SelectedValue == "Student")
            {
                try
                {

                    MailMessage mailMessage = new MailMessage();
                    MailAddress fromAddress = new MailAddress("Halslaget_GK@golf.se");
                    mailMessage.From = fromAddress;
                    mailMessage.To.Add("student@golf.se");
                    mailMessage.Body = TextBox1.Text + " Med Vanliga Halsningnar Halslaget GK";
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Subject = "Meddelande till Studenter: " + TextBox2.Text;
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Host = "localhost";
                    smtpClient.Send(mailMessage);
                }
                catch (Exception)
                {
                }
            }
            if (DropDownList1.SelectedValue == "Junior 0 - 12 år")
            {
                try
                {

                    MailMessage mailMessage = new MailMessage();
                    MailAddress fromAddress = new MailAddress("Halslaget_GK@golf.se");
                    mailMessage.From = fromAddress;
                    mailMessage.To.Add("junior0-12@golf.se");
                    mailMessage.Body = TextBox1.Text + " Med Vanliga Halsningnar Halslaget GK";
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Subject = "Meddelande till Junior 0 - 12 år: " + TextBox2.Text;
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Host = "localhost";
                    smtpClient.Send(mailMessage);
                }
                catch (Exception)
                {
                }
            }
            if (DropDownList1.SelectedValue == "Junior 13 - 21 år")
            {
                try
                {

                    MailMessage mailMessage = new MailMessage();
                    MailAddress fromAddress = new MailAddress("Halslaget_GK@golf.se");
                    mailMessage.From = fromAddress;
                    mailMessage.To.Add("junior12-21@golf.se");
                    mailMessage.Body = TextBox1.Text + " Med Vanliga Halsningnar Halslaget GK";
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Subject = "Meddelande till Junior 13 - 21 år: " + TextBox2.Text;
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Host = "localhost";
                    smtpClient.Send(mailMessage);
                }
                catch (Exception)
                {
                }
            }



        }


    }

}
