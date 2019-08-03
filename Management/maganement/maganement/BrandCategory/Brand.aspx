<%@ Page Title="" Language="C#" MasterPageFile="~/mDesign.Master" AutoEventWireup="true" CodeBehind="Brand.aspx.cs" Inherits="maganement.BrandCategory.Brand" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Brand</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="page-wrapper">
                <div class="content container-fluid">
					<div class="row">
						<div class="col-md-6 col-md-offset-1">
							<h4 class="page-title">Brand & Category</h4>

                            <asp:Panel ID="pnlUpdate" runat="server">
                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>

                                        <div class="row">
                                            <div class="col-xs-12 col-sm-12">
                                                <div class="form-group">
                                                    <label>Select WireHouse</label>
                                                    <asp:DropDownList ID="ddlWirehouse" OnTextChanged="ddlWirehouse_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:DropDownList>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-xs-12 col-sm-12">
                                                <div class="form-group">
                                                    <label>Select Categoty</label>
                                                    <asp:DropDownList ID="ddlCategory" OnTextChanged="ddlCategory_TextChanged" AutoPostBack="true" CssClass="form-control" runat="server"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-xs-12 col-sm-12">
                                                <div class="form-group">
                                                    <label>Select Sub Categoty</label>
                                                    <asp:DropDownList ID="ddlSubCategory" CssClass="form-control" runat="server"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </asp:Panel>

                            <div class="row">
                                <div class="col-xs-12 col-sm-12">
                                    <div class="form-group">
                                        <label>Brand Name</label>
                                        <asp:TextBox ID="txtBrandName" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 text-center m-t-20">
                                    <asp:Button ID="btnBrand" OnClick="btnBrand_Click"  CssClass="btn btn-success" runat="server" Text="Add Brand" />
                                    <asp:Button ID="btnUpdateBrand" OnClick="btnUpdateBrand_Click"  CssClass="btn btn-success" runat="server" Text="Update Brand" />
                                </div>
                            </div>
						<asp:Label ID="lblResult" runat="server" ></asp:Label>
						</div>
                        <div class="col-md-4">
                            <h5 class="page-title">Note</h5>
                            <a class="text-justify"> <strong>(English) </strong> Please First Select Wirehouse Category Then Select Cagtegory Name and Then Type Sub Category Name.</a>
                            <br /><br />
                            <a class="text-justify"> <strong>(বাংলা) </strong> প্রথমে ওয়্যারহাউস বিভাগ নির্বাচন করুন তারপর বিভাগের নাম নির্বাচন করুন এবং তারপরে উপ বিভাগের নাম টাইপ করুন ।</a>


                        </div>


					</div>
				</div>
         </div>
    
</asp:Content>
