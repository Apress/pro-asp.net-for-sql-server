<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HeaderNavigation.ascx.cs"
    Inherits="Controls_HeaderNavigation" %>
<asp:HyperLink ID="hlHome" runat="server" NavigateUrl="~/">Home</asp:HyperLink>
|
<asp:HyperLink ID="hlAddLink" runat="server" NavigateUrl="~/AddLink.aspx">Add Link</asp:HyperLink>
<!--|
<asp:HyperLink ID="hlPrefs" runat="server" NavigateUrl="~/Preferences.aspx">Preferences</asp:HyperLink>-->
|
<asp:HyperLink ID="hlTools" runat="server" NavigateUrl="~/Tools.aspx">Tools</asp:HyperLink>
|
<asp:LoginStatus ID="ls1" runat="server" LogoutAction="Redirect" LogoutPageUrl="~/Default.aspx" />
