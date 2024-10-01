using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AMS
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Cache.SetCacheability(HttpCacheability.Public);
            //Response.Cache.SetExpires(DateTime.Now.AddSeconds(60)); // Cache for 60 seconds
            //Response.Cache.SetValidUntilExpires(true);

            if (!IsPostBack)
            {
                HttpCookie userin4ck = Request.Cookies["SzxWNHuO4XCyfPMBrVASxNrPPA"];
                if (userin4ck != null)
                {
                    LogoutBTN.Visible = true;
                    LoginBtn.Visible = false;
                }
                else
                {
                    LogoutBTN.Visible = false;
                    LoginBtn.Visible = true;
                }
            }
        }
    }
}