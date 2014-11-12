<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ServerSideRadioButtons.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:RadioButtonList ID="Radios" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Radios_SelectedIndexChanged">
            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
            <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
        </asp:RadioButtonList>
        <asp:ListBox ID="MaleOptions" runat="server" Visible="false">
            <asp:ListItem Text="BMW" Value="BMW"></asp:ListItem>
            <asp:ListItem Text="Toyota" Value="Toyota"></asp:ListItem>
            <asp:ListItem Text="Audi" Value="Audi"></asp:ListItem>
            <asp:ListItem Text="Opel" Value="Opel"></asp:ListItem>
            <asp:ListItem Text="Ford" Value="Ford"></asp:ListItem>
        </asp:ListBox>
        <asp:ListBox ID="FemaleOptions" runat="server" Visible="false">
            <asp:ListItem Text="Lavazza" Value="Lavazza"></asp:ListItem>
            <asp:ListItem Text="New Brazil" Value="New Brazil"></asp:ListItem>
            <asp:ListItem Text="Nescafe" Value="Nescafe"></asp:ListItem>
            <asp:ListItem Text="Jakobs" Value="Jakobs"></asp:ListItem>
            <asp:ListItem Text="Royal" Value="Royal"></asp:ListItem>
        </asp:ListBox>
    </div>
    </form>
</body>
</html>
