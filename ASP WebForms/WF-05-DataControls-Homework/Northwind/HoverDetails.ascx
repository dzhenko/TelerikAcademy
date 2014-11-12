<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HoverDetails.ascx.cs" Inherits="Northwind.HoverDetails" %>

<asp:ScriptManager ID="ScriptManager" runat="server" />

<div id="hoveredInfoHolder">
    <input runat="server" type="hidden" id="HiddenHoveredItemId" value="1"/>
</div>

<div id="hoveredWindowHolder" hidden="hidden">
    <asp:UpdatePanel runat="server" ID="UpdateDetailsWindow">
        <ContentTemplate>
            <asp:DetailsView Id="Details" runat="server" AutoGenerateRows="true"></asp:DetailsView>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>

<link href="resources/hoverDetails.css" rel="stylesheet" />
<script src="resources/hoverDetails.js"></script>