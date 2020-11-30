<%@ Page Title="" Language="C#" MasterPageFile="~/mDesign.Master" AutoEventWireup="true" CodeBehind="Category_List.aspx.cs" Inherits="management.BrandCategory.Category_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Category List</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
     <div class="page-wrapper">
                <div class="content container-fluid">
					<div class="row">
						<div class="col-sm-8">
							<h4 class="page-title">Category List</h4>
						</div>
                        <div class="col-sm-4 col-xs-6 text-right m-b-30">
                            <asp:LinkButton ID="LinkButton1" CssClass="btn btn-primary rounded pull-right" runat="server"><i class="fa  fa-check"></i> Show Data</asp:LinkButton>
						</div>						
					</div>
					<div class="row">
						<div class="col-md-12">
							<div>
								<table class="table table-striped custom-table m-b-0 datatable">
									<thead>
										<tr>
											<th>#</th>
											<th>Category Name</th>
											<th class="text-right">Action</th>
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
		<script type="text/javascript" src="assets/js/app.js"></script>


</asp:Content>
