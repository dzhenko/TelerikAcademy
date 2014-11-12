<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllEmployees.aspx.cs" Inherits="EmployeesTwoPages.AllEmployees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>All employees</h1>
        <asp:Repeater runat="server" ID="AllEmps" SelectMethod="AllEmps_GetData" ItemType="EmployeesTwoPages.Employee">
            <ItemTemplate>
                <asp:HyperLink runat="server" NavigateUrl='<%# "~/DetailsEmployee.aspx/" + Item.EmployeeID %>'>
                    <%# Item.FirstName + " " + Item.LastName %><br />
                </asp:HyperLink>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
