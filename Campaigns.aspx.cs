using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace AMS
{
    public partial class _Campaigns : Page
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

                    BindCampaignGridView();
                }
            }
        }

        protected void CampaignGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CampaignGridView.PageIndex = e.NewPageIndex;

            DataTable dt = ViewState["CampaignTable"] as DataTable;

            if (dt != null)
            {
                CampaignGridView.DataSource = dt;
                CampaignGridView.DataBind();
            }
        }

        private void BindCampaignGridView()
        {
            try
            {
                DataTable dta = new DataTable();
                Serve apir = new Serve();
                dta = apir.getCampaignListById("getCampaignListById", Convert.ToInt16(Idn.Value));

                if (dta.Rows.Count > 0)
                {
                    ViewState["CampaignTable"] = dta;

                    CampaignGridView.DataSource = dta;
                    CampaignGridView.DataBind();
                }
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
                string result = apir.updateCampaignById("updateCampaignById", websiteID, status, Convert.ToInt16(Idn.Value));

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

        protected void CreateCampaignButton_Click(object sender, EventArgs e)
        {
            ErrLbl.ForeColor = Color.Red;

            if (txtCampaignName.Text.Trim() == "")
            {
                ErrLbl.Text = "Enter Campaign Name!";
            }
            else if (txtStartDate.Text.Trim() == "")
            {
                ErrLbl.Text = "Select the Start Date!";
            }
            else if (txtEndDate.Text.Trim() == "")
            {
                ErrLbl.Text = "Select the End Date!";
            }
            else if (Convert.ToDateTime(txtStartDate.Text.Trim()) > Convert.ToDateTime(txtEndDate.Text.Trim()))
            {
                ErrLbl.Text = "The End Date should be greater than or equal to the Start Date!";
            }
            else
            {
                string reslt = InsertRecord(txtCampaignName.Text.Trim(), 1, txtCampaignDescription.Text.Trim(), Convert.ToInt16(Idn.Value), txtStartDate.Text.Trim(), txtEndDate.Text.Trim());
                if (reslt.Contains(" successful"))
                {
                    ErrLbl.ForeColor = Color.Green;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + reslt + "');", true);
                    ErrLbl.Text = reslt;

                    BindCampaignGridView();

                    txtCampaignName.Text = "";
                    txtCampaignDescription.Text = "";
                    txtStartDate.Text = "";
                    txtEndDate.Text = "";
                    DataTable dtx = new DataTable();
                    ViewState["CampaignTable"] = dtx;
                }
                else
                {
                    ErrLbl.ForeColor = Color.Red;
                    ErrLbl.Text = reslt;
                }
            }
        }

        protected void CampaignGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            CampaignGridView.EditIndex = e.NewEditIndex;
            BindCampaignGridView();
        }

        protected void CampaignGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int campaignId = Convert.ToInt32(CampaignGridView.DataKeys[e.RowIndex].Value);

            TextBox txtPriority = (TextBox)CampaignGridView.Rows[e.RowIndex].FindControl("txtPriority");
            int newPriority = Convert.ToInt32(txtPriority.Text);

            string reslt = UpdateRecord(campaignId, newPriority, Convert.ToInt16(Idn.Value));
            if (reslt.Contains(" successful"))
            {
                ErrLbl.ForeColor = Color.Green;
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + reslt + "');", true);
                ErrLbl.Text = reslt;

                BindCampaignGridView();
            }
            else
            {
                ErrLbl.ForeColor = Color.Red;
                ErrLbl.Text = reslt;
            }

            CampaignGridView.EditIndex = -1;
        }

        protected void CampaignGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            CampaignGridView.EditIndex = -1;
            BindCampaignGridView();
        }

        protected void ActivateButton_Click(object sender, EventArgs e)
        {
            LinkButton clickedButton = sender as LinkButton;
            if (clickedButton != null)
            {
                int websiteID = Convert.ToInt32(clickedButton.CommandArgument);
                UpdateStatus(websiteID, 1);
            }

            BindCampaignGridView();
        }

        protected void DeactivateButton_Click(object sender, EventArgs e)
        {
            LinkButton clickedButton = sender as LinkButton;
            if (clickedButton != null)
            {
                int websiteID = Convert.ToInt32(clickedButton.CommandArgument);
                UpdateStatus(websiteID, 0);
            }

            BindCampaignGridView();
        }
        public string UpdateRecord(int campid, int prio, int usr)
        {
            try
            {
                Serve apir = new Serve();
                string result = apir.updateCampaign("updateCampaign", campid, prio, usr);

                return result;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + ex.Message + "');", true);
                return ex.Message;
            }
        }
        public string InsertRecord(string txtCampaignName_, int prio, string txtCampaignDescription_, int AdvertiserDDL_, string txtStartDate_, string txtEndDate_)
        {
            try
            {
                DateTime startDate;
                DateTime endDate;
                DateTime.TryParse(txtStartDate_, out startDate);
                DateTime.TryParse(txtEndDate_, out endDate);

                Serve apir = new Serve();
                string result = apir.insertCampaign("insertCampaign", txtCampaignName_, txtCampaignDescription_, prio, AdvertiserDDL_, startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"), Convert.ToInt16(Idn.Value));

                return result;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + ex.Message + "');", true);
                return ex.Message;
            }
        }
    }
}