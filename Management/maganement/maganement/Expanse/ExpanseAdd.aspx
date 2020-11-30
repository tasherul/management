<%@ Page Title="" Language="C#" MasterPageFile="~/mDesign.Master" AutoEventWireup="true" CodeBehind="ExpanseAdd.aspx.cs" Inherits="management.Expanse.ExpanseAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Expanse ADD</title>
    	<link href="https://fonts.googleapis.com/css?family=Montserrat:300,400,500,600,700" rel="stylesheet"/>
        <link rel="stylesheet" type="text/css" href="assets/css/bootstrap.min.css"/>
        <link rel="stylesheet" type="text/css" href="assets/css/font-awesome.min.css"/>
        <link rel="stylesheet" type="text/css" href="assets/css/line-awesome.min.css"/>
		<link rel="stylesheet" type="text/css" href="assets/css/dataTables.bootstrap.min.css"/>
		<link rel="stylesheet" type="text/css" href="assets/css/select2.min.css"/>
		<link rel="stylesheet" type="text/css" href="assets/css/bootstrap-datetimepicker.min.css"/>
        <link rel="stylesheet" type="text/css" href="assets/css/style.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="page-wrapper">
                <div class="content container-fluid">
					<div class="row">
						<div class="col-sm-8">
							<h4 class="page-title">Expense Report</h4>
						</div>
					</div>
					<div class="row filter-row">
						<div class="col-sm-3 col-xs-6"> 
							<div class="form-group form-focus select-focus">
								<label class="control-label">Category</label>
                                <asp:DropDownList ID="ddlCategory" CssClass="form-control" runat="server" DataSourceID="SqlDataSource1" DataTextField="CategoryName" DataValueField="ex_id"></asp:DropDownList>
                                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:dbm %>' SelectCommand="SELECT * FROM [ExpanseCategory]"></asp:SqlDataSource>
                            </div>
						</div>

                        <div class="col-sm-3 col-xs-6">
                            <div class="form-group form-focus select-focus">
                                <label class="control-label">Schedule</label>
                                <asp:DropDownList ID="ddlSchedule" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="Monthly">Monthly</asp:ListItem>
                                    <asp:ListItem Value="Daily">Daily</asp:ListItem>
                                     <asp:ListItem Value="Hourly">Hourly</asp:ListItem>
                                    <asp:ListItem Value="Once">Once</asp:ListItem>
                                    <asp:ListItem Value="Weekly">Weekly</asp:ListItem>
                                    <asp:ListItem Value="Yearly">Yearly</asp:ListItem>
                                </asp:DropDownList>
                                
                            </div>
                        </div>
                        <div class="col-sm-3 col-xs-6">
                            <div class="form-group form-focus select-focus">
                                <label class="control-label">Paid By</label>
                                <asp:DropDownList ID="ddlPaidBy" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="Cash">Cash</asp:ListItem>
                                    <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                                     <asp:ListItem Value="Card">Card</asp:ListItem>
                                    <asp:ListItem Value="Bank Transfer">Bank Transfer</asp:ListItem>
                                    <asp:ListItem Value="Money Order">Money Order</asp:ListItem>
                                    <asp:ListItem Value="Mobile Banking">Mobile Banking</asp:ListItem>
                                    <asp:ListItem Value="Agency">Agency</asp:ListItem>
                                </asp:DropDownList>                              
                            </div>
                        </div>
                        

                        
                         <div class="col-sm-3 col-xs-6">  
							<div class="form-group form-focus">
								<label class="control-label">Price</label>
                                <asp:TextBox ID="txtPrice" CssClass="form-control floating" runat="server"></asp:TextBox>
							</div>
						</div>

						<div class="col-sm-3 col-xs-6">  
							<div class="form-group form-focus">
								<label class="control-label">From</label>
								<div class="cal-icon"><asp:TextBox ID="txtFrom" CssClass="form-control floating" runat="server"></asp:TextBox></div>
							</div>
						</div>
						<div class="col-sm-3 col-xs-6">  
							<div class="form-group form-focus">
								<label class="control-label">To</label>
								<div class="cal-icon"><asp:TextBox ID="txtTo" CssClass="form-control floating" runat="server"></asp:TextBox></div>
							</div>
						</div>

                        <div class="col-sm-2 col-xs-6">
                            <div class="form-group form-focus select-focus">
                                <label class="control-label">Staff Payable</label>
                                <asp:DropDownList ID="ddlClient" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                              
                            </div>
                        </div>

                       <div class="col-sm-2 col-xs-6">  
							<div class="form-group form-focus">
								<label class="control-label">Remark</label>
                                <asp:TextBox ID="txtRemark" Height="100" TextMode="MultiLine" CssClass="floating form-control" runat="server"></asp:TextBox>
							</div>
						</div>



                        
						<div class="col-sm-2 col-xs-6">  
                            <asp:Button OnClick="btnAdd_Click" ID="btnAdd" CssClass="btn btn-success btn-block" runat="server" Text="ADD" />
						</div>     
                    </div>

					<div class="row">
						<div class="col-md-12">
							<div class="">
								<table class="table table-striped custom-table m-b-0 datatable">
									<thead>
										<tr>
											<th>#</th>
											<th>Name</th>
											<th>EntryDate</th>
											<th>Schedule</th>
											<th>Amount</th>
											<th>Paid By</th>
                                            <th>Remark</th>
											<th class="text-center">Status</th>
											<th class="text-right">Actions</th>
										</tr>
									</thead>
									<tbody>

                                        <asp:PlaceHolder ID="pnlShowData" runat="server"></asp:PlaceHolder>

										<%--<tr>
											<td>
												<strong>1</strong>
											</td>
											<td>Pias</td>
											<td>5 May 2017</td>
											<td>Loren Gatlin</td>
											<td>$ 1215</td>
											<td>Cash</td>
                                            <td>asdas das asdassad jhjhjk jhk j</td>
											<td class='text-center'>
												<div class='dropdown action-label'>
													<a class='btn btn-white btn-sm rounded dropdown-toggle' href='#' data-toggle='dropdown' aria-expanded='false'>
														<i class='fa fa-dot-circle-o text-danger'></i> Pending <i class='caret'></i>
													</a>
													<ul class='dropdown-menu pull-right'>
														<li><a href='#'><i class='fa fa-dot-circle-o text-danger'></i> Pending</a></li>
														<li><a href='#'><i class='fa fa-dot-circle-o text-success'></i> Approved</a></li>
													</ul>
												</div>
											</td>
											<td class='text-right'>
												<div class='dropdown'>
													<a href='#' class='action-icon dropdown-toggle' data-toggle='dropdown' aria-expanded='false'><i class='fa fa-ellipsis-v'></i></a>
													<ul class='dropdown-menu pull-right'>
														<li><a href='#' title='Delete' data-toggle='modal' data-target='#delete_approve'><i class='fa fa-trash-o m-r-5'></i> Delete</a></li>
													</ul>
												</div>
											</td>
										</tr>	
                                        	
                                        --%>
                                        
                                        								
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
		<script type="text/javascript" src="assets/js/select2.min.js"></script>
		<script type="text/javascript" src="assets/js/moment.min.js"></script>
		<script type="text/javascript" src="assets/js/bootstrap-datetimepicker.min.js"></script>
		<script type="text/javascript" src="assets/js/jquery.slimscroll.js"></script>
		<script type="text/javascript" src="assets/js/app.js"></script>
</asp:Content>
