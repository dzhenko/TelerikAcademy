<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TicTacToe.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tic Tac Toe</title>
    <link href="style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="wrapper">
        <h1>
            <asp:Label ID="Result" runat="server" Text="Your turn"></asp:Label>
        </h1>
        <table>
            <tr>
                <td><asp:Button Id="Btn0" Visible="true" runat="server" CommandArgument="0" OnCommand="Click_Command" /></td>
                <td><asp:Button Id="Btn1" Visible="true" runat="server" CommandArgument="1" OnCommand="Click_Command" /></td>
                <td><asp:Button Id="Btn2" Visible="true" runat="server" CommandArgument="2" OnCommand="Click_Command" /></td>
            </tr>
            <tr>
                <td><asp:Button Id="Btn3" Visible="true" runat="server" CommandArgument="3" OnCommand="Click_Command" /></td>
                <td><asp:Button Id="Btn4" Visible="true" runat="server" CommandArgument="4" OnCommand="Click_Command" /></td>
                <td><asp:Button Id="Btn5" Visible="true" runat="server" CommandArgument="5" OnCommand="Click_Command" /></td>
            </tr>
            <tr>
                <td><asp:Button Id="Btn6" Visible="true" runat="server" CommandArgument="6" OnCommand="Click_Command" /></td>
                <td><asp:Button Id="Btn7" Visible="true" runat="server" CommandArgument="7" OnCommand="Click_Command" /></td>
                <td><asp:Button Id="Btn8" Visible="true" runat="server" CommandArgument="8" OnCommand="Click_Command" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
