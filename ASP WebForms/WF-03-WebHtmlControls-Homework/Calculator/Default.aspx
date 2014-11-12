<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Calculator.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="1" style="text-align:center">
            <thead>
                <tr>
                    <th colspan="4">
                        <asp:Literal Mode="Encode" ID="Result" runat="server" Text="0"></asp:Literal>
                    </th>
                </tr>
            </thead>
            <tfoot>
                <tr>
                    <td colspan="4">
                        <asp:Button Text="           =           " runat="server" OnClick="Calculate_Click" />
                    </td>
                </tr>
            </tfoot>
            <tbody>
                <tr>
                    <td><asp:Button Text="1" runat="server" OnCommand="Digit_Click" CommandArgument="1" /></td>
                    <td><asp:Button Text="2" runat="server" OnCommand="Digit_Click" CommandArgument="2" /></td>
                    <td><asp:Button Text="3" runat="server" OnCommand="Digit_Click" CommandArgument="3" /></td>
                    <td><asp:Button Text="+" runat="server" OnCommand="Operation_Click" CommandArgument="+" /></td>
                </tr>
                <tr>
                    <td><asp:Button Text="4" runat="server" OnCommand="Digit_Click" CommandArgument="4" /></td>
                    <td><asp:Button Text="5" runat="server" OnCommand="Digit_Click" CommandArgument="5" /></td>
                    <td><asp:Button Text="6" runat="server" OnCommand="Digit_Click" CommandArgument="6" /></td>
                    <td><asp:Button Text="-" runat="server" OnCommand="Operation_Click" CommandArgument="-" /></td>
                </tr>
                <tr>
                    <td><asp:Button Text="7" runat="server" OnCommand="Digit_Click" CommandArgument="7" /></td>
                    <td><asp:Button Text="8" runat="server" OnCommand="Digit_Click" CommandArgument="8" /></td>
                    <td><asp:Button Text="9" runat="server" OnCommand="Digit_Click" CommandArgument="9" /></td>
                    <td><asp:Button Text="X" runat="server" OnCommand="Operation_Click" CommandArgument="*" /></td>
                </tr>
                <tr>
                    <td><asp:Button Text="C" runat="server" OnClick="Clear_Click" /></td>
                    <td><asp:Button Text="0" runat="server" OnCommand="Digit_Click" CommandArgument="0" /></td>
                    <td><asp:Button Text="/" runat="server" OnCommand="Operation_Click" CommandArgument="/" /></td>
                    <td><asp:Button ID="SqRootBtn" runat="server" OnCommand="Operation_Click" CommandArgument="sr" /></td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>
