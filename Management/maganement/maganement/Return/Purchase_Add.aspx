<%@ Page Title="" Language="C#" MasterPageFile="~/mDesign.Master" AutoEventWireup="true" CodeBehind="Purchase_Add.aspx.cs" Inherits="management.Return.Purchase_Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Purchase Add</title>
    <script type="text/javascript">
        function Sum() {
            var ReturnIteams = parseInt(document.getElementById('Body_txtReturnIteams').value);
            var AvaiableIteams = parseInt(document.getElementById('Body_txtAvaiableStock').value);
            if (ReturnIteams <= AvaiableIteams)
            {
                var ReturnIPrice = parseInt(document.getElementById('Body_txtBuyingPrice').value);
                //var ReturnIAmount = parseInt(document.getElementById('Body_txtAmount').value);

                var total = ReturnIPrice * ReturnIteams;
                $('#Body_txtAmount').val(total);

            }
            else
            {
                $('#Body_txtAmount').val("");
            }

        };

         

        function Sum2() {
            var ReturnIteams = parseInt(document.getElementById('Body_txtReturnIteams').value);
            var AvaiableIteams = parseInt(document.getElementById('Body_txtAvaiableStock').value);
            if (ReturnIteams <= AvaiableIteams) {
                var ReturnIPrice = parseInt(document.getElementById('Body_txtBuyingPrice').value);
                var ReturnIAmount = parseInt(document.getElementById('Body_txtAmount').value);

                var total = ReturnIAmount / ReturnIteams;
                $('#Body_txtBuyingPrice').val(total);

            }
        };
        </script>
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

           
            <div class="row filter-row">
                <div class="col-sm-4 col-xs-6">
                    <div class="form-group form-focus select-focus ">
                        <label class="control-label dColor">Product <span class="req">*</span></label>
                        <asp:DropDownList  OnTextChanged="ddlProduct_TextChanged" AutoPostBack="true" CssClass="floating form-control"  ID="ddlProduct" runat="server"></asp:DropDownList>
                    </div>
                </div>   
                 <div class="col-sm-2 col-xs-6">
                    <div class="form-group form-focus" id="pnlReturnIteams" runat="server">
                        <label class="control-label">Return Iteams</label>
                        <asp:TextBox ID="txtReturnIteams" onkeyup="Sum()" CssClass="form-control floating" TextMode="Number" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-4 col-xs-6">
                    <div class="form-group" id="pnlRemark" runat="server">
                        
                        <asp:TextBox ID="txtRemark" placeholder="short details for return product" CssClass="form-control " TextMode="MultiLine" runat="server"></asp:TextBox>
                    </div>
                </div>   
                <div class="col-sm-2 col-xs-6">
                    <div class="form-group form-focus" id="pnlPreviousReturn" runat="server">
                        <label class="control-label">Previus Return</label>
                        <asp:TextBox ID="txtPreviousReturn" Enabled="false" ForeColor="Green" Font-Bold="true" CssClass="form-control floating" TextMode="Number" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>

            <asp:Panel ID="pnlShowRetuen" runat="server">
                <div class="row filter-row">
                    <div class="col-sm-2 col-xs-6">
                        <div class="form-group form-focus">
                            <label class="control-label dColor">Unit</label>
                            <asp:TextBox ID="txtUnit" ForeColor="Green" Font-Bold="true" Enabled="false" CssClass="form-control floating" runat="server">Null</asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-2 col-xs-6">
                        <div class="form-group form-focus">
                            <label class="control-label dColor">Return Price</label>
                            <asp:TextBox ID="txtBuyingPrice" onkeyup="Sum()" ForeColor="Green" Font-Bold="true" CssClass="form-control floating" runat="server">0</asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-2 col-xs-6">
                        <div class="form-group form-focus">
                            <label class="control-label dColor">Avaiable Stock</label>
                            <asp:TextBox ID="txtAvaiableStock" ForeColor="Green" Font-Bold="true" Enabled="false" CssClass="form-control floating" runat="server">0</asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-2 col-xs-6">
                        <div class="form-group form-focus">
                            <label class="control-label dColor">Amount</label>
                            <asp:TextBox ID="txtAmount" ForeColor="Green" onkeyup="Sum2()" Font-Bold="true" CssClass="form-control floating" runat="server">0</asp:TextBox>
                        </div>
                    </div>
                    <div class="col-sm-2 col-xs-6" id="pnlSaleIteams" runat="server">
                        <div class="form-group form-focus">
                            <label class="control-label dColor">Sale Itams</label>
                            <asp:TextBox ID="txtSaleIteams" Enabled="false" ForeColor="Green" Font-Bold="true" CssClass="form-control floating" runat="server">0</asp:TextBox>
                        </div>
                    </div>


                    <div class="col-sm-2 col-xs-6">
                        <asp:Button ID="btnReturn" OnClick="btnReturn_Click" CssClass="btn btn-success btn-block" runat="server" Text="Return" />
                    </div>







                </div>
            </asp:Panel>

            <div class="row">
                <div class="col-md-12">                
                        <table class="table table-striped custom-table datatable">
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Product Name</th>
                                    <th>Invoice</th>
                                    <th>Quantity</th>
                                    <th>Buy Price</th>
                                    <th>Amount</th>
                                    <th>Unit</th>
                                    <th>InputDate</th>
                                    <th>Suppliers Name</th>
                                    <th>Status</th> 
                                    <th>Act</th>   
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <asp:PlaceHolder ID="ShowData" runat="server"></asp:PlaceHolder>
                                </tr> 
                            </tbody>
                        </table>
             
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
