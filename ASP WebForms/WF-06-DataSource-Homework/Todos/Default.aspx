<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Todos.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Categories</h1>
            <asp:Literal runat="server" Text="Insert Category:"></asp:Literal>
            <asp:TextBox ID="InsertCategoryNameTextBox" runat="server" placeholder="Name"></asp:TextBox>
            <asp:Button runat="server" OnClick="InsertCategoryButton_Click" Text="Insert" />
            <hr />
            <asp:ListView runat="server" ID="CategoriesListView" ItemType="Todos.Data.Models.Category" DataKeyNames="Id"
                SelectMethod="CategoriesListView_GetData" InsertMethod="CategoriesListView_InsertItem"
                UpdateMethod="CategoriesListView_UpdateItem" DeleteMethod="CategoriesListView_DeleteItem">
                <ItemTemplate>
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <asp:Literal runat="server" Text="<%#: Item.Name %>"></asp:Literal>
                </ItemTemplate>
                <ItemSeparatorTemplate>
                    <hr />
                </ItemSeparatorTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="EditCategoryNameTextBox" runat="server" Text="<%# BindItem.Name %>"></asp:TextBox>
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                </EditItemTemplate>
                <LayoutTemplate>
                    <ul id="itemPlaceholderContainer" runat="server" style="font-family: Verdana, Arial, Helvetica, sans-serif;">
                        <li runat="server" id="itemPlaceholder" />
                    </ul>
                    <div style="text-align: center; background-color: #5D7B9D; font-family: Verdana, Arial, Helvetica, sans-serif; color: #FFFFFF;">
                        <asp:DataPager ID="DataPager1" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                            </Fields>
                        </asp:DataPager>
                    </div>
                </LayoutTemplate>
            </asp:ListView>
            
            <h1>Todos</h1>
            <asp:Literal runat="server" Text="Insert Todo:"></asp:Literal>
            <asp:TextBox ID="InsertTodoNameTextBox" runat="server" placeholder="Name"></asp:TextBox>
            <asp:TextBox ID="InsertTodoBodyTextBox" runat="server" placeholder="Body"></asp:TextBox>
            <asp:DropDownList runat="server" ID="InsertTodoCategory" DataValueField="Id" ItemType="Todos.Data.Models.Category" DataTextField="Name" SelectMethod="CategoriesListView_GetData"></asp:DropDownList>
            <asp:Button runat="server" OnClick="InsertTodoButton_Click" Text="Insert" />
            <hr />
            <asp:ListView runat="server" ID="TodosListView" ItemType="Todos.Data.Models.Todo" DataKeyNames="Id"
                SelectMethod="TodosListView_GetData" InsertMethod="TodosListView_InsertItem"
                UpdateMethod="TodosListView_UpdateItem" DeleteMethod="TodosListView_DeleteItem">
                <ItemTemplate>
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <strong><asp:Literal runat="server" Text="<%#: Item.Title %>"></asp:Literal></strong>
                    <asp:Literal runat="server" Text="<%#: Item.Body %>"></asp:Literal>
                    <strong><asp:Literal runat="server" Text="<%#: Item.Category.Name %>"></asp:Literal></strong>
                    <small><asp:Literal runat="server" Text="<%#: Item.Changed %>"></asp:Literal></small>
                </ItemTemplate>
                <ItemSeparatorTemplate>
                    <hr />
                </ItemSeparatorTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="EditCategoryNameTextBox" runat="server" Text="<%# BindItem.Name %>"></asp:TextBox>
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                </EditItemTemplate>
                <LayoutTemplate>
                    <ul id="itemPlaceholderContainer" runat="server" style="font-family: Verdana, Arial, Helvetica, sans-serif;">
                        <li runat="server" id="itemPlaceholder" />
                    </ul>
                    <div style="text-align: center; background-color: #5D7B9D; font-family: Verdana, Arial, Helvetica, sans-serif; color: #FFFFFF;">
                        <asp:DataPager ID="DataPager1" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                            </Fields>
                        </asp:DataPager>
                    </div>
                </LayoutTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>
