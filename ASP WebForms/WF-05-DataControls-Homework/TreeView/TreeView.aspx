<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TreeView.aspx.cs" Inherits="TreeView.TreeView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:XmlDataSource runat="server" ID="XmlSrc" DataFile="~/VendorExpensesInitialData.xml" ></asp:XmlDataSource>
        <asp:TreeView runat="server" DataSourceID="XmlSrc">
            <DataBindings>
                <asp:TreeNodeBinding DataMember="expenses" TextField="#InnerText" />
                <asp:TreeNodeBinding DataMember="vendor" ValueField="name" />
            </DataBindings>
        </asp:TreeView>
    </div>
    </form>
</body>
</html>
