<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Escaping.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="Input" runat="server" />
        <asp:Button runat="server" OnClick="Btn_Click" Text="Click me!"/>
        <hr />
        Text box : <asp:TextBox ID="Result1" runat="server" />
        <hr />
        Label : <asp:Label ID="Result2" runat="server" />
    </div>
    </form>
</body>
</html>
