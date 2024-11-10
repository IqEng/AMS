<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AMS._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">        
        <!-- Serve Ads Section -->
        <div class="content-section dark">
            <div style="flex: 1; display: flex; justify-content: center; align-items: center;">
                <img src="Images/serve_ads.jpg" alt="Serve Ads" />
            </div>
            <div class="content-text">
                <h2 class="dark">Serve Ads</h2>
                <ul class="dark">
                    <li>Deploy ads across websites, apps, and video platforms.</li>
                    <li>Collect detailed statistics on impressions, clicks, and conversions.</li>
                    <li>Analyze ad performance across different channels effortlessly.</li>
                </ul>
                <p class="dark">Our system allows you to serve ads on various platforms, ensuring maximum reach and detailed performance tracking.</p>
            </div>
        </div>

        <!-- Advertisers Section -->
        <div class="content-section">
            <div class="content-text">
                <h2>Advertisers</h2>
                <ul>
                    <li>Upload and manage images for banners with associated destination URLs.</li>
                    <li>Work with various ad networks or exchanges seamlessly.</li>
                    <li>Provide clients with login access to review their advertising statistics.</li>
                </ul>
                <p>Define as many advertisers as needed without any limitations, ensuring your campaigns reach the right audience efficiently.</p>
            </div>
            <div style="flex: 1; display: flex; justify-content: center; align-items: center;">
                <img src="Images/advertisers.jpg" alt="Advertisers" />
            </div>
        </div>

        <!-- Banners Section -->
        <div class="content-section dark">
            <div style="flex: 1; display: flex; justify-content: center; align-items: center;">
                <img src="Images/banners.jpg" alt="Banners" />
            </div>
            <div class="content-text">
                <h2 class="dark">Banners</h2>
                <ul class="dark">
                    <li>Create and manage various types of banners including HTML5 and third-party ad tags.</li>
                    <li>Set up banner rotation rules to optimize ad delivery.</li>
                    <li>Implement advanced targeting options to reach the right audience.</li>
                </ul>
                <p class="dark">Our banner management system allows you to create diverse ad formats, ensuring engaging and effective ad campaigns.</p>
            </div>
        </div>

        <!-- Manage Campaigns Section -->
        <div class="content-section">
            <div class="content-text">
                <h2>Manage Campaigns</h2>
                <ul>
                    <li>Handle campaigns for multiple advertisers with ease.</li>
                    <li>Integrate ad networks and manage campaigns from a single interface.</li>
                    <li>Streamline campaign management with user-friendly tools.</li>
                </ul>
                <p>Our platform simplifies the management of multiple campaigns, offering powerful tools to enhance ad performance.</p>
            </div>
            <div style="flex: 1; display: flex; justify-content: center; align-items: center;">
                <img src="Images/manage_campaigns.jpg" alt="Manage Campaigns" />
            </div>
        </div>

        <!-- Campaigns Section -->
        <div class="content-section dark">
            <div style="flex: 1; display: flex; justify-content: center; align-items: center;">
                <img src="Images/campaigns.jpg" alt="Campaigns" />
            </div>
            <div class="content-text">
                <h2 class="dark">Campaigns</h2>
                <ul class="dark">
                    <li>Manage Contract campaigns with fixed ad impressions, clicks, or conversions.</li>
                    <li>Fill remaining ad space with Remnant campaigns, maximizing revenue.</li>
                    <li>Override campaigns to give priority to specific ads as needed.</li>
                </ul>
                <p class="dark">Our flexible campaign management tools let you handle multiple campaign types efficiently, ensuring optimal ad delivery.</p>
            </div>
        </div>

        <!-- Track Campaign Performance Section -->
        <div class="content-section">
            <div class="content-text">
                <h2>Track Campaign Performance</h2>
                <ul>
                    <li>Monitor key metrics like CTR, conversion rates, and revenue.</li>
                    <li>Analyze eCPM and conversion details including basket value.</li>
                    <li>Access comprehensive reports to optimize ad strategies.</li>
                </ul>
                <p>Gain deep insights into campaign performance with detailed tracking tools, helping you make data-driven decisions.</p>
            </div>
            <div style="flex: 1; display: flex; justify-content: center; align-items: center;">
                <img src="Images/track_performance.jpg" alt="Track Campaign Performance" />
            </div>
        </div>
    </div>
</asp:Content>
