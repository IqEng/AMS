<%@ Page Title="Zone Management" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Zones.aspx.cs" Inherits="AMS._Zones" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="position: relative; width: 100%; height: auto; background-image: url('Images/zone.jpg'); background-repeat: no-repeat; background-size: cover; background-position: center; overflow: hidden;"
        class="blurred-background">
        <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">
        <br />
        <asp:HiddenField ID="Idn" runat="server" Value="InitialValue" /><asp:UpdateProgress ID="UpdateProgress12" runat="server" AssociatedUpdatePanelID="UpdatePanel12">
            <ProgressTemplate>
                <div style="position: fixed; left: 0%; top: 0%; z-index: 999; height: 100%; width: 100%; border-style: none; background-color: Black; filter: alpha(opacity=60); opacity: 0.3; -moz-opacity: 0.5;">
                    <asp:Image ID="ImageLodinggif" Style="position: fixed; left: 48%; top: 48%; z-index: 1000;" runat="server" ImageUrl="~/Images/loading.gif" Width="86px" Height="86px"></asp:Image>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
            <ContentTemplate>
                <div class="panel-header">Zone Management</div>
                <div class="dashboard-section">
                    <div class="dashboard-item">
                        <h4>Add Zone</h4>
                        <asp:Panel ID="Panel1" runat="server">
                            <div class="form-group">
                                <asp:Label ID="lblWebsite" runat="server" Text="Website:" />
                                <asp:DropDownList ID="WebsiteDDL" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <asp:TextBox ID="txtZoneName" runat="server" CssClass="form-control" Placeholder="Name *" MaxLength="23" />
                            <br />
                            <asp:TextBox ID="txtZoneDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Placeholder="Description" MaxLength="150" />
                            <br />
                            <div class="form-group">
                                <asp:Label ID="lblZoneType" runat="server" Text="Zone type:" />
                                <asp:DropDownList ID="ddlZoneTypeDDL" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="-Select-" Selected="True" Value="0" />
                                    <asp:ListItem Text="Banner, Button or Rectangle" Value="Banner" />
                                    <asp:ListItem Text="Interstitial or Floating DHTML" Value="Interstitial" />
                                    <asp:ListItem Text="Text ad" Value="TextAd" />
                                    <asp:ListItem Text="Email/Newsletter zone" Value="EmailNewsletter" />
                                    <asp:ListItem Text="Inline Video ad" Value="InlineVideoAd" />
                                    <asp:ListItem Text="Overlay Video ad" Value="OverlayVideoAd" />
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblSize" runat="server" Text="Size:" />
                                <asp:DropDownList ID="ddlZoneSizeDDL" runat="server" CssClass="form-control">
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
                                    <asp:ListItem Value="-" Text="Custom" />
                                </asp:DropDownList>
                            </div>
                            <div style="align-items:flex-start">
                                <asp:Label ID="lblWidth" runat="server" Text="Custom:" CssClass="mr-2" />
                                <asp:TextBox ID="txtWidth" runat="server" CssClass="form-control mr-2" TextMode="Number" Width="250" Placeholder="Width" />
                                <br />
                                <asp:TextBox ID="txtHeight" runat="server" CssClass="form-control" TextMode="Number" Width="250" Placeholder="Height" />
                            </div><br />
                            <div class="form-group text-center">
                                <asp:Label ID="ErrLbl" runat="server" Height="15px" BackColor="Transparent" Text="" ForeColor="Red" Font-Size="Smaller"></asp:Label>
                            </div>
                            <asp:Button ID="CreateZoneButton" runat="server" CssClass="btn-primary" Text="Create Zone" OnClick="CreateZoneButton_Click" />
                        </asp:Panel>
                    </div>
                </div>
                <div class="dashboard-section">
                    <div class="dashboard-item">
                        <h4>Registered Zones</h4>
                        <asp:GridView ID="ZoneGridView" AllowPaging="True" DataKeyNames="Id" PageSize="10" OnPageIndexChanging="ZoneGridView_PageIndexChanging" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-dark table-hover">
                            <RowStyle BorderStyle="inset" BorderColor="white" />
                            <Columns>
                                <asp:TemplateField HeaderText="Website Name" HeaderStyle-CssClass="sortable">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="WebsiteName"  style="background-color: transparent;" title='<%# Eval("WebsiteName") %>'><%# Eval("WebsiteName") %></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Zone Name" HeaderStyle-CssClass="sortable">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="ZoneName" style="background-color: transparent;" title='<%# Eval("ZoneName") %>'><%# Eval("ZoneName") %></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Zone Type" HeaderStyle-CssClass="sortable">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="ZoneType"  style="background-color: transparent;" title='<%# Eval("ZoneType") %>'><%# Eval("ZoneType") %></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Zone Size" HeaderStyle-CssClass="sortable">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="ZoneSize" style="background-color: transparent;" title='<%# Eval("ZoneSize") %>'><%# Eval("ZoneSize") %></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Created By" HeaderStyle-CssClass="sortable">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="CreatedBy"  style="background-color: transparent;" title='<%# Eval("CreatedBy") %>'><%# Eval("CreatedBy") %></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Created Date" HeaderStyle-CssClass="sortable">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="CreatedDate"  style="background-color: transparent;" title='<%# Eval("CreatedDate") %>'><%# Eval("CreatedDate") %></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Updated Date" HeaderStyle-CssClass="sortable">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="UpdatedDate"  style="background-color: transparent;" title='<%# Eval("UpdatedDate") %>'><%# Eval("UpdatedDate") %></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="sortable">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="Status"  style="background-color: transparent;" title='<%# Eval("Status") %>'><%# Eval("Status") %></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Actions" HeaderStyle-CssClass="sortable">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="ActivateButton" OnClick="ActivateButton_Click" runat="server" CommandName="Activate" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-success" Text="Activate" Visible='<%# Eval("Status").ToString() == "Deactivated" %>'></asp:LinkButton>
                                        <asp:LinkButton ID="DownloadButton" OnClick="DownloadButton_Click" runat="server" CommandName="Download" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-success" Text="Download Script" Visible='<%# Eval("Status").ToString() == "Active" %>'></asp:LinkButton>
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
        <asp:Button ID="HiddenDownloadButton" runat="server" OnClick="HiddenDownloadButton_Click" Style="display:none;" />
    </div>
</asp:Content>
