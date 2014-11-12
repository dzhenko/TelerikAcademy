<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ZippedFileUploader.Default" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <!--You need to install the Telerik ASP.NET AJAX control from here http://www.telerik.com/products/aspnet-ajax.aspx-->
    <form id="form1" runat="server">
        <div>
            <telerik:RadScriptManager ID="RadScriptManager" runat="server">
                <Scripts>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
                </Scripts>
            </telerik:RadScriptManager>

            <telerik:RadAsyncUpload ID="RadAsyncUpload" runat="server" Skin="Default" MultipleFileSelection="Automatic">
            </telerik:RadAsyncUpload>
            <br />
            <asp:Button runat="server" ID="UploadButton" Text="Upload" OnClick="UploadButton_Click" />
        </div>
    </form>
</body>
</html>
