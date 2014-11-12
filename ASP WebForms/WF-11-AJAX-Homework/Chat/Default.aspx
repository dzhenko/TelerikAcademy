<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Chat.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <asp:TextBox ID="MessageText" runat="server" placeholder="Enter Message"></asp:TextBox>
            <asp:Button ID="MessageButton" runat="server" OnClick="MessageButton_Click" Text="Send" />
            <hr />
            <h2>Last 100 messages:</h2>
            <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:ListView SelectMethod="Messages_GetData" runat="server" ItemType="Chat.Data.Models.Message">
                        <ItemTemplate>
                            <%# Item.Text %> written at <%# Item.Date.ToString() %>
                        </ItemTemplate>
                        <ItemSeparatorTemplate>
                            <br />
                        </ItemSeparatorTemplate>
                    </asp:ListView>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Timer" EventName="Tick" />
                </Triggers>
            </asp:UpdatePanel>
            <asp:Timer ID="Timer" runat="server" Interval="500" OnTick="Timer_Tick"></asp:Timer>
        </div>
    </form>
</body>
</html>
