<%@ Page Language="C#" MasterPageFile="~/FavoriteLink.master" AutoEventWireup="true" CodeFile="Tools.aspx.cs" Inherits="Tools" Title="Favorite Link: Tools" %>
<%@ Import namespace="Chapter07.Website"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">

<h3>Your Account</h3>

<ul>
<li><asp:HyperLink ID="hlChangePassword" runat="server" NavigateUrl="~/ChangePassword.aspx">Change Password</asp:HyperLink></li>
</ul>

</asp:Content>

