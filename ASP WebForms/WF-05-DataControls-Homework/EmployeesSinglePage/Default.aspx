<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EmployeesSinglePage.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>All employees</h1>
            <asp:Repeater runat="server" ID="AllEmps" SelectMethod="AllEmps_GetData" ItemType="EmployeesSinglePage.Employee">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Item.FirstName + " " + Item.LastName %>'></asp:Label>
                    <asp:Button runat="server" Text="View Details" OnCommand="Details_Command" CommandArgument="<%# Item.EmployeeID %>"></asp:Button>
                    <br />
                </ItemTemplate>
            </asp:Repeater>
            <h2>Details:</h2>
            
            <asp:FormView runat="server" ID="FormView" ItemType="EmployeesSinglePage.Employee">
                <ItemTemplate>
                    FirstName : <%# Item.FirstName %><br />
                    LastName : <%# Item.LastName %><br />
                    Title : <%# Item.Title %><br />
                    BirthDate : <%# Item.BirthDate %><br />
                    HireDate : <%# Item.HireDate %><br />
                    Address : <%# Item.Address %><br />
                    City : <%# Item.City %><br />
                    Region : <%# Item.Region %><br />
                    PostalCode : <%# Item.PostalCode %><br />
                    Country : <%# Item.Country %><br />
                    HomePhone : <%# Item.HomePhone %><br />
                    Extension : <%# Item.Extension %><br />
                    Notes : <%# Item.Notes %><br />
                    PhotoPath : <%# Item.PhotoPath %><br />
                </ItemTemplate>
            </asp:FormView>
        </div>
    </form>
</body>
</html>
