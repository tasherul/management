<%@ Page Title="" Language="C#" MasterPageFile="~/mDesign.Master" AutoEventWireup="true" CodeBehind="Product_Add.aspx.cs" Inherits="maganement.Product.Product_Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>Product ADD</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
        <div class="page-wrapper">
                <div class="content container-fluid">					
					<div class="row">
						<div class="col-md-10 col-md-offset-2">
                            <div class="form-horizontal">

								<h4 class="page-title">Product</h4>
                                <asp:Panel ID="pnlDelete" runat="server">
                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">Product Name:<span style="color: red;">*</span> </label>
                                        <div class="col-lg-9">
                                            <asp:TextBox ID="txtProductName" placeholder="product name" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">Product Buing Price:<span style="color: red;">*</span></label>
                                        <div class="col-lg-9">
                                            <asp:TextBox ID="txtBuingPrice" placeholder="buing price" CssClass="form-control" runat="server"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">Product Selling Price:<span style="color: red;">*</span></label>
                                        <div class="col-lg-9">
                                            <asp:TextBox ID="txtSellingPrice" placeholder="selling price" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">Unit:<span style="color: red;">*</span></label>
                                        <div class="col-lg-9">
                                            <asp:DropDownList ID="ddlUnit" CssClass="form-control" runat="server">
                                                <asp:ListItem Selected="True" Value="0">Select Product Unit</asp:ListItem>
                                                <asp:ListItem Value="Pics">Pics</asp:ListItem>
                                                <asp:ListItem Value="Packet">Packet</asp:ListItem>
                                                <asp:ListItem Value="kilogram">kilogram (KG)</asp:ListItem>
                                                <asp:ListItem Value="Gram">Gram (G)</asp:ListItem>
                                                <asp:ListItem Value="Pound">Pound (P)</asp:ListItem>
                                                <asp:ListItem Value="Ton">Ton (T)</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">Brand:<span style="color: red;">*</span></label>
                                        <div class="col-lg-9">
                                            <asp:DropDownList ID="ddlBrand" CssClass="form-control" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">Product Description:</label>
                                        <div class="col-lg-9">
                                            <asp:TextBox ID="txtDescription" placeholder="product discription...." TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </asp:Panel>


                                <asp:Label ID="lblResult" runat="server"></asp:Label>
								<div class="col-sm-12 m-t-20 text-center">
                                    <asp:Button ID="btnSave" OnClick="btnSave_Click" CssClass="btn btn-success" runat="server" Text="Save" />
									<asp:Button ID="btnUpdate" OnClick="btnUpdate_Click" CssClass="btn btn-primary" runat="server" Text="Update" />
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
		<script type="text/javascript" src="assets/js/app.js"></script>
</asp:Content>
