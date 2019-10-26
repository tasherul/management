<%@ Page Title="" Language="C#" MasterPageFile="~/mDesign.Master" AutoEventWireup="true" CodeBehind="settings.aspx.cs" Inherits="maganement.Settings.settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <title>Settings</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
      <div class="page-wrapper">
                <div class="content container-fluid">
					<div class="row">
						<div class="col-md-8 col-md-offset-2">						
								<h3 class="page-title">Settings</h3>
								<div class="row">
									<div class="col-sm-6">
										<div class="form-group">
											<label>Stock ID </label>
                                            <asp:TextBox ID="txtStockID" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
										</div>
									</div>
									<div class="col-sm-6">
										<div class="form-group">
											<label>Invoice ID</label>											
                                            <asp:TextBox ID="txtInvoiceID" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
										</div>
									</div>
								</div>
								<div class="row">
									<div class="col-sm-12">
										<div class="form-group">
											<label>Company Name</label>											
                                            <asp:TextBox ID="txtCompanyName" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
										</div>
									</div>
                                    <div class="col-sm-12">
										<div class="form-group">
											<label>Company Address</label>
											<asp:TextBox ID="txtCompanyAddress1" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
										</div>
									</div>
                                    <div class="col-sm-12">
										<div class="form-group">
											<label>Company Address 2</label>
											<asp:TextBox ID="txtCompanyAddress2" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
										</div>
									</div>
                                    <div class="col-sm-6">
										<div class="form-group">
											<label>Company Phone </label>
											<asp:TextBox ID="txtCompanyPhone" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
										</div>
									</div>
									<div class="col-sm-6">
										<div class="form-group">
											<label>Image Size (80 x 80) (.jpg .png .jpeg)</label>
                                            <asp:FileUpload ID="ImageUpload" CssClass="form-control" runat="server" />
										</div>
									</div>
                                      <div class="col-sm-12">
										<div class="form-group">
											<label>Terms And Condition</label>
											<asp:TextBox ID="txtTermsAndCondition" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
										</div>
									</div>
                                    <div class="col-sm-4">
										<div class="form-group">
											<label>Invoice Barcode Font Size</label>
											<asp:TextBox ID="txtInvoiceBarcodeFontSize" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
										</div>
									</div>
                                    <div class="col-sm-4">
										<div class="form-group">
											<label>Invoice Barcode Width</label>
											<asp:TextBox ID="txtInvoiceBarcodeWidth" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
										</div>
									</div>
                                    <div class="col-sm-4">
										<div class="form-group">
											<label>Invoice Barcode Height</label>
											<asp:TextBox ID="txtInvoiceBarcodeHeight" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
										</div>
									</div>

									<div class="col-sm-6 col-md-6 col-lg-3">
										<div class="form-group">
											<label>Invoice Align</label>
                                            <asp:DropDownList CssClass="form-control select" ID="ddlInvoiceAlign" runat="server">
                                                <asp:ListItem Value="justify-content-center">Center</asp:ListItem>
                                                <asp:ListItem Value="justify-content-end">Right</asp:ListItem>
                                                <asp:ListItem Value="justify-content-between">Left</asp:ListItem>
                                            </asp:DropDownList>
										
										</div>
									</div>
									<div class="col-sm-6 col-md-6 col-lg-3">
										<div class="form-group">
											<label>Invoice Size</label>
											<asp:DropDownList CssClass="form-control select" ID="ddlInvoiceSize" runat="server">
                                                <asp:ListItem Value="col-md-4">4</asp:ListItem>
                                                <asp:ListItem Value="col-md-5">5</asp:ListItem>
                                                <asp:ListItem Value="col-md-6">6</asp:ListItem>
                                                <asp:ListItem Value="col-md-7">7</asp:ListItem>
                                                <asp:ListItem Value="col-md-8">8</asp:ListItem>
                                                <asp:ListItem Value="col-md-9">9</asp:ListItem>
                                                <asp:ListItem Value="col-md-10">10</asp:ListItem>
                                                <asp:ListItem Value="col-md-11">11</asp:ListItem>
                                                <asp:ListItem Value="col-md-12">12</asp:ListItem>
                                            </asp:DropDownList>
										</div>
									</div>
									<div class="col-sm-6 col-md-6 col-lg-3">
										<div class="form-group">
											<label>Return Page Align</label>
											<asp:DropDownList CssClass="form-control select" ID="ddlReturnPageAlign" runat="server">
                                                <asp:ListItem Value="justify-content-center">Center</asp:ListItem>
                                                <asp:ListItem Value="justify-content-end">Right</asp:ListItem>
                                                <asp:ListItem Value="justify-content-between">Left</asp:ListItem>
                                            </asp:DropDownList>
										</div>
									</div>
									<div class="col-sm-6 col-md-6 col-lg-3">
										<div class="form-group">
											<label>Return Page Size</label>
											<asp:DropDownList CssClass="form-control select" ID="ddlRetuenPageSize" runat="server">
                                                <asp:ListItem Value="col-md-4">4</asp:ListItem>
                                                <asp:ListItem Value="col-md-5">5</asp:ListItem>
                                                <asp:ListItem Value="col-md-6">6</asp:ListItem>
                                                <asp:ListItem Value="col-md-7">7</asp:ListItem>
                                                <asp:ListItem Value="col-md-8">8</asp:ListItem>
                                                <asp:ListItem Value="col-md-9">9</asp:ListItem>
                                                <asp:ListItem Value="col-md-10">10</asp:ListItem>
                                                <asp:ListItem Value="col-md-11">11</asp:ListItem>
                                                <asp:ListItem Value="col-md-12">12</asp:ListItem>
                                            </asp:DropDownList>
										</div>
									</div>
								</div>
							<%--	<div class="row">
									<div class="col-sm-6">
										<div class="form-group">
											<label>Email</label>
											<input class="form-control" value="danielporter@example.com" type="email">
										</div>
									</div>
									<div class="col-sm-6">
										<div class="form-group">
											<label>Phone Number</label>
											<input class="form-control" value="818-978-7102" type="text">
										</div>
									</div>
								</div>--%>
								<%--<div class="row">
									<div class="col-sm-6">
										<div class="form-group">
											<label>Mobile Number</label>
											<input class="form-control" value="818-635-5579" type="text">
										</div>
									</div>
									<div class="col-sm-6">
										<div class="form-group">
											<label>Fax</label>
											<input class="form-control" value="818-978-7102" type="text">
										</div>
									</div>
								</div>--%>
								<%--<div class="row">
									<div class="col-sm-12">
										<div class="form-group">
											<label>Website Url</label>
											<input class="form-control" value="https://www.example.com" type="text">
										</div>
									</div>
								</div>--%>
                            <div class="row">
									<div class="col-sm-12 text-center m-t-20">
                                        <asp:Label ID="lblResult" runat="server"></asp:Label>
                                        </div>
                                </div>
								<div class="row">
									<div class="col-sm-12 text-center m-t-20">
                                        <asp:Button ID="btnSave" OnClick="btnSave_Click" CssClass="btn btn-primary" runat="server" Text="Save &amp; update" />
						
									</div>
								</div>
							
						</div>
					</div>
                </div>
         </div>
</asp:Content>
