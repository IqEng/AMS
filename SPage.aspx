<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SPage.aspx.cs" Inherits="AMS.SPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Successful</title>
        <meta http-equiv="content-type" content="text/html; charset=utf-8" />
<%--    <meta http-equiv="refresh" content="15; url=Default.aspx" />--%>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/bootstrap-datepicker.css" />
    <link rel="stylesheet" href="css/fontawesome-all.css" />
    <link rel="stylesheet" href="css/solid.min.css" />
    <link rel="stylesheet" href="css/slide-show.css" />
    <link rel="stylesheet" href="css/animation.css" />
    <link rel="stylesheet" href="css/owl.carousel.css" />
    <link rel="stylesheet" href="css/custom.css" />
    <link rel="stylesheet" href="css/media.css" />
    <link rel="stylesheet" href="css/colors.css" />
    <link rel="stylesheet" href="css/Custom-Styles.css" />
    <link rel="stylesheet" href="css/owl-animate.min.css" />
    <link rel="stylesheet" href="css/aos-onscroll-animation.css" />
    <style>
        p {
            text-align: center;
            font-size: 60px;
            margin-top: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center;">
            <br /><br /><br />
            <h3 style="word-spacing:1px; letter-spacing: 0.5px; color: Highlight;" runat="server" id="Msgid"></h3><br />
            <h3><i>You are redirecting in </i>
                <p id="demo"></p>
            </h3>
            <br />
            <%--<asp:Button ID="HomeBtn" runat="server" Text="Home" CssClass="btn radius-25 bg-blue txt-white pl-5 pr-5 font-weight-bold button-hover-blue" TabIndex="0" OnClick="HomeBtn_Click" AutoPostBack="true" />--%>
            <script>
                // Set the date we're counting down to
                var countDownDate = new Date("Jan 5, 2040 00:00:30").getTime();

                // Update the count down every 1 second
                var x = setInterval(function () {

                    ////// Get today's date and time
                    ////var now = new Date().getTime();

                    var now = new Date().getTime();

                    // Find the distance between now and the count down date
                    var distance = countDownDate - now;

                    //// Time calculations for days, hours, minutes and seconds
                    //var days = Math.floor(distance / (1000 * 60 * 60 * 24));
                    //var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
                    //var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
                    var seconds = Math.floor((distance % (1000 * 10)) / 1000);

                    // Output the result in an element with id="demo"
                    document.getElementById("demo").innerHTML = seconds + "s ";

                    if (document.getElementById("demo").innerHTML == "0s ") {
                        document.getElementById("demo").hidden = true;
                        window.location.replace("Default.aspx");
                    }

                    // If the count down is over, write some text 
                    if (distance < 0) {
                        clearInterval(x);
                        document.getElementById("demo").innerHTML = "EXPIRED";
                    }
                }, 1000);
            </script>
        </div>
    </form>
</body>
</html>
