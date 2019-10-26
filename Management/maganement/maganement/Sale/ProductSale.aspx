<%@ Page Title="" Language="C#" MasterPageFile="~/mDesign.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ProductSale.aspx.cs" Inherits="maganement.Sale.ProductSale" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Product Sale</title>
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
     <script type="text/javascript">
        function Sum() {
            var SellingPrice = document.getElementById('Body_txtSellingPrice').value;
            var Quantity = parseInt(document.getElementById('Body_txtQuantity').value);
            var MAX = parseInt(document.getElementById('Body_lblAvaiable').value);
            if (Quantity <= MAX)
            {
                var total = SellingPrice * Quantity;
                $('#Body_txtAmount').val(total);
            }
            else
            {
                $('#Body_txtAmount').val("Null");
            }
            
            
        };
        var a = ['', 'one ', 'two ', 'three ', 'four ', 'five ', 'six ', 'seven ', 'eight ', 'nine ', 'ten ', 'eleven ', 'twelve ', 'thirteen ', 'fourteen ', 'fifteen ', 'sixteen ', 'seventeen ', 'eighteen ', 'nineteen '];
        var b = ['', '', 'twenty', 'thirty', 'forty', 'fifty', 'sixty', 'seventy', 'eighty', 'ninety'];

        function inWords(num) {
            if ((num = num.toString()).length > 9) return 'overflow';
            n = ('000000000' + num).substr(-9).match(/^(\d{2})(\d{2})(\d{2})(\d{1})(\d{2})$/);
            if (!n) return; var str = '';
            str += (n[1] != 0) ? (a[Number(n[1])] || b[n[1][0]] + ' ' + a[n[1][1]]) + 'crore ' : '';
            str += (n[2] != 0) ? (a[Number(n[2])] || b[n[2][0]] + ' ' + a[n[2][1]]) + 'lakh ' : '';
            str += (n[3] != 0) ? (a[Number(n[3])] || b[n[3][0]] + ' ' + a[n[3][1]]) + 'thousand ' : '';
            str += (n[4] != 0) ? (a[Number(n[4])] || b[n[4][0]] + ' ' + a[n[4][1]]) + 'hundred ' : '';
            str += (n[5] != 0) ? ((str != '') ? 'and ' : '') + (a[Number(n[5])] || b[n[5][0]] + ' ' + a[n[5][1]]) + 'only ' : '';
            return str;
        }
         function TotalSum()
        {
             var Subtotal = parseInt(document.getElementById('Body_txtSubtotal').value);
             var Payment = parseInt(document.getElementById('Body_txtPayment').value);
             var Discount = parseInt(document.getElementById('Body_txtDiscount').value);
             var ddlDiscount = document.getElementById('Body_ddlDiscount').value;
             var Vat = parseInt(document.getElementById('Body_txtVat').value);
             var ddlVat = document.getElementById('Body_ddlVat').value;
             //var PaymentCheck = document.getElementById('Body_CheckBox1');
             var Due = parseInt(document.getElementById('Body_txtDue').value);
             //var Total = parseInt(document.getElementById('Body_txtTotal').value);
             var Discount_Price = 0;
             var Vat_Price = 0;
             if (document.getElementById('Body_txtPayment').value=="")
             {
                 Payment = 0;
             }
             if (document.getElementById('Body_txtDue').value=="")
             {
                 Due = 0;
             }
             if (ddlDiscount == "Percentage")
             {
                 if(Discount<=100 && Discount>0)
                 {
                     Discount_Price = (Subtotal * Discount) / 100;
                 }
                 else
                 {
                     $('#Body_txtDiscount').val(0);
                 }
             }
             else {
                 Discount_Price = Discount;
             }
             if (ddlVat == "Percentage") {
                 if (Vat <= 100 && Vat > 0) {
                     Vat_Price = (Subtotal * Vat) / 100;
                 }
                 else {
                     $('#Body_txtVat').val(0);
                 }
             }
             else {
                 Vat_Price = Vat;
             }

             var Total = ((((Subtotal - Discount_Price) + Vat_Price) + Due) - Payment);
             $('#Body_txtTotal').val(Total);
             //document.getElementById("Body_txtPayment").disabled = false;
             $('#Body_txtInWord').val(inWords(Payment));
         }
         </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="page-wrapper">
                <div class="content container-fluid">
					<div class="row">
						<div class="col-md-12">					
								<div class="row">
									<div class="col-sm-3">
										<div class="form-group">
											<label>Date <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtDate" CssClass="form-control" runat="server"></asp:TextBox>
										</div>
									</div>
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>

                                     
                                    <div class="col-sm-6" style="text-align:center;"><label>&nbsp;</label><h3 class="page-title" id="lblTitle">Product Sale <asp:Label ID="lblQuality" ForeColor="Green" runat="server" ></asp:Label></h3></div>
                                       </ContentTemplate>
                                    </asp:UpdatePanel>
									<div class="col-sm-3">
										<div class="form-group">
											<label>Memo</label>
                                            <asp:TextBox ID="txtMemo" placeholder="memo number" CssClass="form-control" runat="server"></asp:TextBox>
										</div>
									</div>
								</div>
                            
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
								<div class="row">									
									<div class="col-sm-6 col-md-6 col-lg-3">
										<div class="form-group">
											<label>Customer Name</label>
                                            <asp:DropDownList ID="ddlCustomerName" AutoPostBack="true" OnTextChanged="ddlCustomerName_TextChanged" CssClass="form-control select" runat="server" >
                                            </asp:DropDownList>
                                            <asp:TextBox ID="txtCustomerName" placeholder="customer name" CssClass="form-control" runat="server"></asp:TextBox>
										</div> 
									</div>
									<div class="col-sm-6 col-md-6 col-lg-6">
										<div class="form-group">
											<label>Address</label>
                                            <asp:TextBox ID="txtAddress" placeholder="address" CssClass="form-control" runat="server"></asp:TextBox>
										</div>
									</div>
                                    <div class="col-sm-6 col-md-6 col-lg-3">
										<div class="form-group">
											<label>Mobile</label>
                                            <asp:TextBox ID="txtMobile" placeholder="01xxxxxxxxxx" CssClass="form-control" runat="server"></asp:TextBox>
										</div>
									</div>									
								</div>
                              </ContentTemplate>
                            </asp:UpdatePanel>

                           

                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <div class="form-group">
                                                <label>Product</label>
                                                <asp:DropDownList ID="ddlProductlist" OnTextChanged="ddlProductlist_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server">
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="col-sm-6" id="pnlTable" runat="server">
                                            <div class="form-group">
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
                                                <div class="form-group">
                                                    <label>Selling Price</label>
                                                    <asp:TextBox ID="txtSellingPrice" onkeyup="Sum()" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-sm-2">
                                                <div class="form-group">
                                                    <label>Quality <small>Available:
                                                        <asp:TextBox ID="lblAvaiable" Enabled="false" ForeColor="Green" CssClass="back" runat="server"></asp:TextBox></small></label>
                                                    <asp:TextBox ID="txtQuantity" TextMode="Number" onkeyup="Sum()" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-sm-2">
                                                <div class="form-group">
                                                    <label>Unit</label>
                                                    <asp:TextBox ID="txtUnit" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-sm-2">
                                                <div class="form-group">
                                                    <label>Amount</label>
                                                    <asp:TextBox ID="txtAmount" Enabled="false" CssClass="form-control" runat="server">0</asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-sm-1">
                                                <div class="form-group">
                                                    <label>&nbsp;</label>
                                                    <asp:Button ID="btnAdd" OnClick="btnAdd_Click" CssClass="btn btn-success form-control" runat="server" Text="Add" />
                                                </div>
                                            </div>
                                        </asp:Panel>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-8">
                                            <table class="table table-striped custom-table datatable">
                                                <thead>
                                                    <tr>
                                                        <th>Product</th>
                                                        <th>Buy Quantity</th>
                                                        <th>Unit</th>
                                                        <th>Selling Price</th>
                                                        <th>Amount</th>
                                                        <th>Status</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <asp:PlaceHolder ID="pnlShowData" runat="server"></asp:PlaceHolder>
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
                                                <li><a href='#'><i class='fa fa-dot-circle-o text-danger'></i>Delete</a></li>
                                            </ul>
                                        </div>
                                    </td>                                    
                                </tr>--%>
                                                </tbody>
                                            </table>
                                            <div class="row">
                                                <div class="col-md-3">
                                                    <asp:TextBox ID="txtRemark" TextMode="MultiLine" Height="100" placeholder="Remark" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-md-9">
                                                    <asp:TextBox ID="txtInWord" CssClass="form-control" placeholder="in word" Enabled="false" runat="server"></asp:TextBox>
                                                    <br />
                                                    <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" CssClass="btn btn-success form-control" runat="server" Text="Submit" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">

                                            <div class="row rowpad">
                                                <label class="col-md-5 mid">Sub Total:</label>
                                                <div class="col-md-7">
                                                    <asp:TextBox ID="txtSubtotal" Enabled="false" CssClass="form-control pad" runat="server">0</asp:TextBox>                                                    
                                                </div>
                                            </div>

                                            <div class="row rowpad">
                                                <label class="col-md-5 mid">Payment:</label>
                                                <div class="col-md-7 ">
                                                    <asp:TextBox ID="txtPayment"  onkeyup="TotalSum()" CssClass="form-control pad" runat="server">0</asp:TextBox>       
                                                </div>
                                            </div>
                                            <div class="row rowpad">
                                                <label class="col-md-5 mid"> Discount:</label>
                                                <div class="col-md-5 pad">
                                                    <asp:TextBox ID="txtDiscount" onkeyup="TotalSum()" CssClass="textboxDesign" runat="server">0</asp:TextBox>       
                                                </div>
                                                <div class="col-md-2 pad">
                                                    <asp:DropDownList ID="ddlDiscount" onchange="TotalSum()" CssClass="dropdownDesign" runat="server">
                                                        <asp:ListItem Value="Percentage">%</asp:ListItem>
                                                        <asp:ListItem Value="Taka">Tk</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="row rowpad">
                                                <label class="col-md-5 mid">Vat:</label>
                                                <div class="col-md-5 pad" >
                                                    <asp:TextBox ID="txtVat" onkeyup="TotalSum()"  CssClass="textboxDesign" runat="server">0</asp:TextBox>     
                                                </div>
                                                <div class="col-md-2 pad" >
                                                    <asp:DropDownList ID="ddlVat" onchange="TotalSum()" CssClass="dropdownDesign" runat="server">
                                                        <asp:ListItem Value="Percentage">%</asp:ListItem>
                                                        <asp:ListItem Value="Taka">Tk</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="row rowpad">
                                                <label class="col-md-5 mid">Due:</label>
                                                <div class="col-md-7 pad">
                                                    <asp:TextBox ID="txtDue" onkeyup="TotalSum()" CssClass="form-control" runat="server">0</asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row rowpad ">
                                                <label class="col-md-5 mid">Total Due:</label>
                                                <div class="col-md-7 pad">
                                                    <asp:TextBox ID="txtTotal" Enabled="false" CssClass="form-control" runat="server">0</asp:TextBox>
                                                </div>
                                            </div>


                                        </div>

                                    </div>

                                </ContentTemplate>
                            </asp:UpdatePanel>
							
								<%--<div class="row">
									<div class="col-sm-12">
										<div class="form-group">
											<label>Website Url</label>
											<input class="form-control" value="https://www.example.com" type="text">
										</div>
									</div>
								</div>--%>

							
					
						</div>
					</div>
                </div>
        </div>


</asp:Content>
