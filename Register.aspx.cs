using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace AMS
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void RegBTN_Click(object sender, EventArgs e)
        {
            ErrTB.ForeColor = Color.Red;

            if (NameTB.Text.Trim() == "")
            {
                ErrTB.Text = "Enter your Display name!";
            }
            else if (SupportDDL.SelectedValue.ToString() == "0")
            {
                ErrTB.Text = "Enter Support Agency No!";
            }
            else if (EmailTB.Text.Trim() == "")
            {
                ErrTB.Text = "Enter your Email!";
            }
            else if (PhoneTB.Text.Trim() == "")
            {
                ErrTB.Text = "Enter your Phone!";
            }
            else if (AddressTB.Text.Trim() == "")
            {
                ErrTB.Text = "Enter Address!";
            }
            else if (PasswordTB.Text.Trim() == "")
            {
                ErrTB.Text = "Enter your Password!";
            }
            else if (RePasswordTB.Text.Trim() == "")
            {
                ErrTB.Text = "Re-type your Password!";
            }
            else if (RePasswordTB.Text.Trim() != PasswordTB.Text.Trim())
            {
                ErrTB.Text = "Passwords do not match!";
            }
            else if (PasswordTB.Text.Trim().Length <= 7)
            {
                ErrTB.Text = "Minimum length of the Password is 8 characters!";
            }
            else if (Regex.IsMatch(PasswordTB.Text.Trim(), "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?^[a-zA-Z0-9_@.-]).{8,}$") == false)
            {
                ErrTB.Text = "Uppser letter, Number, Special character and Lower letter combination is required!";
            }
            else if (TermsCheckBox.Checked != true)
            {
                ErrTB.Text = "Please confirm that you have read and agreed to the AMS Terms and Conditions!";
            }
            else
            {
                Insertuser(EmailTB.Text.Trim(), PasswordTB.Text.Trim(), NameTB.Text.Trim(), SupportDDL.SelectedValue.ToString(), PhoneTB.Text.Trim(), AddressTB.Text.Trim());
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
        public async Task<string> Insertuser(string EmailTB_, string PasswordTB_, string DName, string AId, string Phone, string Address)
        {
            try
            {
                string key = GenerateRandomKey(64);

                if (key.Length > 50)
                {
                    key = key.Substring(0, 50);
                }

                string pass = Kripta.Encrypt(PasswordTB_, "PPA4XCyfPMBrVASxNr/8A" + EmailTB_.ToLower().Trim()).ToString().Trim();

                Serve apir = new Serve();
                string result = apir.insertUser("insertUser", EmailTB_.ToLower().Trim(), pass, DName, AId, Phone, key, Address);

                if (result.Contains(" successful"))
                {
                    ErrTB.ForeColor = Color.Green;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + result + "');", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + "Check your email inbox and please click on the link to activate your account." + "');", true);
                    ErrTB.Text = "Please activate your account.";

                    await SendEmailAsync(DName, EmailTB_, PasswordTB_, key);
                }
                else
                {
                    ErrTB.ForeColor = Color.Red;
                    ErrTB.Text = result;
                }

                return result;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('" + ex.Message + "');", true);
                return ex.Message;
            }
        }

        public async Task<bool> SendEmailAsync(string nme, string email_, string password_, string key)
        {
            try
            {
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress("alert@iq.lk"),
                    IsBodyHtml = true
                };
                mail.To.Add(email_);

                mail.Subject = "Welcome to AMS - Account Activation";
                string LINK = "<a href='https://advertisementmanagementsystem.azurewebsites.net/Terms_and_Conditions.aspx' style='color: #007BFF; text-decoration: none;'>Terms</a>";
                string ALINK = "<a href='https://advertisementmanagementsystem.azurewebsites.net/Val.aspx?Cpara=" + key + "' style='color: #007BFF; text-decoration: none; font-weight: bold;'>Activate My Account</a>";
                string cdetail = "<p style='font-size: 16px; color: #555;'>Please use the following activation link: " + ALINK + "</p>";

                mail.Body = "<div style='background-color: #f4f4f4; color: #333; font-family: Arial, sans-serif; padding: 20px;'>"
                            + "<div style='background-color: #ffffff; border: 1px solid #ddd; border-radius: 8px; padding: 20px; box-shadow: 0 0 10px rgba(0,0,0,0.1);'>"
                            + "<h2 style='color: #007BFF;'>Hello <strong>" + nme + "</strong>,</h2>"
                            + "<p style='font-size: 16px; color: #555;'>Welcome to AMS!</p>"
                            + "<p style='font-size: 16px; color: #555;'>Thank you for your interest in our advertisement management system, the newest ad management service provider in Sri Lanka!</p>"
                            + "<p style='font-size: 16px; color: #555;'>Here are your credentials:</p>"
                            + "<ul style='font-size: 16px; color: #555;'>"
                            + "<li><strong>User Name:</strong> " + email_ + "</li>"
                            + "<li><strong>Password:</strong> " + password_ + "</li>"
                            + "</ul>"
                            + cdetail
                            + "<p style='font-size: 16px; color: #555;'>For more information, please review our " + LINK + ".</p>"
                            + "<p style='font-size: 16px; color: #555;'>Best Regards,<br /><strong>IT Team</strong><br />INNOVATION QUOTIENT</p>"
                            + "<p style='font-size: 14px; color: #777;'><strong>Note:</strong> This is an auto-generated email. Please do not reply to this message. For any inquiries, contact us at <a href='mailto:hello@iq-global.com' style='color: #007BFF;'>hello@iq-global.com</a>.</p>"
                            + "</div></div>";

                using (var SmtpServer = new SmtpClient("smtp.gmail.com"))
                {
                    SmtpServer.Port = 587;
                    SmtpServer.EnableSsl = true;
                    SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.Credentials = new NetworkCredential("alert@iq.lk", "pyme mtyw auqi joal");
                    SmtpServer.Timeout = 30000;

                    await SmtpServer.SendMailAsync(mail);
                }

                // Return true if email was sent successfully
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (you might want to log it somewhere)
                Console.WriteLine("Error sending email: " + ex.Message);

                // Return false if there was an error
                return false;
            }
        }
    }
}