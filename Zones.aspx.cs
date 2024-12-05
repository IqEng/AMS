using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Media.Media3D;
using System.Xml.Linq;

namespace AMS
{
    public partial class _Zones : Page
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

                    BindZoneGridView();
                }
            }
        }

        protected void ZoneGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ZoneGridView.PageIndex = e.NewPageIndex;

            DataTable dt = ViewState["ZoneTable"] as DataTable;

            if (dt != null)
            {
                ZoneGridView.DataSource = dt;
                ZoneGridView.DataBind();
            }
        }

        private void BindZoneGridView()
        {
            try
            {
                DataTable dta = new DataTable();
                Serve apir = new Serve();
                dta = apir.getZoneListById("getZoneListById", Convert.ToInt16(Idn.Value));

                if (dta.Rows.Count > 0)
                {
                    ViewState["ZoneTable"] = dta;

                    ZoneGridView.DataSource = dta;
                    ZoneGridView.DataBind();
                }

                BindDropDowns();
                BindZoneDropDown();
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

        private void UpdateStatus(int websiteID, int status)
        {
            try
            {
                Serve apir = new Serve();
                string result = apir.updateZoneById("updateZoneById", websiteID, status, Convert.ToInt16(Idn.Value));

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

        protected void CreateZoneButton_Click(object sender, EventArgs e)
        {
            ErrLbl.ForeColor = Color.Red;

            if (WebsiteDDL.SelectedValue.ToString() == "0")
            {
                ErrLbl.Text = "Select a Website!";
            }
            else if (txtZoneName.Text.Trim() == "")
            {
                ErrLbl.Text = "Enter Zone Name!";
            }
            else if (ddlZoneTypeDDL.SelectedValue.ToString() == "0")
            {
                ErrLbl.Text = "Select Zone Type!";
            }
            else if (ddlZoneSizeDDL.SelectedValue.ToString() == "0")
            {
                ErrLbl.Text = "Select Zone Size!";
            }
            else if ((ddlZoneSizeDDL.SelectedValue.ToString() == "0") && (txtWidth.Text.Trim() == "" || txtHeight.Text.Trim() == ""))
            {
                ErrLbl.Text = "Enter Zone Sizes!";
            }
            else if ((ddlZoneSizeDDL.SelectedValue.ToString() == "-") && (txtWidth.Text.Trim() == "" || txtHeight.Text.Trim() == ""))
            {
                ErrLbl.Text = "Enter Custom Zone Sizes!";
            }
            else
            {
                PostAPI apir = new PostAPI();
                string reslt = "";

                reslt = InsertRecord(WebsiteDDL.SelectedValue.ToString().Trim(), ddlZoneTypeDDL.SelectedValue.ToString().Trim(), ddlZoneSizeDDL.SelectedValue.ToString().Trim(), txtZoneDescription.Text.Trim(),
                    txtZoneName.Text.Trim(), txtWidth.Text.Trim(), txtHeight.Text.Trim());
                if (reslt.Contains(" successful"))
                {
                    ErrLbl.ForeColor = Color.Green;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + reslt + "');", true);
                    ErrLbl.Text = reslt;

                    BindZoneGridView();

                    WebsiteDDL.SelectedIndex = -1;
                    ddlZoneTypeDDL.SelectedIndex = 0;
                    ddlZoneSizeDDL.SelectedIndex = 0;
                    txtZoneDescription.Text = "";
                    txtZoneName.Text = "";
                    txtWidth.Text = "";
                    txtHeight.Text = "";
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

            BindZoneGridView();
        }

        protected void DeactivateButton_Click(object sender, EventArgs e)
        {
            LinkButton clickedButton = sender as LinkButton;
            if (clickedButton != null)
            {
                int websiteID = Convert.ToInt32(clickedButton.CommandArgument);
                UpdateStatus(websiteID, 0);
            }

            BindZoneGridView();
        }
        public string InsertRecord(string WebSiteDDL_, string ddlZoneTypeDDL, string ddlZoneSizeDDL, string txtZoneDescription, string txtZoneName, string txtWidth, string txtHeight)
        {
            try
            {
                if(ddlZoneSizeDDL == "-")
                {
                    ddlZoneSizeDDL = txtWidth + "x" + txtHeight;
                }
                // Parse numeric values
                int width = 0;
                int height = 0;

                // Try parsing the width and height values
                int.TryParse(txtWidth, out width);
                int.TryParse(txtHeight, out height);

                Serve apir = new Serve();
                string result = apir.insertZone("insertZone", txtZoneName,
                    txtZoneDescription,
                    WebSiteDDL_,
                    ddlZoneTypeDDL,
                    ddlZoneSizeDDL,
                    width,
                    height, Convert.ToInt16(Idn.Value));

                return result;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + ex.Message + "');", true);
                return ex.Message;
            }
        }
        public static string GenerateRandomKey(int size = 32)
        {
            byte[] randomBytes = new byte[size];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomBytes);
            }
            return Convert.ToBase64String(randomBytes);
        }
        protected void DownloadButton_Click(object sender, EventArgs e)
        {
            string TargetWeb = ConfigurationManager.AppSettings["TargetWeb"];
            LinkButton clickedButton = sender as LinkButton;
            if (clickedButton != null)
            {
                GridViewRow row = (GridViewRow)clickedButton.NamingContainer;

                // Get the selected DataKey (zoneId)
                string zoneId = ZoneGridView.DataKeys[row.RowIndex].Value.ToString();

                // Retrieve the DataTable from ViewState
                DataTable dt = ViewState["ZoneTable"] as DataTable;

                if (dt != null)
                {
                    // Find the DataRow where the zoneId matches
                    DataRow[] foundRows = dt.Select($"Id = '{zoneId}'");

                    if (foundRows.Length > 0)
                    {
                        DataRow foundRow = foundRows[0];

                        // Retrieve the ZoneSize from the DataRow
                        string zoneSize = foundRow["ZoneSize"].ToString();
                        string width = "0";
                        string height = "0";

                        if (!string.IsNullOrEmpty(zoneSize))
                        {
                            string[] size = zoneSize.Split('x');
                            if (size.Length == 2)
                            {
                                width = size[0].ToString().Trim();
                                height = size[1].ToString().Trim();
                            }
                        }
                        if (width == "0")
                        {
                            width = "100%";
                        }
                        if (height == "0")
                        { height = "100%"; }

                        string script = $@" <div id='adZone'><iframe src='{TargetWeb}DisplayBanner.aspx?zoneId={zoneId}' width='{width}' height='{height}' frameborder='0' scrolling='no'></iframe></div>";

                        Session["DownloadContent"] = script;
                        Session["DownloadFileName"] = $"adZone_{zoneId}.txt";

                        ScriptManager.RegisterStartupScript(this, GetType(), "triggerDownload", "document.getElementById('" + HiddenDownloadButton.ClientID + "').click();", true);
                    }
                    else
                    {
                        Response.Redirect("~/Zone.aspx", false);
                    }
                }
            }

            BindZoneGridView();
        }

        protected void HiddenDownloadButton_Click(object sender, EventArgs e)
        {
            if (Session["DownloadContent"] != null && Session["DownloadFileName"] != null)
            {
                string content = Session["DownloadContent"].ToString();
                string fileName = Session["DownloadFileName"].ToString();

                Response.Clear();
                Response.ContentType = "text/plain";
                Response.AddHeader("Content-Disposition", $"attachment;filename={fileName}");
                Response.Write(content);
                Response.End();
            }
        }

        private void BindZoneDropDown()
        {
            try
            {
                DataTable dtc = new DataTable();
                Serve apir = new Serve();
                dtc = apir.getZoneByAdvertiserId("getZoneByAdvertiserId", Convert.ToInt16(Idn.Value));

                if (dtc.Rows.Count > 0)
                {
                    ZoneDDL.DataValueField = "Id";
                    ZoneDDL.DataTextField = "Name";
                    ZoneDDL.DataSource = dtc;
                    ZoneDDL.DataBind();
                    ZoneDDL.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + ex.Message + "');", true);
            }
        }

        protected void ZoneDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            Erred.Text = "";
            if (ZoneDDL.SelectedIndex > 0)
            {
                try
                {
                    DataTable dtc = new DataTable();
                    Serve apir = new Serve();
                    dtc = apir.getZoneDetailsById("getZoneDetailsById", Convert.ToInt16(ZoneDDL.SelectedValue));

                    if (dtc.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtc.Rows)
                        {
                            Descriptioned.Text = dr["Description"].ToString().Trim();
                            typeDDL.SelectedValue = dr["ZoneTypeId"].ToString().Trim();
                            sizeDDL.SelectedValue = dr["ZoneSizeId"].ToString().Trim();

                            if (sizeDDL.SelectedValue == "0")
                            {
                                sizeDDL.SelectedValue = "-";
                                CustomW.Text = dr["mWidth"].ToString().Trim();
                                CustomH.Text = dr["mHeight"].ToString().Trim();
                            }
                            else
                            {
                                CustomW.Text = "";
                                CustomH.Text = "";
                            }
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
                ZoneDDL.SelectedIndex = 0;
                Descriptioned.Text = "";
                typeDDL.SelectedIndex = 0;
                sizeDDL.SelectedIndex = 0;
                CustomW.Text = "";
                CustomH.Text = "";
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            Erred.ForeColor = Color.Red;

            if (ZoneDDL.SelectedValue.ToString() == "0")
            {
                Erred.Text = "Select a Zone!";
            }
            else if (typeDDL.SelectedValue.ToString() == "0")
            {
                Erred.Text = "Select Zone Type!";
            }
            else if (sizeDDL.SelectedValue.ToString() == "0")
            {
                Erred.Text = "Select Zone Size!";
            }
            else if ((sizeDDL.SelectedValue.ToString() == "0") && (CustomW.Text.Trim() == "" || CustomH.Text.Trim() == ""))
            {
                Erred.Text = "Enter Zone Sizes!";
            }
            else if ((sizeDDL.SelectedValue.ToString() == "-") && (CustomW.Text.Trim() == "" || CustomH.Text.Trim() == ""))
            {
                Erred.Text = "Enter Custom Zone Sizes!";
            }
            else
            {
                PostAPI apir = new PostAPI();
                string reslt = "";

                reslt = UpdateRecord(ZoneDDL.SelectedValue.ToString().Trim(), typeDDL.SelectedValue.ToString().Trim(), sizeDDL.SelectedValue.ToString().Trim(),
                    Descriptioned.Text.Trim(), CustomW.Text.Trim(), CustomH.Text.Trim());
                if (reslt.Contains(" successful"))
                {
                    Erred.ForeColor = Color.Green;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + reslt + "');", true);
                    Erred.Text = reslt;

                    BindZoneGridView();

                    ZoneDDL.SelectedIndex = -1;
                    Descriptioned.Text = "";
                    typeDDL.SelectedIndex = 0;
                    sizeDDL.SelectedIndex = 0;
                    CustomW.Text = "";
                    CustomH.Text = "";
                }
                else
                {
                    Erred.ForeColor = Color.Red;
                    Erred.Text = reslt;
                }
            }
        }
        public string UpdateRecord(string ZoneDDL_, string ddlZoneTypeDDL, string ddlZoneSizeDDL, string txtZoneDescription, string txtWidth, string txtHeight)
        {
            try
            {
                if (ddlZoneSizeDDL == "-")
                {
                    ddlZoneSizeDDL = txtWidth + "x" + txtHeight;
                }
                // Parse numeric values
                int width = 0;
                int height = 0;

                // Try parsing the width and height values
                int.TryParse(txtWidth, out width);
                int.TryParse(txtHeight, out height);

                Serve apir = new Serve();
                string result = apir.UpdateZone("updateZone", ZoneDDL_,
                    txtZoneDescription,
                    ddlZoneTypeDDL,
                    ddlZoneSizeDDL,
                    width,
                    height, Convert.ToInt16(Idn.Value));

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