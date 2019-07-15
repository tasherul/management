<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="maganement.Login" %>


<!DOCTYPE html>
<html>
<head>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0">
		<link rel="shortcut icon" type="image/x-icon" href="assets/img/favicon.png">
        <title>Login
        </title>
		<link href="https://fonts.googleapis.com/css?family=Montserrat:300,400,500,600,700" rel="stylesheet">
        <link rel="stylesheet" type="text/css" href="assets/css/bootstrap.min.css">
        <link rel="stylesheet" type="text/css" href="assets/css/font-awesome.min.css">
        <link rel="stylesheet" type="text/css" href="assets/css/style.css">
    </head>
    <body>
        <div class="main-wrapper">
			<div class="account-page">
				<%--<a href="job-list.html" class="btn btn-primary apply-btn">Apply Job</a>--%>
				<div class="container">
					<h3 class="account-title">Management Login</h3>
					<div class="account-box">
						<div class="account-wrapper">
							<div class="account-logo">
								<a href="index.html"><img src="assets/img/logo2.png" alt="Focus Technologies"></a>
							</div>
							<form id="form" runat="server">
								<div class="form-group form-focus">
									<label class="control-label">Username</label>
                                    <asp:TextBox ID="txtUsername" CssClass="form-control floating" runat="server"></asp:TextBox>
								</div>
								<div class="form-group form-focus">
									<label class="control-label">Password</label>
                                    <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="form-control floating" runat="server"></asp:TextBox>
								</div>
                                <asp:Label ID="lblResult" CssClass="alert alert-dange" Font-Bold="true" ForeColor="Red" runat="server"></asp:Label>
                                
								<div class="form-group text-center">
                                    <asp:Button ID="btnLogin" OnClick="btnLogin_Click" runat="server" CssClass="btn btn-primary btn-block account-btn" Text="Login" />
								</div>
								<div class="text-center">
									<a href="forgotpassword">Forgot your password?</a>
								</div>
							</form>
						</div>
					</div>
				</div>
			</div>
        </div>
		<div class="sidebar-overlay" data-reff="#sidebar"></div>
        <script type="text/javascript" src="assets/js/jquery-3.2.1.min.js"></script>
        <script type="text/javascript" src="assets/js/bootstrap.min.js"></script>
        <script type="text/javascript" src="assets/js/app.js"></script>
    </body>

<!-- Mirrored from dreamguys.co.in/smarthr/orange/login.html by HTTrack Website Copier/3.x [XR&CO'2014], Mon, 11 Mar 2019 17:16:32 GMT -->
</html>