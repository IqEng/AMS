<%@ Page Title="Terms and Conditions" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Terms_and_Conditions.aspx.cs" Inherits="AMS.Terms_and_Conditions" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
            <ProgressTemplate>
                <div style="position: fixed; left: 0%; top: 0%; z-index: 999; height: 100%; width: 100%; border-style: none; background-color: Black; filter: alpha(opacity=60); opacity: 0.3; -moz-opacity: 0.5;">
                    <asp:Image ID="ImageLodinggif" Style="position: fixed; left: 48%; top: 48%; z-index: 1000;" runat="server" ImageUrl="~/Images/loading.gif" Width="86px" Height="86px"></asp:Image>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <table style="width: 100%; height: 100%; font-family: Calibri Light; word-spacing: 1px; letter-spacing: 0.5px;">
                    <tr>
                        <td style="width: 10%; height: 100%;"></td>
                        <td style="width: 80%; height: 100%;"><br />
                                <h1>Terms and Conditions</h1>
                                <p>Last updated: August 18, 2024</p>

                                <p>Please read these terms and conditions carefully before using Our Service.</p>

                                <h2>Interpretation and Definitions</h2>
                                <h3>Interpretation</h3>
                                <p>The words of which the initial letter is capitalized have meanings defined under the following conditions. The following definitions shall have the same meaning regardless of whether they appear in singular or in plural.</p>

                                <h2>Acceptance of Terms</h2>
                                <p>By accessing and using IQ-AMS.com, you agree to comply with these terms and conditions.</p>

                                <h2>Account Creation</h2>
                                <p>To access certain features, you may be required to create an account. You are responsible for maintaining the confidentiality of your account information.</p>

                                <h2>Content Usage</h2>
                                <p>The content available on IQ-AMS.com is for personal, non-commercial use. Unauthorized distribution, reproduction, or modification of the content is strictly prohibited.</p>

                                <h2>Payment and Purchases</h2>
                                <p>Some features may require a purchase to access. By making a purchase, you agree to provide accurate payment information and authorize the charges. There will be no refund.</p>

                                <h2>Intellectual Property</h2>
                                <p>All materials on IQ-AMS.com are protected by copyright. You may not use, modify, or distribute any copyrighted material without obtaining the necessary permissions.</p>

                                <h2>User Conduct</h2>
                                <p>You agree not to engage in any activities that may disrupt or harm the platform, other users, or the integrity of the content. This includes but is not limited to spamming, hacking, or violating any applicable laws.</p>

                                <h2>Privacy</h2>
                                <p>We value your privacy and handle your personal information in accordance with our Privacy Policy. By using IQ-AMS.com, you consent to the collection and use of your information as described therein.</p>

                                <h2>Modifications and Termination</h2>
                                <p>We reserve the right to modify or terminate the platform or these terms and conditions at any time. Your continued use of IQ-AMS.com after any modifications constitutes acceptance of the updated terms.</p>

                                <h2>Authors</h2>
                                <h3>Content Submission</h3>
                                <p>By submitting your content to IQ-AMS.com, you grant us a non-exclusive license to display, distribute, and manage your work on the platform.</p>

                                <h3>Copyright Ownership</h3>
                                <p>You retain the copyright and intellectual property rights to your content. However, by submitting it to IQ-AMS.com, you grant us the necessary rights to operate the platform and provide the services.</p>

                                <h3>Royalties and Payments</h3>
                                <p>Authors will receive royalties based on the revenue generated from their content. Payment terms and royalty rates will be outlined in a separate agreement.</p>

                                <h3>Content Accuracy and Legality</h3>
                                <p>You are responsible for ensuring the accuracy and legality of the content you submit. Violations may result in removal of the content and potential legal action.</p>

                                <h3>Termination</h3>
                                <p>Both parties have the right to terminate the agreement with written notice. Upon termination, any rights granted to IQ-AMS.com will cease, but previously purchased content will remain accessible.</p>

                                <h3>Modifications</h3>
                                <p>We may need to modify your content's formatting or layout to optimize its display on IQ-AMS.com. Substantial changes will not be made without your consent.</p>

                                <h3>Promotion and Marketing</h3>
                                <p>We may promote and market your content on IQ-AMS.com and through various channels. You grant us the necessary permissions to use your content for promotional purposes.</p>

                                <h2>Definitions</h2>
                                <p>For the purposes of these Terms and Conditions:</p>
                                <ul>
                                    <li><strong>Application</strong> means the software program provided by the Company named IQ-AMS.</li>
                                    <li><strong>Company</strong> (referred to as "We", "Us" or "Our") refers to IQ-AMS.</li>
                                    <li><strong>Device</strong> means any device that can access the Service such as a computer, cellphone, or digital tablet.</li>
                                    <li><strong>Service</strong> refers to the Application or the Website or both.</li>
                                    <li><strong>Website</strong> refers to IQ-AMS, accessible from <a href="http://www.iq-ams.com">http://www.iq-ams.com</a></li>
                                </ul>

                                <h2>Acknowledgment</h2>
                                <p>These Terms and Conditions govern the use of this Service and the agreement between you and the Company. By accessing or using the Service, you agree to be bound by these Terms and Conditions.</p>

                                <h2>Links to Other Websites</h2>
                                <p>Our Service may contain links to third-party websites or services that are not owned or controlled by the Company. We have no control over and assume no responsibility for the content or practices of any third party websites or services.</p>

                                <h2>Termination</h2>
                                <p>We may terminate or suspend your access immediately, without prior notice or liability, for any reason, including if you breach these Terms and Conditions. Upon termination, your right to use the Service will cease immediately.</p>

                                <h2>Limitation of Liability</h2>
                                <p>To the maximum extent permitted by applicable law, the Company shall not be liable for any special, incidental, indirect, or consequential damages, including but not limited to damages for loss of data or business interruption.</p>

                                <h2>"AS IS" and "AS AVAILABLE" Disclaimer</h2>
                                <p>The Service is provided "AS IS" and "AS AVAILABLE" without warranty of any kind. The Company does not warrant that the Service will meet your requirements or be error-free.</p>

                                <h2>Governing Law</h2>
                                <p>The laws of Sri Lanka, excluding its conflicts of law rules, shall govern these Terms and your use of the Service.</p>

                                <h2>Disputes Resolution</h2>
                                <p>If you have any concerns or disputes about the Service, you agree to try to resolve the dispute informally by contacting the Company.</p>

                                <h2>For European Union (EU) Users</h2>
                                <p>If you are an EU consumer, you will benefit from any mandatory provisions of the law of the country in which you are resident.</p>

                                <h2>United States Legal Compliance</h2>
                                <p>You represent and warrant that you are not located in a country subject to a United States government embargo and are not listed on any United States government list of prohibited or restricted parties.</p>

                                <h2>Severability and Waiver</h2>
                                <h3>Severability</h3>
                                <p>If any provision of these Terms is held to be unenforceable or invalid, the remaining provisions will continue in full force and effect.</p>

                                <h3>Waiver</h3>
                                <p>The failure to exercise a right or require performance under these Terms shall not affect a party's ability to exercise such right or require such performance at any time thereafter.</p>

                                <h2>Translation Interpretation</h2>
                                <p>These Terms and Conditions may have been translated. The original English text shall prevail in the case of a dispute.</p>

                                <h2>Changes to These Terms and Conditions</h2>
                                <p>We reserve the right to modify or replace these Terms at any time. If a revision is material, we will provide at least 30 days' notice prior to the new terms taking effect. By continuing to use the Service after revisions, you agree to the revised terms.</p>

                                <h2>Contact Us</h2>
                                <p>If you have any questions about these Terms and Conditions, you can contact us:</p>
                                <p>By email: <a href="mailto:contact@iq-ams.com">contact@iq-ams.com</a></p>
                        </td>
                        <td style="width: 10%; height: 100%;">&nbsp;</td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
