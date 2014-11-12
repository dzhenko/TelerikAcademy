<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Clock.ascx.cs" Inherits="Clock.Clock" %>


<div id="timeZoneHolder" hidden="hidden">
    <asp:TextBox runat="server" ID="TimeZoneValue"></asp:TextBox>
</div>
<canvas id="clock" width="500" height="500"></canvas>
<script src="Clock/analogue_clock.js"></script>
<script>
    init();
</script>
