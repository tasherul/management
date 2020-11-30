<%@ Page Title="" Language="C#" MasterPageFile="~/mDesign.Master" AutoEventWireup="true" CodeBehind="settings.aspx.cs" Inherits="management.Settings.settings" %>
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
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Stock ID </label>
                                        <asp:TextBox ID="txtStockID" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Invoice ID</label>
                                        <asp:TextBox ID="txtInvoiceID" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>Company Name</label>
                                        <asp:TextBox ID="txtCompanyName" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>Company Address</label>
                                        <asp:TextBox ID="txtCompanyAddress1" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>Company Address 2</label>
                                        <asp:TextBox ID="txtCompanyAddress2" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Company Phone </label>
                                        <asp:TextBox ID="txtCompanyPhone" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Image Size (80 x 80) (.jpg .png .jpeg)</label>
                                        <asp:FileUpload ID="ImageUpload" CssClass="form-control" runat="server" />
                                    </div>
                                </div>

                            </div>

                            <div class="row alert-warning">
                                <h5 class=" m-t-10 m-l-10 text-uppercase"><u>Invoice Settings</u></h5>
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>Terms And Condition</label>
                                        <asp:TextBox ID="txtTermsAndCondition" TextMode="MultiLine" Rows="10" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Invoice Barcode Font Size</label>
                                        <asp:TextBox ID="txtInvoiceBarcodeFontSize" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Invoice Barcode Width</label>
                                        <asp:TextBox ID="txtInvoiceBarcodeWidth" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Invoice Barcode Height</label>
                                        <asp:TextBox ID="txtInvoiceBarcodeHeight" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-6 col-md-6 col-lg-3">
                                    <div class="form-group">
                                        <label>Invoice Align</label>
                                        <asp:DropDownList CssClass="form-control select" ID="ddlInvoiceAlign" runat="server">
                                            <asp:ListItem Value="justify-content-center">Center</asp:ListItem>
                                            <asp:ListItem Value="justify-content-end">Right</asp:ListItem>
                                            <asp:ListItem Value="justify-content-between">Left</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                </div>
                                <div class="col-md-6 col-md-6 col-lg-3">
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
                                <div class="col-md-6 col-md-6 col-lg-3">
                                    <div class="form-group">
                                        <label>Return Page Align</label>
                                        <asp:DropDownList CssClass="form-control select" ID="ddlReturnPageAlign" runat="server">
                                            <asp:ListItem Value="justify-content-center">Center</asp:ListItem>
                                            <asp:ListItem Value="justify-content-end">Right</asp:ListItem>
                                            <asp:ListItem Value="justify-content-between">Left</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-6 col-md-6 col-lg-3">
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

                            <div class="row alert-info">
                                <h5 class=" m-t-10 m-l-10 text-uppercase"><u>Sales Settings</u></h5>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Sale Price Editable</label>
                                        <asp:CheckBox ID="chkSalePrice" CssClass="form-control" Text="&nbsp;&nbsp;<- Enable" runat="server" />
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label title="If Disable Sale Price and Sale Quality then It will Auto barcode entry process.">Barcode Sales Quality <i class="fa fa-info-circle" title="If Disable Sale Price and Sale Quality then It will Auto barcode entry process."></i></label>
                                        <asp:CheckBox ID="chkBarcodeQuality" CssClass="form-control" Text="&nbsp;&nbsp;<- Enable" runat="server" />
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Alert Below BuyPrice</label>
                                        <asp:CheckBox ID="chkAlertBuyPrice" CssClass="form-control" Text="&nbsp;&nbsp;<- Enable" runat="server" />
                                    </div>
                                </div>
                            </div>

                            <div class="row alert-success">
                                <h5 class=" m-t-10 m-l-10 text-uppercase"><u>Bar Code Settings</u></h5>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>BarCode</label>
                                        <asp:TextBox ID="txtBarcodeNumber" TextMode="Number" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Width</label>
                                        <asp:TextBox ID="txtBarcodeWidth" TextMode="Number" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Higth</label>
                                        <asp:TextBox ID="txtBarcodeHigth" TextMode="Number" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Font Size</label>
                                        <asp:TextBox ID="txtBarcodeFontSize" TextMode="Number" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>Point X</label>
                                        <asp:TextBox ID="txtBarcodePointX" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>Point Y</label>
                                        <asp:TextBox ID="txtBarcodePointY" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Font Name</label>
                                        <asp:TextBox ID="txtBarCodeFontName" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>Download</label>
                                        <a href="../BarcodeFont/Barcodefont.zip" class="form-control"><i class="fa fa-download"></i>Font</a>

                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Color</label>
                                        <asp:DropDownList ID="ddlColor" CssClass="form-control" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-4 col-lg-3">
                                    <div class="form-group">
                                        <label>Barcode Page Line</label>
                                        <asp:DropDownList CssClass="form-control select" ID="ddlBarcodePageLine" runat="server">
                                            <asp:ListItem Value="col-md-1">PerLine 12 Barcode</asp:ListItem>
                                            <asp:ListItem Value="col-md-2">PerLine 6 Barcode</asp:ListItem>
                                            <asp:ListItem Value="col-md-3">PerLine 4 Barcode</asp:ListItem>
                                            <asp:ListItem Value="col-md-4">PerLine 3 Barcode</asp:ListItem>
                                            <asp:ListItem Value="col-md-6">PerLine 2 Barcode</asp:ListItem>
                                            <asp:ListItem Value="col-md-12">PerLine 1 Barcode</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>Barode Image Width</label>
                                        <asp:TextBox ID="txtBarcodeImageWidth" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>
                                            Company Name
                                                    <asp:CheckBox ID="chkBarcode_CompanyTag" runat="server" /></label>
                                        <asp:TextBox ID="txtBarcode_CompanyName" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>
                                            Price Tag
                                                    <asp:CheckBox ID="chkBarcode_PriceTag" runat="server" /></label>
                                        <asp:TextBox ID="txtBarcode_PriceTag" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Company Name Size</label>
                                        <asp:TextBox ID="txtBarcode_CompanyNameSize" TextMode="Number" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Company Point X</label>
                                        <asp:TextBox ID="txtBarcode_CompanyPointX" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Company Point Y</label>
                                        <asp:TextBox ID="txtBarcode_CompanyPointY" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Company FontName</label>
                                        <asp:TextBox ID="txtBarcode_CompanyFontName" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Company FontSize</label>
                                        <asp:TextBox ID="txtBarcode_CompanyFontSize" TextMode="Number" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Company Color</label>
                                        <asp:DropDownList ID="ddlBarcode_CompanyColor" CssClass="form-control" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Price Tage Size</label>
                                        <asp:TextBox ID="txtBarcode_PriceTagSize" TextMode="Number" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Price Point X</label>
                                        <asp:TextBox ID="txtBarcode_PricePointX" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Price FontName</label>
                                        <asp:TextBox ID="txtBarcode_PriceFontName" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Price FontSize</label>
                                        <asp:TextBox ID="txtBarcode_PriceFontSize" TextMode="Number" CssClass="form-control" placeholder="" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Price Color</label>
                                        <asp:DropDownList ID="ddlBarcode_PriceColor" CssClass="form-control" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>


							<%--	<div class="row">
									<div class="col-md-6">
										<div class="form-group">
											<label>Email</label>
											<input class="form-control" value="danielporter@example.com" type="email">
										</div>
									</div>
									<div class="col-md-6">
										<div class="form-group">
											<label>Phone Number</label>
											<input class="form-control" value="818-978-7102" type="text">
										</div>
									</div>
								</div>--%>
								<%--<div class="row">
									<div class="col-md-6">
										<div class="form-group">
											<label>Mobile Number</label>
											<input class="form-control" value="818-635-5579" type="text">
										</div>
									</div>
									<div class="col-md-6">
										<div class="form-group">
											<label>Fax</label>
											<input class="form-control" value="818-978-7102" type="text">
										</div>
									</div>
								</div>--%>
								<%--<div class="row">
									<div class="col-md-12">
										<div class="form-group">
											<label>Website Url</label>
											<input class="form-control" value="https://www.example.com" type="text">
										</div>
									</div>
								</div>--%>
                            <div class="row">
									<div class="col-md-12 text-center m-t-20">
                                        <asp:Label ID="lblResult" runat="server"></asp:Label>
                                        </div>
                                </div>
								<div class="row">
									<div class="col-md-12 text-center m-t-20">
                                        <asp:Button ID="btnSave" OnClick="btnSave_Click" CssClass="btn btn-primary" runat="server" Text="Save &amp; update" />
						
									</div>
								</div>
							
						</div>
					</div>
                </div>
         </div>
</asp:Content>
