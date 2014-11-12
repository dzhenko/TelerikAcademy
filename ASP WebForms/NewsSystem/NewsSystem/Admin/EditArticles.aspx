<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditArticles.aspx.cs" Inherits="NewsSystem.Admin.EditArticles" %>

<asp:Content ID="ContentEditArticles" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView runat="server" ID="ListViewArticles" ItemType="NewsSystem.Models.Article" DataKeyNames="Id"
        SelectMethod="ListViewArticles_GetData" UpdateMethod="ListViewArticles_UpdateItem"
        DeleteMethod="ListViewArticles_DeleteItem" OnSorting="ListViewArticles_Sorting">
        <LayoutTemplate>
            <div class="row">
                <asp:LinkButton runat="server" ID="SortTitle" CssClass="col-md-2 btn btn-default"
                    CommandName="Sort" CommandArgument="Title" Text="Sorty by Title"></asp:LinkButton>
                <asp:LinkButton runat="server" ID="SortDate" CssClass="col-md-2 btn btn-default"
                    CommandName="Sort" CommandArgument="DateCreated" Text="Sorty by Date"></asp:LinkButton>
                <asp:LinkButton runat="server" ID="SortCategory" CssClass="col-md-2 btn btn-default"
                    CommandName="Sort" CommandArgument="Category" Text="Sorty by Category"></asp:LinkButton>
                <asp:LinkButton runat="server" ID="SortLikes" CssClass="col-md-2 btn btn-default"
                    CommandName="Sort" CommandArgument="Likes" Text="Sorty by Likes"></asp:LinkButton>
            </div>
            <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
            <div class="row">
                <asp:DataPager runat="server" PageSize="5" PagedControlID="ListViewArticles">
                    <Fields>
                        <asp:NextPreviousPagerField ShowNextPageButton="false" />
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ShowPreviousPageButton="false" />
                    </Fields>
                </asp:DataPager>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="row">
                <h3><%#: Item.Title %>
                    <asp:LinkButton runat="server" ID="LinkButtonEdit" CssClass="btn btn-info" CommandName="Edit" Text="Edit"></asp:LinkButton>
                    <asp:LinkButton runat="server" ID="LinkButtonDelete" CssClass="btn btn-danger" CommandName="Delete" Text="Delete"></asp:LinkButton>
                </h3>
                <p>Category: <%#: Item.Category.Name %></p>
                <p>
                    <%#: Item.Content.Length > 300 ? string.Format("{0}...", Item.Content.Substring(0, 300)) : Item.Content %>
                </p>
                <p>Likes count: <%#: Item.Likes.Count() %></p>
                <div>
                    <i>by <%#: Item.Author.UserName %></i>
                    <i>created on: <%#: Item.DateCreated %></i>
                </div>
            </div>
        </ItemTemplate>
        <EditItemTemplate>
            <div class="row">
                <h3>
                    <span class="col-md-3">
                        <asp:TextBox runat="server" CssClass="form-control" ID="EditArticleTitle" Text="<%#: BindItem.Title %>"></asp:TextBox>
                        <asp:RequiredFieldValidator
                            ID="RequiredFieldEditValidatorTitle"
                            runat="server" ForeColor="Red" Display="Dynamic"
                            ErrorMessage="Title is required"
                            ControlToValidate="EditArticleTitle" EnableClientScript="false">
                        </asp:RequiredFieldValidator>
                    </span>
                    <asp:LinkButton runat="server" ID="LinkButtonEdit" CssClass="btn btn-success" CommandName="Update" Text="Save"></asp:LinkButton>
                    <asp:LinkButton runat="server" ID="LinkButtonDelete" CssClass="btn btn-danger" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                </h3>
                <p class="col-md-3">
                    <asp:DropDownList runat="server" ID="EditArticleCategory" ItemType="NewsSystem.Models.Category"
                        DataValueField="Id" DataTextField="Name" SelectedValue="<%#: BindItem.CategoryId %>"
                        SelectMethod="EditArticleCategory_GetData" CssClass="form-control">
                    </asp:DropDownList>
                </p>
                <p>
                    <asp:TextBox runat="server" ID="EditArticleContent" Text="<%#: BindItem.Content %>"
                        TextMode="MultiLine" CssClass="form-control" Rows="5"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldEditValidatorContent"
                        runat="server" ForeColor="Red" Display="Dynamic"
                        ErrorMessage="Content is required"
                        ControlToValidate="EditArticleContent" EnableClientScript="false">
                    </asp:RequiredFieldValidator>
                </p>
                <div>
                    <i>by <%#: Item.Author.UserName %></i>
                    <i>created on: <%#: Item.DateCreated %></i>
                </div>
            </div>
        </EditItemTemplate>
        <EmptyDataTemplate>
            No Categories.
        </EmptyDataTemplate>
    </asp:ListView>
    <hr />
    <asp:UpdatePanel runat="server" ID="UpdatePanelInsert">
        <ContentTemplate>
            <asp:Button runat="server" ID="InsertNewArticleBtn" OnClick="InsertNewArticleBtn_Click" CssClass="pull-right btn btn-md btn-info" Text="Insert New Article" />
            <div runat="server" id="CreateArticleHolder" visible="false">
                <fieldset>
                    <div class="form-group">
                        <br />
                        <label for="NewArticleTitle" class="col-lg-2 control-label">Title</label>
                        <div class="col-lg-10">
                            <asp:TextBox runat="server" ID="NewArticleTitle" CssClass="form-control" placeholder="Title"></asp:TextBox>
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldInsertValidatorTitle"
                                runat="server" ForeColor="Red" Display="Dynamic"
                                ErrorMessage="Title is required"
                                ControlToValidate="NewArticleTitle" EnableClientScript="false">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />
                    <div class="form-group">
                        <br />
                        <label for="select" class="col-lg-2 control-label">Category</label>
                        <div class="col-lg-3">
                            <asp:DropDownList runat="server" ID="NewArticleCategory" ItemType="NewsSystem.Models.Category"
                                DataValueField="Id" DataTextField="Name"
                                SelectMethod="EditArticleCategory_GetData" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <br />
                        <label for="NewArticleContent" class="col-lg-2 control-label">Content</label>
                        <div class="col-lg-4">
                            <asp:TextBox runat="server" ID="NewArticleContent" TextMode="MultiLine" Rows="5" CssClass="form-control" placeholder="Content"></asp:TextBox>
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldInsertValidatorContent"
                                runat="server" ForeColor="Red" Display="Dynamic"
                                ErrorMessage="Content is required"
                                ControlToValidate="NewArticleContent" EnableClientScript="false">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <br />
                        <div class="col-lg-10 col-md-offset-2">
                            <asp:Button runat="server" ID="CreateNewArticle" OnClick="CreateNewArticle_Click" Text="Insert" CssClass="btn btn-success btn-md" />
                            <asp:Button runat="server" ID="CancelNewArticle" OnClick="CancelNewArticle_Click" Text="Cancel" CssClass="btn btn-danger btn-md" />
                        </div>
                    </div>
                </fieldset>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="InsertNewArticleBtn" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <br />
</asp:Content>
