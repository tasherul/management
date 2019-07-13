<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ManagementApp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

   
</head>
<body>
    <form id="form1" runat="server">
   <table border="0" cellpadding="0" cellspacing="0">
<tr>
    <td>
        Name:
    </td>
    <td>
        <asp:TextBox ID="txtName" runat="server" Text="" />
    </td>
</tr>
<tr>
    <td>
        Age:
    </td>
    <td>
        <asp:TextBox ID="txtAge" runat="server" Text="" />
    </td>
</tr>
<tr>
    <td>
        <asp:Button ID="btnSubmit" Text="Submit" runat="server" />
    </td>
</tr>
</table>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>


            <script type="text/javascript">
                $(function () {
                    $("[id*=btnSubmit]").click(function () {
                        var name = $.trim($("[id*=txtName]").val());
                        var age = $.trim($("[id*=txtAge]").val());
                        $.ajax({
                            type: "POST",
                            url: "test.asmx/GetDetails",
                            data: "{ name: '" + name + "', age: " + age + "}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (r) {
                                alert(r.d);
                            },
                            error: function (r) {
                                alert(r.responseText);
                            },
                            failure: function (r) {
                                alert(r.responseText);
                            }
                        });
                        return false;
                    });
                });
            </script>


    </form>
</body>
</html>
