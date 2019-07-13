﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0">
        <link rel="shortcut icon" type="image/x-icon" href="../assets/img/favicon.png">
        <title>Department - HRMS admin template</title>
		<link href="https://fonts.googleapis.com/css?family=Montserrat:300,400,500,600,700" rel="stylesheet">
        <link rel="stylesheet" type="text/css" href="../assets/css/bootstrap.min.css">
        <link rel="stylesheet" type="text/css" href="../assets/css/font-awesome.min.css">
        <link rel="stylesheet" type="text/css" href="../assets/css/line-awesome.min.css">
		<link rel="stylesheet" type="text/css" href="../assets/css/dataTables.bootstrap.min.css">
        <link rel="stylesheet" type="text/css" href="../assets/css/style.css">
		<!--[if lt IE 9]>
			<script src="../assets/js/html5shiv.min.js"></script>
			<script src="../assets/js/respond.min.js"></script>
			
			table table-striped custom-table m-b-0 datatable">
		<![endif]-->
		<script type="javascript">
		$('#myTable').DataTable( {
    buttons: [
        'copy', 'excel', 'pdf'
    ]
} );
		</script>
		
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <div class="main-wrapper">
            <div class="header">
			
                <div class="header-left">
                    <a href="index.html" class="logo">
						<img src="../assets/img/logo.png" width="40" height="40" alt="">
					</a>
                </div>
				<a id="toggle_btn" href="javascript:void(0);"><i class="la la-bars"></i></a>
                <div class="page-title-box pull-left">
					<h3>Focus Technologies</h3>
                </div>
				<a id="mobile_btn" class="mobile_btn pull-left" href="#sidebar"><i class="fa fa-bars" aria-hidden="true"></i></a>
				<ul class="nav navbar-nav navbar-right user-menu pull-right">
					<li class="dropdown hidden-xs">
						<a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="fa fa-bell-o"></i> <span class="badge bg-purple pull-right">3</span></a>
						<div class="dropdown-menu notifications">
							<div class="topnav-dropdown-header">
								<span>Notifications</span>
							</div>
							<div class="drop-scroll">
								<ul class="media-list">
									<li class="media notification-message">
										<a href="activities.html">
											<div class="media-left">
												<span class="avatar">
													<img alt="John Doe" src="../assets/img/user.jpg" class="img-responsive img-circle">
												</span>
											</div>
											<div class="media-body">
												<p class="m-0 noti-details"><span class="noti-title">John Doe</span> added new task <span class="noti-title">Patient appointment booking</span></p>
												<p class="m-0"><span class="notification-time">4 mins ago</span></p>
											</div>
										</a>
									</li>
									<li class="media notification-message">
										<a href="activities.html">
											<div class="media-left">
												<span class="avatar">V</span>
											</div>
											<div class="media-body">
												<p class="m-0 noti-details"><span class="noti-title">Tarah Shropshire</span> changed the task name <span class="noti-title">Appointment booking with payment gateway</span></p>
												<p class="m-0"><span class="notification-time">6 mins ago</span></p>
											</div>
										</a>
									</li>
									<li class="media notification-message">
										<a href="activities.html">
											<div class="media-left">
												<span class="avatar">L</span>
											</div>
											<div class="media-body">
												<p class="m-0 noti-details"><span class="noti-title">Misty Tison</span> added <span class="noti-title">Domenic Houston</span> and <span class="noti-title">Claire Mapes</span> to project <span class="noti-title">Doctor available module</span></p>
												<p class="m-0"><span class="notification-time">8 mins ago</span></p>
											</div>
										</a>
									</li>
									<li class="media notification-message">
										<a href="activities.html">
											<div class="media-left">
												<span class="avatar">G</span>
											</div>
											<div class="media-body">
												<p class="m-0 noti-details"><span class="noti-title">Rolland Webber</span> completed task <span class="noti-title">Patient and Doctor video conferencing</span></p>
												<p class="m-0"><span class="notification-time">12 mins ago</span></p>
											</div>
										</a>
									</li>
									<li class="media notification-message">
										<a href="activities.html">
											<div class="media-left">
												<span class="avatar">V</span>
											</div>
											<div class="media-body">
												<p class="m-0 noti-details"><span class="noti-title">Bernardo Galaviz</span> added new task <span class="noti-title">Private chat module</span></p>
												<p class="m-0"><span class="notification-time">2 days ago</span></p>
											</div>
										</a>
									</li>
								</ul>
							</div>
							<div class="topnav-dropdown-footer">
								<a href="activities.html">View all Notifications</a>
							</div>
						</div>
					</li>
					<li class="dropdown hidden-xs">
						<a href="javascript:;" id="open_msg_box" class="hasnotifications"><i class="fa fa-comment-o"></i> <span class="badge bg-purple pull-right">8</span></a>
					</li>	
					<li class="dropdown">
						<a href="profile.html" class="dropdown-toggle user-link" data-toggle="dropdown" title="Admin">
							<span class="user-img"><img class="img-circle" src="../assets/img/user.jpg" width="40" alt="Admin">
							<span class="status online"></span></span>
							<span>Admin</span>
							<i class="caret"></i>
						</a>
						<ul class="dropdown-menu">
							<li><a href="profile.html">My Profile</a></li>
							<li><a href="edit-profile.html">Edit Profile</a></li>
							<li><a href="settings.html">Settings</a></li>
							<li><a href="login.html">Logout</a></li>
						</ul>
					</li>
				</ul>
				<div class="dropdown mobile-user-menu pull-right">
					<a href="#" class="dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a>
					<ul class="dropdown-menu pull-right">
						<li><a href="profile.html">My Profile</a></li>
						<li><a href="edit-profile.html">Edit Profile</a></li>
						<li><a href="settings.html">Settings</a></li>
						<li><a href="login.html">Logout</a></li>
					</ul>
				</div>
            </div>
			
			
            <div class="sidebar" id="sidebar">
                <div class="sidebar-inner slimscroll">
					<div id="sidebar-menu" class="sidebar-menu">
						<ul>
							  <li > 
								<a href="dashboard.html/"><i class="la la-dashboard"></i> <span>Dashboard</span></a>
							</li>
							
							<li class="submenu">
								<a href="#" ><i class="la la-folder-open"></i> <span>Brand & Catagory</span><span class="menu-arrow"></span>  </a>
								<ul style="display: none;">
								<li><a href="#" class="active"> Catagory</a></li>
								<li><a href="#"> Catagory List</a></li>
								<li><a href="#">Sub Catagory  </a></li>
								 <li><a href="#">Sub Catagory List</a></li>
								 <li><a href="#">Brand</a></li>
								 <li><a href="#">Brand List</a></li>
 
								</ul>
							</li>
							<li class="submenu">
								<a href="#"  ><i class="la la-plus-square"></i> <span>Product</span><span class="menu-arrow"></span> </a>
								<ul style="display: none;">
									<li><a href="#">Product Add</a></li>
									<li><a href="#">Product List</a></li>
									<li><a href="#">Product Quality</a></li>
 
								</ul>
							</li>
							
							<li class="submenu">
								<a href="#"  ><i class="la la-user-plus"></i> <span>Customar & Supplier</span><span class="menu-arrow"></span> </a>
								<ul style="display: none;">
									<li><a href="#">Customar Add</a></li>
									<li><a href="#">Customar List</a></li>
									<li><a href="#">Supplier Add</a></li>
									<li><a href="#">Supplier List</a></li>
									  
								</ul>
							</li>
							
							<li class="submenu">
								<a href="#"  ><i class="la la-cart-plus"></i> <span>Product Sale</span><span class="menu-arrow"></span>  </a>
								<ul style="display: none;">
									<li><a href="#">Wholesale</a></li>
									<li><a href="#">Retailer</a></li>
									<li><a href="#">Sale List</a></li>
								</ul>
							</li>
							
							<li class="submenu">
								<a href="#"  ><i class="la la-caret-left"></i> <span> Return</span><span class="menu-arrow"></span>  </a>
								<ul style="display: none;">
									<li><a href="#">Sale</a></li>
									<li><a href="#">Return Sale List</a></li>
									<li><a href="#">Purchase</a></li>
									<li><a href="#">Return Purchase List</a></li>
 								
								</ul>
							</li>
							
							<li class="submenu">
								<a href="#"><i class="la la-money"></i> <span>Expanse</span> <span class="menu-arrow"></span></a>
								<ul style="display: none;">
									<li><a href="#"> Expense Catagory</a></li>
									<li><a href="#"> Catagory List</a></li>
									<li><a href="#">ADD Expense </a></li> 
								</ul>
							</li>
							
							<li class="submenu">
								<a href="#"><i class="la la-ship"></i> <span>Transfer</span> <span class="menu-arrow"></span></a>
								<ul style="display: none;">
									<li><a href="#"> Add Transfer</a></li>
									<li><a href="#"> Transfer List</a></li>
 
								</ul>
							</li>
							
							<li class="submenu">
								<a href="#"  ><i class="la la-pie-chart"></i> <span>Reporting</span> <span class="menu-arrow"></span></a>
								<ul style="display: none;">
									<li><a href="#">Profit</a></li>
									<li><a href="#">Expense</a></li>									
									<li><a href="#">Sale</a></li>
									<li><a href="#">Purchase</a></li>	
									<li><a href="#">Stock</a></li>																
									<li><a href="#">Sale Return</a></li>								
									<li><a href="#">Purchase Return</a></li>
 						
								</ul>
							</li>							
							
							<li class="submenu">
								<a href="#"><i class="la la-money"></i> <span>Users</span><span class="menu-arrow"></span>  </a>
								<ul style="display: none;">
									<li><a href="#">Create Group</a></li>
									<li><a href="#">Add a Users</a></li>
									<li><a href="#">Users List</a></li>
								</ul>
							</li>
							
							<li class="submenu">
								<a href="#"><i class="la la-cc-mastercard"></i> <span> Payment </span><span class="menu-arrow"></span> </span></a>
								<ul style="display: none;">
									<li><a href="#">Add a Payment Card</a></li>
									<li><a href="#">Payments</a></li>
									<li><a href="#">List Payment</a></li>									
								</ul>
							</li>
							
							<li class="submenu">
								<a href="#"><i class="la la-comments"></i> <span> Chat </span> <span class="menu-arrow"></span></a>
								<ul style="display: none;">
									<li><a href="#">Find a Owner</a></li>		
									<li><a href="#">Owner List</a></li>
									<li><a href="#">Person List</a></li>
									<li><a href="#">Settings</a></li>
									<li><a href="#">Messages</a></li>
									<li><a href="#">Send List</a></li>
									<li><a href="#">Request List</a></li>									
								</ul>
							</li>	
							
							<li class="submenu">
								<a href="#"><i class="la la-bell"></i> <span>Event</span> <span class="menu-arrow"></span></a>
								<ul style="display: none;">
									<li><a href="#">Create Event</a></li>
									<li><a href="#">Event List </a></li>
									 
								</ul>
							</li>
							
							<li class="submenu">
								<a href="#"><i class="la la-barcode"></i> <span>Barcode</span> <span class="menu-arrow"></span></a>
								<ul style="display: none;">
									<li><a href="#">Generate Barcode</a></li>
									<li><a href="#">Barcode Settings</a></li>
									 
								</ul>
							</li>
							
							<li class="submenu">
								<a href="#"><i class="la la-cloud-upload"></i> <span>Product Online</span> <span class="menu-arrow"></span></a>
								<ul style="display: none;">
									<li><a href="#">Product Add</a></li>
									<li><a href="#">Product List </a></li>
									<li><a href="#">Order List</a></li>
									<li><a href="#">Pending List</a></li> 
									<li><a href="#">Delivery List</a></li>
									<li><a href="#">Report</a></li>
									<li><a href="#">Fearued Product</a></li>
								</ul>
							</li>
							
						 
							<li class="submenu">
								<a href="#"><i class="la la-cog"></i> <span>Settings</span> </a>
								<ul style="display: none;">
									<li><a href="#">Tax</a></li>
									<li><a href="#">Unit</a></li>
									<li><a href="#">SMS</a></li>
									<li><a href="#">Product</a></li> 
									<li><a href="#">Report</a></li>
									<li><a href="#">Main</a></li>
									<li><a href="#">Profile</a></li>
								</ul>
							</li>
							<li> 
								<a href="#"><i class="la la-group"></i> <span>Refference</span></a>
							</li>
							<li> 
								<a href="#"><i class="la la-info-circle"></i> <span>Helpline</span></a>
							</li>
						</ul>
					</div>
                </div>
            </div>
			
            <div class="page-wrapper">
                <div class="content container-fluid">
					<div class="row">
						<div class="col-sm-8">
							<h4 class="page-title">Department</h4>
						</div>
						<div class="col-sm-4 text-right m-b-30">
							<a href="#" class="btn btn-primary rounded" data-toggle="modal" data-target="#add_department"><i class="fa fa-plus"></i> Add New Department</a>
						</div>
					</div>
					<div class="row">
						<div class="col-md-12">
							<div>
								<table id="myTable"  class="table table-striped custom-table m-b-0 datatable">
									<thead>
										<tr>
											<th>#</th>
											<th>Department Name</th>
											<th class="text-right">Action</th>
										</tr>
									</thead>
									<tbody>
										<tr>
											<td>1</td>
											<td>Web Development</td>
											<td class="text-right">
												<div class="dropdown">
													<a href="#" class="action-icon dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a>
													<ul class="dropdown-menu pull-right">
														<li><a href="#" data-toggle="modal" data-target="#edit_department" title="Edit"><i class="fa fa-pencil m-r-5"></i> Edit</a></li>
														<li><a href="#" data-toggle="modal" data-target="#delete_department" title="Delete"><i class="fa fa-trash-o m-r-5"></i> Delete</a></li>
													</ul>
												</div>
											</td>
										</tr>
										<tr>
											<td>2</td>
											<td>Application Development</td>
											<td class="text-right">
												<div class="dropdown">
													<a href="#" class="action-icon dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a>
													<ul class="dropdown-menu pull-right">
														<li><a href="#" data-toggle="modal" data-target="#edit_department" title="Edit"><i class="fa fa-pencil m-r-5"></i> Edit</a></li>
														<li><a href="#" data-toggle="modal" data-target="#delete_department" title="Delete"><i class="fa fa-trash-o m-r-5"></i> Delete</a></li>
													</ul>
												</div>
											</td>
										</tr>
										<tr>
											<td>3</td>
											<td>IT Management</td>
											<td class="text-right">
												<div class="dropdown">
													<a href="#" class="action-icon dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a>
													<ul class="dropdown-menu pull-right">
														<li><a href="#" data-toggle="modal" data-target="#edit_department" title="Edit"><i class="fa fa-pencil m-r-5"></i> Edit</a></li>
														<li><a href="#" data-toggle="modal" data-target="#delete_department" title="Delete"><i class="fa fa-trash-o m-r-5"></i> Delete</a></li>
													</ul>
												</div>
											</td>
										</tr>
										<tr>
											<td>4</td>
											<td>Accounts Management</td>
											<td class="text-right">
												<div class="dropdown">
													<a href="#" class="action-icon dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a>
													<ul class="dropdown-menu pull-right">
														<li><a href="#" data-toggle="modal" data-target="#edit_department" title="Edit"><i class="fa fa-pencil m-r-5"></i> Edit</a></li>
														<li><a href="#" data-toggle="modal" data-target="#delete_department" title="Delete"><i class="fa fa-trash-o m-r-5"></i> Delete</a></li>
													</ul>
												</div>
											</td>
										</tr>
										<tr>
											<td>5</td>
											<td>Support Management</td>
											<td class="text-right">
												<div class="dropdown">
													<a href="#" class="action-icon dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a>
													<ul class="dropdown-menu pull-right">
														<li><a href="#" data-toggle="modal" data-target="#edit_department" title="Edit"><i class="fa fa-pencil m-r-5"></i> Edit</a></li>
														<li><a href="#" data-toggle="modal" data-target="#delete_department" title="Delete"><i class="fa fa-trash-o m-r-5"></i> Delete</a></li>
													</ul>
												</div>
											</td>
										</tr>
										<tr>
											<td>6</td>
											<td>Marketing</td>
											<td class="text-right">
												<div class="dropdown">
													<a href="#" class="action-icon dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a>
													<ul class="dropdown-menu pull-right">
														<li><a href="#" data-toggle="modal" data-target="#edit_department" title="Edit"><i class="fa fa-pencil m-r-5"></i> Edit</a></li>
														<li><a href="#" data-toggle="modal" data-target="#delete_department" title="Delete"><i class="fa fa-trash-o m-r-5"></i> Delete</a></li>
													</ul>
												</div>
											</td>
										</tr>
									</tbody>
								</table>
							</div>
						</div>
					</div>
                </div>
				<div class="notification-box">
					<div class="msg-sidebar notifications msg-noti">
						<div class="topnav-dropdown-header">
							<span>Messages</span>
						</div>
						<div class="drop-scroll msg-list-scroll">
							<ul class="list-box">
								<li>
									<a href="chat.html">
										<div class="list-item">
											<div class="list-left">
												<span class="avatar">R</span>
											</div>
											<div class="list-body">
												<span class="message-author">Richard Miles </span>
												<span class="message-time">12:28 AM</span>
												<div class="clearfix"></div>
												<span class="message-content">Lorem ipsum dolor sit amet, consectetur adipiscing</span>
											</div>
										</div>
									</a>
								</li>
								<li>
									<a href="chat.html">
										<div class="list-item new-message">
											<div class="list-left">
												<span class="avatar">J</span>
											</div>
											<div class="list-body">
												<span class="message-author">John Doe</span>
												<span class="message-time">1 Aug</span>
												<div class="clearfix"></div>
												<span class="message-content">Lorem ipsum dolor sit amet, consectetur adipiscing</span>
											</div>
										</div>
									</a>
								</li>
								<li>
									<a href="chat.html">
										<div class="list-item">
											<div class="list-left">
												<span class="avatar">T</span>
											</div>
											<div class="list-body">
												<span class="message-author"> Tarah Shropshire </span>
												<span class="message-time">12:28 AM</span>
												<div class="clearfix"></div>
												<span class="message-content">Lorem ipsum dolor sit amet, consectetur adipiscing</span>
											</div>
										</div>
									</a>
								</li>
								<li>
									<a href="chat.html">
										<div class="list-item">
											<div class="list-left">
												<span class="avatar">M</span>
											</div>
											<div class="list-body">
												<span class="message-author">Mike Litorus</span>
												<span class="message-time">12:28 AM</span>
												<div class="clearfix"></div>
												<span class="message-content">Lorem ipsum dolor sit amet, consectetur adipiscing</span>
											</div>
										</div>
									</a>
								</li>
								<li>
									<a href="chat.html">
										<div class="list-item">
											<div class="list-left">
												<span class="avatar">C</span>
											</div>
											<div class="list-body">
												<span class="message-author"> Catherine Manseau </span>
												<span class="message-time">12:28 AM</span>
												<div class="clearfix"></div>
												<span class="message-content">Lorem ipsum dolor sit amet, consectetur adipiscing</span>
											</div>
										</div>
									</a>
								</li>
								<li>
									<a href="chat.html">
										<div class="list-item">
											<div class="list-left">
												<span class="avatar">D</span>
											</div>
											<div class="list-body">
												<span class="message-author"> Domenic Houston </span>
												<span class="message-time">12:28 AM</span>
												<div class="clearfix"></div>
												<span class="message-content">Lorem ipsum dolor sit amet, consectetur adipiscing</span>
											</div>
										</div>
									</a>
								</li>
								<li>
									<a href="chat.html">
										<div class="list-item">
											<div class="list-left">
												<span class="avatar">B</span>
											</div>
											<div class="list-body">
												<span class="message-author"> Buster Wigton </span>
												<span class="message-time">12:28 AM</span>
												<div class="clearfix"></div>
												<span class="message-content">Lorem ipsum dolor sit amet, consectetur adipiscing</span>
											</div>
										</div>
									</a>
								</li>
								<li>
									<a href="chat.html">
										<div class="list-item">
											<div class="list-left">
												<span class="avatar">R</span>
											</div>
											<div class="list-body">
												<span class="message-author"> Rolland Webber </span>
												<span class="message-time">12:28 AM</span>
												<div class="clearfix"></div>
												<span class="message-content">Lorem ipsum dolor sit amet, consectetur adipiscing</span>
											</div>
										</div>
									</a>
								</li>
								<li>
									<a href="chat.html">
										<div class="list-item">
											<div class="list-left">
												<span class="avatar">C</span>
											</div>
											<div class="list-body">
												<span class="message-author"> Claire Mapes </span>
												<span class="message-time">12:28 AM</span>
												<div class="clearfix"></div>
												<span class="message-content">Lorem ipsum dolor sit amet, consectetur adipiscing</span>
											</div>
										</div>
									</a>
								</li>
								<li>
									<a href="chat.html">
										<div class="list-item">
											<div class="list-left">
												<span class="avatar">M</span>
											</div>
											<div class="list-body">
												<span class="message-author">Melita Faucher</span>
												<span class="message-time">12:28 AM</span>
												<div class="clearfix"></div>
												<span class="message-content">Lorem ipsum dolor sit amet, consectetur adipiscing</span>
											</div>
										</div>
									</a>
								</li>
								<li>
									<a href="chat.html">
										<div class="list-item">
											<div class="list-left">
												<span class="avatar">J</span>
											</div>
											<div class="list-body">
												<span class="message-author">Jeffery Lalor</span>
												<span class="message-time">12:28 AM</span>
												<div class="clearfix"></div>
												<span class="message-content">Lorem ipsum dolor sit amet, consectetur adipiscing</span>
											</div>
										</div>
									</a>
								</li>
								<li>
									<a href="chat.html">
										<div class="list-item">
											<div class="list-left">
												<span class="avatar">L</span>
											</div>
											<div class="list-body">
												<span class="message-author">Loren Gatlin</span>
												<span class="message-time">12:28 AM</span>
												<div class="clearfix"></div>
												<span class="message-content">Lorem ipsum dolor sit amet, consectetur adipiscing</span>
											</div>
										</div>
									</a>
								</li>
								<li>
									<a href="chat.html">
										<div class="list-item">
											<div class="list-left">
												<span class="avatar">T</span>
											</div>
											<div class="list-body">
												<span class="message-author">Tarah Shropshire</span>
												<span class="message-time">12:28 AM</span>
												<div class="clearfix"></div>
												<span class="message-content">Lorem ipsum dolor sit amet, consectetur adipiscing</span>
											</div>
										</div>
									</a>
								</li>
							</ul>
						</div>
						<div class="topnav-dropdown-footer">
							<a href="chat.html">See all messages</a>
						</div>
					</div>
				</div>
            </div>
			
			
			<div id="delete_department" class="modal custom-modal fade" role="dialog">
				<div class="modal-dialog">
					<div class="modal-content modal-md">
						<div class="modal-header">
							<h4 class="modal-title">Delete Department</h4>
						</div>
						<div class="modal-body card-box">
							<p>Are you sure want to delete this?</p>
							<div class="m-t-20 text-left">
								<a href="#" class="btn btn-default" data-dismiss="modal">Close</a>
								<button type="submit" class="btn btn-danger">Delete</button>
							</div>
						</div>
					</div>
				</div>
			</div>
			<div id="add_department" class="modal custom-modal fade" role="dialog">
				<div class="modal-dialog">
					<button type="button" class="close" data-dismiss="modal">&times;</button>
					<div class="modal-content modal-md">
						<div class="modal-header">
							<h4 class="modal-title">Add Department</h4>
						</div>
						<div class="modal-body">
							<form>
								<div class="form-group">
									<label>Department Name <span class="text-danger">*</span></label>
									<input class="form-control" required="" type="text">
								</div>
								<div class="m-t-20 text-center">
									<button class="btn btn-primary">Create Department</button>
								</div>
							</form>
						</div>
					</div>
				</div>
			</div>
			<div id="edit_department" class="modal custom-modal fade" role="dialog">
				<div class="modal-dialog">
					<button type="button" class="close" data-dismiss="modal">&times;</button>
					<div class="modal-content modal-md">
						<div class="modal-header">
							<h4 class="modal-title">Edit Department</h4>
						</div>
						<div class="modal-body">
							<form>
								<div class="form-group">
									<label>Department Name <span class="text-danger">*</span></label>
									<input class="form-control" value="IT Management" type="text">
								</div>
								<div class="m-t-20 text-center">
									<button class="btn btn-primary">Save Changes</button>
								</div>
							</form>
						</div>
					</div>
				</div>
			</div>
			
        </div>
		
		<div class="sidebar-overlay" data-reff="#sidebar"></div>
        <script type="text/javascript" src="../assets/js/jquery-3.2.1.min.js"></script>
        <script type="text/javascript" src="../assets/js/bootstrap.min.js"></script>
		<script type="text/javascript" src="../assets/js/jquery.dataTables.min.js"></script>
		<script type="text/javascript" src="../assets/js/dataTables.bootstrap.min.js"></script>
		<script type="text/javascript" src="../assets/js/jquery.slimscroll.js"></script>
		<script type="text/javascript" src="../assets/js/app.js"></script>
    </div>
    </form>
</body>
</html>
