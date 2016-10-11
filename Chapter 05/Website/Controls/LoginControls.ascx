<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginControls.ascx.cs" Inherits="Controls_LoginControls" %>
<%@ Register Src="CreateCustomUserControl.ascx" TagName="CreateCustomUserControl"
    TagPrefix="uc1" %>
<%@ Register Src="CreateUserControl.ascx" TagName="CreateUserControl" TagPrefix="uc2" %>

<b>Select Action:</b>

<asp:DropDownList ID="ddlViewChanger" runat="server" AutoPostBack="True" 
    OnSelectedIndexChanged="ddlViewChanger_SelectedIndexChanged">
    <asp:ListItem Value="0">Log In</asp:ListItem>
    <asp:ListItem Value="1">Create User</asp:ListItem>
    <asp:ListItem Value="2">Create Custom User</asp:ListItem>
    <asp:ListItem Value="3">Recover Password</asp:ListItem>
    <asp:ListItem Value="4">Change Password</asp:ListItem>
</asp:DropDownList><br /><br />

<asp:MultiView ID="mvLoginControls" runat="server" ActiveViewIndex="0">
<asp:View ID="vwLogin" runat="server">
    <asp:Login ID="Login1" runat="server" PasswordRecoveryUrl="~/PasswordRecovery.aspx"
        RememberMeSet="True" VisibleWhenLoggedIn="False">
    </asp:Login>
</asp:View>
<asp:View ID="vwCreateUser" runat="server">
<uc2:CreateUserControl ID="CreateUserControl1" runat="server" />
</asp:View>
<asp:View ID="vwCreateCustomUser" runat="server">
<uc1:CreateCustomUserControl ID="CreateCustomUserControl1" runat="server" />
</asp:View>
<asp:View ID="vwRecoverPassword" runat="server">
<asp:PasswordRecovery ID="PasswordRecovery1" runat="server">
</asp:PasswordRecovery>
</asp:View>
<asp:View ID="vwChangePassword" runat="server">
<asp:ChangePassword ID="ChangePassword1" runat="server">
</asp:ChangePassword>
</asp:View>
</asp:MultiView>