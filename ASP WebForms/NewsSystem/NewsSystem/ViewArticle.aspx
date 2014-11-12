<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewArticle.aspx.cs" Inherits="NewsSystem.ViewArticle" %>

<%@ Register TagPrefix="uc" TagName="LikeControl" Src="~/Controls/LikeControl.ascx" %>

<asp:Content ID="ContentViewArticle" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ID="FormViewArticle" ItemType="NewsSystem.Models.Article" SelectMethod="FormViewBook_GetItem">
        <ItemTemplate>
            <div class="row">
                <div class="col-md-1">
                    <uc:LikeControl runat="server" ArticleId="<%# Item.Id %>" ID="LikeControl"
                        LikesCount="<%# GetLikesCount(Item) %>"
                        UserVote="<%# GetUserVote(Item) %>"
                        OnButtonClicked="LikeControl_ButtonClicked"></uc:LikeControl>
                </div>
                <div class="col-md-10 col-md-offset-1">
                    <h2><%#: Item.Title %> <small>Category: <%#: Item.Category.Name %></small></h2>
                    <p><%#: Item.Content %></p>
                </div>
            </div>
            <br />
            <p class="row">
                <span class="pull-left">Author: <%#: Item.Author.UserName %></span>
                <span class="pull-right"><%#: Item.DateCreated %></span>
            </p>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
