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
using System.Xml.Linq;

namespace AMS
{
    public partial class _Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cookysFnd();
            }
        }
        public void cookysFnd()
        {
            HttpCookie userin4ck = Request.Cookies["SzxWNHuO4XCyfPMBrVASxNrPPA"];
            if (userin4ck != null)
            {
                Response.Redirect("~/Dashboard.aspx", false);
            }
            else
            {
                //Do nothing
            }
        }
        public void LoginUser()
        {
            try
            {
                string pass = Kripta.Encrypt(PasswordTB.Text, "PPA4XCyfPMBrVASxNr/8A" + EmailTB.Text.ToLower().Trim()).ToString().Trim();

                DataTable dt = new DataTable();
                Serve apir = new Serve();
                dt = apir.getUserDetails("getUserDetails", EmailTB.Text.ToLower().Trim(), pass);

                if (dt.Rows.Count > 0)
                {
                    string Id = ""; string Email = ""; string DName = ""; string AId = ""; string Address = ""; string Type = "";
                    string Phone = ""; string Pic = ""; string Description = "";

                    foreach (DataRow row in dt.Rows)
                    {
                        Id = row["Id"].ToString().Trim();
                        Email = row["Email"].ToString().Trim();
                        DName = row["DName"].ToString().Trim();
                        AId = row["AId"].ToString().Trim();
                        Address = row["Address"].ToString().Trim();
                        Phone = row["Phone"].ToString().Trim();
                        Pic = row["Pic"].ToString().Trim();
                        Description = row["Description"].ToString().Trim();
                    }

                    HttpCookie userin4ck = new HttpCookie("SzxWNHuO4XCyfPMBrVASxNrPPA");

                    if (Pic == "")
                    {
                        Pic = string.Empty;
                    }
                    Id = Kripta.Encrypt(Id.Trim(), "PPA4XCyfPMBrVASxNr/8A").ToString().Trim();
                    Email = Kripta.Encrypt(Email.Trim(), "PPA4XCyfPMBrVASxNr/8A").ToString().Trim();
                    DName = Kripta.Encrypt(DName.Trim(), "PPA4XCyfPMBrVASxNr/8A").ToString().Trim();
                    AId = Kripta.Encrypt(AId.Trim(), "PPA4XCyfPMBrVASxNr/8A").ToString().Trim();
                    Address = Kripta.Encrypt(Address.Trim(), "PPA4XCyfPMBrVASxNr/8A").ToString().Trim();
                    Type = Kripta.Encrypt(Type.Trim(), "PPA4XCyfPMBrVASxNr/8A").ToString().Trim();
                    Phone = Kripta.Encrypt(Phone.Trim(), "PPA4XCyfPMBrVASxNr/8A").ToString().Trim();

                    Description = Kripta.Encrypt(Description.Trim(), "PPA4XCyfPMBrVASxNr/8A").ToString().Trim();

                    userin4ck["id"] = Id;
                    userin4ck["email"] = Email;
                    userin4ck["dname"] = DName;
                    userin4ck["aId"] = AId;
                    userin4ck["addr"] = Address;
                    userin4ck["type"] = Type;
                    userin4ck["phone"] = Phone;
                    userin4ck["pic"] = Pic;
                    userin4ck["description"] = Description;

                    Response.Cookies.Add(userin4ck);

                    Session["SesE"] = Pic;

                    EmailTB.Text = "";
                    PasswordTB.Text = "";

                    Response.Redirect("~/Dashboard", false);
                }
                else
                {
                    PasswordTB.Focus();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + "Wrong credentials!" + "')", true);
                    ErrTB.Text = "Wrong credentials!";
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + ex.Message + "');", true);
            }
        }
        protected void LoginBTN_Click(object sender, EventArgs e)
        {
            string pass = PasswordTB.Text.Trim();

            if (EmailTB.Text.Trim() == "")
            {
                ErrTB.Text = "Enter your Email!";
            }
            else if (PasswordTB.Text.Trim() == "")
            {
                ErrTB.Text = "Enter your Password!";
            }
            else if ((EmailTB.Text != "") && (PasswordTB.Text != ""))
            {
                LoginUser();
            }
        }
    }
}