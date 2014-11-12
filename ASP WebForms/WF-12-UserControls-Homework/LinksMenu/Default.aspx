<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LinksMenu.Default" %>
<%@ Register TagPrefix="uc" TagName="LinkMenu" Src="~/LinkMenu.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc:LinkMenu runat="server" ID="LinkMenu" FontColor="Blue"></uc:LinkMenu>
    </div>
    </form>
</body>
</html>
