<%@ Page Title="Ad Management Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="AMS._Dashboard" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">
    <div class="dashboard-grid">
        <div class="dashboard-square">
            <a href="Websites.aspx">
                <i class="fas fa-globe dashboard-icon"></i>
                <div class="dashboard-title">Websites Management</div>
                <div class="dashboard-description">Manage and configure websites.</div>
            </a>
        </div>
        <div class="dashboard-square">
            <a href="Zones.aspx">
                <i class="fas fa-th-large dashboard-icon"></i>
                <div class="dashboard-title">Zones Management</div>
                <div class="dashboard-description">Manage ad zones across sites.</div>
            </a>
        </div>
        <div class="dashboard-square">
            <a href="Campaigns.aspx">
                <i class="fas fa-bullhorn dashboard-icon"></i>
                <div class="dashboard-title">Campaigns Management</div>
                <div class="dashboard-description">Manage ad campaigns and schedules.</div>
            </a>
        </div>
        <div class="dashboard-square">
            <a href="Banners.aspx">
                <i class="fas fa-image dashboard-icon"></i>
                <div class="dashboard-title">Banners Management</div>
                <div class="dashboard-description">Upload and configure banners.</div>
            </a>
        </div>
    </div>
    <center>
        <div class="centered-grid">
            <div class="centered-square">
                <a href="Reports.aspx">
                    <i class="fas fa-chart-line dashboard-icon"></i>
                    <div class="dashboard-title">Reports & Analytics</div>
                    <div class="dashboard-description">View performance and analytics.</div>
                </a>
            </div>
            <div class="centered-square">
                <a href="Profile.aspx">
                    <i class="fas fa-user-circle dashboard-icon"></i>
                    <div class="dashboard-title">User Accounts</div>
                    <div class="dashboard-description">Manage Admin and Advertiser user accounts.</div>
                </a>
            </div>
            <div class="centered-square">
                <a href="Contact_us.aspx">
                    <i class="fas fa-life-ring dashboard-icon"></i>
                    <div class="dashboard-title">Support</div>
                    <div class="dashboard-description">Get help and support.</div>
                </a>
            </div>
        </div>
    </center>
</asp:Content>
