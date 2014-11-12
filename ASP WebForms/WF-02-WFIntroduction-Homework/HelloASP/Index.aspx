<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="HelloASP.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="Name" runat="server"></asp:TextBox>
        <asp:Button ID="Btn" runat="server" OnClick="Btn_Click" Text="Click me!" />
        <asp:Label ID="Result" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
