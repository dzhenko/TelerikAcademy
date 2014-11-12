<%@ Page Title="Books" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="LibrarySystem.Books" %>

<asp:Content ID="ContentBooks" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h1><%: this.Title %></h1>
    </div>

    <asp:ListView runat="server" ID="ListViewCategories" ItemType="LibrarySystem.Models.Category"
        SelectMethod="ListViewCategories_GetData" GroupItemCount="3">
        <ItemTemplate>
            <div class="col-md-4">
                <h2><%#: Item.Name %></h2>
                <asp:ListView runat="server" ID="ListViewBooks" ItemType="LibrarySystem.Models.Book" DataSource="<%# Item.Books %>">
                    <LayoutTemplate>
                        <ul>
                            <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                        </ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <li>
                            <a runat="server" href='<%#: string.Format("~/BookDetails?id={0}", Item.Id) %>'>
                                <%#: Item.Title %> by 
                            <i>
                                <%#: Item.Author %>
                            </i>
                            </a>
                        </li>
                    </ItemTemplate>

                    <EmptyDataTemplate>
                        <i>No books in this category.</i>
                    </EmptyDataTemplate>
                </asp:ListView>
            </div>
        </ItemTemplate>

        <EmptyDataTemplate>
            <i>No categories yet.</i>
        </EmptyDataTemplate>

        <GroupTemplate>
            <div class="row">
                <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
            </div>
        </GroupTemplate>
    </asp:ListView>

</asp:Content>
