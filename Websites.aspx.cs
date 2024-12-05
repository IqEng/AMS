using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace AMS
{
    public partial class _Websites : Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie userin4ck = Request.Cookies["SzxWNHuO4XCyfPMBrVASxNrPPA"];

                if (userin4ck == null)
                {
                    Response.Redirect("~/Login.aspx", false);
                }
                else
                {
                    Idn.Value = Kripta.Decrypt(userin4ck["id"].Trim(), "PPA4XCyfPMBrVASxNr/8A").ToString().Trim();
                    BindWebsiteGridView();
                }
            }
        }

        protected void WebsiteGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            WebsiteGridView.PageIndex = e.NewPageIndex;

            DataTable dt = ViewState["WebsiteTable"] as DataTable;

            if (dt != null)
            {
                WebsiteGridView.DataSource = dt;
                WebsiteGridView.DataBind();
            }
        }

        private void BindWebsiteGridView()
        {
            try
            {
                DataTable dt = new DataTable();
                Serve apir = new Serve();
                dt = apir.getWebsiteListById("getWebsiteListById", Convert.ToInt16(Idn.Value));

                if (dt.Rows.Count > 0)
                {
                    ViewState["WebsiteTable"] = dt;

                    WebsiteGridView.DataSource = dt;
                    WebsiteGridView.DataBind();
                }

                BindDropDowns();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + ex.Message + "');", true);
            }
        }

        private void UpdateStatus(int websiteID, int status)
        {
            try
            {
                Serve apir = new Serve();
                string result = apir.updateWebsiteById("updateWebsiteById", websiteID, status, Convert.ToInt16(Idn.Value));

                if (result.Contains(" successful"))
                {
                    ErrLbl.ForeColor = Color.Green;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + result + "');", true);
                    ErrLbl.Text = result;
                }
                else
                {
                    ErrLbl.ForeColor = Color.Red;
                    ErrLbl.Text = result;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + ex.Message + "');", true);
            }
        }

        protected void CreateWebsiteButton_Click(object sender, EventArgs e)
        {
            ErrLbl.ForeColor = Color.Red;

            if (NameTextBox.Text.Trim() == "")
            {
                ErrLbl.Text = "Enter Website Name!";
            }
            else if (WebsiteUrlTextBox.Text.Trim() == "")
            {
                ErrLbl.Text = "Enter Website URL!";
            }
            else if (txtCampaignBudget.Text.Trim() == "")
            {
                ErrLbl.Text = "Enter Campaign Budget!";
            }
            else if (TargetFrameDropDownList.SelectedValue == "0")
            {
                ErrLbl.Text = "Enter Target Frame!";
            }
            else
            {
                PostAPI apir = new PostAPI();
                string reslt = "";

                reslt = InsertRecord(NameTextBox.Text.Trim(), WebsiteUrlTextBox.Text.Trim(), TargetFrameDropDownList.SelectedValue.ToString().Trim(), txtCampaignBudget.Text.Trim());
                if (reslt.Contains(" successful"))
                {
                    ErrLbl.ForeColor = Color.Green;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + reslt + "');", true);
                    ErrLbl.Text = reslt;

                    BindWebsiteGridView();

                    TargetFrameDropDownList.SelectedIndex = 0;
                    NameTextBox.Text = "";
                    WebsiteUrlTextBox.Text = "";
                    txtCampaignBudget.Text = "";
                }
                else
                {
                    ErrLbl.ForeColor = Color.Red;
                    ErrLbl.Text = reslt;
                }
            }
        }

        protected void ActivateButton_Click(object sender, EventArgs e)
        {
            LinkButton clickedButton = sender as LinkButton;
            if (clickedButton != null)
            {
                int websiteID = Convert.ToInt32(clickedButton.CommandArgument);
                UpdateStatus(websiteID, 1);
            }
            
            BindWebsiteGridView();
        }

        protected void DeactivateButton_Click(object sender, EventArgs e)
        {
            LinkButton clickedButton = sender as LinkButton;
            if (clickedButton != null)
            {
                int websiteID = Convert.ToInt32(clickedButton.CommandArgument);
                UpdateStatus(websiteID, 0);
            }

            BindWebsiteGridView();
        }
        public string InsertRecord(string NameTextBox_, string WebsiteUrlTextBox_, string TargetFrameDropDownList_, string bdget)
        {
            try
            {
                decimal budget_ = 0;
                decimal.TryParse(bdget, out budget_);

                Serve apir = new Serve();
                string result = apir.insertWebsite("insertWebsite", NameTextBox_, WebsiteUrlTextBox_, budget_, TargetFrameDropDownList_, Convert.ToInt16(Idn.Value));

                return result;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + ex.Message + "');", true);
                return ex.Message;
            }
        }
        public string UpdateRecord(string WebId_, string WebsiteUrlTextBox_, string TargetFrameDropDownList_, string bdget)
        {
            try
            {
                decimal budget_ = 0;
                decimal.TryParse(bdget, out budget_);

                Serve apir = new Serve();
                string result = apir.updateWebsite("updateWebsite", WebId_, WebsiteUrlTextBox_, budget_, TargetFrameDropDownList_, Convert.ToInt16(Idn.Value));

                return result;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + ex.Message + "');", true);
                return ex.Message;
            }
        }

        private void BindDropDowns()
        {
            try
            {
                DataTable dtc = new DataTable();
                Serve apir = new Serve();
                dtc = apir.getWebsiteByAdvertiserId("getWebsiteByAdvertiserId", Convert.ToInt16(Idn.Value));

                if (dtc.Rows.Count > 0)
                {
                    WebsiteDDL.DataValueField = "Id";
                    WebsiteDDL.DataTextField = "Name";
                    WebsiteDDL.DataSource = dtc;
                    WebsiteDDL.DataBind();
                    WebsiteDDL.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + ex.Message + "');", true);
            }
        }

        protected void WebsiteDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditLbl.Text = "";
            if (WebsiteDDL.SelectedIndex > 0)
            {
                try
                {
                    DataTable dtc = new DataTable();
                    Serve apir = new Serve();
                    dtc = apir.getWebsiteDetailsById("getWebsiteDetailsById", Convert.ToInt16(WebsiteDDL.SelectedValue));

                    if (dtc.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtc.Rows)
                        {
                            Websiteurled.Text = dr["WebsiteUrl"].ToString().Trim();
                            Budgeted.Text = dr["Budget"].ToString().Trim();
                            TargetDDL.SelectedValue = dr["TargetFrame"].ToString().Trim();
                        }
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + ex.Message + "');", true);
                }
            }
            else
            {
                WebsiteDDL.SelectedIndex = 0;
                TargetDDL.SelectedIndex = 0;
                Budgeted.Text = "";
                Websiteurled.Text = "";
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            EditLbl.ForeColor = Color.Red;

            if (WebsiteDDL.SelectedIndex < 0)
            {
                EditLbl.Text = "Select a Website!";
            }
            else if (Websiteurled.Text.Trim() == "")
            {
                EditLbl.Text = "Enter Website URL!";
            }
            else if (Budgeted.Text.Trim() == "")
            {
                EditLbl.Text = "Enter Campaign Budget!";
            }
            else if (TargetDDL.SelectedValue == "0")
            {
                EditLbl.Text = "Enter Target Frame!";
            }
            else
            {
                PostAPI apir = new PostAPI();
                string reslt = "";

                reslt = UpdateRecord(WebsiteDDL.SelectedValue.ToString().Trim(), Websiteurled.Text.Trim(), TargetDDL.SelectedValue.ToString().Trim(), Budgeted.Text.Trim());
                if (reslt.Contains(" successful"))
                {
                    EditLbl.ForeColor = Color.Green;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + reslt + "');", true);
                    EditLbl.Text = reslt;

                    BindWebsiteGridView();

                    WebsiteDDL.SelectedIndex = 0;
                    TargetDDL.SelectedIndex = 0;
                    Budgeted.Text = "";
                    Websiteurled.Text = "";
                }
                else
                {
                    EditLbl.ForeColor = Color.Red;
                    EditLbl.Text = reslt;
                }
            }
        }
    }
}