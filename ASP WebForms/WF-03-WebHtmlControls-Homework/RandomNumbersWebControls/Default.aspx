<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RandomNumbersWebControls.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Range</h2>
        <asp:TextBox ID="Val1" runat="server" Placeholder="Range from"/>
        <br />
        <asp:TextBox ID="Val2" runat="server" Placeholder="Range to"/>
        <br />
        <asp:Button runat="server" OnClick="Btn_Click" Text="Get random number" />
        <asp:Literal runat="server" ID="Result" />
    </div>
    </form>
</body>
</html>
