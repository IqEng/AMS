<%@ Page Title="Website Management" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Websites.aspx.cs" Inherits="AMS._Websites" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="position: relative; width: 100%; height: auto; background-image: url('Images/website.jpg'); background-repeat: no-repeat; background-size: cover; background-position: center; overflow: hidden;"
        class="blurred-background">
        <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">
        <br />
        <asp:UpdateProgress ID="UpdateProgress10" runat="server" AssociatedUpdatePanelID="UpdatePanel10">
            <ProgressTemplate>
                <div style="position: fixed; left: 0%; top: 0%; z-index: 999; height: 100%; width: 100%; border-style: none; background-color: Black; filter: alpha(opacity=60); opacity: 0.3; -moz-opacity: 0.5;">
                    <asp:Image ID="ImageLodinggif" Style="position: fixed; left: 48%; top: 48%; z-index: 1000;" runat="server" ImageUrl="~/Images/loading.gif" Width="86px" Height="86px"></asp:Image>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
            <ContentTemplate>
                <asp:HiddenField ID="Idn" runat="server" Value="InitialValue" />
                <div class="panel-header">Website Management</div>
                <div class="dashboard-section">
                    <div class="dashboard-item">
                        <h4>Add Website</h4>
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:TextBox ID="NameTextBox" runat="server" CssClass="form-control" Placeholder="Name *" MaxLength="23" />
                            <br />
                            <asp:TextBox ID="WebsiteUrlTextBox" runat="server" CssClass="form-control" Placeholder="Website URL *" MaxLength="60" />
                            <br />
                            <asp:TextBox ID="txtCampaignBudget" runat="server" CssClass="form-control" Width="230" Placeholder="Campaign Budget" TextMode="Number" />
                            <br />
                            <div class="form-group">
                                <asp:Label ID="LabelTargetFrame" runat="server" Text="Target frame:" />
                                <asp:DropDownList ID="TargetFrameDropDownList" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="-Select-" Selected="True" Value="0" />
                                    <asp:ListItem Text="Default" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="New Window" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Same Window" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group text-center">
                                <asp:Label ID="ErrLbl" runat="server" Height="15px" BackColor="Transparent" Text="" ForeColor="Red" Font-Size="Smaller"></asp:Label>
                            </div>
                            <asp:Button ID="CreateWebsiteButton" runat="server" CssClass="btn-primary" Text="Create Website" OnClick="CreateWebsiteButton_Click" />
                        </asp:Panel>
                    </div>
                </div>
                <div class="dashboard-section">
                    <div class="dashboard-item">
                        <h4>Registered Websites</h4>
                        <asp:GridView ID="WebsiteGridView" AllowPaging="True" PageSize="10"
                            OnPageIndexChanging="WebsiteGridView_PageIndexChanging" runat="server" AutoGenerateColumns="False"
                            CssClass="table table-bordered table-dark table-hover">
                            <Columns>
                                <asp:TemplateField HeaderText="Website Name" HeaderStyle-CssClass="sortable">
                                    <ItemTemplate>
                                        <span style="background-color: transparent;" title='<%# Eval("WebsiteName") %>'>
                                            <%# Eval("WebsiteName") %>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Created By" HeaderStyle-CssClass="sortable">
                                    <ItemTemplate>
                                        <span style="background-color: transparent;" title='<%# Eval("CreatedBy") %>'>
                                            <%# Eval("CreatedBy") %>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Created Date" HeaderStyle-CssClass="sortable">
                                    <ItemTemplate>
                                        <span style="background-color: transparent;" title='<%# Eval("CreatedDate") %>'>
                                            <%# Eval("CreatedDate") %>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Updated Date" HeaderStyle-CssClass="sortable">
                                    <ItemTemplate>
                                        <span style="background-color: transparent;" title='<%# Eval("UpdatedDate") %>'>
                                            <%# Eval("UpdatedDate") %>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="sortable">
                                    <ItemTemplate>
                                        <span style="background-color: transparent;" title='<%# Eval("Status") %>'>
                                            <%# Eval("Status") %>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Actions" HeaderStyle-CssClass="sortable">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="ActivateButton" runat="server" CommandName="Activate" CommandArgument='<%# Eval("Id") %>'
                                            CssClass="btn btn-success" Text="Activate"
                                            Visible='<%# Eval("Status").ToString() == "Deactivated" %>' OnClick="ActivateButton_Click"></asp:LinkButton>
                                        <asp:LinkButton ID="DeactivateButton" runat="server" CommandName="Deactivate" CommandArgument='<%# Eval("Id") %>'
                                            CssClass="btn btn-danger" Text="Deactivate"
                                            Visible='<%# Eval("Status").ToString() == "Active" %>' OnClick="DeactivateButton_Click"></asp:LinkButton>
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
