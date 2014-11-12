<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AllEmployeesRepeater.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <asp:EntityDataSource runat="server" ID="AllEmployeesDataSource" EnableFlattening="False" ConnectionString="name=NorthwindEntities" DefaultContainerName="NorthwindEntities" EntitySetName="Employees"></asp:EntityDataSource>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater runat="server" DataSourceID="AllEmployeesDataSource" ItemType="AllEmployeesRepeater.Employee">
                <HeaderTemplate>
                    <table border="1">
                        <thead>
                            <tr>
                                <th>FirstName</th>
                                <th>LastName</th>
                                <th>Title</th>
                                <th>BirthDate</th>
                                <th>HireDate</th>
                                <th>Address</th>
                                <th>City</th>
                                <th>Region</th>
                                <th>PostalCode</th>
                                <th>Country</th>
                                <th>HomePhone</th>
                                <th>Extension</th>
                                <th>PhotoPath</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Item.FirstName %></td>
                        <td><%# Item.LastName %></td>
                        <td><%# Item.Title %></td>
                        <td><%# Item.BirthDate %></td>
                        <td><%# Item.HireDate %></td>
                        <td><%# Item.Address %></td>
                        <td><%# Item.City %></td>
                        <td><%# Item.Region %></td>
                        <td><%# Item.PostalCode %></td>
                        <td><%# Item.Country %></td>
                        <td><%# Item.HomePhone %></td>
                        <td><%# Item.Extension %></td>
                        <td><%# Item.PhotoPath %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
            </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
