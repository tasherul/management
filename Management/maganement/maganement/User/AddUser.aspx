<%@ Page Title="" Language="C#" MasterPageFile="~/mDesign.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="maganement.User.AddUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Add a User</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="page-wrapper">
                <div class="content container-fluid">
					<div class="row">
						<div class="col-md-8 col-md-offset-2">
							
								<h3 class="page-title">Add a User</h3>
								<div class="row">
									<div class="col-sm-6">
										<div class="form-group">
											<label>Name <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtName"  CssClass="form-control" placeholder="Name" runat="server"></asp:TextBox>
										</div>
									</div>
									<div class="col-sm-6">
										<div class="form-group">
											<label>NID</label>
											<asp:TextBox ID="txtNID"  CssClass="form-control" placeholder="NID Card Number" runat="server"></asp:TextBox>
										</div>
									</div>
								</div>
								<div class="row">
									<div class="col-sm-12">
										<div class="form-group">
											<label>Address</label>
											<asp:TextBox ID="txtAddress"  CssClass="form-control" placeholder="Address or Location" runat="server"></asp:TextBox>
										</div>
									</div>
									</div>
								<div class="row">
									<div class="col-sm-6">
										<div class="form-group">
											<label>Email</label>
											<asp:TextBox ID="txtEmail"  CssClass="form-control" placeholder="Email" TextMode="Email" runat="server"></asp:TextBox>
										</div>
									</div>
									<div class="col-sm-6">
										<div class="form-group">
											<label>Mobile Number</label>
											<asp:TextBox ID="txtMobileNumber"  CssClass="form-control" placeholder="Mobile Number" runat="server"></asp:TextBox>
										</div>
									</div>
								</div>
								<div class="row">
									<div class="col-sm-6">
										<div class="form-group">
											<label>UserName</label>
											<asp:TextBox ID="txtUserName"  CssClass="form-control" placeholder="UserName" runat="server"></asp:TextBox>
										</div>
									</div>
									<div class="col-sm-6">
										<div class="form-group">
											<label>Password</label>
											<asp:TextBox ID="txtPassword"  CssClass="form-control" placeholder="Password" runat="server"></asp:TextBox>
										</div>
									</div>
								</div>
                                <div class="row">
									<div class="col-sm-6">
										<div class="form-group">
											<label>Select Group</label>
                                            <asp:DropDownList ID="ddlGroup" CssClass="form-control" runat="server" DataSourceID="SqlDataSource1" DataTextField="GroupName" DataValueField="GroupName"></asp:DropDownList>
                                            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:dbm %>' SelectCommand="SELECT distinct GroupName FROM [m_UserGroup]"></asp:SqlDataSource>
                                        </div>
									</div>
									<div class="col-sm-6">
										<div class="form-group">
											<label>Login Permistion</label>
                                            <asp:DropDownList ID="ddlLoginPermit" CssClass="form-control" runat="server">
                                                <asp:ListItem Value="True">Enable</asp:ListItem>
                                                <asp:ListItem Value="False">Disable</asp:ListItem>
                                            </asp:DropDownList>
										</div>
									</div>
								</div>
								<div class="row">
									<div class="col-sm-12">
										<div class="form-group">
											<label>Details</label>
											<asp:TextBox ID="txtDetails"  CssClass="form-control" placeholder="Details" runat="server"></asp:TextBox>
										</div>
									</div>
								</div>
                                <div class="row">
									<div class="col-sm-12">
										<div class="form-group">
											<label>Image Upload</label>
                                            <asp:FileUpload ID="ImageUpload" CssClass="form-control" runat="server" />
										</div>
									</div>
								</div>
                                <asp:Label ID="lblResult" runat="server"></asp:Label>
								<div class="row">
									<div class="col-sm-12 text-center m-t-20">
                                        <asp:Button ID="btnUpdate" Visible="false" OnClick="btnUpdate_Click" runat="server" CssClass="btn btn-success" Text="Update" />
                                        <asp:Button ID="btnUser"  Visible="false" OnClick="btnUser_Click" CssClass="btn btn-primary " runat="server" Text="Add User" />
									</div>
								</div>
							
						</div>
					</div>
                </div>
        </div>

        		<div class="sidebar-overlay" data-reff="#sidebar"></div>
        <script type="text/javascript" src="assets/js/jquery-3.2.1.min.js"></script>
        <script type="text/javascript" src="assets/js/bootstrap.min.js"></script>
        <script type="text/javascript" src="assets/js/jquery.slimscroll.js"></script>
		<script type="text/javascript" src="assets/js/select2.min.js"></script>
		<script type="text/javascript" src="assets/js/app.js"></script>

</asp:Content>
