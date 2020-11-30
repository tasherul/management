<%@ Page Title="" Language="C#" MasterPageFile="~/mDesign.Master" AutoEventWireup="true" CodeBehind="Product_Stock.aspx.cs" Inherits="management.Product.Product_Stock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Product Stock</title>
    <style>
        .dColor
        {
            color:#142d3c !important;
            font-weight:bold !important;
            font-style:unset;
        }
        .req
        {
            color:red !important;
        }
    </style>
    <script type="text/javascript">
        function Sum() {
            var BuyQuantity = document.getElementById('Body_txtBuyQuantity').value;
            var BuyingPrice = document.getElementById('Body_txtBuyingPrice').value;
            var total = BuyingPrice * BuyQuantity;
            $('#Body_txtAmount').val(total);
            
        };
        function SumAmount()
        {
            var TotalAmount = document.getElementById('Body_txtAmount').value;
            var Stock = document.getElementById('Body_txtBuyQuantity').value;
            var Total = TotalAmount / Stock;
            $('#Body_txtBuyingPrice').val(Total);
            
        }
        
    

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
</asp:ScriptManager>
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="row">
                <div class="col-sm-4 col-xs-3">
                    <h4 class="page-title">Stock Adjust</h4>
                </div>
                <div class="col-sm-8 col-xs-9 text-right m-b-20">
                    <a href="../Product/Product_Add" class="btn btn-primary rounded pull-right"><i class="fa fa-plus"></i>Add Product</a>
                    <a href="../CustomerSupplier/Supplier_Add" class="btn btn-primary rounded pull-right m-r-5"><i class="fa fa-plus"></i>Add Supplier</a>
                </div>

            </div>


            <div class="row filter-row">
                <div class="col-sm-4 col-xs-6">
                    <div class="form-group form-focus select-focus">
                        <label class="control-label dColor">Product <span class="req">*</span></label>
                        <asp:DropDownList AutoPostBack="true" CssClass="floating form-control" OnTextChanged="ddlProduct_TextChanged" ID="ddlProduct" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-sm-3 col-xs-6">
                    <div class="form-group form-focus">
                        <label class="control-label dColor">Buy Quantity<span class="req">*</span></label>
                        <asp:TextBox ID="txtBuyQuantity" onkeyup="Sum()" CssClass="form-control floating" TextMode="Number" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-2"></div>



            </div>
            <div class="row filter-row">
                <div class="col-sm-2 col-xs-6">
                    <div class="form-group form-focus">
                        <label class="control-label dColor">Unit</label>
                        <asp:TextBox ID="txtUnit" ForeColor="Green" Font-Bold="true" Enabled="false" CssClass="form-control floating" runat="server">Null</asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-2 col-xs-6">
                    <div class="form-group form-focus">
                        <label class="control-label dColor">Buying Price</label>
                        <asp:TextBox ID="txtBuyingPrice" onkeyup="Sum()" ForeColor="Green" Font-Bold="true" CssClass="form-control floating" runat="server">0</asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-2 col-xs-6">
                    <div class="form-group form-focus">
                        <label class="control-label dColor">Total Stock</label>
                        <asp:TextBox ID="txtTotalStock" ForeColor="Green" Font-Bold="true" Enabled="false" CssClass="form-control floating" runat="server">0</asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-2 col-xs-6">
                    <div class="form-group form-focus">
                        <label class="control-label dColor">Amount</label>
                        <asp:TextBox ID="txtAmount" ForeColor="Green" Font-Bold="true" onkeyup="SumAmount()" CssClass="form-control floating" runat="server">0</asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-2 col-xs-6">
                    <div class="form-group form-focus">
                        <label class="control-label dColor">Total Amount</label>
                        <asp:TextBox ID="txtTtotalAmount" ForeColor="Green" Font-Bold="true" Enabled="false" CssClass="form-control floating" runat="server">0</asp:TextBox>
                    </div>
                </div>


                <div class="col-sm-2 col-xs-6">
                    <asp:Button ID="btnStockAdd" OnClick="btnStockAdd_Click" CssClass="btn btn-success btn-block" runat="server" Text="Add" />
                </div>







            </div>




            <div class="row">
                <div class="col-md-12">
                
                        <table class="table table-striped custom-table datatable">
                            <thead>
                                <tr>
                                    <th>Product</th>
                                    <th>Buy Quantity</th>
                                    <th>Unit</th>
                                    <th>Buying Price</th>
                                    <th>Amount</th>
                                    <th>Status</th>
    
                                </tr>
                            </thead>
                            <tbody>

                                <tr>
                                    <asp:PlaceHolder ID="ShowData" runat="server"></asp:PlaceHolder>
                                    </tr>
                               <%-- <tr>
                                    <td>
                                        <a class='circle m-r-10 dColor'>1.</a>
                                        <h2>Global Technologies</h2>
                                    </td>
                                    <td>100</td>
                                    <td>Pics</td>
                                    <td>500</td>
                                    <td>50000</td>
                                    <td>
                                        <div class='dropdown action-label'>
                                            <a class='btn btn-white btn-sm rounded dropdown-toggle' data-toggle='dropdown' aria-expanded='false'><i class='fa fa-dot-circle-o text-success'></i>Active <i class='caret'></i></a>
                                            <ul class='dropdown-menu'>
                                                <li><a href='#'><i class='fa fa-dot-circle-o text-success'></i>Active</a></li>
                                                <li><a href='#'><i class='fa fa-dot-circle-o text-danger'></i>Delete</a></li>
                                            </ul>
                                        </div>
                                    </td>                                    
                                </tr>--%>


                            </tbody>
                        </table>
             
                </div>
            </div>

            <div class="row filter-row">

                <div class="col-sm-3 col-xs-6">
                    <div class="form-group form-focus select-focus">
                        <label class="control-label dColor">Suppliers (Optional) </label>
                        <asp:DropDownList CssClass="floating form-control" ID="ddlSuppliers" runat="server"></asp:DropDownList>
                    </div>
                </div>

                <div class="col-sm-2 col-xs-6">
                    <div class="form-group form-focus">
                        <label class="dColor control-label">Invoice</label>
                        <asp:TextBox ID="txtInvoice" CssClass="form-control floating" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-3 col-xs-6">
                    <div class="form-group form-focus">
                        <label class="control-label dColor">Remark</label>
                        <asp:TextBox ID="txtRemark" CssClass="form-control floating" Height="100" TextMode="MultiLine" runat="server"></asp:TextBox>
                    </div>
                </div>
                 <div class="col-sm-2"></div>

            <div class="col-sm-2 col-xs-6">
                    <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" CssClass="btn btn-success btn-block" runat="server" Text="Submit" />
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
		<script type="text/javascript" src="assets/js/app.js"></script>
</asp:Content>
