<%@ Page Title="" Language="C#" MasterPageFile="~/mDesign.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Sub_Category_List.aspx.cs" Inherits="management.BrandCategory.Sub_Category_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="https://fonts.googleapis.com/css?family=Montserrat:300,400,500,600,700" rel="stylesheet"/>
        <link rel="stylesheet" type="text/css" href="assets/css/bootstrap.min.css"/>
        <link rel="stylesheet" type="text/css" href="assets/css/font-awesome.min.css"/>
        <link rel="stylesheet" type="text/css" href="assets/css/line-awesome.min.css"/>
		<link rel="stylesheet" type="text/css" href="assets/css/select2.min.css"/>
		<link rel="stylesheet" type="text/css" href="assets/css/bootstrap-datetimepicker.min.css"/>
        <link rel="stylesheet" type="text/css" href="assets/css/style.css"/>
    <title>Sub Category List</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
     <div class="page-wrapper">
                <div class="content container-fluid">
					<div class="row">
						<div class="col-sm-8">
							<h4 class="page-title">Invoices</h4>
						</div>						
					</div>

					<div class="row filter-row">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <Triggers><asp:PostBackTrigger ControlID="btnShow" /></Triggers>
                            <ContentTemplate>
                                <div class="col-sm-3 col-xs-6">
                                    <div class="form-group form-focus select-focus">
                                        <label class="control-label">Wirehouse</label>
                                        <asp:DropDownList ID="ddlWirehouse" OnTextChanged="ddlWirehouse_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:DropDownList>

                                    </div>
                                </div>					
                                <div class="col-sm-3 col-xs-6">
                                    <div class="form-group form-focus select-focus">
                                        <label class="control-label">Category</label>
                                        <asp:DropDownList ID="ddlCategory" CssClass="form-control" runat="server"></asp:DropDownList>

                                    </div>
                                </div>
                                <div class="col-sm-3 col-xs-6">
                                    <asp:Button ID="btnShow" OnClick="btnShow_Click" CssClass="btn btn-success btn-block" runat="server" Text="Search" />
                                </div>  
                                <div class="col-sm-3 col-xs-6">
                                    <asp:Label ID="lblResult" runat="server"></asp:Label>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        

						   
                    </div>

					<div class="row">
						<div class="col-md-12">
							<div class="table-responsive">
                            

								<table class="table table-striped custom-table m-b-0">
									<thead>
										<tr>
											<th>#</th>
											<th>Sub Category Name</th>
											<th>Category Name</th>											
											<th class="text-right">Action</th>
										</tr>
									</thead>
									<tbody>
                                        <asp:PlaceHolder ID="pnlDataShow" runat="server"></asp:PlaceHolder>
										
								
									</tbody>
								</table>
                                
							</div>
						</div>
					</div>
                </div>
         </div>
    		<div class="sidebar-overlay" data-reff="#sidebar"></div>
        <script type="text/javascript" src="assets/js/jquery-3.2.1.min.js"></script>
        <script type="text/javascript" src="assets/js/bootstrap.min.js"></script>
		<script type="text/javascript" src="assets/js/select2.min.js"></script>
		<script type="text/javascript" src="assets/js/jquery.slimscroll.js"></script>
		<script type="text/javascript" src="assets/js/moment.min.js"></script>
		<script type="text/javascript" src="assets/js/bootstrap-datetimepicker.min.js"></script>
		<script type="text/javascript" src="assets/js/app.js"></script>
</asp:Content>
