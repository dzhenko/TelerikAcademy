<%@ Page Title="Edit Book" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditBooks.aspx.cs" Inherits="LibrarySystem.Admin.EditBooks" %>

<asp:Content ID="ContentEditBooks" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h1><%: this.Title %></h1>
    </div>

    <asp:ListView runat="server" ID="ListViewBooks" DataKeyNames="Id" ItemType="LibrarySystem.Models.Book"
        SelectMethod="ListViewBooks_GetData" DeleteMethod="ListViewBooks_DeleteItem" UpdateMethod="ListViewBooks_UpdateItem">
        <LayoutTemplate>
            <table class="table table-striped table-hover">
                <thead class="lead">
                    <tr>
                        <th>
                            <asp:LinkButton runat="server" ID="SortTitle" CommandName="Sort"
                                CommandArgument="Title"  Text="Title"></asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton runat="server" ID="SortAuthor" CommandName="Sort"
                                CommandArgument="Author"  Text="Author"></asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton runat="server" ID="SortISBN" CommandName="Sort"
                                CommandArgument="ISBN"  Text="ISBN"></asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton runat="server" ID="SortWebSite" CommandName="Sort"
                                CommandArgument="WebSite"  Text="WebSite"></asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton runat="server" ID="Category" CommandName="Sort"
                                CommandArgument="Category" OnCommand="Sort_Command" Text="Category"></asp:LinkButton>
                        </th>
                        <th runat="server" id="DescrptionHiddenHeader" visible="false">Description</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                </tbody>
            </table>
            <asp:DataPager runat="server" PageSize="3" PagedControlID="ListViewBooks">
                <Fields>
                    <asp:NumericPagerField ButtonType="Button" NumericButtonCssClass="btn btn-info btn-sm" CurrentPageLabelCssClass="btn btn-success btn-sm" />
                </Fields>
            </asp:DataPager>
        </LayoutTemplate>
        <ItemTemplate>
            <tr class="info">
                <td><%#: Item.Title.Length > 20 ? string.Format("{0}...",Item.Title.Substring(0, 20)) : Item.Title %></td>
                <td><%#: Item.Author.Length > 20 ? string.Format("{0}...",Item.Author.Substring(0, 20)) : Item.Author %></td>
                <td><%#: string.IsNullOrEmpty(Item.ISBN) ? "-" : Item.ISBN.Length > 20 ? string.Format("{0}...",Item.ISBN.Substring(0, 20)) : Item.ISBN %></td>
                <td><a href="<%#: Item.WebSite %>"><%#: string.IsNullOrEmpty(Item.WebSite) ? "-" : Item.WebSite.Length > 20 ? string.Format("{0}...",Item.WebSite.Substring(0, 20)) : Item.WebSite  %></a></td>
                <td><%#: Item.Category.Name.Length > 20 ? string.Format("{0}...",Item.Category.Name.Substring(0, 20)) : Item.Category.Name  %></td>
                <td>
                    <asp:LinkButton runat="server" OnClick="ShowAdditionalTableHeaders" ID="LinkButtonEdit" CssClass="btn btn-sm btn-info" Text="Edit" CommandName="Edit" />
                    <asp:LinkButton runat="server" ID="LinkButtonDelete" CssClass="btn btn-sm btn-danger" Text="Delete" CommandName="Delete" />
                </td>
            </tr>
        </ItemTemplate>
        <EditItemTemplate>
            <td>
                <asp:TextBox runat="server" ID="TextBoxEditTitle" CssClass="form-control" Text="<%#: BindItem.Title %>"></asp:TextBox>

            </td>
            <td>
                <asp:TextBox runat="server" ID="TextBoxEditAuthor" CssClass="form-control" Text="<%#: BindItem.Author %>"></asp:TextBox>

            </td>
            <td>
                <asp:TextBox runat="server" ID="TextBoxEditISBN" CssClass="form-control" Text="<%#: BindItem.ISBN %>"></asp:TextBox>

            </td>
            <td>
                <asp:TextBox runat="server" ID="TextBoxEditWebSite" CssClass="form-control" Text="<%#: BindItem.WebSite %>"></asp:TextBox>

            </td>
            <td>
                <asp:DropDownList runat="server" ID="DDLCategory" ItemType="LibrarySystem.Models.Category"
                    DataValueField="Id" DataTextField="Name" SelectedValue="<%#: BindItem.CategoryID %>"
                    SelectMethod="DDLCategory_GetData" CssClass="form-control">
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox runat="server" ID="TextBoxEditDescription" CssClass="form-control" Rows="3" Text="<%#: BindItem.Description %>" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>
                <asp:LinkButton runat="server" OnClick="HideAdditionalTableHeaders" ID="LinkButtonEdit" CssClass="form-control btn btn-sm btn-success" Text="Save" CommandName="Update" />
                <asp:LinkButton runat="server" OnClick="HideAdditionalTableHeaders" ID="LinkButtonDelete" CssClass="form-control btn btn-sm btn-info" Text="Cancel" CommandName="Cancel" />
            </td>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <i>No books added yet.</i>
        </EmptyDataTemplate>
    </asp:ListView>
    <hr />
    <asp:UpdatePanel runat="server" ID="UpdatePanelInsert">
        <ContentTemplate>
            <asp:Button runat="server" ID="InsertNewBookBtn" OnClick="InsertNewBookBtn_Click" CssClass="pull-right btn btn-md btn-success" Text="Create New Book" />
            <div runat="server" id="CreateBookWell" visible="false" class="well">
                <fieldset>
                    <legend>Create New Book</legend>

                    <div class="form-group">
                        <label for="NewBookTitle" class="col-lg-2 control-label">Title</label>
                        <div class="col-lg-10">
                            <asp:TextBox runat="server" ID="NewBookTitle" CssClass="form-control" placeholder="Title"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="NewBookAuthor" class="col-lg-2 control-label">Author</label>
                        <div class="col-lg-10">
                            <asp:TextBox runat="server" ID="NewBookAuthor" CssClass="form-control" placeholder="Author"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="NewBookISBN" class="col-lg-2 control-label">ISBN</label>
                        <div class="col-lg-10">
                            <asp:TextBox runat="server" ID="NewBookISBN" CssClass="form-control" placeholder="ISBN"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="NewBookWebSite" class="col-lg-2 control-label">Web Site</label>
                        <div class="col-lg-10">
                            <asp:TextBox runat="server" ID="NewBookWebSite" CssClass="form-control" placeholder="Web Site"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="NewBookDescription" class="col-lg-2 control-label">Description</label>
                        <div class="col-lg-10">
                            <asp:TextBox runat="server" ID="NewBookDescription" Rows="3" CssClass="form-control" placeholder="Description"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="select" class="col-lg-2 control-label">Category</label>
                        <div class="col-lg-3">
                            <asp:DropDownList runat="server" ID="NewBookCategory" ItemType="LibrarySystem.Models.Category"
                                DataValueField="Id" DataTextField="Name"
                                SelectMethod="DDLCategory_GetData" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-lg-10 col-lg-offset-2">
                            <asp:Button runat="server" ID="CreateNewBook" OnClick="CreateNewBook_Click" Text="Create" CssClass="btn btn-success btn-md" />
                            <asp:Button runat="server" ID="CancelNewBook" OnClick="CancelNewBook_Click" Text="Cancel" CssClass="btn btn-info btn-md" />
                        </div>
                    </div>
                </fieldset>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="InsertNewBookBtn" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <br />
</asp:Content>
