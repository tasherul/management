<%@ Page Title="" Language="C#" MasterPageFile="~/mDesign.Master" AutoEventWireup="true" CodeBehind="CreateGroup.aspx.cs" Inherits="maganement.User.CreateGroup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Create Group</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">

    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="row">
                <div class="col-sm-8">
                    <h4 class="page-title">All Groups</h4>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-3">
                    <div class="roles-menu">
                        <ul class="nav">
                            <asp:PlaceHolder ID="ShowGroupData" runat="server"></asp:PlaceHolder>
                            
                        </ul>
                    </div>
                </div>
                <div class="col-sm-9">
                    <div class="row">

                        <div class="col-md-6">
                            <h6 class="panel-title m-b-20">Group</h6>
                            <div class="row">
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtGroupName" CssClass="form-control" placeholder="Group Name" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:Button ID="btnCreateGroup" OnClick="btnCreateGroup_Click" CssClass="btn btn-primary form-control" runat="server" Text="Add Group" />
                                </div>
                            </div>
                           <%--<div class=" alert alert-success ">													
									<span>adadasdasd</span>													
												</div>--%>
                            <asp:Label ID="lblCreateGroup" runat="server"></asp:Label>
                            
                          <br />
                            <div class="panel">
                                <ul class="list-group">
                                    <asp:GridView ID="GridView_Create" ShowHeader="false" GridLines="None" Width="100%" runat="server" AutoGenerateColumns="False" DataKeyNames="m_id" DataSourceID="SqlDataSource1">
                                        <Columns>
                                            <asp:TemplateField HeaderText="m_id" InsertVisible="False" SortExpression="m_id">
                                                <ItemTemplate>                                                    
                                                        <asp:Label ID="Label1" CssClass="btn-sm text-success circle" runat="server" Text='<%# Eval("m_id") %>'></asp:Label>
                                                                              
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField>
                                                
                                                <ItemTemplate>
                                                    <li class="list-group-item "><%# Eval("PageName") %>
                                                        <div class="pull-right">
                                                            <asp:CheckBox ID="CheckBox1"  runat="server" />
                                                        </div>
                                                    </li>                                               
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>


                                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:dbm %>' SelectCommand="SELECT * FROM [m_page]"></asp:SqlDataSource>
                                </ul>
                            </div>
                        </div>

                        <asp:Panel ID="pnlUpdate" runat="server">
                        <div class="col-md-6">
                            <h6 class="panel-title m-b-20">Update</h6>
                             <div class="row">                                
                                <div class="col-md-4">
                                    <asp:Button ID="btnUpdate" OnClick="btnUpdate_Click"  CssClass="btn btn-success form-control" runat="server" Text="Update" />
                                </div>
                                 <div class="col-md-4">
                                    <asp:Button ID="btnCancle" OnClick="btnCancle_Click"  CssClass="btn btn-default form-control" runat="server" Text="Cancel" />
                                </div>
                                 <div class="col-md-4">
                                    <asp:Button ID="btnDelete" OnClick="btnDelete_Click"  CssClass="btn btn-danger form-control" runat="server" Text="Delete" />
                                </div>
                            </div>
                            <asp:Label ID="lblCreateGroup2" runat="server"></asp:Label>
                            <br />
                            <div class="panel">
                                <ul class="list-group">

                                    <asp:GridView ID="GridView_Update" ShowHeader="false" GridLines="None" Width="100%" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                                        <Columns>
                                            <asp:TemplateField HeaderText="m_id" InsertVisible="False" SortExpression="m_id">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" CssClass="btn-sm text-success circle" runat="server" Text='<%# Eval("m_id") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField>

                                                <ItemTemplate>
                                                    <li class="list-group-item "><%# Eval("PageName") %>
                                                        <div class="pull-right">
                                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                                        </div>
                                                    </li>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>

                                    

                                </ul>
                            </div>
                        </div>
                        </asp:Panel>

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
</asp:Content>
