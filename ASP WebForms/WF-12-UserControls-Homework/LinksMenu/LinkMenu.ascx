<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LinkMenu.ascx.cs" Inherits="LinksMenu.LinkMenu" %>


<asp:DataList runat="server" ID="DataList">
    <ItemTemplate>
        <asp:HyperLink runat="server" NavigateUrl='<%# Eval("Url") %>' Text='<%# Eval("Title") %>'></asp:HyperLink>
    </ItemTemplate>
</asp:DataList>