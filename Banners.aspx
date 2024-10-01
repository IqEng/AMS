<%@ Page Title="Banner Management" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Banners.aspx.cs" Inherits="AMS._Banners" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="position: relative; width: 100%; height: auto; background-image: url('Images/banner.jpg'); background-repeat: no-repeat; background-size: cover; background-position: center; overflow: hidden;"
        class="blurred-background">
        <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">
        <br />
        <asp:HiddenField ID="Idn" runat="server" Value="InitialValue" />
        <asp:UpdateProgress ID="UpdateProgress7" runat="server" AssociatedUpdatePanelID="UpdatePanel7">
            <ProgressTemplate>
                <div style="position: fixed; left: 0%; top: 0%; z-index: 999; height: 100%; width: 100%; border-style: none; background-color: Black; filter: alpha(opacity=60); opacity: 0.3; -moz-opacity: 0.5;">
                    <asp:Image ID="ImageLodinggif" Style="position: fixed; left: 48%; top: 48%; z-index: 1000;" runat="server" ImageUrl="~/Images/loading.gif" Width="86px" Height="86px"></asp:Image>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <div class="panel-header">Banner Management</div>
        <div class="dashboard-section">
            <div class="dashboard-item">
                <h4>Add Banner</h4>
                <asp:Panel ID="Panel1" runat="server">
                    <div class="form-group">
                        <asp:Label ID="Label4" runat="server" Text="Campaign:" />
                        <asp:DropDownList ID="CampaignDDL" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblWebsite" runat="server" Text="Website:" />
                        <asp:DropDownList ID="WebsiteDDL" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" Text="Zone:" />
                        <asp:DropDownList ID="ZonesDDL" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <hr />
                    <asp:TextBox ID="txtBannerName" runat="server" CssClass="form-control" Placeholder="Banner Name*" MaxLength="23" />
                    <br />
                    <div class="form-group">
                        <asp:Label ID="Label5" runat="server" Text="Banner Type:"></asp:Label>
                        <asp:DropDownList ID="ddlBannerType" runat="server" CssClass="form-control">
                            <asp:ListItem Text="-Select-" Selected="True" Value="0" />
                            <asp:ListItem Text="HTML5" Value="html5" />
                            <asp:ListItem Text="Image" Value="image" />
                            <asp:ListItem Text="Text" Value="text" />
                            <asp:ListItem Text="Video" Value="video" />
                        </asp:DropDownList>
                    </div>
                </asp:Panel>
            </div>
            <div class="dashboard-item">
                <div class="form-group">
                    <asp:Label ID="lblSize" runat="server" Text="Banner Size:" />
                    <asp:DropDownList ID="ddlBannerSizeDDL" runat="server" CssClass="form-control">
                        <asp:ListItem Text="-Select-" Selected="True" Value="0" />
                        <asp:ListItem Text="Banner, Button or Rectangle" Value="Banner" />
                        <asp:ListItem Value="468x60" Text="IAB Full Banner (468 x 60)" />
                        <asp:ListItem Value="120x600" Text="IAB Skyscraper (120 x 600)" />
                        <asp:ListItem Value="728x90" Text="IAB Leaderboard (728 x 90)" />
                        <asp:ListItem Value="120x90" Text="IAB Button 1 (120 x 90)" />
                        <asp:ListItem Value="120x60" Text="IAB Button 2 (120 x 60)" />
                        <asp:ListItem Value="234x60" Text="IAB Half Banner (234 x 60)" />
                        <asp:ListItem Value="88x31" Text="IAB Micro Bar (88 x 31)" />
                        <asp:ListItem Value="125x125" Text="IAB Square Button (125 x 125)" />
                        <asp:ListItem Value="120x240" Text="IAB Vertical Banner (120 x 240)" />
                        <asp:ListItem Value="180x150" Text="IAB Rectangle (180 x 150)" />
                        <asp:ListItem Value="300x250" Text="IAB Medium Rectangle (300 x 250)" />
                        <asp:ListItem Value="336x280" Text="IAB Large Rectangle (336 x 280)" />
                        <asp:ListItem Value="240x400" Text="IAB Vertical Rectangle (240 x 400)" />
                        <asp:ListItem Value="250x250" Text="IAB Square Pop-up (250 x 250)" />
                        <asp:ListItem Value="160x600" Text="IAB Wide Skyscraper (160 x 600)" />
                        <asp:ListItem Value="720x300" Text="IAB Pop-Under (720 x 300)" />
                        <asp:ListItem Value="300x100" Text="IAB 3:1 Rectangle (300 x 100)" />
                    </asp:DropDownList>
                </div>
                <hr />
                <asp:Label ID="Label3" runat="server" Text="Resource:"></asp:Label>
                <asp:FileUpload ID="fileBannerUpload" runat="server" CssClass="form-control" />
                <asp:CustomValidator ID="fileValidator" runat="server" ControlToValidate="fileBannerUpload"
                    ClientValidationFunction="validateFile" ErrorMessage="Invalid file type or size exceeded 5MB"
                    Display="Dynamic" ForeColor="Red" />

                <script type="text/javascript">
                    function validateFile(sender, args) {
                        var fileInput = document.getElementById('<%= fileBannerUpload.ClientID %>');
                        var filePath = fileInput.value;
                        var fileSize = fileInput.files[0].size / 1024 / 1024;

                        var allowedExtensions = /(\.html|\.htm|\.jpg|\.jpeg|\.png|\.gif|\.bmp|\.tiff|\.webp|\.txt|\.mp4|\.avi|\.mkv|\.mov|\.wmv|\.zip)$/i;

                        if (!allowedExtensions.exec(filePath)) {
                            args.IsValid = false;
                            alert("Invalid file type. Only HTML, Image, Text, and Video files are allowed.");
                            return;
                        }

                        if (fileSize > 5) {
                            args.IsValid = false;
                            alert("File size exceeds the 5MB limit.");
                            return;
                        }

                        args.IsValid = true;
                    }
                </script>

                <hr />
                <asp:TextBox ID="txtBannerLink" runat="server" CssClass="form-control" Placeholder="The website link this banner points to *" MaxLength="100" />
                <br />
                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" Text="Target:"></asp:Label>
                    <asp:DropDownList ID="ddlTarget" runat="server" CssClass="form-control">
                        <asp:ListItem Text="-Select-" Selected="True" Value="0" />
                        <asp:ListItem Text="Open in New Tab" Value="_blank" />
                        <asp:ListItem Text="Open in Same Tab" Value="_self" />
                        <asp:ListItem Text="Open in Parent Frame" Value="_parent" />
                        <asp:ListItem Text="Open in Full Window" Value="_top" />
                    </asp:DropDownList>
                </div>
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <div class="form-group text-center">
                            <asp:Label ID="ErrLbl" runat="server" Height="15px" BackColor="Transparent" Text="" ForeColor="Red" Font-Size="Smaller"></asp:Label>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="form-group text-left">
                    <asp:Button ID="CreateBannerButton" runat="server" CssClass="btn-primary" Text="Create Banner" OnClick="CreateBannerButton_Click" />
                </div>
            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="dashboard-section">
                    <div class="dashboard-item">
                        <h4>Registered Banners</h4>
                        <asp:GridView ID="BannerGridView" AllowPaging="True" PageSize="10" OnPageIndexChanging="BannerGridView_PageIndexChanging" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-dark table-hover">
                            <RowStyle BorderStyle="inset" BorderColor="white" />
                            <Columns>
                                <asp:TemplateField HeaderText="Campaign Name" HeaderStyle-CssClass="sortable">
                                    <ItemTemplate>
                                        <span style="background-color: transparent;" title='<%# Eval("CampaignName") %>'><%# Eval("CampaignName") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Website Name" HeaderStyle-CssClass="sortable">
                                    <ItemTemplate>
                                        <span style="background-color: transparent;" title='<%# Eval("WebsiteName") %>'><%# Eval("WebsiteName") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Zone Name" HeaderStyle-CssClass="sortable">
                                    <ItemTemplate>
                                        <span style="background-color: transparent;" title='<%# Eval("ZoneName") %>'><%# Eval("ZoneName") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Banner Name" HeaderStyle-CssClass="sortable">
                                    <ItemTemplate>
                                        <span style="background-color: transparent;" title='<%# Eval("BannerName") %>'><%# Eval("BannerName") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Created By" HeaderStyle-CssClass="sortable">
                                    <ItemTemplate>
                                        <span style="background-color: transparent;" title='<%# Eval("CreatedBy") %>'><%# Eval("CreatedBy") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Created Date" HeaderStyle-CssClass="sortable">
                                    <ItemTemplate>
                                        <span style="background-color: transparent;" title='<%# Eval("CreatedDate") %>'><%# Eval("CreatedDate") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Updated Date" HeaderStyle-CssClass="sortable">
                                    <ItemTemplate>
                                        <span style="background-color: transparent;" title='<%# Eval("UpdatedDate") %>'><%# Eval("UpdatedDate") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="sortable">
                                    <ItemTemplate>
                                        <span style="background-color: transparent;" title='<%# Eval("Status") %>'><%# Eval("Status") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Actions" HeaderStyle-CssClass="sortable">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="ActivateButton" OnClick="ActivateButton_Click" runat="server" CommandName="Activate" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-success" Text="Activate" Visible='<%# Eval("Status").ToString() == "Deactivated" %>'></asp:LinkButton>
                                        <asp:LinkButton ID="DeactivateButton" OnClick="DeactivateButton_Click" runat="server" CommandName="Deactivate" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-danger" Text="Deactivate" Visible='<%# Eval("Status").ToString() == "Active" %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <script type="text/javascript">
                            document.addEventListener('DOMContentLoaded', function () {
                                const getCellValue = (tr, idx) => tr.children[idx].innerText || tr.children[idx].textContent;

                                const comparer = (idx, asc) => (a, b) => ((v1, v2) =>
                                    v1 !== '' && v2 !== '' && !isNaN(v1) && !isNaN(v2) ? v1 - v2 : v1.toString().localeCompare(v2)
                                )(getCellValue(asc ? a : b, idx), getCellValue(asc ? b : a, idx));

                                document.querySelectorAll('.sortable').forEach(th => th.addEventListener('click', (() => {
                                    const table = th.closest('table');
                                    Array.from(table.querySelectorAll('tr:nth-child(n+2)'))
                                        .sort(comparer(Array.from(th.parentNode.children).indexOf(th), this.asc = !this.asc))
                                        .forEach(tr => table.appendChild(tr));
                                })));
                            });
                        </script>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
