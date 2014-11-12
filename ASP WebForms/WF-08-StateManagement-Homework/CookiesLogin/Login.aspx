<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CookiesLogin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="Username" runat="server" placeholder="Enter your username"></asp:TextBox>
        <asp:Button ID="LoginBtn" runat="server" OnClick="Login_Click" Text="Login"/>
    </div>
    </form>
</body>
</html>
