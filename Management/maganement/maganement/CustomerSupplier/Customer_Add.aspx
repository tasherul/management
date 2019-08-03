<%@ Page Title="" Language="C#" MasterPageFile="~/mDesign.Master" AutoEventWireup="true" CodeBehind="Customer_Add.aspx.cs" Inherits="maganement.CustomerSupplier.Customer_Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Customer Add</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="row">
						<div class="col-sm-4 col-xs-3">
							<h4 class="page-title">Customaer Add</h4>
						</div>						
					</div>
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label">Full Name <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtName" placeholder="full name" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label">Email</label>
                        <asp:TextBox ID="txtEmail" placeholder="email" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label">Mobile Number <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtMobileNumber" MaxLength="11" placeholder="mobile number (example: 01xxxxxxxxx)" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label">Gender</label>
                        <asp:DropDownList ID="ddlGender" CssClass="form-control" runat="server">
                            <asp:ListItem Value="Null">Select Gender</asp:ListItem>
                            <asp:ListItem Value="Male">Male</asp:ListItem>
                            <asp:ListItem Value="Female">Female</asp:ListItem>
                            <asp:ListItem Value="Other">Other</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label">Address</label>
                        <asp:TextBox ID="txtAddress" placeholder="customer address" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>              

                <div class="col-md-12">
                    <div class="form-group">
                        <label class="control-label">Details </label>
                        <asp:TextBox ID="txtDetails" placeholder="customar details" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>                
            </div>
            <asp:Label ID="lblResult" runat="server"></asp:Label>
            <div class="m-t-20 text-center">
                <asp:Button ID="btnCreate" OnClick="btnCreate_Click" CssClass="btn btn-success" runat="server" Text="Create Customer" />
                <asp:Button ID="btnUpdate" CssClass="btn btn-info" runat="server" Text="Update Customer" />
            </div>

        </div>
    </div>

</asp:Content>
