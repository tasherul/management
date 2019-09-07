<%@ Page Title="" Language="C#" MasterPageFile="~/mDesign.Master" AutoEventWireup="true" CodeBehind="ViewCustomer.aspx.cs" Inherits="maganement.CustomerSupplier.ViewCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Customer Details</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
     <div class="page-wrapper">
                <div class="content container-fluid">
					<div class="row">
						<div class="col-sm-8">
							<h4 class="page-title">My Profile</h4>
						</div>
						<div class="col-sm-4 text-right m-b-30">
                            <asp:LinkButton ID="btnEditProfile" OnClick="btnEditProfile_Click" CssClass="btn btn-primary rounded" runat="server"><i class="fa fa-plus"></i> Edit Profile</asp:LinkButton>

						</div>
					</div>
					<div class="card-box m-b-0">
						<div class="row">
							<div class="col-md-12">
								<div class="profile-view">
									<div class="profile-img-wrap">
										<div class="profile-img">
											<a href="#"><img class="avatar" src="../image/customer.PNG" alt="Customer Image"/>
                                                
											</a>
										</div>
									</div>
									<div class="profile-basic">
										<div class="row">
											<div class="col-md-5">
												<div class="profile-info-left">
													<h3 class="user-name m-t-0" id="lblName" runat="server"></h3>
													<%--<h5 class="company-role m-t-0 m-b-0">Barry Cuda</h5>--%>
													<small class="text-muted">Customer</small>
													<div class="staff-id">Customer ID : <span id="lblCustomerID" runat="server"></span></div>
													<div class="staff-msg"><a href="#" class="btn btn-custom">Send Message</a></div>
												</div>
											</div>
											<div class="col-md-7">
												<ul class="personal-info">
													<li>
														<span class="title">Phone:</span>
														<span class="text"><a id="lblPhone" runat="server"></a></span>
													</li>
													<li>
														<span class="title">Email:</span>
														<span class="text"><a id="lblEmail" runat="server"></a></span>
													</li>	
                                                    <li>
														<span class="title">Gender:</span>
														<span id="lblGender" runat="server" class="text"></span>
													</li>												
													<li>
														<span class="title">Address:</span>
														<span class="text" id="lblAddress" runat="server"></span>
													</li>
                                                    <li>
														<span class="title">Details:</span>
														<span class="text" id="lblDetails" runat="server"></span>
													</li>
													
												</ul>
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>	
					<div class="card-box tab-box">						
						<div class="row user-tabs">
							<div class="col-lg-12 col-md-12 col-sm-12 line-tabs">
								<ul class="nav nav-tabs tabs nav-tabs-bottom">
									<li class="active col-sm-3"><a data-toggle="tab" href="#myprojects">My Projects</a></li>
									<li class="col-sm-3"><a data-toggle="tab" href="#tasks">Tasks</a></li>
								</ul>
							</div>
						</div>
					</div>
                    <div class="row">
                        <div class="col-lg-12"> 
							<div class="tab-content  profile-tab-content">
								<div id="myprojects" class="tab-pane fade in active">
									
                                   <%-- <div class="row">
										<div class="col-lg-3 col-sm-4">
											<div class="card-box project-box">
												<div class="dropdown profile-action">
													<a href="#" class="action-icon dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a>
													<ul class="dropdown-menu pull-right">
														<li><a href="#" data-toggle="modal" data-target="#edit_project"><i class="fa fa-pencil m-r-5"></i> Edit</a></li>
														<li><a href="#" data-toggle="modal" data-target="#delete_project"><i class="fa fa-trash-o m-r-5"></i> Delete</a></li>
													</ul>
												</div>
												<h4 class="project-title"><a href="project-view.html">Food and Drinks</a></h4>
												<small class="block text-ellipsis m-b-15">
													<span class="text-xs">1</span> <span class="text-muted">open tasks, </span>
													<span class="text-xs">9</span> <span class="text-muted">tasks completed</span>
												</small>
												<p class="text-muted">Lorem Ipsum is simply dummy text of the printing and
													typesetting industry. When an unknown printer took a galley of type and
													scrambled it...
												</p>
												<div class="pro-deadline m-b-15">
													<div class="sub-title">
														Deadline:
													</div>
													<div class="text-muted">
														8 Sep 2017
													</div>
												</div>
												<div class="project-members m-b-15">
													<div>Project Leader :</div>
													<ul class="team-members">
														<li>
															<a href="#" data-toggle="tooltip" title="Jeffery Lalor"><img src="assets/img/user.jpg" alt="Jeffery Lalor"></a>
														</li>
													</ul>
												</div>
												<div class="project-members m-b-15">
													<div>Team :</div>
													<ul class="team-members">
														<li>
															<a href="#" data-toggle="tooltip" title="John Doe"><img src="assets/img/user.jpg" alt="John Doe"></a>
														</li>
														<li>
															<a href="#" data-toggle="tooltip" title="Richard Miles"><img src="assets/img/user.jpg" alt="Richard Miles"></a>
														</li>
														<li>
															<a href="#" data-toggle="tooltip" title="John Smith"><img src="assets/img/user.jpg" alt="John Smith"></a>
														</li>
														<li>
															<a href="#" data-toggle="tooltip" title="Mike Litorus"><img src="assets/img/user.jpg" alt="Mike Litorus"></a>
														</li>
														<li>
															<a href="#" class="all-users">+15</a>
														</li>
													</ul>
												</div>
												<p class="m-b-5">Progress <span class="text-success pull-right">40%</span></p>
												<div class="progress progress-xs m-b-0">
													<div class="progress-bar progress-bar-success" role="progressbar" data-toggle="tooltip" title="40%" style="width: 40%"></div>
												</div>
											</div>
										</div>
										<div class="col-lg-3 col-sm-4">
											<div class="card-box project-box">
												<div class="dropdown profile-action">
													<a href="#" class="action-icon dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a>
													<ul class="dropdown-menu pull-right">
														<li><a href="#" data-toggle="modal" data-target="#edit_project"><i class="fa fa-pencil m-r-5"></i> Edit</a></li>
														<li><a href="#" data-toggle="modal" data-target="#delete_project"><i class="fa fa-trash-o m-r-5"></i> Delete</a></li>
													</ul>
												</div>
												<h4 class="project-title"><a href="project-view.html">School Guru</a></h4>
												<small class="block text-ellipsis m-b-15">
													<span class="text-xs">2</span> <span class="text-muted">open tasks, </span>
													<span class="text-xs">5</span> <span class="text-muted">tasks completed</span>
												</small>
												<p class="text-muted">Lorem Ipsum is simply dummy text of the printing and
													typesetting industry. When an unknown printer took a galley of type and
													scrambled it...
												</p>
												<div class="pro-deadline m-b-15">
													<div class="sub-title">
														Deadline:
													</div>
													<div class="text-muted">
														8 Sep 2017
													</div>
												</div>
												<div class="project-members m-b-15">
													<div>Project Leader :</div>
													<ul class="team-members">
														<li>
															<a href="#" data-toggle="tooltip" title="Jeffery Lalor"><img src="assets/img/user.jpg" alt="Jeffery Lalor"></a>
														</li>
													</ul>
												</div>
												<div class="project-members m-b-15">
													<div>Team :</div>
													<ul class="team-members">
														<li>
															<a href="#" data-toggle="tooltip" title="John Doe"><img src="assets/img/user.jpg" alt="John Doe"></a>
														</li>
														<li>
															<a href="#" data-toggle="tooltip" title="Richard Miles"><img src="assets/img/user.jpg" alt="Richard Miles"></a>
														</li>
														<li>
															<a href="#" data-toggle="tooltip" title="John Smith"><img src="assets/img/user.jpg" alt="John Smith"></a>
														</li>
														<li>
															<a href="#" data-toggle="tooltip" title="Mike Litorus"><img src="assets/img/user.jpg" alt="Mike Litorus"></a>
														</li>
														<li>
															<a href="#" class="all-users">+15</a>
														</li>
													</ul>
												</div>
												<p class="m-b-5">Progress <span class="text-success pull-right">40%</span></p>
												<div class="progress progress-xs m-b-0">
													<div class="progress-bar progress-bar-success" role="progressbar" data-toggle="tooltip" title="40%" style="width: 40%"></div>
												</div>
											</div>
										</div>
										<div class="col-lg-3 col-sm-4">
											<div class="card-box project-box">
												<div class="dropdown profile-action">
													<a href="#" class="action-icon dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a>
													<ul class="dropdown-menu pull-right">
														<li><a href="#" data-toggle="modal" data-target="#edit_project"><i class="fa fa-pencil m-r-5"></i> Edit</a></li>
														<li><a href="#" data-toggle="modal" data-target="#delete_project"><i class="fa fa-trash-o m-r-5"></i> Delete</a></li>
													</ul>
												</div>
												<h4 class="project-title"><a href="project-view.html">Penabook</a></h4>
												<small class="block text-ellipsis m-b-15">
													<span class="text-xs">3</span> <span class="text-muted">open tasks, </span>
													<span class="text-xs">3</span> <span class="text-muted">tasks completed</span>
												</small>
												<p class="text-muted">Lorem Ipsum is simply dummy text of the printing and
													typesetting industry. When an unknown printer took a galley of type and
													scrambled it...
												</p>
												<div class="pro-deadline m-b-15">
													<div class="sub-title">
														Deadline:
													</div>
													<div class="text-muted">
														8 Sep 2017
													</div>
												</div>
												<div class="project-members m-b-15">
													<div>Project Leader :</div>
													<ul class="team-members">
														<li>
															<a href="#" data-toggle="tooltip" title="Jeffery Lalor"><img src="assets/img/user.jpg" alt="Jeffery Lalor"></a>
														</li>
													</ul>
												</div>
												<div class="project-members m-b-15">
													<div>Team :</div>
													<ul class="team-members">
														<li>
															<a href="#" data-toggle="tooltip" title="John Doe"><img src="assets/img/user.jpg" alt="John Doe"></a>
														</li>
														<li>
															<a href="#" data-toggle="tooltip" title="Richard Miles"><img src="assets/img/user.jpg" alt="Richard Miles"></a>
														</li>
														<li>
															<a href="#" data-toggle="tooltip" title="John Smith"><img src="assets/img/user.jpg" alt="John Smith"></a>
														</li>
														<li>
															<a href="#" data-toggle="tooltip" title="Mike Litorus"><img src="assets/img/user.jpg" alt="Mike Litorus"></a>
														</li>
														<li>
															<a href="#" class="all-users">+15</a>
														</li>
													</ul>
												</div>
												<p class="m-b-5">Progress <span class="text-success pull-right">40%</span></p>
												<div class="progress progress-xs m-b-0">
													<div class="progress-bar progress-bar-success" role="progressbar" data-toggle="tooltip" title="40%" style="width: 40%"></div>
												</div>
											</div>
										</div>
										<div class="col-lg-3 col-sm-4">
											<div class="card-box project-box">
												<div class="dropdown profile-action">
													<a href="#" class="action-icon dropdown-toggle" data-toggle="dropdown" aria-expanded="false"><i class="fa fa-ellipsis-v"></i></a>
													<ul class="dropdown-menu pull-right">
														<li><a href="#" data-toggle="modal" data-target="#edit_project"><i class="fa fa-pencil m-r-5"></i> Edit</a></li>
														<li><a href="#" data-toggle="modal" data-target="#delete_project"><i class="fa fa-trash-o m-r-5"></i> Delete</a></li>
													</ul>
												</div>
												<h4 class="project-title"><a href="project-view.html">Harvey Clinic</a></h4>
												<small class="block text-ellipsis m-b-15">
													<span class="text-xs">12</span> <span class="text-muted">open tasks, </span>
													<span class="text-xs">4</span> <span class="text-muted">tasks completed</span>
												</small>
												<p class="text-muted">Lorem Ipsum is simply dummy text of the printing and
													typesetting industry. When an unknown printer took a galley of type and
													scrambled it...
												</p>
												<div class="pro-deadline m-b-15">
													<div class="sub-title">
														Deadline:
													</div>
													<div class="text-muted">
														8 Sep 2017
													</div>
												</div>
												<div class="project-members m-b-15">
													<div>Project Leader :</div>
													<ul class="team-members">
														<li>
															<a href="#" data-toggle="tooltip" title="Jeffery Lalor"><img src="assets/img/user.jpg" alt="Jeffery Lalor"></a>
														</li>
													</ul>
												</div>
												<div class="project-members m-b-15">
													<div>Team :</div>
													<ul class="team-members">
														<li>
															<a href="#" data-toggle="tooltip" title="John Doe"><img src="assets/img/user.jpg" alt="John Doe"></a>
														</li>
														<li>
															<a href="#" data-toggle="tooltip" title="Richard Miles"><img src="assets/img/user.jpg" alt="Richard Miles"></a>
														</li>
														<li>
															<a href="#" data-toggle="tooltip" title="John Smith"><img src="assets/img/user.jpg" alt="John Smith"></a>
														</li>
														<li>
															<a href="#" data-toggle="tooltip" title="Mike Litorus"><img src="assets/img/user.jpg" alt="Mike Litorus"></a>
														</li>
														<li>
															<a href="#" class="all-users">+15</a>
														</li>
													</ul>
												</div>
												<p class="m-b-5">Progress <span class="text-success pull-right">40%</span></p>
												<div class="progress progress-xs m-b-0">
													<div class="progress-bar progress-bar-success" role="progressbar" data-toggle="tooltip" title="40%" style="width: 40%"></div>
												</div>
											</div>
										</div>
									</div>--%>


								</div>
								<div id="tasks" class="tab-pane fade">
									<div class="project-task">
										<div class="tabbable">
											<ul class="nav nav-tabs nav-tabs-top nav-justified m-b-0">
												<li class="active"><a href="#all_tasks" data-toggle="tab" aria-expanded="true">All Invoice</a></li>
												<li><a href="#pending_tasks" data-toggle="tab" aria-expanded="false">Pending Payment</a></li>
												<li><a href="#completed_tasks" data-toggle="tab" aria-expanded="false">Completed Payment</a></li>
											</ul>
											<div class="tab-content">
												<div class="tab-pane active" id="all_tasks">
													<div class="task-wrapper">
														<div class="task-list-container">
															<div class="task-list-body">
																<ul id="task-list">
																	<li class="task">
																		<div class="task-container">
																			<span class="task-action-btn task-check">
																				<span class="action-circle large complete-btn" title="Mark Complete">
																					<i class="material-icons">check</i>
																				</span>
																			</span>
																			<span class="task-label" contenteditable="true">Patient appointment booking</span>
																			<span class="task-action-btn task-btn-right">
																				<span class="action-circle large" title="Assign">
																					<i class="material-icons">person_add</i>
																				</span>
																				<span class="action-circle large delete-btn" title="Delete Task">
																					<i class="material-icons">delete</i>
																				</span>
																			</span>
																		</div>
																	</li>
																	<li class="task">
																		<div class="task-container">
																			<span class="task-action-btn task-check">
																				<span class="action-circle large complete-btn" title="Mark Complete">
																					<i class="material-icons">check</i>
																				</span>
																			</span>
																			<span class="task-label" contenteditable="true">Appointment booking with payment gateway</span>
																			<span class="task-action-btn task-btn-right">
																				<span class="action-circle large" title="Assign">
																					<i class="material-icons">person_add</i>
																				</span>
																				<span class="action-circle large delete-btn" title="Delete Task">
																					<i class="material-icons">delete</i>
																				</span>
																			</span>
																		</div>
																	</li>
																	<li class="completed task">
																		<div class="task-container">
																			<span class="task-action-btn task-check">
																				<span class="action-circle large complete-btn" title="Mark Complete">
																					<i class="material-icons">check</i>
																				</span>
																			</span>
																			<span class="task-label">Doctor available module</span>
																			<span class="task-action-btn task-btn-right">
																				<span class="action-circle large" title="Assign">
																					<i class="material-icons">person_add</i>
																				</span>
																				<span class="action-circle large delete-btn" title="Delete Task">
																					<i class="material-icons">delete</i>
																				</span>
																			</span>
																		</div>
																	</li>
																	<li class="task">
																		<div class="task-container">
																			<span class="task-action-btn task-check">
																				<span class="action-circle large complete-btn" title="Mark Complete">
																					<i class="material-icons">check</i>
																				</span>
																			</span>
																			<span class="task-label" contenteditable="true">Patient and Doctor video conferencing</span>
																			<span class="task-action-btn task-btn-right">
																				<span class="action-circle large" title="Assign">
																					<i class="material-icons">person_add</i>
																				</span>
																				<span class="action-circle large delete-btn" title="Delete Task">
																					<i class="material-icons">delete</i>
																				</span>
																			</span>
																		</div>
																	</li>
																	<li class="task">
																		<div class="task-container">
																			<span class="task-action-btn task-check">
																				<span class="action-circle large complete-btn" title="Mark Complete">
																					<i class="material-icons">check</i>
																				</span>
																			</span>
																			<span class="task-label" contenteditable="true">Private chat module</span>
																			<span class="task-action-btn task-btn-right">
																				<span class="action-circle large" title="Assign">
																					<i class="material-icons">person_add</i>
																				</span>
																				<span class="action-circle large delete-btn" title="Delete Task">
																					<i class="material-icons">delete</i>
																				</span>
																			</span>
																		</div>
																	</li>
																	<li class="task">
																		<div class="task-container">
																			<span class="task-action-btn task-check">
																				<span class="action-circle large complete-btn" title="Mark Complete">
																					<i class="material-icons">check</i>
																				</span>
																			</span>
																			<span class="task-label" contenteditable="true">Patient Profile add</span>
																			<span class="task-action-btn task-btn-right">
																				<span class="action-circle large" title="Assign">
																					<i class="material-icons">person_add</i>
																				</span>
																				<span class="action-circle large delete-btn" title="Delete Task">
																					<i class="material-icons">delete</i>
																				</span>
																			</span>
																		</div>
																	</li>
																</ul>
															</div>
															<div class="task-list-footer">
																<div class="new-task-wrapper">
																	<textarea  id="new-task" placeholder="Enter new task here. . ."></textarea>
																	<span class="error-message hidden">You need to enter a task first</span>
																	<span class="add-new-task-btn btn" id="add-task">Add Task</span>
																	<span class="cancel-btn btn" id="close-task-panel">Close</span>
																</div>
															</div>
														</div>
													</div>
												</div>
												<div class="tab-pane" id="pending_tasks"></div>
												<div class="tab-pane" id="completed_tasks"></div>
											</div>
										</div>
									</div>
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
		<script type="text/template" id="task-template">
			<li class="task">
				<div class="task-container">
					<span class="task-action-btn task-check">
						<span class="action-circle large complete-btn" title="Mark Complete">
							<i class="material-icons">check</i>
						</span>
					</span>
					<span class="task-label" contenteditable="true"></span>
					<span class="task-action-btn task-btn-right">
						<span class="action-circle large" title="Assign">
							<i class="material-icons">person_add</i>
						</span>
						<span class="action-circle large delete-btn" title="Delete Task">
							<i class="material-icons">delete</i>
						</span>
					</span>
				</div>
			</li>
		</script>
		<script type="text/javascript" src="assets/js/task.js"></script>

</asp:Content>
