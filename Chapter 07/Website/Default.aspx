<%@ Page Language="C#" MasterPageFile="~/FavoriteLink.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Favorite Link" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
        
<table class="home">
<tr>
<td>
<p>
Favorite Links, for your online bookmarks.  Is this your first
visit?  Please <asp:HyperLink ID="hlCreateAccount" runat="server" NavigateUrl="~/CreateNewAccount.aspx">create a new account</asp:HyperLink>
today.  It is very easy.
</p>
<h3>Features</h3>
<ul>
<li>timely reminders</li>
<li>link tagging for quick access</li>
<li>link sharing with friends</li>
<li>rate your links for importance</li>
</ul>

</td>
<td class="login">
<fl:LoginControl ID="lc1" runat="server" />
</td>
</tr>
</table>

</asp:Content>
