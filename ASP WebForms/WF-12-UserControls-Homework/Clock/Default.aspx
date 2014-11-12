<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Clock.Default" %>
<%@ Register TagPrefix="uc" TagName="Clock" Src="~/Clock.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc:Clock runat="server" ID="Clock" TimeZone="+2"></uc:Clock>
    </div>
    </form>
</body>
</html>
