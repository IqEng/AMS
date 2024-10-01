using Antlr.Runtime.Misc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AMS
{
    public partial class DisplayBanner : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string zoneId = ""; string BannerId = ""; string CampaignId = ""; string WebsiteId = ""; string Target = ""; string BannerLink = "";
            string BannerTypeId = ""; string BannerSizeId = ""; string FileName = ""; string TargetFrame = ""; string Priority = "";
            try
            {
                zoneId = Request.QueryString["zoneId"];
                if (zoneId != null)
                {
                    DataTable dt = new DataTable();
                    Serve apir = new Serve();
                    dt = apir.getDetailsByZoneId("getDetailsByZoneId", Convert.ToInt16(zoneId));

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            BannerId = row["Id"].ToString().Trim(); Target = row["Target"].ToString().Trim(); FileName = row["FileName"].ToString().Trim();
                            BannerTypeId = row["BannerTypeId"].ToString().Trim();
                            CampaignId = row["CampaignId"].ToString().Trim(); WebsiteId = row["WebsiteId"].ToString().Trim();
                            BannerLink = row["BannerLink"].ToString().Trim(); BannerSizeId = row["BannerSizeId"].ToString().Trim();
                            TargetFrame = row["TargetFrame"].ToString().Trim(); Priority = row["Priority"].ToString().Trim();
                        }
                        if (BannerTypeId == "image")
                        {
                            Response.Write($@"
    <html>
    <body style='margin:0;padding:0;'>
        <a href='HitAd.aspx?zoneId={zoneId}&BannerLink' target='{Target}'>
            <img src='{"https://advertisementmanagementsystem.azurewebsites.net/Uploads/" + FileName}' alt='{BannerTypeId}' style='width:100%; height:100%;' />
        </a>
    </body>
    </html>");
                        }
                        else if (BannerTypeId == "html5")
                        {
                            Response.Write($@"
<html>
<body style='margin:0;padding:0;'>
    <div style='width:100%; height:100%; position:relative;'>
        <iframe src='{"https://advertisementmanagementsystem.azurewebsites.net/Uploads/" + FileName}' style='width:100%; height:100%; border:none;'></iframe>
        <a href='HitAd.aspx?zoneId={zoneId}' target='{Target}' style='position:absolute; top:0; left:0; width:100%; height:100%; background:transparent;'></a>
    </div>
</body>
</html>");
                        }
                        else if (BannerTypeId == "text")
                        {
                            Response.Write($@"
    <html>
    <body style='margin:0;padding:0; display:flex; align-items:center; justify-content:center; height:100vh;'>
        <a href='HitAd.aspx?zoneId={zoneId}' target='{Target}' style='text-decoration:none; color:black; font-size:24px;'>
            {FileName} <!-- Assuming FileName is used as the text content -->
        </a>
    </body>
    </html>");
                        }
                        else if (BannerTypeId == "video")
                        {
                            Response.Write($@"
    <html>
    <body style='margin:0;padding:0; position:relative;'>
        <video width='100%' height='100%' controls style='z-index: 1; position:relative;'>
            <source src='{"https://advertisementmanagementsystem.azurewebsites.net/Uploads/" + FileName}' type='video/mp4'>
            Your browser does not support the video tag.
        </video>
        <a href='{BannerLink}' target='{Target}' style='z-index: 2;'>
            <div style='position:absolute; top:0; left:0; width:100%; height:100%; background:transparent; cursor:pointer; z-index:2;'></div>
        </a>
    </body>
    </html>");
                        }
                        else
                        {
                            Response.Write($@"
    <html>
    <body style='margin:0;padding:0; display:flex; align-items:center; justify-content:center; height:100vh; background-color:#f0f0f0; color:#333; font-family:Arial, sans-serif;'>
        <div style='text-align:center;'>
            <p style='font-size:24px;'>Advertisement Space Available</p>
            <p style='font-size:16px;'>Contact us for more information.</p>
            <p style='font-size:16px;'>+94 (11) 7 101 606 | +94 777 00 45 45</p>
        </div>
    </body>
    </html>");
                        }
                    }
                    else
                    {
                        Response.Write($@"
    <html>
    <body style='margin:0;padding:0; display:flex; align-items:center; justify-content:center; height:100vh; background-color:#f0f0f0; color:#333; font-family:Arial, sans-serif;'>
        <div style='text-align:center;'>
            <p style='font-size:24px;'>Advertisement Space Available</p>
            <p style='font-size:16px;'>Contact us for more information.</p>
            <p style='font-size:16px;'>+94 (11) 7 101 606 | +94 777 00 45 45</p>
        </div>
    </body>
    </html>");
                    }
                }
                else
                {
                    Response.Write($@"
    <html>
    <body style='margin:0;padding:0; display:flex; align-items:center; justify-content:center; height:100vh; background-color:#f0f0f0; color:#333; font-family:Arial, sans-serif;'>
        <div style='text-align:center;'>
            <p style='font-size:24px;'>Advertisement Space Available</p>
            <p style='font-size:16px;'>Contact us for more information.</p>
            <p style='font-size:16px;'>+94 (11) 7 101 606 | +94 777 00 45 45</p>
        </div>
    </body>
    </html>");
                }
            }
            catch
            {
                Response.Write($@"
    <html>
    <body style='margin:0;padding:0; display:flex; align-items:center; justify-content:center; height:100vh; background-color:#f0f0f0; color:#333; font-family:Arial, sans-serif;'>
        <div style='text-align:center;'>
            <p style='font-size:24px;'>Advertisement Space Available</p>
            <p style='font-size:16px;'>Contact us for more information.</p>
            <p style='font-size:16px;'>+94 (11) 7 101 606 | +94 777 00 45 45</p>
        </div>
    </body>
    </html>");
            }
        }
    }
}