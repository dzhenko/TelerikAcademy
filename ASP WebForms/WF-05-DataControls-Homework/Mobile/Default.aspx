<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Mobile.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Welcome to Mobile.eDaMaNe</h1>
        <hr />
        <h2>Model</h2>
        <asp:DropDownList runat="server" ID="CarProducer" SelectMethod="GetProducers" AutoPostBack="true" OnSelectedIndexChanged="CarProducer_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:DropDownList runat="server" ID="CarModel">
        </asp:DropDownList>
        <h2>Extras</h2>
        <asp:CheckBoxList runat="server" ID="Extras" SelectMethod="GetExtras"></asp:CheckBoxList>
        <h2>Engine Type</h2>
        <asp:RadioButtonList runat="server" ID="Engine" RepeatDirection="Horizontal" SelectMethod="GetEngines"></asp:RadioButtonList>
        <asp:Button runat="server" ID="SubmitBtn" Text="Get That Car" OnClick="SubmitBtn_Click"/>
        <h2>Your choice :</h2>
        <asp:Literal ID="Result" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>
