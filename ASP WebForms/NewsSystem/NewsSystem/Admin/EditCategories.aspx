<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCategories.aspx.cs" Inherits="NewsSystem.Admin.EditCategories" %>

<asp:Content ID="ContentEditArticles" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView runat="server" ID="ListViewCategories" DataKeyNames="Id" ItemType="NewsSystem.Models.Category"
        SelectMethod="ListViewCategories_GetData" DeleteMethod="ListViewCategories_DeleteItem"
        UpdateMethod="ListViewCategories_UpdateItem"
        InsertMethod="ListViewCategories_InsertItem" InsertItemPosition="LastItem">
        <LayoutTemplate>
            <div class="row">
                <asp:LinkButton runat="server" ID="SortName" CssClass="btn btn-default"
                    CommandName="Sort" CommandArgument="Name" Text="Category Name"></asp:LinkButton>
            </div>
            <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
            <div class="row">
                <asp:DataPager runat="server" PageSize="5" PagedControlID="ListViewCategories">
                    <Fields>
                        <asp:NextPreviousPagerField ShowNextPageButton="false" />
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ShowPreviousPageButton="false" />
                    </Fields>
                </asp:DataPager>
            </div>
        </LayoutTemplate>
        <EmptyDataTemplate>
            No Categories
        </EmptyDataTemplate>
        <ItemTemplate>
            <div class="row">
                <div class="col-md-3"><%#: Item.Name %></div>
                <asp:LinkButton runat="server" ID="LinkButtonEdit" CssClass="btn btn-info" CommandName="Edit" Text="Edit"></asp:LinkButton>
                <asp:LinkButton runat="server" ID="LinkButtonDelete" CssClass="btn btn-danger" CommandName="Delete" Text="Delete"></asp:LinkButton>
            </div>
        </ItemTemplate>
        <EditItemTemplate>
            <div class="row">
                <div class="col-md-3">
                    <asp:TextBox runat="server" CssClass="form-control" ID="EditCategoryTitle" Text="<%#: BindItem.Name %>"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldEditValidatorName" ValidationGroup="Edit"
                        runat="server" ForeColor="Red" Display="Dynamic"
                        ErrorMessage="Name is required"
                        ControlToValidate="EditCategoryTitle" EnableClientScript="false">
                    </asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomNameFieldEditValidatorName"
                        runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="Edit"
                        ErrorMessage="Category with this name already exists"
                        ControlToValidate="EditCategoryTitle" EnableClientScript="false"
                        OnServerValidate="CustomNameFieldInsertValidatorName_ServerValidate">
                    </asp:CustomValidator>
                </div>
                <asp:LinkButton runat="server" ID="LinkButtonEdit" CssClass="btn btn-success" CommandName="Update" Text="Save"></asp:LinkButton>
                <asp:LinkButton runat="server" ID="LinkButtonDelete" CssClass="btn btn-danger" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
            </div>
        </EditItemTemplate>
        <InsertItemTemplate>
            <div class="row">
                <div class="col-md-3">
                    <asp:TextBox runat="server" CssClass="form-control" ID="InsertCategoryTitle" Text="<%#: BindItem.Name %>"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldInsertValidatorName" ValidationGroup="Insert"
                        runat="server" ForeColor="Red" Display="Dynamic" 
                        ErrorMessage="Name is required"
                        ControlToValidate="InsertCategoryTitle" EnableClientScript="false">
                    </asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomNameFieldInsertValidatorName"
                        runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="Insert"
                        ErrorMessage="Category with this name already exists"
                        ControlToValidate="InsertCategoryTitle" EnableClientScript="false"
                        OnServerValidate="CustomNameFieldInsertValidatorName_ServerValidate">
                    </asp:CustomValidator>
                </div>
                <asp:LinkButton runat="server" ID="LinkButtonEdit" CssClass="btn btn-info" CommandName="Insert" Text="Save"></asp:LinkButton>
                <asp:LinkButton runat="server" ID="LinkButtonDelete" CssClass="btn btn-danger" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
            </div>
        </InsertItemTemplate>
    </asp:ListView>
</asp:Content>
