using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AMS
{
    public partial class SPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var vlu = Context.Session["Msg"];
                if (vlu != null)
                {
                    Msgid.InnerText = Session["Msg"].ToString().Replace("\"", "");
                }
                else
                {
                    Msgid.InnerText = "";
                }
            }
            catch (Exception ex)
            {
                Msgid.InnerText = ex.Message;
            }
        }

        protected void HomeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default", false);
        }
    }
}