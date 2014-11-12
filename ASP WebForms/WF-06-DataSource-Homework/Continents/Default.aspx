<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Continents.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <%--Run the db script to create the DB First - ContinentsDb.sql--%>
    <asp:EntityDataSource runat="server" ID="ContinentsDataSource"
        ConnectionString="name=ContinentsEntities" DefaultContainerName="ContinentsEntities"
        EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True"
        EntitySetName="Continents">
    </asp:EntityDataSource>

    <asp:EntityDataSource runat="server" ID="CoutriesDataSource"
        ConnectionString="name=ContinentsEntities" DefaultContainerName="ContinentsEntities"
        EnableDelete="True" EnableFlattening="False" EnableInsert="True" EnableUpdate="True"
        EntitySetName="Countries" Where="it.ContinentId=@ContId">
        <WhereParameters>
            <asp:ControlParameter ControlID="ListBoxContinents" Name="ContId" DefaultValue="1" DbType="Int32" />
        </WhereParameters>
    </asp:EntityDataSource>

    <asp:EntityDataSource runat="server" ID="TownsDataSource" ConnectionString="name=ContinentsEntities" 
        DefaultContainerName="ContinentsEntities" EnableDelete="True" EnableFlattening="False" 
        EnableInsert="True" EnableUpdate="True" EntitySetName="Towns" Where="it.CountryId=@CountrId">
        <WhereParameters>
            <asp:ControlParameter ControlID="CountriesGridView" Name="CountrId" DefaultValue="1" DbType="Int32" />
        </WhereParameters>
    </asp:EntityDataSource>
    <form id="form1" runat="server">
        <div>
            <h1>Continents</h1>
            <asp:ListBox ID="ListBoxContinents" runat="server"
                DataSourceID="ContinentsDataSource" 
                DataTextField="Name" DataValueField="Id"
                Rows="10" AutoPostBack="True"
                OnSelectedIndexChanged="ListBoxContinents_SelectedIndexChanged" />
            <br />
            <asp:TextBox ID="InsertContinetTb" runat="server"></asp:TextBox>
            <asp:Button ID="InsertContinentBtn" runat="server" OnClick="InsertContinentBtn_Click" Text="Insert" />
            <br />
            <asp:TextBox ID="UpdateContinetTb" runat="server"></asp:TextBox>
            <asp:Button ID="UpdateContinetBtn" runat="server" OnClick="UpdateContinetBtn_Click" Text="Update Selected" />
            <br />
            <asp:Button ID="DeleteContinetBtn" runat="server" OnClick="DeleteContinetBtn_Click" Text="Delete Selected" />

            <h2>Countries</h2>
            <asp:GridView runat="server" ID="CountriesGridView" DataSourceID="CoutriesDataSource"
                AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="Id">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                    <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Language" HeaderText="Language" SortExpression="Language" />
                    <asp:BoundField DataField="Population" HeaderText="Population" SortExpression="Population" />
                    <asp:BoundField DataField="ContinentId" HeaderText="ContinentId" SortExpression="ContinentId" />
                    <asp:TemplateField>
                        <HeaderTemplate>Flag</HeaderTemplate>
                        <ItemTemplate>
                            <img width="60" height="30" src='data:image/png;base64,<%# Convert.ToBase64String((byte[])Eval("FlagImage")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>

            <br />
            <asp:Button runat="server" ID="InsertCountryBtn" Text="Insert Country" OnClick="InsertCountryBtn_Click" />
            <asp:TextBox runat="server" ID="InsertedCountryName" placeholder="Name"></asp:TextBox>
            <asp:TextBox runat="server" ID="InsertedCountryLanguage" placeholder="Language"></asp:TextBox>
            <asp:TextBox runat="server" ID="InsertedCountryPopulation" placeholder="Population"></asp:TextBox>
            <asp:Literal runat="server" Text="Flag"></asp:Literal>
            <asp:FileUpload runat="server" ID="InsertedCountryFlag" />

            
            <h2>Cities</h2>
            <asp:ListView runat="server" DataSourceID="TownsDataSource" ID="TownsListView" 
                ItemType="Continents.Town" DataKeyNames="Id" InsertItemPosition="LastItem">
                <ItemTemplate>
                    <li style="background-color: #E0FFFF;color: #333333;">
                        Name:
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                        <br />
                        Population:
                        <asp:Label ID="PopulationLabel" runat="server" Text='<%# Eval("Population") %>' />
                        <br />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    </li>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <li style="background-color: #FFFFFF;color: #284775;">
                        Name:
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                        <br />
                        Population:
                        <asp:Label ID="PopulationLabel" runat="server" Text='<%# Eval("Population") %>' />
                        <br />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    </li>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <li style="background-color: #999999;">
                        Name:
                        <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                        <br />
                        Population:
                        <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                        <br />
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                    </li>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    No data was returned.
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <li style="">
                        CountryId:
                        <asp:Literal ID="CountryIdLiteral" runat="server" Text='<%# Bind("CountryId")%>' />
                        <br />
                        Name:
                        <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                        <br />
                        Population:
                        <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                        <br />
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                    </li>
                </InsertItemTemplate>
                <ItemSeparatorTemplate><br /></ItemSeparatorTemplate>
                <LayoutTemplate>
                    <ul id="itemPlaceholderContainer" runat="server" style="font-family: Verdana, Arial, Helvetica, sans-serif;">
                        <li runat="server" id="itemPlaceholder" />
                    </ul>
                    <div style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF;">
                        <asp:DataPager ID="DataPager1" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                            </Fields>
                        </asp:DataPager>
                    </div>
                </LayoutTemplate>
            </asp:ListView>
        </div>

    </form>
</body>
</html>
