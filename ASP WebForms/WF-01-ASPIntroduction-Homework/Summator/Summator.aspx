<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Summator.aspx.cs" Inherits="Summator.Summator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Giga cool sumator!</h1>
    <form id="form1" runat="server">
    <div>
        Value 1:
        <asp:TextBox runat="server" ID="Val1">
        </asp:TextBox>
        <hr />
        Value 2:
        <asp:TextBox runat="server" ID="Val2">
        </asp:TextBox>
        <hr />
        <asp:Button runat="server" ID="SumBtn" Text="Sum" OnClick="sumBtn_Click"/>
        Result: <asp:Label runat="server" ID="Result"></asp:Label>
    </div>
    </form>
</body>
</html>
