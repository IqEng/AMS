﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AMS
{
    public partial class _HitAd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string zoneId = ""; string Target = ""; string BannerLink = ""; string TargetFrame = ""; string BannerId = "";
            try
            {
                string mask = Request.QueryString["zoneId"];
                mask = mask.Replace(" ", "+");
                zoneId = Kripta.Decrypt(mask.Trim(), "mNwg0rIP8");//actually the banner id

                if (zoneId != null)
                {
                    DataTable dt = new DataTable();
                    Serve apir = new Serve();
                    dt = apir.getDetailsByBannerId("getDetailsByBannerId", Convert.ToInt16(zoneId));

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            BannerLink = row["BannerLink"].ToString().Trim();
                            Target = row["Target"].ToString().Trim();
                            BannerId = row["Id"].ToString().Trim();
                            TargetFrame = row["TargetFrame"].ToString().Trim();
                        }

                        apir.insertClickCount("insertClickCount", Convert.ToInt16(BannerId));

                        string fullUrl = $"{BannerLink}?targetFrame={TargetFrame}&target={Target}";

                        Response.Redirect(fullUrl, false);
                    }
                    else
                    {
                        Response.Redirect("~/Default.aspx", false);
                    }
                }
                else
                {
                    Response.Redirect("~/Default.aspx", false);
                }
            }
            catch //(Exception ex)
            {
                Response.Redirect("~/Default.aspx", false);
            }
        }
    }
}