using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using System.Drawing;
using System.Net.Mail;

namespace AMS
{
    public partial class ForgotCredentials : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cookysFnd();
                ViewState["ClientDetail"] = getIP();
            }
        }
        public void cookysFnd()
        {
            HttpCookie userin4ck = Request.Cookies["SzxWNHuO4XCyfPMBrVASxNrPPA"];
            if (userin4ck != null)
            {
                Response.Redirect("~/Default.aspx", false);
            }
            else
            {
                //Do nothing
            }
        }
        protected void CredBTN_Click(object sender, EventArgs e)
        {
            ErrTB.ForeColor = Color.Red;
            if (EmailTB.Text.Trim() == "")
            {
                ErrTB.Text = "Enter Registerd Email!";
            }
            else
            {
                GetUser();
            }
        }
        public void GetUser()
        {
            try
            {
                DataTable dt = new DataTable();
                Serve apir = new Serve();
                dt = apir.getCredentialsByEmail("getCredentialsByEmail", EmailTB.Text.ToLower().Trim());

                if (dt.Rows.Count > 0)
                {
                    ErrTB.ForeColor = Color.Green;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + "Check your email inbox for view your account details." + "');", true);
                    ErrTB.Text = "Check your email inbox for view your account details.";
                }
                else
                {
                    EmailTB.Focus();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + "Email not found!" + "')", true);
                    ErrTB.Text = "Email not found!";
                }
            }
            catch (Exception ex)
            {
                ErrTB.ForeColor = Color.Red; ErrTB.Text = "Email not found!";
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + ex.Message + "');", true);
            }
        }

        public string getIP()
        {
            try
            {
                Uri lnk = new Uri("https://api.find-ip.net/widget.js?width=240&");
                var http = (HttpWebRequest)WebRequest.Create(lnk);
                http.KeepAlive = true;
                http.PreAuthenticate = true;
                http.AllowAutoRedirect = true;
                string result = "";
                using ((HttpWebResponse)http.GetResponse())
                {
                    StreamReader sr = new StreamReader(http.GetResponse().GetResponseStream());
                    result = sr.ReadToEnd().Trim();
                    string[] resultColl_temp = Regex.Split(result, "_blank\">");
                    string[] resultCollection = Regex.Split(resultColl_temp[1].ToString(), "</div></a>");
                    string[] resultLang = Regex.Split(resultCollection[0].ToString(), "<div>Language:");
                    string[] resultdiv = Regex.Split(resultLang[0].ToString(), "<div>");
                    string[] resultb = Regex.Split(resultdiv[1].ToString() + resultdiv[2].ToString() + resultdiv[3].ToString() + resultdiv[4].ToString(), "<b>");
                    string[] resultbf = Regex.Split(resultb[0].ToString() + resultb[1].ToString() + resultb[2].ToString() + resultb[3].ToString() + resultb[4].ToString(), "</b>");
                    string[] resultdivt = Regex.Split(resultbf[0].ToString() + resultbf[1].ToString() + resultbf[2].ToString() + resultbf[3].ToString(), "</div>");
                    string[] resultdima = Regex.Split(resultdivt[1].ToString(), " <img");
                    result = resultdivt[0].ToString() + "&nbsp;|&nbsp;" + resultdima[0].ToString() + "&nbsp;|&nbsp;" + resultdivt[2].ToString() + "&nbsp;|&nbsp;" + resultdivt[3].ToString();

                    IPlbl.Text = resultdivt[0].ToString();
                    Conlbl.Text = resultdima[0].ToString();
                    Reglbl.Text = resultdivt[2].ToString();
                    Ctylbl.Text = resultdivt[3].ToString();
                    return result;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}