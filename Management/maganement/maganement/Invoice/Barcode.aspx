<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Barcode.aspx.cs" Inherits="maganement.Invoice.Barcode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width,initial-scale=1,user-scalable=0,minimal-ui"/>
    <title>Barcode</title>
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
    <form id="form1" runat="server">
    

         <div> 
                <div class="page-content-wrapper">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="page-title-box">
                                    <div class="float-right">
                                        <div class="dropdown">
                                           <div class="d-print-none float-right"><a href="javascript:window.print()" class="btn btn-info text-light"><i class="fas fa-print"></i></a> 
                                               <a href="../Barcode/GenerateBarcode" class="btn btn-danger text-light"><- Back</a>
                                              <%-- <button class="btn btn-secondary btn-round dropdown-toggle px-3" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i class="mdi mdi-settings mr-1"></i>Settings</button> 
                                               <div class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdownMenuButton"><a class="dropdown-item" href="#">Action</a> <a class="dropdown-item" href="#">Another action</a> <a class="dropdown-item" href="#">Something else here</a></div>                                             --%>
                                           </div>                                           
                                        </div>                                        
                                    </div>
                                    <h4 class="page-title text-center">BarCode</h4></div>
                            </div>
                        </div>
                        <!-- end page title end breadcrumb    justify-content-end justify-content-between -->
                        <div class="row d-flex  justify-content-center">
                            <div class="col-md-12">
                                <div class="card">
                                    <div class="card-body invoice">
                                        <div class="row">
                                            <asp:PlaceHolder ID="pnlShowBarcode" runat="server"></asp:PlaceHolder>

                                         <%--  
                                            <div class="col-md-2 m-b-30 m-t-30">
                                                <img src="../image/bar-code.jpg" width="100%" />
                                            </div> 
                                            <div class="col-md-2 m-b-30 m-t-30">
                                                <img src="../image/bar-code.jpg" width="100%" />
                                            </div> 
                                            <div class="col-md-2 m-b-30 m-t-30">
                                                <img src="../image/bar-code.jpg" width="100%" />
                                            </div> 
                                            <div class="col-md-2 m-b-30 m-t-30">
                                                <img src="../image/bar-code.jpg" width="100%" />
                                            </div> 
                                            <div class="col-md-2 m-b-30 m-t-30">
                                                <img src="../image/bar-code.jpg" width="100%" />
                                            </div> 
                                             <div class="col-md-2 m-b-30 m-t-30">
                                                <img src="../image/bar-code.jpg" width="100%" />
                                            </div> 
                                             <div class="col-md-2 m-b-30 m-t-30">
                                                <img src="../image/bar-code.jpg" width="100%" />
                                            </div> --%>
                                        </div>
                                      
                                       
                                        
                                      


                                        <div class="row d-flex justify-content-center">
                                            <div class="col-lg-12 col-xl-4 ml-auto align-self-center">
                                                <div class="text-center text-muted"><small>Thank you very much for doing business with us. APitSoft !</small></div>
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
            <footer class="footer">©2020 <a href="http://apitsoft.com">APitSoft</a>.</footer>
        
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

        
    </form>
</body>
</html>
