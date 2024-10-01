<%@ Page Title="User Accounts" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="AMS._Profile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="position: relative; width: 100%; height: auto; background-image: url('Images/profile.jpg'); background-repeat: no-repeat; background-size: cover; background-position: center; overflow: hidden;"
        class="blurred-background">
        <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">
        <br />
        <asp:HiddenField ID="Emailn" runat="server" Value="InitialValue" />
        <asp:HiddenField ID="Idn" runat="server" Value="InitialValue" />
        <asp:UpdateProgress ID="UpdateProgress11" runat="server" AssociatedUpdatePanelID="UpdatePanel11">
            <ProgressTemplate>
                <div style="position: fixed; left: 0%; top: 0%; z-index: 999; height: 100%; width: 100%; border-style: none; background-color: Black; filter: alpha(opacity=60); opacity: 0.3; -moz-opacity: 0.5;">
                    <asp:Image ID="ImageLodinggif" Style="position: fixed; left: 48%; top: 48%; z-index: 1000;" runat="server" ImageUrl="~/Images/loading.gif" Width="86px" Height="86px"></asp:Image>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <div class="panel-header">User Account Management</div>
        <div class="dashboard-section">
            <div class="dashboard-item">
                <h4>Your Profile</h4>
                <asp:Panel ID="ProfilePanel" runat="server">
                    <div>
                        <script type="text/javascript">
                            function previewFile() {
                                var preview = document.querySelector('#<%= profileImageDisplay.ClientID %>');
                                var file = document.querySelector('#<%=profileImage.ClientID %>').files[0];
                                var reader = new FileReader();

                                reader.onloadend = function () {
                                    preview.src = reader.result;
                                }
                                if (file) {
                                    reader.readAsDataURL(file);
                                } else {
                                    Image1.src = "";
                                }
                            }
                            function ofd1() {
                                $("#profileImage").click();
                            }
                        </script>
                        <div class="text-center">
                            <asp:Image ID="profileImageDisplay" Width="170px" Height="170px" runat="server" ImageUrl="~/Images/Default-profile.png" AlternateText="Profile Image" CssClass="profile-image" />
                            <p class="profile-label">Profile Image</p>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label1" runat="server" Text="Update Profile Image:" />
                            <asp:FileUpload ID="profileImage" runat="server" onchange="previewFile();" accept=".png,.jpg,.jpeg,.gif" CssClass="form-control" Width="300px" />
                            <asp:Button ID="UploadBtn" runat="server" CssClass="btn-primary" Text="Upload" OnClick="UploadBtn_Click" />
                        </div>
                    </div>
                    <hr />
                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                        <ContentTemplate>
                            <div>
                                <div class="form-group">
                                    <asp:Label ID="lblProfileName" runat="server" Text="Display Name:" />
                                    <asp:TextBox ID="profileName" runat="server" CssClass="form-control" ForeColor="Black" Placeholder="Display Name Ex. Personal/ Org.*" Enabled="false" />
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="lblProfileDescription" runat="server" Text="Profile Description:" />
                                    <asp:TextBox ID="profileDescription" runat="server" CssClass="form-control" ForeColor="Black" TextMode="MultiLine" MaxLength="500" Placeholder="Add a brief description about yourself" />
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="lblProfileSupport" runat="server" Text="Support Agency No:" />
                                    <asp:TextBox ID="profileSupport" runat="server" CssClass="form-control" ForeColor="Black" Placeholder="Support Agency No*" Enabled="false" />
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="lblProfileEmail" runat="server" Text="Email:" />
                                    <asp:TextBox ID="profileEmail" runat="server" CssClass="form-control" ForeColor="Black" Placeholder="Email*" Enabled="false" />
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="lblProfilePhone" runat="server" Text="Phone Number:" />
                                    <asp:TextBox ID="profilePhone" runat="server" CssClass="form-control" ForeColor="Black" Placeholder="Phone Number*" Enabled="false" />
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="lblProfileAddress" runat="server" Text="Address:" />
                                    <asp:TextBox ID="profileAddress" runat="server" CssClass="form-control" ForeColor="Black" Placeholder="Address*" TextMode="MultiLine" Enabled="false" />
                                </div>
                                <div class="form-group text-center">
                                    <asp:Label ID="ErrTB" runat="server" Height="15px" BackColor="Transparent" Text="" ForeColor="Red" Font-Size="Smaller"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <asp:Button ID="UpdateProfileButton" runat="server" CssClass="btn-primary" Text="Update Profile" OnClick="UpdateProfileButton_Click" />
                                    <asp:Button ID="DeleteAccountButton" runat="server" CssClass="btn-primary" Text="Delete Account"
                                        OnClientClick="return confirm('Are you sure you want to delete your account?');"
                                        OnClick="DeleteAccountButton_Click" />
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </div>
            <div class="dashboard-item" style="max-height: 410px;">
                <h4>Reset Password</h4>
                <div class="form-group">
                    <asp:Label ID="lblProfilePassword" runat="server" Text="Current Password:" />
                    <asp:TextBox ID="profilePassword" runat="server" CssClass="form-control" Text="" Placeholder="Password*" TextMode="Password" />
                </div>
                <div class="form-group">
                    <asp:Label ID="lblNewPassword" runat="server" Text="New Password:" />
                    <asp:TextBox ID="newPassword" runat="server" CssClass="form-control" Placeholder="Password*" TextMode="Password" />
                </div>
                <div class="form-group">
                    <asp:Label ID="lblProfileRePassword" runat="server" Text="Re-Type New Password:" />
                    <asp:TextBox ID="profileRePassword" runat="server" CssClass="form-control" Placeholder="Re-Type Password*" TextMode="Password" />
                </div>
                <div class="form-group text-center">
                    <asp:Label ID="Elbl" runat="server" Height="15px" BackColor="Transparent" Text="" ForeColor="Red" Font-Size="Smaller"></asp:Label>
                </div>
                <div class="form-group">
                    <asp:Button ID="UpdatePassBtn" runat="server" CssClass="btn-primary" Text="Reset Password" OnClick="UpdatePassBtn_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
