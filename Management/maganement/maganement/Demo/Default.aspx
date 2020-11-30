<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="management.Demo.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Demo</title>
	<link href="../AutoComplete/css/base/jquery-ui-1.10.4.custom.css" rel="stylesheet"/>
	<script src="../AutoComplete/js/jquery-1.10.2.js"></script>
	<script src="../AutoComplete/js/jquery-ui-1.10.4.custom.js"></script>

	<script>
	
	</script>
	
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2 class="demoHeaders">Autocomplete</h2>
<div>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
</div>

        <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text="Button" />
    </div>
    </form>
</body>
</html>
