using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;
using System.Security.Policy;
using System.Web.Services.Description;
using System.Runtime.InteropServices.ComTypes;
using System.IO;
using System.Text;
using PdfSharp.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using PdfSharp.Drawing;
using iTextSharp.text.pdf;
using iTextSharp.text;
using ClosedXML.Excel;

namespace AMS
{
    public partial class _Reports : Page
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
                    AdDDL.Text = Kripta.Decrypt(userin4ck["dname"].Trim(), "PPA4XCyfPMBrVASxNr/8A").ToString().Trim();

                    getWebsites();
                    BindCams();

                    ReportNameLabel.Text = "";
                    ReportDateLabel.Text = "";
                }
            }
        }

        protected void GenerateReportButton_Click(object sender, EventArgs e)
        {
            if (ddlReportType.SelectedValue == "0")
            {
                ErrLbl.ForeColor = System.Drawing.Color.Red;
                ErrLbl.Text = "Select Report Type!";
            }
            else if (string.IsNullOrEmpty(txtFromDate.Text.Trim()))
            {
                ErrLbl.ForeColor = System.Drawing.Color.Red;
                ErrLbl.Text = "Select From Date!";
            }
            else if (string.IsNullOrEmpty(txtToDate.Text.Trim()))
            {
                ErrLbl.ForeColor = System.Drawing.Color.Red;
                ErrLbl.Text = "Select To Date!";
            }
            else
            {
                if (ddlReportType.SelectedValue == "CampaignPerformance")
                {
                    campaignPerformanceReport();
                }
                else if (ddlReportType.SelectedValue == "BannerPerformance")
                {
                    bannerPerformanceReport();
                }
                else if (ddlReportType.SelectedValue == "WebsitePerformance")
                {
                    websitePerformanceReport();
                }
                else if (ddlReportType.SelectedValue == "ZonePerformance")
                {
                    zonePerformanceReport();
                }
                else if (ddlReportType.SelectedValue == "CustomReport")
                {
                    customReport();
                }
            }
        }

        private void campaignPerformanceReport()
        {
            try
            {
                DataTable dta = new DataTable();
                Serve apir = new Serve();
                dta = apir.campaignPerformanceReport("campaignPerformanceReport", txtFromDate.Text.Trim(), txtToDate.Text.Trim(), Convert.ToInt16(Idn.Value));

                if (dta.Rows.Count > 0)
                {
                    ViewState["CampaignTable"] = dta;

                    DynamicReportGridView.DataSource = dta;
                    DynamicReportGridView.DataBind();

                    ReportNameLabel.Text = "Campaign Performance Report | From: " + txtFromDate.Text.Trim() + " To: " + txtToDate.Text.Trim();
                    ReportDateLabel.Text = "Generated on: " + DateTime.Now.ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + "No Record(s) found!" + "');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + ex.Message + "');", true);
            }
        }

        private void bannerPerformanceReport()
        {
            try
            {
                DataTable dta = new DataTable();
                Serve apir = new Serve();
                dta = apir.bannerPerformanceReport("bannerPerformanceReport", txtFromDate.Text.Trim(), txtToDate.Text.Trim(), Convert.ToInt16(Idn.Value));

                if (dta.Rows.Count > 0)
                {
                    ViewState["CampaignTable"] = dta;

                    DynamicReportGridView.DataSource = dta;
                    DynamicReportGridView.DataBind();

                    ReportNameLabel.Text = "Banner Performance Report | From: " + txtFromDate.Text.Trim() + " To: " + txtToDate.Text.Trim();
                    ReportDateLabel.Text = "Generated on: " + DateTime.Now.ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + "No Record(s) found!" + "');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + ex.Message + "');", true);
            }
        }

        private void websitePerformanceReport()
        {
            try
            {
                DataTable dta = new DataTable();
                Serve apir = new Serve();
                dta = apir.websitePerformanceReport("websitePerformanceReport", txtFromDate.Text.Trim(), txtToDate.Text.Trim(), Convert.ToInt16(Idn.Value));

                if (dta.Rows.Count > 0)
                {
                    ViewState["CampaignTable"] = dta;

                    DynamicReportGridView.DataSource = dta;
                    DynamicReportGridView.DataBind();

                    ReportNameLabel.Text = "Website Performance Report | From: " + txtFromDate.Text.Trim() + " To: " + txtToDate.Text.Trim();
                    ReportDateLabel.Text = "Generated on: " + DateTime.Now.ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + "No Record(s) found!" + "');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + ex.Message + "');", true);
            }
        }

        private void zonePerformanceReport()
        {
            try
            {
                DataTable dta = new DataTable();
                Serve apir = new Serve();
                dta = apir.zonePerformanceReport("zonePerformanceReport", txtFromDate.Text.Trim(), txtToDate.Text.Trim(), Convert.ToInt16(Idn.Value));

                if (dta.Rows.Count > 0)
                {
                    ViewState["CampaignTable"] = dta;

                    DynamicReportGridView.DataSource = dta;
                    DynamicReportGridView.DataBind();

                    ReportNameLabel.Text = "Zone Performance Report | From: " + txtFromDate.Text.Trim() + " To: " + txtToDate.Text.Trim();
                    ReportDateLabel.Text = "Generated on: " + DateTime.Now.ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + "No Record(s) found!" + "');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + ex.Message + "');", true);
            }
        }
        private void BindCams()
        {
            try
            {
                DataTable dtc = new DataTable();
                Serve apir = new Serve();
                dtc = apir.getCampaignById("getCampaignByIdAll", Convert.ToInt16(Idn.Value));

                if (dtc.Rows.Count > 0)
                {
                    CampaignDDL.DataValueField = "Id";
                    CampaignDDL.DataTextField = "Name";
                    CampaignDDL.DataSource = dtc;
                    CampaignDDL.DataBind();
                    CampaignDDL.SelectedIndex = 0;

                    ReportNameLabel.Text = "Custom Report | From: " + txtFromDate.Text.Trim() + " To: " + txtToDate.Text.Trim();
                    ReportDateLabel.Text = "Generated on: " + DateTime.Now.ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + "No Record(s) found!" + "');", true);
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
                dta = apir.getWebsiteByCampaignId("getWebsiteByCampaignIdAll", Convert.ToInt16(Idn.Value));

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

        private void customReport()
        {
            try
            {
                DataTable dta = new DataTable();
                Serve apir = new Serve();
                dta = apir.customReport("customReport", Convert.ToInt16(Idn.Value), Convert.ToInt16(CampaignDDL.SelectedValue.ToString()), Convert.ToInt16(WebsiteDDL.SelectedValue.ToString()), txtFromDate.Text.Trim(), txtToDate.Text.Trim(), Convert.ToInt16(Idn.Value));

                if (dta.Rows.Count > 0)
                {
                    ViewState["CampaignTable"] = dta;

                    DynamicReportGridView.DataSource = dta;
                    DynamicReportGridView.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + ex.Message + "');", true);
            }
        }

        protected void btnDownloadPdf_Click(object sender, EventArgs e)
        {
            if (DynamicReportGridView.Rows.Count > 0)
            {
                string reportName = GetReportName();

                try
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (Document document = new Document(PageSize.A4, 10f, 10f, 10f, 0f))
                        {
                            PdfWriter.GetInstance(document, memoryStream);
                            document.Open();

                            var titleFont = FontFactory.GetFont("Arial", 16, Font.BOLD);
                            document.Add(new Paragraph(reportName, titleFont));

                            var dateFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
                            document.Add(new Paragraph("Date: " + ReportDateLabel.Text, dateFont));
                            document.Add(new Paragraph("\n"));

                            PdfPTable pdfTable = new PdfPTable(DynamicReportGridView.HeaderRow.Cells.Count);
                            pdfTable.WidthPercentage = 100;

                            var headerFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
                            foreach (TableCell headerCell in DynamicReportGridView.HeaderRow.Cells)
                            {
                                PdfPCell pdfCell = new PdfPCell(new Phrase(headerCell.Text, headerFont))
                                {
                                    BackgroundColor = BaseColor.LightGray
                                };
                                pdfTable.AddCell(pdfCell);
                            }

                            var rowFont = FontFactory.GetFont("Arial", 10, Font.NORMAL);
                            foreach (GridViewRow gridViewRow in DynamicReportGridView.Rows)
                            {
                                foreach (TableCell gridViewCell in gridViewRow.Cells)
                                {
                                    PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewCell.Text, rowFont));
                                    pdfTable.AddCell(pdfCell);
                                }
                            }

                            document.Add(pdfTable);
                            document.Close();
                        }

                        Response.Clear();
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-disposition", "attachment;filename=" + reportName + ".pdf");
                        Response.Buffer = true;
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);

                        Response.BinaryWrite(memoryStream.ToArray());
                        Response.End();
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert", $"alert('An error occurred: {ex.Message}');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('No data available to export.');", true);
            }
        }

        private string GetReportName()
        {
            if (ReportNameLabel.Text.Contains("Campaign"))
            {
                return "Campaign Performance Report";
            }
            if (ReportNameLabel.Text.Contains("Banner"))
            {
                return "Banner Performance Report";
            }
            if (ReportNameLabel.Text.Contains("Website"))
            {
                return "Website Performance Report";
            }
            if (ReportNameLabel.Text.Contains("Zone"))
            {
                return "Zone Performance Report";
            }
            if (ReportNameLabel.Text.Contains("Custom"))
            {
                return "Custom Report";
            }
            return "Report";
        }

        private string CaptureDivHtml(string divId)
        {
            Control ctrl = Page.FindControl(divId);
            if (ctrl != null)
            {
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                ctrl.RenderControl(htw);

                string htmlContent = sw.ToString();
                string styledHtml = $@"
            <html>
            <head>
                <style>
                    body {{ font-family: Arial, sans-serif; }}
                    .table {{ width: 100%; border-collapse: collapse; }}
                    .table th, .table td {{ border: 1px solid black; padding: 8px; }}
                    h4 {{ color: black; }}
                    label {{ color: black; }}
                </style>
            </head>
            <body>
                {htmlContent}
            </body>
            </html>";

                return styledHtml;
            }
            return string.Empty;
        }

        private void GeneratePdf(string htmlContent, string fileName)
        {
            PdfSharp.Pdf.PdfDocument pdf = PdfGenerator.GeneratePdf(htmlContent, PdfSharp.PageSize.A4);
            using (MemoryStream ms = new MemoryStream())
            {
                pdf.Save(ms, false);

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
                Response.BinaryWrite(ms.ToArray());
                Response.End();
            }
        }
        protected void btnDownloadExcel_Click(object sender, EventArgs e)
        {
            if (DynamicReportGridView.Rows.Count > 0)
            {
                string reportName = GetReportName();

                try
                {
                    using (XLWorkbook workbook = new XLWorkbook())
                    {
                        IXLWorksheet worksheet = workbook.Worksheets.Add(reportName);

                        worksheet.Cell(1, 1).Value = reportName;
                        worksheet.Cell(1, 1).Style.Font.Bold = true;
                        worksheet.Cell(1, 1).Style.Font.FontSize = 16;
                        worksheet.Row(1).Merge();

                        worksheet.Cell(2, 1).Value = "Date: " + ReportDateLabel.Text;
                        worksheet.Cell(2, 1).Style.Font.FontSize = 12;
                        worksheet.Row(2).Merge();

                        int currentRow = 4;

                        for (int i = 0; i < DynamicReportGridView.HeaderRow.Cells.Count; i++)
                        {
                            worksheet.Cell(currentRow, i + 1).Value = DynamicReportGridView.HeaderRow.Cells[i].Text;
                            worksheet.Cell(currentRow, i + 1).Style.Font.Bold = true;
                            worksheet.Cell(currentRow, i + 1).Style.Fill.BackgroundColor = XLColor.LightGray;
                        }

                        foreach (GridViewRow gridViewRow in DynamicReportGridView.Rows)
                        {
                            currentRow++;
                            for (int i = 0; i < gridViewRow.Cells.Count; i++)
                            {
                                worksheet.Cell(currentRow, i + 1).Value = gridViewRow.Cells[i].Text;
                            }
                        }

                        worksheet.Columns().AdjustToContents();

                        Response.Clear();
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.AddHeader("content-disposition", "attachment;filename=" + reportName + ".xlsx");
                        Response.Buffer = true;
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);

                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            workbook.SaveAs(memoryStream);
                            memoryStream.WriteTo(Response.OutputStream);
                            Response.End();
                        }
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert", $"alert('An error occurred: {ex.Message}');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('No data available to export.');", true);
            }
        }
    }
}