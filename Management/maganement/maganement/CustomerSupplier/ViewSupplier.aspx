<%@ Page Title="" Language="C#" MasterPageFile="~/mDesign.Master" AutoEventWireup="true" CodeBehind="ViewSupplier.aspx.cs" Inherits="management.CustomerSupplier.ViewSupplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>View Supplier</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
      <div class="page-wrapper">
                <div class="content container-fluid">
					<div class="row">
						<div class="col-sm-8">
							<h4 class="page-title">Supplier Profile</h4>
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
													<small class="text-muted">Supplier</small>
													<div class="staff-id">Supplier ID : <span id="lblCustomerID" runat="server"></span></div>
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
									<li class=" active col-sm-3"><a data-toggle="tab" href="#tasks">Tasks</a></li>
								</ul>
							</div>
						</div>
					</div>
                    <div class="row">
                        <div class="col-lg-12"> 
							<div class="tab-content  profile-tab-content">																
								<div id="tasks" class="tab-pane fade in active">
									<div class="project-task">
										<div class="tabbable">
											<ul class="nav nav-tabs nav-tabs-top nav-justified m-b-0">
												<li class="active"><a href="#all_tasks" data-toggle="tab" aria-expanded="true">Stock List</a></li>
												<li><a href="#pending_tasks" data-toggle="tab" aria-expanded="false">Product List</a></li>
												<li><a href="#completed_tasks" data-toggle="tab" aria-expanded="false">Return Product</a></li>
											</ul>
											<div class="tab-content">
												<div class="tab-pane active" id="all_tasks">
													<div class="task-wrapper">
														<div class="task-list-container">
															<div class="task-list-body">
															


                                                                <div class="col-md-12">
                                                                        <div class="">
                                                                            <table class="table table-striped custom-table m-b-0 datatable">
                                                                                <thead>
                                                                                    <tr>
                                                                                        <th>#</th>
                                                                                        <th>Stock ID</th>
                                                                                        <th>Invoice</th>
                                                                                        <th>Created Date</th>
                                                                                        <th>Total Amount</th>
                                                                                        <th>Total Stock</th>
                                                                                    </tr>
                                                                                </thead>
                                                                                <tbody>
                                                                                    <asp:PlaceHolder ID="pnlShowStockList" runat="server"></asp:PlaceHolder>
                                                                                 

                                                                                </tbody>
                                                                            </table>
                                                                        </div>
                                                                    </div>



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
                                                <div class="tab-pane" id="pending_tasks">

                                                    <div class="col-md-12">
                                                        <div class="">
                                                            <table class="table table-striped custom-table m-b-0 datatable">
                                                                <thead>
                                                                    <tr>
                                                                        <th>#</th>
                                                                        <th>Stock ID</th>
                                                                        <th>Product Name</th>
                                                                        <th>Unit</th>
                                                                        <th>Buy Quality</th>
                                                                        <th>BuyingPrice</th>
                                                                        <th>Amount</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                                    <asp:PlaceHolder ID="pnlShowStock" runat="server"></asp:PlaceHolder>
                                                                </tbody>
                                                            </table>
                                                        </div>
                                                    </div>


                                                </div>
												<div class="tab-pane" id="completed_tasks">
                                                    <div class="col-md-12">
                                                        <div class="">
                                                            <table class="table table-striped custom-table m-b-0 datatable">
                                                                <thead>
                                                                    <tr>
                                                                        <th>#</th>
                                                                        <th>Product Name</th>
                                                                        <th>Quantity</th>
                                                                        <th>Return Price</th>
                                                                        <th>Amount</th>
                                                                        <th>Date</th>
                                                                        <th>Unit</th>
                                                                       
                                                                        
                                                                        <%--<th class="text-right">Actions</th>--%>
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
