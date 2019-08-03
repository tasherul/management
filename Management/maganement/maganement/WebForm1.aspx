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
        <asp:Button ID="Button1" runat="server" Text="Button" />

    </div>
    </form>
</body>
</html>
