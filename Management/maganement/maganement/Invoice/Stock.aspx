<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Stock.aspx.cs" Inherits="maganement.Invoice.Stock" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

<head>
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width,initial-scale=1,user-scalable=0,minimal-ui"/>
    <title>Stock</title>
    <meta content="Admin Dashboard" name="description"/>
    <meta content="themesdesign" name="author"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <link rel="shortcut icon" href="assets/images/favicon.ico"/>
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
    <link href="assets/plugins/animate/animate.css" rel="stylesheet" type="text/css"/>
    <link href="assets/css/icons.css" rel="stylesheet" type="text/css"/>
    <link href="assets/css/style.css" rel="stylesheet" type="text/css"/>
</head>

<body class="fixed-left">
 

    <div>
  
        
          
                <div class="page-content-wrapper">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="page-title-box">
                                    <div class="float-right">
                                        <div class="dropdown">
                                           <div class="d-print-none float-right"><a href="javascript:window.print()" class="btn btn-info text-light"><i class="fas fa-print"></i></a> 
                                               <a href="../Sale/ProductSale?=Retailer" class="btn btn-danger text-light">Back</a>
                                             <%--  <button class="btn btn-secondary btn-round dropdown-toggle px-3" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i class="mdi mdi-settings mr-1"></i>Settings</button> 
                                               <div class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdownMenuButton"><a class="dropdown-item" href="#">Action</a> <a class="dropdown-item" href="#">Another action</a> <a class="dropdown-item" href="#">Something else here</a></div>                                             --%>
                                           </div>                                           
                                        </div>
                                        
                                                                               
                                    </div>
                                    <h4 class="page-title text-center">Stock Details</h4></div>
                            </div>
                        </div>
                        <!-- end page title end breadcrumb    justify-content-end justify-content-between -->
                        <div class="row d-flex  " id="divAlign" runat="server">
                            <div  id="divSize" runat="server">
                                <div class="card">
                                    <div class="card-body invoice">
                                        <div class="float-right">
                                            <h6>Stock ID : # <strong><asp:Label ID="lblInvoice" runat="server"></asp:Label></strong></h6>
                                            <asp:Image ID="BarcodeShow" runat="server" />
                                            <%--<img src="../image/download.gif" />--%>
                              <%--              <h6 class="mb-0">Order ID: #<asp:Label ID="lblorderID" runat="server" ></asp:Label> </h6>--%>
                                            <h6 class="mb-0">Date: <asp:Label ID="lblDate" runat="server" ></asp:Label> </h6>
                                        </div>
                                        <div class=" float-left">
                                            <h4 class="mb-0 align-self-center">
                                                <asp:Image ID="CompanyImage" Width="80" Height="80" runat="server" />
                                                
                                                <%--<img src="../image/companylogo.png" style="position:relative;" width="150" height="80" />--%>
                                            </h4></div>
                                        <div class="clearfix"></div>
                                        
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="float-left mt-4">
                                                    <address>
                                                        <strong>
                                                            <asp:Label ID="lblCompanyName" runat="server" ></asp:Label></strong>
                                                        <br/>
                                                        <asp:Label ID="lblCompanyAddress1" runat="server"></asp:Label><br/>
                                                        <asp:Label ID="lblCompanyAddress2" runat="server" ></asp:Label><br/>
                                                        <abbr title="Phone">P:</abbr> <asp:Label ID="lblCompanyPhone" runat="server" ></asp:Label>
                                                    </address></div>

                                                <div class="float-right mt-4">
                                                    <address>
                                                        <strong><asp:Label ID="lblCustomarName" runat="server" ></asp:Label></strong>
                                                        <br><asp:Label ID="lblCustomarAddress" runat="server" ></asp:Label><br>
                                                        <abbr title="Phone">P:</abbr> <asp:Label ID="lblCustomarPhone" runat="server" ></asp:Label>
                                                    </address>
                                                    <%--<p><strong>Order Date: </strong>May 15, 2018</p>
                                                    <p><strong>Order Status: </strong><span class="badge badge-warning">Pending</span></p>
                                                    <p><strong>Order ID: </strong>#123456</p>--%>
                                                </div>
                                            </div>
                                        </div>
                                        <!--end row-->
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="table-responsive">
                                                    <table class="table mt-4">
                                                        <thead>
                                                            <tr>
                                                                <th>#</th>
                                                                <th>Iteam</th>
                                                                <th>Description</th>
                                                                <th>Quantity</th>
                                                                <th>Cost</th>
                                                                <th>Total</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <%--<tr>
                                                                <td>1</td>
                                                                <td>LCD</td>
                                                                <td>There are many variations of passages of Lorem Ipsum available.</td>
                                                                <td>1</td>
                                                                <td>$380</td>
                                                                <td>$380</td>
                                                            </tr>--%>
                                                            
                                                            <asp:PlaceHolder ID="pnlShowStock" runat="server"></asp:PlaceHolder>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                        <!--end row-->
                                        <div class="row" style="border-radius: 0px;">
                                            <div class="col-md-9">
                                                <%--<p><strong>Terms And Condition :</strong></p>
                                                <ul class="pl-3">
                                                    <li><small>
                                                        <asp:Label ID="lblTermsAndCondition" runat="server" ></asp:Label></small></li>
                                                </ul>
                                                <p><strong>In Word : <asp:Label ID="lblInWord" runat="server" ></asp:Label></strong></p>
                                                --%>
                                            </div>
                                            <div class="col-md-3">
                                                <p class="text-right"><strong>Total Stock:</strong> <asp:Label ID="lblSubTotal" runat="server"></asp:Label></p>
                                               <%-- <p class="text-right">Discout: <asp:Label ID="lblDiscount" runat="server"></asp:Label></p>
                                                <p class="text-right">VAT: <asp:Label ID="lblVat" runat="server"></asp:Label></p>
                                                <p class="text-right">Previous Due: <asp:Label ID="lblPreviousDue" runat="server"></asp:Label></p>
                                                <p class="text-right">Total: <asp:Label ID="lblTotal" runat="server"></asp:Label></p>
                                                <p class="text-right"><strong>Due: <asp:Label ID="lblDue" runat="server"></asp:Label></strong> </p>--%>
                                                <hr/>
                                                <h4 class="text-right mb-0">Total Amount: <asp:Label ID="lblPaid" runat="server"></asp:Label></h4>
                                            </div>
                                        </div>
                                        <!--end row-->
                                        <hr/>
                                        <div class="row d-flex justify-content-center">
                                            <div class="col-lg-12 col-xl-4 ml-auto align-self-center">
                                                <div class="text-center text-muted"><small>Thank you very much for doing business with us. DevelopBD !</small></div>
                                            </div>
                                           
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!--end row-->
                    </div>
                    <!-- container -->
                </div>
                <!-- Page content Wrapper -->
            
            <!-- content -->
            <footer class="footer">© 2019 Developbd.</footer>
        
        <!-- End Right content here -->
    </div>
    <!-- END wrapper -->
    <!-- jQuery  -->
    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/js/popper.min.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
    <script src="assets/js/modernizr.min.js"></script>
    <script src="assets/js/detect.js"></script>
    <script src="assets/js/fastclick.js"></script>
    <script src="assets/js/jquery.slimscroll.js"></script>
    <script src="assets/js/jquery.blockUI.js"></script>
    <script src="assets/js/waves.js"></script>
    <script src="assets/js/jquery.nicescroll.js"></script>
    <script src="assets/js/jquery.scrollTo.min.js"></script>
    <!-- App js -->
    <script src="assets/js/app.js"></script>
</body>
<!-- Mirrored from themesdesign.in/dashor/layouts/vertical/pages-invoice.html by HTTrack Website Copier/3.x [XR&CO'2014], Thu, 19 Sep 2019 21:32:38 GMT -->

</html>