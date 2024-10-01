using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AMS
{
    public partial class _SignOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie userin4ck = Request.Cookies["SzxWNHuO4XCyfPMBrVASxNrPPA"];
            if (userin4ck != null)
            {
                userin4ck.Expires = DateTime.Now.AddDays(-1); Session.Clear(); Session.Abandon();
                Response.Cookies.Add(userin4ck);
            }
            Response.Redirect("~/Default.aspx", false);
        }
    }
}