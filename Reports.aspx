<%@ Page Title="Reports & Analytics" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="AMS._Reports" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        /* Style for the report header */
        .report-header-panel {
            margin-bottom: 5px;
            padding: 5px;
            border: 1px solid #dcdcdc;
            border-radius: 4px;
            font-size: 16px;
            font-weight: bold;
            color: black;
            background-color: transparent;
        }

        /* GridView styling */
        .table {
            width: 100%;
            border-collapse: collapse;
        }

        .table-bordered {
            border: 1px solid #ddd;
        }

            .table-bordered th, .table-bordered td {
                border: 1px solid #ddd;
                padding: 8px;
                text-align: left;
            }

        .table-striped tbody tr:nth-of-type(odd) {
            background-color: #f9f9f9;
        }

        .table thead {
            background-color: #f0f0f0;
            font-weight: bold;
        }

        .table th {
            padding: 10px;
        }

        .table td {
            padding: 8px;
        }

        .table th, .table td {
            border: 1px solid #ddd;
            text-align: left;
        }

        .table-hover tbody tr:hover {
            background-color: #f1f1f1;
        }

        .table-bordered {
            border: 1px solid #ddd;
        }
    </style>

    <div style="position: relative; width: 100%; height: auto; background-image: url('Images/report.jpg'); background-repeat: no-repeat; background-size: cover; background-position: center; overflow: hidden;"
        class="blurred-background">
        <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">
        <br />
        <asp:HiddenField ID="Idn" runat="server" Value="InitialValue" />
        <asp:UpdateProgress ID="UpdateProgress9" runat="server" AssociatedUpdatePanelID="UpdatePanel9">
            <ProgressTemplate>
                <div style="position: fixed; left: 0%; top: 0%; z-index: 999; height: 100%; width: 100%; border-style: none; background-color: Black; filter: alpha(opacity=60); opacity: 0.3; -moz-opacity: 0.5;">
                    <asp:Image ID="ImageLodinggif" Style="position: fixed; left: 48%; top: 48%; z-index: 1000;" runat="server" ImageUrl="~/Images/loading.gif" Width="86px" Height="86px"></asp:Image>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
            <ContentTemplate>
                <div class="panel-header">Reports & Analytics</div>
                <div class="dashboard-section">
                    <div class="dashboard-item">
                        <h4>Generate Report</h4>
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:Label ID="lblReportType" runat="server" Text="Select Report Type:" />
                            <asp:DropDownList ID="ddlReportType" runat="server" CssClass="form-control">
                                <asp:ListItem Text="-Select Type-" Value="0" />
                                <asp:ListItem Text="Campaign Performance" Value="CampaignPerformance" />
                                <asp:ListItem Text="Banner Performance" Value="BannerPerformance" />
                                <asp:ListItem Text="Website Performance" Value="WebsitePerformance" />
                                <asp:ListItem Text="Zone Performance" Value="ZonePerformance" />
                                <asp:ListItem Text="Custom Report" Value="CustomReport" />
                            </asp:DropDownList>
                            <br />
                            <asp:Label ID="Label10" runat="server" Text="Advertiser:" />
                            <asp:TextBox ID="AdDDL" runat="server" CssClass="form-control" />
                            <br />
                            <asp:Label ID="Label9" runat="server" Text="Campaign:" />
                            <asp:DropDownList ID="CampaignDDL" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                            <br />
                            <asp:Label ID="lblZoneType" runat="server" Text="Website:" />
                            <asp:DropDownList ID="WebsiteDDL" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                            <br />
                        </asp:Panel>
                    </div>
                    <div class="dashboard-item">
                        <asp:Panel ID="Panel2" runat="server">
                            <asp:Label ID="Label7" runat="server" Text="Created From Date:" />
                            <asp:TextBox ID="txtFromDate" runat="server" TextMode="Date" CssClass="form-control" Placeholder="YYYY-MM-DD" />
                            <br />
                            <asp:Label ID="Label8" runat="server" Text="Created To Date:" />
                            <asp:TextBox ID="txtToDate" runat="server" TextMode="Date" CssClass="form-control" Placeholder="YYYY-MM-DD" />
                            <br />
                            <asp:Label ID="lblFilters" runat="server" Text="Additional Filters:" />
                            <asp:TextBox ID="txtFilter" runat="server" CssClass="form-control" Placeholder="Enter filters (optional)" />
                            <br />
                            <div class="form-group text-center">
                                <asp:Label ID="ErrLbl" runat="server" Height="15px" BackColor="Transparent" Text="" ForeColor="Red" Font-Size="Smaller"></asp:Label>
                            </div>
                            <asp:Button ID="GenerateReportButton" runat="server" CssClass="btn-primary" Text="Generate Report" OnClick="GenerateReportButton_Click" />
                        </asp:Panel>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div id="divToExport" class="dashboard-section">
            <div class="dashboard-item" style="background-color: silver;">
                <h4>Report Details</h4>
                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="ReportNameLabel" runat="server" Text="" Style="color: black;" />
                        <br />
                        <asp:Label ID="ReportDateLabel" runat="server" Text="" Style="color: black;" />
                        <br />
                        <br />
                        <asp:GridView ID="DynamicReportGridView" AllowPaging="True" PageSize="10" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered table-striped table-hover">
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
                <asp:Button ID="btnDownloadPdf" runat="server" CssClass="btn btn-success" Text="Download PDF" OnClick="btnDownloadPdf_Click" />
                <asp:Button ID="btnDownloadExcel" runat="server" CssClass="btn btn-success" Text="Download EXCEL" OnClick="btnDownloadExcel_Click" />
            </div>
        </div>
    </div>
</asp:Content>
