<%@ Page Title="" Language="C#" MasterPageFile="~/mDesign.Master" AutoEventWireup="true" CodeBehind="ReturnList.aspx.cs" Inherits="maganement.Return.ReturnList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Return List</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="page-wrapper">
                <div class="content container-fluid">
					<div class="row">
						<div class="col-xs-8">
							<h4 class="page-title">Jobs</h4>
						</div>
						<div class="col-xs-4 text-right m-b-30">
							<a href="../Product/Product_Add" class="btn btn-primary rounded pull-right"><i class="fa fa-plus"></i> Add New Product</a>
						</div>
					</div>
					<div class="row">
						<div class="col-md-12">
							<div class="table-responsive">
								<table class="table table-striped custom-table m-b-0 datatable">
									<thead>
										<tr>
											<th>#</th>
											<th>Product Name</th>
											<th>Quantity</th>
											<th>Return Price</th>
											<th>Amount</th>
                                            <th>Unit</th>
                                             <th>Supplier</th>
											<th>Date</th>
											<th class="text-right">Actions</th>
										</tr>
									</thead>
									<tbody>
                                        <asp:PlaceHolder ID="pnlShow" runat="server"></asp:PlaceHolder>
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
		<script type="text/javascript" src="assets/js/jquery.dataTables.min.js"></script>
		<script type="text/javascript" src="assets/js/dataTables.bootstrap.min.js"></script>
		<script type="text/javascript" src="assets/js/jquery.slimscroll.js"></script>
		<script type="text/javascript" src="assets/js/select2.min.js"></script>
		<script type="text/javascript" src="assets/js/moment.min.js"></script>
		<script type="text/javascript" src="assets/js/bootstrap-datetimepicker.min.js"></script>
		<script type="text/javascript" src="assets/js/app.js"></script>
</asp:Content>
