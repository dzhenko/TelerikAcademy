<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="LibrarySystem.BookDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h1><%: this.Title %></h1>
    </div>

    <asp:FormView runat="server" ItemType="LibrarySystem.Models.Book" ID="FormViewBook" SelectMethod="FormViewBook_GetItem">
        <ItemTemplate>
            <div class="row form-group">
                <label class="col-md-2 control-label">Title</label>
                <div class="col-md-10">
                    <%#: Item.Title %>
                </div>
            </div>
        </ItemTemplate>
        <FooterTemplate>
            <br />
        </FooterTemplate>
    </asp:FormView>
</asp:Content>
