using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AMS
{
    public partial class Val : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cpara = "";
            try
            {
                var vlu = Request.QueryString["Cpara"];
                if (vlu != null)
                {
                    cpara = Request.QueryString["Cpara"].Trim();
                    Vdate(cpara);
                }
                else
                {
                    Response.Redirect("~/Default", false);
                }
            }
            catch
            {
                Response.Redirect("~/Default", false);
            }
        }
        public void Vdate(string ema)
        {
            try
            {
                Serve apir = new Serve();
                string result = apir.updateUserByActivationCode("updateUserByActivationCode", ema.Trim());

                if (result.Contains(" successful"))
                {
                    Session["Msg"] = "Account has been activated successfully!";
                    Response.Redirect("SPage.aspx", false);
                }
                else
                {
                    Session["Msg"] = result;
                    Response.Redirect("SPage.aspx", false);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + ex.Message + "');", true);
            }
        }
    }
}