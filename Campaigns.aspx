<%@ Page Title="Campaign Management" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Campaigns.aspx.cs" Inherits="AMS._Campaigns" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="position: relative; width: 100%; height: auto; background-image: url('Images/campaign.jpg'); background-repeat: no-repeat; background-size: cover; background-position: center; overflow: hidden;"
        class="blurred-background">
        <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">
        <br />
        <asp:HiddenField ID="Idn" runat="server" Value="InitialValue" />
        <asp:UpdateProgress ID="UpdateProgress8" runat="server" AssociatedUpdatePanelID="UpdatePanel8">
            <ProgressTemplate>
                <div style="position: fixed; left: 0%; top: 0%; z-index: 999; height: 100%; width: 100%; border-style: none; background-color: Black; filter: alpha(opacity=60); opacity: 0.3; -moz-opacity: 0.5;">
                    <asp:Image ID="ImageLodinggif" Style="position: fixed; left: 48%; top: 48%; z-index: 1000;" runat="server" ImageUrl="~/Images/loading.gif" Width="86px" Height="86px"></asp:Image>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
            <ContentTemplate>
                <div class="panel-header">Campaign Management</div>
                <div class="dashboard-section">
                    <div class="dashboard-item">
                        <h4>Add Campaign</h4>
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:TextBox ID="txtCampaignName" runat="server" CssClass="form-control" Placeholder="Campaign Name *" MaxLength="23" /><br />
                            <asp:TextBox ID="txtCampaignDescription" runat="server" CssClass="form-control" TextMode="MultiLine" MaxLength="150" Placeholder="Campaign Description" />
                            <br />
                            <div style="align-items: flex-start">
                                <asp:Label ID="lblStartDate" runat="server" Text="Start Date:"></asp:Label>
                                <asp:TextBox ID="txtStartDate" runat="server" TextMode="Date" Width="230" CssClass="form-control" Placeholder="YYYY-MM-DD *" /><br />

                                <asp:Label ID="lblEndDate" runat="server" Text="End Date:"></asp:Label>
                                <asp:TextBox ID="txtEndDate" runat="server" TextMode="Date" Width="230" CssClass="form-control" Placeholder="YYYY-MM-DD *" /><br />
                                <div class="form-group text-center">
                                    <asp:Label ID="ErrLbl" runat="server" Height="15px" BackColor="Transparent" Text="" ForeColor="Red" Font-Size="Smaller"></asp:Label>
                                </div>
                            </div>
                            <asp:Button ID="CreateCampaignButton" runat="server" CssClass="btn-primary" Text="Create Campaign" OnClick="CreateCampaignButton_Click" />
                        </asp:Panel>
                    </div>
                </div>
                <div class="dashboard-section">
                    <div class="grid-section">
                        <div class="dashboard-item">
                            <h4>Registered Campaigns</h4>
                            <asp:GridView ID="CampaignGridView" AllowPaging="True" PageSize="10" OnPageIndexChanging="CampaignGridView_PageIndexChanging" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-dark table-hover" OnRowEditing="CampaignGridView_RowEditing" OnRowUpdating="CampaignGridView_RowUpdating" OnRowCancelingEdit="CampaignGridView_RowCancelingEdit">
                                <RowStyle BorderStyle="inset" BorderColor="white" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Campaign Name" HeaderStyle-CssClass="sortable">
                                        <ItemTemplate>
                                            <span style="background-color: transparent;" title='<%# Eval("CampaignName") %>'><%# Eval("CampaignName") %></span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Priority" HeaderStyle-CssClass="sortable">
                                        <ItemTemplate>
                                            <span style="background-color: transparent;" title='<%# Eval("Priority") %>'><%# Eval("Priority") %></span>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtPriority" runat="server" Text='<%# Eval("Priority") %>' CssClass="form-control"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Advertiser" HeaderStyle-CssClass="sortable">
                                        <ItemTemplate>
                                            <span style="background-color: transparent;" title='<%# Eval("Advertiser") %>'><%# Eval("Advertiser") %></span>
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
                                    <asp:TemplateField HeaderText="Start Date" HeaderStyle-CssClass="sortable">
                                        <ItemTemplate>
                                            <span style="background-color: transparent;" title='<%# Eval("StartDate") %>'><%# Eval("StartDate") %></span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="End Date" HeaderStyle-CssClass="sortable">
                                        <ItemTemplate>
                                            <span style="background-color: transparent;" title='<%# Eval("EndDate") %>'><%# Eval("EndDate") %></span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="sortable">
                                        <ItemTemplate>
                                            <span style="background-color: transparent;" title='<%# Eval("Status") %>'><%# Eval("Status") %></span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowEditButton="True" />
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
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
