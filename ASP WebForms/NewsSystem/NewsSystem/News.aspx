<%@ Page Title="News" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="NewsSystem.News" %>
<asp:Content ID="ContentNews" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Title %></h1>

    <h2>Most popular articles</h2>

    <asp:ListView runat="server" ID="ListViewMostBooks" ItemType="NewsSystem.Models.Article" SelectMethod="ListViewMostBooks_GetData">
        <ItemTemplate>
            <div class="row">
                <h3>
                    <a href='<%#: string.Format("ViewArticle?id={0}", Item.Id) %>'><%#: Item.Title %></a> 
                    <small><%#: Item.Category.Name %></small>
                </h3>
                <p>
                    <%#: Item.Content.Length > 300 ? string.Format("{0}...", Item.Content.Substring(0, 300)) : Item.Content %>
                </p>
                <p>Likes: <%# Item.Likes.Count %></p>
                <div>
                    <i>by <%#: Item.Author.UserName %></i>
                    <i>created on: <%#: Item.DateCreated %></i>
                </div>
            </div>
        </ItemTemplate>
        <EmptyDataTemplate>
            No articles.
        </EmptyDataTemplate>
    </asp:ListView>

    <h2>All categories</h2>

    <asp:ListView runat="server" ID="ListViewCategories" ItemType="NewsSystem.Models.Category" 
        SelectMethod="ListViewCategories_GetData" GroupItemCount="2">
        <EmptyDataTemplate>
            No categories.
        </EmptyDataTemplate>
        <GroupTemplate>
            <div class="row">
                <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
            </div>
        </GroupTemplate>
        <ItemTemplate>
            <div class="col-md-6">
                <h3><%#: Item.Name %></h3>
                <asp:ListView runat="server" ItemType="NewsSystem.Models.Article" 
                    DataSource="<%# Item.Articles.OrderByDescending(a => a.DateCreated).Take(3) %>">
                    <EmptyDataTemplate>
                        No articles.
                    </EmptyDataTemplate>
                    <LayoutTemplate>
                        <ul>
                            <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                        </ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <li>
                            <a href='<%#: string.Format("ViewArticle?id={0}", Item.Id) %>'>
                                <strong><%#: Item.Title %></strong>
                                <i> by <%#: Item.Author.UserName %></i>
                            </a>
                            </a>
                        </li>
                    </ItemTemplate>
                </asp:ListView>                   
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
