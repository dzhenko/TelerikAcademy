<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Northwind.Default" %>
<%@ Register Src="~/HoverDetails.ascx" TagPrefix="uc" TagName="HoverDetails" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Hover on last name to see the magic</h1>
    <asp:EntityDataSource runat="server" ID="EntityDataSource" 
        ConnectionString="name=NorthwindEntities" 
        DefaultContainerName="NorthwindEntities" 
        EnableFlattening="False" EntitySetName="Employees">

    </asp:EntityDataSource>
    <form id="form1" runat="server">
    <div>
        <asp:ListView runat="server" ID="ListView" DataSourceID="EntityDataSource" 
            DataKeyNames="EmployeeID" >
            <LayoutTemplate>
                <table runat="server" id="employeesTable">
                    <tr runat="server" style="background-color: #E0FFFF;color: #333333;">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                                <tr runat="server" style="">
                                    <th runat="server" style="display:none">Id</th>
                                    <th runat="server">LastName</th>
                                    <th runat="server">FirstName</th>
                                    <th runat="server">City</th>
                                    <th runat="server">Country</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF">
                            <asp:DataPager ID="DataPager1" runat="server" PageSize="5">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                    <asp:NumericPagerField />
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr style="background-color: #E0FFFF;color: #333333;">
                    <td style="display:none" >
                        <asp:Label ID="HiddenId" runat="server" Text='<%# Eval("EmployeeId") %>' />
                    </td>
                    <td class="HoveredItem">
                        <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CityLabel" runat="server" Text='<%# Eval("City") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CountryLabel" runat="server" Text='<%# Eval("Country") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr style="background-color: #FFFFFF;color: #284775;">
                    <td style="display:none" >
                        <asp:Label ID="HiddenId" runat="server" Text='<%# Eval("EmployeeId") %>' />
                    </td>
                    <td class="HoveredItem" >
                        <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CityLabel" runat="server" Text='<%# Eval("City") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CountryLabel" runat="server" Text='<%# Eval("Country") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="">
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
        </asp:ListView>
        <uc:HoverDetails ID="HoverDetails" runat="server"></uc:HoverDetails>
    </div>
    </form>
</body>
</html>
