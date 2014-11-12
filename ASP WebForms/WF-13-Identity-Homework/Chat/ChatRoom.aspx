<%@ Page Title="Chat" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChatRoom.aspx.cs" Inherits="Chat.ChatRoom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <asp:TextBox runat="server" ID="ChatMsg" placeholder="Write your message..."></asp:TextBox>
    <asp:Button runat="server" ID="SendMsgBtn" Text="Send" OnClick="SendMsgBtn_Click" />
    <hr/>
    
    <asp:ListBox runat="server" Width="450" Height="250" SelectMethod="Messages_GetAll" ItemType="Chat.Models.Message" DataValueField="Id" DataTextField="Text"></asp:ListBox>
</asp:Content>
