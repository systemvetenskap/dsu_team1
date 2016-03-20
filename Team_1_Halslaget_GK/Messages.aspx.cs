using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Team_1_Halslaget_GK.Classes;

namespace Team_1_Halslaget_GK
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeGUI();
            }
            
        }

        protected void InitializeGUI()
        {
            int id = 2; //Convert.ToInt32(Session["username"])

            Message msg = new Message();
            DataTable dt = msg.GetMessages(id);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["meddelande"].ToString().Length > 30)
                {
                    string messageshort = dt.Rows[i]["meddelande"].ToString().Substring(0, 30);
                    messageshort = messageshort + "...";
                    dt.Rows[i]["meddelande"] = messageshort;
                }
            }

            dt = FixDates(dt);
            BindRepeater1(dt);
            
        }

        protected void BindRepeater1(DataTable dt)
        {
            Repeater1.DataSource = null;
            Repeater1.DataBind();
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }

        protected DataTable FixDates(DataTable dt)
        {
            dt.Columns.Add("nytid");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime datetime = Convert.ToDateTime(dt.Rows[i]["tid"]);
                string nytid = datetime.ToString("dd-MM-yyyy HH:mm");
                dt.Rows[i]["nytid"] = nytid;
            }

            return dt;
        }

        protected void LinkBtnShowFullMessage_Click(object sender, EventArgs e)
        {
            TextBoxReply.Visible = true;
            ButtonReply.Visible = true;

            var btn = (LinkButton)sender;
            var item = (RepeaterItem)btn.NamingContainer;
            var hf = (HiddenField)item.FindControl("HiddenFieldMemberID");
            int id = Convert.ToInt32(hf.Value);

            ClientScript.RegisterStartupScript(GetType(), "hwa", "scrollToConversationBottom();", true);
            ShowMessage(id);
        }

        protected void ShowMessage(int id)
        {
            Message msg = new Message();
            DataTable dt = msg.GetMessagesSpecificMember(id);

            DateTime datetime = Convert.ToDateTime(dt.Rows[dt.Rows.Count - 1]["tid"]);

            frommember2.InnerHtml = "<strong>" + dt.Rows[0]["fornamn"].ToString() + dt.Rows[0]["efternamn"].ToString() + "</strong>";
            date2.InnerHtml = "<strong>" + datetime.ToString("dd-MM-yyyy HH:mm") + "</strong>";

            if (dt.Rows[0]["to_medlem"].ToString() == "2") //Session["username"]
            {
                LabelIDto.Text = dt.Rows[0]["from_medlem"].ToString();
            }

            else
            {
                LabelIDto.Text = dt.Rows[0]["to_medlem"].ToString();
            }

            Repeater2.DataSource = dt;
            Repeater2.DataBind();
        }

        protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var hf = e.Item.FindControl("HiddenFieldFromID") as HiddenField;                
                int from_id = Convert.ToInt32(hf.Value);

                HtmlGenericControl div = e.Item.FindControl("messageinrow") as HtmlGenericControl;
                HtmlGenericControl divborder = e.Item.FindControl("messageborder") as HtmlGenericControl;

                if (from_id == 2) //Session["username"]
                {
                    div.Attributes.Add("class", div.Attributes["class"] + " message-from");
                    divborder.Attributes.Add("class", divborder.Attributes["class"] + " border-from");
                    
                }

                else
                {
                    div.Attributes.Add("class", div.Attributes["class"] + " message-to");
                }
            }
        }

        protected void ButtonReply_Click(object sender, EventArgs e)
        {
            if (TextBoxReply.Text != "")
            {
                SendMessage();
            }
        }

        protected void TextBoxReply_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxReply.Text != "")
            {
                SendMessage();
            }
        }

        protected void SendMessage()
        {
            Message msg = new Message();
            string message = TextBoxReply.Text;
            int idfrom = 2; //Session["username"]
            int idto = Convert.ToInt32(LabelIDto.Text);

            if (msg.SendMessage(message, idfrom, idto))
            {
                ShowMessage(idto);
                TextBoxReply.Text = "";
            }
        }

        protected string FixSearchString()
        {
            string searchstring = TextBoxSearch.Text;
            string searchlower = searchstring.ToLower();
            char[] searchCharArray = searchlower.ToCharArray();
            searchCharArray[0] = char.ToUpper(searchCharArray[0]);
            return new string(searchCharArray);
        }

        protected void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (TextBoxSearch.Text != "")
            {
                int id = 2; //Convert.ToInt32(Session["username"]);
                Message msg = new Message();

                string search = FixSearchString();

                DataTable dt = msg.GetMessagesSearch(id, search);

                dt = FixDates(dt);

                BindRepeater1(dt);
            }

            else
            {
                InitializeGUI();
            }
        }

        protected void Repeater1_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            ScriptManager scriptMan = ScriptManager.GetCurrent(this);
            LinkButton btn = e.Item.FindControl("LinkBtnShowFullMessage") as LinkButton;
            if (btn != null)
            {
                btn.Click += LinkBtnShowFullMessage_Click;
                scriptMan.RegisterAsyncPostBackControl(btn);
            }
        }

    }
}