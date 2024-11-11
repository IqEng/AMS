<%@ Page Title="Help and Support" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact_us.aspx.cs" Inherits="AMS.Contactus" Async="true"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="position: relative; width: 100%; height: auto; background-image: url('Images/contact_us.jpg'); background-repeat: no-repeat; background-size: cover; background-position: center; overflow: hidden;"
        class="blurred-background">
        <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">
        <br />
        <asp:UpdateProgress ID="UpdateProgress9" runat="server" AssociatedUpdatePanelID="UpdatePanel9">
            <ProgressTemplate>
                <div style="position: fixed; left: 0%; top: 0%; z-index: 999; height: 100%; width: 100%; background-color: Black; opacity: 0.3;">
                    <asp:Image ID="ImageLodinggif" Style="position: fixed; left: 48%; top: 48%; z-index: 1000;" runat="server" ImageUrl="~/Images/loading.gif" Width="50px" Height="50px"></asp:Image>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
            <ContentTemplate>
                <div class="panel-header">Contact and Support</div>
                <div class="dashboard-section">
                    <div class="dashboard-item">
                        <h4>Contact Us</h4>
                        <asp:Panel ID="ContactPanel" runat="server">
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Placeholder="Your Name *" TabIndex="0" MaxLength="50" /><br />
                            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="form-control" Placeholder="Your Email *" TabIndex="1" MaxLength="50" /><br />
                            <asp:TextBox ID="txtSubject" runat="server" CssClass="form-control" Placeholder="Subject *" TabIndex="2" MaxLength="50" /><br />
                            <asp:TextBox ID="txtMessage" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" Placeholder="Your Message *" TabIndex="3" MaxLength="250" /><br />
                            <div class="form-group text-center">
                                <asp:Label ID="ErrLbl" runat="server" Height="15px" BackColor="Transparent" Text="" ForeColor="Red" Font-Size="Smaller"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="SendEmailButton" runat="server" CssClass="btn-primary" TabIndex="4" Text="Send Message" OnClick="SendEmailButton_Click" />
                            </div>
                        </asp:Panel>
                    </div>
                    <div class="dashboard-item">
                        <h4>Our Locations</h4>
                        <p><strong>IQ Sri Lanka</strong><br>LEVEL 6, 299, UNION PLACE, Colombo 00200, Sri Lanka<br>Phone: +94 (11) 7 101 606<br>Email: info@iq-global.com</p>
                        <hr />
                        <p><strong>IQ Dubai</strong><br>Yes Business Tower, Al Barsha Rd, Dubai, UAE<br>Email: info@iq-global.com</p>
                        <hr />
                        <p><strong>IQ Europe</strong><br>Utrechtsestraat 93-1, 1017VK, Amsterdam, Netherlands<br>Email: info@iq-global.com</p>
                        <hr />
                        <p><strong>General Inquiries</strong><br>Phone: +94 777 00 45 45<br>WhatsApp: Chat on WhatsApp</p>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
