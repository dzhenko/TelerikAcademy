<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ClientSideRadioButtons.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="radiosHolder">
                <asp:RadioButtonList ID="Radios" runat="server">
                    <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div id="maleOptions" hidden="hidden">
                <asp:ListBox ID="ListBox2" runat="server">
                    <asp:ListItem Text="BMW" Value="BMW"></asp:ListItem>
                    <asp:ListItem Text="Toyota" Value="Toyota"></asp:ListItem>
                    <asp:ListItem Text="Audi" Value="Audi"></asp:ListItem>
                    <asp:ListItem Text="Opel" Value="Opel"></asp:ListItem>
                    <asp:ListItem Text="Ford" Value="Ford"></asp:ListItem>
                </asp:ListBox>
            </div>
            <div id="femaleOptions" hidden="hidden">
                <asp:ListBox ID="ListBox1" runat="server">
                    <asp:ListItem Text="Lavazza" Value="Lavazza"></asp:ListItem>
                    <asp:ListItem Text="New Brazil" Value="New Brazil"></asp:ListItem>
                    <asp:ListItem Text="Nescafe" Value="Nescafe"></asp:ListItem>
                    <asp:ListItem Text="Jakobs" Value="Jakobs"></asp:ListItem>
                    <asp:ListItem Text="Royal" Value="Royal"></asp:ListItem>
                </asp:ListBox>
            </div>
        </div>
    </form>
    <script src="jquery.js"></script>
    <script>
        $("#radiosHolder").click(function () {
            if ($("#radiosHolder input:checked").val() == "Male") {
                $("#maleOptions").show();
                $("#femaleOptions").hide();
            }
            else {
                $("#maleOptions").hide();
                $("#femaleOptions").show();
            }
        })
    </script>
</body>
</html>
