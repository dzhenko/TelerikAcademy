<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PhotoAlbum.Default" EnableEventValidation="true" %>

<%@ Register Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="ajaxtoolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .background {
            box-shadow:inset
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ajaxToolkit:ToolkitScriptManager runat="Server" />
            <ajaxToolkit:ModalPopupExtender ID="MPE" runat="server"
                TargetControlID="PictureView"
                PopupControlID="ShowMWBtn"
                BackgroundCssClass="background"
                CancelControlID="CloseBtn"
                DropShadow="true"/>

            <asp:Button ID="ShowMWBtn" runat="server" visible="false" Text="C"/>


            <asp:Repeater runat="server" ID="ImagesRepeater">
                <ItemTemplate>
                    <asp:ImageButton Id="ViewBtn" CommandArgument="<%# Container.ItemIndex + 1 %>" OnCommand="ViewBtn_Command" 
                        ImageUrl='<%# string.Format("images/{0}.jpg",Container.ItemIndex + 1) %>' Width="200" Height="200" runat="server" />
                </ItemTemplate>
            </asp:Repeater>

            <asp:Panel runat="server" ID="PictureView" Visible="false">
                <asp:Button ID="PrevImage" runat="server" Text="Prev" OnClick="PrevImage_Click"/>
                <asp:Button ID="NextImage" runat="server" Text="Next" OnClick="NextImage_Click"/>
                <br />

                <asp:Image ID="PictureUrl" Width="600" Height="500" runat="server" ImageUrl="~/images/1.jpg"/>
                <br />

                <asp:Button ID="CloseBtn" runat="server" Text="Close" OnClick="CloseBtn_Click"/>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
