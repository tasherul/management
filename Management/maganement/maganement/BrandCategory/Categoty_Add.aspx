<%@ Page Title="" Language="C#" MasterPageFile="~/mDesign.Master" AutoEventWireup="true" CodeBehind="Categoty_Add.aspx.cs" Inherits="management.BrandCategory.Categoty_Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Category</title>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <div class="page-wrapper">
        <div class="content container-fluid">
            <div class="row">
                <div class="col-md-6 col-md-offset-1">
                    <h4 class="page-title">Brand & Category</h4>

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
                            <asp:Button ID="btnUpdateCategory" OnClick="btnUpdateCategory_Click" CssClass="btn btn-success" runat="server" Text="Update Categoty" />
                        </div>
                    </div>
                    <%--OnClientClick="return GetSelectedTextValue()"--%>
                    <asp:Label ID="lblResult" runat="server"></asp:Label>
                
                </div>

                <div class="col-md-4">
                    <h5 class="page-title">Note</h5>
                    <a class="text-justify"><strong>(English) </strong>Please First Select Wirehouse Category Then Type Cagtegory Name.</a>
                    <br />
                    <br />
                    <a class="text-justify"><strong>(বাংলা) </strong>প্রথমে ওয়্যারহাউস বিভাগ নির্বাচন করুন তারপর শ্রেণীবিভাগ নাম লিখুন ।</a>
                </div>


            </div>
        </div>
    </div>
    
</asp:Content>
