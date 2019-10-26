<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="WebForm1.aspx.cs" Inherits="maganement.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:DropDownList ID="ddlWirehouseSub" OnTextChanged="ddlWirehouseSub_TextChanged" CssClass="form-control" runat="server"></asp:DropDownList>
        <asp:DropDownList ID="ddlCategory" CssClass="form-control" runat="server"></asp:DropDownList>
        <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text="Button" />
        <asp:Image ID="Image1" runat="server" />
        <asp:Label ID="Label1" runat="server" ></asp:Label>

    </div>
    </form>
</body>
</html>
