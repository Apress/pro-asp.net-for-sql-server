<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TopUserControl.ascx.cs" Inherits="PageState_Controls_TopUserControl" %>
<%@ Register Src="BottomUserControl.ascx" TagName="BottomUserControl" TagPrefix="uc1" %>

<h2>Top User Control</h2>

ViewState Enabled: <asp:Label ID="Label1" runat="server"></asp:Label><br />
ViewState Data: <asp:Label ID="Label2" runat="server"></asp:Label><br />
ControlState Data: <asp:Label ID="Label3" runat="server"></asp:Label><br />

<uc1:BottomUserControl ID="BottomUserControl1" runat="server" EnableViewState="false" />
<uc1:BottomUserControl ID="BottomUserControl2" runat="server" EnableViewState="true" />
