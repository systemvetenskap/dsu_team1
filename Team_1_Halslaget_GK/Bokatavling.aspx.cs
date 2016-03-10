﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team_1_Halslaget_GK
{
    public partial class Bokatavling : System.Web.UI.Page
    {
        NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

        medlem openmedlem;

        protected void Page_Load(object sender, EventArgs e)
        {
            Competition newcomp = new Competition();

            if (Session["Username"] == null)
            {
                Response.Redirect("~/NotAllowed.aspx");
            }

            openmedlem = Getmember(Session["Username"].ToString());
            

            gvTavlingar.DataSource = newcomp.GetAllCompetitions();
            gvTavlingar.DataBind();

            lblTavlingDesc.Visible = false;
            lblTavlingNamn.Visible = false;
            lblTavlingTyp.Visible = false;

            tbgolfid1.Visible = false;
            tbgolfid2.Visible = false;
            tbgolfid3.Visible = false;
            tbgolfid4.Visible = false;

            btnConfirm.Visible = false;
            btnConfirm2.Visible = false;
            btnRemove.Visible = false;

        }

        protected void gvTavlingar_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvTavlingar.Rows)
            {
                if (row.RowIndex == gvTavlingar.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#6C6C6C");
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                }
            }

            Competition newcom = GetspecificComp(gvTavlingar.SelectedValue.ToString());
           
            lblTavlingNamn.Text = newcom.namn;
            lblTavlingTyp.Text = newcom.type;
            lblTavlingDesc.Text = newcom.desc;

            lblTavlingDesc.Visible = true;
            lblTavlingNamn.Visible = true;
            lblTavlingTyp.Visible = true;

            string type = lblTavlingTyp.Text;

            if (type.ToLower() == "singel")
            {
                tbgolfid1.Visible = true;
                tbgolfid1.Enabled = false;
                tbgolfid1.Text = "test";
                btnConfirm.Visible = true;
            }

            else if (type.ToLower() == "lag")
            {
                tbgolfid1.Visible = true;
                tbgolfid1.Enabled = false;
                tbgolfid1.Text = "test";
                tbgolfid2.Visible = true;
                tbgolfid3.Visible = true;
                tbgolfid4.Visible = true;
                btnConfirm2.Visible = true;

            }

            if (alreadybooked())
            {
                tbgolfid1.Visible = false;
                tbgolfid2.Visible = false;
                tbgolfid3.Visible = false;
                tbgolfid4.Visible = false;

                btnConfirm.Visible = false;
                btnConfirm2.Visible = false;
                btnRemove.Visible = true;
            }         
        }     

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            string tavlingid = gvTavlingar.SelectedValue.ToString();
            string medlemid = openmedlem.ID.ToString();
            
           if (bookMember(medlemid, tavlingid))
            {
                             
            }
            else
            {
                
            }

        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {

            if (cancelbookingsingel(openmedlem.ID.ToString(), gvTavlingar.SelectedValue.ToString()))
            {

            }
        }

        protected void btnConfirm2_Click(object sender, EventArgs e)
        {

        }

        // ----------- Funktioner --------- //   

        public Competition GetspecificComp(string compid)
        {
            Competition newcom = new Competition();

            string sql = "SELECT * FROM tavling where id = @id";

            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", compid);
            conn.Open();

            NpgsqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                newcom.id = dr["id"].ToString();
                newcom.namn = dr["namn"].ToString();
                newcom.starttid = dr["starttid"].ToString();
                newcom.sluttid = dr["sluttid"].ToString();
                newcom.desc = dr["description"].ToString();
                newcom.type = dr["type"].ToString();
            }

            conn.Close();

            return newcom;
        }

        public medlem Getmember(string id)
        {
            medlem newmedlem = new medlem();

            string sql = "SELECT * FROM medlem where id = @id";

            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();

            NpgsqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                newmedlem.ID = Convert.ToInt32(dr["id"]);
                newmedlem.golfid = dr["golfid"].ToString();
            }

            conn.Close();

            return newmedlem;
        }

        public bool bookMember(string medlemid, string tavlingid)
        {
            try
            {
                string sql = "INSERT INTO medlem_tavling (medlem_id, tavling_id) VALUES (@medlem_id, @bokning_id)";
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@medlem_id", medlemid);
                cmd.Parameters.AddWithValue("@bokning_id", tavlingid);
                
                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                return false;
            }
            finally
            {
                conn.Close();
                
            }
            return true;

        }

        public bool cancelbookingsingel(string medlemid, string tavlingid)
        {
            try
            {
                string sql = "DELETE FROM medlem_tavling WHERE medlem_id = @medlem_id AND @tavling_id = tavling_id";
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@medlem_id", medlemid);
                cmd.Parameters.AddWithValue("@tavling_id", tavlingid);

                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                Label1.Text = ex.Message.ToString();
                return false;
                
            }
            finally
            {
                conn.Close();

            }
            return true;
        }

        public bool alreadybooked()
        {
            List<string> tavlingid = new List<string>();
            medlem newmedlem = Getmember(Session["Username"].ToString());
            string sql = "SELECT * FROM medlem_tavling WHERE medlem_id = @medlem_id";
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@medlem_id", newmedlem.ID.ToString());

            NpgsqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string id;
                id = dr["tavling_id"].ToString() + newmedlem.ID.ToString();
                tavlingid.Add(id);
            }

            string tmidselected = gvTavlingar.SelectedValue.ToString() + newmedlem.ID.ToString();

            foreach (string tmid in tavlingid)
            {
                if(tmid == tmidselected)
                {
                    return true;                    
                }
            }

            return false;
        }

        public bool bookTeam()
        {
            Team 
            return true;
        }

    }
}