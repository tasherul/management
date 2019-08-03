<%@ Page Title="" Language="C#" MasterPageFile="~/mDesign.Master" AutoEventWireup="true" CodeBehind="Customer_List.aspx.cs" Inherits="maganement.CustomerSupplier.Customer_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Customer List</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
        <div class="page-wrapper">
                <div class="content container-fluid">
					<div class="row">
						<div class="col-sm-4 col-xs-3">
							<h4 class="page-title">Clients</h4>
						</div>
						<div class="col-sm-8 col-xs-9 text-right m-b-20">
							<a href="#" class="btn btn-primary rounded pull-right" data-toggle="modal" data-target="#add_client"><i class="fa fa-plus"></i> Add Client</a>	
						</div>
					</div>
					<div class="row filter-row">
						
						<div class="col-sm-3 col-xs-6">  
							<div class="form-group form-focus">
								<label class="control-label">Client Name</label>
								<input type="text" class="form-control floating" />
							</div>
						</div>						
						<div class="col-sm-3 col-xs-6">  
							<a href="#" class="btn btn-success btn-block"> Search </a>  
						</div>     
                    </div>

					<div class="row staff-grid-row">
						<div class="col-md-4 col-sm-4 col-xs-6 col-lg-3">
							<div class="profile-widget">
								<div class="profile-img">
									<a href="client-profile.html" class="avatar">G</a>
								</div>
								<div class="dropdown profile-action">
									<a href="#" class="action-icon dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a>
									<ul class="dropdown-menu pull-right">
										<li><a href="#" data-toggle="modal" data-target="#edit_client"><i class="fa fa-pencil m-r-5"></i> Edit</a></li>
										<li><a href="#" data-toggle="modal" data-target="#delete_client"><i class="fa fa-trash-o m-r-5"></i> Delete</a></li>
									</ul>
								</div>
								<h4 class="user-name m-t-10 m-b-0 text-ellipsis"><a href="client-profile.html">Global Technologies</a></h4>
								<h5 class="user-name m-t-10 m-b-0 text-ellipsis"><a href="client-profile.html">Barry Cuda</a></h5>
								<div class="small text-muted">CEO</div>
								<a href="chat.html" class="btn btn-default btn-sm m-t-10">Message</a>
								<a href="client-profile.html" class="btn btn-default btn-sm m-t-10">View Profile</a>
							</div>
						</div>
						<div class="col-md-4 col-sm-4 col-xs-6 col-lg-3">
							<div class="profile-widget">
								<div class="profile-img">
									<a href="client-profile.html" class="avatar">G</a>
								</div>
								<div class="dropdown profile-action">
									<a href="#" class="action-icon dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a>
									<ul class="dropdown-menu pull-right">
										<li><a href="#" data-toggle="modal" data-target="#edit_client"><i class="fa fa-pencil m-r-5"></i> Edit</a></li>
										<li><a href="#" data-toggle="modal" data-target="#delete_client"><i class="fa fa-trash-o m-r-5"></i> Delete</a></li>
									</ul>
								</div>
								<h4 class="user-name m-t-10 m-b-0 text-ellipsis"><a href="client-profile.html">Delta Infotech</a></h4>
								<h5 class="user-name m-t-10 m-b-0 text-ellipsis"><a href="client-profile.html">Tressa Wexler</a></h5>
								<div class="small text-muted">Manager</div>
								<a href="chat.html" class="btn btn-default btn-sm m-t-10">Message</a>
								<a href="client-profile.html" class="btn btn-default btn-sm m-t-10">View Profile</a>
							</div>
						</div>
						<div class="col-md-4 col-sm-4 col-xs-6 col-lg-3">
							<div class="profile-widget">
								<div class="profile-img">
									<a href="client-profile.html" class="avatar">G</a>
								</div>
								<div class="dropdown profile-action">
									<a href="#" class="action-icon dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a>
									<ul class="dropdown-menu pull-right">
										<li><a href="#" data-toggle="modal" data-target="#edit_client"><i class="fa fa-pencil m-r-5"></i> Edit</a></li>
										<li><a href="#" data-toggle="modal" data-target="#delete_client"><i class="fa fa-trash-o m-r-5"></i> Delete</a></li>
									</ul>
								</div>
								<h4 class="user-name m-t-10 m-b-0 text-ellipsis"><a href="client-profile.html">Cream Inc</a></h4>
								<h5 class="user-name m-t-10 m-b-0 text-ellipsis"><a href="client-profile.html">Ruby Bartlett</a></h5>
								<div class="small text-muted">CEO</div>
								<a href="chat.html" class="btn btn-default btn-sm m-t-10">Message</a>
								<a href="client-profile.html" class="btn btn-default btn-sm m-t-10">View Profile</a>
							</div>
						</div>
						<div class="col-md-4 col-sm-4 col-xs-6 col-lg-3">
							<div class="profile-widget">
								<div class="profile-img">
									<a href="client-profile.html" class="avatar">G</a>
								</div>
								<div class="dropdown profile-action">
									<a href="#" class="action-icon dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a>
									<ul class="dropdown-menu pull-right">
										<li><a href="#" data-toggle="modal" data-target="#edit_client"><i class="fa fa-pencil m-r-5"></i> Edit</a></li>
										<li><a href="#" data-toggle="modal" data-target="#delete_client"><i class="fa fa-trash-o m-r-5"></i> Delete</a></li>
									</ul>
								</div>
								<h4 class="user-name m-t-10 m-b-0 text-ellipsis"><a href="client-profile.html">Wellware Company</a></h4>
								<h5 class="user-name m-t-10 m-b-0 text-ellipsis"><a href="client-profile.html">Misty Tison</a></h5>
								<div class="small text-muted">CEO</div>
								<a href="chat.html" class="btn btn-default btn-sm m-t-10">Message</a>
								<a href="client-profile.html" class="btn btn-default btn-sm m-t-10">View Profile</a>
							</div>
						</div>
						<div class="col-md-4 col-sm-4 col-xs-6 col-lg-3">
							<div class="profile-widget">
								<div class="profile-img">
									<a href="client-profile.html" class="avatar">G</a>
								</div>
								<div class="dropdown profile-action">
									<a href="#" class="action-icon dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a>
									<ul class="dropdown-menu pull-right">
										<li><a href="#" data-toggle="modal" data-target="#edit_client"><i class="fa fa-pencil m-r-5"></i> Edit</a></li>
										<li><a href="#" data-toggle="modal" data-target="#delete_client"><i class="fa fa-trash-o m-r-5"></i> Delete</a></li>
									</ul>
								</div>
								<h4 class="user-name m-t-10 m-b-0 text-ellipsis"><a href="client-profile.html">Mustang Technologies</a></h4>
								<h5 class="user-name m-t-10 m-b-0 text-ellipsis"><a href="client-profile.html">Daniel Deacon</a></h5>
								<div class="small text-muted">CEO</div>
								<a href="chat.html" class="btn btn-default btn-sm m-t-10">Message</a>
								<a href="client-profile.html" class="btn btn-default btn-sm m-t-10">View Profile</a>
							</div>
						</div>
						<div class="col-md-4 col-sm-4 col-xs-6 col-lg-3">
							<div class="profile-widget">
								<div class="profile-img">
									<a href="client-profile.html" class="avatar">G</a>
								</div>
								<div class="dropdown profile-action">
									<a href="#" class="action-icon dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a>
									<ul class="dropdown-menu pull-right">
										<li><a href="#" data-toggle="modal" data-target="#edit_client"><i class="fa fa-pencil m-r-5"></i> Edit</a></li>
										<li><a href="#" data-toggle="modal" data-target="#delete_client"><i class="fa fa-trash-o m-r-5"></i> Delete</a></li>
									</ul>
								</div>
								<h4 class="user-name m-t-10 m-b-0 text-ellipsis"><a href="client-profile.html">International Software Inc</a></h4>
								<h5 class="user-name m-t-10 m-b-0 text-ellipsis"><a href="client-profile.html">Walter Weaver</a></h5>
								<div class="small text-muted">CEO</div>
								<a href="chat.html" class="btn btn-default btn-sm m-t-10">Message</a>
								<a href="client-profile.html" class="btn btn-default btn-sm m-t-10">View Profile</a>
							</div>
						</div>
						<div class="col-md-4 col-sm-4 col-xs-6 col-lg-3">
							<div class="profile-widget">
								<div class="profile-img">
									<a href="client-profile.html" class="avatar">G</a>
								</div>
								<div class="dropdown profile-action">
									<a href="#" class="action-icon dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a>
									<ul class="dropdown-menu pull-right">
										<li><a href="#" data-toggle="modal" data-target="#edit_client"><i class="fa fa-pencil m-r-5"></i> Edit</a></li>
										<li><a href="#" data-toggle="modal" data-target="#delete_client"><i class="fa fa-trash-o m-r-5"></i> Delete</a></li>
									</ul>
								</div>
								<h4 class="user-name m-t-10 m-b-0 text-ellipsis"><a href="client-profile.html">Mercury Software Inc</a></h4>
								<h5 class="user-name m-t-10 m-b-0 text-ellipsis"><a href="client-profile.html">Amanda Warren</a></h5>
								<div class="small text-muted">CEO</div>
								<a href="chat.html" class="btn btn-default btn-sm m-t-10">Message</a>
								<a href="client-profile.html" class="btn btn-default btn-sm m-t-10">View Profile</a>
							</div>
						</div>
						<div class="col-md-4 col-sm-4 col-xs-6 col-lg-3">
							<div class="profile-widget">
								<div class="profile-img">
									<a href="client-profile.html" class="avatar">G</a>
								</div>
								<div class="dropdown profile-action">
									<a href="#" class="action-icon dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a>
									<ul class="dropdown-menu pull-right">
										<li><a href="#" data-toggle="modal" data-target="#edit_client"><i class="fa fa-pencil m-r-5"></i> Edit</a></li>
										<li><a href="#" data-toggle="modal" data-target="#delete_client"><i class="fa fa-trash-o m-r-5"></i> Delete</a></li>
									</ul>
								</div>
								<h4 class="user-name m-t-10 m-b-0 text-ellipsis"><a href="client-profile.html">Carlson Tech</a></h4>
								<h5 class="user-name m-t-10 m-b-0 text-ellipsis"><a href="client-profile.html">Betty Carlson</a></h5>
								<div class="small text-muted">CEO</div>
								<a href="chat.html" class="btn btn-default btn-sm m-t-10">Message</a>
								<a href="client-profile.html" class="btn btn-default btn-sm m-t-10">View Profile</a>
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
