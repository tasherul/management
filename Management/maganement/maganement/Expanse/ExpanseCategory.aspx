<%@ Page Title="" Language="C#" MasterPageFile="~/mDesign.Master" AutoEventWireup="true" CodeBehind="ExpanseCategory.aspx.cs" Inherits="management.Expanse.ExpanseCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title>Category</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
      <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="row">
                <div class="col-md-6 col-md-offset-1">
                    <h4 class="page-title">Expanse Category</h4>

                    <div class="row">
                        <div class="col-xs-12 col-sm-12">
                            <div class="form-group">
                                <label>Categoty Name</label>
                                <asp:TextBox ID="txtCategoryName" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-12 text-center m-t-20">
                            <asp:Button ID="btnAddCategory" OnClick="btnAddCategory_Click" CssClass="btn btn-success" runat="server" Text="Add Category" />
                        </div>
                    </div>
                    <%--OnClientClick="return GetSelectedTextValue()"--%>
                    <asp:Label ID="lblResult" runat="server"></asp:Label>
                
                </div>

                <div class="col-md-5">
                    <h5 class="page-title">Category List</h5>
                    <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="ex_id" DataSourceID="SqlDataSource1" AllowPaging="True" CellPadding="2" ForeColor="Black" GridLines="None" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px">
                        <AlternatingRowStyle BackColor="PaleGoldenrod"></AlternatingRowStyle>
                        <Columns>
                            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True"></asp:CommandField>
                            <asp:BoundField DataField="ex_id" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="ex_id"></asp:BoundField>
                            <asp:BoundField DataField="CategoryName" HeaderText="Name" SortExpression="CategoryName"></asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="Tan"></FooterStyle>

                        <HeaderStyle BackColor="Tan" Font-Bold="True"></HeaderStyle>

                        <PagerStyle HorizontalAlign="Center" BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue"></PagerStyle>

                        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite"></SelectedRowStyle>

                        <SortedAscendingCellStyle BackColor="#FAFAE7"></SortedAscendingCellStyle>

                        <SortedAscendingHeaderStyle BackColor="#DAC09E"></SortedAscendingHeaderStyle>

                        <SortedDescendingCellStyle BackColor="#E1DB9C"></SortedDescendingCellStyle>

                        <SortedDescendingHeaderStyle BackColor="#C2A47B"></SortedDescendingHeaderStyle>
                    </asp:GridView>


                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:dbm %>' DeleteCommand="DELETE FROM [ExpanseCategory] WHERE [ex_id] = @ex_id" InsertCommand="INSERT INTO [ExpanseCategory] ([CategoryName]) VALUES (@CategoryName)" SelectCommand="SELECT * FROM [ExpanseCategory]" UpdateCommand="UPDATE [ExpanseCategory] SET [CategoryName] = @CategoryName WHERE [ex_id] = @ex_id">
                        <DeleteParameters>
                            <asp:Parameter Name="ex_id" Type="Int32"></asp:Parameter>
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="CategoryName" Type="String"></asp:Parameter>
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="CategoryName" Type="String"></asp:Parameter>
                            <asp:Parameter Name="ex_id" Type="Int32"></asp:Parameter>
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </div>


            </div>
        </div>
    </div>
</asp:Content>
