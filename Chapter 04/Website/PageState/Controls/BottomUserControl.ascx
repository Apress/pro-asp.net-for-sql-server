<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BottomUserControl.ascx.cs"
    Inherits="PageState_Controls_BottomUserControl" %>
    
<div style="border: 1px solid #444; margin: 10px; padding: 5px;">
    <h2>Bottom User Control</h2>

    ViewState Enabled: <asp:Label ID="Label1" runat="server"></asp:Label><br />
    ViewState Data: <asp:Label ID="Label2" runat="server"></asp:Label><br />
    ControlState Data: <asp:Label ID="Label3" runat="server"></asp:Label><br />

</div>
