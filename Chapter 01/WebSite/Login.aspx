<%@ Page Language="C#" MasterPageFile="~/Chapter01.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" Title="Chapter 1: Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <asp:Login ID="Login1" runat="server" CreateUserText="Create New Account" CreateUserUrl="~/CreateNewAccount.aspx" DestinationPageUrl="~/Home.aspx" PasswordRecoveryText="Forgot Password?" PasswordRecoveryUrl="~/PasswordRecovery.aspx" RememberMeSet="True">
    </asp:Login>
</asp:Content>

