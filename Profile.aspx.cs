using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace AMS
{
    public partial class _Profile : Page
    {
        String DName = ""; String AId = ""; String Address = ""; String Type = "";
        String Phone = ""; String Pic = ""; String Description = "";
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
                    Emailn.Value = Kripta.Decrypt(userin4ck["email"].Trim(), "PPA4XCyfPMBrVASxNr/8A").ToString().Trim();
                    profileEmail.Text = Emailn.Value;
                    DName = Kripta.Decrypt(userin4ck["dname"].Trim(), "PPA4XCyfPMBrVASxNr/8A").ToString().Trim();
                    profileName.Text = DName;
                    AId = Kripta.Decrypt(userin4ck["aId"].Trim(), "PPA4XCyfPMBrVASxNr/8A").ToString().Trim();
                    profileSupport.Text = AId;
                    Address = Kripta.Decrypt(userin4ck["addr"].Trim(), "PPA4XCyfPMBrVASxNr/8A").ToString().Trim();
                    profileAddress.Text = Address;
                    Type = Kripta.Decrypt(userin4ck["type"].Trim(), "PPA4XCyfPMBrVASxNr/8A").ToString().Trim();
                    Phone = Kripta.Decrypt(userin4ck["phone"].Trim(), "PPA4XCyfPMBrVASxNr/8A").ToString().Trim();
                    profilePhone.Text = Phone;
                    Pic = userin4ck["pic"].Trim();
                    if (Pic == "")
                    {
                        profileImageDisplay.ImageUrl = "~/Images/Default-profile.png";
                    }
                    else
                    {
                        profileImageDisplay.ImageUrl = "~/Uploads/" + Pic.Trim();
                    }
                    Description = Kripta.Decrypt(userin4ck["description"].Trim(), "PPA4XCyfPMBrVASxNr/8A").ToString().Trim();
                    profileDescription.Text = Description;
                }
            }
        }
        protected void UpdateProfileButton_Click(object sender, EventArgs e)
        {
            ErrTB.ForeColor = Color.Red;

            Serve apir = new Serve();
            string result = apir.updateProfileById("updateProfileById", profileDescription.Text, Convert.ToInt16(Idn.Value));

            if (result.Contains(" successful"))
            {
                ErrTB.ForeColor = Color.Green;
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + result + "');", true);
                ErrTB.Text = result;
            }
            else
            {
                ErrTB.ForeColor = Color.Red;
                ErrTB.Text = result;
            }
        }

        protected void DeleteAccountButton_Click(object sender, EventArgs e)
        {
            try
            {
                Serve apir = new Serve();
                string result = apir.deleteUserById("deleteUserById", Emailn.Value, Convert.ToInt16(Idn.Value));

                if (result.Contains(" successful"))
                {
                    ErrTB.ForeColor = Color.Green;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + result + "');", true);
                    ErrTB.Text = result;

                    HttpCookie userin4ck = Request.Cookies["SzxWNHuO4XCyfPMBrVASxNrPPA"];
                    if (userin4ck != null)
                    {
                        userin4ck.Expires = DateTime.Now.AddDays(-1); Session.Clear(); Session.Abandon();
                        Response.Cookies.Add(userin4ck);
                    }
                    Response.Redirect("~/Default.aspx", false);
                }
                else
                {
                    ErrTB.ForeColor = Color.Red;
                    ErrTB.Text = result;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + ex.Message + "');", true);
            }
        }

        protected void UpdatePassBtn_Click(object sender, EventArgs e)
        {
            Elbl.ForeColor = Color.Red;

            if ((profilePassword.Text.Trim().Length >= 1) && (newPassword.Text.Trim() == "" || profileRePassword.Text.Trim() == ""))
            {
                Elbl.Text = "Passwords do not match!";
            }
            else if (newPassword.Text.Trim().Length <= 7)
            {
                Elbl.Text = "Minimum length of the Password is 8 characters!";
            }
            else if (newPassword.Text.Trim() != profileRePassword.Text.Trim())
            {
                Elbl.Text = "Passwords do not match!";
            }
            else if (Regex.IsMatch(newPassword.Text.Trim(), "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?^[a-zA-Z0-9_@.-]).{8,}$") == false)
            {
                Elbl.Text = "Uppser letter, Number, Special character and Lower letter combination is required!";
            }
            else
            {
                string oldpass = Kripta.Encrypt(profilePassword.Text, "PPA4XCyfPMBrVASxNr/8A" + Emailn.Value).ToString().Trim();
                string newpass = Kripta.Encrypt(newPassword.Text, "PPA4XCyfPMBrVASxNr/8A" + Emailn.Value).ToString().Trim();

                Serve apir = new Serve();
                string result = apir.updatePasswordProfileById("updatePasswordProfileById", oldpass, newpass, Convert.ToInt16(Idn.Value));

                if (result.Contains(" successful"))
                {
                    Elbl.ForeColor = Color.Green;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + result + "');", true);
                    Elbl.Text = result;
                }
                else
                {
                    Elbl.ForeColor = Color.Red;
                    Elbl.Text = result;
                }

                profilePassword.Text = "";
                newPassword.Text = "";
                profileRePassword.Text = "";
            }
        }

        protected void UploadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (profileImage.HasFile)
                {
                    string fileExtension = System.IO.Path.GetExtension(profileImage.FileName).ToLower();
                    string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff" };
                    bool proceed;
                    if (Array.Exists(allowedExtensions, ext => ext == fileExtension))
                    {
                        if (profileImage.PostedFile.ContentLength <= 1002880)
                        {
                            proceed = true;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + "File size exceeds the 1MB limit!" + "');", true);
                            proceed = false;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + "Invalid file type. Only Image files are allowed!" + "');", true);
                        proceed = false;
                    }
                    if (proceed == true)
                    {
                        string fullPath = Server.MapPath("~/Uploads/" + profileImage.FileName);
                        string key = "";
                        if (profileImage.FileName.Length > 100)
                        {
                            key = GenerateRandomKey(64);
                            key = key.Substring(0, 100);
                            fullPath = Server.MapPath("~/Uploads/" + key);
                        }
                        string folderPath = Server.MapPath("~/Uploads/");

                        if (!System.IO.Directory.Exists(folderPath))
                        {
                            System.IO.Directory.CreateDirectory(folderPath);
                        }
                        string savePath = fullPath;
                        profileImage.SaveAs(savePath);

                        HttpCookie userin4ck = Request.Cookies["SzxWNHuO4XCyfPMBrVASxNrPPA"];
                        userin4ck["pic"] = profileImage.FileName;
                        Response.Cookies.Add(userin4ck);

                        profileImageDisplay.ImageUrl = "~/Uploads/" + profileImage.FileName;

                        Serve apir = new Serve();
                        string result = apir.updateProfileImageById("updateProfileImageById", profileImage.FileName, Convert.ToInt16(Idn.Value));

                        if (result.Contains(" successful"))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + "File uploaded successfully!" + "');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + result + "');", true);
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + "Select profile image!" + "');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + ex.Message + "');", true);
            }
        }
        private static string GenerateRandomKey(int length)
        {
            byte[] buff = new byte[length];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(buff);
            }
            return BitConverter.ToString(buff).Replace("-", "");
        }
    }
}