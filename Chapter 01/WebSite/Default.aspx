<%@ Page Language="C#" MasterPageFile="~/Chapter01.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Chapter 1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">

        <asp:Label ID="lblRolesStatus" runat="server" Text="Roles Status"></asp:Label>
        <br />
        
        <h2>Profile</h2>
        <c01:Profile ID="Profile1" runat="server" /><br />
        
</asp:Content>
