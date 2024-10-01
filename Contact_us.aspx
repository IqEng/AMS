<%@ Page Title="Help and Support" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact_us.aspx.cs" Inherits="AMS.Contactus" Async="true"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="position: relative; width: 100%; height: auto; background-image: url('Images/contact_us.jpg'); background-repeat: no-repeat; background-size: cover; background-position: center; overflow: hidden;"
        class="blurred-background">
        <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">
        <br />
        <asp:UpdateProgress ID="UpdateProgress9" runat="server" AssociatedUpdatePanelID="UpdatePanel9">
            <ProgressTemplate>
                <div style="position: fixed; left: 0%; top: 0%; z-index: 999; height: 100%; width: 100%; border-style: none; background-color: Black; filter: alpha(opacity=60); opacity: 0.3; -moz-opacity: 0.5;">
                    <asp:Image ID="ImageLodinggif" Style="position: fixed; left: 48%; top: 48%; z-index: 1000;" runat="server" ImageUrl="~/Images/loading.gif" Width="86px" Height="86px"></asp:Image>
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
                            <asp:TextBox ID="txtMessage" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" Placeholder="Your Message *" TabIndex="3" MaxLength="250" OnKeyUp="updateCharCount()" /><br />
                            <%--<asp:Label ID="charCountLabel" runat="server" CssClass="form-control" Text="250 characters left" />--%>
                            <div class="form-group text-center">
                                <asp:Label ID="ErrLbl" runat="server" Height="15px" BackColor="Transparent" Text="" ForeColor="Red" Font-Size="Smaller"></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:Button ID="SendEmailButton" runat="server" CssClass="btn-primary" TabIndex="4" Text="Send Message" OnClick="SendEmailButton_Click" />
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
<%--    <script type="text/javascript">
        function updateCharCount() {
            var txtMessage = document.getElementById('<%= txtMessage.ClientID %>');
            var charCountLabel = document.getElementById('<%= charCountLabel.ClientID %>');
            var maxLength = parseInt(txtMessage.getAttribute('maxlength'));
            var currentLength = txtMessage.value.length;
            var charsLeft = maxLength - currentLength;
            charCountLabel.innerText = charsLeft + ' characters left';
        }

        document.addEventListener('DOMContentLoaded', function () {
            updateCharCount();
        });
    </script>--%>
</asp:Content>