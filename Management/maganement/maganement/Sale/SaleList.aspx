﻿<%@ Page Title="" Language="C#" MasterPageFile="~/mDesign.Master" AutoEventWireup="true" CodeBehind="SaleList.aspx.cs" Inherits="management.Sale.SaleList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Sale List</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
         <div class="page-wrapper">
                <div class="content container-fluid">
					<div class="row">
						<div class="col-sm-8 col-xs-6">
							<h4 class="page-title">Stock List</h4>
						</div>
						<div class="col-sm-4 col-xs-6 text-right m-b-30">
							<a href="../Product/Product_Stock" class="btn btn-primary rounded pull-right"><i class="fa fa-plus"></i> Add Stock</a>
						</div>
                        <div class="col-sm-9"></div>
                        <div class="col-sm-3 right">
                            <input id="myInput" class="form-control" type="text" placeholder="Search.." />
                        </div>
					</div>
					
					<div class="row">
						<div class="col-md-12">
							<div>
								<table class="table table-striped custom-table m-b-0 datatable">
									<thead>
										<tr>
											<th>Invoice</th>
											<th>Memo</th>																					
											<th>CustomerName</th>
											<th>CustomerMobile</th>
                                            <th>Product</th>
                                            <th>Quantity</th>	
                                            <th>SubTotal</th>	
                                            <th>Payment</th>	
                                            <th>TotalDue</th>	
                                            <th>SubmitDate</th>	
                                            <th>Type</th>	
											<th class="text-right">Actions</th>
										</tr>
									</thead>
									<tbody id="myTable">
                                        <asp:PlaceHolder ID="pnlShow" runat="server"></asp:PlaceHolder>
										
                                  <%--      --%>
									
									</tbody>
								</table>
							</div>
						</div>
					</div>
                </div>
         </div>
    <div class="sidebar-overlay" data-reff="#sidebar"></div>
    <script src="../assets/js/jquery.min.js"></script>
        <script type="text/javascript" src="assets/js/jquery-3.2.1.min.js"></script>
        <script type="text/javascript" src="assets/js/bootstrap.min.js"></script>
		<script type="text/javascript" src="assets/js/jquery.dataTables.min.js"></script>
		<script type="text/javascript" src="assets/js/dataTables.bootstrap.min.js"></script>
		<script type="text/javascript" src="assets/js/jquery.slimscroll.js"></script>
		<script type="text/javascript" src="assets/js/select2.min.js"></script>
		<script type="text/javascript" src="assets/js/moment.min.js"></script>
		<script type="text/javascript" src="assets/js/bootstrap-datetimepicker.min.js"></script>
		<script type="text/javascript" src="assets/js/app.js"></script>
    <script>
        $(document).ready(function () {
            $("#myInput").on("keyup", function () {
                var value = $(this).val().toLowerCase();
                $("#myTable tr").filter(function () {
                    $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                });
            });
        });
    </script>

</asp:Content>
