<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default" Title="Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ss:QuickTable ID="qt1" runat="server" TableName="Person" />
    <ss:QuickTable ID="at2" runat="server" TableName="Location" />
    <ss:Scaffold ID="s1" runat="Server" TableName="Person"></ss:Scaffold>
    <ss:Scaffold ID="s2" runat="Server" TableName="Location"></ss:Scaffold>
</asp:Content>
