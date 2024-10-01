<%@ Page Title="Sign In" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AMS._Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 100%; height: auto; background-image: url('Images/AdsBackground.jpg'); background-repeat: no-repeat; background-size: cover; background-position: center; vertical-align: central;">
        <asp:UpdateProgress ID="UpdateProgress4" runat="server" AssociatedUpdatePanelID="UpdatePanel4">
            <ProgressTemplate>
                <div style="position: fixed; left: 0%; top: 0%; z-index: 999; height: 100%; width: 100%; border-style: none; background-color: Black; filter: alpha(opacity=60); opacity: 0.3; -moz-opacity: 0.5;">
                    <asp:Image ID="ImageLodinggif" Style="position: fixed; left: 48%; top: 48%; z-index: 1000;" runat="server" ImageUrl="~/Images/loading.gif" Width="86px" Height="86px"></asp:Image>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <style>
                    .SBtn {
                        font-size: 14px;
                        width: 50%;
                        height: 42px;
                        color: White;
                        background-color: orangered;
                        letter-spacing: 0.08em;
                        cursor: pointer;
                        border-style: none;
                        font-family: Calibri Light;
                        word-spacing: 1px;
                        letter-spacing: 0.5px;
                        border-radius: 23px;
                    }

                        .SBtn:focus {
                            letter-spacing: 0.12em;
                            transition: letter-spacing 0.2s 0.05s ease;
                            cursor: pointer;
                            border-radius: 23px;
                        }

                        .SBtn:hover {
                            letter-spacing: 0.12em;
                            transition: letter-spacing 0.2s 0.05s ease;
                            cursor: pointer;
                            border-radius: 23px;
                        }
                </style>
                <div style="display: flex; justify-content: center; align-items: center; height: 100vh; background-position: center;">
                    <div class="masterpages">
                        <div style="text-align: center;">
                            <asp:HiddenField ID="HF" runat="server" />
                            <br />
                            <br />
                            <img src="Images/AMS.png" style="height: 42px;" /><br />
                            <br />
                            <asp:Label ID="Label4" runat="server" Text="IQ - Ad Management System" ForeColor="White" Font-Size="17px"></asp:Label>
                            <div style="height: 23px;"></div>
                            <hr style="width: 23%; margin: 0 auto;" />
                            <h3>Sign In</h3>
                            <div style="height: 14px;"></div>
                            <asp:TextBox ID="EmailTB" placeholder="Email *" MaxLength="50" BackColor="Transparent" TextMode="Email" TabIndex="1" ondrop="return false" ondragover="return false" Style="border-radius: 3px; color: white; border-color: gold; border-top-style: none; border-right-style: none; border-bottom-style: inset; border-width: thin; height: 24px; max-width: 32%; min-width: 280px; font-family: Calibri Light; word-spacing: 1px; letter-spacing: 0.5px;" runat="server"></asp:TextBox>
                            <div style="height: 23px;"></div>
                            <asp:TextBox ID="PasswordTB" placeholder="Password *" MaxLength="16" BackColor="Transparent" TextMode="Password" TabIndex="2" ondrop="return false" ondragover="return false" Style="border-radius: 3px; color: white; border-color: gold; border-top-style: none; border-right-style: none; border-bottom-style: inset; border-width: thin; height: 24px; max-width: 32%; min-width: 280px; font-family: Calibri Light; word-spacing: 1px; letter-spacing: 0.5px;" runat="server"></asp:TextBox>
                            <div style="height: 23px;"></div>
                            <asp:Label ID="ErrTB" BackColor="Transparent" runat="server" Height="15px" Text="" ForeColor="Red" Font-Size="Smaller"></asp:Label>
                            <div style="height: 23px;"></div>
                            <asp:Button CssClass="SBtn" ID="LoginBTN" Text="ENTER SITE" runat="server" TabIndex="3" OnClick="LoginBTN_Click" />
                            <div style="height: 14px;"></div>
                            <div style="height: 140px; text-align: center;">
                                <hr style="width: 23%; margin: 0 auto;" />
                                <asp:Label ID="Label3" runat="server" Height="15px" Text="FORGOT CREDENTIALS?&nbsp;" ForeColor="Silver" Font-Size="12px"></asp:Label>
                                <a href="ForgotCredentials.aspx" target="_blank" tabindex="4" style="font-family: Calibri Light; word-spacing: 1px; letter-spacing: 0.5px; letter-spacing: 0.08em; font-size: 12px; text-decoration: none; color: darkorange;">RESET</a>
                                <div style="height: 23px;"></div>
                                <asp:Label ID="Label1" runat="server" Height="15px" Text="DON’T HAVE AN ACCOUNT?" ForeColor="Silver" Font-Size="12px"></asp:Label><br />
                                <a href="Register.aspx" target="_blank" tabindex="5" style="font-family: Calibri Light; word-spacing: 1px; letter-spacing: 0.5px; letter-spacing: 0.08em; font-size: 12px; text-decoration: none; color: orangered;">CREATE ACCOUNT</a>
                            <br />
                            <br />
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
