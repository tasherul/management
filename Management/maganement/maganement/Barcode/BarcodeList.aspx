<%@ Page Title="" Language="C#" MasterPageFile="~/mDesign.Master" AutoEventWireup="true" CodeBehind="BarcodeList.aspx.cs" Inherits="management.Barcode.BarcodeList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title>Barcode List</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <div class="table-responsive">
                            <div class="panel">
                                <ul class="list-group">
                                    <li class="list-group-item ">
                                        <div class="row">
                                            <div class="col-md-2">
                                                <asp:CheckBox ID="CheckBox1" Text="&nbsp;All | Index" runat="server" />

                                            </div>
                                            <div class="col-md-3"><strong>Barcode</strong></div>
                                            <div class="col-md-3"><strong>Product Name</strong></div>
                                            <div class="col-md-2"><strong>Price</strong></div>
                                            <div class="col-md-2"><strong>Status</strong></div>
                                        </div>
                                    </li>
                                    <asp:GridView ID="GridView1" Width="100%" ShowHeader="false" GridLines="None" runat="server" AutoGenerateColumns="False" DataKeyNames="bc_id" DataSourceID="SqlDataSource1">
                                        <Columns>
                                            <asp:TemplateField HeaderText="bc_id" InsertVisible="False" SortExpression="bc_id">
                                                <ItemTemplate>
                                                    <li class="list-group-item">
                                                        <div class="row">
                                                            <div class="col-md-2">
                                                                <asp:CheckBox ID="chkIndex" runat="server" Text='<%# "&nbsp;#0x"+Convert.ToInt32(Eval("bc_id")).ToString("X")+Convert.ToString(Convert.ToInt32(Eval("bc_id")),10)  %>' />
                                                            </div>
                                                            <div class="col-md-3 text-danger"><%#  Eval("BarCode") %> </div>
                                                            <div class="col-md-3"><%#  Eval("Product_Name") %>
                                                                <br />
                                                                <b><sup><%#  Eval("GeneratID") %></sup></b></div>

                                                            <div class="col-md-2"><span class="label label-info-border"><%#  Eval("Product_Price") %></span></div>
                                                            <div class="col-md-2"><%#  Eval("Sell_Code").ToString().ToLower()=="true"?"<span class='label label-danger-border'>Sale</span> ":"<span class='label label-success-border'>Avaiable</span>" %></div>
                                                        </div>
                                                    </li>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <%--    <asp:BoundField DataField="s_id" HeaderText="s_id" SortExpression="s_id"></asp:BoundField>
                                            <asp:BoundField DataField="p_id" HeaderText="p_id" SortExpression="p_id"></asp:BoundField>
                                            <asp:BoundField DataField="GeneratID" HeaderText="GeneratID" SortExpression="GeneratID"></asp:BoundField>
                                            <asp:BoundField DataField="BarCode" HeaderText="BarCode" SortExpression="BarCode"></asp:BoundField>
                                            <asp:BoundField DataField="Product_Name" HeaderText="Product_Name" SortExpression="Product_Name"></asp:BoundField>
                                            <asp:BoundField DataField="Product_Price" HeaderText="Product_Price" SortExpression="Product_Price"></asp:BoundField>
                                            <asp:BoundField DataField="DateTime" HeaderText="DateTime" SortExpression="DateTime"></asp:BoundField>
                                            <asp:BoundField DataField="Sell_Code" HeaderText="Sell_Code" SortExpression="Sell_Code"></asp:BoundField>--%>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:dbm %>' SelectCommand="SELECT * FROM [Barcode]"></asp:SqlDataSource>

                                </ul>
                            </div>
                         

                        </div>
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label dColor">Select Product</label>
                                <asp:DropDownList CssClass="floating form-control" ID="ddlProduct" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label dColor">Select Status</label>
                                <asp:DropDownList  CssClass="floating form-control" ID="DropDownList1" runat="server">
                                    <asp:ListItem Selected="True">All</asp:ListItem>
                                    <asp:ListItem Value="Sell_Code='false'">Avaiable</asp:ListItem>
                                    <asp:ListItem Value="Sell_Code='true'">Sale</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>


                        <div class="col-md-6">
                            

                        </div>

                    </div>

                    


                </div>
            </div>
        </div>
    </div>

</asp:Content>
