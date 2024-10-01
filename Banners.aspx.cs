using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.IO.Compression;
using System.Linq.Expressions;

namespace AMS
{
    public partial class _Banners : Page
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

                    BindBannerGridView();
                }
            }
        }

        protected void BannerGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BannerGridView.PageIndex = e.NewPageIndex;

            DataTable dt = ViewState["BannerTable"] as DataTable;

            if (dt != null)
            {
                BannerGridView.DataSource = dt;
                BannerGridView.DataBind();
            }
        }

        private void BindBannerGridView()
        {
            try
            {
                DataTable dt = new DataTable();
                Serve apir = new Serve();
                dt = apir.getBannerListById("getBannerListById", Convert.ToInt16(Idn.Value));

                if (dt.Rows.Count > 0)
                {
                    ViewState["BannerTable"] = dt;

                    BannerGridView.DataSource = dt;
                    BannerGridView.DataBind();
                }
                
                BindDropDowns();
                getWebsites();
                getZones();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + ex.Message + "');", true);
            }
        }

        private void BindDropDowns()
        {
            try
            {
                DataTable dtc = new DataTable();
                Serve apir = new Serve();
                dtc = apir.getCampaignById("getCampaignById", Convert.ToInt16(Idn.Value));

                if (dtc.Rows.Count > 0)
                {
                    CampaignDDL.DataValueField = "Id";
                    CampaignDDL.DataTextField = "Name";
                    CampaignDDL.DataSource = dtc;
                    CampaignDDL.DataBind();
                    CampaignDDL.SelectedIndex = 0;
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
                string result = apir.updateBannerById("updateBannerById", websiteID, status, Convert.ToInt16(Idn.Value));

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
        protected void CreateBannerButton_Click(object sender, EventArgs e)
        {
            ErrLbl.ForeColor = Color.Red;
            ErrLbl.Text = string.Empty;

            if (CampaignDDL.SelectedValue == "0")
            {
                ErrLbl.Text = "Select a Campaign!";
                return;
            }

            if (WebsiteDDL.SelectedValue == "0")
            {
                ErrLbl.Text = "Select a Website!";
                return;
            }

            if (ZonesDDL.SelectedValue == "0")
            {
                ErrLbl.Text = "Select a Zone!";
                return;
            }

            if (string.IsNullOrWhiteSpace(txtBannerName.Text))
            {
                ErrLbl.Text = "Enter Banner Name!";
                return;
            }

            if (ddlBannerType.SelectedValue == "0")
            {
                ErrLbl.Text = "Select a Banner Type!";
                return;
            }

            if (!fileBannerUpload.HasFile)
            {
                ErrLbl.Text = "Upload the Media!";
                return;
            }

            if (string.IsNullOrWhiteSpace(txtBannerLink.Text))
            {
                ErrLbl.Text = "Enter the website link this banner points to!";
                return;
            }

            if (ddlTarget.SelectedValue == "0")
            {
                ErrLbl.Text = "Select the Target!";
                return;
            }

            string fileExtension = Path.GetExtension(fileBannerUpload.FileName).ToLower();
            string[] allowedExtensions = { ".html", ".htm", ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff", ".webp", ".txt", ".mp4", ".avi", ".mkv", ".mov", ".wmv", ".zip" };

            if (!allowedExtensions.Contains(fileExtension))
            {
                ErrLbl.Text = "Invalid file type. Only HTML, Image, Text, and Video files are allowed.";
                return;
            }

            if (fileBannerUpload.PostedFile.ContentLength > 5242880)
            {
                ErrLbl.Text = "File size exceeds the 5MB limit.";
                return;
            }

            string folderPath = Server.MapPath("~/Uploads/");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string key = GenerateRandomKey(50).Substring(0, 7);
            string filenme = $"{CampaignDDL.SelectedValue}_{WebsiteDDL.SelectedValue}_{ZonesDDL.SelectedValue}_{key}{fileExtension}";
            string savePath = Path.Combine(folderPath, filenme);

            bool proceed = false;

            try
            {
                if (fileExtension == ".zip")
                {
                    string extractPath = Path.Combine(folderPath, key);
                    if (!Directory.Exists(extractPath))
                    {
                        Directory.CreateDirectory(extractPath);
                    }

                    fileBannerUpload.SaveAs(savePath);
                    ZipFile.ExtractToDirectory(savePath, extractPath);

                    string[] htmlFiles = Directory.GetFiles(extractPath, "*.html");
                    if (htmlFiles.Length > 0)
                    {
                        string mainHtmlFile = htmlFiles[0];
                        string htmlContent = File.ReadAllText(mainHtmlFile);
                        string htmlFileName = Path.GetFileName(mainHtmlFile);

                        string pattern = "src=\"";
                        int index = 0;

                        while ((index = htmlContent.IndexOf(pattern, index)) != -1)
                        {
                            int startIndex = index + pattern.Length;
                            int endIndex = htmlContent.IndexOf("\"", startIndex);

                            if (endIndex > startIndex)
                            {
                                string srcValue = htmlContent.Substring(startIndex, endIndex - startIndex);

                                if (!srcValue.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                                {
                                    string newSrcValue = $"{extractPath}/{srcValue}";
                                    htmlContent = htmlContent.Substring(0, startIndex) + newSrcValue + htmlContent.Substring(endIndex);
                                }
                            }

                            index = endIndex + 1;
                        }

                        File.WriteAllText(mainHtmlFile, htmlContent);
                        filenme = $"{key}/{htmlFileName}";
                        ErrLbl.Text = "File uploaded and extracted successfully!";
                        proceed = true;
                    }
                    else
                    {
                        ErrLbl.Text = "HTML file not found in this attachment!";
                        proceed = false;
                    }
                }
                else
                {
                    fileBannerUpload.SaveAs(savePath);
                    ErrLbl.Text = "File uploaded successfully!";
                    proceed = true;
                }
            }
            catch (Exception ex)
            {
                ErrLbl.Text = $"An error occurred: {ex.Message}";
                proceed = false;
            }

            if (proceed)
            {
                // Insert the record into the database
                string result = InsertRecord(
                    filenme,
                    WebsiteDDL.SelectedValue.Trim(),
                    ddlBannerSizeDDL.SelectedValue.Trim(),
                    CampaignDDL.SelectedValue.Trim(),
                    ZonesDDL.SelectedValue.Trim(),
                    ddlBannerType.SelectedValue.Trim(),
                    ddlTarget.SelectedValue.Trim(),
                    txtBannerLink.Text.Trim(),
                    txtBannerName.Text.Trim()
                );

                if (result.Contains(" successful"))
                {
                    ErrLbl.ForeColor = Color.Green;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert", $"alert('{result}');", true);
                    ErrLbl.Text = result;

                    BindBannerGridView();

                    ResetFormFields();
                }
                else
                {
                    ErrLbl.Text = result;
                }
            }
        }

        private void ResetFormFields()
        {
            CampaignDDL.SelectedIndex = 0;
            WebsiteDDL.SelectedIndex = 0;
            ZonesDDL.SelectedIndex = 0;
            ddlBannerSizeDDL.SelectedIndex = 0;
            ddlBannerType.SelectedIndex = 0;
            ddlTarget.SelectedIndex = 0;
            txtBannerLink.Text = string.Empty;
            txtBannerName.Text = string.Empty;
        }

        // Utility method to generate a random key
        private string GenerateRandomKey(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[new Random().Next(s.Length)]).ToArray());
        }

        public string InsertRecord(string filenme, string WebsiteId, string BannerSize, string CampaignDDLVlu, string ZonesDDLVlu, string ddlBannerTypeVlu, string ddlTargetVlu, string txtBannerLinkVlu, string txtBannerNameVlu)
        {
            try
            {
                Serve apir = new Serve();
                string result = apir.insertBanner("insertBanner", filenme, Convert.ToInt16(WebsiteId), BannerSize, Convert.ToInt16(CampaignDDLVlu), Convert.ToInt16(ZonesDDLVlu), ddlBannerTypeVlu, ddlTargetVlu, txtBannerLinkVlu, txtBannerNameVlu, Convert.ToInt16(Idn.Value));

                return result;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + ex.Message + "');", true);
                return ex.Message;
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

            BindBannerGridView();
        }

        protected void DeactivateButton_Click(object sender, EventArgs e)
        {
            LinkButton clickedButton = sender as LinkButton;
            if (clickedButton != null)
            {
                int websiteID = Convert.ToInt32(clickedButton.CommandArgument);
                UpdateStatus(websiteID, 0);
            }

            BindBannerGridView();
        }

        private void getZones()
        {
            try
            {
                DataTable dta = new DataTable();
                Serve apir = new Serve();
                dta = apir.getZonesById("getZonesById", Convert.ToInt16(Idn.Value));

                if (dta.Rows.Count > 0)
                {
                    ZonesDDL.DataValueField = "Id";
                    ZonesDDL.DataTextField = "Name";
                    ZonesDDL.DataSource = dta;
                    ZonesDDL.DataBind();
                    ZonesDDL.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + ex.Message + "');", true);
            }
        }

        private void getWebsites()
        {
            try
            {
                DataTable dta = new DataTable();
                Serve apir = new Serve();
                dta = apir.getWebsiteByCampaignId("getWebsiteByCampaignId", Convert.ToInt16(Idn.Value));

                if (dta.Rows.Count > 0)
                {
                    WebsiteDDL.DataValueField = "Id";
                    WebsiteDDL.DataTextField = "Name";
                    WebsiteDDL.DataSource = dta;
                    WebsiteDDL.DataBind();
                    WebsiteDDL.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + ex.Message + "');", true);
            }
        }
    }
}