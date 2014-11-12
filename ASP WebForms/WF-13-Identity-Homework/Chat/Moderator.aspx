<%@ Page Title="Moderator Area" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Moderator.aspx.cs" Inherits="Chat.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Moderators can post and edit the content.</h3>

    <asp:ListView ID="ListView" runat="server" DataKeyNames="Id" SelectMethod="ListView_GetData" UpdateMethod="ListView_UpdateItem" ItemType="Chat.Models.Message">
        <ItemTemplate>
            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
            <%# Item.Text %>
        </ItemTemplate>
        <ItemSeparatorTemplate>
            <br />
        </ItemSeparatorTemplate>
        <EditItemTemplate>
            <asp:TextBox runat="server" ID="editBox" Text="<%#: BindItem.Text %>"></asp:TextBox>
            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>
    </asp:ListView>
</asp:Content>
