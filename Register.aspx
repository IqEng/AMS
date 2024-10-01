<%@ Page Title="Create Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AMS.Register" Async="true"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 100%; height: auto; background-image: url('Images/AdsBackground2.jpg'); background-repeat: no-repeat; background-size: cover; background-position: center; vertical-align: central;">
        <asp:UpdateProgress ID="UpdateProgress6" runat="server" AssociatedUpdatePanelID="UpdatePanel6">
            <ProgressTemplate>
                <div style="position: fixed; left: 0%; top: 0%; z-index: 999; height: 100%; width: 100%; border-style: none; background-color: Black; filter: alpha(opacity=60); opacity: 0.3; -moz-opacity: 0.5;">
                    <asp:Image ID="ImageLodinggif" Style="position: fixed; left: 48%; top: 48%; z-index: 1000;" runat="server" ImageUrl="~/Images/loading.gif" Width="86px" Height="86px"></asp:Image>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
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
                <div style="display: flex; justify-content: center; align-items: center; height: 110vh; background-position: center;">
                    <div class="masterpages">
                        <div style="text-align: center;">
                            <asp:HiddenField ID="HF" runat="server" />
                            <br />
                            <br />
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <img src="Images/AMS.png" style="height: 42px;" /><br />
                            <br />
                            <asp:Label ID="Label4" runat="server" Text="IQ - Ad Management System" ForeColor="White" Font-Size="17px"></asp:Label>
                            <div style="height: 23px;"></div>
                            <hr style="width: 23%; margin: 0 auto;" />
                            <h3>Create an Advertiser Account</h3>
                            <div style="height: 14px;"></div>
                            <asp:TextBox ID="NameTB" TabIndex="1" BackColor="Transparent" ondrop="return false" ondragover="return false" placeholder="Display Name Ex. Personal/ Org.*" MaxLength="100" TextMode="Search" Style="border-radius: 3px; color: white; border-color: gold; border-top-style: none; border-right-style: none; border-bottom-style: inset; border-width: thin; height: 24px; max-width: 32%; min-width: 280px; font-family: Calibri Light; word-spacing: 1px; letter-spacing: 0.5px;" runat="server"></asp:TextBox>
                            <div style="height: 14px;"></div>
                            <asp:DropDownList ID="SupportDDL" TabIndex="2" runat="server" Style="border-radius: 3px; background-color: Black; color: silver; border-color: gold; border-top-style: none; border-right-style: none; border-bottom-style: inset; border-width: thin; height: 24px; max-width: 32%; min-width: 280px; font-family: Calibri Light; word-spacing: 1px; letter-spacing: 0.5px;">
                                <asp:ListItem Text="Select the Support Agency" Selected="True" Value="0"></asp:ListItem>
                                <asp:ListItem Text="IQ -Digital Marketing" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Squared -Digital Marketing" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                            <div style="height: 14px;"></div>
                            <asp:TextBox ID="EmailTB" ToolTip="Enter valied email, You will receive Activation link to this email!" TabIndex="4" BackColor="Transparent" ondrop="return false" ondragover="return false" placeholder="Email*" TextMode="Email" MaxLength="50" Style="border-radius: 3px; color: white; border-color: gold; border-top-style: none; border-right-style: none; border-bottom-style: inset; border-width: thin; height: 24px; max-width: 32%; min-width: 280px; font-family: Calibri Light; word-spacing: 1px; letter-spacing: 0.5px;" runat="server"></asp:TextBox>
                            <div style="height: 14px;"></div>
                            <asp:TextBox ID="PhoneTB" TabIndex="5" BackColor="Transparent" ondrop="return false" ondragover="return false" placeholder="Phone Number*" TextMode="Phone" MaxLength="15" Style="border-radius: 3px; color: white; border-color: gold; border-top-style: none; border-right-style: none; border-bottom-style: inset; border-width: thin; height: 24px; max-width: 32%; min-width: 280px; font-family: Calibri Light; word-spacing: 1px; letter-spacing: 0.5px;" runat="server"></asp:TextBox>
                            <div style="height: 14px;"></div>
                            <asp:TextBox ID="AddressTB" TabIndex="6" BackColor="Transparent" ondrop="return false" ondragover="return false" placeholder="Address*" TextMode="MultiLine" MaxLength="150" Style="border-radius: 3px; color: white; border-color: gold; border-top-style: none; border-right-style: none; border-bottom-style: inset; border-width: thin; height: 50px; max-width: 32%; min-width: 280px; font-family: Calibri Light; word-spacing: 1px; letter-spacing: 0.5px;" runat="server"></asp:TextBox>
                            <div style="height: 14px;"></div>
                            <asp:TextBox ID="PasswordTB" ToolTip="In this field Uppser letter, Number, Special character and Lower letter combination is required!" TabIndex="7" BackColor="Transparent" ondrop="return false" ondragover="return false" placeholder="Password*" MaxLength="16" TextMode="Password" Style="border-radius: 3px; color: white; border-color: gold; border-top-style: none; border-right-style: none; border-bottom-style: inset; border-width: thin; height: 24px; max-width: 32%; min-width: 280px; font-family: Calibri Light; word-spacing: 1px; letter-spacing: 0.5px;" runat="server"></asp:TextBox>
                            <div style="height: 14px;"></div>
                            <asp:TextBox ID="RePasswordTB" ToolTip="In this field Uppser letter, Number, Special character and Lower letter combination is required!" TabIndex="8" BackColor="Transparent" ondrop="return false" ondragover="return false" placeholder="Re-Type Password*" MaxLength="16" TextMode="Password" Style="border-radius: 3px; color: white; border-color: gold; border-top-style: none; border-right-style: none; border-bottom-style: inset; border-width: thin; height: 24px; max-width: 32%; min-width: 280px; font-family: Calibri Light; word-spacing: 1px; letter-spacing: 0.5px;" runat="server"></asp:TextBox>
                            <div style="height: 21px;"></div>
                            <asp:CheckBox ID="TermsCheckBox" TabIndex="9" BackColor="Transparent" runat="server" Style="font-family: Calibri Light; word-spacing: 1px; letter-spacing: 0.5px; font-size: 12px;" /><font style="font-family: Calibri Light; word-spacing: 1px; letter-spacing: 0.5px; font-size: 12px;">&nbsp;BY CLICKEING THIS YOU ARE AGREEING TO THE&nbsp;</font><a href="Terms_and_Conditions.aspx" target="_blank" tabindex="10" style="letter-spacing: 0.07em; font-family: Calibri Light; word-spacing: 1px; letter-spacing: 0.5px; font-size: 12px; color: Blue;">TERMS</a>
                            <div style="height: 14px;"></div>
                            <asp:Label ID="ErrTB" runat="server" Height="15px" BackColor="Transparent" Text="" ForeColor="Red" Font-Size="Smaller"></asp:Label>
                            <div style="height: 21px;"></div>
                            <asp:Button CssClass="SBtn" TabIndex="11" Text="REGISTER" ID="RegBTN" OnClick="RegBTN_Click" runat="server" />
                            <div style="height: 14px;"></div>
                            <a href="Login.aspx" tabindex="12" style="font-family: Calibri Light; word-spacing: 1px; letter-spacing: 0.5px; letter-spacing: 0.08em; font-size: 12px; text-decoration: blink; color: orangered;">SIGN IN</a>
                            <br />
                            <br />
                        </div>
                    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
