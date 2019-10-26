<%@ Page Title="" Language="C#" MasterPageFile="~/mDesign.Master" AutoEventWireup="true" CodeBehind="GenerateBarcode.aspx.cs" Inherits="maganement.Barcode.GenerateBarcode" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Purchase Add</title>
     <style type="text/css">
        .black{
            color:black !important;            
        }
        .bold{
            font-weight:bold;
        }
        .Green{
            color: green !important;
        }
        .Red{
            color:red !important;
        }
        .back
        {
            background-color:rgba(255, 255, 255, 0.00)!important;
            border:0;
            width:25px;
        }
        .mid{
            padding-top:10px;
            text-align:right;
        }
        .pad{            
            height:35px;
        }
        .rowpad
        {
            padding-bottom:10px;
        }
        .textboxDesign
        {
            width:120px;
            height:35px;
            border:1px solid #ccc;
            padding-left:10px;
        }
        .dropdownDesign
        {
            margin-right:20px;
            width:45px;
            height:40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
     <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="row">
                <div class="col-sm-4 col-xs-3">
                    <h4 class="page-title">Return Product</h4>
                </div>
                <div class="col-sm-8 col-xs-9 text-right m-b-20">
                    <a href="../Product/Product_Add" class="btn btn-primary rounded pull-right"><i class="fa fa-plus"></i>Add Product</a>
                    <a href="../CustomerSupplier/Supplier_Add" class="btn btn-primary rounded pull-right m-r-5"><i class="fa fa-plus"></i>Add Supplier</a>
                </div>

            </div>

           
            <div class="row ">
                <div class="col-sm-3 col-xs-6">
                    <div class="form-group">
                        <label class="control-label dColor">Product</label>
                        <asp:DropDownList OnTextChanged="ddlProduct_TextChanged" AutoPostBack="true" CssClass="floating form-control"  ID="ddlProduct" runat="server"></asp:DropDownList>
                    </div>
                </div>   
                <div class="col-sm-6 col-xs-6" id="pnlTable" runat="server">
                    <div class="form-group">
                        <label class="control-label dColor">Details</label>
                        <table class="table table-striped custom-table m-b-0">
                            <thead>
                                <tr>
                                    <th class="col-md-3">Details </th>
                                    <th class="col-md-3">Stock</th>
                                    <th class="text-right col-md-1">Action</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:PlaceHolder ID="pnlShow" runat="server"></asp:PlaceHolder>
                            </tbody>
                        </table>
                    </div>
                </div>
                
                <asp:Panel ID="pnlStockAdd" runat="server">
                    
                    <div class="col-sm-2">
                        <div class="form-group" id="pnlQuantity" runat="server">
                            <label>
                                Iteams <small>Available:
                                                        <asp:TextBox ID="lblAvaiable" Enabled="false" ForeColor="Green" CssClass="back" runat="server"></asp:TextBox></small></label>
                            <asp:TextBox ID="txtQuantity" TextMode="Number" onkeyup="Sum()" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="form-group">
                            <label>Amount</label>
                            <asp:TextBox ID="txtAmount"  CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-1">
                        <div class="form-group" style="text-align:center;">
                            <label>Automatic</label>
                            <asp:CheckBox ID="chkAutomatic" AutoPostBack="true" OnCheckedChanged="chkAutomatic_CheckedChanged"  Text="" CssClass= " form-control" runat="server" />
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="form-group">
                            <label>Barcode</label>
                            <asp:TextBox ID="txtManualBarcode"  CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-1">
                        <div class="form-group">
                            <label>&nbsp;</label>
                            <asp:Button ID="btnAdd" CssClass="btn btn-success form-control" OnClick="btnAdd_Click" runat="server" Text="Add" />
                        </div>
                    </div>
                </asp:Panel>

                


           

        </div>
            <div class="row">
                <div class="col-md-4" >
                    <div class="form-group">
                        <div class="table-responsive">
                            <table class="table table-striped custom-table m-b-0">
                                <thead>
                                    <tr>
                                        <th>#</th>
                                        <th>Product Name</th>
                                        <th>Barcode</th>
                                        <th>Amount</th> 
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>1</td>
                                        <td>Samsung</td>
                                        <td>11242323</td>
                                        <td>500</td>
                                    </tr>

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
