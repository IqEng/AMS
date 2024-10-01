using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;

namespace AMS
{
    public partial class Contactus : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendEmailButton_Click(object sender, EventArgs e)
        {
            ErrLbl.ForeColor = Color.Red;

            if (txtName.Text.Trim() == "")
            {
                ErrLbl.Text = "Enter Your Name!";
            }
            else if (txtEmail.Text.Trim() == "")
            {
                ErrLbl.Text = "Enter Your Email!";
            }
            else if (txtSubject.Text.Trim() == "")
            {
                ErrLbl.Text = "Enter Subject!";
            }
            else if (txtMessage.Text.Trim() == "")
            {
                ErrLbl.Text = "Enter Message!";
            }
            else
            {
                _ = EmailAsync();
            }
        }
        public async Task EmailAsync()
        {
            bool x = await SendEmailAsync(txtSubject.Text.Trim(), txtMessage.Text.Trim(), txtName.Text.Trim(), txtEmail.Text.Trim());

            if (x == true)
            {
                ErrLbl.ForeColor = Color.Green;
                ErrLbl.Text = "Email sent! one of our agents will contact you soon!";

                txtName.Text = "";
                txtEmail.Text = "";
                txtSubject.Text = "";
                txtMessage.Text = "";
            }
            else
            {
                ErrLbl.ForeColor = Color.Red;
                ErrLbl.Text = "Email sending error, Please try again later!";
            }
        }
        public async Task<bool> SendEmailAsync(string subject, string message, string nme, string email_)
        {
            try
            {
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress("alert@iq.lk"),
                    Subject = subject,
                    IsBodyHtml = true
                };
                mail.To.Add("shanaka@iq-global.com");

                string INNOVATION_QUOTIENT = "<a href='https://advertisementmanagementsystem.azurewebsites.net/Terms_and_Conditions.aspx' style='color: #007BFF; text-decoration: none; font-weight: bold;'>Terms</a>";

                mail.Body = "<div style='background-color: #f4f4f4; color: #333; font-family: Arial, sans-serif; padding: 20px;'>"
                            + "<div style='background-color: #ffffff; border: 1px solid #ddd; border-radius: 8px; padding: 20px; box-shadow: 0 0 10px rgba(0,0,0,0.1);'>"
                            + "<h2 style='color: #007BFF;'>Hello,</h2>"
                            + "<p style='font-size: 16px; color: #555;'>We hope this message finds you well. This is an alert email to inform you of important information.</p>"
                            + "<hr style='border: 0; border-top: 2px solid #007BFF; margin: 20px 0;'>"
                            + "<p><strong style='color: #333;'>Sender:</strong> <span style='color: #555;'>" + nme.ToUpper() + "</span></p>"
                            + "<p><strong style='color: #333;'>Sender's Email:</strong> <span style='color: #555;'>" + email_.ToLower() + "</span></p>"
                            + "<hr style='border: 0; border-top: 2px solid #007BFF; margin: 20px 0;'>"
                            + "<p><strong style='color: #333;'>Original Message:</strong></p>"
                            + "<p style='background-color: #f9f9f9; border: 1px solid #ddd; border-radius: 4px; padding: 10px; color: #555;'>" + message + "</p>"
                            + "<hr style='border: 0; border-top: 2px solid #007BFF; margin: 20px 0;'>"
                            + "<p>Best Regards,<br /><strong>IT Team</strong><br />INNOVATION QUOTIENT</p>"
                            + "<p style='font-size: 14px; color: #777;'><strong>Note:</strong> This is an auto-generated email. Please do not reply to this message. - " + INNOVATION_QUOTIENT + "</p>"
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