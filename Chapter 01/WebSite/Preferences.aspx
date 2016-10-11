<%@ Page Language="C#" MasterPageFile="~/Chapter01.master" AutoEventWireup="true" CodeFile="Preferences.aspx.cs" Inherits="Preferences" Title="Chapter 1: Preferences" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">

    <h2>Profile</h2>    
    <c01:Profile ID="Profile1" runat="server" /><br />

    <asp:HyperLink ID="hlChangePassword" runat="server" NavigateUrl="~/ChangePassword.aspx">Change Password</asp:HyperLink>

</asp:Content>

