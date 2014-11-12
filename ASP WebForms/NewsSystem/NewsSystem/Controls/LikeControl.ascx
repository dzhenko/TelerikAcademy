<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LikeControl.ascx.cs" Inherits="NewsSystem.Controls.LikeControl" %>

<div class="like-control col-md-1" runat="server" id="LikePanelHolder">
    <div>Likes</div>
    <asp:UpdatePanel runat="server" ID="UpdatePanelLike" ChildrenAsTriggers="true">
        <ContentTemplate>
            <asp:LinkButton runat="server" CommandArgument="<%#: this.ArticleId %>" Id="ButtonLike"
                CommandName="true" OnCommand="Vote_Command" CssClass="btn btn-default glyphicon glyphicon-chevron-up"></asp:LinkButton>
            <asp:Label runat="server" ID="LableLikesCount" CssClass="like-value"></asp:Label>
            <asp:LinkButton runat="server" CommandArgument="<%#: this.ArticleId %>" Id="ButtonHate"
                CommandName="false" OnCommand="Vote_Command" CssClass="btn btn-default glyphicon glyphicon-chevron-down"></asp:LinkButton>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
